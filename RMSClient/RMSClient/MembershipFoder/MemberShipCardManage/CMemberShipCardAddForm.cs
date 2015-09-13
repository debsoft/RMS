using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.Customer;
using System.Collections;
using RMS.TakeAway;
using RMSUI;
using RMS.Common;
using RMSClient.DataAccess;
using RMS.Common.DataAccess;

namespace RMS.MemberShipCardManage
{
    public partial class CMemberShipCardAddForm : BaseForm
    {         
        private string m_sOpType;
        private CCustomerInfo m_oCustomer;
        private bool UpperCase = false;
        private TextBox m_cCurrentControl;
        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;


        private MembershipCard membershipCard = null;
        private bool isModify = false;

        public bool ISModify
        {
            get { return isModify; }
            set { isModify = value; }
        }

        public MembershipCard MembershipCardData
        {
            get { return membershipCard; }
            set { membershipCard  = value; }
        }


        public CMemberShipCardAddForm()
        {
            InitializeComponent();

            this.ScreenTitle = "Membership Card";
        }

        public CMemberShipCardAddForm(String inOpType, MembershipCard inCustomer)
        {
            InitializeComponent();                        
            m_sOpType = inOpType;
            membershipCard = inCustomer;

            this.ScreenTitle = "Membership Card";
        }        

        private void ClearTextBoxes()
        {
            txtDescription.Clear();
            txtMembershipCardName.Clear();
         //   txtPostalCode.Clear();
            txtCode.Clear();
            txtPoint.Clear();
            txtDiscountPercentRate.Clear();
            cmbType.SelectedIndex = -1;
        }

