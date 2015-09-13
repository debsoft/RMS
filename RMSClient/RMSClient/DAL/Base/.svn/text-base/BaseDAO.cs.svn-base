using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using System.Diagnostics;

using RMS.Common.Config;
using RMS.Common.DataAccess;
using RMS.Common;



namespace RMS
{
    namespace DataAccess
    {
        public class BaseDAO
        {
            protected IDbConnection m_oConnection;
            protected CDalConfig m_oDalConfig;

            protected IDbTransaction m_oTransaction = null;
            //protected int m_iConnectionTimeOut = 15;
            protected int m_iCommandTimeOut = 30;
            protected int m_iStatusCode = 0;
            protected string m_sLastError = "";

            #region Properties

            public int StatusCode
            {
                get { return m_iStatusCode; }
            }

            public string LastError
            {
                get { return m_sLastError; }
            }

            #endregion


            public BaseDAO()
            {
                //next two lines moved to OpenConnection()
                //if (m_oDalConfig == null)
                //    m_oDalConfig = ConfigManager.GetConfig<CDalConfig>();
            }

            protected IDbConnection CreateConnection(string sConnectionString)
            {
                //for now returning hardcoded connection object
                return new SqlConnection(sConnectionString);
            }

            protected IDbConnection CreateConnection(string sConnectionString, bool bUseTransaction)
            {
                //TODO: implement transaction code, please ask REM
                //for now returning hardcoded connection object
                return new SqlConnection(sConnectionString);
            }

            protected void OpenConnection()
            {
               // m_oDalConfig = ConfigManager.GetConfig<CDalConfig>();

                CCommonConstants m_oDalConfig = ConfigManager.GetConfig<CCommonConstants>();


                if (m_oDalConfig != null)
                {                   
                        OpenConnection(m_oDalConfig.DBConnection);                                      
                }
                else
                {
                    throw new DAOException("Error occured while opening database connection: DalConfig object was null.");
                }
            }

            protected void OpenConnectionWithTransection()
            {
                SqlTransaction tranSection = null;
                OpenConnection();
                SqlConnection connection = (SqlConnection)this.m_oConnection;
                tranSection = connection.BeginTransaction();
                this.m_oTransaction = tranSection;
            }

            protected void RollBackTransection()
            {
                if (this.m_oTransaction != null)
                    this.m_oTransaction.Rollback();
            }

            protected void CommitTransection()
            {
                if (m_oTransaction != null)
                    m_oTransaction.Commit();
            }

            protected void OpenConnection(string sConnectionString)
            {
                try
                {
                    if (sConnectionString.Length>0)
                    {
                        m_oConnection = this.CreateConnection(sConnectionString);
                        m_oConnection.Open();
                    }
                    else
                    {
                        throw new DAOException("Error occured while oppening database connection: ConnectionString was empty.");
                    }
                }
                catch (Exception exp)
                {
                    //TODO: Logs the error and send emails
                    throw new Exception("Exception occured while oppening database connection.", exp);
                }
            }

            protected void CloseConnection()
            {
                try
                {
                    if (m_oConnection != null)
                    {
                        m_oConnection.Close();
                        m_oConnection.Dispose();
                        m_oConnection = null;
                    }

                    if (m_oTransaction != null)
                    {
                        m_oTransaction.Dispose();
                        m_oTransaction = null;
                    }
                }
                catch (Exception exp)
                {
                    //TODO: Logs the error and send emails
                    throw new Exception("Exception occured while closing database connection.", exp);
                }
            }

            protected IDbCommand CreateCommand(string sSqlStatement)
            {
                if (m_oConnection == null)
                {
                    this.OpenConnection(); //Establish connection
                }
                
                IDbCommand oCommand = m_oConnection.CreateCommand();

                oCommand.CommandText = sSqlStatement;
                oCommand.CommandType = CommandType.Text;
                oCommand.CommandTimeout = m_iCommandTimeOut;

                if (m_oTransaction != null)
                    oCommand.Transaction = m_oTransaction;

                return oCommand;
            }

