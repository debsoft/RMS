using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.User;
using RMS.Main;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.Customer;
using Managers.TableInfo;
using RMS.TableOrder;
using System.Collections;
using System.Xml;
using System.IO;
using RMSClient.DataAccess;
using RMSUI;

namespace RMS.TakeAway
{
    public partial class CTakeAwayForm : BaseForm
    {
        #region "Declaration Area"

        private Point m_pCursorPosition;
        private int m_iSelectionIndex = 0;
        private TextBox m_cCurrentControl;
        private CCommonConstants m_oCommonConstants;
        private bool UpperCase=false;
        private Int64 m_iOrderID = 0;
        public static Hashtable m_htOrderInfo=new Hashtable();
        public string m_phoneNumber = String.Empty;
        public static bool m_tobeModifiedCustomer = false;
        private bool m_customerEditStatus = false;
        private string m_deliveryTime = String.Empty;
        private string m_orderType = String.Empty;
        private Int32 m_orderIndex = 0;
        private string m_order_name = String.Empty;
        private List<CUserInfo> userList = new List<CUserInfo>();


        #endregion

        #region "Initialization Area"

        public CTakeAwayForm(Int32 orderIndex)
        {
            InitializeComponent();
            m_cCurrentControl = txtCustomerName;
            m_customerEditStatus = false;
            m_deliveryTime = String.Empty;
            m_orderType = String.Empty;
            m_orderIndex = orderIndex;


            if (orderIndex != 1)
            {
              //  this.ChangeVisibility();
            }
            if (orderIndex == 2 || orderIndex == 3) //If waiting type orders 
            {
                this.GetWaitingNumber();
                txtTips.Visible = true;
            }

            CUserManager tempUserManager = new CUserManager();
            CResult tempResult = tempUserManager.GetAllUser();
            if (tempResult.IsSuccess)
            {
                userList = new List<CUserInfo>();
                userList = (List<CUserInfo>)tempResult.Data;
            }

            ScreenTitle = "Takeaway Customer Information";
            m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            if (m_oCommonConstants.UserInfo == null)
                return;
        }

        public CTakeAwayForm(Int64 inOrderId)
        {
            InitializeComponent();
            ScreenTitle = "Takeaway Customer Information";
            m_cCurrentControl = txtCustomerName;
            m_customerEditStatus = false;
            m_deliveryTime = String.Empty;
            m_orderType = String.Empty;
            m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            if (m_oCommonConstants.UserInfo == null)
                return;
            m_iOrderID = inOrderId;
            CUserManager tempUserManager = new CUserManager();
            CResult tempResult = tempUserManager.GetAllUser();
            if (tempResult.IsSuccess)
            {
                userList = new List<CUserInfo>();
                userList = (List<CUserInfo>)tempResult.Data;
            }
          
           
        }

        public CTakeAwayForm(Int64 inOrderId, CDelivery objDeliveryTime, string orderType, bool editStatus)
        {
            InitializeComponent();
            ScreenTitle = "Takeaway Customer Information";
            m_cCurrentControl = txtCustomerName;
            m_customerEditStatus = editStatus;

            if (objDeliveryTime != null)
            {
                m_deliveryTime = objDeliveryTime.DeliveryTime;
            }
            else
            {
                m_deliveryTime = "Takeaway";
            }

            m_orderType = orderType;

            m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            if (m_oCommonConstants.UserInfo == null)
                return;
            m_iOrderID = inOrderId;
            CUserManager tempUserManager = new CUserManager();
            CResult tempResult = tempUserManager.GetAllUser();
            if (tempResult.IsSuccess)
            {
                userList = new List<CUserInfo>();
                userList = (List<CUserInfo>)tempResult.Data;
            }
        }

        #endregion

        #region "Manupulation Area"

