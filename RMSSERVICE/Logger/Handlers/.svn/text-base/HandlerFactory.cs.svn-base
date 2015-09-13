using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using System.Diagnostics;

using RMS;


using RMS.Handlers;

namespace Utils.Log.Handlers
{
    /// <summary>
    /// Log handler factory used to load and create log handlers.
    /// The factory keeps an internal static list of all loaded handlers,
    /// if a request to get a handler that is not loaded, it will be loaded
    /// and kept in the list for future use.
    /// </summary>
    class HandlerFactory
    {
        private static object _monitor = new object();
        private static Dictionary<string, AHandler> m_colHanderList = new Dictionary<string, AHandler>();
        private static string m_sAppName = "NoAppNameInFactory";
        private static LoggerConfig m_oLoggerConfig = null;
        private static string m_sRootFolder = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Static construtor.
        /// </summary>
        static HandlerFactory()
        {
            Debug.WriteLine("Creating HandlerFactory.", "HandlerFactory.ctor");
        }

        /// <summary>
        /// Sets the current application name.
        /// </summary>
        /// <param name="sAppName">The application name</param>
        public static void SetCurrentAppName(string sAppName)
        {
            lock (_monitor)
            {
                m_sAppName = sAppName;
            }
        }

        /// <summary>
        /// Sets the logger config object.
        /// </summary>
        /// <param name="oLoggerConfig"></param>
        public static void SetLoggerConfig(LoggerConfig oLoggerConfig)
        {
            lock (_monitor)
            {
                m_oLoggerConfig = oLoggerConfig;
            }
        }

        /// <summary>
        /// Creates a handler object and adds it to the internal list.
        /// </summary>
        /// <param name="sHandlerName">The name of the handler to load.</param>
        private static void LoadHandler(string sHandlerName)
        {
            Debug.WriteLine("Loading handler: " + sHandlerName, "HandlerFactory.LoadHandler");

            try
            {
                HandlerConfig oHandlerConfig = m_oLoggerConfig.Handlers.Find(delegate(HandlerConfig obj) { return obj.Name.Equals(sHandlerName, StringComparison.OrdinalIgnoreCase); });

                if (oHandlerConfig == null)
                {
                    Debug.WriteLine("A handler with the name '" + sHandlerName + "' could not be found. Loading default handler for this handler name.");
                    m_colHanderList.Add(sHandlerName, new WindowsEventHandler());
                    //throw new Exception("The configuration for the handler '" + sHandlerName + "' was not found. Check the 'Handlers' section of loggerconfig.xml and make sure the log handler is registered there.");
                }
                else
                {
                    System.Reflection.Assembly assembly = Assembly.LoadFrom(m_sRootFolder + oHandlerConfig.Assembly);
                    Type t = assembly.GetType(oHandlerConfig.Type);

                    if (t == null)
                        throw new Exception("Unable to load the type '" + oHandlerConfig.Type + "' for the handler '" + sHandlerName + "'. Check the 'Handlers' section of loggerconfig.xml and make sure the correct type is specified in the Type tag.");

                    AHandler oPlugin = (AHandler)Activator.CreateInstance(t);
                    oPlugin.Init(oHandlerConfig);

                    m_colHanderList.Add(sHandlerName, oPlugin);
                }

                //switch (sHandlerName)
                //{
                //    case "FileHandler":
                //    {
                //        //m_colHanderList.Add(sHandlerName, new FileHandler());

                //        System.Reflection.Assembly assembly = Assembly.LoadFrom("Logger.dll");
                //        Type t = assembly.GetType("Utils.Log.Handlers.FileHandler");
                //        AHandler oPlugin = (AHandler)Activator.CreateInstance(t);

                //        HandlerConfig oHandlerConfig = m_oLoggerConfig.Handlers.Find(delegate(HandlerConfig obj) { return obj.Name.Equals(sHandlerName, StringComparison.OrdinalIgnoreCase); });

                //        if (oHandlerConfig != null)
                //            oPlugin.Init(oHandlerConfig);
                //        else
                //            throw new Exception("The configuration for the handler '" + sHandlerName + "' was not found. Check the 'Handlers' section of loggerconfig.xml and make sure the log handler is registered there");

                //        m_colHanderList.Add(sHandlerName, oPlugin);

                //        break;
                //    }

                //    case "WindowsEventHandler":
                //        m_colHanderList.Add(sHandlerName, new WindowsEventHandler());
                //        break;

                //    case "SQLDBHandler":
                //        m_colHanderList.Add(sHandlerName, new SQLDBHandler());
                //        break;

                //    default: //WindowsEventHandler
                //        Debug.WriteLine("A handler with the name '" + sHandlerName + "' could not be found. Loading default handler for this handler name.");
                //        m_colHanderList.Add(sHandlerName, new WindowsEventHandler());
                //        break;
                //}
            }
            catch (Exception exp)
            {
                if (!EventLog.SourceExists(m_sAppName))
                    EventLog.CreateEventSource(m_sAppName, "Application");

                EventLog oEventLog = new EventLog();
                oEventLog.Source = m_sAppName;

                oEventLog.WriteEntry("Error loading handler: " + exp.Message, EventLogEntryType.Error, 0);
                
                if (exp.InnerException != null)
                    oEventLog.WriteEntry("Error loading handler (inner exception):" + exp.InnerException.Message, EventLogEntryType.Error, 0);

                //while (exp.InnerException != null)
                //{
                //    exp = exp.InnerException;
                //    oEventLog.WriteEntry("Error loading handler (inner exception):" + exp.Message, EventLogEntryType.Error, 0);
                //}

                oEventLog.Close();
            }
        }

        /// <summary>
        /// Gets a handler object by it's name.
        /// If the handler is not loaded yet it will be loaded and
        /// stored in the internal handler list for future use.
        /// </summary>
        /// <param name="sHandlerName">The name of the handler to get.</param>
        /// <returns>A log handler object.</returns>
        public static AHandler GetHandler(string sHandlerName)
        {
            Debug.WriteLine("Getting handler: " + sHandlerName, "HandlerFactory.GetHandler");
            //int iIndex = m_colHanderList.FindIndex(delegate(AHandler obj) { return obj.HandlerName == sHandlerName;});
            //return GetHandler(iIndex);
            lock (_monitor)
            {
                if (!m_colHanderList.ContainsKey(sHandlerName))
                {
                    LoadHandler(sHandlerName);
                    m_colHanderList[sHandlerName].AppName = m_sAppName;
                    m_colHanderList[sHandlerName].Open();
                }

                return m_colHanderList[sHandlerName];
            }
        }
        
        /// <summary>
        /// Disposes all loaded handlers and removes them
        /// from the internal handler list.
        /// </summary>
        public static void DisposeAllHandlers()
        {
            lock (_monitor)
            {
                foreach (AHandler oHandler in m_colHanderList.Values)
                {
                    if (oHandler != null)
                    {
                        Debug.WriteLine("Close/Dispose handler: " + oHandler.HandlerName, "HandlerFactory.DisposeAllHandlers");
                        oHandler.Close();
                        oHandler.Dispose();
                    }
                }

                m_colHanderList.Clear();
            }
        }

    }//class
}//ns