            /// <summary>ExecuteReader
            /// <para>Executes a sql query against the current open database connection.</para>
            /// <param name='SqlStatement'>SqlStatement to run</param>
            /// <returns>Returns a SqlDataReader</returns>
            /// </summary>
            public IDataReader ExecuteReader(string sSqlStatement)
            {
                IDbCommand oCommand;
                IDataReader oDataReader;

                try
                {
                    if (sSqlStatement != "")
                    {
                        oCommand = CreateCommand(sSqlStatement);
                        
                        oDataReader = oCommand.ExecuteReader();
                 
                    }
                    else
                    {
                        m_sLastError = "No sql statement specified";
                        m_iStatusCode = 1;
                        throw (new DAOArgumentException(m_sLastError, "sSqlStatement"));
                    }

                    oCommand.Dispose();

                    return oDataReader;

                }
                catch (Exception exp)
                {
                    m_sLastError = "Error in ExecuteSQL: " + exp.Message;
                    m_iStatusCode = 2;
                    throw (new DAOException(m_sLastError, exp));
                }

            } //ExecuteSQL()



            /// <summary>ExecuteNonQuery
            /// <para>Executes a sql query against the current open database connection.</para>
            /// <para>ExecuteNonQuery does not return anything.</para>
            /// <param name='SqlStatement'>SqlStatement to run</param>
            /// </summary>
            public void ExecuteNonQuery(string sSqlStatement)
            {
                IDbCommand oCommand;

                try
                {
                    if (sSqlStatement != "")
                    {
                       
                        oCommand = CreateCommand(sSqlStatement);

                        oCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        m_sLastError = "No sql statement specified";
                        m_iStatusCode = 1;
                        throw (new DAOArgumentException(m_sLastError, "sSqlStatement"));
                    }

                    oCommand.Dispose();
                }
                catch (Exception exp)
                {
                    m_sLastError = "Error in ExecuteNonQuery: " + exp.Message;
                    m_iStatusCode = 2;
                    throw (new DAOException(m_sLastError, exp));
                }

            } //ExecuteNonQuery()



            /// <summary>ExecuteScalar
            /// <para>Executes a sql query against the current open database connection 
            /// and returns the first column from the first row.
            /// </para>
            /// <param name='SqlStatement'>SqlStatement to run</param>
            /// <returns>The first column from the first row</returns>
            /// </summary>
            public object ExecuteScalar(string sSqlStatement)
            {
                IDbCommand oCommand;
                object oRetVal = null;

                try
                {
                    if (sSqlStatement != "")
                    {
                        oCommand = CreateCommand(sSqlStatement);

                        oRetVal = oCommand.ExecuteScalar();
                    }
                    else
                    {
                        m_sLastError = "No sql statement specified";
                        m_iStatusCode = 1;
                        throw (new DAOArgumentException(m_sLastError, "sSqlStatement"));
                    }

                    oCommand.Dispose();
                    return oRetVal;
                }
                catch (Exception exp)
                {
                    m_sLastError = "Error in ExecuteNonQuery: " + exp.Message;
                    m_iStatusCode = 2;
                    throw (new DAOException(m_sLastError, exp));
                }

            } //ExecuteScalar()




            #region Custom Exception Classes

            public class DAOException : Exception
            {
                public DAOException()
                {
                }
                public DAOException(string message)
                    : base(message)
                {
                }
                public DAOException(string message, Exception inner)
                    : base(message, inner)
                {
                }
            }

            public class DAOArgumentException : ArgumentException
            {
                public DAOArgumentException()
                {
                }
                public DAOArgumentException(string message)
                    : base(message)
                {
                }
                public DAOArgumentException(string message, Exception inner)
                    : base(message, inner)
                {
                }
                public DAOArgumentException(string message, string paramName)
                    : base(message, paramName)
                {
                }
            }

            #endregion


        }//ADAO
    }//ns
}//ns