        /// <summary>
        /// If the order is waiting type then collects the waiting number of the order.
        /// For this reason the function collects the maximum waiting number and increases by 1 to return the current id.
        /// </summary>
        /// <returns></returns>
        private void GetWaitingNumber()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime dateOnly = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 0, 0, 0);
            COrderManager tempOrderManager = new COrderManager();
            CResult objWaiting = tempOrderManager.GetWaitingNumber(dateOnly.Ticks,m_orderIndex);
            CTableInfo objTableInfo = (CTableInfo)objWaiting.Data;
            if (m_orderIndex == 3)
            {
                m_order_name = "Waiting" + (objTableInfo.WaitingNumber + 1).ToString("000");
            }
            else if (m_orderIndex == 2)
            {
                m_order_name = "Collection" + (objTableInfo.WaitingNumber + 1).ToString("000");//Here waiting number is collection number.
            }
        }


        /// <summary>
        /// The following controls are hidden when collection or waiting type orders.
        /// </summary>
        private void ChangeVisibility()
        {
            lblBuildingName.Visible = false;
            lblCountry.Visible = false;
            lblDelTime.Visible = false;
            lblFlatApt.Visible = false;
            lblHour.Visible = false;
            lblHouseNumber.Visible = false;
            lblMeridien.Visible = false;
            lblMinutes.Visible = false;
            lblPostCode.Visible = false;
            lblStreetName.Visible = false;
            lblTown.Visible = false;

            txtBuildingName.Visible = false;
            txtFloorAptNumber.Visible = false;
            txtHouseNumber.Visible = false;
            txtPostalCode.Visible = false;
            txtStreet2.Visible = false;
            txtStreetName.Visible = false;
            txtTown.Visible = false;
            cmbCountry.Visible = false;
            cmbHour.Visible = false;
            cmbMeridiem.Visible = false;
            cmbMinute.Visible = false;

            lblMandatoryPostalCode.Visible = false;
            lblMandatoryTown.Visible = false;
            //takeawaykeyBoard.Left = 12;
            //takeawaykeyBoard.Top = 121;
        }


        private void ClearTextBoxes()
        {
            txtCustomerName.Clear();
            txtPostalCode.Clear();
            txtStreetName.Clear();
            txtStreetName.Clear();
            txtTown.Clear();
            cmbCountry.SelectedIndex=-1;
        }

        private bool CheckEmpty()
        {
            //if (txtHouseNumber.Text.Equals(""))
            //{
            //    return false;
            //}

            //if (txtPostalCode.Text.Equals(""))
            //{
            //    return false;
            //}
            //if (txtTown.Text.Equals(""))
            //    return false;

            //if (txtStreetName.Text.Equals("") && txtStreet2.Text.Equals(""))
            //    return false;

            //if (txtCustomerName.Text.Equals(""))
            //    return false;

            //if (cmbCountry.SelectedIndex < 0)
            //    return false;



            if (txtPhoneNumber.Text.Equals("") && txtStreet2.Text.Equals(""))
                return false;

            if (txtCustomerName.Text.Equals(""))
                return false;

            return true;
        }
        private int GetValidTableNumber(string TableType)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                List<int> tempTableNumberList = (List<int>)tempOrderManager.GetTableNumberList(TableType).Data;

                for (int rowIndex = 0; rowIndex < tempTableNumberList.Count; rowIndex++)
                {
                    if (tempTableNumberList[rowIndex] != (rowIndex + 1))
                    {
                        return (rowIndex + 1);
                    }
                    if ((rowIndex + 1) == tempTableNumberList.Count)
                        return tempTableNumberList[rowIndex] + 1;
                }
            }
            catch (Exception eee)
            {
            }
            return 1;
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

        #endregion

        #region "UI Events"

        private void CancelButton_Click(object sender, EventArgs e)
        {
            m_phoneNumber = String.Empty;
            Form tempMainForm = CFormManager.Forms.Pop();
            tempMainForm.Show();
            m_phoneNumber = null;
            this.Close();
        }
        private void TextBox_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPhoneNumber;
            keyboard1.ControlToInputText = txtCustomerName;
            m_cCurrentControl = (TextBox)sender;
            m_pCursorPosition = Cursor.Current.HotSpot;
            m_iSelectionIndex = m_cCurrentControl.SelectionStart;
        }
        private void FinishButton_Click(object sender, EventArgs e)
        {
            CResult objResultant = new CResult();
            try
            {
                if (!CheckEmpty() && m_orderIndex == 1)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Please enter all the mandatory values.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                if (txtPhoneNumber.Text.Trim().Equals(String.Empty))
                {
                    CResult oResult5 = tempCustomerManager.CustomerInfoGetByName(txtCustomerName.Text.Trim());
                    if (oResult5.IsSuccess && oResult5.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult5.Data;
                    }
                }

                else
                {
                    CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(txtPhoneNumber.Text.Trim());
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }
                }

                if (txtCustomerName.Text.Length == 0 && (m_orderIndex == 2 || m_orderIndex == 3)) 
                {
                    txtCustomerName.Text = m_order_name;
                }

                tempCustomerInfo.CustomerName = txtCustomerName.Text.Trim();
                tempCustomerInfo.CustomerPhone = txtPhoneNumber.Text.Trim();

                if (m_orderIndex == 1) //If only delivery type order is considered
                {
                    tempCustomerInfo.CustomerPostalCode = txtPostalCode.Text.Trim();

                    tempCustomerInfo.FloorAptNumber = txtFloorAptNumber.Text.Trim();
                    tempCustomerInfo.HouseNumber = txtHouseNumber.Text.Trim();
                    tempCustomerInfo.StreetName = txtStreetName.Text.Trim() + "-" + txtStreet2.Text.Trim();
                    tempCustomerInfo.BuildingName = txtBuildingName.Text.Trim();

                    tempCustomerInfo.CustomerTown = txtTown.Text.Trim();
                    tempCustomerInfo.CustomerCountry = cmbCountry.Text;
                    tempCustomerInfo.UserName = RMSGlobal.LoginUserName;
                    tempCustomerInfo.TerminalId = RMSGlobal.Terminal_Id;
                    Int64 currentdateTime = DateTime.Now.Ticks;
                    tempCustomerInfo.InsertDate = currentdateTime;
                }

                if (tempCustomerInfo.CustomerID == 0)
                {
                        CResult oResult6 = tempCustomerManager.InsertCustomerInfo(tempCustomerInfo);
                        if (oResult6.IsSuccess && oResult6.Data != null)
                            tempCustomerInfo = (CCustomerInfo)oResult6.Data;
                }
                else
                {
                        tempCustomerManager.UpdateCustomerInfo(tempCustomerInfo);
                }

                #region "Older"

                if (m_customerEditStatus == false)
                {
                    if (m_iOrderID == 0)
                    {
                        COrderManager tempOrderManager = new COrderManager();
                        COrderInfo tempOrderInfo = new COrderInfo();
                        tempOrderInfo.CustomerID = tempCustomerInfo.CustomerID;
                        tempOrderInfo.OrderType = "TakeAway";
                        tempOrderInfo.OrderTime = System.DateTime.Now;
                        tempOrderInfo.TableNumber = GetValidTableNumber("TakeAway");
                        CTableInfo tempTableInfo = new CTableInfo();
                        tempTableInfo.TableNumber = tempOrderInfo.TableNumber;
                        tempTableInfo.TableType = "TakeAway";
                        tempOrderManager.InsertTableInfo(tempTableInfo);

                        if (m_orderIndex==1)
                        {
                            tempOrderInfo.Status = "Delivery";
                        }
                        else if (m_orderIndex ==2 )
                        {
                            tempOrderInfo.Status = "Collection";
                        }
                        else if (m_orderIndex == 3)
                        {
                            tempOrderInfo.Status = "Waiting";
                        }

                        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                        tempOrderInfo.UserID = m_oCommonConstants.UserInfo.UserID;

                        objResultant = tempOrderManager.InsertOrderInfo(tempOrderInfo); //New Order
                        COrderInfo tempOrderInfoNew = (COrderInfo)objResultant.Data;//Taking the order ID
                        m_iOrderID = tempOrderInfoNew.OrderID;

                        #region " Inserting Order details info if items are selected from the previous orders"
                        //Developed by baruri
                        List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                        if (m_htOrderInfo.Count > 0) //If item is selected from the previous order
                        {
                            tempOrderDetailsList = (List<COrderDetails>)m_htOrderInfo["orderdetail"];
                        }
                        if (tempOrderDetailsList.Count > 0) //Insert details for the new order
                        {
                            for (int itemDetailIndex = 0; itemDetailIndex < tempOrderDetailsList.Count; itemDetailIndex++)
                            {
                                COrderDetails objOrderDetails = (COrderDetails)tempOrderDetailsList[itemDetailIndex];
                                objOrderDetails.OrderID = tempOrderInfo.OrderID;
                                tempOrderManager.InsertOrderDetails(objOrderDetails);
                            }
                            m_htOrderInfo = new Hashtable();//Clearing the previous items from the order if there is any.
                        }
                        #endregion

                        //insert delivery time
                        if (tempOrderInfo.Status.Equals("Delivery"))
                        {
                            CDelivery tempDelivery = new CDelivery();
                            tempDelivery.DeliveryOrderID = tempOrderInfo.OrderID;
                            string deliveryTime = Convert.ToInt32("0" + cmbHour.Text).ToString("00") + ":" + Convert.ToInt32("0" + cmbMinute.Text).ToString("00") + " " + cmbMeridiem.Text;
                            tempDelivery.DeliveryTime = deliveryTime;// DeliveryTimeTextBox.Text.Trim();
                            tempOrderManager.InsertDeliveryInfo(tempDelivery);
                        }

                        //OLD Code
                        //Form tempForm = CFormManager.Forms.Pop();
                        //tempForm.Show();

                        try
                        {
                            WaiterForm waiterForm = new WaiterForm();
                            waiterForm.UserList = userList;
                            waiterForm.ShowDialog();

                            if (waiterForm.DialogResult == DialogResult.OK)
                            {
                                COrderWaiterDao orderwaiterDao = new COrderWaiterDao();
                                COrderwaiter orderwaiter = new COrderwaiter();

                                orderwaiter = orderwaiterDao.GetOrderwaiterByOrderID(tempOrderInfo.OrderID);
                                if (orderwaiter != null && orderwaiter.ID > 0 && orderwaiter.WaiterID != waiterForm.UserInfoData.UserID)
                                {
                                    orderwaiter.OrderID = tempOrderInfo.OrderID;
                                    orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                    orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                    orderwaiterDao.UpdateOrderwaiter(orderwaiter);
                                }
                                else if (orderwaiter.ID == 0)
                                {
                                    orderwaiter.OrderID = tempOrderInfo.OrderID;
                                    orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                    orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                    orderwaiterDao.InsertOrderwaiter(orderwaiter);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }





                        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                        CTableOrderForm tempForm = new CTableOrderForm(m_iOrderID, m_oCommonConstants.TakeAwayType, tempOrderInfo.TableNumber);
                        tempForm.m_orderUserName = RMSGlobal.LoginUserName;
                        tempForm.Show();

                        this.Close();
                    }
                    else
                    {
                        COrderManager tempOrderManager = new COrderManager();
                        CResult oResult7 = tempOrderManager.OrderInfoByOrderID(m_iOrderID);
                        COrderInfo tempOrderInfo = new COrderInfo();
                        if (oResult7.IsSuccess && oResult7.Data != null)
                        {
                            tempOrderInfo = (COrderInfo)oResult7.Data;
                        }

                        tempOrderInfo.OrderType = "TakeAway";
                        tempOrderInfo.Status = "TakeAway";
                        tempOrderInfo.GuestCount = 0;
                        tempOrderInfo.TableName = "";
                        tempOrderInfo.CustomerID = tempCustomerInfo.CustomerID;
                        tempOrderInfo.TableNumber = GetValidTableNumber("TakeAway");

                        CTableInfo tempTableInfo = new CTableInfo();
                        tempTableInfo.TableNumber = tempOrderInfo.TableNumber;
                        tempTableInfo.TableType = "TakeAway";
                        tempOrderManager.InsertTableInfo(tempTableInfo);

                        if (m_orderIndex == 1)
                        {
                            tempOrderInfo.Status = "Delivery";
                        }
                        else if (m_orderIndex == 3)
                        {
                            tempOrderInfo.Status = "Waiting";
                        }
                        else if (m_orderIndex == 2)
                        {
                            tempOrderInfo.Status = "Collection";
                        }
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                        //insert delivery time
                        if (tempOrderInfo.Status.Equals("Delivery"))
                        {
                            CDelivery tempDelivery = new CDelivery();
                            tempDelivery.DeliveryOrderID = tempOrderInfo.OrderID;
                            string deliveryTime = Convert.ToInt32("0" + cmbHour.Text).ToString("00") + ":" + Convert.ToInt32("0" + cmbMinute.Text).ToString("00") + " " + cmbMeridiem.Text;
                            tempDelivery.DeliveryTime = deliveryTime;// DeliveryTimeTextBox.Text.Trim();
                            tempOrderManager.InsertDeliveryInfo(tempDelivery);
                        }

                        try
                        {
                            WaiterForm waiterForm = new WaiterForm();
                            waiterForm.UserList = userList;
                            waiterForm.ShowDialog();

                            if (waiterForm.DialogResult == DialogResult.OK)
                            {
                                COrderWaiterDao orderwaiterDao = new COrderWaiterDao();
                                COrderwaiter orderwaiter = new COrderwaiter();

                                orderwaiter = orderwaiterDao.GetOrderwaiterByOrderID(tempOrderInfo.OrderID);
                                if (orderwaiter != null && orderwaiter.ID > 0 && orderwaiter.WaiterID != waiterForm.UserInfoData.UserID)
                                {
                                    orderwaiter.OrderID = tempOrderInfo.OrderID;
                                    orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                    orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                    orderwaiterDao.UpdateOrderwaiter(orderwaiter);
                                }
                                else if (orderwaiter.ID == 0)
                                {
                                    orderwaiter.OrderID = tempOrderInfo.OrderID;
                                    orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                    orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                    orderwaiterDao.InsertOrderwaiter(orderwaiter);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }




                        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                        CTableOrderForm tempForm = (CTableOrderForm)CFormManager.Forms.Pop();
                        tempForm.m_iType = m_oCommonConstants.TakeAwayType;
                        tempForm.Show();
                        this.Close();
                    }
                }
                #endregion
                else //Edit order information.As here is reached from order details screen.
                {
                    COrderInfo tempOrderInfo = new COrderInfo();
                    COrderManager tempOrderManager = new COrderManager();
                    CDelivery tempDelivery = null;

                    tempOrderInfo.OrderID = m_iOrderID;
                    tempOrderManager.DeleteDeliveryInfo(m_iOrderID);//Delete previous record from delivery information table

                    if (m_orderIndex==2)
                    {
                        tempOrderInfo.Status = "Collection";
                    }
                    else if (m_orderIndex==3)
                    {
                        tempOrderInfo.Status = "Waiting";
                    }
                    else
                    {
                        tempOrderInfo.Status = "Delivery";
                        tempDelivery = new CDelivery();
                        tempDelivery.DeliveryOrderID = tempOrderInfo.OrderID;
                        string deliveryTime = Convert.ToInt32("0" + cmbHour.Text).ToString("00") + ":" + Convert.ToInt32("0" + cmbMinute.Text).ToString("00") + " " + cmbMeridiem.Text;
                        tempDelivery.DeliveryTime = deliveryTime;// 
                        tempOrderManager.InsertDeliveryInfo(tempDelivery);//Update delivery information
                    }

                    tempOrderManager.UpdateTakeawayOrderInfo(tempOrderInfo);//Update order information


                    try
                    {
                        WaiterForm waiterForm = new WaiterForm();
                        waiterForm.UserList = userList;
                        waiterForm.ShowDialog();

                        if (waiterForm.DialogResult == DialogResult.OK)
                        {
                            COrderWaiterDao orderwaiterDao = new COrderWaiterDao();
                            COrderwaiter orderwaiter = new COrderwaiter();

                            orderwaiter = orderwaiterDao.GetOrderwaiterByOrderID(tempOrderInfo.OrderID);
                            if (orderwaiter != null && orderwaiter.ID > 0 && orderwaiter.WaiterID != waiterForm.UserInfoData.UserID)
                            {
                                orderwaiter.OrderID = tempOrderInfo.OrderID;
                                orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                orderwaiterDao.UpdateOrderwaiter(orderwaiter);
                            }
                            else if (orderwaiter.ID == 0)
                            {
                                orderwaiter.OrderID = tempOrderInfo.OrderID;
                                orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                                orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                                orderwaiterDao.InsertOrderwaiter(orderwaiter);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                    CTableOrderForm tempForm = (CTableOrderForm)CFormManager.Forms.Pop();
                    tempForm.m_iType = m_oCommonConstants.TakeAwayType;
                    tempForm.Show();
                    this.Close();
                }
                m_phoneNumber = String.Empty;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
       
     
        /// <summary>
        /// Collecting the recent orders of the selected customer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentOrderButton_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Equals("")) //If phone number of the customer is not entered.
            {
                return;
            }
            try
            {
                string phone = txtPhoneNumber.Text.Trim();
                this.ClearTextBoxes();
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

                txtStreetName.Text = tempCustomerInfo.StreetName;
                txtTown.Text = tempCustomerInfo.CustomerTown;
                if (tempCustomerInfo.CustomerCountry.Length > 0)
                {
                    cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                }
                else
                {
                    cmbCountry.Text = "United Kingdom (London) (EU)";
                }

                CRecentOrderForm tempOrderForm = new CRecentOrderForm(tempCustomerInfo.CustomerID, tempCustomerInfo.CustomerName, tempCustomerInfo.CustomerPhone, tempCustomerInfo.CustomerAddress);
                tempOrderForm.ShowDialog();
                m_htOrderInfo = CRecentOrderForm.m_htPreviousOrders; //Order details information from pervious order developed by baruri at10.09.2008
                COrderInfoArchive tempOrderInfo = (COrderInfoArchive)m_htOrderInfo["orderinfo"]; //For detecting the order type

                //if (tempOrderInfo.OrderType.ToString().ToUpper().Trim() == "TakeAway".ToString().ToUpper().Trim())
                //{
                //    TakeAwayRadioButton.Checked = true;
                //}
                if (m_htOrderInfo.Count > 0)
                {
                    FinishButton_Click(sender, e);
                }
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
                btnSearchByPhone_Click(sender, e);
            }
        }

        /// <summary>
        /// Modified by Baruri at 23.12.2008
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CTakeAwayForm_Activated(object sender, EventArgs e)
        {
            CCustomerManager tempCustomerManager = new CCustomerManager();
            if (m_customerEditStatus == false)
            {
                CResult oResult = tempCustomerManager.CollectConfiguredTime();//Collect the configured time
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                tempCustomerInfo = (CCustomerInfo)oResult.Data;
                Int32 configuredTime = tempCustomerInfo.ConfiguredTime;

                cmbCountry.Text = "United Kingdom (London) (EU)";
                DateTime dtCurent = DateTime.Now;
                DateTime dtDelivery = dtCurent.AddMinutes(configuredTime);//As within 30-40 minutes order will be completed or completed.

                int hour = dtDelivery.Hour;
                int minute = dtDelivery.Minute;
                string meridiem = dtDelivery.ToString("tt");
                if (hour > 12) //If hour value is greater than 12 pm then go to 12 hr format clock settings
                {
                    hour = hour - 12;
                }
                cmbHour.Text = hour.ToString();
                cmbMinute.Text = minute.ToString();
                cmbMeridiem.Text = meridiem;

                //Showing the current city
                XmlDocument xmlDoc = new XmlDocument();
                string cityName = String.Empty;
                string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                FileInfo executableFileInfo = new FileInfo(executableName);
                string currentDirectory = executableFileInfo.DirectoryName + "\\Config";
                xmlDoc.Load(currentDirectory + "\\CommonConstants.xml");
                XmlNode appSettingsNode =
                xmlDoc.SelectSingleNode("CCommonConstants/cityname");
                cityName = appSettingsNode.InnerText;
                txtTown.Text = cityName;

                if (CustomerListForm.m_phoneNumber.Length > 0)
                {
                    txtPhoneNumber.Text = CustomerListForm.m_phoneNumber;
                    btnSearchByPhone_Click(sender, e);
                }
            }
            else
            {
               //For modifying customer from order details form. 
                CResult oResult = tempCustomerManager.GetCustomerTakeawayInfo(m_iOrderID);
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                tempCustomerInfo = (CCustomerInfo)oResult.Data;
                txtCustomerName.Text = tempCustomerInfo.CustomerName;
                txtBuildingName.Text = tempCustomerInfo.BuildingName;
                txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;
                txtHouseNumber.Text = tempCustomerInfo.HouseNumber;
                txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                txtTown.Text = tempCustomerInfo.CustomerTown;

                string[] street = new string[0];
                street = tempCustomerInfo.StreetName.Split('-');

                if (street.Length > 1)
                {
                    txtStreetName.Text = street[0].ToString();
                    txtStreet2.Text = street[1].ToString();
                }
                else if (street.Length > 0 && street.Length < 2)
                {
                    txtStreetName.Text = street[0].ToString();
                }
                cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                if (m_deliveryTime.Replace(" ", "").ToUpper() != "TakeAway".Replace(" ", "").ToUpper())
                {
                    string[] delTime = m_deliveryTime.Split(':');
                    Int32 hourValue = Convert.ToInt32("0"+delTime[0].ToString());
                    cmbHour.Text = hourValue.ToString();
                    string[] minutes = delTime[1].Split(' ');
                    cmbMinute.Text =Convert.ToInt32(minutes[0]).ToString();
                    cmbMeridiem.Text = minutes[1].ToString();
                    //DeliveryRadioBtton.Checked = true;
                }
                else
                {
                    CResult oResult2 = tempCustomerManager.CollectConfiguredTime();//Collect the configured time
                    tempCustomerInfo = new CCustomerInfo();
                    tempCustomerInfo = (CCustomerInfo)oResult2.Data;
                    Int32 configuredTime = tempCustomerInfo.ConfiguredTime;
                     DateTime dtCurent = DateTime.Now;
                    DateTime dtDelivery = dtCurent.AddMinutes(configuredTime);//As within 30-40 minutes order will be completed or completed.

                    int hour = dtDelivery.Hour;
                    int minute = dtDelivery.Minute;
                    string meridiem = dtDelivery.ToString("tt");
                    if (hour > 12) //If hour value is greater than 12 pm then go to 12 hr format clock settings
                    {
                        hour = hour - 12;
                    }
                    cmbHour.Text = hour.ToString();
                    cmbMinute.Text = minute.ToString();
                    cmbMeridiem.Text = meridiem;
                    //TakeAwayRadioButton.Checked = true;
                }
            }
            txtPhoneNumber.Select();
            m_cCurrentControl = txtPhoneNumber;
            tmrCallerInfo.Start();
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
                    string addressKey = AddressInFoForm.m_addressKey.ToUpper().Replace(" ","");
                    clsCustomerInfo objCustomer = (clsCustomerInfo)slAddressInfo[addressKey];
                    txtHouseNumber.Text = objCustomer.HouseNumber;
                    txtBuildingName.Text = objCustomer.buildingName;
                    txtTown.Text = objCustomer.Town;
                    txtFloorAptNumber.Text = objCustomer.ApartmentNumber;

                    string[] street = new string[0];
                    street = objCustomer.StreenName.Split('-');

                    if (street.Length > 1)
                    {
                        txtStreetName.Text = street[0].ToString();
                        txtStreet2.Text = street[1].ToString();
                    }
                    else if (street.Length > 0 && street.Length < 2)
                    {
                        txtStreetName.Text = street[0].ToString();
                    }
                }
                else if (slAddressInfo.Count == 1)
                {
                    foreach (clsCustomerInfo objCustomer in slAddressInfo.Values)
                    {
                        txtHouseNumber.Text = objCustomer.HouseNumber;
                        txtBuildingName.Text = objCustomer.buildingName;
                        txtTown.Text = objCustomer.Town;

                        string[] street = new string[0];
                        street = objCustomer.StreenName.Split('-');

                        if (street.Length > 1)
                        {
                            txtStreetName.Text = street[0].ToString();
                            txtStreet2.Text = street[1].ToString();
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            txtStreetName.Text = street[0].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No address has been found.",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
       
        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            txtPostalCode.Text=txtPostalCode.Text.ToUpper();
        }

        #endregion

        private void btnSearchByPhone_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Equals("")) //If phone number is blank then return.
            {
                return;
            }
            try
            {
                string phone = txtPhoneNumber.Text.Trim();
                this.ClearTextBoxes();
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(phone);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                }

                if (tempCustomerInfo.CustomerPhone.Length > 0)
                {
                    txtPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                }
                txtCustomerName.Text = tempCustomerInfo.CustomerName;
                txtPostalCode.Text = tempCustomerInfo.CustomerPostalCode;
                txtBuildingName.Text = tempCustomerInfo.BuildingName;
                txtFloorAptNumber.Text = tempCustomerInfo.FloorAptNumber;
                txtHouseNumber.Text = tempCustomerInfo.HouseNumber;
                string[] street=new string[0];
                street=tempCustomerInfo.StreetName.Split('-');

                if (street.Length > 1)
                {
                    txtStreetName.Text = street[0].ToString();
                    txtStreet2.Text = street[1].ToString();
                }
                else if (street.Length > 0 && street.Length < 2)
                {
                    txtStreetName.Text = street[0].ToString();
                }

                txtTown.Text = tempCustomerInfo.CustomerTown;

                if (tempCustomerInfo.CustomerCountry.Length > 0)
                {
                    cmbCountry.Text = tempCustomerInfo.CustomerCountry;
                }
                else
                {
                    cmbCountry.Text = "United Kingdom (London) (EU)";
                }

                if (txtCustomerName.Text == String.Empty || txtCustomerName.Text == null)
                {
                    MessageBox.Show("No customer has been found", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                MessageBox.Show("No customer has been found",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (txtCustomerName.Text == String.Empty || txtCustomerName.Text == null)
            {
                return;
            }

            if (e.KeyChar == 13) //If enter button is pressed
            {
                btnFindCustomer_Click(sender, e);
            }
        }

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void tmrCallerInfo_Tick(object sender, EventArgs e)
        {
            if ((RMSGlobal.m_phoneNumber.Replace(" ", "").ToUpper() == "There is no call".Replace(" ", "").ToUpper()) || (RMSGlobal.m_phoneNumber==String.Empty))
            {
                lblPhone.Text = RMSGlobal.m_phoneNumber;
                lblCustomerName.Text = RMSGlobal.m_CallerName;
                btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
            }

            else if (RMSGlobal.m_isCallAccepted==true)
            {
                lblPhone.Text = RMSGlobal.m_phoneNumber;
                lblCustomerName.Text = RMSGlobal.m_CallerName;
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
                        lblCustomerName.Text = tempCustomerInfo.CustomerName;
                        lblPhone.Text = tempCustomerInfo.CustomerPhone;
                        RMSGlobal.m_CallerAddress = tempCustomerInfo.StreetName.Replace("-","");
                    }
                    else
                    {
                        lblCustomerName.Text = "Unknow Customer";
                        lblPhone.Text = RMSGlobal.m_phoneNumber.Replace("-", "");
                        RMSGlobal.m_CallerAddress = "OUT OF AREA";
                    }
                    RMSGlobal.m_CallerName = lblCustomerName.Text;
                }
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
             try
                {
                    if ((lblPhone.Text.Replace(" ", "").ToUpper() != "There is no call".Replace(" ", "").ToUpper()) && (RMSGlobal.m_isCallAccepted == false)) //If call is in progress
                    {
                        txtPhoneNumber.Text = lblPhone.Text.Replace(" ", "");
                        btnSearchByPhone_Click(sender, e);
                        lblPhone.Text = txtPhoneNumber.Text;
                        if (txtCustomerName.Text.Length < 1)
                        {
                            lblCustomerName.Text = "Unknown Customer";
                        }
                        else
                        {
                            lblCustomerName.Text = txtCustomerName.Text;
                        }
                        RMSGlobal.m_isCallAccepted = true;
                        btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
                        RMSGlobal.m_CallerName = lblCustomerName.Text;
                        RMSGlobal.m_CallerAddress = txtStreetName.Text + " " + txtStreet2.Text;
                        }
                    else if ((lblPhone.Text.Replace(" ", "").ToUpper() != "There is no call".Replace(" ", "").ToUpper()) && (RMSGlobal.m_isCallAccepted == true)) //If call is in progress
                    {
                        txtPhoneNumber.Text = lblPhone.Text.Replace(" ", "");
                        btnSearchByPhone_Click(sender, e);
                        lblPhone.Text = txtPhoneNumber.Text;
                        if (txtCustomerName.Text.Length < 1)
                        {
                            lblCustomerName.Text = "Unknown Customer";
                        }
                        else
                        {
                            lblCustomerName.Text = txtCustomerName.Text;
                        }
                        RMSGlobal.m_isCallAccepted = true;
                        btnAccept.Image = global::RMS.Properties.Resources.ring_stop;
                        RMSGlobal.m_CallerName = lblCustomerName.Text;
                        RMSGlobal.m_CallerAddress = txtStreetName.Text + " " + txtStreet2.Text;
                    }
            }
             catch (Exception exp)
             {
                 throw exp;
             }
        }

        private void takeawaykeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            m_cCurrentControl.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

       
        
        private void OneButton_Click(object sender, EventArgs e)
        {
            SetText("1");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            SetText("2");
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            SetText("0");
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            m_cCurrentControl.Clear();
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            SetText("3");
        }

        private void TextBox_Click_txtPhoneNumber(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPhoneNumber;
        }

        private void TextBox_Click_txtFloorAptNumber(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtFloorAptNumber;
        }

        private void TextBox_Click_txtBuildingName(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtBuildingName;
        }

        private void TextBox_Click_txtHouseNumber(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtHouseNumber;
        }

        private void TextBox_Click_txtStreetName(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtStreetName;
        }

        private void TextBox_Click_txtStreet2(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtStreet2;
        }

        private void TextBox_Click_txtPostalCode(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtPostalCode;
        }

        private void TextBox_Click_txtTown(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = txtTown;
        }

        

        

       

       /* private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyboard1.ControlToInputText = txtCustomerName;
            if (txtCustomerName.Text == String.Empty || txtCustomerName.Text == null)
            {
                return;
            }

            if (e.KeyChar == 13) //If enter button is pressed
            {
                btnFindCustomer_Click(sender, e);
            }
        }*/
      

        

        
    }
}