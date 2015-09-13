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
using System.Net;
using RMSAdmin;
using RMS.Common.Config;

namespace RMS
{
    public partial class AuthenticationForm : Form
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

        private void ProcessLogin()
        {
            try
            {
                CCommonConstants objCommonConstant = ConfigManager.GetConfig<CCommonConstants>();

                CDalConfig objDalConstant = ConfigManager.GetConfig<CDalConfig>();

                CUserManager tempUserManager = new CUserManager();
                CLogin objLogin = new CLogin();
                CUserInfo objUserInfo = new CUserInfo();

                objUserInfo.UserName = UserLabel.Text.Trim();

                objUserInfo.Password = LoginTextBox.Text.Trim();


                objLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), objCommonConstant.RemoteURL);

                CResult objResult = objLogin.ProcessAdminLogin(objUserInfo);

                if (objResult.IsSuccess && objResult.Data != null)
                {
                    CUserLogin objUserLogin = (CUserLogin)objResult.Data;

                    objCommonConstant.UserInfo = objUserLogin.UserInfo;

                    objDalConstant.ConnectionString = objUserLogin.ConnectionStr;
                    RMSGlobal.LogInUserName = objCommonConstant.UserInfo.UserName;

                    objCommonConstant.DBConnection = objUserLogin.ConnectionStr;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    g_ErrorLabel.Show();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        #endregion

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            //CCurrentUser.User_name = m_userName;
            UserLabel.Text = m_userName;
            UserLabel.Show();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("1");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("2");
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("3");
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("4");
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("5");
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("6");
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("7");
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("8");
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("9");
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (!CheckPasswordLength())
                return;

            LoginTextBox.AppendText("0");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Equals(""))
                return;
            else
                LoginTextBox.Clear();
        }

        private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_authenticationForm = null;
        }
    }
}
