using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;

namespace RMSServerSetupDBCreationAction
{
    [RunInstaller(true)]
    public partial class DatabaseCreationInstaller : Installer
    {
        public DatabaseCreationInstaller()
        {
            InitializeComponent();
        }//DatabaseCreationInstaller

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }//Install

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);

            #region Get Parameters From Dialogs

            string dbServerName = this.Context.Parameters["Server"];
            string dbUserName = this.Context.Parameters["UserName"];
            string dbUserPassword = this.Context.Parameters["Password"];
          

            Debug.WriteLine("Commit - AppServer: " + dbServerName);
            Debug.WriteLine("Commit - AppUserName: " + dbUserName);
            Debug.WriteLine("Commit - AppPassword: " + dbUserPassword);
            

            #endregion

            #region Prepare Database Creation

            string sConnString = "User ID={0};Password={1};Database={2};Data Source={3};Pooling=true;Min Pool Size=1;Max Pool Size=3;";
            string sqlCommand = "";
            string sMasterDB = "Master";
            SqlConnection cobConnection = null;
            SqlCommand cmdName = null;

            #endregion

            

            #region Create Application Database

            try
            {
                Debug.WriteLine("Creating application database: 1 ");
                //application connection
                cobConnection = new SqlConnection(string.Format(sConnString, dbUserName, dbUserPassword, sMasterDB, dbServerName));

                //open application connection
                cobConnection.Open();

                //create application database
                sqlCommand = GetSqlScript("App_Database.sql");
                Debug.WriteLine("Creating application database: ");
                this.Context.LogMessage("Creating application database: " );

                cmdName = new SqlCommand(sqlCommand, cobConnection);
                cmdName.ExecuteNonQuery();
                Debug.WriteLine("Application database created.");
                this.Context.LogMessage("Application database created.");

                //create inbox/outbox tables
                sqlCommand = GetSqlScript("App_Tables.sql");
                Debug.WriteLine("Creating application tables: " );
                this.Context.LogMessage("Creating application tables: " );

                cmdName = new SqlCommand(sqlCommand, cobConnection);

                //oCmd.CommandType = System.Data.CommandType.Text;
                cmdName.ExecuteNonQuery();
                Debug.WriteLine("Application tables created.");
                this.Context.LogMessage("Application tables created.");

/*
                sqlCommand = GetSqlScript("AddDeleteParentCat.sql");
                this.Context.LogMessage("Creating application tables: ");
                cmdName = new SqlCommand(sqlCommand, cobConnection);
                cmdName.ExecuteNonQuery();
                this.Context.LogMessage("Application stored procedure parent cat created.");
                
                sqlCommand = GetSqlScript("AddDeleteCat1.sql");                
                this.Context.LogMessage("Creating application tables: ");
                cmdName = new SqlCommand(sqlCommand, cobConnection);        
                cmdName.ExecuteNonQuery();
                this.Context.LogMessage("Application stored procedure cat1 created.");

                sqlCommand = GetSqlScript("AddDeleteCat2.sql");
                this.Context.LogMessage("Creating application tables: ");
                cmdName = new SqlCommand(sqlCommand, cobConnection);
                cmdName.ExecuteNonQuery();
                this.Context.LogMessage("Application stored procedure cat2 created.");

                sqlCommand = GetSqlScript("AddDeleteCat3.sql");
                this.Context.LogMessage("Creating application tables: ");
                cmdName = new SqlCommand(sqlCommand, cobConnection);
                cmdName.ExecuteNonQuery();
                this.Context.LogMessage("Application stored procedure cat3 created.");

                sqlCommand = GetSqlScript("AddDeleteCat4.sql");
                this.Context.LogMessage("Creating application tables: ");
                cmdName = new SqlCommand(sqlCommand, cobConnection);
                cmdName.ExecuteNonQuery();
                this.Context.LogMessage("Application stored procedure cat4 created.");
 * */
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Error creating application database: " + exp.Message);
                this.Context.LogMessage("Error creating application database: " + exp.Message);

                throw new InstallException("Error creating application database: " + exp.Message);
            }
            finally
            {
                //close application connection
                if (cobConnection!=null)
                    cobConnection.Close();
            }

            #endregion

            #region Cleanup Database Creation

            if (cmdName!=null)
                cmdName.Dispose();

            if (cobConnection!=null)
                cobConnection.Dispose();

            #endregion

        }//Commit

        private string GetSqlScript(string sScriptFileName)
        {
            string sRetval = null;
            Stream oStream = null;
            StreamReader oReader = null;

            try
            {
                Assembly oAsm = Assembly.GetExecutingAssembly();
                Debug.WriteLine("Assembly name : " + oAsm.GetName().Name);
                oStream = oAsm.GetManifestResourceStream(oAsm.GetName().Name + "." + sScriptFileName);

                if (oStream != null)
                {
                    oReader = new StreamReader(oStream);
                    sRetval = oReader.ReadToEnd();

                    oReader.Close();
                    oStream.Close();
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Error getting resource '" + sScriptFileName + "' from assembly: " + exp.Message);
                this.Context.LogMessage("Error getting resource '" + sScriptFileName + "' from assembly: " + exp.Message);

                throw exp;
            }
            finally
            {
                if (oReader!=null)
                    oReader.Close();

                if (oStream!=null)
                    oStream.Close();
            }

            return sRetval;
        }//GetSqlScript

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
        }//Rollback

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
        }//Uninstall

    }//DatabaseCreationInstaller
}//ns