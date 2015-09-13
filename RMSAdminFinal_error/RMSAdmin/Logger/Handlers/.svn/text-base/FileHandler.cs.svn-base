using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Globalization;

namespace RMS.Handlers
{
    /// <summary>
    /// File handler implementation.
    /// TODO: Proper file and folder creation schemes have not been
    /// implemented yet.
    /// TODO: documentation
    /// </summary>
    class FileHandler : AHandler
    {
        private StreamWriter m_oWriter = null;
        private XmlDocument m_oXmlDoc = null;
        private string m_sLogFilename = "LogFile1.txt";
        private string m_sLogLinePattern = "{0} [{1}] [{2}] {3}";
        private string m_sLogLinePatternXML = "<LogTime>{0}</LogTime><LogSource>{1}</LogSource><LogType>{2}</LogType><LogMessage>{3}</LogMessage>";
        private int m_iWriterBufferSize = 1024;
        private Encoding m_oCharacterEncoding = Encoding.UTF8;

        private static string m_sConfigFile = AppDomain.CurrentDomain.BaseDirectory + "Config/FileHandlerConfig.xml";
        private static FileHandlerConfig m_oConfig = null;
        private static object _monitor = new object();

        private string m_sHandlerName = "FileHandler";

        #region Constructor

        /// <summary>
        /// Static constructor.
        /// </summary>
        static FileHandler()
        {
            try
            {
                Debug.WriteLine("Creating FileHandler object.", "FileHandler.ctor");

                //lock (_monitor)
                //{
                //    m_oConfig = (FileHandlerConfig)LoggerUtils.XMLSerializer.DeserializeObjectFromFile(typeof(FileHandlerConfig), m_sConfigFile);
                //}
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Exception while creating FileHandler: " + exp.Message, "FileHandler.ctor");
                throw new Exception("Exception while creating FileHandler: " + exp.Message, exp);
            }
        }

        #endregion

        #region Overrided Abstract Methods and Properties

        /// <summary>
        /// Gets the name of the handler.
        /// </summary>
        public override string HandlerName
        {
            get { return m_sHandlerName; }
        }

        /// <summary>
        /// Init the handler, for loading the config file.
        /// </summary>
        public override void Init(HandlerConfig oConfig)
        {
            lock (_monitor)
            {
                m_sConfigFile = FixConfigPath(oConfig.ConfigFile);

                //if (Path.IsPathRooted(oConfig.ConfigFile))
                //    m_sConfigFile = oConfig.ConfigFile;
                //else
                //    m_sConfigFile = AppDomain.CurrentDomain.BaseDirectory + "config/" + oConfig.ConfigFile;

                m_oConfig = (FileHandlerConfig)LoggerUtils.XMLSerializer.DeserializeObjectFromFile(typeof(FileHandlerConfig), m_sConfigFile);
            }
        }

        /// <summary>
        /// Opens the handler and prepares it's resources.
        /// </summary>
        public override void Open()
        {
            Debug.WriteLine("Opening FileHandler.", "FileHandler.Open");

            if (m_oConfig != null)
            {
                if (!m_oConfig.SaveAsXML) //text file
                {
                    m_oWriter = new StreamWriter(GetLogFoldername() + GetLogFilename(), true, m_oCharacterEncoding, m_iWriterBufferSize);
                    m_oWriter.AutoFlush = false;
                }
                else //xml file
                {
                    bool bNewFile = File.Exists(GetLogFoldername() + GetLogFilename());
                    m_oXmlDoc = new XmlDocument();

                    if (!bNewFile) //create new xml file
                        m_oXmlDoc.AppendChild(m_oXmlDoc.CreateElement("LogFile"));
                    else //load existing xml file
                        m_oXmlDoc.Load(GetLogFoldername() + GetLogFilename());
                }
            }
            else
            {
                //should be specialized
                throw new Exception("No LoggerConfig object was specified (m_oConfig was null).");
            }
        }

        /// <summary>
        /// Closes the handler and it's underlaying resources.
        /// </summary>
        public override void Close()
        {
            Debug.WriteLine("Closing FileHandler.", "FileHandler.Close");

            if (!m_oConfig.SaveAsXML) //close text file
            {
                if (m_oWriter != null)
                    m_oWriter.Close();
            }
            else //save xml file
            {
                m_oXmlDoc.Save(GetLogFoldername() + GetLogFilename());
            }
        }

