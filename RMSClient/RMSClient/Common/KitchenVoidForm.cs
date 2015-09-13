﻿using System;
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
using System.IO;
using RMS.DataAccess;
using RMS.SystemManagement;
using RMSClient.DataAccess;
using RmsRemote;
using System.Net;
using RMSUI;
using RMS.Utility;



namespace RMS.Common
{
    public partial class KitchenVoidForm : BaseForm
    {
        private Int64 m_orderID = 0;
        private CCommonConstants m_cCommonConstants;
        private int m_printedCopy = 0;
        private int m_barPrintedCopy = 0;
        private SortedList m_slOrderedItems = new SortedList();
        private Int64 m_onlineOrderID = 0;

       

        public KitchenVoidForm()
        {
            InitializeComponent();
            m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
        }

        private void FillOrders()
        {
            COrderManager tempOrderManager = new COrderManager();
            List<COrderShow> tempOrderShowList = (List<COrderShow>)tempOrderManager.OrderListShowByStatus("Paid").Data;

            dgvCurrentOrders.RowCount = 0;
            for (int orderCounter = 0; orderCounter < tempOrderShowList.Count; orderCounter++)
            {
                CTableIcon tableIcon = new CTableIcon();
                tableIcon.User = tempOrderShowList[orderCounter].UserName;
                tableIcon.GuestCount = tempOrderShowList[orderCounter].GuestCount.ToString();
                tableIcon.TableName = tempOrderShowList[orderCounter].TableName;
                tableIcon.Type = tempOrderShowList[orderCounter].OrderType;
                tableIcon.OrderID = tempOrderShowList[orderCounter].OrderID;


                if (tableIcon.Type.Equals("Table"))
                {
                    tableIcon.TableName = "Table " + tempOrderShowList[orderCounter].TableNumber.ToString();
                }
                else if (tableIcon.Type.Equals("Tabs"))
                {
                    tableIcon.TableName = "Tab " + tempOrderShowList[orderCounter].TableNumber.ToString();
                }
                else if (tableIcon.Type.Equals("TakeAway"))
                {
                    COrderInfo temp2OrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(tempOrderShowList[orderCounter].OrderID).Data;
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerinfo = new CCustomerInfo();

                    tempCustomerinfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(temp2OrderInfo.CustomerID).Data;

                    if (tempCustomerinfo != null)
                    {
                        tableIcon.TableName = tempCustomerinfo.CustomerName;
                    }
                    else
                    {
                        tableIcon.TableName = "Take Away";
                    }
                    tableIcon.GuestCountLabel.Text = tempOrderShowList[orderCounter].Status;
                }

            DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvCurrentOrders.Rows;
            dgvRow.Add(tableIcon.OrderID, tableIcon.TableName, tempOrderShowList[orderCounter].OnlineOrderID);
            }
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }

