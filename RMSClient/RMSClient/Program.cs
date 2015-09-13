using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PayRoll.Forms;
using RMS.Login;
using System.Data;
using RMS.Common;
using System.Data.SqlClient;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RmsRemote;
using RMS.Common.ObjectModel;
using RMS.Common.Config;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using RMSRegistry;
using System.Threading;
using System.Diagnostics;

namespace RMS
{
    static class Program
    {
        private static XmlDocument xmlDoc = null;
        private static string currentDirectory = String.Empty;
        public static DataSet initDataSet;

        public static string currency = "Tk";
        public static double vat = 0.00;
        public static bool isVatEnabled=true;
        public static string vatRegDes = "[vat reg no]";

        private static StartScreen startScreen;
       

       
        private static void Init()
        {
           
            //Starting sub version
            try
            {


                startScreen.loadingtext.Text = "Loading configuration...";
                ConfigurationClass obj = new ConfigurationClass();
                
                initDataSet = new DataSet();
                ConfigManager.Init();
                ConfigManager.ReloadConfig();
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                startScreen.loadingtext.Text = "Connecting remote objects...";
                
                CLogin oLogin = new CLogin();
                oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oTempConstant.RemoteURL);

                startScreen.loadingtext.Text = "Loading inistal dataset...";
                CResult oResult = oLogin.GetInitialDBStr();

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    String oTempStr = (String)oResult.Data;

                    oTempConstant.DBConnection = oTempStr;

                    oTempDal.ConnectionString = oTempStr;
                   

                    String ConnectionString = oTempConstant.DBConnection;

                    SqlDataAdapter tempSqlDataAdapter = new SqlDataAdapter(SqlQueries.GetQuery(Query.ButtonAccessGetAll), ConnectionString);
                    tempSqlDataAdapter.Fill(initDataSet, "ButtonAccess");
                    tempSqlDataAdapter.Dispose();

                    SqlDataAdapter tempSqlDataAdapter2 = new SqlDataAdapter(SqlQueries.GetQuery(Query.ButtonColorGetAll), ConnectionString);
                    tempSqlDataAdapter2.Fill(initDataSet, "ButtonColor");
                    tempSqlDataAdapter2.Dispose();

                    SqlDataAdapter tempSqlDataAdapter3 = new SqlDataAdapter(SqlQueries.GetQuery(Query.ParentCategoryGetAll), ConnectionString);
                    tempSqlDataAdapter3.Fill(initDataSet, "ParentCategory");
                    tempSqlDataAdapter3.Dispose();

                     SqlDataAdapter tempSqlDataAdapter4 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category1GetAll), ConnectionString);
                    tempSqlDataAdapter4.Fill(initDataSet, "Category1");
                    tempSqlDataAdapter4.Dispose();

