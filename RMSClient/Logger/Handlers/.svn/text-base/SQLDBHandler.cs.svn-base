using System;
using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using System.Xml;
//using System.Xml.XPath;
//using System.Globalization;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RMS.Handlers
{
    /// <summary>
    /// SQL Server database implementation.
    /// 
    /// TODO: Maybe implement option for using a static connection
    /// or static connection pooling to the database server.
    /// </summary>
    class SQLDBHandler : AHandler
    {
        protected static string m_sConfigFile = AppDomain.CurrentDomain.BaseDirectory + "Config/SQLDBHandlerConfig.xml";
        protected static SQLDBHandlerConfig m_oConfig = null;
        protected static object _monitor = new object();
        protected string m_sHandlerName = "SQLDBHandler";

        protected static string m_sConnString = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
        protected SqlConnection m_oConnection = null;
        protected int m_iConnectionTimeOut = 15;
        protected int m_iCommandTimeOut = 30;

        protected static string m_sSql = @"INSERT INTO {0} ([Log_Time],[Log_Source],[Log_Level],[Log_Category],[Log_EventID],[Log_Message]) 
                        VALUES ('{1}','{2}','{3}','{4}',{5},'{6}')"; // ,[Log_Data]   --    ,'{7}'

        #region Constructor

        /// <summary>
        /// Static constructor.
        /// </summary>
        static SQLDBHandler()
        {
            try
            {
                Debug.WriteLine("Creating SQLDBHandler object.", "SQLDBHandler.ctor");

                //lock (_monitor)
                //{
                //    m_oConfig = (SQLDBHandlerConfig)LoggerUtils.XMLSerializer.DeserializeObjectFromFile(typeof(SQLDBHandlerConfig), m_sConfigFile);
                //    m_sConnString = string.Format(m_sConnString, m_oConfig.Server, m_oConfig.Database, m_oConfig.User, m_oConfig.Password);

                //    if (m_oConfig.DateFormat != "")
                //        m_sSql = "SET DateFormat " + m_oConfig.DateFormat + ";" + m_sSql;

                //    CreateTable();
                //}
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Exception while creating SQLDBHandler: " + exp.Message, "SQLDBHandler.ctor");
                throw new Exception("Exception while creating SQLDBHandler: " + exp.Message, exp);
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
        /// Init the handler, loads the config file and creates the log table if needed.
        /// </summary>
        public override void Init(HandlerConfig oConfig)
        {
            lock (_monitor)
            {
                m_sConfigFile = FixConfigPath(oConfig.ConfigFile);

                m_oConfig = (SQLDBHandlerConfig)LoggerUtils.XMLSerializer.DeserializeObjectFromFile(typeof(SQLDBHandlerConfig), m_sConfigFile);
                m_sConnString = string.Format(m_sConnString, m_oConfig.Server, m_oConfig.Database, m_oConfig.User, m_oConfig.Password);

                if (m_oConfig.DateFormat != "")
                    m_sSql = "SET DateFormat " + m_oConfig.DateFormat + ";" + m_sSql;

                if (m_oConfig.AutoGenerateTable)
                    CreateTable();
            }
        }

        /// <summary>
        /// Opens the handler and prepares it's resources.
        /// </summary>
        public override void Open()
        {
            Debug.WriteLine("Opening SQLDBHandler.", "SQLDBHandler.Open");

            if (m_oConfig != null)
            {
                try
                {
                    m_oConnection = new SqlConnection(m_sConnString);
                    m_oConnection.Open();
                }
                catch (Exception exp)
                {
                    throw new Exception("Unable to open a connection to the specified server or database: " + exp.Message, exp);
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
            Debug.WriteLine("Closing SQLDBHandler.", "SQLDBHandler.Close");
            
            if (m_oConnection != null)
                m_oConnection.Close();
        }

        /// <summary>
        /// Logs an event to the handler resource.
        /// </summary>
        /// <param name="oEvent">The event object to be logged by the handler.</param>
        public override void Log(LogEvent oEvent)
        {
            string sSql = "";

            try
            {
                //[Log_Time],[Log_Source],[Log_Level],[Log_Category],[Log_EventID],[Log_Message],[Log_Data]
                sSql = string.Format(m_sSql, m_oConfig.Table, oEvent.Time, oEvent.Source, oEvent.Level.ToString().Substring(0, 1), oEvent.Category,
                    oEvent.ID, oEvent.Message); //, oEvent.Data

                SqlCommand oCommand = new SqlCommand(sSql, m_oConnection);
                oCommand.CommandTimeout = m_iCommandTimeOut;
                oCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw new Exception("Unable to insert event into database:" + exp.Message + "SQL Statement: " + sSql, exp);
            }
        }

        /// <summary>
        /// Disposes the handler and all it's resources.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine("Disposing SQLDBHandler object.", "SQLDBHandler.Dispose");
            
            if (m_oConnection != null)
                m_oConnection.Dispose();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Creates the log table using the database and table names
        /// from the configuration file. This method will throw an exception if
        /// unable to create the table.
        /// </summary>
        static protected void CreateTable()
        {
            string sSql = "";
            try
            {
                sSql = string.Format(@"
                    SET ANSI_NULLS ON;
                    SET QUOTED_IDENTIFIER ON;
                    SET ANSI_PADDING ON;
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))
                    BEGIN
                    CREATE TABLE [dbo].[{0}](
	                    [Log_Time] [datetime] NULL,
	                    [Log_Source] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	                    [Log_Level] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	                    [Log_Category] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	                    [Log_EventID] [int] NULL,
	                    [Log_Message] [varchar](3000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	                    [Log_Data] [varbinary](3000) NULL
                    ) ON [PRIMARY]
                    END
                    SET ANSI_PADDING OFF;"
                    , m_oConfig.Table);

                SqlConnection  oConnection = new SqlConnection(m_sConnString);
                oConnection.Open();

                SqlCommand oCommand = new SqlCommand(sSql, oConnection);
                oCommand.CommandTimeout = 30;
                oCommand.ExecuteNonQuery();

                if (oConnection != null)
                {
                    oConnection.Close();
                    oConnection.Dispose();
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Unable to auto create log table: " + exp.Message, exp);
            }
        }

        #endregion

    }//SQLDBHandler

    /// <summary>
    /// The SQLDBHandler handler config object used when 
    /// deserializing SQLDBHandlerConfig.xml
    /// </summary>
    public class SQLDBHandlerConfig
    {
        private string m_sServer;
        private string m_sDatabase;
        private string m_sTable;
        private string m_sUser;
        private string m_sPassword;
        private string m_sDateFormat;
        private bool m_bAutoGenerateTable;

        #region Properties

        /// <summary>
        /// Sets or gets the name of the SQL server.
        /// </summary>
        public string Server
        {
            get { return m_sServer; }
            set { m_sServer = value; }
        }

        /// <summary>
        /// Sets or gets the database name.
        /// </summary>
        public string Database
        {
            get { return m_sDatabase; }
            set { m_sDatabase = value; }
        }

        /// <summary>
        /// Gets or sets the table to log to.
        /// </summary>
        public string Table
        {
            get { return m_sTable; }
            set { m_sTable = value; }
        }

        /// <summary>
        /// Sets or gets the login user name.
        /// </summary>
        public string User
        {
            get { return m_sUser; }
            set { m_sUser = value; }
        }

        /// <summary>
        /// Sets of gets the login password.
        /// </summary>
        public string Password
        {
            get { return m_sPassword; }
            set { m_sPassword = value; }
        }

        /// <summary>
        /// Sets or gets the sql date format that should be used. Set to
        /// blank/nothing to use system default date format with sql server
        /// default collation settings.
        /// </summary>
        public string DateFormat
        {
            get { return m_sDateFormat; }
            set { m_sDateFormat = value; }
        }

        /// <summary>
        /// Sets or gets wether log table should be auto generated if
        /// it doesn't exist. Set to true to auto generate. Note, the 
        /// database will not be auto generated, only the table.
        /// </summary>
        public bool AutoGenerateTable
        {
            get { return m_bAutoGenerateTable; }
            set { m_bAutoGenerateTable = value; }
        }

        #endregion

    } //SQLDBHandlerConfig
}//ns
