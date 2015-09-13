using System;
using System.Collections.Generic;
/*
 * File name: CMain.cs 
 * Author: Md. Nazmus Sakib
 *   
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 *                     1/4/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Managers.User;
using RMS.Common;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using RMS.TableOrder;
using RMS.BarService;
using RMS.TakeAway;
using RMS.Login;
using RMS.SystemManagement;
using Managers.Button;
using RMSClient.DataAccess;
using RmsRemote;
using Managers.Customer;
using System.Net;
using Managers.Payment;
using ns;
using System.Xml;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using RMSUI;

namespace RMS.Main
{
    public partial class CMainForm : BaseForm
    {
        #region "Declaration"

        private List<LobbyItemButton> tableIconList;
        private bool m_bTableInfoClicked;
        private bool m_bNameTableClicked;
        private bool m_bChangeDetailsClicked;
        private CCommonConstants m_oCommonConstants;
        private int m_iPageIndex = 1;
        private int m_iTotalPageCount=1;
        private string[] m_onlineOrders=new  string[0]; //This array is used to keep the track of the online orders.
        //private const int m_page_order_capacity = 21;//15 prevois value

        private const int m_page_order_capacity = 27; // Change by Mithu

        private DataGridView m_dgvFood = null;
        private DataGridView m_dgvBeverage = null;
        private List<byte> PortBuffer = new List<byte>();//For callers id
        public static bool received = false;
         // -- Properties ---------------------------------------------------------

        private List<CUserInfo> userList = new List<CUserInfo>();

        #endregion

        #region "Initialization"

        public CMainForm()
        {
            InitializeComponent();
            this.ScreenTitle = "Restaurant Lobby";
          //  Init();
        }

        private void LoadStatusBar(int openOrders)
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            UserStatusLabel.Text = " Logged in as "+oConstants.UserInfo.UserName+" ";
            OpenOrdersLabel.Text = " "+openOrders + " Open Orders";

            CPcInfoManager tempPcInfoManager = new CPcInfoManager();
            IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
            CResult oResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
            CPcInfo tempPcInfo = new CPcInfo();
            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempPcInfo = (CPcInfo)oResult.Data;
            }
            TerminalIDLabel.Text = " Terminal ID: " + tempPcInfo.Name+" ";
            RMSGlobal.Terminal_Id = tempPcInfo.PcID;
        }

        private void Init()
        {
           
            string onlineOrders = String.Empty;
            try
            {
                m_bTableInfoClicked = false;
                m_bNameTableClicked = false;
                m_bChangeDetailsClicked = false;

                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                if (m_oCommonConstants.UserInfo == null)
                {
                    return;
                }

                UserStatusLabel.Text = "Logged in as " + m_oCommonConstants.UserInfo.UserName;

                tableIconList = new List<LobbyItemButton>();

                COrderManager tempOrderManager = new COrderManager();
                List<COrderShow> tempOrderShowList = (List<COrderShow>)tempOrderManager.OrderListShowByStatus("Paid").Data;

                onlineOrders = String.Empty;

                for (int orderCounter = 0; orderCounter < tempOrderShowList.Count; orderCounter++)
                {
                    LobbyItemButton tableIcon = new LobbyItemButton();
                   // tableIcon.Visible = false;
                    tableIcon.User = tempOrderShowList[orderCounter].UserName;
                    tableIcon.GuestCount = tempOrderShowList[orderCounter].GuestCount.ToString();
                    tableIcon.TableName = tempOrderShowList[orderCounter].TableName;
                    tableIcon.Type = tempOrderShowList[orderCounter].OrderType;
                    tableIcon.FloorName = tempOrderShowList[orderCounter].FloorNo;

                    if (tableIcon.TableName.Equals(""))
                    {
                        if (tableIcon.Type.Equals("Table"))
                            tableIcon.TableName = "Table " + tempOrderShowList[orderCounter].TableNumber.ToString();
                        else if (tableIcon.Type.Equals("Tabs"))
                            tableIcon.TableName = "Tab " + tempOrderShowList[orderCounter].TableNumber.ToString();
                        else if (tableIcon.Type.Equals("TakeAway"))
                        {
                            COrderInfo temp2OrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(tempOrderShowList[orderCounter].OrderID).Data;
                            CCustomerManager tempCustomerManager = new CCustomerManager();
                            CCustomerInfo tempCustomerinfo = new CCustomerInfo();

                            tempCustomerinfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(temp2OrderInfo.CustomerID).Data;
                            
                            if (tempCustomerinfo != null)
                                tableIcon.TableName = tempCustomerinfo.CustomerName;
                            else
                            tableIcon.TableName = "Take Away";
                          //tableIcon.GuestCountLabel.Text = tempOrderShowList[orderCounter].Status;
                            
                            tableIcon.TableName = tempOrderShowList[orderCounter].Status;
                        }
                    }

                    tableIcon.TableNumber = Int64.Parse(tempOrderShowList[orderCounter].TableNumber.ToString());
                    string status = tempOrderShowList[orderCounter].Status;
                    tableIcon.OrderID = tempOrderShowList[orderCounter].OrderID;

                    //Added by Baruri at 13.12.2008.This portion is used for automatic printing of online orders.
                    if (tempOrderShowList[orderCounter].OnlineOrderID >1) //If online order
                    {
                        if (onlineOrders.Length == 0)
                        {
                            onlineOrders = tempOrderShowList[orderCounter].OrderID.ToString();
                        }
                        else
                        {
                            onlineOrders = onlineOrders + "," + tempOrderShowList[orderCounter].OrderID.ToString();
                        }
                    }

                    COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(tableIcon.OrderID).Data;
                    COrderSeatTime tempOrderSeatTime = (COrderSeatTime)tempOrderManager.OrderSeatTimeByOrderID(tableIcon.OrderID).Data;

                    tableIcon.OrderedTime = tempOrderInfo.OrderTime;
                    tableIcon.SeatedTime = tempOrderSeatTime.SeatTime;

                    if (tempOrderShowList[orderCounter].OrderType.Equals("Table"))
                    {
                        if (status.Equals("Seated"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.SeatedButNoOrdered;
                          
                        }
                        else if (status.Equals("Ordered"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.Ordered;
                            //tableIcon.Icon = global::RMS.Properties.Resources.ordered_png;
                        }
                        else if (status.Equals("Billed"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.WaitingForPayment;
                            //tableIcon.Icon = global::RMS.Properties.Resources.awaiting_png;
                        }
                        else if (tempOrderShowList[orderCounter].Status.Equals("DelivaryFromKitchen"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.Delevery;
                            // tableIcon.Icon = global::RMS.Properties.Resources.Delevery_png;
                        }

                        tableIcon.Type = "Table";
                    }
                    
                    else if (tempOrderShowList[orderCounter].OrderType.Equals("TakeAway"))
                    {
                        if (tempOrderShowList[orderCounter].Status.Equals("Collection"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.Collection;
                           // tableIcon.Icon = global::RMS.Properties.Resources.takeaway_png;
                        }
                        else if (tempOrderShowList[orderCounter].Status.Equals("DelivaryFromKitchen"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.Delevery;
                            // tableIcon.Icon = global::RMS.Properties.Resources.Delevery_png;
                        }
                        //else if(tempOrderShowList[orderCounter].Status.Equals("Delivery"))
                        //{
                        //    tableIcon.ItemType = RMSUIConstants.ItemType.Delevery;
                        //   // tableIcon.Icon = global::RMS.Properties.Resources.Delevery_png;
                        //}
                        else if (tempOrderShowList[orderCounter].Status.Equals("Waiting"))
                        {
                            tableIcon.ItemType = RMSUIConstants.ItemType.Waiting;
                        }
                        tableIcon.Type = "TakeAway";
                    }
                    else if (tempOrderShowList[orderCounter].OrderType.Equals("Tabs"))
                    {
                       // tableIcon.i = global::RMS.Properties.Resources.rms_bar_service;
                        tableIcon.ItemType = RMSUIConstants.ItemType.BarService;
                        //tableIcon.Icon = global::RMS.Properties.Resources.tab_png;
                        tableIcon.Type = "Tabs";
                    }

                    tableIcon.Click += new EventHandler(TableIcon_MouseClick);
                    tableIconList.Add(tableIcon);
                }

                this.SortIcons();

                for (int k = ((m_iPageIndex - 1) * m_page_order_capacity); k < tableIconList.Count && k < (m_iPageIndex * m_page_order_capacity); k++)
                    TablePanel.Controls.Add(tableIconList[k]);


                #region "Current Code Modified by Baruri at 30/07/2008"

                if (tableIconList.Count % m_page_order_capacity == 0)
                {
                    m_iTotalPageCount = tableIconList.Count / m_page_order_capacity;
                }
                else
                {
                    m_iTotalPageCount = (tableIconList.Count / m_page_order_capacity) + 1;
                }
                TotalPageLabel.Text = m_iTotalPageCount.ToString();

                #endregion

                if (m_iPageIndex < m_iTotalPageCount)
                    NextButton.Enabled = true;
                else
                    NextButton.Enabled = false;

                if (m_iPageIndex > 1)
                    PreviousButton.Enabled = true;
                else
                    PreviousButton.Enabled = false;

                CurrentPageLabel.Text = m_iPageIndex.ToString();

                String BarServiceColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Bar Service'")[0]["color"].ToString();
                BarServiceButton.BackColor = Color.FromArgb(Int32.Parse(BarServiceColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(BarServiceColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(BarServiceColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

                String TakeAwayColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Take Away'")[0]["color"].ToString();
                TWButton.BackColor = Color.FromArgb(Int32.Parse(TakeAwayColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(TakeAwayColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(TakeAwayColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


                String NewTableColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'New Table'")[0]["color"].ToString();
                NewTableButton.BackColor = Color.FromArgb(Int32.Parse(NewTableColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(NewTableColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                        Int32.Parse(NewTableColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

                LoadStatusBar(tempOrderShowList.Count);
            }
            catch (Exception ee)
            {
            }
            m_onlineOrders = onlineOrders.Split(','); //Online order list .
      
        }

        #endregion

        #region "Manupulation"
       

        /// <summary>
        /// Set the default status of the datagrid view
        /// </summary>
        private void FillRMSDataGridView()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

            int counter = m_dgvFood.RowCount;

            if (counter < oConstants.TableOrderFoodGrid)
            {
                for (int rowIndex = counter; rowIndex < oConstants.TableOrderFoodGrid; rowIndex++)
                {
                    string[] str = { "", "", "", "", "", Int64.MaxValue.ToString(), "" };
                    m_dgvFood.Rows.Add(str);
                }
            }

            counter = m_dgvBeverage.RowCount;

            if (counter < oConstants.TableOrderBeverageGrid)
            {
                for (int rowIndex = counter; rowIndex < oConstants.TableOrderBeverageGrid; rowIndex++)
                {
                    string[] str = { "", "", "", "", "", Int64.MaxValue.ToString(), "" };
                    m_dgvBeverage.Rows.Add(str);
                }
            }
        }

        private void ConvertRank()
        {
            for (int rowCounter = 0; rowCounter <m_dgvFood.RowCount-1; rowCounter++)
            {
                m_dgvFood[5, rowCounter].Value = Convert.ToInt64("0"+m_dgvFood[5, rowCounter].Value.ToString());
            }

            for (int rowCounter = 0; rowCounter < m_dgvBeverage.RowCount-1; rowCounter++)
            {
                m_dgvBeverage[5, rowCounter].Value = Convert.ToInt64("0" + m_dgvBeverage[5, rowCounter].Value.ToString());
            }
        }

        /// <summary>
        /// icon List
        /// </summary>
        public void SortIcons()
        {
            try
            {
                for (int iconCounter = 0; iconCounter < tableIconList.Count; iconCounter++)
                    for (int iconInnerCounter = iconCounter + 1; iconInnerCounter < tableIconList.Count; iconInnerCounter++)
                    {
                        if (!tableIconList[iconCounter].Type.Equals(tableIconList[iconInnerCounter].Type))
                        {
                            if (tableIconList[iconCounter].Type.Equals("TakeAway"))
                            {
                                LobbyItemButton tempTableIcon = new LobbyItemButton();
                                tempTableIcon = tableIconList[iconCounter];
                                tableIconList[iconCounter] = tableIconList[iconInnerCounter];
                                tableIconList[iconInnerCounter] = tempTableIcon;
                            }
                            else if (tableIconList[iconCounter].Type.Equals("Tabs") && !tableIconList[iconInnerCounter].Type.Equals("TakeAway"))
                            {
                                LobbyItemButton tempTableIcon = new LobbyItemButton();
                                tempTableIcon = tableIconList[iconCounter];
                                tableIconList[iconCounter] = tableIconList[iconInnerCounter];
                                tableIconList[iconInnerCounter] = tempTableIcon;
                            }
                            continue;
                        }
                        if (tableIconList[iconCounter].TableNumber > tableIconList[iconInnerCounter].TableNumber)
                        {
                            LobbyItemButton tempTableIcon = new LobbyItemButton();
                            tempTableIcon = tableIconList[iconCounter];
                            tableIconList[iconCounter] = tableIconList[iconInnerCounter];
                            tableIconList[iconInnerCounter] = tempTableIcon;
                        }
                    }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Collecting the online orders and prints automatically
        /// </summary>
        private void PrintOnlineOrders()
        {
            Int64 onlineOrderId = 0;
            for (int orderIndex = 0; orderIndex < m_onlineOrders.Length; orderIndex++)
            {
                onlineOrderId = Convert.ToInt64("0" + m_onlineOrders[orderIndex]);
                COrderManager tempOrderManager = new COrderManager();
                CResult objResult = new CResult();
                objResult= tempOrderManager.GetOnlineOrderPrintStatus(onlineOrderId);
                COrderInfo tempOrderInfo = new COrderInfo();
                tempOrderInfo = (COrderInfo)objResult.Data;
                int printStatus = tempOrderInfo.OnlineOrderPrintStatus;

                if (printStatus < 2) //If not printed then print the online orders
                {
                    List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                    CResult oResult = tempOrderManager.GetOnlineOrderDetailsByOrderID(onlineOrderId);//Collecting the orders details

                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempOrderDetailsList = (List<COrderDetails>)oResult.Data;
                    }
                    if (tempOrderDetailsList.Count > 0)
                    {
                        this.GetPrintedCopy(onlineOrderId, tempOrderDetailsList);
                    }
                }
                tempOrderManager.ChangeOnlineOrderPrintStatus(onlineOrderId);
            }
        }

        /// <summary>
        /// Collecting the printed copy of the respective order .added by Baruri at 13.12.2008
        /// </summary>
        private void GetPrintedCopy(Int64 orderID, List<COrderDetails> tempOrderDetailsList)
        { 
            string Cat1ID = String.Empty;

            try
            {
                CPrintMethods tempPrintMethods = new CPrintMethods();
                int categoryID = 0;
               
                string serialHeader = "IBACS RMS";
                string serialFooter = "Please Come Again";
                string serialBody = "";
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                serialBody = "               KITCHEN COPY\r\n";
               
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;//order information for online orders

                    serialBody += "\r\nOrder Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    
                    serialBody += "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    
                    serialBody += "\r\nType: " + tempOrderInfo.Status;

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;
                   
                    serialBody += "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                    serialBody += "\r\nPhone: " + tempCustomerInfo.CustomerPhone;
                   
                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        serialBody += "\r\nAddress:";
                       
                        serialBody += "\r\n----------------------------------------";
                       
                        serialBody += "\r\nFloor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                       
                        serialBody += "\r\nBuilding Name:" + tempCustomerInfo.BuildingName;
                       
                        serialBody += "\r\nHouse Number:" + tempCustomerInfo.HouseNumber;
                       
                        serialBody += "\r\nPhone:" + tempCustomerInfo.CustomerPhone;

                        serialBody += "\r\nPostal Code:" + tempCustomerInfo.CustomerPostalCode;
                       
                        serialBody += "\r\nTown:" + tempCustomerInfo.CustomerTown;
                       
                        serialBody += "\r\nCountry:" + tempCustomerInfo.CustomerCountry;
                        
                        serialBody += "\r\n----------------------------------------";
                    }
               
                serialBody += "\r\nOrder Information";
               
                serialBody += "\r\n----------------------------------------";
             
                serialBody += "\r\nQty Item                         Price  ";

                serialBody += "\r\n----------------------------------------";

                if (tempOrderDetailsList.Count > 0)
                {
                    for (int counter = 0; counter < tempOrderDetailsList.Count; counter++)
                    {
                        serialBody += "\r\n" + tempOrderDetailsList[counter].OrderQuantity.ToString() + "  ";
                        serialBody += CPrintMethods.GetFixedString(tempOrderDetailsList[counter].ItemName.ToString(), 30)+" ";
                        serialBody += CPrintMethods.RightAlign(tempOrderDetailsList[counter].OrderAmount.ToString(), 6);
                       // billTotal += Convert.ToDouble("0" + tempOrderDetailsList[j].OrderAmount);
                    }
                 }


                serialBody += "\r\n----------------------------------------";
                
                //serialBody += "\r\n                      Order Total: " + billTotal.ToString("F02");
                
                //serialBody += "\r\n                    Total Payable: " + billTotal.ToString("F02");

                //serialBody += "\r\n----------------------------------------";
              
                //serialBody += "\r\n        S/N: " + tempOrderInfo.SerialNo.ToString();
               
                //serialBody += "\r\nDeveloped by:ibacs limited.";

                serialBody += "\r\nThis is an online order.";
                serialBody += "\r\n           [END]        ";

                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

                CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                tempPrintingFormat.Header = serialHeader;
                tempPrintingFormat.Body = serialBody.ToUpper();
                tempPrintingFormat.Footer = serialFooter;
                tempPrintingFormat.OrderID = orderID;
                tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                CLogin oLogin = new CLogin();
                oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                oLogin.PostPrintingRequest(tempPrintingFormat);
             
                ///Update status
                ///
                if (tempOrderInfo.OrderType.Equals("Table"))
                {
                    tempOrderInfo.Status = "Billed";
                    tempOrderInfo.OrderTime = System.DateTime.Now;
                    tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                    CPaymentManager tempPaymentManager = new CPaymentManager();
                    CPayment tempPayment = new CPayment();
                    tempPayment.OrderID = tempOrderInfo.OrderID;
                    tempPayment.BillPrintTime = DateTime.Now;
                    tempPaymentManager.InsertBillPrintTime(tempPayment);
                }
            }
            catch (Exception exp)
            {
                
            }
        }


        #endregion

        #region "UI Events"

        private void TableIcon_MouseClick(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                LobbyItemButton tempTableIcon = (LobbyItemButton)sender;
                CCommonConstants tempCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                if (tempTableIcon.Type.Equals("Table") || tempTableIcon.Type.Equals("Tabs"))
                {
                    if (m_bTableInfoClicked)
                    {
                        CTableInfoMessageBox tempTableInfoMessageBox = new CTableInfoMessageBox(tempTableIcon.OrderID);
                        tempTableInfoMessageBox.Show();

                        m_bTableInfoClicked = false;
                        return;
                    }
                    else if (m_bNameTableClicked)
                    {
                        CKeyBoardForm tempKeyBoardForm = new CKeyBoardForm("Table Naming", "Please Enter the Name of the Table");
                        tempKeyBoardForm.ShowDialog();

                        if (CKeyBoardForm.Content.Equals("Cancel") || CKeyBoardForm.Content.Equals(""))
                            return;

                        COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(tempTableIcon.OrderID).Data;
                        tempOrderInfo.TableName = CKeyBoardForm.Content;
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                        tempTableIcon.TableName = CKeyBoardForm.Content;
                        m_bNameTableClicked = false;
                        TablePanel.Controls.Clear();
                        this.Init();
                        return;
                    }
                    else if (m_bChangeDetailsClicked)
                    {
                        CKeyBoardForm tempKeyBoardForm = new CKeyBoardForm("Change Details", "Please Enter the Name of the Table");
                        tempKeyBoardForm.ShowDialog();
                        if (CKeyBoardForm.Content.Equals("Cancel")) //If cancelled then exit.
                        {
                            return;
                        }

                        CCalculatorForm tempCalculatorForm = new CCalculatorForm("Change Details", "Guest Quantity");
                        tempCalculatorForm.ShowDialog();

                        COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(tempTableIcon.OrderID).Data;
                        if (!CKeyBoardForm.Content.Equals("") && !CKeyBoardForm.Content.Equals("Cancel"))
                        {
                            tempOrderInfo.TableName = CKeyBoardForm.Content;
                        }
                        
                        
                        if(!CCalculatorForm.inputResult.Equals("") && !CCalculatorForm.inputResult.Equals("Cancel") && !(Int32.Parse(CCalculatorForm.inputResult)==0))
                            tempOrderInfo.GuestCount = Convert.ToInt32(CCalculatorForm.inputResult);
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                        
                        m_bChangeDetailsClicked = false;
                        TablePanel.Controls.Clear();
                        Init();
                        return;
                    }
                }


                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo = (CTableInfo)tempOrderManager.GetTableInfoByTableNumber(tempTableIcon.TableNumber, tempTableIcon.Type).Data;

                if (tempTableInfo!=null && tempTableInfo.Status == 1)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Table Information", "Someone else is using this table at this moment.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                tempTableInfo.TableNumber = tempTableIcon.TableNumber;
                tempTableInfo.TableType = tempTableIcon.Type;
                tempTableInfo.Status = 1;
                tempOrderManager.UpdateTableInfo(tempTableInfo);


                if (tempTableIcon.Type.Equals("Table"))
                {
                    CTableOrderForm tempTableOrderForm = new CTableOrderForm(tempTableIcon.OrderID, tempCommonConstants.TableType, tempTableIcon.TableNumber);
                    tempTableOrderForm.m_TerminalName = TerminalIDLabel.Text;
                    tempTableOrderForm.m_orderUserName = tempTableIcon.User; 
                    tempTableOrderForm.Show();
                }
                else if (tempTableIcon.Type.Equals("Tabs"))
                {
                    CBarServiceForm tempBarServiceForm = new CBarServiceForm(tempTableIcon.OrderID, tempCommonConstants.TabsType, tempTableIcon.TableNumber);
                    tempBarServiceForm.Show();

                }
                else if (tempTableIcon.Type.Equals("TakeAway"))
                {
                    CTableOrderForm tempTableOrderForm = new CTableOrderForm(tempTableIcon.OrderID, tempCommonConstants.TakeAwayType, tempTableIcon.TableNumber);
                    //tempTableOrderForm.m_TerminalName = TerminalIDLabel.Text;
                    tempTableOrderForm.m_orderUserName = tempTableIcon.User; 
                    tempTableOrderForm.Show();
                }

                CFormManager.Forms.Push(this);
                this.Hide();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void SysMngmntButton_Click(object sender, EventArgs e)
        {
            CSystemManagementForm tempSystemManagementForm = new CSystemManagementForm();
            tempSystemManagementForm.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }

        private void TabInfoButton_Click(object sender, EventArgs e)
        {
            m_bTableInfoClicked = true;
        }

        private void NameTableButton_Click(object sender, EventArgs e)
        {
            m_bNameTableClicked = true;

        }

        private void TWButton_Click(object sender, EventArgs e)
        {
          /*  CustomerListForm.m_phoneNumber = String.Empty;
            TakeAway.CTakeAwayTypeForm objTakeAwayType = new CTakeAwayTypeForm(this);
            objTakeAwayType.Show();*/

            CTakeAwayForm tempTakeAwayForm = new CTakeAwayForm(2); //2 for collection type orders
            tempTakeAwayForm.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
           
        }

        private void BarServiceButton_Click(object sender, EventArgs e)
        {
            CBarServiceForm tempBarServiceForm = null;
            try
            {
                 tempBarServiceForm = new CBarServiceForm();
                 tempBarServiceForm.Show();

                CFormManager.Forms.Push(this);
                this.Hide();
            }
            catch (ArgumentException exp)
            {
                Console.Write(exp.Message);
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }  


        private void NewTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                List<COrderShow> tempOrderShowList = (List<COrderShow>)tempOrderManager.OrderListShowByStatus("Paid").Data;

                CCalculatorForm tableNumberForm = new CCalculatorForm("Table Information", "Table Number");
                tableNumberForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }

                string tableNumber = "";

                tableNumber = CCalculatorForm.inputResult;

                if (tableNumber.Equals(""))
                    return;

                bool found = false;
                for (int recordCounter = 0; recordCounter < tempOrderShowList.Count; recordCounter++)
                {
                    if (int.Parse(tableNumber) == tempOrderShowList[recordCounter].TableNumber && tempOrderShowList[recordCounter].OrderType.Equals("Table"))
                        found = true;
                }

                if (found)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Table already opened. Please select another table number.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                if (tableNumber.Equals("Cancel"))
                {
                    return;
                }

                CCalculatorForm tableGuestForm = new CCalculatorForm("Table Information", "Covers");
                tableGuestForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                {
                    return;
                }

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }

                string tableGuest = "";

                tableGuest = CCalculatorForm.inputResult;


                if (tableGuest.Equals("Cancel")) //If cancelled then exit.
                {
                    return;
                }




                CCalculatorForm floorNumberForm = new CCalculatorForm("Floor Information", "Floor Number");
                floorNumberForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;


                string floorNumber = "";

                floorNumber = CCalculatorForm.inputResult;



                COrderInfo tempOrderInfo = new COrderInfo();
                tempOrderInfo.TableNumber = int.Parse(tableNumber);
                //tempOrderInfo.TableName = "Table " + tableNumber;
                tempOrderInfo.UserID = m_oCommonConstants.UserInfo.UserID;
                tempOrderInfo.OrderTime = System.DateTime.Now; //needed now
                tempOrderInfo.OrderType = "Table";
                tempOrderInfo.GuestCount = int.Parse(tableGuest);
                tempOrderInfo.Status = "Seated";
                tempOrderInfo.FloorNo = floorNumber;
                //tempOrderInfo.InitialKitchenText = kitchenText;


                COrderManager tempOrderManager2 = new COrderManager();
                tempOrderInfo = (COrderInfo)tempOrderManager2.InsertOrderInfo(tempOrderInfo).Data;


                COrderSeatTime tempOrderSeatTime = new COrderSeatTime();
                tempOrderSeatTime.OrderID = tempOrderInfo.OrderID;
                tempOrderSeatTime.SeatTime = DateTime.Now;
                tempOrderManager2.InsertOrderSeatTime(tempOrderSeatTime);


                LobbyItemButton tableIcon = new LobbyItemButton();
                tableIcon.OrderID = tempOrderInfo.OrderID;
                tableIcon.TableName = "Table " + tableNumber;
                tableIcon.GuestCount = tableGuest;
                tableIcon.User = m_oCommonConstants.UserInfo.UserName;
                tableIcon.SeatedTime = tempOrderSeatTime.SeatTime;
               // tableIcon.Icon = global::RMS.Properties.Resources.seated;
                tableIcon.ItemType = RMSUIConstants.ItemType.SeatedButNoOrdered;
                tableIcon.TableNumber = int.Parse(tableNumber);
                tableIcon.Click += new EventHandler(TableIcon_MouseClick);

                tableIconList.Add(tableIcon);

                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo.TableNumber = int.Parse(tableNumber);
                tempTableInfo.TableType = "Table";
                tempTableInfo.Status = 0;
                tempOrderManager.InsertTableInfo(tempTableInfo);


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





                #region "OLD Code"

                //TablePanel.Controls.Clear();
                //Init();

                #endregion

                #region "New code added by Baruri"
                CTableOrderForm objOrderDetailsForm = new CTableOrderForm(tempOrderInfo.OrderID, 0, tempTableInfo.TableNumber);
                objOrderDetailsForm.m_orderUserName = RMSGlobal.LoginUserName;
                objOrderDetailsForm.Show();
                CFormManager.Forms.Push(this);
                this.Hide();
                #endregion

            }
            catch (Exception ee)
            {
            }
        }

        private void LogOffButton_Click(object sender, EventArgs e)
        {
            CLogin oLogin = new CLogin();
            CUserInfo oUserInfo = new CUserInfo();
            oUserInfo.UserID = m_oCommonConstants.UserInfo.UserID;
            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);

            CResult oResult = oLogin.ProcessLogout(oUserInfo);

            if (oResult.IsSuccess )//&& oResult.Data != null)
            {
                this.Close();
                m_oCommonConstants.UserInfo = null;
                CLoginForm tempLogin = (CLoginForm)CFormManager.Forms.Pop();
                tempLogin.Show();
            }
        }

        private void CMainForm_Activated(object sender, EventArgs e)
        {
            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                TablePanel.Controls.Clear();
                this.Init();
                RefreshTimer.Interval = oConstants.RefreshRate;
                RefreshTimer.Start();

               // grpCallerInfo.Location = new Point(this.Width - (80 + grpCallerInfo.Width), this.Height - grpCallerInfo.Height - 38);
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);   
            }
        }

        private void ChangeDetailsButton_Click(object sender, EventArgs e)
        {
            m_bChangeDetailsClicked = true;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iPageIndex < m_iTotalPageCount)
                    m_iPageIndex++;
                else
                    return;

                TablePanel.Controls.Clear();

                for (int k = ((m_iPageIndex - 1) * m_page_order_capacity); k < tableIconList.Count && k < (m_iPageIndex * m_page_order_capacity); k++)
                    TablePanel.Controls.Add(tableIconList[k]);

                if (m_iPageIndex < m_iTotalPageCount)
                    NextButton.Enabled = true;
                else
                    NextButton.Enabled = false;

                if (m_iPageIndex > 1)
                    PreviousButton.Enabled = true;
                else
                    PreviousButton.Enabled = false;

                CurrentPageLabel.Text = m_iPageIndex.ToString();

            }
            catch (Exception ee)
            {
            }
        }

      
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Clear();
            Init();
        }

        //private void RefreshTimer_Tick(object sender, EventArgs e) \\ Change by Mithu
        //{/*
        //    try
        //    {
        //        TablePanel.Controls.Clear();
        //        this.Init();

        //        //COrderManager tempOrderManager = new COrderManager();
        //        //tempOrderManager.SynchronizeOnlineOrders();

        //        this.PrintOnlineOrders(); //Prints online orders if there is any
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.Write(exp.Message);
        //    */
        //} \\ Change by Mithu

        private void CMainForm_Deactivate(object sender, EventArgs e)
        {
            RefreshTimer.Stop();
        }

        private void CMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                tsCallerIdStatus.Text = "Connected on port "+RMSGlobal.m_comPortName;
                tmrCallerInfo.Start();//Starting the caller timer
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                tsLblCurrentUser.Text = " Logged in as " + oConstants.UserInfo.UserName + " ";
            }
            catch (Exception exp)
            {
                tsCallerIdStatus.Text = RMSGlobal.m_connectionStatus;
            }
            CUserManager tempUserManager = new CUserManager();
            CResult tempResult = tempUserManager.GetAllUser();
            if (tempResult.IsSuccess)
            {
                userList = new List<CUserInfo>();
                userList = (List<CUserInfo>)tempResult.Data;
            }
        }

        private void btnRMSExit_Click(object sender, EventArgs e)
        {
            DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (tempDialogResult.Equals(DialogResult.No)) return;

            CCommonConstants m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            CLogin oLogin = new CLogin();
            CUserInfo oUserInfo = new CUserInfo();
            oUserInfo.UserID = m_oCommonConstants.UserInfo.UserID;
            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);

            CResult oResult = oLogin.ProcessLogout(oUserInfo);

            if (oResult.IsSuccess)
            {
                Application.Exit();
            }
            else
            {
            }
        }
      
        /// <summary>
        /// After closing of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        #endregion

        private void tmrCallerInfo_Tick(object sender, EventArgs e)
        {
            if (RMSGlobal.m_isCallAccepted==true)
            {
                picBoxPhone.Image = global::RMS.Properties.Resources.ring_stop;
                lblPhoneNumber.Text = RMSGlobal.m_phoneNumber;
                txtFirstAddress.Text = RMSGlobal.m_CallerAddress;
                txtCustomerName.Text = RMSGlobal.m_CallerName;
            }
            else if ((RMSGlobal.m_phoneNumber.Replace(" ", "").ToUpper() == "There is no call".Replace(" ", "").ToUpper()) || (RMSGlobal.m_phoneNumber==String.Empty)) //If there is no call
            {
                picBoxPhone.Image = global::RMS.Properties.Resources.ring_stop;
                lblPhoneNumber.Text = RMSGlobal.m_phoneNumber;
                txtFirstAddress.Text = RMSGlobal.m_CallerAddress;
                txtCustomerName.Text = RMSGlobal.m_CallerName;
            }
            else
            {
                picBoxPhone.Image = global::RMS.Properties.Resources.ring;
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.CustomerInfoGetByPhone(RMSGlobal.m_phoneNumber.Replace("-",""));//Collect the customer information
                
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    if (tempCustomerInfo.CustomerName.Length > 0)
                    {
                        txtCustomerName.Text = tempCustomerInfo.CustomerName;
                        lblPhoneNumber.Text = tempCustomerInfo.CustomerPhone;
                        tempCustomerInfo.StreetName = tempCustomerInfo.StreetName.Replace("-", " ");
                        txtFirstAddress.Text = tempCustomerInfo.StreetName;
                    }
                    else
                    {
                        txtCustomerName.Text = "Unknow Customer";
                        lblPhoneNumber.Text = RMSGlobal.m_phoneNumber;
                        txtFirstAddress.Text = "Unknown Area";
                    }
                    RMSGlobal.m_phoneNumber = lblPhoneNumber.Text;
                    RMSGlobal.m_CallerName = txtCustomerName.Text;
                    RMSGlobal.m_CallerAddress = txtFirstAddress.Text;
                }
            }
        }

        private void btnCallRefresh_Click(object sender, EventArgs e)
        {
            picBoxPhone.Image = global::RMS.Properties.Resources.ring_stop;
            RMSGlobal.m_isCallAccepted = true;
            RMSGlobal.m_CallerAddress = "There is no call";
            RMSGlobal.m_CallerName = "There is no call";
            RMSGlobal.m_phoneNumber = "There is no call";
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iPageIndex > 1)
                    m_iPageIndex--;
                else
                    return;

                TablePanel.Controls.Clear();

                for (int k = ((m_iPageIndex - 1) * m_page_order_capacity); k < tableIconList.Count && k < (m_iPageIndex * m_page_order_capacity); k++)
                    TablePanel.Controls.Add(tableIconList[k]);


                if (m_iPageIndex < m_iTotalPageCount)
                    NextButton.Enabled = true;
                else
                    NextButton.Enabled = false;

                if (m_iPageIndex > 1)
                    PreviousButton.Enabled = true;
                else
                    PreviousButton.Enabled = false;

                CurrentPageLabel.Text = m_iPageIndex.ToString();
            }
            catch (Exception ee)
            {
            }

        }

        private void TablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void refreshlobbyButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Clear();
           Init();
        }


        private void RefreshTimer_Tick(object sender, EventArgs e) // Change by Mithu(New add)
        {
            try
            {
                TablePanel.Controls.Clear();
                this.Init();

                //COrderManager tempOrderManager = new COrderManager();
                //tempOrderManager.SynchronizeOnlineOrders();

                //this.PrintOnlineOrders(); //Prints online orders if there is any
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }  // Change by Mithu(New add)
    

       
    }
}