        private void KitchenVoidForm_Activated(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string productName = "";
            int quantity = 0;

            foreach (ListViewItem lsvItem in lsvCurrent.CheckedItems)
            {
                productName = lsvItem.Text;
                quantity = Convert.ToInt32(lsvItem.SubItems[1].Text);

                if (quantity > 1)
                {
                    //Decrease 1 item
                    lsvItem.SubItems[1].Text = (Convert.ToInt32(lsvItem.SubItems[1].Text) - 1).ToString();
                    int itemIndex = IsAlreadyAdded(lsvRemovable, productName);
                    if (itemIndex > -1)
                    {
                        lsvRemovable.Items[itemIndex].SubItems[1].Text = (Convert.ToInt32(lsvRemovable.Items[itemIndex].SubItems[1].Text) + 1).ToString();
                    }
                    else
                    {
                        ListViewItem lsvRemoveItem = new ListViewItem(productName);
                        lsvRemoveItem.SubItems.Add("1");
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[2].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[3].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[4].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[5].Text);
                        lsvRemovable.Items.Add(lsvRemoveItem);
                    }

                    Int64 orderDetailsID = Convert.ToInt64(lsvItem.SubItems[4].Text);//Details ID for accessing the respective item
                    COrderDetails objDetails = (COrderDetails)m_slOrderedItems[orderDetailsID];
                    objDetails.OrderAmount = (objDetails.OrderAmount / objDetails.OrderQuantity) * (objDetails.OrderQuantity - 1);
                    objDetails.OrderQuantity = objDetails.OrderQuantity - 1;//Decrease by 1 item at a time.
                    objDetails.OnlineItemSequenceNumber = orderDetailsID; //As during loading of the items details id is initialized by sequence number.

                    objDetails.PrintedQuantity = objDetails.PrintedQuantity-1;
                }
                else
                {
                    int itemIndex = IsAlreadyAdded(lsvRemovable, productName);
                    if (itemIndex > -1)
                    {
                        lsvRemovable.Items[itemIndex].SubItems[1].Text = (Convert.ToInt32(lsvRemovable.Items[itemIndex].SubItems[1].Text) + 1).ToString();
                    }
                    else
                    {
                        ListViewItem lsvRemoveItem = new ListViewItem(productName);
                        lsvRemoveItem.SubItems.Add("1");
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[2].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[3].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[4].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[5].Text);
                        lsvRemovable.Items.Add(lsvRemoveItem);
                    }

                    //Update quantity status. 
                    Int64 orderDetailsID = Convert.ToInt64(lsvItem.SubItems[4].Text);//Details ID for accessing the respective item
                    COrderDetails objDetails = (COrderDetails)m_slOrderedItems[orderDetailsID];
                    objDetails.OnlineItemSequenceNumber = orderDetailsID;
                    objDetails.OrderAmount = (objDetails.OrderAmount / objDetails.OrderQuantity) * (objDetails.OrderQuantity - 1);
                    objDetails.OrderQuantity = objDetails.OrderQuantity-1;//Decrease by 1 item at a time.
                    objDetails.PrintedQuantity = objDetails.PrintedQuantity-1;

                    lsvCurrent.Items.RemoveAt(lsvItem.Index);
                }
            }
        }


        private int IsAlreadyAdded(ListView lsvRecord, string productName)
        {
            int itemIndex = -1;
            foreach (ListViewItem lsvItem in lsvRecord.Items)
            {
                if (lsvItem.Text.Replace(" ", "").ToUpper() == productName.Replace(" ", "").ToUpper())
                {
                    itemIndex = lsvItem.Index;
                }
            }
            return itemIndex;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string productName = "";
            int quantity = 0;

            foreach (ListViewItem lsvItem in lsvRemovable.CheckedItems)
            {
                productName = lsvItem.Text;
                quantity = Convert.ToInt32(lsvItem.SubItems[1].Text);

                if (quantity > 1)
                {
                    //Decrease 1 item
                    lsvItem.SubItems[1].Text = (Convert.ToInt32(lsvItem.SubItems[1].Text) - 1).ToString();
                    int itemIndex = IsAlreadyAdded(lsvCurrent, productName);
                    if (itemIndex > -1)
                    {
                        lsvCurrent.Items[itemIndex].SubItems[1].Text = (Convert.ToInt32(lsvCurrent.Items[itemIndex].SubItems[1].Text) + 1).ToString();
                    }
                    else
                    {
                        ListViewItem lsvRemoveItem = new ListViewItem(productName);
                        lsvRemoveItem.SubItems.Add("1");
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[2].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[3].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[4].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[5].Text);
                        lsvCurrent.Items.Add(lsvRemoveItem);
                    }

                    Int64 orderDetailsID = Convert.ToInt64(lsvItem.SubItems[4].Text);//Details ID for accessing the respective item
                    COrderDetails objDetails = (COrderDetails)m_slOrderedItems[orderDetailsID];
                    objDetails.OrderAmount = (objDetails.OrderAmount / objDetails.OrderQuantity) * (objDetails.OrderQuantity +1); //Set the increased price
                    objDetails.OrderQuantity = objDetails.OrderQuantity +1;//Decrease by 1 item at a time.
                    objDetails.PrintedQuantity = objDetails.PrintedQuantity+1;
                    objDetails.OnlineItemSequenceNumber = orderDetailsID;
                }
                else
                {
                    int itemIndex = IsAlreadyAdded(lsvCurrent, productName);
                    if (itemIndex > -1)
                    {
                        lsvCurrent.Items[itemIndex].SubItems[1].Text = (Convert.ToInt32(lsvCurrent.Items[itemIndex].SubItems[1].Text) + 1).ToString();
                    }
                    else
                    {
                        ListViewItem lsvRemoveItem = new ListViewItem(productName);
                        lsvRemoveItem.SubItems.Add("1");
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[2].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[3].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[4].Text);
                        lsvRemoveItem.SubItems.Add(lsvItem.SubItems[5].Text);
                        lsvCurrent.Items.Add(lsvRemoveItem);
                    }

                    Int64 orderDetailsID = Convert.ToInt64(lsvItem.SubItems[4].Text);//Details ID for accessing the respective item
                    COrderDetails objDetails = (COrderDetails)m_slOrderedItems[orderDetailsID];

                    objDetails.OrderAmount = (objDetails.OrderAmount / objDetails.OrderQuantity) * (objDetails.OrderQuantity + 1); //Set the increased price
                    objDetails.OrderQuantity = objDetails .OrderQuantity+ 1;//Decrease by 1 item at a time.
                    objDetails.PrintedQuantity = objDetails.PrintedQuantity+ 1;
                    objDetails.OnlineItemSequenceNumber = orderDetailsID;
                    lsvRemovable.Items.RemoveAt(lsvItem.Index);
                }
            }
        }

        private void dgvCurrentOrders_SelectionChanged(object sender, EventArgs e)
        {
            m_orderID = Convert.ToInt64("0" + dgvCurrentOrders.CurrentRow.Cells[0].Value);
            m_onlineOrderID = Convert.ToInt64("0" + dgvCurrentOrders.CurrentRow.Cells[2].Value);

            lsvCurrent.Items.Clear();
            lsvRemovable.Items.Clear();

            if (m_onlineOrderID < 1)
            {
                COrderManager tempOrderManager = new COrderManager();
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                CResult oResult = tempOrderManager.OrderDetailsByOrderID(m_orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;

                m_slOrderedItems = new SortedList();
                for (int itemIndex = 0; itemIndex < tempOrderDetailsList.Count; itemIndex++)
                {
                    Int64 tempProductID = tempOrderDetailsList[itemIndex].ProductID;
                    int tempCategoryLevel = tempOrderDetailsList[itemIndex].CategoryLevel;

                    string tempProductName = "";
                    if (tempCategoryLevel == 3)
                    {
                        DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempProductID);

                        if (tempDataRowArr.Length > 0)  //Added by Baruri .This was a bug previously when no row found.
                        {
                            tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                        }
                    }
                    else if (tempCategoryLevel == 4)
                    {
                        DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID);
                        int tempCat3_id = 0;
                        if (tempDataRowArr.Length > 0)
                        {
                            tempCat3_id = Convert.ToInt32("0" + tempDataRowArr[0]["cat3_id"]);
                        }

                        tempProductName = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0]["cat4_name"].ToString();


                        tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCat3_id);

                        if (tempDataRowArr.Length > 0)//If rows found
                        {
                            tempProductName += " " + tempDataRowArr[0]["cat3_name"].ToString();
                        }
                    }
                    else if (tempCategoryLevel == 0)
                    {
                        tempProductName = tempOrderDetailsList[itemIndex].OrderRemarks;
                    }

                    //if remarks exists append it... otherwise append nothing...
                    string appendString = "";
                    if (tempCategoryLevel != 0)
                    {
                        appendString = (tempOrderDetailsList[itemIndex].OrderRemarks.Equals("")) ? ("") : (" (" + tempOrderDetailsList[itemIndex].OrderRemarks + ")");
                    }

                    if (tempOrderDetailsList[itemIndex].PrintedQuantity > 0)
                    {
                        ListViewItem lsvItem = new ListViewItem(tempProductName + appendString);
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].PrintedQuantity.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OrderAmount.ToString("F02"));
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].ProductID.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OrderDetailsID.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OrderFoodType.ToString());
                        lsvCurrent.Items.Add(lsvItem);
                        

                        //For taking the track of the ordered items.
                        COrderDetails objOrderedItems=new COrderDetails();
                        objOrderedItems.OrderDetailsID=tempOrderDetailsList[itemIndex].OrderDetailsID;
                        objOrderedItems.OrderID=m_orderID;
                        objOrderedItems.ProductID=tempOrderDetailsList[itemIndex].ProductID;
                        objOrderedItems.OrderQuantity=tempOrderDetailsList[itemIndex].OrderQuantity;
                        objOrderedItems.PrintedQuantity=tempOrderDetailsList[itemIndex].PrintedQuantity;
                        objOrderedItems.OrderAmount = tempOrderDetailsList[itemIndex].OrderAmount;
                        m_slOrderedItems.Add(objOrderedItems.OrderDetailsID, objOrderedItems);
                    }
                }
            }
            else
            {
                //Loading the online orders information
                m_slOrderedItems = new SortedList();
                COrderManager tempOrderManager = new COrderManager();
                string remarks = "";
                string itemName = "";
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                CResult oResult = tempOrderManager.GetOnlineOrderDetailsByOrderID(m_orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;

                for (int itemIndex = 0; itemIndex < tempOrderDetailsList.Count; itemIndex++)
                {
                    remarks = tempOrderDetailsList[itemIndex].OrderRemarks.ToString();
                    itemName = tempOrderDetailsList[itemIndex].ItemName.ToString();

                    if (remarks.Length > 0)
                    {
                        itemName = itemName + "(" + remarks + ")";
                    }
                    if (tempOrderDetailsList[itemIndex].PrintedQuantity > 0)
                    {
                        ListViewItem lsvItem = new ListViewItem(itemName);
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].PrintedQuantity.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OrderAmount.ToString("F02"));
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].ProductID.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OnlineItemSequenceNumber.ToString());
                        lsvItem.SubItems.Add(tempOrderDetailsList[itemIndex].OrderFoodType.ToString());
                        lsvCurrent.Items.Add(lsvItem);


                        //For taking the track of the ordered items.
                        COrderDetails objOrderedItems = new COrderDetails();
                        objOrderedItems.OrderDetailsID = tempOrderDetailsList[itemIndex].OnlineItemSequenceNumber; //Here details id contains online ordered item sequence number
                        objOrderedItems.OrderID = m_orderID;
                        objOrderedItems.ProductID = tempOrderDetailsList[itemIndex].ProductID;
                        objOrderedItems.OrderQuantity = tempOrderDetailsList[itemIndex].OrderQuantity;
                        objOrderedItems.PrintedQuantity = tempOrderDetailsList[itemIndex].PrintedQuantity;
                        objOrderedItems.OrderAmount = tempOrderDetailsList[itemIndex].OrderAmount;
                        m_slOrderedItems.Add(objOrderedItems.OrderDetailsID, objOrderedItems);
                    }
                }
            }
        }

        private void KitchenVoidForm_Load(object sender, EventArgs e)
        {
            this.FillOrders();
        }

        private int GetPrintedQuantity(string productName)
        {
            int printedQuantity = -1;
            foreach (ListViewItem lsvItem in lsvCurrent.Items)
            {
                if (lsvItem.Text.Replace(" ", "").ToUpper() == productName.Replace(" ", "").ToUpper())
                {
                    printedQuantity = Convert.ToInt32(lsvItem.SubItems[1].Text);
                }
            }
            return printedQuantity;
        }


        private void CollectSettings()
        {
            DataSet tempDataSet = new DataSet();
            tempDataSet.ReadXml("Config/Mouse_Config.xml");

            if (!tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString().Equals(""))
            {
                m_printedCopy = Convert.ToInt32("0" + tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString());
            }

            if (!tempDataSet.Tables[0].Rows[0]["BarCopyNumber"].ToString().Equals(""))
            {
                m_barPrintedCopy = Convert.ToInt32("0" + tempDataSet.Tables[0].Rows[0]["BarCopyNumber"].ToString());
            }
        }


        private void btnVoidItem_Click(object sender, EventArgs e)
        {
           
            this.CollectSettings();
            DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to void this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tempDialogResult.Equals(DialogResult.No)) return;

            //ITEM_VOID_INFORMATION n = new ITEM_VOID_INFORMATION();
            //n.ShowDialog();


            if (lsvRemovable.Items.Count < 1)
            {
                MessageBox.Show("There is no item to be void.Please select as removable items.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
      
             
            else
            {
               
                if (MessageBox.Show("Ok Done", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    COrderManager tempOrderManager = new COrderManager();

                    if (m_onlineOrderID < 1)
                    {
                        tempOrderManager.VoidPrintedItems(m_slOrderedItems, m_orderID);//Updatre DB with latest quantity status for local ordered items.
                        
                    }
                    else
                    {
                        tempOrderManager.VoidOnlinePrintedItems(m_slOrderedItems); //For online ordered items
                    }

                   this.AddItemVoidReport();

                    this.KitchenPrintVoidCopy();
                    this.PrintBeverageVoidItems();
                    MessageBox.Show("Items are successfully sent to kitchen.", 
                        RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lsvRemovable.Items.Clear();
                }
            }
        }

        private void AddItemVoidReport()
        {

            COrderManager tempOrderManager = new COrderManager();
            CResult oResult = tempOrderManager.OrderInfoByOrderID(m_orderID);
            COrderInfo tempOrderInfo = new COrderInfo();

            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempOrderInfo = (COrderInfo)oResult.Data;
            }

            ItemVoid aItemVoid=new ItemVoid();
            aItemVoid.OrderId = (int)m_orderID;
            aItemVoid.Creator_Id = tempOrderInfo.UserID;
            aItemVoid.RemoverId = RMS.RMSGlobal.m_iLoginUserID;
            ReasonForm aReasonForm = new ReasonForm();
            aReasonForm.ShowDialog();
            aItemVoid.Reason = aReasonForm.reason;
            aItemVoid.VoidDate = DateTime.Now;



            foreach (ListViewItem lsvItem in lsvRemovable.Items)
            {

                try
                {
                    aItemVoid.Quantity = Convert.ToDouble(lsvItem.SubItems[1].Text);
                    aItemVoid.ItemName = lsvItem.SubItems[0].Text;

                    int id = Convert.ToInt32(lsvItem.SubItems[3].Text);
                    CCategory3 aCategory3 = new CCategory3();
                    CCategory3DAO aCategory3Dao = new CCategory3DAO();
                    aCategory3 = aCategory3Dao.GetAllCategory3ByCategory3ID(id);
                    aItemVoid.Amount = aItemVoid.Quantity * aCategory3.Category3TablePrice;
                    OrderVoidDAO aOrderVoidDao = new OrderVoidDAO();
                    aOrderVoidDao.InsertItemForVoid(aItemVoid);
                }
                catch (Exception)
                {
                    
                   
                }  
                

                    
                    
                                         

                
            }
        }


        private void PrintBeverageVoidItems()
        {
            string Cat1ID = String.Empty;
            bool itemAvailable = false;
            try
            {
                StringPrintFormater strPrintFormatter = new StringPrintFormater(29);
                int papersize = 29;


                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                string serialHeader = "";
                string serialFooter = "";



                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_orderID).Data;
                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();

                if ("Table" == tempOrderInfo.OrderType)
                {
                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Order Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    //serialBody.Add(tempSerialPrintContent);


                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    //serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n\r\nTable No:" + tempOrderInfo.TableNumber.ToString() + "\r\n";
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "COVERS:" + tempOrderInfo.GuestCount.ToString() + "\r\n";
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                }



                 tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "           Void Beverages/Non-Foods\n";
                serialBody.Add(tempSerialPrintContent);


                if ("Table" == tempOrderInfo.OrderType)
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Table No:" + tempOrderInfo.TableNumber.ToString() + "\r\n";
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "COVERS:" + tempOrderInfo.GuestCount.ToString() + "\r\n";
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                }
                else if ("TakeAway" == tempOrderInfo.OrderType)
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Type: " + tempOrderInfo.Status;
                    serialBody.Add(tempSerialPrintContent);

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Customer Name: " + tempCustomerInfo.CustomerName;
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Phone:" + tempCustomerInfo.CustomerPhone;
                    serialBody.Add(tempSerialPrintContent);


                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Address:";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "----------------------------------------";
                        serialBody.Add(tempSerialPrintContent);

                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Floor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Building Name:" + tempCustomerInfo.BuildingName;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "House Number:" + tempCustomerInfo.HouseNumber;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        string[] street = new string[0];
                        street = tempCustomerInfo.StreetName.Split('-');

                        if (street.Length > 1)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }

                            if (street[1].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = street[1].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }
                        }

                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Postal Code:" + tempCustomerInfo.CustomerPostalCode;
                            serialBody.Add(tempSerialPrintContent);
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Town:" + tempCustomerInfo.CustomerTown;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "----------------------------------------";
                        serialBody.Add(tempSerialPrintContent);

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = m_orderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;
                        if (objDelivery != null)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Information";
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);


                tempSerialPrintContent = new CSerialPrintContent();
               
                tempSerialPrintContent.StringLine = "Item                           Qty";
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);

                    Hashtable htOrderedItems = new Hashtable();
                    string categoryOrder = String.Empty;
                    PrintUtility printUtility = new PrintUtility();
                    foreach(ListViewItem lsvItem in lsvRemovable.Items)
                    {
                        if (lsvItem.SubItems[5].Text.ToString().Replace(" ", "").ToUpper() == "NonFood".Replace(" ", "").ToUpper())
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                         //   tempSerialPrintContent.StringLine = "(Void)" + lsvItem.Text.ToString() + "  ";
                        //    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(lsvItem.SubItems[1].Text.ToString(), 30);
                            
                            tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText(
                                          printUtility.MultipleLine("(Void)" + lsvItem.Text + "  ", papersize - 5, lsvItem.SubItems[1].Text.ToString(), papersize), "");

                            serialBody.Add(tempSerialPrintContent);
                            itemAvailable = true;


                         

                       //     tempSerialPrintContent.StringLine +=
                       //                                strPrintFormatter.ItemLabeledText(
                       //                             printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 32, priceString, papersize), "");

                        }
                    }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);

                //New at 22.08.2008
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Prepared By :" + RMSGlobal.LoginUserName;
                serialBody.Add(tempSerialPrintContent);


                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult objResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (objResult.IsSuccess && objResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)objResult.Data;
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = tempPcInfo.Name.Trim();
                serialBody.Add(tempSerialPrintContent);

                if (itemAvailable == true) //If there is items for printing
                {
                    for (int printCopy = 0; printCopy < m_barPrintedCopy; printCopy++)
                    {
                       // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                    }

                    string printingObject = ""; //Write to the text file
                    for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                    {
                        printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                    }

                    tempPrintMethods.USBPrint(printingObject, PrintDestiNation.BEVARAGE, false);
                    this.WriteString(printingObject);///Write to a file when print command is executed
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void KitchenPrintVoidCopy()
        {
            Hashtable htOrderedItems = new Hashtable();
            bool itemAvailable = false;
            try
            {
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();
                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                COrderManager tempOrderManager = new COrderManager();
                CResult oResult = tempOrderManager.OrderInfoByOrderID(m_orderID);
                COrderInfo tempOrderInfo = new COrderInfo();

                StringPrintFormater strPrintFormatter = new StringPrintFormater(29);
              int   papersize = 29;

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }

                string serialHeader = "";
                string serialFooter = "";
                string serialBody = "";

                if ("Table" == tempOrderInfo.OrderType)
                {
                    serialBody += "\r\n\r\nTable NO:" + tempOrderInfo.TableNumber.ToString();
                    serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();
                }

                serialBody += "\r\n           Kitchen Copy";

                if (!tempOrderInfo.Status.Equals("Seated") && "Table"== tempOrderInfo.OrderType)
                {
                    serialBody += "\r\nReprint";
                }
                serialBody += "\r\n\r\nOrdered Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                serialBody += "\r\nPrint Date: " + DateTime.Now.ToString("dd/MM/yy hh:mm tt");

                if ("Table" == tempOrderInfo.OrderType)
                {
                    //serialBody += "\r\n\r\nTable NO:" + tempOrderInfo.TableNumber.ToString();
                    //serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();
                }
                else if ("TakeAway" == tempOrderInfo.OrderType)
                {
                    serialBody += "\r\n\r\n        Take Away";
                    serialBody += "\r\n       Type: " + tempOrderInfo.Status;
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;
                    serialBody += "\r\n Customer Name: " + tempCustomerInfo.CustomerName;
                    serialBody += "\r\nPhone:" + tempCustomerInfo.CustomerPhone;


                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        serialBody += "\r\nAddress:";
                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            serialBody += "\r\nFloor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                        }
                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            serialBody += "\r\nBuilding Name:" + tempCustomerInfo.BuildingName;
                        }
                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            serialBody += "\r\nHouse Number:" + tempCustomerInfo.HouseNumber;
                        }
                        string[] street = new string[0];
                        street = tempCustomerInfo.StreetName.Split('-');

                        if (street.Length > 1)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                serialBody += "\r\nStreet:" + street[0].ToString();
                            }
                            if (street[1].ToString().Length > 0)
                            {
                                serialBody += "\r\n" + street[1].ToString();
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                serialBody += "\r\nStreet:" + street[0].ToString();
                            }
                        }
                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            serialBody += "\r\nPostal Code:" + tempCustomerInfo.CustomerPostalCode;
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            serialBody += "\r\nTown:" + tempCustomerInfo.CustomerTown;
                        }
                        serialBody += "\r\n----------------------------------------";
                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = m_orderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;

                        serialBody += "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                    }
                }

                serialBody += "\r\n\r\nOrder Information";
                serialBody += "\r\n---------------------------------";


                serialBody += "\r\n Item                       Qty";
                serialBody += "\r\n---------------------------------";

                PrintUtility printUtility = new PrintUtility();

                foreach (ListViewItem lsvItem in lsvRemovable.Items)
                {
                    if (lsvItem.SubItems[5].Text.Replace(" ", "").ToUpper() == "Food".Replace(" ", "").ToUpper())
                    {
                    //    serialBody += "\r\n(Void)" + CPrintMethods.GetFixedString(lsvItem.Text, 20) + "  ";
                      // serialBody += lsvItem.SubItems[0].Text;
                        itemAvailable = true;

                        serialBody += "\r\n" +  strPrintFormatter.ItemLabeledText(
                                                    printUtility.MultipleLine("(Void)" + lsvItem.Text + "  ", papersize - 5, lsvItem.SubItems[1].Text.ToString(), papersize), "");

                    }
                }
                serialBody += "\r\n---------------------------------";

                serialBody += "\r\nOrder Prepared By:" + RMSGlobal.LoginUserName;

                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult objResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (objResult.IsSuccess && objResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)objResult.Data;
                }

                serialBody += "\r\nTerminal Name:" + tempPcInfo.Name;

                serialBody += "\r\n\r\n          [ E N D ]\r\n\r\n";

                CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                tempPrintingFormat.Header = serialHeader;
                tempPrintingFormat.Body = serialBody.ToUpper();
                tempPrintingFormat.Footer = serialFooter;
                tempPrintingFormat.OrderID = m_orderID;
                tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;


                if (itemAvailable == true)
                {
                    CLogin oLogin = new CLogin();
                    oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);

                    for (int printCopy = 0; printCopy < m_printedCopy; printCopy++)
                    {
                       // oLogin.PostPrintingRequest(tempPrintingFormat);

                        tempPrintMethods.USBPrint(serialBody, PrintDestiNation.KITCHEN, false);

                    }
                    this.WriteString(serialBody);//Writing to the specified file
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        private void WriteString(string s)
        {
            StreamWriter fstr_out;

            // Open the file directly using StreamWriter. 
            try
            {
                fstr_out = new StreamWriter("rms_printedcopy.txt");
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "Cannot open file.");
                return;
            }

            try
            {
                fstr_out.Write(s);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "File Error");
                return;
            }
            fstr_out.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            

        }

        

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            //lsvRemovable.Items.Clear();
        }

        

       
    }
}