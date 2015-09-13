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
using RMS.MemberShipCardManage;

namespace RMS.MemberShipCardNoManage
{
    public partial class CMemberShipAddForm : BaseForm
    {         
        private string m_sOpType;
        private CCustomerInfo m_oCustomer;
        private bool UpperCase = false;
        private TextBox m_cCurrentControl;
        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;


        private Membership membership = null;
        private bool isModify = false;       

        public bool ISModify
        {
            get { return isModify; }
            set { isModify = value; }
        }

        private bool isSetMemberShipCard = false;

        public bool ISSetMemberShipCard
        {
            get { return isSetMemberShipCard; }
            set { isSetMemberShipCard = value; }
        }

        public Membership MembershipData
        {
            get { return membership; }
            set { membership  = value; }
        }


        public CMemberShipAddForm()
        {
            InitializeComponent();

            this.ScreenTitle = " Membership Card";
        }

        public CMemberShipAddForm(String inOpType, CCustomerInfo inCustomer)
        {
            InitializeComponent();                        
            m_sOpType = inOpType;
            m_oCustomer = inCustomer;
            this.ScreenTitle = " Membership Card";
           // this.membership = membership;
        }        

        private void ClearTextBoxes()
        {
          //  txtDescription.Clear();
            txtMembershipCardName.Clear();
         //   txtPostalCode.Clear();
            txtCode.Clear();
            //txtPoint.Clear();
          //  txtDiscountPercentRate.Clear();
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

            IMembershipDao membershipDao = new MembershipDao();
                  
            try
            {
                if (CheckEmpty())
                {                    
                    return;
                }

                if (isModify)
                {
                    membership = txtTitle.Tag as Membership;
                }
                else
                {
                    membership = new Membership();
                    membership.issueDate = System.DateTime.Now;
                }

                if (txtCustomerName.Tag != null)
                {
                    membership.customerID = (txtCustomerName.Tag as CCustomerInfo).CustomerID;
                }

                if (!isModify)
                {
                    if (txtCustomerName.Tag == null || membership.customerID == 0)
                    {
                        MessageBox.Show("Please select the customer");
                        return;
                    }
                }
               
                membership.customerName = txtCustomerName.Text;
                membership.customerPhone = txtPhoneNumber.Text;

                if (txtMembershipCardName.Tag != null)
                {
                    membership.mebershipCardID = (txtMembershipCardName.Tag as MembershipCard).id;
                }


                membership.membershipCardName = txtMembershipCardName.Text;
                membership.membershipCardType = cmbType.Text;
                membership.startDate = dtpStartDate.Value;
                membership.endDate = dtpEndDate.Value;

                membership.membershipCardTitle = txtTitle.Text;
                membership.membershipCardCode = txtCode.Text;

                membership.point = float.Parse(txtPoint.Text.ToString());
                membership.discountPercentRate = float.Parse(txtDiscountPercentRate.Text.ToString());               

                if (rdbActive.Checked)
                {
                    membership.isActive = rdbActive.Checked;
                }
                else if (rdbInActive.Checked)
                {
                    membership.isActive = false;
                }
                

                if (isModify)
                {
                    membershipDao.UpdateMembership(membership);
                    MessageBox.Show("Membership  " + membership.id + " updated successfully");
                }
                else
                {
                    membershipDao.AddMembership(membership);
                    MessageBox.Show("Membership  " + membership.id + " created successfully");
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


                txtCustomerName.Text = membership.customerName;
                txtPhoneNumber.Text = membership.customerPhone;


              
               txtMembershipCardName.Text = membership.membershipCardName;
               txtTitle.Tag = membership;
               cmbType.Text = membership.membershipCardType;
               dtpStartDate.Value = membership.startDate;
               dtpEndDate.Value = membership.endDate;

               txtPoint.Text = membership.point.ToString();
               txtDiscountPercentRate.Text = membership.discountPercentRate.ToString();

               txtTitle.Text = membership.membershipCardTitle.ToString();
               txtCode.Text = membership.membershipCardCode.ToString();

                
                if (membership.isActive)
                {
                    rdbActive.Checked = true;
                }
                else
                {
                    rdbInActive.Checked = true;
                }
                               
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

        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {

        }

        private void CCustomerInfoForm_Activated(object sender, EventArgs e)
        {
            if (CustomerListForm.m_phoneNumber.Length > 0)
            {
              //  txtDescription.Text = CustomerListForm.m_phoneNumber;
                btnSearchByPhone_Click(sender, e);
            }
        }

        private void Name_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtMembershipCardName;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
           // keyboard1.ControlToInputText = txtDescription;
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
           // keyboard1.ControlToInputText = txtPoint;
        }

        private void Town_Click(object sender, EventArgs e)
        {
         //   keyboard1.ControlToInputText = txtDiscountPercentRate;
        }

        private void PostalCode_Click(object sender, EventArgs e)
        {
            //keyboard1.ControlToInputText = txtPostalCode;
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTitle;
        }

        private void btnMemberShipCardAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnMemberShipCardRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnMemberShipCardRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnFindCustomer_Click_1(object sender, EventArgs e)
        {
            if (isSetMemberShipCard)
            {
                SearchMembership(3);
            }
            else
            {
                SearchCustomer(1);
            }
        }

        private void SearchCustomer(int searchType)
        {
            if (searchType == 1)
            {
                if (txtCustomerName.Text == "" || txtCustomerName.Text.Length < 1)
                {
                    return;
                }
            }
            else if (searchType == 2)
            {
                if (txtPhoneNumber.Text == "" || txtPhoneNumber.Text.Length < 1)
                {
                    return;
                }
            }

            try
            {
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult;

                if (searchType == 1)
                {
                    oResult = tempCustomerManager.GetCustomerInfoByName(txtCustomerName.Text);
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    DataTable dtCustomerList = (DataTable)tempCustomerInfo.CustomerDataTable;
                    if (dtCustomerList.Rows.Count > 1)
                    {
                        CustomerListForm objCustomerList = new CustomerListForm(dtCustomerList);
                        objCustomerList.ShowDialog(this);

                        string phoneNumber = CustomerListForm.m_phoneNumber;
                        if (phoneNumber != null && !phoneNumber.ToString().Equals(""))
                        {
                            oResult = tempCustomerManager.CustomerInfoGetByPhone(phoneNumber);
                            if (oResult.IsSuccess && oResult.Data != null)
                            {
                                tempCustomerInfo = (CCustomerInfo)oResult.Data;

                                FillCustomerInfo(tempCustomerInfo);
                            }
                        }
                    }
                    else if (dtCustomerList.Rows.Count == 1)
                    {
                        string phoneNumber = dtCustomerList.Rows[0]["phone"].ToString();
                        oResult = tempCustomerManager.CustomerInfoGetByPhone(phoneNumber);
                        if (oResult.IsSuccess && oResult.Data != null)
                        {
                            tempCustomerInfo = (CCustomerInfo)oResult.Data;

                            FillCustomerInfo(tempCustomerInfo);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (searchType == 2)
                {
                    string phoneNumber = txtPhoneNumber.Text;
                    oResult = tempCustomerManager.CustomerInfoGetByPhone(phoneNumber);
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;

                        FillCustomerInfo(tempCustomerInfo);
                    }
                    else
                    {
                        MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }


        private void FillCustomerInfo(CCustomerInfo tempCustomerInfo)
        {    

            txtCustomerName.Text = tempCustomerInfo.CustomerName;
            txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;

            txtCustomerName.Tag = tempCustomerInfo;
        }
        private void btnMembershipCardName_Click(object sender, EventArgs e)
        {
            if (isSetMemberShipCard)
            {
                SearchMembership(1);
            }
            else
            {
                SearchMembershipCard(1);
            }
        }


        private void SearchMembershipCard(int searchType)
        {
            if (searchType == 1)
            {
                if (txtMembershipCardName.Text == "" || txtMembershipCardName.Text.Length < 1)
                {
                    return;
                }
            }
            else if (searchType == 2)
            {
                if (txtCode.Text == "" || txtCode.Text.Length < 1)
                {
                    return;
                }
            }

            IMembershipCardDao membershipCardDao = new MembershipCardDao();

            try
            {
                List<MembershipCard> membershipCardList = new List<MembershipCard> ();

                if (searchType == 1)
                {
                    membershipCardList = membershipCardDao.GetAllMembershipCardByName(txtMembershipCardName.Text);
                }
                else
                {
                    membershipCardList = membershipCardDao.GetAllMembershipCardByName(txtCode.Text);
                }

                if (membershipCardList.Count == 1)
                {
                    FillMembershipCard(membershipCardList[0]);
                }
                else if (membershipCardList.Count > 1)
                {
                    CMemberShipCardForm objMemberShipCardForm = new CMemberShipCardForm();

                    objMemberShipCardForm.btnSelect.Visible = true;
                    objMemberShipCardForm.btnSelect.Location = new Point(654, 452);                     
                    objMemberShipCardForm.MembershipCardListData = membershipCardList;

                    objMemberShipCardForm.ISDialogBox = true;
                    objMemberShipCardForm.AddButton.Visible =false;
                    objMemberShipCardForm.UpdateButton.Visible = false;
                    objMemberShipCardForm.DeleteButton.Visible = false;

               //    CFormManager.Forms.Push(this);
               //     this.Hide();   

                    objMemberShipCardForm.ShowDialog(this);      

                    if (objMemberShipCardForm.DialogResult == DialogResult.OK)
                    {
                        FillMembershipCard(objMemberShipCardForm.membershipCardData);

                    }
                }

                //CCustomerManager tempCustomerManager = new CCustomerManager();
                //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                //CResult oResult = tempCustomerManager.GetCustomerInfoByName(txtMembershipCardName.Text);
                //tempCustomerInfo = (CCustomerInfo)oResult.Data;
                //DataTable dtCustomerList = (DataTable)tempCustomerInfo.CustomerDataTable;
                //if (dtCustomerList.Rows.Count > 1)
                //{
                //    CustomerListForm objCustomerList = new CustomerListForm(dtCustomerList);
                //    objCustomerList.ShowDialog(this);
                //}
                //else if (dtCustomerList.Rows.Count == 1)
                //{
                //    string phoneNumber = dtCustomerList.Rows[0]["phone"].ToString();
                //    txtcDescription.Text = phoneNumber;
                //    btnSearchByPhone_Click(sender, e);
                //}
                //else
                //{
                //    MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }


        private void FillMembershipCard(MembershipCard membershipCard)
        {
            txtMembershipCardName.Tag = membershipCard;

            dtpStartDate.Value = membershipCard.startDate;
            dtpEndDate.Value = membershipCard.endDate;

            txtMembershipCardName.Text = membershipCard.name;
            cmbType.Text = membershipCard.type;

            txtTitle.Text = membershipCard.title;
            txtCode.Text = membershipCard.code;
            txtPoint.Text = membershipCard.points.ToString();
            txtDiscountPercentRate.Text = membershipCard.discountPercent.ToString();

        }

        private void btnMembershipCardCode_Click(object sender, EventArgs e)
        {
            if (isSetMemberShipCard)
            {
                SearchMembership(2);
            }
            else
            {
                SearchMembershipCard(2);
            }
        }

        private void btnSearchByPhone_Click_1(object sender, EventArgs e)
        {
            if (isSetMemberShipCard)
            {

            }
            else
            {
                SearchCustomer(2);
            }
        }

        #region SearchMembership
        private void SearchMembership(int searchType)
        {
            if (searchType == 1)
            {
                if (txtMembershipCardName.Text == "" || txtMembershipCardName.Text.Length < 1)
                {
                    return;
                }
            }
            else if (searchType == 2)
            {
                if (txtCode.Text == "" || txtCode.Text.Length < 1)
                {
                    return;
                }
            }
            else if (searchType == 3)
            {
                if (txtCustomerName.Text == "" || txtCustomerName.Text.Length < 1)
                {
                    return;
                }
            }
            else if (searchType == 4)
            {
                if (txtPhoneNumber.Text == "" || txtPhoneNumber.Text.Length < 1)
                {
                    return;
                }
            }

            IMembershipDao membershipDao = new MembershipDao();

            try
            {
                List<Membership> membershipList = new List<Membership>();

                Membership membership = new Membership();

                if (searchType == 1)
                {
                    membershipList = membershipDao.GetMembershipByMembershipCardName(txtMembershipCardName.Text);
                }
                else if (searchType == 2)
                {
                    membership = membershipDao.GetMembershipByMembershipCardCode(txtCode.Text);
                    if (membership != null && membership.id>0)
                        membershipList.Add(membership);
                }
                else if (searchType == 2)
                {
                    membership = membershipDao.GetMembershipByCustomerPhone(txtPhoneNumber.Text);
                    if (membership != null && membership.id > 0)
                        membershipList.Add(membership);
                }

                if (membershipList.Count == 1)
                {
                    FillMembership(membershipList[0]);
                }
                else if (membershipList.Count > 1)
                {
                    CMemberShipForm objMemberShipForm = new CMemberShipForm();

                    objMemberShipForm.btnSelect.Visible = true;
                    objMemberShipForm.btnSelect.Location = new Point(654, 452);
                    objMemberShipForm.MembershipListData = membershipList;

                    objMemberShipForm.ISDialogBox = true;
                    objMemberShipForm.AddButton.Visible = false;
                    objMemberShipForm.UpdateButton.Visible = false;
                    objMemberShipForm.DeleteButton.Visible = false;

               //     CFormManager.Forms.Push(this);
              //      this.Hide();

                    objMemberShipForm.ShowDialog(this);

                    if (objMemberShipForm.DialogResult == DialogResult.OK)
                    {
                        FillMembership(objMemberShipForm.membershipData);

                    }
                }

                //CCustomerManager tempCustomerManager = new CCustomerManager();
                //CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                //CResult oResult = tempCustomerManager.GetCustomerInfoByName(txtMembershipCardName.Text);
                //tempCustomerInfo = (CCustomerInfo)oResult.Data;
                //DataTable dtCustomerList = (DataTable)tempCustomerInfo.CustomerDataTable;
                //if (dtCustomerList.Rows.Count > 1)
                //{
                //    CustomerListForm objCustomerList = new CustomerListForm(dtCustomerList);
                //    objCustomerList.ShowDialog(this);
                //}
                //else if (dtCustomerList.Rows.Count == 1)
                //{
                //    string phoneNumber = dtCustomerList.Rows[0]["phone"].ToString();
                //    txtcDescription.Text = phoneNumber;
                //    btnSearchByPhone_Click(sender, e);
                //}
                //else
                //{
                //    MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        #endregion


        #region FillMembership
        private void FillMembership(Membership membership)
        {

            if (membership != null)
            {
                txtCustomerName.Text = membership.customerName;
                txtPhoneNumber.Text = membership.customerPhone;

                this.membership = membership;

                txtMembershipCardName.Text = membership.membershipCardName;
                txtTitle.Tag = membership;
                cmbType.Text = membership.membershipCardType;
                dtpStartDate.Value = membership.startDate;
                dtpEndDate.Value = membership.endDate;

                txtPoint.Text = membership.point.ToString();
                txtDiscountPercentRate.Text = membership.discountPercentRate.ToString();

                txtTitle.Text = membership.membershipCardTitle.ToString();
                txtCode.Text = membership.membershipCardCode.ToString();


                if (membership.isActive)
                {
                    rdbActive.Checked = true;
                }
                else
                {
                    rdbInActive.Checked = true;
                }
            }
              
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {          
            this.DialogResult = DialogResult.OK;
            //Form tempForm = CFormManager.Forms.Pop();
            //tempForm.Show();
            this.Close();
        }

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtCustomerName;
        }

        private void txtPhoneNumber_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPhoneNumber;
        }

        private void txtMembershipCardName_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtMembershipCardName;
        }

        private void txtTitle_Click_1(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTitle;
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtCode;
        }

        private void txtPoint_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPoint;
        }

        private void txtDiscountPercentRate_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtDiscountPercentRate;
        }
    }
}