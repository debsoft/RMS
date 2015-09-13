using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.User;
using RMSUI;
using RMS.Common.Constants;

namespace RMS.Common
{
    public partial class CUserInfoForm : BaseForm
    {
        public CUserInfo m_oUserInfo;        
        public string m_sOpType;
        
        private bool UpperCase = false;
        private bool m_bInPassBox = false;
        private TextBox m_cCurrentControl;
        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;

        public CUserInfoForm()
        {
            InitializeComponent();            
        }

        public CUserInfoForm(String inOpType, CUserInfo inUserInfo)
        {
            InitializeComponent();
            m_oUserInfo = inUserInfo;
            m_sOpType = inOpType;
        }

        private void ClearTextBoxes()
        {            
            NameTextBox.Clear();
            PasswordTextBox.Clear();
            ConfirmPassTextBox.Clear();
        }

        private bool CheckEmpty()
        {
            bool temp = true;
            if (NameTextBox.Text.Equals("")) temp = true;
            
            return temp;
        }

        private void SetText(string input)
        {
            try
            {
                if (UpperCase)
                    input = input.ToUpper();

                if (m_cCurrentControl.SelectionLength == 0)
                    m_cCurrentControl.SelectionLength = 1;
                m_cCurrentControl.Text = m_cCurrentControl.Text.Insert(m_iSelectionIndex, input);
                m_iSelectionIndex++;
            }
            catch (Exception eee)
            {
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Form tempMainForm = CFormManager.Forms.Pop();
            tempMainForm.Show();
            this.Close();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            m_cCurrentControl = (TextBox)sender;

            if (m_cCurrentControl.Equals(PasswordTextBox) || m_cCurrentControl.Equals(ConfirmPassTextBox)) m_bInPassBox = true;
            else m_bInPassBox = false;

            m_pCursorPosition = Cursor.Current.HotSpot;
            m_iSelectionIndex = m_cCurrentControl.SelectionStart;
        }

       

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cCurrentControl.SelectionLength == 0)
                    m_cCurrentControl.SelectionLength = 1;
                m_cCurrentControl.Text = m_cCurrentControl.Text.Remove(m_iSelectionIndex, m_cCurrentControl.SelectionLength);
            }
            catch (Exception eee)
            {
            }
        }


        private void KeyButton_Click(object sender, EventArgs e)
        {
            if (!m_bInPassBox)
            {
                String letter = ((Button)sender).Text;
                String input = (UpperCase) ? (letter.ToUpper()) : (letter);
                SetText(input);
            }
        }

        private void KeyCommaButton_Click(object sender, EventArgs e)
        {
            if (m_cCurrentControl != null && (m_cCurrentControl.Equals(PasswordTextBox) || m_cCurrentControl.Equals(ConfirmPassTextBox))) return;
            String input = ",";
            SetText(input);
        }

        private void KeyFullStopButton_Click(object sender, EventArgs e)
        {
            if (m_cCurrentControl != null && (m_cCurrentControl.Equals(PasswordTextBox) || m_cCurrentControl.Equals(ConfirmPassTextBox))) return;
            String input = ".";
            SetText(input);
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cCurrentControl.Text.Length == 1)
                    m_cCurrentControl.Clear();
                int tempLength;
                if (m_cCurrentControl.SelectionLength == 0)
                    tempLength = 1;
                else
                    tempLength = m_cCurrentControl.SelectionLength;


                m_cCurrentControl.Text = m_cCurrentControl.Text.Remove(m_iSelectionIndex - 1, tempLength);
                m_iSelectionIndex--;
            }
            catch (Exception eee)
            {
            }
        }

        private void SpaceButton_Click(object sender, EventArgs e)
        {
            if (m_cCurrentControl != null && (m_cCurrentControl.Equals(PasswordTextBox) || m_cCurrentControl.Equals(ConfirmPassTextBox))) return;
            SetText(" ");
        }

        private void CUserInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_sOpType.Equals("Update"))
                {
                    NameTextBox.Text = m_oUserInfo.UserName;
                    PasswordTextBox.Text = m_oUserInfo.Password;
                    ConfirmPassTextBox.Text = m_oUserInfo.Password;
                    UserTypeComboBox.SelectedItem = CUserConstant.GetUSerConstant(m_oUserInfo.Type);

                    if (m_oUserInfo.Gender.ToLower().Equals("male")) GenderComboBox.SelectedIndex = 0;
                    else if (m_oUserInfo.Gender.ToLower().Equals("female")) GenderComboBox.SelectedIndex = 1;
                   

                    if (m_oUserInfo.Status == 1) ActiveRadioButton.Checked = true;
                    else if (m_oUserInfo.Status == 0) InActiveRadioButton.Checked = true;
                   
                    
                    CUserManager tempUserManager = new CUserManager();
                    CUserAccess tempUserAccess = (CUserAccess)tempUserManager.GetUserAccess(m_oUserInfo).Data;
                                        
                    if (tempUserAccess.MergeTable == 1) MergeCheckBox.Checked = true;
                    if (tempUserAccess.OpenDrawer == 1) OpenDrawerCheckBox.Checked = true;
                    if (tempUserAccess.ReviewTransaction == 1) ReviewCheckBox.Checked = true;
                    if (tempUserAccess.TillReporting == 1) TillCheckBox.Checked = true;
                    if (tempUserAccess.TransferTable == 1) TransferCheckBox.Checked = true;
                    if (tempUserAccess.UnlockTable == 1) UnlockCheckBox.Checked = true;
                    if (tempUserAccess.ViewReport == 1) ViewCheckBox.Checked = true;
                    if (tempUserAccess.VoidTable == 1) VoidCheckBox.Checked = true;
                    if (tempUserAccess.ExitRms == 1) ExitCheckBox.Checked= true;
                    if (tempUserAccess.Customers == 1) CustomersCheckBox.Checked = true;
                    if (tempUserAccess.Users == 1) UsersCheckBox.Checked = true;
                    if (tempUserAccess.Booking == 1) BookingCheckBox.Checked = true;
                    if (tempUserAccess.Deposit == 1) DepositCheckBox.Checked = true;
                    if (tempUserAccess.UpdateItems == 1) UpdateItemCheckBox.Checked = true;
                    if (tempUserAccess.RemoveItems == 1) chkRemoveItems.Checked = true;
                    if (tempUserAccess.LogRegister == 1) chkLogRegister.Checked = true;

                    if (tempUserAccess.ProcessDeliveryTime == 1) chkProcessTime.Checked = true;
                    if (tempUserAccess.KitchenText == 1) chkManageKitchenText.Checked = true;

                    if (tempUserAccess.SystemSettings == 1) chkSettings.Checked = true;
                   
                }
                m_cCurrentControl = NameTextBox;
            }
            catch (Exception ex)
            {
            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            try
            {
                CResult tempCheckForValidation = this.ValidateInput();
                if (tempCheckForValidation.IsSuccess)
                {
                    CUserInfo tempUser = new CUserInfo();
                    
                    tempUser.UserName = NameTextBox.Text;

                    //string tempPass =RMSGlobal.Encrypt(PasswordTextBox.Text,true);

                    string tempPass = PasswordTextBox.Text;

                    if (!tempPass.Equals(ConfirmPassTextBox.Text))
                    {
                        MessageBox.Show("Given Password does not match with confirmed password.");
                        PasswordTextBox.Clear();
                        ConfirmPassTextBox.Clear();
                        return;
                    }
                    else
                    {
                        tempUser.Password = tempPass;

                      //  tempUser.Type = UserTypeComboBox.SelectedIndex;
                         tempUser.Type = CUserConstant.GetUSerConstant(UserTypeComboBox.Text); 

                        if (GenderComboBox.SelectedIndex == 0) tempUser.Gender = "Male";
                        else if (GenderComboBox.SelectedIndex == 1) tempUser.Gender = "Female";
                      

                        if (ActiveRadioButton.Checked) tempUser.Status = 1;
                        else if (InActiveRadioButton.Checked) tempUser.Status = 0;
                        

                        CUserAccess tempUserAccess = new CUserAccess();
                        if (OpenDrawerCheckBox.Checked) tempUserAccess.OpenDrawer = 1;
                        if (VoidCheckBox.Checked) tempUserAccess.VoidTable = 1;
                        if (TransferCheckBox.Checked) tempUserAccess.TransferTable = 1;
                        if (MergeCheckBox.Checked) tempUserAccess.MergeTable = 1;
                        if (UnlockCheckBox.Checked) tempUserAccess.UnlockTable = 1;
                        if (ReviewCheckBox.Checked) tempUserAccess.ReviewTransaction = 1;
                        if (ViewCheckBox.Checked) tempUserAccess.ViewReport = 1;
                        if (TillCheckBox.Checked) tempUserAccess.TillReporting = 1;
                        if (ExitCheckBox.Checked) tempUserAccess.ExitRms = 1;
                        if (CustomersCheckBox.Checked) tempUserAccess.Customers = 1;
                        if (UsersCheckBox.Checked) tempUserAccess.Users= 1;
                        if (BookingCheckBox.Checked) tempUserAccess.Booking = 1;
                        if (DepositCheckBox.Checked) tempUserAccess.Deposit = 1;
                        if (UpdateItemCheckBox.Checked) tempUserAccess.UpdateItems = 1;
                        if (chkRemoveItems.Checked) tempUserAccess.RemoveItems = 1;
                        if (chkLogRegister.Checked) tempUserAccess.LogRegister = 1;

                        if (chkProcessTime.Checked) tempUserAccess.ProcessDeliveryTime= 1;
                        if (chkManageKitchenText.Checked) tempUserAccess.KitchenText = 1;

                        if (chkSettings.Checked) tempUserAccess.SystemSettings = 1;


                        tempUser.UserAccess = tempUserAccess;

                        CUserManager tempUserManager = new CUserManager();
                        CResult tempResult = new CResult();
                        if (m_sOpType.Equals("Add")) tempResult = tempUserManager.AddUser(tempUser);
                        else if (m_sOpType.Equals("Update"))
                        {
                            tempUser.UserID = m_oUserInfo.UserID;
                            tempResult = tempUserManager.UpdateUser(tempUser);
                        }
                        else ;

                        if (tempResult.IsSuccess)
                        {
                            Form tempMainForm = CFormManager.Forms.Pop();
                            tempMainForm.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(tempCheckForValidation.Message);
                    ClearTextBoxes();
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public CResult ValidateInput()
        {
            CResult oResult = new CResult();
            
            if (NameTextBox.Text.Equals(String.Empty))
            {
                oResult.Message = " Write User name.";
                return oResult;
            }

            if (PasswordTextBox.Text.Equals(String.Empty))
            {
                oResult.Message = " Write password.";
                return oResult;
            }

            if (ConfirmPassTextBox.Text.Equals(String.Empty))
            {
                oResult.Message = " Confirm password.";
                return oResult;
            }

            if (UserTypeComboBox.SelectedIndex < 0)
            {
                oResult.Message = " Select user type.";
                return oResult;
            }

            if (GenderComboBox.SelectedIndex < 0)
            {
                oResult.Message = " Select gender.";
                return oResult;
            }
            
            oResult.IsSuccess = true;

            return oResult;
        }

        private void custInfoKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            m_cCurrentControl.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void Name_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = NameTextBox;
        }

        private void Password_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = PasswordTextBox;
        }

        private void ConfirmPassword_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = ConfirmPassTextBox;
        }
    }
}