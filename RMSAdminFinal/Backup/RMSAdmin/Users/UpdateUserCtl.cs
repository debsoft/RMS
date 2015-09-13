using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.User;
using RMS;

namespace RMSAdmin
{
    public partial class UpdateUserCtl : UserControl
    {
        private Int32 m_userID = 0;
        public UpdateUserCtl(Int32 userId)
        {
            InitializeComponent();
            m_userID = userId;
        }

        private void LoadExistingData()
        {

            CUserInfo oUserInfo = new CUserInfo();

            oUserInfo.UserID = m_userID;

            CUserAccess oUserAccess = new CUserAccess();

            CUserManager oManager = new CUserManager();

            CResult oResult = oManager.GetUser(oUserInfo);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                oUserInfo = (CUserInfo)oResult.Data;

                txtUserName.Text = oUserInfo.UserName;

                txtPassword.Text = oUserInfo.Password;

                if (oUserInfo.Gender.Trim().Equals("Male"))
                {
                    cmbSex.SelectedIndex = 0;
                }
                else if (oUserInfo.Gender.Trim().Equals("Female"))
                {
                    cmbSex.SelectedIndex = 1;
                }

                if (oUserInfo.Type == 0)
                {
                    cmbUserType.SelectedIndex = 0;
                }

                else if (oUserInfo.Type == 1)
                {
                    cmbUserType.SelectedIndex = 1;
                }

                if (oUserInfo.Status == 1)
                {
                    rdoActive.Checked = true;
                }
                else if (oUserInfo.Status == 0)
                {
                    rdoInActive.Checked = true;
                }

                CResult oResult2 = oManager.GetUserAccess(oUserInfo);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {
                    oUserAccess = (CUserAccess)oResult2.Data;

                    if (oUserAccess.OpenDrawer == 1)
                    {
                        chkOpenDrawer.Checked = true;
                    }

                    if (oUserAccess.VoidTable == 1)
                    {
                        chkVoidTable.Checked = true;
                    }

                    if (oUserAccess.TransferTable == 1)
                    {
                        chkTransferTable.Checked = true;
                    }

                    if (oUserAccess.MergeTable == 1)
                    {
                        chkMergeTable.Checked = true;
                    }

                    if (oUserAccess.ReviewTransaction == 1)
                    {
                        chkReviewTrans.Checked = true;
                    }

                    if (oUserAccess.ViewReport == 1)
                    {
                        chkViewReport.Checked = true;
                    }

                    if (oUserAccess.TillReporting == 1)
                    {
                        chkTillReport.Checked = true;
                    }

                    if (oUserAccess.ExitRms == 1)
                    {
                        chkExitRms.Checked = true;
                    }

                    if (oUserAccess.UnlockTable == 1)
                    {
                        chkUnlockTable.Checked = true;
                    }

                    if (oUserAccess.Booking == 1)
                    {
                        chkBooking.Checked = true;
                    }

                    if (oUserAccess.Users == 1)
                    {
                        chkUsers.Checked = true;
                    }

                    if (oUserAccess.Deposit == 1)
                    {
                        chkDeposit.Checked = true;
                    }

                    if (oUserAccess.Customers == 1)
                    {
                        chkCustomer.Checked = true;
                    }

                    if (oUserAccess.UpdateItems == 1)
                    {
                        chkUpdateItems.Checked = true;
                    }

                    if (oUserAccess.RemoveItems == 1)
                    {
                        chkRemoveItems.Checked = true;
                    }

                    if (oUserAccess.LogRegister == 1)
                    {
                        chkLogRegister.Checked = true;
                    }

                    if (oUserAccess.SystemSettings == 1)
                    {
                        chkSettings.Checked = true;
                    }
                    if (oUserAccess.RmsAdminAccess == 1)
                    {
                        chkRmsAdmin.Checked = true;
                    }
                }
            }
        }

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            if (txtUserName.Text.Equals(String.Empty))
            {
                oResult.Message = "Please enter user name.";

                return oResult;
            }