        private bool CheckEmpty()
        {            
            if (txtMembershipCardName.Text.Equals(""))
            {
                MessageBox.Show("Enter a Membership Card Name",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }            

            else return(false);           
        }       

        private void SetText(string input)
        {           
            try
            {
                if (UpperCase)
                {
                    input = input.ToUpper();
                }

                if (m_cCurrentControl.SelectionLength == 0)
                {
                    m_cCurrentControl.SelectionLength = 1;
                }
                m_cCurrentControl.Text = m_cCurrentControl.Text.Insert(m_iSelectionIndex, input);
                m_iSelectionIndex++;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Form tempMainForm = CFormManager.Forms.Pop();
            //tempMainForm.Show();
            this.Close();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            m_cCurrentControl = (TextBox)sender;
            m_pCursorPosition = Cursor.Current.HotSpot;
            m_iSelectionIndex = m_cCurrentControl.SelectionStart;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {

            IMembershipCardDao membershipCardDao = new MembershipCardDao();
                   

            try
            {
                if (CheckEmpty())
                {                    
                    return;
                }

                if (isModify)
                {
                    membershipCard = txtMembershipCardName.Tag as MembershipCard;
                }
                else
                {
                    membershipCard = new MembershipCard();
                    membershipCard.creationDate = System.DateTime.Now;
                }


                membershipCard.startDate = dtpStartDate.Value;
                membershipCard.endDate = dtpEndDate.Value;


                membershipCard.name = txtMembershipCardName.Text;
                membershipCard.type = cmbType.Text;
                if (rdbActive.Checked)
                {
                    membershipCard.isActive = rdbActive.Checked;
                }
                else if (rdbInActive.Checked)
                {
                    membershipCard.isActive = false;
                }

                membershipCard.title = txtTitle.Text;
                membershipCard.code = txtCode.Text;

                if (txtPoint.Text != null && !txtPoint.Text.ToString().Equals(""))
                {
                    membershipCard.points = Convert.ToDouble(txtPoint.Text);
                }
                else
                {
                    membershipCard.points = 0;
                }

                if (txtDiscountPercentRate.Text != null && !txtDiscountPercentRate.Text.ToString().Equals(""))
                {
                    membershipCard.discountPercent = Convert.ToDouble(txtDiscountPercentRate.Text);
                }

                membershipCard.description = txtDescription.Text;


                if (isModify)
                {

                    membershipCardDao.UpdateMembershipCard(membershipCard);
                    MessageBox.Show("Membership Card " + membershipCard.id + " updated successfully");

                }
                else
                {

                    membershipCardDao.AddMembershipCard(membershipCard);
                    MessageBox.Show("Membership Card " + membershipCard.id + " created successfully");

                }                

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                //Console.Write(exp.Message);
            }
        }
        
        private void PhoneSearchButton_Click(object sender, EventArgs e)
        {
            
        }
     
        private void TwoButton_Click(object sender, EventArgs e)
        {
            SetText("2");
        }
        private void ThreeButton_Click(object sender, EventArgs e)
        {
            SetText("3");
        }
        private void FourButton_Click(object sender, EventArgs e)
        {
            SetText("4");
        }
        private void FiveButton_Click(object sender, EventArgs e)
        {
            SetText("5");
        }
        private void SixButton_Click(object sender, EventArgs e)
        {
            SetText("6");
        }
        private void SevenButton_Click(object sender, EventArgs e)
        {
            SetText("7");
        }
        private void EightButton_Click(object sender, EventArgs e)
        {
            SetText("8");
        }
        private void NineButton_Click(object sender, EventArgs e)
        {
            SetText("9");
        }
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            SetText("0");
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {                
                if (m_cCurrentControl.SelectionLength == 0)
                    m_cCurrentControl.SelectionLength = 1;
                m_cCurrentControl.Text = m_cCurrentControl.Text.Remove(m_iSelectionIndex, m_cCurrentControl.SelectionLength);
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        
        private void KeyButton_Click(object sender, EventArgs e)
        {
            String letter=((Button)sender).Text;
            String input= (UpperCase)?(letter.ToUpper()):(letter);
            SetText(input);
        }
        private void KeyCommaButton_Click(object sender, EventArgs e)
        {
            String input= ",";
            SetText(input);
        }
        private void KeyFullStopButton_Click(object sender, EventArgs e)
        {
            String input= ".";
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

                
                m_cCurrentControl.Text = m_cCurrentControl.Text.Remove(m_iSelectionIndex-1, tempLength);
                m_iSelectionIndex--;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        private void SpaceButton_Click(object sender, EventArgs e)
        {
            SetText(" ");
        }

        /// <summary>
        /// Modified By Baruri at 12.12.2008
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CCustomerInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitForm();
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        #region InitForm
        private void InitForm()
        {
            if (isModify)
            {
                 txtMembershipCardName.Tag = membershipCard;

                 dtpStartDate.Value = membershipCard.startDate;
                 dtpEndDate.Value = membershipCard.endDate;

                 txtMembershipCardName.Text = membershipCard.name;
                 cmbType.Text = membershipCard.type;
                 if (membershipCard.isActive)
                {
                    rdbActive.Checked = true;
                }
                else 
                {
                    rdbInActive.Checked = true;
                }

                txtTitle.Text = membershipCard.title;
                txtCode.Text = membershipCard.code;
                txtPoint.Text = membershipCard.points.ToString();
                txtDiscountPercentRate.Text = membershipCard.discountPercent.ToString();

                txtDescription.Text = membershipCard.description;
                
            }
        }
        #endregion

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PhoneSearchButton_Click(sender, e);
            }
        }

        private void customerKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            m_cCurrentControl.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void btnAddressLookup_Click(object sender, EventArgs e)
        {
            try
            {
                //CCustomerManager tempCustomerManager = new CCustomerManager();
                //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                //CResult oResult = tempCustomerManager.GetCustomerAddressInfo(txtCode.Text, txtPostalCode.Text);
                //SortedList slAddressInfo = (SortedList)oResult.Data;

                //if (slAddressInfo.Count > 1)
                //{
                //    AddressInFoForm objAddresses = new AddressInFoForm(slAddressInfo);
                //    objAddresses.ShowDialog();
                //    string addressKey = AddressInFoForm.m_addressKey.ToUpper().Replace(" ", "");
                //    clsCustomerInfo objCustomer = (clsCustomerInfo)slAddressInfo[addressKey];
                //    txtCode.Text = objCustomer.HouseNumber;
                //    txtBuildingName.Text = objCustomer.buildingName;
                //    txtDiscountPercentRate.Text = objCustomer.Town;
                //    txtFloorAptNumber.Text = objCustomer.ApartmentNumber;
                //    txtPoint.Text = objCustomer.StreenName.ToString();
                //}
                //else if (slAddressInfo.Count == 1)
                //{
                //    foreach (clsCustomerInfo objCustomer in slAddressInfo.Values)
                //    {
                //        txtCode.Text = objCustomer.HouseNumber;
                //        txtBuildingName.Text = objCustomer.buildingName;
                //        txtDiscountPercentRate.Text = objCustomer.Town;
                //        txtPoint.Text = objCustomer.StreenName;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("No address has been found.", RMSGlobal.MessageBoxTitle,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            SetText("1");
        }

        private void btnSearchByPhone_Click(object sender, EventArgs e)
        {
            try
            {
                //string phone = txtDescription.Text.Trim();
                //ClearTextBoxes();
                //CCustomerManager tempCustomerManager = new CCustomerManager();
                //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                //CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(phone);
                //if (oResult.IsSuccess && oResult.Data != null)
                //{
                //    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                //}

                //txtDescription.Text = tempCustomerInfo.CustomerPhone;
                //txtMembershipCardName.Text = tempCustomerInfo.CustomerName;
                //txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                //txtCode.Text = tempCustomerInfo.HouseNumber;
                //txtPoint.Text = tempCustomerInfo.StreetName;
                //txtDiscountPercentRate.Text = tempCustomerInfo.CustomerTown;
                //cmbType.Text = tempCustomerInfo.CustomerCountry;
                //txtBuildingName.Text = tempCustomerInfo.BuildingName;
                //txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            if (txtMembershipCardName.Text == "" || txtMembershipCardName.Text.Length < 1)
            {
                return;
            }
            try
            {
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.GetCustomerInfoByName(txtMembershipCardName.Text);
                tempCustomerInfo = (CCustomerInfo)oResult.Data;
                DataTable dtCustomerList = (DataTable)tempCustomerInfo.CustomerDataTable;
                if (dtCustomerList.Rows.Count > 1)
                {
                    CustomerListForm objCustomerList = new CustomerListForm(dtCustomerList);
                    objCustomerList.ShowDialog(this);
                }
                else if (dtCustomerList.Rows.Count == 1)
                {
                    string phoneNumber = dtCustomerList.Rows[0]["phone"].ToString();
                    txtDescription.Text = phoneNumber;
                    btnSearchByPhone_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void CCustomerInfoForm_Activated(object sender, EventArgs e)
        {
            if (CustomerListForm.m_phoneNumber.Length > 0)
            {
                txtDescription.Text = CustomerListForm.m_phoneNumber;
                btnSearchByPhone_Click(sender, e);
            }
        }

        private void Name_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtMembershipCardName;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtDescription;
        }

        private void Floor_Click(object sender, EventArgs e)
        {
          //  keyboard1.ControlToInputText = txtFloorAptNumber;
        }

        private void buildingName_Click(object sender, EventArgs e)
        {
         //   keyboard1.ControlToInputText = txtBuildingName;
        }

        private void HouseNo_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtCode;
        }

        private void StreetName_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPoint;
        }

        private void Town_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtDiscountPercentRate;
        }

        private void PostalCode_Click(object sender, EventArgs e)
        {
            //keyboard1.ControlToInputText = txtPostalCode;
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTitle;
        }                             
    }
}