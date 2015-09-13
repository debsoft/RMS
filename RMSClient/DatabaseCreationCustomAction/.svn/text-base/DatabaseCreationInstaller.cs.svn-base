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

namespace CellBazaarSvcSetupDBCreationAction
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

            #region Debug and Help

            //System.Diagnostics.Debugger.Launch();

            //This is for the CustomActionData property in the custom actions editor
            //It connects the [VARIABLE] in the dialogs with /Variable parameter in the Context.Paramaters.
            //   /Server="[APP_SERVER]" /UserName="[APP_USERNAME]" /Password="[APP_PASSWORD]" /BoxServer="[BOX_SERVER]" /BoxUserName="[BOX_USERNAME]" /BoxPassword="[BOX_PASSWORD]"

            #endregion

            #region Get Parameters From Dialogs

            string sServer = this.Context.Parameters["Server"];
            string sUserName = this.Context.Parameters["UserName"];
            string sPassword = this.Context.Parameters["Password"];
            string sBoxServer = this.Context.Parameters["BoxServer"];
            string sBoxUserName = this.Context.Parameters["BoxUserName"];
            string sBoxPassword = this.Context.Parameters["BoxPassword"];

            Debug.WriteLine("Commit - AppServer: " + sServer);
            Debug.WriteLine("Commit - AppUserName: " + sUserName);
            Debug.WriteLine("Commit - AppPassword: " + sPassword);
            Debug.WriteLine("Commit - BoxServer: " + sBoxServer);
            Debug.WriteLine("Commit - BoxUserName: " + sBoxUserName);
            Debug.WriteLine("Commit - BoxPassword: " + sBoxPassword);

            #endregion

            #region Prepare Database Creation

            string sConnString = "User ID={0};Password={1};Database={2};Data Source={3};Pooling=true;Min Pool Size=1;Max Pool Size=3;";
            string sSql = "";
            string sMasterDB = "Master";
            SqlConnection oConn = null;
            SqlCommand oCmd = null;

            #endregion

            #region Create Inbox/Outbox Database

            try
            {
                //inbox/outbox connection
                oConn = new SqlConnection(string.Format(sConnString, sBoxUserName, sBoxPassword, sMasterDB, sBoxServer));

                //open inbox/outbox connection
                oConn.Open();

                //create inbox/outbox database
                sSql = GetSqlScript("Box_Database.sql");
                Debug.WriteLine("Creating inbox/outbox database: " + sSql);
                this.Context.LogMessage("Creating inbox/outbox database: " + sSql);

                oCmd = new SqlCommand(sSql, oConn);
                oCmd.ExecuteNonQuery();
                Debug.WriteLine("Inbox/outbox database created.");
                this.Context.LogMessage("Inbox/outbox database created.");

                //create inbox/outbox tables
                sSql = GetSqlScript("Box_Tables.sql");
                Debug.WriteLine("Creating inbox/outbox tables: " + sSql);
                this.Context.LogMessage("Creating inbox/outbox tables: " + sSql);

                oCmd = new SqlCommand(sSql, oConn);
                oCmd.ExecuteNonQuery();
                Debug.WriteLine("Inbox/outbox tables created.");
                this.Context.LogMessage("Inbox/outbox tables created.");
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Error creating inbox/outbox database: " + exp.Message);
                this.Context.LogMessage("Error creating inbox/outbox database: " + exp.Message);

                throw new InstallException("Error creating inbox/outbox database: " + exp.Message);
            }
            finally
            {
                //close inbox/outbox connection
                if (oConn!=null)
                    oConn.Close();
            }

            #endregion

            #region Create Application Database

            try
            {
                //application connection
                oConn = new SqlConnection(string.Format(sConnString, sUserName, sPassword, sMasterDB, sServer));

                //open application connection
                oConn.Open();

                //create application database
                sSql = GetSqlScript("App_Database.sql");
                Debug.WriteLine("Creating application database: " + sSql);
                this.Context.LogMessage("Creating application database: " + sSql);

                oCmd = new SqlCommand(sSql, oConn);
                oCmd.ExecuteNonQuery();
                Debug.WriteLine("Application database created.");
                this.Context.LogMessage("Application database created.");

                //create inbox/outbox tables
                sSql = GetSqlScript("App_Tables.sql");
                Debug.WriteLine("Creating application tables: " + sSql);
                this.Context.LogMessage("Creating application tables: " + sSql);

                oCmd = new SqlCommand(sSql, oConn);
                oCmd.ExecuteNonQuery();
                Debug.WriteLine("Application tables created.");
                this.Context.LogMessage("Application tables created.");
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
                if (oConn!=null)
                    oConn.Close();
            }

            #endregion

            #region Cleanup Database Creation

            if (oCmd!=null)
                oCmd.Dispose();

            if (oConn!=null)
                oConn.Dispose();

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