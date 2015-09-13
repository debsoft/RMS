using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using Managers.Customer;
using System.Collections;
using RMSUI;

namespace RMS.Common
{
    public partial class CBookingInfoForm : BaseForm
    {                    
        private DateTime tempCurrentDate;   
        private string m_sOpType;
        private CBooking m_oBooking;
        private bool UpperCase = false;
        private TextBox m_cCurrentControl;
        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;
        private string m_phoneNumber = String.Empty;

        public CBookingInfoForm()
        {
            InitializeComponent();
        }

        public CBookingInfoForm(DateTime inCurrentDate, String inOpType, CBooking inBooking)
        {
            InitializeComponent();            
            tempCurrentDate = inCurrentDate;
            m_sOpType = inOpType;           
            m_oBooking = inBooking;
            this.Text = inOpType+" Booking Info";
        }


        public CBookingInfoForm(String inOpType, CBooking inBooking)
        {
            InitializeComponent();
            tempCurrentDate = DateTime.Today.Date;
            m_sOpType = inOpType;
            m_oBooking = inBooking;
            this.Text = inOpType + " Booking Info";
        }


        private void ClearTextBoxes()
        {
            txtPhoneNumber.Clear();
            NameTextBox.Clear();
            txtPostalCode.Clear();
            txtHouseNumber.Clear();
            txtStreetName.Clear();
            txtTown.Clear();
            CommentTextBox.Clear();
            NoofGuestTextBox.Clear();         
        }

        private bool CheckEmpty()
        {            
            if (txtPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("Enter a Phone No.");
                return true;
            }

            else if (NoofGuestTextBox.Text.Equals(""))
            {
                MessageBox.Show("Enter No of Guest.");
                return true;
            }

            else return(false);           
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
            m_pCursorPosition = Cursor.Current.HotSpot;
            m_iSelectionIndex = m_cCurrentControl.SelectionStart;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
            else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

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

                    tempCustomerInfo.CustomerName = NameTextBox.Text.Trim();
                    tempCustomerInfo.CustomerPhone = txtPhoneNumber.Text.Trim();
                    tempCustomerInfo.CustomerPostalCode = txtPostalCode.Text.Trim();
                    tempCustomerInfo.HouseNumber = txtHouseNumber.Text.Trim();
                    tempCustomerInfo.FloorAptNumber = txtFloorAptNumber.Text;
                    tempCustomerInfo.BuildingName = txtBuildingName.Text;
                    tempCustomerInfo.CustomerTown = txtTown.Text.Trim();
                    tempCustomerInfo.CustomerCountry = cmbCountry.Text.Trim();
                    tempCustomerInfo.StreetName = txtStreetName.Text ;

                    if (tempCustomerInfo.CustomerID == 0)
                    {
                        oResult = tempCustomerManager.InsertCustomerInfo(tempCustomerInfo);
                        if (oResult.IsSuccess && oResult.Data != null)
                            tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }
                    else
                    {
                        tempCustomerManager.UpdateCustomerInfo(tempCustomerInfo);

                        CBooking tempBooking = new CBooking();
                        tempBooking.Address = tempCustomerInfo.CustomerAddress;
                        tempBooking.BookingTime = tempCurrentDate.Ticks;
                        if (ProvisionalRadioButton.Checked) tempBooking.BookingType = "Provisional";
                        else if (ConfirmRadioButton.Checked) tempBooking.BookingType = "Confirmed";
                        else if (CallBackRadioButton.Checked) tempBooking.BookingType = "CallBack";
                        else if (FinishRadioButton.Checked) tempBooking.BookingType = "Finished";
                       
                        tempBooking.Comments = CommentTextBox.Text;
                        tempBooking.CustomerID = tempCustomerInfo.CustomerID;
                        tempBooking.CustomerName = tempCustomerInfo.CustomerName;
                        int temp = 0;
                        int.TryParse(NoofGuestTextBox.Text, out temp);
                        tempBooking.GuestCount = temp;
                        tempBooking.TableCount = 0;

                        COrderManager tempOrderManager = new COrderManager();
                        CResult tempResult3 = tempOrderManager.InsertBookingInfo(tempBooking);
                        if (tempResult3.IsSuccess)
                        {
                            Form tempForm = CFormManager.Forms.Pop();
                            tempForm.Show();
                            this.Close();
                        }
                    }
                }
                else if (m_sOpType.Equals("Update"))
                {
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                    CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(m_oBooking.Phone);
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }

                    tempCustomerInfo.CustomerName = NameTextBox.Text.Trim();
                    tempCustomerInfo.CustomerPhone = txtPhoneNumber.Text.Trim();
                    tempCustomerInfo.CustomerPostalCode = txtPostalCode.Text.Trim();
                    tempCustomerInfo.HouseNumber = txtHouseNumber.Text.Trim();
                    tempCustomerInfo.FloorAptNumber = txtFloorAptNumber.Text;
                    tempCustomerInfo.BuildingName = txtBuildingName.Text;
                    tempCustomerInfo.CustomerTown = txtTown.Text.Trim();
                    tempCustomerInfo.CustomerCountry = cmbCountry.Text.Trim();
                    tempCustomerInfo.StreetName = txtStreetName.Text ;

