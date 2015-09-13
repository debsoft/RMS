using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using RMS.Managers;
using RMS.Common;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using RMSSvc;
using System.Xml;
using System.IO;

namespace RMS
{
    public partial class RMSSERVER : ServiceBase
    {
        CPrinterConstants objPrinterConstants = null;
        Thread m_oPrintThread;
        private XmlDocument xmlDoc = null;
        private string currentDirectory = String.Empty;

        public RMSSERVER()
        {           
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            #region "Added by Baruri at 15.06.2009 for retrieving the print command"
            xmlDoc = new XmlDocument();
            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName + "\\Config";
            xmlDoc.Load(currentDirectory + "\\CommonConstants.xml");
            CPrinterConstants objPrinterConstants = new CPrinterConstants();
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("CCommonConstants/PaperCutCommand");

            RMSServiceGlobal.m_printer_kitchen_cut_command = Convert.ToString(appSettingsNode.InnerText);
            appSettingsNode = xmlDoc.SelectSingleNode("CCommonConstants/BeepCommand");

            RMSServiceGlobal.m_printer_beep_command = Convert.ToString(appSettingsNode.InnerText);


          
            #endregion


            try
            {
                ConfigManager.Init();

                ConfigManager.ReloadConfig();

                Logger.Write("Starting RMS SMS Service.", LogLevel.Information, LogSources.RmsServer);
                //throw new Exception("test exception");

                //preload config
               // ConfigManager.Init();

                Logger.Write("RMS SMS Service successfully started.", LogLevel.Information, LogSources.RmsServer);
                
                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
               
                CPrintThread myThread = new CPrintThread();               
                m_oPrintThread = new Thread(new ThreadStart(myThread.run));               
                m_oPrintThread.Start();

                String sTempChannel = oConstant.Channel.Trim().ToLower();

                int iTempPort = oConstant.Port;

                if (sTempChannel.Equals("tcp"))
                {                   
                    TcpChannel oChannel = new TcpChannel(iTempPort);                    
                    ChannelServices.RegisterChannel(oChannel);                   
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof

                                   (RmsRemote.CLogin), "RMSSERVER", WellKnownObjectMode.Singleton);
                    
                }
                else if(sTempChannel.Equals("http"))
                {

                    HttpChannel oChannel = new HttpChannel(iTempPort);

                    ChannelServices.RegisterChannel(oChannel);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof

                                   (RmsRemote.CLogin), "RMSSERVER", WellKnownObjectMode.Singleton);

                }
            }
            catch (Exception exp)
            {
                Logger.Write("A fatal error occured while trying to start the RMS SMS Service: " + exp.Message, LogLevel.Fatal, LogSources.RmsServer);
                throw exp;
            }
        }//OnStart

        protected override void OnStop()
        {
            Logger.Write("Stopping RMS SMS Service.", LogLevel.Information, LogSources.RmsServer);

            #region Printing Thread Stop( By Zahid)
           
            try
            {
                m_oPrintThread.Abort();
            }
            catch (Exception ex)
            {
            }

            #endregion


            //do clean up etc.

            Logger.Write("RMS SMS Service successfully stopped.", LogLevel.Information, LogSources.RmsServer);
        }//OnStop



    }//Rmsserver
}//ns
