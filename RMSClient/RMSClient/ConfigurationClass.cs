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

namespace RMS
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
            currentDirectory = executableFileInfo.DirectoryName + "\\Config";
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
            string remoteURL = String.Empty;
            string cityName = String.Empty;
            string comportName = String.Empty;
            string comportBaudRate = String.Empty;
            string callerIdCommand = String.Empty;
            string online_user_name = String.Empty;
            string online_password_name = String.Empty;
            string online_location = String.Empty;

            string serverIP = this.Context.Parameters["ipaddress"];
            XmlNode appSettingsNode =
            xmlDoc.SelectSingleNode("CCommonConstants/RemoteURL");
            remoteURL = "tcp://" + serverIP + ":8085/RMSSERVER";
            appSettingsNode.InnerText = remoteURL;

            cityName = this.Context.Parameters["cityname"];
            XmlNode citysettings = xmlDoc.SelectSingleNode("CCommonConstants/cityname");
            citysettings.InnerText = cityName;

            comportName = this.Context.Parameters["attachedportname"];
            XmlNode NameOfComPort = xmlDoc.SelectSingleNode("CCommonConstants/ComportName");
            NameOfComPort.InnerText = comportName;

            comportBaudRate = this.Context.Parameters["attachedbaudrate"];
            XmlNode rateOfBaud = xmlDoc.SelectSingleNode("CCommonConstants/ComportBaudRate");
            rateOfBaud.InnerText = comportBaudRate;

            callerIdCommand = this.Context.Parameters["calleridcommand"];
            XmlNode commandName = xmlDoc.SelectSingleNode("CCommonConstants/CallerIDCommand");
            commandName.InnerText = callerIdCommand;

            online_user_name = this.Context.Parameters["online_user_name"];
            XmlNode authenticatedUser = xmlDoc.SelectSingleNode("CCommonConstants/OnlineUser");
            authenticatedUser.InnerText = online_user_name;

            online_password_name = this.Context.Parameters["online_password_name"];
            XmlNode authenticatedPassword = xmlDoc.SelectSingleNode("CCommonConstants/OnlinePassword");
            authenticatedPassword.InnerText = online_password_name;

            online_location = this.Context.Parameters["website_name"];
            XmlNode location = xmlDoc.SelectSingleNode("CCommonConstants/online_location");
            location.InnerText = online_location; 

            xmlDoc.Save(currentDirectory + "\\CommonConstants.xml");
        }
    }
}
