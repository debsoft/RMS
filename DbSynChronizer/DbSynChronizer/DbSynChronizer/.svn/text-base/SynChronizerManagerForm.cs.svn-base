using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using System.Net;


namespace DbSynChronizer
{
    public partial class SynChronizerManagerForm : Form
    {
        #region "Declaration "
        //private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private XmlDocument xmlDoc = null;
        private XmlDocument xmlConstants = null;
        private string currentDirectory = String.Empty;
        private string StartStatusValue = "2";
        private Int32 m_timerInterval = 0;
        private string m_websiteName = string.Empty;
        private Hashtable m_onlineOrdersList = null;
        private string m_accessCode = String.Empty;
     

        #endregion

        #region "Initialization Area"

        public SynChronizerManagerForm()
        {
            InitializeComponent();

            xmlDoc = new XmlDocument();
            xmlConstants = new XmlDocument();

            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName;
            xmlDoc.Load(currentDirectory + "\\DbSynChronizer.exe.config");

            xmlConstants.Load(currentDirectory + "\\CommonConstants.xml");

            XmlNode appSettingsNode =
               xmlConstants.SelectSingleNode("configuration/startstatus");
            StartStatusValue = appSettingsNode.InnerXml;

            XmlNode appSettingsNodeInterval =
               xmlConstants.SelectSingleNode("configuration/timerinterval");
            m_timerInterval = Convert.ToInt32("0" + appSettingsNodeInterval.InnerText);

            XmlNode appSettingsNodeUrl =
            xmlConstants.SelectSingleNode("configuration/url");
            m_websiteName = Convert.ToString(appSettingsNodeUrl.InnerText);


            XmlNode appSettingsNodeAccessCode =
            xmlConstants.SelectSingleNode("configuration/accesscode");
            m_accessCode = Convert.ToString(appSettingsNodeAccessCode.InnerText);
            

            tmrDbSynchronizer.Interval = m_timerInterval*60*1000;

           
            //if (StartStatusValue == "1")
            //{
                tmrDbSynchronizer.Start();
                //picBoxActiveStatus.Image = DbSynChronizer.Properties.Resources.DB;

                //if (rkApp.GetValue("dbSynChronizer") == null)
                //{
                //    //The value doesn't exist, the application is not set to run at startup
                //    rkApp.SetValue("dbSynChronizer", Application.ExecutablePath.ToString());
                //}
            //}
            //else
            //{
            //    picBoxActiveStatus.Image = DbSynChronizer.Properties.Resources.DBstop;
            //}
        }

        #endregion

        #region "Manupulation Area"

        private string GenerateCustomerInformation(string strURL,string removeStatus)
        {
            string retVal = "";
            strURL = strURL + "?accesscode=" + m_accessCode + "&removedata=" + removeStatus;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                //call the GetResponse() metphod to obtain a connection to the remote site:

                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                //Accumulate the data from the response stream:

                response.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return retVal;
        }

        private string GetHTMLFromURL(string strURL)
        {
            string retVal = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                //call the GetResponse() method to obtain a connection to the remote site:

                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                //Accumulate the data from the response stream:

                response.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return retVal;
        }