                    tempCustomerManager.UpdateCustomerInfo(tempCustomerInfo);

                    CBooking tempBooking = m_oBooking;
                    tempBooking.Address = tempCustomerInfo.CustomerAddress;
                    tempBooking.BookingTime = tempCurrentDate.Ticks;
                    if (ProvisionalRadioButton.Checked) tempBooking.BookingType = "Provisional";
                    else if (ConfirmRadioButton.Checked) tempBooking.BookingType = "Confirmed";
                    else if (CallBackRadioButton.Checked) tempBooking.BookingType = "CallBack";
                    else if (FinishRadioButton.Checked) tempBooking.BookingType = "Finished";
                    
                    tempBooking.Comments = CommentTextBox.Text;
                    tempBooking.CustomerID = tempCustomerInfo.CustomerID;
                    tempBooking.CustomerName = tempCustomerInfo.CustomerName;
                    int temp = 0;
                    int.TryParse(NoofGuestTextBox.Text, out temp);
                    tempBooking.GuestCount = temp;
                    tempBooking.TableCount = 0;

                    COrderManager tempOrderManager = new COrderManager();
                    CResult tempResult3 = tempOrderManager.updateBookingInfo(tempBooking);

                    if (tempResult3.IsSuccess)
                    {
                        Form tempForm = CFormManager.Forms.Pop();
                        tempForm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception eee)
            {
            }
        }
        
       
        private void OneButton_Click(object sender, EventArgs e)
        {
            SetText("1");
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
            catch (Exception eee)
            {
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
            catch (Exception eee)
            {
            }
        }
        private void SpaceButton_Click(object sender, EventArgs e)
        {
            SetText(" ");
        }

        private void CBookingInfoForm_Load(object sender, EventArgs e)
        {
            m_phoneNumber = RMSGlobal.m_phoneNumber;

            DateTimeLabel.Text = tempCurrentDate.ToLongDateString();
            if (m_sOpType.Equals("Update") && m_oBooking != null)
            {
                DateTimeLabel.Text = (new DateTime(m_oBooking.BookingTime)).ToString();

                if (m_oBooking.BookingType.Equals("Provisional")) ProvisionalRadioButton.Checked = true;
                else if (m_oBooking.BookingType.Equals("Confirmed")) ConfirmRadioButton.Checked = true;
                else if (m_oBooking.BookingType.Equals("CallBack")) CallBackRadioButton.Checked = true;
                else if (m_oBooking.BookingType.Equals("Finished")) FinishRadioButton.Checked = true;             
                else ;

                string phone = m_oBooking.Phone;
                ClearTextBoxes();
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(phone);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                }

                txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                txtPhoneNumber.Enabled = false;
                NameTextBox.Text = tempCustomerInfo.CustomerName;
                txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;
                txtHouseNumber.Text = tempCustomerInfo.HouseNumber;
                txtBuildingName.Text = tempCustomerInfo.BuildingName;

                    txtStreetName.Text = tempCustomerInfo.StreetName.ToString();
               

                txtTown.Text = tempCustomerInfo.CustomerTown;

                if (tempCustomerInfo.CustomerCountry.Length > 0)
                {
                    cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                }
                else
                {
                    cmbCountry.Text = "United Kingdom (London) (EU)";
                }
                txtTown.Text = tempCustomerInfo.CustomerTown;

                CommentTextBox.Text = m_oBooking.Comments;
                NoofGuestTextBox.Text = m_oBooking.GuestCount.ToString();
                PhoneSearchButton.Visible = false;
            }
                       
            txtPhoneNumber.Select();
            tmrCallerInfo.Start();
            m_cCurrentControl = txtPhoneNumber;
        }

     
        private void myCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
            DateTimeLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void myCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;            
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
            DateTimeLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void PhoneSearchButton_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Equals(""))
            {
                return;
            }

            try
            {
                string phone = txtPhoneNumber.Text.Trim();
                //ClearTextBoxes();
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(phone);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                }
                if (tempCustomerInfo.CustomerName.Length > 0)
                {
                    if (tempCustomerInfo.CustomerPhone.Length > 0)
                    {
                        txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                    }
                    NameTextBox.Text = tempCustomerInfo.CustomerName;
                    txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                    txtHouseNumber.Text = tempCustomerInfo.HouseNumber;
                    txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;
                    txtBuildingName.Text = tempCustomerInfo.BuildingName;
                    txtTown.Text = tempCustomerInfo.CustomerTown;
                    txtStreetName.Text = tempCustomerInfo.StreetName;
                       

                    txtTown.Text = tempCustomerInfo.CustomerTown;

                    if (tempCustomerInfo.CustomerCountry.Length > 0)
                    {
                        cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                    }
                }
                else
                {
                    MessageBox.Show("No customer has been found.", RMSGlobal.MessageBoxTitle,
                               MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            catch (Exception eee)
            {
            }
        }

       

        /// <summary>
        /// Added by Baruri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoofGuestTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tmrCallerInfo_Tick(object sender, EventArgs e)
        {
            if ((RMSGlobal.m_phoneNumber.Replace(" ", "").ToUpper() == "There is no call".Replace(" ", "").ToUpper()) || (RMSGlobal.m_phoneNumber==String.Empty)) //If there is no call
            {
                lblPhoneNumber.Text = RMSGlobal.m_phoneNumber;
                lblCustomer.Text = RMSGlobal.m_CallerName;
                btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
            }
            else if (RMSGlobal.m_isCallAccepted==true)
            {
                lblPhoneNumber.Text = RMSGlobal.m_phoneNumber;
                lblCustomer.Text = RMSGlobal.m_CallerName;
                btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
            }
            else
            {
                btnAccept.Image = global::RMS.Properties.Resources.ring;
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(RMSGlobal.m_phoneNumber.Replace("-",""));//Collect the customer information

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    if (tempCustomerInfo.CustomerName.Length > 0)
                    {
                        lblCustomer.Text = tempCustomerInfo.CustomerName;
                        lblPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                        RMSGlobal.m_CallerAddress = tempCustomerInfo.StreetName.Replace("-", "");
                    }
                    else
                    {
                        lblCustomer.Text = "Unknow Customer";
                        lblPhoneNumber.Text = RMSGlobal.m_phoneNumber.Replace("-", "");
                        RMSGlobal.m_CallerAddress = "Unknown Area";
                    }
                    RMSGlobal.m_CallerName = lblCustomer.Text;
                }
            }
        }

        private void btnFindAddress_Click(object sender, EventArgs e)
        {
            try
            {
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                //CResult oResult = tempCustomerManager.GetCustomerAddressDetailsInfo(txtHouseNumber.Text, txtPostalCode.Text);
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
                        txtStreetName.Text = objCustomer.StreenName.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No address has been found.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPhoneNumber.Text.Replace(" ", "").ToUpper() != "There is no Call".Replace(" ", "").ToUpper() && (RMSGlobal.m_isCallAccepted == false)) //If call is in progress
                {
                    txtPhoneNumber.Text = lblPhoneNumber.Text.Replace(" ", "").ToUpper();
                    PhoneSearchButton_Click(sender, e);
                    lblPhoneNumber.Text = txtPhoneNumber.Text;
                    txtPhoneNumber.Text = lblPhoneNumber.Text.Replace(" ", "").ToUpper();
                    if (NameTextBox.Text.Length < 1)
                    {
                        lblCustomer.Text = "Unknown Customer";
                    }
                    else
                    {
                        lblCustomer.Text = NameTextBox.Text;
                    }
                    btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
                    RMSGlobal.m_isCallAccepted = true;
                    RMSGlobal.m_CallerName = lblCustomer.Text;
                    RMSGlobal.m_CallerAddress = txtStreetName.Text ;
                }

                if (lblPhoneNumber.Text.Replace(" ", "").ToUpper() != "There is no Call".Replace(" ", "").ToUpper() && (RMSGlobal.m_isCallAccepted == true)) //If call is in progress
                {
                    txtPhoneNumber.Text = lblPhoneNumber.Text.Replace(" ", "").ToUpper();
                    PhoneSearchButton_Click(sender, e);
                    lblPhoneNumber.Text = txtPhoneNumber.Text;
                    txtPhoneNumber.Text = lblPhoneNumber.Text.Replace(" ", "").ToUpper();
                    if (NameTextBox.Text.Length < 1)
                    {
                        lblCustomer.Text = "Unknown Customer";
                    }
                    else
                    {
                        lblCustomer.Text = NameTextBox.Text;
                    }
                    btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
                    RMSGlobal.m_isCallAccepted = true;
                    RMSGlobal.m_CallerName = lblCustomer.Text;
                    RMSGlobal.m_CallerAddress = txtStreetName.Text ;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void bookingInfoKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            m_cCurrentControl.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void Name_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = NameTextBox;
        }

        private void FloorNo_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtFloorAptNumber;
        }

        private void PostalCode_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPostalCode;
        }

        private void Street_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtStreetName;
        }

        private void Town_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTown;
        }

        private void NoGuest_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = NoofGuestTextBox;
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPhoneNumber;
        }

        private void HouseNo_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtHouseNumber;
        }

        private void BuildinNo_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtBuildingName;
        }

        private void Comments_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = CommentTextBox;
        }
    }        
}