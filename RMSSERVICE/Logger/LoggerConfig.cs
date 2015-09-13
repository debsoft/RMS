using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace RMS
{
    /// <summary>
    /// The logger configuration object. Used when deserializing the
    /// logger config xml file.
    /// </summary>
    public class LoggerConfig
    {
        private int m_iFlushInterval;
        private string m_sAppName;
        private List<LogConfig> m_colLoggersConfig = new List<LogConfig>();
        private List<HandlerConfig> m_colHandlersConfig = new List<HandlerConfig>();

        public LoggerConfig()
        {
        }

        public int FlushInterval
        {
            get { return m_iFlushInterval; }
            set { m_iFlushInterval = value; }
        }

        public string AppName
        {
            get { return m_sAppName; }
            set { m_sAppName = value; }
        }

        [XmlArray("Loggers"), XmlArrayItem("Log", typeof(LogConfig))]
        public List<LogConfig> Loggers
        {
            get { return m_colLoggersConfig; }
            set { m_colLoggersConfig = value; }
        }

        [XmlArray("Handlers"), XmlArrayItem("Handler", typeof(HandlerConfig))]
        public List<HandlerConfig> Handlers
        {
            get { return m_colHandlersConfig; }
            set { m_colHandlersConfig = value; }
        }


    }//LoggerConfig

    /// <summary>
    /// The handler config object, used by LoggerConfig.
    /// </summary>
    [Serializable, XmlRoot(Namespace="Log")]
    public class LogConfig
    {
        private string m_sSource;
        private string m_sHandlerName;
        private int m_iLogLevel;

        public LogConfig()
        {
        }

        [XmlAttribute(AttributeName="source")]
        public string Source
        {
            get { return m_sSource; }
            set { m_sSource = value; }
        }

        [XmlAttribute(AttributeName = "handler")]
        public string HandlerName
        {
            get { return m_sHandlerName;}
            set { m_sHandlerName = value; }
        }

        [XmlAttribute(AttributeName = "loglevel")]
        public int LogLevel
        {
            get { return m_iLogLevel; }
            set { m_iLogLevel = value; }
        }

    }//LogConfig

    [Serializable, XmlRoot(ElementName="Handler", DataType="HandlerConfig")]
    public class HandlerConfig
    {
        private string m_sName;
        private string m_sAssembly;
        private string m_sType;
        private string m_sConfigFile;
/*
    <Handler name="FileHandler">
      <Assembly>Logger.dll</Assembly>
      <Type>Utils.Log.Handlers.FileHandler</Type>
      <Config>FileHandlerConfig.xml</Config>
    </Handler>         
*/
        public HandlerConfig()
        {
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        [XmlElement("Assembly", typeof(string))]
        public string Assembly
        {
            get { return m_sAssembly; }
            set { m_sAssembly = value; }
        }

        [XmlElement("Type", typeof(string))]
        public string Type
        {
            get { return m_sType; }
            set { m_sType = value; }
        }

        [XmlElement("Config", typeof(string))]
        public string ConfigFile
        {
            get { return m_sConfigFile; }
            set { m_sConfigFile = value; }
        }

    }


}//ns
