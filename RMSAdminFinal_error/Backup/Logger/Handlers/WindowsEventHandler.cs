using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RMS.Handlers
{
    /// <summary>
    /// Windows event handler implementation.
    /// </summary>
    class WindowsEventHandler : AHandler
    {
        private EventLog m_oEventLog = null;
        private string m_sHandlerName = "WindowsEventHandler";

        #region Constructor

        //Static constructor only used for debug purposes.
        static WindowsEventHandler()
        {
            Debug.WriteLine("Creating WindowsEventHandler object.", "WindowsEventHandler.ctor");
        }

        #endregion

        #region Overrided Abstract Methods and Properties

        public override string HandlerName
        {
            get { return m_sHandlerName; }
        }

        public override void Init(HandlerConfig oConfig)
        {
        }

        public override void Open()
        {
            Debug.WriteLine("Opening WindowsEventHandler.", "WindowsEventHandler.Open");

            m_oEventLog = new EventLog();

            if (!EventLog.SourceExists(this.AppName))
                EventLog.CreateEventSource(this.AppName, "Application");
        }

        public override void Close()
        {
            Debug.WriteLine("Closing WindowsEventHandler.", "WindowsEventHandler.Close");

            if (m_oEventLog != null)
                m_oEventLog.Close();
        }

        public override void Log(LogEvent oEvent)
        {
            m_oEventLog.Source = this.AppName;
            m_oEventLog.WriteEntry(oEvent.Message, GetEventEntryType(oEvent.Level), oEvent.ID);
            //test exception
            //throw new Exception("test exp from WindowsEventHandler class");
        }

        public override void Dispose()
        {
            Debug.WriteLine("Disposing WindowsEventHandler.", "WindowsEventHandler.Dispose");

            if (m_oEventLog != null)
                m_oEventLog.Dispose();
        }

        #endregion

        #region Private Methods

        private EventLogEntryType GetEventEntryType(LogLevel eLevel)
        {
            EventLogEntryType eRetval;

            switch (eLevel)
            {
                case LogLevel.Warning:
                    eRetval = EventLogEntryType.Warning;
                    break;
                case LogLevel.Error:
                case LogLevel.Fatal:
                    eRetval = EventLogEntryType.Error;
                    break;

                //case LogLevel.Debug:
                //case LogLevel.Information:
                default:
                    eRetval = EventLogEntryType.Information;
                    break;
            }

            return eRetval;
        }

        #endregion

    }//class
}//ns
