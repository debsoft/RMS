using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMS.Common;
using Managers.User;
using RmsRemote;
using Managers.TableInfo;
using System.Net;
using RMSUI;

namespace RMS
{
    public partial class AuthenticationForm : IRDialogForm
    {
        private static AuthenticationForm m_authenticationForm = null;
        private static string m_userName = String.Empty;
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        public static AuthenticationForm CreateInstance(string userName)
        {
            if (m_authenticationForm == null)
            {
                m_authenticationForm = new AuthenticationForm();
            }
            m_userName = userName;
            return m_authenticationForm;
        }

        #region "Manipulation Area"

        private bool CheckPasswordLength()
        {
            if (LoginTextBox.Text.Length >= LoginTextBox.MaxLength)                 //no more characters allowed
                return false;
            else
                return true;
        }
        #endregion


        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            //CCurrentUser.User_name = m_userName;
           // UserLabel.Text = m_userName;

            this.SetTitle = "Login as "+m_userName;
           // UserLabel.Show();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            /*string password = LoginTextBox.Text;

            CUserManager tempUserManager = new CUserManager();
            CUserInfo tempUserInfo = new CUserInfo();

            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            tempUserInfo = (CUserInfo)tempUserManager.GetUserInfoByUsername(CCurrentUser.User_name).Data;

            CLogin oLogin = new CLogin();
            CUserInfo oUserInfo = new CUserInfo();

            CPcInfoManager tempPcInfoManager = new CPcInfoManager();
            IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());

            CPcInfo tempPcInfo = (CPcInfo)tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString()).Data;

            oUserInfo.UserName = CCurrentUser.User_name;
            RMSGlobal.LoginUserName = CCurrentUser.User_name;
            RMSGlobal.m_iLoginUserID = tempUserInfo.UserID;
            oUserInfo.Password = password;

            oUserInfo.PCID = tempPcInfo.PcID;
            RMSGlobal.m_connectionString = oConstant.DBConnection;
            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);

            CResult oResult = oLogin.ProcessLogin(oUserInfo);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                CUserLogin oUserLogin = (CUserLogin)oResult.Data;

                oConstant.UserInfo = oUserLogin.UserInfo;
                g_ErrorLabel.Hide();
            }
            else
            {
                string tempStr = oResult.Message;
                if (!tempStr.Equals(String.Empty))
                {
                    g_ErrorLabel.Text = tempStr;
                }

                g_ErrorLabel.Show();
                return;
            }

            CCurrentUser.User_id = tempUserInfo.UserID;
            CCurrentUser.Type = tempUserInfo.Type;
            LoginTextBox.Clear();
            this.DialogResult = DialogResult.OK;*/
        }
       
      
        private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_authenticationForm = null;
        }
        public TextBox PasswordFiled 
        {
            get { return this.LoginTextBox; }
        }
        public Label LabelErrorMessage 
        {
            get { return g_ErrorLabel; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
