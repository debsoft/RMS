using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using Managers.User;
using RMS.Common.ObjectModel;
using RmsRemote;
using RMS;
using RMS.Common.Config;

namespace RMSAdmin
{
    public partial class LoginForm : Form
    {
        private const int MAX_USER_BUTTON = 24;
        private UserButton[] buttons;
        private int m_iStartingPoint = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        #region "Manupulation Area"
        private void ProcessLogin()
        {
            try
            {
                CCommonConstants objCommonConstant = ConfigManager.GetConfig<CCommonConstants>();

                CDalConfig objDalConstant = ConfigManager.GetConfig<CDalConfig>();

                CUserManager tempUserManager = new CUserManager();
                CLogin objLogin = new CLogin();
                CUserInfo objUserInfo = new CUserInfo();

                //objUserInfo.UserName = UserLabel.Text.Trim();

                //objUserInfo.Password = LoginTextBox.Text.Trim();
               

                objLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), objCommonConstant.RemoteURL);

                CResult objResult = objLogin.ProcessAdminLogin(objUserInfo);

                if (objResult.IsSuccess && objResult.Data != null)
                {
                    CUserLogin objUserLogin = (CUserLogin)objResult.Data;

                    objCommonConstant.UserInfo = objUserLogin.UserInfo;

                    objDalConstant.ConnectionString = objUserLogin.ConnectionStr;
                    RMSGlobal.LogInUserName = objCommonConstant.UserInfo.UserName;

                    objCommonConstant.DBConnection = objUserLogin.ConnectionStr;

                    RMSAdminMdiForm objParent = new RMSAdminMdiForm();  //Previous
                    objParent.Show();
                    this.Hide();
                }
                else
                {
                    //g_ErrorLabel.Show();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void LoginForm_Activated(object sender, EventArgs e)
        {
            try
            {
                LoadUserButtons();
                DateLabel.Text = System.DateTime.Today.Date.ToString("MMM dd");       //shows current date
                DayLabel.Text = System.DateTime.Today.Date.DayOfWeek.ToString();      //shows current day of the week
                TimeLabel.Text = System.DateTime.Now.ToLongTimeString();              //shows current time  
                lblRMSVersion.Text = RMSGlobal.m_rmsVersionNumber;

                tmrLoginScreen.Start();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void LoadUserButtons()
        {
            try
            {
                CUserManager tempUserManager = new CUserManager();
                List<CUserInfo> tempUserList = new List<CUserInfo>();
                tempUserList = (List<CUserInfo>)tempUserManager.GetAllUser().Data;

                int buttonCount = tempUserList.Count;
                buttons = new UserButton[buttonCount];

                for (int counter = 0; counter < buttonCount; counter++)
                {
                    if (tempUserList[counter].Status == 1)
                        {
                        // NAIN.K modified 06/01/2009                       

                        string webuser = "Web User";

                        if (tempUserList[counter].UserName.Replace(" ", " ").ToUpper() != webuser.Replace(" ", " ").ToUpper())
                        {
                            buttons[counter] = new UserButton();
                            buttons[counter].Gender = tempUserList[counter].Gender;
                           // buttons[counter].TouchButton.Text = tempUserList[counter].UserName;
                            buttons[counter].rmsUserName.Text = tempUserList[counter].UserName;
                            buttons[counter].Click += new System.EventHandler(this.UserButton_Click);

                            buttons[counter].Show();
                        }
                    }
                }

                LoadUserPanel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void LoadUserPanel()
        {
            userButtonPanel.Controls.Clear();
            for (int btnCounter = m_iStartingPoint; btnCounter < m_iStartingPoint + MAX_USER_BUTTON && btnCounter < buttons.Length; btnCounter++)
            {
                userButtonPanel.Controls.Add(buttons[btnCounter]);
            }
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            CCurrentUser.User_name = ((UserButton)sender).TouchButton.Text;
            AuthenticationForm objAuthentication = AuthenticationForm.CreateInstance(((UserButton)sender).rmsUserName.Text);
            DialogResult drResult = objAuthentication.ShowDialog();
            if (drResult == DialogResult.OK)
            {
                RMSAdminMdiForm objParent = new RMSAdminMdiForm();  //Previous
                objParent.Show();

                this.Visible = false;
            }
        }

        private void tmrLoginScreen_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            this.ProcessLogin();
        }

       
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
