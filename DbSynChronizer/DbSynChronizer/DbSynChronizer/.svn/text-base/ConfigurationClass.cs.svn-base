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
using System.Xml;
using System.Windows.Forms;


namespace DbSynChronizer
{
    [RunInstaller(true)]
  public  class ConfigurationClass:Installer
    {

       private XmlDocument xmlDoc = null;
       private string currentDirectory = String.Empty;

      public ConfigurationClass()
        {
            xmlDoc = new XmlDocument();
            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName ;
            xmlDoc.Load(currentDirectory + "\\CommonConstants.xml");
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);

            #region Get Parameters From Dialogs
           
            try
            {
                this.ModifyConfiguration();//For configuration
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Error creating application database: " + exp.Message);
                throw new InstallException(exp.Message+"Error creating application database: " + exp.Message);
            }
            #endregion
        }

        private void ModifyConfiguration()
        {
            string innerString = String.Empty;
            string timeInterval = this.Context.Parameters["timelength"];
            string websiteName = "http://"+this.Context.Parameters["website"];
            
            XmlNode appSettingsNode =
            xmlDoc.SelectSingleNode("configuration/timerinterval");
            appSettingsNode.InnerText = timeInterval;

            XmlNode appSettingsNodeUrl =
            xmlDoc.SelectSingleNode("configuration/url");
            appSettingsNodeUrl.InnerText = websiteName;

            xmlDoc.Save(currentDirectory + "\\CommonConstants.xml");
        }
    }
}
