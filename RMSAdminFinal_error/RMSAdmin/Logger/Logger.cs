using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Xml.Serialization;

using RMS.Handlers;
using Utils.Log.Handlers;

namespace RMS
{
    /// <summary>
    /// Singleton logger class.
    /// This class is used to write entries to the log. It is
    /// using an internal queue that is flushed at the interval 
    /// set by m_iFlushInterval. The default logger configuration
    /// file that will be loaded must be .\config\LoggerConfig.xml
    /// </summary>
    public sealed class Logger : IDisposable
    {
        //Main vars
        private string m_sAppSourceName = "NoAppNameInConfig";
        private string m_sConfigFile = AppDomain.CurrentDomain.BaseDirectory + ".\\config\\LoggerConfig.xml";
        private bool m_bDisposed;
        private LoggerConfig m_oLoggerConfig = null;

        //Timer related vars
        private int m_iFlushInterval = 2;
        private Queue m_qEvents; //would like to use Queue<T> here, but it does not have a synclock...maybe lock of _monitor is ok?...dunno
        private Timer m_oTimer; //is the Timer worse than spawning a thread and then sleep/wake that thread when needed?, i.e, homemade timer...
        private TimerCallback m_oTimerCallback;
        private FlusDelegate m_oFlushDelegate = new FlusDelegate();

        //Statics
        private static volatile Logger m_oLoggerInstance = null;
        private static object _monitor = new object();


        #region Constructor / Destructor / Dispose

        /// <summary>
        /// Private constructor, loads configuration, initializes the internal event queue
        /// and sets up the flush timer delegate.
        /// </summary>
        private Logger() //need sync locking in this constructor?
        {
            try
            {
                Debug.WriteLine("Creating Logger object.", "Logger.ctor");

                m_oLoggerConfig = (LoggerConfig)LoggerUtils.XMLSerializer.DeserializeObjectFromFile(typeof(LoggerConfig), m_sConfigFile);

                m_qEvents = new Queue();
                m_iFlushInterval = m_oLoggerConfig.FlushInterval;
                m_sAppSourceName = m_oLoggerConfig.AppName;

                m_oTimerCallback = new TimerCallback(m_oFlushDelegate.Flush);
                //m_oTimer = new Timer(m_oTimerCallback, null, m_iFlushInterval * 1000, m_iFlushInterval * 1000);

                //set the logger config object for the handler factory
                HandlerFactory.SetLoggerConfig(m_oLoggerConfig);
            }
            catch (IOException ioExp)
            {
                Debug.WriteLine("IOException while creating Logger(ctor). Logger will not log anything!: " + ioExp.Message, "Logger.ctor");
                ExceptionWriter("IOException while creating Logger(ctor). Logger will not log anything!", ioExp);
            }
            catch (LoggerUtils.XMLSerializerException xmlExp)
            {
                Debug.WriteLine("XMLSerializerException while creating Logger(ctor). Logger will not log anything!: " + xmlExp.Message, "Logger.ctor");
                ExceptionWriter("XMLSerializerException while creating Logger(ctor). Logger will not log anything!", xmlExp);
            }
            catch (Exception exp)
            {
                Debug.WriteLine("General exception while creating Logger(ctor). Logger will not log anything!: " + exp.Message, "Logger.ctor");
                ExceptionWriter("General exception while creating Logger(ctor). Logger will not log anything!", exp);
            }
        }

        /// <summary>
        /// Deconstructor, calling dispose.
        /// </summary>
        ~Logger()
        {
            Debug.WriteLine("~Logger() called.", "Logger.~dtor");
            Dispose(false);
        }

