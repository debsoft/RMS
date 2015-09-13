using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RMSUI.Interfaces;
using Managers.User;
using RMS.Common.ObjectModel;
using RMS.Common;
using Managers.TableInfo;
using System.Net;
using RmsRemote;

namespace RMS.Login
{
    class LoginAction :DialogueFormInterface     
    {
        private TextBox passwordFiled;
        private Label lblErrorMessage;

        #region DialogueFormInterface Members

        public LoginAction(TextBox passwordFiled, Label lblErrorMessage) 
        {
            this.passwordFiled = passwordFiled;
            this.lblErrorMessage = lblErrorMessage;
        }

        public DialogResult OnEnterPress()
        {
            string password = passwordFiled.Text;

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
                lblErrorMessage.Hide();
            }
            else
            {
                string tempStr = oResult.Message;
                if (!tempStr.Equals(String.Empty))
                {
                    lblErrorMessage.Text = tempStr;
                }

                lblErrorMessage.Show();
                return DialogResult.None;
            }

            CCurrentUser.User_id = tempUserInfo.UserID;
            CCurrentUser.Type = tempUserInfo.Type;
            passwordFiled.Clear();
            return  DialogResult.OK;
        }

        #endregion
    }
}