            if (txtPassword.Text.Equals(String.Empty))
            {
                oResult.Message = "Please enter password.";

                return oResult;
            }

            if (cmbUserType.SelectedIndex < 0)
            {
                oResult.Message = "Please select user type.";

                return oResult;
            }

            if (cmbSex.SelectedIndex < 0)
            {
                oResult.Message = "Please select user's sex.";

                return oResult;
            }

            oResult.IsSuccess = true;

            return oResult;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                String sTempUser = txtUserName.Text.Trim();

                //String sTempPass =RMSGlobal.Decrypt(txtPassword.Text.Trim(),true);

                String sTempPass = txtPassword.Text.Trim();

                int iTempType = ((CComboBoxItem)cmbUserType.SelectedItem).Value;

                String sTempGender = cmbSex.SelectedItem.ToString();

                CUserInfo oUser = new CUserInfo();

                oUser.UserName = sTempUser;

                oUser.Password =sTempPass;

                oUser.Type = iTempType;

                oUser.Gender = sTempGender;

                if (rdoActive.Checked)
                {
                    oUser.Status = 1;
                }
                else if (rdoInActive.Checked)
                {
                    oUser.Status = 0;
                }

                CUserAccess oUserAccess = new CUserAccess();

                if (chkOpenDrawer.Checked)
                {

                    oUserAccess.OpenDrawer = 1;
                }

                if (chkReviewTrans.Checked)
                {
                    oUserAccess.ReviewTransaction = 1;
                }

                if (chkVoidTable.Checked)
                {
                    oUserAccess.VoidTable = 1;
                }

                if (chkViewReport.Checked)
                {
                    oUserAccess.ViewReport = 1;
                }

                if (chkTransferTable.Checked)
                {
                    oUserAccess.TransferTable = 1;
                }

                if (chkTillReport.Checked)
                {
                    oUserAccess.TillReporting = 1;
                }

                if (chkMergeTable.Checked)
                {
                    oUserAccess.MergeTable = 1;
                }

                if (chkExitRms.Checked)
                {
                    oUserAccess.ExitRms = 1;
                }

                if (chkUnlockTable.Checked)
                {
                    oUserAccess.UnlockTable = 1;
                }

                if (chkBooking.Checked)
                {
                    oUserAccess.Booking = 1;
                }

                if (chkUsers.Checked)
                {
                    oUserAccess.Users = 1;
                }

                if (chkDeposit.Checked)
                {
                    oUserAccess.Deposit = 1;
                }

                if (chkCustomer.Checked)
                {
                    oUserAccess.Customers = 1;
                }

                if (chkUpdateItems.Checked)
                {
                    oUserAccess.UpdateItems = 1;
                }
               
                if (chkRemoveItems.Checked)
                {
                    oUserAccess.RemoveItems = 1;
                }

                if (chkLogRegister.Checked)
                {
                    oUserAccess.LogRegister = 1;
                }

                if (chkSettings.Checked)
                {
                    oUserAccess.SystemSettings = 1;
                }

                if (chkRmsAdmin.Checked)
                {
                    oUserAccess.RmsAdminAccess = 1;
                }


                oUser.UserAccess = oUserAccess;

                oUser.UserID = m_userID;

                CUserManager oManager = new CUserManager();

                CResult oResult2 = oManager.UpdateUser(oUser);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = "User information has been modified successfully.";

                    lblSaveStatus.Visible = true;
                }
                else
                {
                    lblSaveStatus.Text = oResult2.Message;

                    lblSaveStatus.Visible = true;
                }
            }
            else
            {
                lblSaveStatus.Text = oResult.Message;
                lblSaveStatus.Visible = true;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

       

        private void UpdateUserCtl_Load(object sender, EventArgs e)
        {
            cmbUserType.Items.Clear();
            cmbUserType.Items.Add(new CComboBoxItem(0, "Admin"));
            cmbUserType.Items.Add(new CComboBoxItem(1, "User"));

            cmbUserType.DisplayMember = "Display";

            cmbUserType.ValueMember = "Value";
            
            this.LoadExistingData();//Loading the selected user information
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
