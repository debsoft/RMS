using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using RMS.Common;
using RMS;
using RMS.Common.Config;
using RmsRemote;
using RMS.Common.ObjectModel;
using Managers.Payment;
using System.Data;

namespace RMSAdmin
{
    static class Program
    {
        public static DataTable m_foodTypeRecords=new DataTable();
        public static DataTable m_categoryRecords = new DataTable();
        public static DataTable m_foodItemRecords = new DataTable();
        public static DataTable m_selectionItemRecords = new DataTable();
        public static DataSet m_initDataSet=new DataSet();
        private static void Init()
        {
            ConfigManager.Init();
            ConfigManager.ReloadConfig();
            CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            CLogin oLogin = new CLogin();
            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oTempConstant.RemoteURL);

            CResult oResult = oLogin.GetInitialDBStr();

            if (oResult.IsSuccess && oResult.Data != null)
            {
                DataSet dsRecords = new DataSet();
                String oTempStr = (String)oResult.Data;
                oTempConstant.DBConnection = oTempStr;
                RMSGlobal.m_serverConnectionString = oTempConstant.DBConnection;

                CReportManager objReportMgnr = new CReportManager();
                CResult objFoodType = objReportMgnr.GetFoodTypesRecords();
                dsRecords = (DataSet)objFoodType.Data;
                m_foodTypeRecords=dsRecords.Tables[0];

                objFoodType = objReportMgnr.GetFoodCategoryRecords();
                dsRecords = (DataSet)objFoodType.Data;
                m_categoryRecords= dsRecords.Tables[0];

                objFoodType = objReportMgnr.GetFoodItemRecords();
                dsRecords = (DataSet)objFoodType.Data;
                 m_foodItemRecords= dsRecords.Tables[0];

                objFoodType = objReportMgnr.GetSelectionofItemsRecords();
                dsRecords = (DataSet)objFoodType.Data;
                m_selectionItemRecords=dsRecords.Tables[0];
                
                //m_initDataSet.Relations.Add("category1_to_category2",
                //      m_foodTypeRecords.Columns["cat1_id"],
                //      m_categoryRecords.Columns["cat1_id"], false);
            }
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Init();
            RegistryKey regKey;

            regKey = Registry.LocalMachine;

            regKey = regKey.OpenSubKey("SOFTWARE").OpenSubKey("Ibacs Ltd"); //First try to find if ibacs product is installed or not.

           // if (regKey != null) //If not installed then.......
           // {

              //  if (regKey.GetValue("rmsadmin") != null)//If admin is installed
               // {
                    //bool firstInstance = false;
                    //string mutexName = "Local\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

                    //Mutex mutex = null;
                    //try
                    //{
                    //    // Create a new mutex object with a unique name
                    //    mutex = new Mutex(false, mutexName, out firstInstance);
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace +
                    //         "\n\n" + "Application Exiting...", "Exception thrown");
                    //    Application.Exit();
                    //}

                    //if (firstInstance)
                    //{
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new LoginForm());
                    //}

                    //else
                    //{
                    //    MessageBox.Show("An instance has already been run!", RMS.RMSGlobal.MessageBoxTitle,
                    //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
               // else
               // {
                 //   MessageBox.Show("Invalid applications!", RMS.RMSGlobal.MessageBoxTitle,
            //                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Invalid applications!", RMS.RMSGlobal.MessageBoxTitle,
            //                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        //}
    }
}