        /// <summary>
        /// Logs an event to the handler resource.
        /// </summary>
        /// <param name="oEvent">The event object to be logged by the handler.</param>
        public override void Log(LogEvent oEvent)
        {
            if (!m_oConfig.SaveAsXML) //write to text file
            {
                m_oWriter.WriteLine(GetLogLinePattern(), oEvent.Time.ToString(), oEvent.Source, oEvent.Level.ToString().Substring(0, 1), oEvent.Message);
            }
            else //add to xml doc
            {
                XmlElement oElemLine = m_oXmlDoc.CreateElement("LogLineItem");
                oElemLine.InnerXml = string.Format(GetLogLinePattern(), oEvent.Time.ToString("yyyy-MM-ddThh:mm:ss"), oEvent.Source, oEvent.Level.ToString().Substring(0, 1), oEvent.Message);
                m_oXmlDoc.DocumentElement.AppendChild(oElemLine);
            }
        }

        /// <summary>
        /// Disposes the handler and all it's resources.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine("Disposing FileHandler object.", "FileHandler.Dispose");
            if (m_oWriter != null)
            {
                m_oWriter.Close();
                m_oWriter.Dispose(); //RC1 only
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the pattern for a single log line.
        /// </summary>
        /// <returns>The log line pattern.</returns>
        private string GetLogLinePattern()
        {
            if (m_oConfig.SaveAsXML)
                return m_sLogLinePatternXML;
            else
                return m_sLogLinePattern;
        }

        /// <summary>
        /// Gets the name of the log file based on the file naming
        /// scheme specified in the configuration file.
        /// </summary>
        /// <returns>The file name for the log file.</returns>
        private string GetLogFilename()
        {
            switch (m_oConfig.FileNaming)
            {
                case FileNameScheme.Daily:
                    return string.Format("{0}{1}.{2}",
                            m_oConfig.FileNamePrefix,
                            DateTime.Now.ToString("yyyyMMdd"),
                            m_oConfig.FileNameExtension);

                case FileNameScheme.MaxSize:
                    return GetFileNameMaxSize();
                default:
                    return m_sLogFilename;
            }
        }

        private string GetFileNameMaxSize()
        {
            int iFileCount = Directory.GetFiles(GetLogFoldername(), "Log" + "*." + "txt").Length;

            if (iFileCount == 0)
                iFileCount = 1;

            string sTempFilename = string.Format("{0}{1}{2}.{3}",
                m_oConfig.FileNamePrefix,
                m_oConfig.FileMaxSizeName,
                iFileCount,
                m_oConfig.FileNameExtension);

            FileInfo oInfo = new FileInfo(GetLogFoldername() + sTempFilename);

            if (oInfo.Exists)
            {
                if (oInfo.Length / 1000 >= m_oConfig.FileMaxSize)
                {
                    sTempFilename = string.Format("{0}{1}{2}.{3}",
                        m_oConfig.FileNamePrefix,
                        m_oConfig.FileMaxSizeName,
                        iFileCount + 1,
                        m_oConfig.FileNameExtension);
                }
            }

            return sTempFilename;
        }

        /// <summary>
        /// Gets the name of the log folder based on the folder naming
        /// scheme specified in the configuration file.
        /// </summary>
        /// <returns>The folder for the log file.</returns>
        private string GetLogFoldername()
        {
            CultureInfo oInfo;
            string sFolder = m_oConfig.LogFolder.TrimEnd('\\') + "\\";

            try
            {
                oInfo = new CultureInfo(m_oConfig.Culture);

                switch (m_oConfig.FolderNaming)
                {
                    case FolderNameScheme.Day:
                        sFolder += DateTime.Now.ToString(m_oConfig.DayFormat) + "\\";
                        break;

                    case FolderNameScheme.Month:
                        sFolder += DateTime.Now.ToString(m_oConfig.MonthFormat, oInfo) + "\\";
                        break;

                    case FolderNameScheme.MonthDay:
                        sFolder += DateTime.Now.ToString(m_oConfig.MonthFormat, oInfo) + "\\";
                        sFolder += DateTime.Now.ToString(m_oConfig.DayFormat) + "\\";
                        break;

                    case FolderNameScheme.YearMonthDay:
                        sFolder += DateTime.Now.Year.ToString() + "\\";
                        sFolder += DateTime.Now.ToString(m_oConfig.MonthFormat, oInfo) + "\\";
                        sFolder += DateTime.Now.ToString(m_oConfig.DayFormat) + "\\";
                        break;

                    case FolderNameScheme.YearMonth:
                        sFolder += DateTime.Now.Year.ToString() + "\\";
                        sFolder += DateTime.Now.ToString(m_oConfig.MonthFormat, oInfo) + "\\";
                        break;

                    default: //none
                        break;
                }

                //create folder if it does not exist.
                if (!Directory.Exists(sFolder))
                    Directory.CreateDirectory(sFolder);
            }
            catch (Exception exp)
            {
                throw new Exception("Error creating log folder, ensure that the account running the application has sufficient permissions and verify the configuration file settings.", exp);
            }

            return sFolder;
        }

        #endregion

    }//FileHandler

