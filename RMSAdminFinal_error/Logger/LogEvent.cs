using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    /// <summary>
    /// Logger event object. This is used in the internal
    /// queue for keeping all log data information.
    /// </summary>
    public class LogEvent
    {
        private LogLevel m_eLevel;
        private string m_sMessage;
        private string m_sCategory;
        private string m_sSource;
        private DateTime m_dtTime;
        private int m_iID;
        private object m_oData;

        #region Constructors

        /// <summary>
        /// Default constructor, set loglevel to debug and
        /// logtime to "now".
        /// </summary>
        public LogEvent()
        {
            m_eLevel = LogLevel.Debug;
            m_dtTime = DateTime.Now;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        public LogEvent(string sMessage)
            : this()
        {
            m_sSource = "DefaultSource";
            m_sMessage = sMessage;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        public LogEvent(string sMessage, LogLevel eLevel)
            : this(sMessage)
        {
            m_eLevel = eLevel;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        /// <param name="sSource">The source</param>
        public LogEvent(string sMessage, LogLevel eLevel, string sSource)
            : this(sMessage, eLevel)
        {
            m_sSource = sSource;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        /// <param name="sSource">The source</param>
        /// <param name="sCategory">The category</param>
        public LogEvent(string sMessage, LogLevel eLevel, string sSource, string sCategory)
            : this(sMessage, eLevel, sSource)
        {
            m_sCategory = sCategory;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        /// <param name="sSource">The source</param>
        /// <param name="sCategory">The category</param>
        /// <param name="iEventID">The event id</param>
        public LogEvent(string sMessage, LogLevel eLevel, string sSource, string sCategory, int iEventID)
            : this(sMessage, eLevel, sSource, sCategory)
        {
            m_iID = iEventID;
        }

        /// <summary>
        /// Overloaded constructor calling the default constructor.
        /// </summary>
        /// <param name="sMessage">The message</param>
        /// <param name="eLevel">The loglevel</param>
        /// <param name="sSource">The source</param>
        /// <param name="sCategory">The category</param>
        /// <param name="iEventID">The event id</param>
        /// <param name="oData">The custom data for the event</param>
        public LogEvent(string sMessage, LogLevel eLevel, string sSource, string sCategory, int iEventID, object oData)
            : this(sMessage, eLevel, sSource, sCategory, iEventID)
        {
            m_oData = oData;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The log level value, used to control the different
        /// levels of logging through the configuration file.
        /// </summary>
        public LogLevel Level
        {
            get { return m_eLevel; }
            set { m_eLevel = value; }
        }

        /// <summary>
        /// The message to log.
        /// </summary>
        public string Message
        {
            get { return m_sMessage; }
            set { m_sMessage = value; }
        }

        /// <summary>
        /// The log category, used to categorize log entries if
        /// needed.
        /// </summary>
        public string Category
        {
            get { return m_sCategory; }
            set { m_sCategory = value; }
        }

        /// <summary>
        /// The source of the log entry, used together with loglevel to
        /// control the different levels per source of logging 
        /// in the configuration file.
        /// </summary>
        public string Source
        {
            get { return m_sSource; }
            set { m_sSource = value; }
        }

        /// <summary>
        /// The time stamp for the event.
        /// </summary>
        public DateTime Time
        {
            get { return m_dtTime; }
            set { m_dtTime = value; }
        }

        /// <summary>
        /// The id of the event.
        /// </summary>
        public int ID
        {
            get { return m_iID; }
            set { m_iID = value; }
        }

        /// <summary>
        /// Custom data for the event.
        /// </summary>
        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        #endregion

    }//LogEvent
}
