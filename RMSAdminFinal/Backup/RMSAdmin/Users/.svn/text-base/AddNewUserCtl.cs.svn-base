using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.User;
using RMS.Common.ObjectModel;
using RMS;

namespace RMSAdmin
{
    public partial class AddNewUserCtl : UserControl
    {
        public AddNewUserCtl()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length < 1 && txtPassword.Text.Length < 1)
            {
                    return;
            }
            
            String sTempUser = txtUserName.Text.Trim();

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


            CUserManager oManager = new CUserManager();

            CResult oResult = oManager.AddUser(oUser);

            if (oResult.IsSuccess)
            {
                lblSaveStatus.Text = "User information has been saved successfully.";

                lblSaveStatus.Visible = true;
            }
            else
            {
                lblSaveStatus.Text = oResult.Message;
                lblSaveStatus.Visible = true;
            }
        }

        private void cmbUserType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbUserType.Items.Clear();
                cmbUserType.Items.Add(new CComboBoxItem(0, "Administrator"));
                cmbUserType.Items.Add(new CComboBoxItem(1, "Service"));
                cmbUserType.Items.Add(new CComboBoxItem(2, "Waiter"));
                cmbUserType.Items.Add(new CComboBoxItem(3, "Delivery Driver"));
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string controlType = String.Empty;

            foreach (Control ctl in this.Controls)
            {
                controlType = ctl.GetType().ToString().ToUpper();
                if (controlType == "System.Windows.Forms.CheckBox".ToUpper())
                {
                    CheckBox chkBox = (CheckBox)ctl;
                    chkBox.Checked = false;
                }
                else if (controlType == "System.Windows.Forms.ComboBox".ToUpper())
                {
                    ComboBox cmb = (ComboBox)ctl;
                    cmb.SelectedIndex = -1;
                }
                else if (controlType == "System.Windows.Forms.TextBox".ToUpper())
                {
                    TextBox txtBox = (TextBox)ctl;
                    txtBox.Clear();
                }
                else if (controlType == "System.Windows.Forms.RadioButton".ToUpper())
                {
                    RadioButton rdoBtn = (RadioButton)ctl;
                    rdoBtn.Checked = false;
                }
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