        /// <summary>
        /// Collects customer information from online
        /// </summary>
        private void ExtractCustomerInformation()
        {
            DataSet dsCustomerInfo = new DataSet();
            m_onlineOrdersList = new Hashtable();
            String strURL = m_websiteName + "/XML/Online_Customer_info.xml";
            XmlDocument doc = new XmlDocument();
            dsCustomerInfo.ReadXml(strURL);

            IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
            string ipAddress = (ipEntry.AddressList[0].ToString());

            Database db = DatabaseFactory.CreateDatabase("LocalHostDatabase");
            string procedureName = "sp_SaveOnlineCustomerInfo";
            DbCommand dbCommand = null;

            if (dsCustomerInfo.Tables.Count > 0)
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        foreach (DataRow dtRow in dsCustomerInfo.Tables[0].Rows)
                        {
                            dbCommand = db.GetStoredProcCommand(procedureName);

                            db.AddInParameter(dbCommand, "@customer_id", DbType.Int64, Convert.ToInt64("0" + dtRow["customer_id"].ToString()));
                            db.AddInParameter(dbCommand, "@name", DbType.String, dtRow["name"].ToString());
                            db.AddInParameter(dbCommand, "@floororapt_number", DbType.String, dtRow["floororapt_number"].ToString());
                            db.AddInParameter(dbCommand, "@building_name", DbType.String, dtRow["building_name"].ToString());
                            db.AddInParameter(dbCommand, "house_number", DbType.String, dtRow["house_number"].ToString());
                            db.AddInParameter(dbCommand, "@phone", DbType.String, dtRow["phone"].ToString());
                            db.AddInParameter(dbCommand, "@postal_code", DbType.String, dtRow["postal_code"].ToString());
                            db.AddInParameter(dbCommand, "@town", DbType.String, dtRow["town"].ToString());
                            db.AddInParameter(dbCommand, "@country", DbType.String, dtRow["country"].ToString());
                            db.AddInParameter(dbCommand, "@userid", DbType.String, "Web User");
                            db.AddInParameter(dbCommand, "@insertdate", DbType.Int64, DateTime.Now.Ticks);

                            db.AddInParameter(dbCommand, "@terminal_id", DbType.String, ipAddress);
                            db.AddInParameter(dbCommand, "@onlinestatus", DbType.Int32, dtRow["onlinestatus"].ToString());
                            db.AddInParameter(dbCommand, "@street_name", DbType.String, dtRow["street_name"].ToString());

                            db.ExecuteNonQuery(dbCommand);
                        }
                    }