        /// <summary>
        /// Disposes the logger instance and flushes any non-written
        /// log entries from the internal queue.
        /// </summary>
        public void Dispose()
        {
            Debug.WriteLine("Dispose() called.", "Logger.Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the logger instance and flushes any non-written
        /// log entries from the internal queue.
        /// </summary>
        /// <param name="bIsDisposing"></param>
        public void Dispose(bool bIsDisposing)
        {
            Debug.WriteLine("Dispose(bool) called.", "Logger.Dispose(bool)");

            if (!m_bDisposed)
            {
                if (bIsDisposing)
                {
                    //clean up managed resources
                    m_oTimer.Dispose();
                    m_oTimer = null;
                    m_oTimerCallback = null;
                    m_oFlushDelegate = null;
                }

                //clean up potentially un-managed resources
                //and write events to handlers if queue is not empty
                if (m_qEvents != null)
                {
                    WriteToHandler();
                }
            }

            m_bDisposed = true;
        }

        public static void Reset()
        {
            Logger.Instance.Dispose();
        }

        #endregion

        #region Singleton Instance Property

        /// <summary>
        /// Static readonly property for getting the instance of the Logger object.
        /// </summary>
        /// <remarks>
        /// Double-Check Locking idiom is used to ensure singleton instance 
        /// in a multithreaded environment. This is thread safe but not inter-process
        /// safe.
        /// </remarks>
        private static Logger Instance
        {
            get
            {
                if (m_oLoggerInstance == null)
                {
                    lock (_monitor)
                    {
                        if (m_oLoggerInstance == null)
                            m_oLoggerInstance = new Logger();
                    }
                }
                return m_oLoggerInstance;
            }
        }

        #endregion

        #region Public Write Methods

        /// <summary>
        /// Writes an event to the log using the event object data.
        /// </summary>
        /// <param name="oEvent">Event object</param>
        public static void Write(LogEvent oEvent)
        {
            if (Instance != null && Instance.m_qEvents != null)
            {
                lock (Instance.m_qEvents.SyncRoot)
                {
                    Instance.m_qEvents.Enqueue(oEvent);
                }
            }
        }

        /// <summary>
        /// Writes a message to the log. Default loglevel(debug) and no 
        /// source will be used.
        /// </summary>
        /// <param name="sMessage">The message</param>
        public static void Write(string sMessage)
        {
            Write(new LogEvent(sMessage));
        }

        /// <summary>
        /// Writes a message to the log using the specified loglevel.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        public static void Write(string sMessage, LogLevel eLevel)
        {
            Write(new LogEvent(sMessage, eLevel));
        }

        /// <summary>
        /// Writes a message to the log using the specified loglevel and 
        /// source.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        /// <param name="sSource">The source</param>
        public static void Write(string sMessage, LogLevel eLevel, string sSource)
        {
            Write(new LogEvent(sMessage, eLevel, sSource));
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Writes from the internal queue to the appropriate
        /// log handlers. The loghandler should be defined in the
        /// logger configuration file. The handler will be selected
        /// based on the source specified in the logevent object.
        /// </summary>
        private void WriteToHandler()
        {
            lock (m_qEvents.SyncRoot) //maybe locking _monitor would be good enough? in that case a generic Queue<LogEvent> could be used :)
            {
                try
                {
                    if (m_qEvents.Count > 0)
                    {
                        Debug.WriteLine("Entries found in queue, writing to handler.", "Logger.WriteToHandler");

                        HandlerFactory.SetCurrentAppName(m_sAppSourceName);

                        while (m_qEvents.Count > 0)
                        {
                            if (m_qEvents.Peek() != null) //debug: this check might not be needed, but added as a safety when using multithreading.
                            {
                                LogEvent oEvent = (LogEvent)m_qEvents.Dequeue(); //TODO: should probably add the event to the queue again if an exception occurs in the code below!

                                string sHandlerName = GetHandlerName(oEvent.Source, oEvent.Level);

                                if (sHandlerName.Length > 0)
                                {
                                    HandlerFactory.GetHandler(sHandlerName).Log(oEvent);
                                }
                            }
                            else
                            {
                                m_qEvents.Dequeue(); //debug: experienced null values in the queue during multithread stress test...
                            }
                        }

                        Debug.WriteLine("Done writing to handler.", "Logger.WriteToHandler");
                    }
                    else
                    {
                        Debug.WriteLine("No entries found in queue.", "Logger.WriteToHandler");
                    }
                }
                catch (Exception exp)
                {
                    //For now we call ExceptionWriter, this will stop the timer and null the queue
                    Debug.WriteLine("Exception in Logger.WriteToHandler: " + exp.Message, "Logger.WriteToHandler");
                    ExceptionWriter("An exception occured in Logger.WriteToHandler: " + exp.Message, exp);
                }
                finally
                {
                    HandlerFactory.DisposeAllHandlers();
                }
            }
        }

        /// <summary>
        /// Gets the handler name for the given source and loglevel.
        /// </summary>
        /// <param name="sSource">The source</param>
        /// <param name="eLevel">The loglevel</param>
        /// <returns></returns>
        private string GetHandlerName(string sSource, LogLevel eLevel)
        {
            string sRetval = "";

            //search for requested source
            LogConfig oLogConfig = m_oLoggerConfig.Loggers.Find(delegate(LogConfig obj) { return obj.Source.Equals(sSource, StringComparison.OrdinalIgnoreCase); });

            if (oLogConfig == null) //then try to get default source
            {
                oLogConfig = m_oLoggerConfig.Loggers.Find(delegate(LogConfig obj) { return obj.Source.Equals("DefaultSource", StringComparison.OrdinalIgnoreCase); });
            }

            if (oLogConfig != null) //source found, requested or default
            {
                if ((oLogConfig.LogLevel & Convert.ToInt16(eLevel)) == Convert.ToInt16(eLevel))
                    sRetval = oLogConfig.HandlerName;
            }

            Debug.WriteLine("HandlerName for source: '" + sSource + "' was: '" + sRetval + "'", "Logger.GetHandlerName");
            return sRetval;
        }

        /// <summary>
        /// Flushes the internal queue.
        /// </summary>
        public static void Flush()
        {
            Logger.Instance.WriteToHandler();
        }

        /// <summary>
        /// Writes internal exceptions to the windows event log.
        /// If this throws and exception it will be rethrown to the
        /// caller.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="oException">The exception</param>
        private void ExceptionWriter(string sMessage, Exception oException)
        {
            try
            {
                if (!EventLog.SourceExists(m_sAppSourceName))
                {
                    EventLog.CreateEventSource(m_sAppSourceName, "Application");
                }

                EventLog oEventLog = new EventLog();

                oEventLog.Source = m_sAppSourceName;
                oEventLog.WriteEntry(sMessage + "\r\nLogger will now stop logging events!.\r\nThe error message was: " + oException.Message + "\r\nStacktrace:\r\n" + oException.StackTrace, EventLogEntryType.Error, 0);

                oEventLog.Close();
            }
            catch (Exception exp)
            {
                Debug.WriteLine("A fatal exception occured in Logger.ExceptionWriter: " + exp.Message + "\r\nStacktrace:\r\n" + exp.StackTrace, "Logger");
                throw new Exception("A fatal exception occured in Logger.ExceptionWriter: " + exp.Message + "\r\nCheck inner exception for information regarding the source of this error.", exp);
            }
            finally
            {
                if (m_oTimer != null)
                    m_oTimer.Dispose();

                m_qEvents = null;
            }
        }

        #endregion

        #region Private Class "FlushDelegate"

        /// <summary>
        /// Delegate used for the timer to initiate a "Flush" of
        /// the internal buffer of the Logger object instance.
        /// </summary>
        private class FlusDelegate
        {
            /// <summary>
            /// Flushes the internal queue of the logger instance.
            /// </summary>
            /// <param name="stateInfo"></param>
            public void Flush(Object stateInfo)
            {
                Logger.Instance.WriteToHandler();
            }
        }

        #endregion

    } //Logger
}//ns