    /// <summary>
    /// The file handler config object used when 
    /// deserializing filehandlerconfig.xml
    /// </summary>
    public class FileHandlerConfig
    {
        private string m_sLogFolder;
        private FileNameScheme m_eFileNaming;
        private FolderNameScheme m_eFolderNaming;
        private string m_sFileMaxSizeName;
        private int m_iFileMaxSize;
        private string m_sFileNamePrefix;
        private string m_sFileNameExtension;
        private bool m_sSaveAsXML;

        private string m_sMonthFormat;
        private string m_sDayFormat;
        private string m_sCulture;

        #region Properties

        /// <summary>
        /// Gets or sets the base folder for the log files.
        /// </summary>
        public string LogFolder
        {
            get { return m_sLogFolder; }
            set { m_sLogFolder = value; }
        }

        /// <summary>
        /// Gets or sets the filenaming scheme.
        /// </summary>
        public FileNameScheme FileNaming
        {
            get { return m_eFileNaming; }
            set { m_eFileNaming = value; }
        }

        /// <summary>
        /// Gets or sets the foldernaming scheme.
        /// </summary>
        public FolderNameScheme FolderNaming
        {
            get { return m_eFolderNaming; }
            set { m_eFolderNaming = value; }
        }

        /// <summary>
        /// Gets or sets the base filename used with the "MaxSize" 
        /// filenaming scheme.
        /// </summary>
        public string FileMaxSizeName
        {
            get { return m_sFileMaxSizeName; }
            set { m_sFileMaxSizeName = value; }
        }

        /// <summary>
        /// Gets or sets the maximum file size used with "MaxSize" 
        /// filenaming scheme.
        /// </summary>
        public int FileMaxSize
        {
            get { return m_iFileMaxSize; }
            set { m_iFileMaxSize = value; }
        }

        /// <summary>
        /// Gets or sets the prefix for the filenames.
        /// </summary>
        public string FileNamePrefix
        {
            get { return m_sFileNamePrefix; }
            set { m_sFileNamePrefix = value; }
        }

        /// <summary>
        /// Gets or sets the extension of the log file.
        /// </summary>
        public string FileNameExtension
        {
            get { return m_sFileNameExtension; }
            set { m_sFileNameExtension = value; }
        }

        /// <summary>
        /// Gets or sets saving the log as XML or as normal text.
        /// </summary>
        public bool SaveAsXML
        {
            get { return m_sSaveAsXML; }
            set { m_sSaveAsXML = value; }
        }

        /// <summary>
        /// Gets or sets the format expression for month naming.
        /// </summary>
        public string MonthFormat
        {
            get { return m_sMonthFormat; }
            set { m_sMonthFormat = value; }
        }

        /// <summary>
        /// Gets or sets the format expression for day naming.
        /// </summary>
        public string DayFormat
        {
            get { return m_sDayFormat; }
            set { m_sDayFormat = value; }
        }

        /// <summary>
        /// Gets or sets the culture info name. This is used
        /// when formating the month name to get language 
        /// specific names.
        /// </summary>
        public string Culture
        {
            get { return m_sCulture; }
            set { m_sCulture = value; }
        }

        #endregion

    } //FileHandlerConfig
}//ns