                    SqlDataAdapter tempSqlDataAdapter5 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category2GetAll), ConnectionString);
                    tempSqlDataAdapter5.Fill(initDataSet, "Category2");
                    tempSqlDataAdapter5.Dispose();

                    SqlDataAdapter tempSqlDataAdapter6 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category3GetAll), ConnectionString);
                    tempSqlDataAdapter6.Fill(initDataSet, "Category3");
                    tempSqlDataAdapter6.Dispose();

                    SqlDataAdapter tempSqlDataAdapter7 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category4GetAll), ConnectionString);
                    tempSqlDataAdapter7.Fill(initDataSet, "Category4");
                    tempSqlDataAdapter7.Dispose();

                    SqlDataAdapter tempSqlDataAdapter8 = new SqlDataAdapter(SqlQueries.GetQuery(Query.GetGeneralSetting), ConnectionString);
                    tempSqlDataAdapter8.Fill(initDataSet, "GeneralSettings");
                    tempSqlDataAdapter8.Dispose();


                    vat = Convert.ToDouble(initDataSet.Tables["GeneralSettings"].Rows[0]["vat_amount"].ToString());
                    isVatEnabled = Convert.ToBoolean(Program.initDataSet.Tables["GeneralSettings"].Rows[0]["vat_enabled"].ToString());
                   currency =initDataSet.Tables["GeneralSettings"].Rows[0]["currency"].ToString();

                    
                    initDataSet.Relations.Add("parent_category_to_category1",
                        initDataSet.Tables["ParentCategory"].Columns["parent_cat_id"],
                        initDataSet.Tables["Category1"].Columns["parent_cat_id"], false);

                    initDataSet.Relations.Add("category1_to_category2",
                        initDataSet.Tables["Category1"].Columns["cat1_id"],
                        initDataSet.Tables["Category2"].Columns["cat1_id"], false);

                    initDataSet.Relations.Add("category2_to_category3",
                       initDataSet.Tables["Category2"].Columns["cat2_id"],
                       initDataSet.Tables["Category3"].Columns["cat2_id"], false);

                    initDataSet.Relations.Add("category3_to_category4",
                       initDataSet.Tables["Category3"].Columns["cat3_id"],
                       initDataSet.Tables["Category4"].Columns["cat3_id"], false);

                    initDataSet.Relations.Add("button_color_to_button_access",
                       initDataSet.Tables["ButtonColor"].Columns["button_id"],
                       initDataSet.Tables["ButtonAccess"].Columns["button_id"], false);

                   



                    GetPrinterCommands();
                }
                else
                {
                    MessageBox.Show("Could not login.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This function collects the printer commands when loading the application
        /// </summary>
        private static void GetPrinterCommands()
        {
            #region "Added by Baruri at 15.06.2009 for retrieving the print command"
            xmlDoc = new XmlDocument();
            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName + "\\config";
            xmlDoc.Load(currentDirectory + "\\paper_cartridge_command.xml");
            CPrinterConstants objPrinterConstants = new CPrinterConstants();
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("cartridge/CutPaperCode");

            RMSGlobal.m_printer_kitchen_cut_command = Convert.ToString(appSettingsNode.InnerText);
        }
          
            #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Mutex mutex = new Mutex(false, "RMSClient");
            if (!mutex.WaitOne(0, false))
            {
               // MessageBox.Show("Instance already running");
                return;
            }
          
            Cryptograph myCryptoGraph = new Cryptograph();

            string strExistingHDSN = myCryptoGraph.EncodeString(SystemInfo.getHardiskSerialNumber());
           
            string strHDSNOnAPPREG = AppRegistry.ReadRegistry(Registry.CurrentUser, "Software\\Ibacs", "regkey");
            if (strExistingHDSN == strHDSNOnAPPREG)
            {


                #region "For Registration added at 11/08/2008"

              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);

                //TrialMaker tm = new TrialMaker("RMSCustomer", Application.StartupPath + "\\RmsClientRegFile.reg",
                //    Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\RmsClient.dbf",
                //    "Tel:+44 (0) 08456522218\nMob:+44 (0) 7922911811\nFax  : +44 (0) 2920 920 260",
                //    5, 10, "843");

                //byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
                //4, 54, 87, 56, 123, 10, 3, 62,
                //7, 9, 20, 36, 37, 21, 101, 57};
                //tm.TripleDESKey = MyOwnKey;

                //TrialMaker.RunTypes RT = tm.ShowDialog();
                bool is_trial = false;
                //if (RT != TrialMaker.RunTypes.Expired)
                //{
                //    if (RT == TrialMaker.RunTypes.Full)
                //        is_trial = false;
                //    else
                //        is_trial = true;


               startScreen = new StartScreen();
              //startScreen.loadingtext.Text = "Loading...";
               startScreen.Show();
              startScreen.loadingtext.Text = "Loading...";
                Init();
                startScreen.loadingtext.Text = "Loading completed....";

                startScreen.Visible = false;
                startScreen.Dispose();
              //  Application.Run(new CLoginForm(is_trial));
               Application.Run(new WelcomeForm("",""));

                GC.KeepAlive(mutex);
                //}
                #endregion
            }
            else {
                MessageBox.Show("RMS Application is not registered for this computer.");
            }
        }
    }
}