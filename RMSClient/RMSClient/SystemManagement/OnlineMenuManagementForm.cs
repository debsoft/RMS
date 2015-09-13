using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace RMS.SystemManagement
{
    public partial class OnlineMenuManagementForm : Form
    {
        public OnlineMenuManagementForm()
        {
            InitializeComponent();
        }

        private void OnlineMenuManagementForm_Activated(object sender, EventArgs e)
        {
            string onlineUser = String.Empty;
            string onlinePassword = String.Empty;
            string onlineLocation = String.Empty;

            XmlDocument xmlDoc = new XmlDocument();

            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            string currentDirectory = executableFileInfo.DirectoryName + "\\Config";
            xmlDoc.Load(currentDirectory + "\\CommonConstants.xml");

            XmlNode appSettingsNode =
            xmlDoc.SelectSingleNode("CCommonConstants/OnlineUser");
            onlineUser = appSettingsNode.InnerText;

            appSettingsNode =
            xmlDoc.SelectSingleNode("CCommonConstants/OnlinePassword");
            onlinePassword = appSettingsNode.InnerText;

            appSettingsNode =
            xmlDoc.SelectSingleNode("CCommonConstants/online_location");
            onlineLocation = appSettingsNode.InnerText;
            string url = onlineLocation + "/Category/OnlineMenuManagement.aspx?RMSAdmin=" + onlineUser + "$" + onlinePassword;
            url = "http://www.ibacs.co.uk/";
            menumanagementBrowser.Navigate(url);
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (menumanagementBrowser.CanGoForward)
            {
                menumanagementBrowser.GoForward();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (menumanagementBrowser.CanGoBack)
            {
                menumanagementBrowser.GoBack();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