                    catch (Exception exp)
                    {
                        Console.Write(exp.Message, "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc = null;
                        strURL = null;
                    }
                }
            }
        }

        private void ExtractOnlineOrders()
        {
            DataSet dsOnlineOrders = new DataSet();
            
            String strURL = m_websiteName+"/XML/Online_Orders.xml";
            XmlDocument doc = new XmlDocument();
            IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
            string ipAddress = (ipEntry.AddressList[0].ToString());
            dsOnlineOrders.ReadXml(strURL);

            if (dsOnlineOrders.Tables.Count > 0)
            {
                try
                {
                    Database db = DatabaseFactory.CreateDatabase("LocalHostDatabase");
                    string procedureName = "sp_saveonlineorders";
                    DbCommand dbCommand = null;

                    using (DbConnection connection = db.CreateConnection())
                    {
                        connection.Open();
                        DbTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            foreach (DataRow dtRow in dsOnlineOrders.Tables[0].Rows)
                            {
                                dbCommand = db.GetStoredProcCommand(procedureName);

                                db.AddInParameter(dbCommand, "@order_id", DbType.Int64, Convert.ToInt64("0" + dtRow["order_id"].ToString()));
                                db.AddInParameter(dbCommand, "@customer_id", DbType.Int64, Convert.ToInt64("0" + dtRow["customer_id"].ToString()));
                                db.AddInParameter(dbCommand, "@user_id", DbType.String, "Web User");
                                db.AddInParameter(dbCommand, "@order_type", DbType.String, dtRow["order_type"].ToString());
                                db.AddInParameter(dbCommand, "@order_time", DbType.Int64, Convert.ToInt64("0" + dtRow["order_time"].ToString()));
                                db.AddInParameter(dbCommand, "@status", DbType.String, dtRow["status"].ToString());
                                db.AddInParameter(dbCommand, "@guest_count", DbType.Int32, Convert.ToInt32("0" + dtRow["guest_count"].ToString()));
                                db.AddInParameter(dbCommand, "@table_number", DbType.Int64, Convert.ToInt64("0" + dtRow["table_number"].ToString()));
                                db.AddInParameter(dbCommand, "@table_name", DbType.String, dtRow["table_name"].ToString());
                                db.AddInParameter(dbCommand, "@ipaddress", DbType.String, ipAddress);
                                db.AddInParameter(dbCommand, "@online_orderid", DbType.Int64, 0);

                                db.AddInParameter(dbCommand, "@webstatus", DbType.String, "");
                                db.AddInParameter(dbCommand, "@webstatusnote", DbType.String, "");
                                db.AddInParameter(dbCommand, "@OnlineStatus", DbType.Int32, Convert.ToInt32("0" + dtRow["OnlineStatus"].ToString()));
                                db.AddInParameter(dbCommand, "@quantity", DbType.Int32, Convert.ToInt32("0" + dtRow["quantity"].ToString()));
                                db.AddInParameter(dbCommand, "@amount", DbType.Double, Convert.ToDouble("0" + dtRow["amount"].ToString()) * Convert.ToInt32("0" + dtRow["quantity"].ToString()));
                                db.AddInParameter(dbCommand, "@remarks", DbType.String,Convert.ToString(dtRow["remarks"]));
                                db.AddInParameter(dbCommand, "@food_type", DbType.String, Convert.ToString(dtRow["food_type"]));
                                db.AddInParameter(dbCommand, "@pcat_name", DbType.String, Convert.ToString(dtRow["pcat_name"]));
                                db.AddInParameter(dbCommand, "@cat1_name", DbType.String, Convert.ToString(dtRow["cat1_name"]));
                                db.AddInParameter(dbCommand, "@cat2_name", DbType.String, Convert.ToString(dtRow["cat2_name"]));
                                db.AddInParameter(dbCommand, "@item_name", DbType.String, Convert.ToString(dtRow["item_name"]));
                                if (dtRow.ItemArray.Length>18)
                                {
                                    db.AddInParameter(dbCommand, "@del_time", DbType.String, Convert.ToString(dtRow["delivery_time"]));
                                }
                                else
                                {
                                    db.AddInParameter(dbCommand, "@del_time", DbType.String, "NA");
                                }

                                db.AddInParameter(dbCommand, "@item_add_time", DbType.Int64, Convert.ToInt64("0" + dtRow["item_add_time"]));

                                db.ExecuteNonQuery(dbCommand);
                            }
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message,
                                 "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                catch (WebException exp)
                {
                    MessageBox.Show(exp.Message + "Online orders can not be retrieved from the specified location",
                        "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message,
                         "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    doc = null;
                    strURL = null;
                }
            }
        }

        /// <summary>
        /// This function is used to check whether network connection is exists or not. 
        /// </summary>
        /// <returns></returns>
        public  bool ConnectionExists()
        {
            bool isExists = false;
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                clnt.Close();
                isExists = true;
            }
            catch (System.Exception ex)
            {
                isExists = false;
                throw ex;
            }
            return isExists;
        }

        #endregion

        #region "UI Events"

        private void tmrDbSynchronizer_Tick(object sender, EventArgs e)
        {
            if (this.ConnectionExists() == true) //Execute ping command 
            {
                this.GenerateCustomerInformation(m_websiteName + "/XML/RMSNewOrder.aspx","3");

                this.ExtractCustomerInformation();

                this.ExtractOnlineOrders();

                this.GenerateCustomerInformation(m_websiteName + "/XML/RMSNewOrder.aspx", "1");
            }
        }

        private void SynChronizerManagerForm_Load(object sender, EventArgs e)
        {
            try
            {
                tmrDbSynchronizer.Interval = m_timerInterval;
                tmrDbSynchronizer.Start();
                string str1 = currentDirectory + "/favicon_start.ico";
                synchronizerNotification.Icon = System.Drawing.Icon.ExtractAssociatedIcon(str1);
                this.synchronizerNotification.ContextMenuStrip = this.conMnuItem;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message, "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SynChronizerManagerForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Hide();
                this.synchronizerNotification.Visible = true;
                this.synchronizerNotification.ShowBalloonTip(5000);
            }
        }

        private void SynChronizerManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void tsMnuItemOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void tsMnuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void synchronizerNotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                tmrDbSynchronizer.Start();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                picBoxActiveStatus.Image = DbSynChronizer.Properties.Resources.DB;
                tsRunStatus.Text = "The service is running..";

                string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                FileInfo executableFileInfo = new FileInfo(executableName);
                currentDirectory = executableFileInfo.DirectoryName;

                string str1 = currentDirectory+"/favicon_start.ico";
                synchronizerNotification.Icon = System.Drawing.Icon.ExtractAssociatedIcon(str1);
                synchronizerNotification.Text = "Online Orders Synchronizing...";
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message, "Database Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrDbSynchronizer.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName ;


            picBoxActiveStatus.Image = DbSynChronizer.Properties.Resources.DBstop;
            tsRunStatus.Text = "The service stopped";

            //string str1 = @"favicon_stop.ico"; Previously
            string str1 = currentDirectory+"/favicon_stop.ico";
            synchronizerNotification.Icon = System.Drawing.Icon.ExtractAssociatedIcon(str1);
            synchronizerNotification.Text = "Online Orders Synchronizer stopped";
        }

        private void SynChronizerManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
