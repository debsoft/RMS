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

namespace RMS.Common
{
    public partial class CCustomerInfoForm : BaseForm
    {         
        private string m_sOpType;
        private CCustomerInfo m_oCustomer;
        private bool UpperCase = false;
        private TextBox m_cCurrentControl;
        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;

        public CCustomerInfoForm()
        {
            InitializeComponent();
        }

        public CCustomerInfoForm(String inOpType, CCustomerInfo inCustomer)
        {
            InitializeComponent();                        
            m_sOpType = inOpType;
            m_oCustomer = inCustomer;            
        }        

        private void ClearTextBoxes()
        {
            txtPhoneNumber.Clear();
            txtCustomerName.Clear();
            txtPostalCode.Clear();
            txtHouseNumber.Clear();
            txtStreetName.Clear();
            txtTown.Clear();
            cmbCountry.SelectedIndex = -1;
        }

        private bool CheckEmpty()
        {            
            if (txtPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("Enter a Phone No.",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            Form tempMainForm = CFormManager.Forms.Pop();
            tempMainForm.Show();
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
            try
            {
                if (CheckEmpty())
                {                    
                    return;
                }

                if (m_sOpType.Equals("Add"))
                {
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                    CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(txtPhoneNumber.Text.Trim());
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }

                    tempCustomerInfo.CustomerName = txtCustomerName.Text.Trim();
                    tempCustomerInfo.CustomerPhone = txtPhoneNumber.Text.Trim();
                    tempCustomerInfo.CustomerPostalCode = txtPostalCode.Text.Trim();
                    tempCustomerInfo.HouseNumber = txtHouseNumber.Text.Trim();
                    tempCustomerInfo.StreetName =txtStreetName.Text.Trim();
                    tempCustomerInfo.CustomerCountry = cmbCountry.Text.Trim();
                    tempCustomerInfo.BuildingName = txtBuildingName.Text.Trim();
                    tempCustomerInfo.CustomerTown = txtTown.Text.Trim();
                    tempCustomerInfo.FloorAptNumber = txtFloorAptNumber.Text.Trim();

                    if (tempCustomerInfo.CustomerID == 0)
                    {
                        oResult = tempCustomerManager.InsertCustomerInfo(tempCustomerInfo);
                        if (oResult.IsSuccess && oResult.Data != null)
                        {                                                        
                            Form tempForm = CFormManager.Forms.Pop();
                            tempForm.Show();
                            this.Close();                         
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer with this Phone No alredy exixsts./nPlease Select other Phone No.",
                            RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;                        
                    }
                }
                else if (m_sOpType.Equals("Update"))
                {
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                    CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(m_oCustomer.CustomerPhone);
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }

                    tempCustomerInfo.CustomerName = txtCustomerName.Text.Trim();
                    tempCustomerInfo.CustomerPhone = txtPhoneNumber.Text.Trim();
                    tempCustomerInfo.CustomerPostalCode = txtPostalCode.Text.Trim();
                    tempCustomerInfo.HouseNumber = txtHouseNumber.Text.Trim();
                    tempCustomerInfo.StreetName = txtStreetName.Text.Trim();
                    tempCustomerInfo.CustomerCountry = cmbCountry.Text.Trim();
                    tempCustomerInfo.BuildingName = txtBuildingName.Text.Trim();
                    tempCustomerInfo.CustomerTown = txtTown.Text.Trim();
                    tempCustomerInfo.FloorAptNumber = txtFloorAptNumber.Text.Trim();

                    CResult tempResult3 = tempCustomerManager.UpdateCustomerInfo(tempCustomerInfo);

                    if (tempResult3.IsSuccess)
                    {
                        Form tempForm = CFormManager.Forms.Pop();
                        tempForm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
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
                if (m_sOpType.Equals("Update") && m_oCustomer != null)
                {
                    ClearTextBoxes();

                    txtPhoneNumber.Text = m_oCustomer.CustomerPhone;
                    txtCustomerName.Text = m_oCustomer.CustomerName;
                    txtPostalCode.Text = m_oCustomer.CustomerPostalCode;
                   
                    txtHouseNumber.Text = m_oCustomer.HouseNumber;
                    txtStreetName.Text = m_oCustomer.StreetName;
                    txtTown.Text = m_oCustomer.CustomerTown;
                    cmbCountry.Text = m_oCustomer.CustomerCountry;
                    txtFloorAptNumber.Text = m_oCustomer.FloorAptNumber;
                    txtBuildingName.Text = m_oCustomer.BuildingName;
                }
                m_cCurrentControl = txtCustomerName;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

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
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.GetCustomerAddressInfo(txtHouseNumber.Text, txtPostalCode.Text);
                SortedList slAddressInfo = (SortedList)oResult.Data;

                if (slAddressInfo.Count > 1)
                {
                    AddressInFoForm objAddresses = new AddressInFoForm(slAddressInfo);
                    objAddresses.ShowDialog();
                    string addressKey = AddressInFoForm.m_addressKey.ToUpper().Replace(" ", "");
                    clsCustomerInfo objCustomer = (clsCustomerInfo)slAddressInfo[addressKey];
                    txtHouseNumber.Text = objCustomer.HouseNumber;
                    txtBuildingName.Text = objCustomer.buildingName;
                    txtTown.Text = objCustomer.Town;
                    txtFloorAptNumber.Text = objCustomer.ApartmentNumber;
                    txtStreetName.Text = objCustomer.StreenName.ToString();
                }
                else if (slAddressInfo.Count == 1)
                {
                    foreach (clsCustomerInfo objCustomer in slAddressInfo.Values)
                    {
                        txtHouseNumber.Text = objCustomer.HouseNumber;
                        txtBuildingName.Text = objCustomer.buildingName;
                        txtTown.Text = objCustomer.Town;
                        txtStreetName.Text = objCustomer.StreenName;
                    }
                }
                else
                {
                    MessageBox.Show("No address has been found.", RMSGlobal.MessageBoxTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                string phone = txtPhoneNumber.Text.Trim();
                ClearTextBoxes();
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(phone);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                }

                txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                txtCustomerName.Text = tempCustomerInfo.CustomerName;
                txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                txtHouseNumber.Text = tempCustomerInfo.HouseNumber;
                txtStreetName.Text = tempCustomerInfo.StreetName;
                txtTown.Text = tempCustomerInfo.CustomerTown;
                cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                txtBuildingName.Text = tempCustomerInfo.BuildingName;
                txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtCustomerName.Text.Length < 1)
            {
                return;
            }
            try
            {
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.GetCustomerInfoByName(txtCustomerName.Text);
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
                    txtPhoneNumber.Text = phoneNumber;
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
                txtPhoneNumber.Text = CustomerListForm.m_phoneNumber;
                btnSearchByPhone_Click(sender, e);
            }
        }

        private void Name_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtCustomerName;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPhoneNumber;
        }

        private void Floor_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtFloorAptNumber;
        }

        private void buildingName_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtBuildingName;
        }

        private void HouseNo_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtHouseNumber;
        }

        private void StreetName_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtStreetName;
        }

        private void Town_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTown;
        }

        private void PostalCode_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPostalCode;
        }                             
    }
}