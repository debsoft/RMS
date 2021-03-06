using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Main;
using RMS.Common;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using Managers.Payment;
using System.Net;
using Managers.User;
using RMS.TableOrder;
using Managers.Customer;
using RMSUI;

namespace RMS.BarService
{
    public partial class CBarServiceForm : BaseForm
    {
        //CategoryButton lists
        private List<CCategoryButton> category2ButtonList;
        private List<CCategoryButton> category3ButtonList;
        private List<CCategoryButton> category4ButtonList;

        private int m_iNavigationPoint = 0; //stores the point of navigation for Category2Panel 
        private int m_iNavigationCategory3Point = 0;//stores the point of navigation for ItemSelectionPanel 
        private int m_iType = 0;
        private Int64 orderID;
        private CCommonConstants m_cCommonConstants;
        private int m_iDataGridViewCurrentRowIndex = -1;
        private DataGridView m_dDataGridView;
        private int m_iSavedOrderedQty = 1;
        private Int64 m_iTableNumber;
        private bool m_bOrderState = false; //To check whther there is an order active
        private bool m_bItemDescriptionClicked = false;
        private double m_dDiscountAmount = 0.000;
        private string m_sDiscountType = "Fixed";

        private const int CATEGORY2PANEL_CAPACITY = 10;
        private const int CATEGORY3PANEL_CAPACITY = 21;

        public CBarServiceForm()
        {
            InitializeComponent();

            m_bOrderState = false;
            m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            m_iType = m_cCommonConstants.TabsType;
            FillRMSDataGridView();
            category2ButtonList = new List<CCategoryButton>();
            category3ButtonList = new List<CCategoryButton>();
            category4ButtonList = new List<CCategoryButton>();

            try
            {
                m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                this.ActivateButtons();

                if (m_cCommonConstants.UserInfo == null)
                    return;

                this.g_ConvertButton.Text = "Convert to Table";
                

                foreach (DataRow tempDataRow in Program.initDataSet.Tables["Category2"].Rows)
                {
                    if (int.Parse(tempDataRow["cat2_type"].ToString()) == 1)
                        continue;

                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat2_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat2_order"].ToString());
                    tempCategoryButton.CategoryLevel = 2;
                    tempCategoryButton.Text = tempDataRow["cat2_name"].ToString();
                    try
                    {
                        tempCategoryButton.BackColor = Color.FromArgb(Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                    }
                    catch (Exception eeee)
                    {
                    }
                    //tempCategoryButton.BackColor = Color.FromName(tempDataRow["cat2_color"].ToString());
                    tempCategoryButton.Click += new EventHandler(Category2Button_Click);
                    category2ButtonList.Add(tempCategoryButton);
                }

                g_Category2Panel.Controls.Clear();
                for (int counter = 0; counter < CATEGORY2PANEL_CAPACITY && counter < category2ButtonList.Count; counter++)
                {
                    g_Category2Panel.Controls.Add(category2ButtonList[counter]);
                }

                if (category2ButtonList.Count > CATEGORY2PANEL_CAPACITY)
                    g_NextButton.Enabled = true;
                else
                    g_NextButton.Enabled = false;

                g_PreviousButton.Enabled = false;
                LoadStatusBar();
            }
            catch (Exception eee)
            {
            }
        }

        public CBarServiceForm(Int64 inOrderID,int inType, Int64 inTableNumber)
        {
            InitializeComponent();
            m_bOrderState = true;
            orderID = inOrderID;
            m_iType = inType;
            m_iTableNumber = inTableNumber;
            category2ButtonList = new List<CCategoryButton>();
            category3ButtonList = new List<CCategoryButton>();
            category4ButtonList = new List<CCategoryButton>();

            FillRMSDataGridView();
            try
            {
                m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                this.ActivateButtons();
                if (m_cCommonConstants.UserInfo == null)
                    return;

                this.g_ConvertButton.Text = "Convert to Table";
                
                foreach (DataRow tempDataRow in Program.initDataSet.Tables["Category2"].Rows)
                {
                    if (int.Parse(tempDataRow["cat2_type"].ToString()) == 1)
                        continue;

                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat2_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat2_order"].ToString());
                    tempCategoryButton.CategoryLevel = 2;
                    tempCategoryButton.Text = tempDataRow["cat2_name"].ToString();

                    try
                    {
                        tempCategoryButton.BackColor = Color.FromArgb(Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                    }
                    catch (Exception eee)
                    {
                    }

                    tempCategoryButton.Click += new EventHandler(Category2Button_Click);
                    category2ButtonList.Add(tempCategoryButton);
                }

                g_Category2Panel.Controls.Clear();
                for (int counter = 0; counter < CATEGORY2PANEL_CAPACITY && counter < category2ButtonList.Count; counter++)
                {
                    g_Category2Panel.Controls.Add(category2ButtonList[counter]);
                }

                ///Load Order Details
                /// 
                this.FillNonFoods();
                
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void FillNonFoods()
        {
            g_FoodDataGridView.RowCount = 0;
            COrderManager tempOrderManager = new COrderManager();
            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            CResult oResult = tempOrderManager.OrderDetailsByOrderID(orderID);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempOrderDetailsList = (List<COrderDetails>)oResult.Data;
            }

            for (int detailsCounter = 0; detailsCounter < tempOrderDetailsList.Count; detailsCounter++)
            {
                Int64 tempProductID = tempOrderDetailsList[detailsCounter].ProductID;
                int tempCategoryLevel = tempOrderDetailsList[detailsCounter].CategoryLevel;

                string tempProductName = "";
                if (tempCategoryLevel == 3)
                {
                    DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempProductID);
                    tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                }
                else if (tempCategoryLevel == 4)
                {
                    //Latest name is at first
                    int tempCat3_id = int.Parse(Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0].GetParentRow(Program.initDataSet.Relations["category3_to_category4"])["cat3_id"].ToString());
                    tempProductName += Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0]["cat4_name"].ToString();
                    tempProductName += " " + Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCat3_id)[0]["cat3_name"].ToString();

                }
                else if (tempCategoryLevel == 0)
                    tempProductName = tempOrderDetailsList[detailsCounter].OrderRemarks;

                int tempFoodType = 0;

                DataGridView tempDataGridView = new DataGridView();
                tempDataGridView = g_FoodDataGridView;

                string[] tempDataGridViewRow = { 
                    tempProductName, 
                    tempOrderDetailsList[detailsCounter].OrderQuantity.ToString(),
                    ((double)tempOrderDetailsList[detailsCounter].OrderAmount).ToString("F02"),
                    tempOrderDetailsList[detailsCounter].ProductID.ToString(),
                    tempOrderDetailsList[detailsCounter].CategoryLevel.ToString(),
                    (Int64.MaxValue-1)+"",//max rank
                    tempOrderDetailsList[detailsCounter].OrderDetailsID.ToString()
                    };


                //not misc item... rank is specified
                if (tempCategoryLevel != 0)
                    tempDataGridViewRow[5] = Program.initDataSet.Tables["Category" + tempCategoryLevel].Select("cat" + tempCategoryLevel + "_id = " + tempProductID)[0]["cat" + tempCategoryLevel + "_rank"].ToString();

                tempDataGridView.Rows.Add(tempDataGridViewRow);
                ConvertRank();
                tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                tempDataGridView.Update();
                g_FoodDataGridView.ClearSelection();
            }

            //get discount
            COrderDiscount tempOrderDiscount = new COrderDiscount();
            oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempOrderDiscount = (COrderDiscount)oResult.Data;
                m_dDiscountAmount = tempOrderDiscount.Discount;
            }

            if (category2ButtonList.Count > CATEGORY2PANEL_CAPACITY)
                g_NextButton.Enabled = true;
            else
                g_NextButton.Enabled = false;

            g_PreviousButton.Enabled = false;

            TotalAmountCalculation();
            LoadStatusBar();
        }


        private void CBarServiceForm_Shown(object sender, EventArgs e)
        {
            g_FoodDataGridView.ClearSelection();
        }


        /// <summary>
        /// Addred By Baruri at 06.09.2008
        /// </summary>
        private void ActivateButtons()
        {
            CUserManager tempUserManager = new CUserManager();
            CUserAccess tempUserAccess2 = (CUserAccess)tempUserManager.GetUserAccess(m_cCommonConstants.UserInfo).Data;
            if (tempUserAccess2.RemoveItems == 1)
            {
                g_RemoveButton.Enabled = true;
            }
            else
            {
                g_RemoveButton.Enabled = false;
            }
        }


        private void LoadStatusBar()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            UserStatusLabel.Text = " Logged in as " + oConstants.UserInfo.UserName + " ";


            if (m_bOrderState)
            {
                COrderManager oOrderManager = new COrderManager();
                COrderInfo oOrderInfo = new COrderInfo();
                CResult oResult = oOrderManager.OrderInfoByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    oOrderInfo = (COrderInfo)oResult.Data;
                }


                TableStatusLabel.Text = " Tab No. " + oOrderInfo.TableNumber + " ";
                TableStatusLabel.Visible = true;
                GuestStatusLabel.Text = " No. of Guests - " + oOrderInfo.GuestCount + " ";
                GuestStatusLabel.Visible = true;

                BillNoStatusLabel.Text = " Reference No. " + oOrderInfo.SerialNo.ToString() + " ";
                BillNoStatusLabel.Visible = true;
            }
            else
            {
                TableStatusLabel.Visible = false;
                GuestStatusLabel.Visible = false;
                BillNoStatusLabel.Visible = false;
                TableValueStatusLabel.Visible = false;
            }
        }

        private void FillRMSDataGridView()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

            int rowCounter = g_FoodDataGridView.RowCount;

            if (rowCounter < oConstants.BarServiceFoodGrid)
            {
                for (int counter = rowCounter; counter < oConstants.BarServiceFoodGrid; counter++)
                {
                    string[] str ={ "", "", "", "", "", Int64.MaxValue.ToString(), "" };
                    g_FoodDataGridView.Rows.Add(str);
                }
            }
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
            catch (Exception exp)
            {
                throw exp;
            }

            return 1;
        }

        private void NewOrder()
        {
            try
            {
                if (m_bOrderState)
                {
                    return;
                }
                CCommonConstants tempCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = new COrderInfo();
                
                tempOrderInfo.TableNumber = GetValidTableNumber("Tabs");
                tempOrderInfo.GuestCount = 1;
                tempOrderInfo.TableName = "Tabs" + tempOrderInfo.TableNumber;
                tempOrderInfo.UserID = tempCommonConstants.UserInfo.UserID;
                tempOrderInfo.OrderTime = DateTime.Now;
                tempOrderInfo.OrderType = "Tabs";
                //Status not used
                


                CResult oResult = tempOrderManager.InsertOrderInfo(tempOrderInfo);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }

                //insert new tab info
                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo.TableType = "Tabs";
                tempTableInfo.TableNumber = tempOrderInfo.TableNumber;
                tempTableInfo.Status = 1;
                tempOrderManager.InsertTableInfo(tempTableInfo);
                m_iTableNumber = tempTableInfo.TableNumber;

                COrderSeatTime tempOrderSeatTime = new COrderSeatTime();
                tempOrderSeatTime.OrderID = tempOrderInfo.OrderID;
                tempOrderSeatTime.SeatTime = System.DateTime.Now;
                tempOrderManager.InsertOrderSeatTime(tempOrderSeatTime);

                orderID = tempOrderInfo.OrderID;
                m_iType = tempCommonConstants.TabsType;
              
                m_bOrderState = true;
                LoadStatusBar();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void Reload()
        {
            g_ItemSelectionFlowLayoutPanel.Controls.Clear();
            g_FoodDataGridView.Rows.Clear();
            FillRMSDataGridView();
            g_FoodDataGridView.Update();
            g_FoodDataGridView.ClearSelection();
            g_InputTextBox.Text = "�0.000";
            g_BalanceLabel.Text = "�0.000";
            g_TenderedLabel.Text = "�0.000";
            m_bOrderState = false;
        }

        private int DataGridViewSearch(DataGridView inDataGridView, string inValue)
        {
            try
            {
                for (int rowIndex = 0; rowIndex < inDataGridView.Rows.Count; rowIndex++)
                {
                    if (inDataGridView[0, rowIndex].Value != null && inDataGridView[0, rowIndex].Value.ToString().Equals(inValue))
                    {
                        return rowIndex;
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return -1;
        }

        private void TotalAmountCalculation()
        {
            try
            {
                Double tempTotal = new Double();
                tempTotal = 0.0;

                for (int rowCounter = 0; rowCounter < g_FoodDataGridView.Rows.Count; rowCounter++)
                {
                    if (g_FoodDataGridView[2, rowCounter].Value != null && !g_FoodDataGridView[2, rowCounter].Value.ToString().Equals(""))
                    {
                        tempTotal += Double.Parse(g_FoodDataGridView[2, rowCounter].Value.ToString());
                    }
                }

                Double discountAmount = 0.000;
                if (m_sDiscountType.Equals("Fixed"))
                {
                    discountAmount = m_dDiscountAmount;
                }
                else if (m_sDiscountType.Equals("Percent"))
                {
                    discountAmount = tempTotal * m_dDiscountAmount / 100;
                }

                COrderManager tempOrderManager = new COrderManager();
                COrderDiscount tempOrderDiscount = new COrderDiscount();
                CResult oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDiscount = (COrderDiscount)oResult.Data;

                    //update
                    tempOrderDiscount.Discount = discountAmount;
                    tempOrderManager.UpdateOrderDiscount(tempOrderDiscount);
                }
                else
                {
                    //insert
                    tempOrderDiscount.OrderID = orderID;
                    tempOrderDiscount.Discount = discountAmount;
                    tempOrderManager.InsertOrderDiscount(tempOrderDiscount);
                }
                tempTotal = tempTotal - discountAmount;
                g_DiscountLabel.Text = discountAmount.ToString("F02");

                g_BalanceLabel.Text = tempTotal.ToString("F02");
                numericInputButton13.Text = "�"+tempTotal.ToString("F02");
                TableValueStatusLabel.Text = " Total Value �" + tempTotal.ToString("F02")+" ";
                TableValueStatusLabel.Visible = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private DataTable DataGridViewToDataTable(DataGridView inDataGridView)
        {
            DataTable tempDataTable = new DataTable();
            try
            {
                tempDataTable.Columns.Add("Item");
                tempDataTable.Columns.Add("Qty");
                tempDataTable.Columns.Add("Price");
                tempDataTable.Columns.Add("Catid");
                tempDataTable.Columns.Add("Catlevel");
                tempDataTable.Columns.Add("isdrink");
                tempDataTable.Columns.Add("rank");

                foreach (DataGridViewRow tempDGRow in inDataGridView.Rows)
                {
                    DataRow tempDataRow = tempDataTable.NewRow();
                    if (tempDGRow.Cells[0].Value != null && !tempDGRow.Cells[0].Value.ToString().Equals(""))
                    {
                        tempDataRow["Item"] = tempDGRow.Cells[0].Value.ToString();
                    }
                    else
                    {
                        continue;
                    }
                    if (tempDGRow.Cells[1].Value != null)
                    {
                        tempDataRow["Qty"] = tempDGRow.Cells[1].Value.ToString();
                    }

                    if (tempDGRow.Cells[2].Value != null)
                    {
                        tempDataRow["Price"] = tempDGRow.Cells[2].Value.ToString();
                    }

                    if (tempDGRow.Cells[3].Value != null)
                    {
                        tempDataRow["Catid"] = tempDGRow.Cells[3].Value.ToString();
                    }

                    if (tempDGRow.Cells[4].Value != null)
                    {
                        tempDataRow["Catlevel"] = tempDGRow.Cells[4].Value.ToString();
                    }

                    if (tempDGRow.Cells[5].Value != null)
                    {
                        tempDataRow["rank"] = tempDGRow.Cells[5].Value.ToString();
                    }

                    tempDataRow["isdrink"] = "1";

                    tempDataTable.Rows.Add(tempDataRow);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return tempDataTable;
        }

        private void g_ExitButton_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo.TableNumber = m_iTableNumber;
                tempTableInfo.Status = 0;
                string tableType = "Tabs";
                tempTableInfo.TableType = tableType;
                tempOrderManager.UpdateTableInfo(tempTableInfo);

                if (g_FoodDataGridView[0, 0].Value.ToString().Equals(""))
                {
                    tempOrderManager.DeleteOrderInfo(orderID);
                    tempOrderManager.DeleteTableInfo(m_iTableNumber, "Tabs");
                }

                CMainForm tempMainForm = (CMainForm)CFormManager.Forms.Pop();
                tempMainForm.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void Category2Button_Click(object sender, EventArgs e)
        {
            try
            {
                CCategoryButton tempCategory2Button = (CCategoryButton)sender;
                int tempCategory2ID = tempCategory2Button.CategoryID;

                DataRow[] tempDataRowArray = Program.initDataSet.Tables["Category3"].Select("cat2_id = " + tempCategory2ID.ToString());
                category3ButtonList.Clear();
                foreach (DataRow tempDataRow in tempDataRowArray)
                {
                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat3_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat3_order"].ToString());
                    tempCategoryButton.CategoryLevel = 3;
                    tempCategoryButton.Text = tempDataRow["cat3_name"].ToString();
                    tempCategoryButton.BackColor = tempCategory2Button.BackColor;
                    tempCategoryButton.Click += new EventHandler(Category3Button_Click);
                    category3ButtonList.Add(tempCategoryButton);
                }
                m_iNavigationCategory3Point = 0;
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int buttonCounter = 0; buttonCounter < CATEGORY3PANEL_CAPACITY && buttonCounter < category3ButtonList.Count; buttonCounter++)
                {
                    g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[buttonCounter]);
                }

                if (category3ButtonList.Count > CATEGORY3PANEL_CAPACITY)
                    g_Category3NextButton.Enabled = true;
                else
                    g_Category3NextButton.Enabled = false;

                if (m_iNavigationCategory3Point > 0)
                    g_Category3PreviousButton.Enabled = true;
                else
                    g_Category3PreviousButton.Enabled = false;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void Category3Button_Click(object sender, EventArgs e)
        {
            try
            {
                CCategoryButton tempCategory3Button = (CCategoryButton)sender;
                int tempCategory3ID = tempCategory3Button.CategoryID;

                if (m_bItemDescriptionClicked)
                {
                    string tempItemDescription = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3ID)[0]["description"].ToString();
                    CMessageBox tempMessageBox = new CMessageBox("Item Description", tempItemDescription);
                    tempMessageBox.ShowDialog();
                    m_bItemDescriptionClicked = false;
                    return;
                }

                int tempFoodType = int.Parse(Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3ID)[0].GetParentRow(Program.initDataSet.Relations["category2_to_category3"])["cat2_type"].ToString());
                DataGridView tempDataGridView = new DataGridView();
                tempDataGridView = g_FoodDataGridView;

                DataRow[] tempDataRowArray = Program.initDataSet.Tables["Category4"].Select("cat3_id = " + tempCategory3ID.ToString());
                category4ButtonList.Clear();
                if (tempDataRowArray.Length != 0)
                {
                    foreach (DataRow tempDataRow in tempDataRowArray)
                    {
                        CCategoryButton tempCategoryButton = new CCategoryButton();
                        tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat4_id"].ToString());
                        tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat4_order"].ToString());
                        tempCategoryButton.CategoryLevel = 4;
                        tempCategoryButton.Text = tempDataRow["cat4_name"].ToString();
                        tempCategoryButton.BackColor = tempCategory3Button.BackColor;
                        category4ButtonList.Add(tempCategoryButton);
                    }

                    CCategory4Form tempCategory4Form = new CCategory4Form(tempCategory3ID, category4ButtonList, tempCategory3Button.Text);
                    tempCategory4Form.ShowDialog();
                    CCategoryButton tempCategory4Button = CCategory4Form.m_cbResult;
                    if (tempCategory4Button == null)
                        return;
                    else   //insert into table and datagridview
                    {
                        NewOrder();

                        DataRow[] temp2DataRowArray = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempCategory4Button.CategoryID.ToString());
                        if (temp2DataRowArray.Length != 0)
                        {
                            //category4 + categpry3
                            string ItemName = temp2DataRowArray[0]["cat4_name"].ToString() + " " + tempCategory3Button.Text;
                            string tableTypePrice = string.Empty;
                            tableTypePrice = temp2DataRowArray[0]["bar_price"].ToString();
                            int tempSearchResult = DataGridViewSearch(tempDataGridView, ItemName);

                            COrderManager tempOrderManager = new COrderManager();
                            COrderDetails tempOrderDetails = new COrderDetails();

                            if (tempSearchResult != -1)
                            {
                                int tempRowIndex = tempSearchResult;
                                int qty = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                                tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
                                tempDataGridView.Rows[tempRowIndex].Cells[2].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
                                //update Order_details table
                                tempOrderDetails.OrderID = orderID;
                                tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[6].Value.ToString());
                                tempOrderDetails.ProductID = tempCategory4Button.CategoryID;
                                tempOrderDetails.CategoryLevel = tempCategory4Button.CategoryLevel;
                                tempOrderDetails.OrderQuantity = qty;
                                tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                                tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                                tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                                tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                            }
                            else
                            {
                                //Insert into Order_details table
                                tempOrderDetails.OrderID = orderID;
                                tempOrderDetails.ProductID = tempCategory4Button.CategoryID;
                                tempOrderDetails.CategoryLevel = tempCategory4Button.CategoryLevel;
                                tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                                tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                                tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                                tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                                CResult oResult = tempOrderManager.InsertOrderDetails(tempOrderDetails);
                                if (oResult.IsSuccess && oResult.Data != null)
                                {
                                    tempOrderDetails = (COrderDetails)oResult.Data;
                                }

                                string[] tempDataGridViewRow = new string[] 
                                { ItemName, 
                                  m_iSavedOrderedQty.ToString(), 
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory4Button.CategoryID.ToString(),
                                  "4",
                                  temp2DataRowArray[0]["cat4_rank"].ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString()
                                };

                                tempDataGridView.Rows.Add(tempDataGridViewRow);
                            }
                            ConvertRank();
                            tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                            tempDataGridView.Update();
                            TotalAmountCalculation();
                        }
                    }
                }
                else //There is no category4
                {
                    NewOrder();
                    DataGridViewRow tempDataGridViewRow = new DataGridViewRow();
                    tempDataGridViewRow.CreateCells(tempDataGridView);

                    DataRow[] temp2DataRowArray = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3Button.CategoryID.ToString());

                    if (temp2DataRowArray.Length != 0)
                    {
                        string tableTypePrice = string.Empty;
                        tableTypePrice = temp2DataRowArray[0]["bar_price"].ToString();

                        COrderManager tempOrderManager = new COrderManager();
                        COrderDetails tempOrderDetails = new COrderDetails();

                        int tempResult = DataGridViewSearch(tempDataGridView, temp2DataRowArray[0]["cat3_name"].ToString());
                        if (tempResult != -1)
                        {
                            //update Order_details table
                            int tempRowIndex = tempResult;
                            int qty=int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                            tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
                            tempDataGridView.Rows[tempRowIndex].Cells[2].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
                            tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[6].Value.ToString());
                            tempOrderDetails.OrderID = orderID;
                            tempOrderDetails.ProductID = tempCategory3Button.CategoryID;
                            tempOrderDetails.CategoryLevel = tempCategory3Button.CategoryLevel;
                            tempOrderDetails.OrderQuantity = qty;
                            tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                            tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                            tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                        }
                        else
                        {
                            //Insert into Order_details table
                            tempOrderDetails.OrderID = orderID;
                            tempOrderDetails.ProductID = tempCategory3Button.CategoryID;
                            tempOrderDetails.CategoryLevel = tempCategory3Button.CategoryLevel;
                            tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                            tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                            tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                            tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                            CResult oResult = tempOrderManager.InsertOrderDetails(tempOrderDetails);
                            if (oResult.IsSuccess && oResult.Data != null)
                            {
                                tempOrderDetails = (COrderDetails)oResult.Data;
                            }

                            string[] temp2DataGridViewRow = new string[] 
                                { temp2DataRowArray[0]["cat3_name"].ToString(), 
                                  m_iSavedOrderedQty.ToString(), 
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory3Button.CategoryID.ToString(),
                                  "3",
                                  temp2DataRowArray[0]["cat3_rank"].ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString()
                                };

                            tempDataGridView.Rows.Add(temp2DataGridViewRow);
                        }
                        ConvertRank();
                        tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                        tempDataGridView.Update();
                        TotalAmountCalculation();
                    }
                }
                m_iSavedOrderedQty = 1;
                g_FoodDataGridView.ClearSelection();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void ConvertRank()
        {
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
            {
                g_FoodDataGridView[5, rowIndex].Value = Int64.Parse(g_FoodDataGridView[5, rowIndex].Value.ToString());
            }
        }

        private void g_PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationPoint > 0)
                {
                    m_iNavigationPoint--;
                }
                else
                    return;

                g_Category2Panel.Controls.Clear();
                for (int buttonCounter = 0; buttonCounter < CATEGORY2PANEL_CAPACITY; buttonCounter++)
                {
                    if (category2ButtonList.Count > (CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + buttonCounter))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + buttonCounter)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY) && (category2ButtonList.Count % CATEGORY2PANEL_CAPACITY) == 0)
                    {
                        g_NextButton.Enabled = false;
                    }
                    else
                    {
                        g_NextButton.Enabled = true;
                    }
                }
                else
                    g_NextButton.Enabled = false;

                if (m_iNavigationPoint > 0)
                    g_PreviousButton.Enabled = true;
                else
                    g_PreviousButton.Enabled = false;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void g_NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    m_iNavigationPoint++;
                }
                g_Category2Panel.Controls.Clear();
                for (int counter = 0; counter < CATEGORY2PANEL_CAPACITY; counter++)
                {
                    if (category2ButtonList.Count > (CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY) && (category2ButtonList.Count % CATEGORY2PANEL_CAPACITY) == 0)
                    {
                        g_NextButton.Enabled = false;
                    }
                    else
                    {
                        g_NextButton.Enabled = true;
                    }
                }
                else
                    g_NextButton.Enabled = false;

                if (m_iNavigationPoint > 0)
                {
                    g_PreviousButton.Enabled = true;
                }
                else
                {
                    g_PreviousButton.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void g_Category3PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationCategory3Point > 0)
                    m_iNavigationCategory3Point--;
                else
                    return;

                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int i = 0; i < CATEGORY3PANEL_CAPACITY; i++)
                {
                    if (category3ButtonList.Count > (CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + i))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + i)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY) && (category3ButtonList.Count % CATEGORY3PANEL_CAPACITY == 0))
                        g_Category3NextButton.Enabled = false;
                    else
                        g_Category3NextButton.Enabled = true;
                }
                else
                    g_Category3NextButton.Enabled = false;

                if (m_iNavigationCategory3Point > 0)
                    g_Category3PreviousButton.Enabled = true;
                else
                    g_Category3PreviousButton.Enabled = false;
            }
            catch (Exception eee)
            {
            }
        }

        private void g_Category3NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                    m_iNavigationCategory3Point++;
                else
                    return;

                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int categoryCounter = 0; categoryCounter < CATEGORY3PANEL_CAPACITY; categoryCounter++)
                {
                    if (category3ButtonList.Count > (CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + categoryCounter))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + categoryCounter)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY) && (category3ButtonList.Count % CATEGORY3PANEL_CAPACITY == 0))
                        g_Category3NextButton.Enabled = false;
                    else
                        g_Category3NextButton.Enabled = true;
                }
                else
                    g_Category3NextButton.Enabled = false;

                if (m_iNavigationCategory3Point > 0)
                    g_Category3PreviousButton.Enabled = true;
                else
                    g_Category3PreviousButton.Enabled = false;
            }
            catch (Exception eee)
            {
            }
        }

        private void g_FoodDataGridView_Click(object sender, EventArgs e)
        {
            if (g_FoodDataGridView.RowCount != 0)
            {
                m_iDataGridViewCurrentRowIndex = g_FoodDataGridView.CurrentRow.Index;
                m_dDataGridView = g_FoodDataGridView;
            }
        }
        private void g_RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iDataGridViewCurrentRowIndex == -1)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Please select ordered food or beverage.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                COrderManager tempOrderManager = new COrderManager();
                int qty = Int32.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString());
                Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());
                Double unitPrice = amount / qty;
                if (qty == 1)
                {
                    tempOrderManager.DeleteOrderDetails(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString()));
                    m_dDataGridView.Rows.RemoveAt(m_iDataGridViewCurrentRowIndex);
                }
                else
                {
                    qty = qty - 1;

                    COrderDetails tempOrderDetails = new COrderDetails();
                    CResult oResult = tempOrderManager.OrderDetailsByOrderDetailID(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString()));
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempOrderDetails = (COrderDetails)oResult.Data;
                    }
                    tempOrderDetails.OrderQuantity = qty;
                    tempOrderDetails.OrderAmount = qty * unitPrice;
                    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = qty;
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = ((double)(qty * unitPrice)).ToString("F02");
                }


                m_dDataGridView.Update();
                TotalAmountCalculation();
                m_dDataGridView.ClearSelection();
            }
            catch (Exception eee)
            {
            }
        }
        private void g_ItemDescriptionButton_Click(object sender, EventArgs e)
        {
            m_bItemDescriptionClicked = true;
        }
        private void g_QuantityButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempCalculatorForm = new CCalculatorForm("Order Quantity", "Item Quantity");
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
            {
                CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                tempMessageBox.ShowDialog();
                return;
            }

            int tempOrderedQty = Int32.Parse(CCalculatorForm.inputResult);
            m_iSavedOrderedQty = tempOrderedQty;
        }
        private void g_MiscButton_Click(object sender, EventArgs e)
        {
            try
            {
                CKeyBoardForm tempKeyBoardForm = new CKeyBoardForm("Misc Item", "Enter Item Name or Description");
                tempKeyBoardForm.ShowDialog();

                if (CKeyBoardForm.Content.Equals("Cancel"))
                    return;

                if (CKeyBoardForm.Content.Equals(""))
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Item Name cannot be Empty");
                    tempMessageBox.ShowDialog();
                    return;
                }
                CPriceCalculatorForm tempCalculatorForm = new CPriceCalculatorForm("Misc Item", "Enter Price");
                tempCalculatorForm.ShowDialog();

                if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CPriceCalculatorForm.inputResult.Equals("0.000"))
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Price cannot be zero.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                NewOrder();

                COrderManager tempOrderManager = new COrderManager();
                COrderDetails tempOrderDetails = new COrderDetails();
                DataGridView tempDataGridView = g_FoodDataGridView;

                int tempResult = DataGridViewSearch(tempDataGridView, CKeyBoardForm.Content);
                if (tempResult != -1)
                {
                    //update Order_details table
                    int tempRowIndex = tempResult;
                    tempDataGridView.Rows[tempRowIndex].Cells[1].Value = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                    tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[6].Value.ToString());
                    tempOrderDetails.OrderID = orderID;
                    tempOrderDetails.ProductID = 0;
                    tempOrderDetails.CategoryLevel = 0;
                    tempOrderDetails.OrderRemarks = CKeyBoardForm.Content;
                    tempOrderDetails.OrderQuantity = Int32.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString());
                    tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(CPriceCalculatorForm.inputResult);
                    tempOrderDetails.OrderFoodType = "Nonfood";
                    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                }
                else
                {
                    //Insert into Order_details table
                    tempOrderDetails.OrderID = orderID;
                    tempOrderDetails.ProductID = 0;
                    tempOrderDetails.CategoryLevel = 0;
                    tempOrderDetails.OrderRemarks = CKeyBoardForm.Content;
                    tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                    tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(CPriceCalculatorForm.inputResult);
                    tempOrderDetails.OrderFoodType = "Nonfood";
                    tempOrderDetails = (COrderDetails)tempOrderManager.InsertOrderDetails(tempOrderDetails).Data;


                    string[] tempDataGridViewRow = new string[] 
                                { CKeyBoardForm.Content, 
                                  m_iSavedOrderedQty.ToString(), 
                                  CPriceCalculatorForm.inputResult,
                                  "0",
                                  "0",
                                  (Int64.MaxValue-1)+"",
                                  tempOrderDetails.OrderDetailsID.ToString()
                                };

                    tempDataGridView.Rows.Add(tempDataGridViewRow);

                }
                ConvertRank();
                tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                tempDataGridView.Update();
                TotalAmountCalculation();
                m_iSavedOrderedQty = 1;
                g_FoodDataGridView.ClearSelection();
            }
            catch (Exception eee)
            {
            }
        }

        private void g_ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                CResult oResult = tempOrderManager.OrderListShowByStatus("Paid");
                List<COrderShow> tempOrderShowList= new List<COrderShow>();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderShowList = (List<COrderShow>)oResult.Data;
                }

                CCalculatorForm tableNumberForm = new CCalculatorForm("Table Information", "Table Number");
                tableNumberForm.ShowDialog();

                string tableNumber = "";

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }

                tableNumber = CCalculatorForm.inputResult;

                //check whether table already exists
                bool found = false;
                for (int orderCounter = 0; orderCounter < tempOrderShowList.Count; orderCounter++)
                {
                    if (int.Parse(tableNumber) == tempOrderShowList[orderCounter].TableNumber && tempOrderShowList[orderCounter].OrderType.Equals("Table"))
                        found = true;
                }
                if (found)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Table already opened. Please select another table number.");
                    tempMessageBox.ShowDialog();
                    return;
                }
                
                CCalculatorForm tableGuestForm = new CCalculatorForm("Table Information", "Guest Quantity");
                tableGuestForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }

                string tableGuest = "";
                tableGuest = CCalculatorForm.inputResult;

                //update order info table
                
                COrderInfo tempOrderInfo = new COrderInfo();
                oResult = tempOrderManager.OrderInfoByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }

                //delete previous tab number from table info
                if(tempOrderInfo.TableNumber!=0)
                    tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "Tabs");

                //update order info 
                tempOrderInfo.GuestCount = int.Parse(tableGuest);
                tempOrderInfo.Status = "Seated";
                tempOrderInfo.OrderType = "Table";
                tempOrderInfo.TableNumber = int.Parse(tableNumber);
                tempOrderInfo.TableName = "";
                tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                //insert new table number in table info
                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo.TableNumber = tempOrderInfo.TableNumber;
                tempTableInfo.TableType = "Table";
                tempOrderManager.InsertTableInfo(tempTableInfo);

                CMainForm tempMainForm = (CMainForm)CFormManager.Forms.Pop();
                tempMainForm.Show();
                this.Close();
            }
            catch (Exception eee)
            {
                //MessageBox.Show(eee.ToString());
            }
        }
        private void g_OpenTabsButton_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                List<COrderShow> tempOrderShowList = (List<COrderShow>)tempOrderManager.OrderListShowByStatus("Paid").Data;

                CKeyBoardForm tempKeyboardForm = new CKeyBoardForm("Tabs Information", "Enter Customer Name");
                tempKeyboardForm.ShowDialog();

                if (CKeyBoardForm.Content.Equals("Cancel") || CKeyBoardForm.Content.Equals(""))
                    return;

                string tabsName = CKeyBoardForm.Content;
            

                CCalculatorForm tableGuestForm = new CCalculatorForm("Tabs Information", "Guest Quantity");
                tableGuestForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }

                string tableGuest = "";
                tableGuest = CCalculatorForm.inputResult;

                NewOrder();
                CResult oResult=tempOrderManager.OrderInfoByOrderID(orderID);
                COrderInfo tempOrderInfo = new COrderInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }
                tempOrderInfo.GuestCount = int.Parse(tableGuest);
                tempOrderInfo.TableName = tabsName;
                tempOrderManager.UpdateOrderInfo(tempOrderInfo);
            }
            catch (Exception eee)
            {
            }
        }

        private void g_PayCloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tempItemTable = new DataTable();
                tempItemTable = DataGridViewToDataTable(g_FoodDataGridView);

                CPaymentForm tempPaymentForm = new CPaymentForm(orderID, Double.Parse(g_BalanceLabel.Text), "Tabs", tempItemTable, Double.Parse(g_DiscountLabel.Text),-1,"0");//0 for service charge added by baruri
                tempPaymentForm.Show();
                CFormManager.Forms.Push(this);
                this.Hide();

            }
            catch (Exception eee)
            {
            }
        }

        private void SetNumber(int inDigit)
        {
            try
            {
                if (g_InputTextBox.Text.Length > 10)
                    return;
                Double tempInput = Double.Parse(g_InputTextBox.Text.Substring(1));
                g_InputTextBox.Text = "�" + ((Double)(tempInput * 10 + inDigit * 0.01)).ToString("F02");

            }
            catch (Exception eee)
            {
            }
        }
        private void g_OneButton_Click(object sender, EventArgs e)
        {
            SetNumber(1);
        }
        private void g_TwoButton_Click(object sender, EventArgs e)
        {
            SetNumber(2);
        }
        private void g_ThreeButton_Click(object sender, EventArgs e)
        {
            SetNumber(3);
        }
        private void g_FourButton_Click(object sender, EventArgs e)
        {
            SetNumber(4);
        }
        private void g_FiveButton_Click(object sender, EventArgs e)
        {
            SetNumber(5);
        }
        private void g_SixButton_Click(object sender, EventArgs e)
        {
            SetNumber(6);
        }
        private void g_SevenButton_Click(object sender, EventArgs e)
        {
            SetNumber(7);
        }
        private void g_EightButton_Click(object sender, EventArgs e)
        {
            SetNumber(8);
        }
        private void g_NineButton_Click(object sender, EventArgs e)
        {
            SetNumber(9);
        }
        private void g_ZeroButton_Click(object sender, EventArgs e)
        {
            SetNumber(0);
        }
        private void g_ClearButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�0.000";
        }
        private void g_20poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�20.00";
        }
        private void g_10poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�10.00";
        }
        private void g_5poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�5.00";
        }
        private void g_InputTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double tempTotalBill = Double.Parse(g_BalanceLabel.Text);
                Double tempInputBill = Double.Parse(g_InputTextBox.Text.Substring(1));

                Double tempBalance = tempTotalBill - tempInputBill;
                if (tempBalance > 0)
                    g_TenderedStatusLabel.Text = "Balance Due";
                else
                {
                    g_TenderedStatusLabel.Text = "Pay Back";
                    tempBalance = -tempBalance;
                }
                g_TenderedLabel.Text = "�" + tempBalance.ToString("F02");
               
            }
            catch (Exception eee)
            {
            }
        }

        private void g_PrintTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPrintMethods tempPrintMethods = new CPrintMethods();

                CKeyBoardForm tempKeyboardForm = new CKeyBoardForm("Bar Token Information", "Enter Customer Name");
                tempKeyboardForm.ShowDialog();

                if (CKeyBoardForm.Content.Equals("Cancel"))
                    return;

                CCalculatorForm tempCalculatorForm = new CCalculatorForm("Bar Token Information", "Enter Number of Guest");
                tempCalculatorForm.ShowDialog();

                if (CCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                    tempMessageBox.ShowDialog();
                    return;
                }
            }
            catch (Exception eee)
            {
            }
        }
      
        private void g_PrintGuestBillButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPrintMethods tempPrintMethods = new CPrintMethods();
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;

                //serial print 
                string serialHeader = "IBACS RMS";
                string serialFooter = "Please Come Again";
                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine="               Guest Bill";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Date: " + System.DateTime.Now.ToLongDateString()+"\n";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "               Bar Service\n";
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();                               
                tempSerialPrintContent.StringLine="Order Information";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Qty Item                         Price  ";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);

                for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
                {
                    DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                    if (!tempRow.Cells[0].Value.ToString().Equals(""))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = tempRow.Cells[1].Value.ToString() + "  ";
                        tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                        tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(tempRow.Cells[2].Value.ToString(), 6);
                        serialBody.Add(tempSerialPrintContent);
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);
                Double discountAmount = Double.Parse(g_DiscountLabel.Text);
                Double totalAmount = Double.Parse(g_BalanceLabel.Text);
                Double billTotal = discountAmount + totalAmount;
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "                     Order Total: " + billTotal.ToString("F02");
                serialBody.Add(tempSerialPrintContent);
                if (discountAmount > 0)
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    Double discountPercent = 100 * discountAmount / (discountAmount + totalAmount);
                    tempSerialPrintContent.StringLine = "                 Discount:(" + discountPercent.ToString("F02") + "%) " + g_DiscountLabel.Text;
                    serialBody.Add(tempSerialPrintContent);
                }
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "                   Total Payable: " + g_BalanceLabel.Text;
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);
                
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine="\nS/N: " + tempOrderInfo.SerialNo.ToString();
                serialBody.Add(tempSerialPrintContent);

                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "Developed By:ibacs limited";
                //serialBody.Add(tempSerialPrintContent);

                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "www.ibacs.co.uk";
                //serialBody.Add(tempSerialPrintContent);

                tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
            }
            catch (Exception eee)
            {
            }
        }
        private void g_CashButton_Click(object sender, EventArgs e)
        {
            try
            {
                Double tempTotal = Double.Parse(g_BalanceLabel.Text);
                Double tempInput = Double.Parse(g_InputTextBox.Text.Substring(1));
                if (tempTotal > tempInput)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Paid Amount less than Balance Amount.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                CPaymentManager tempPaymentManager = new CPaymentManager();

                ///insert into payment table
                CPayment tempPayment = new CPayment();
                tempPayment.OrderID = orderID;

                //get pc id from pc ip
                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult oResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)oResult.Data;
                }

                tempPayment.PcID = tempPcInfo.PcID;
                tempPayment.TotalAmount = Double.Parse(g_BalanceLabel.Text);
                tempPayment.CashAmount = tempPayment.TotalAmount;
                tempPayment.PaymentTime = System.DateTime.Now;

                oResult = tempPaymentManager.InsertPayment(tempPayment);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPayment = (CPayment)oResult.Data;
                }

                ////update order info status
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;
                //tempOrderInfo.Status = "Paid";
                //tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                //opening cash drawer
                try
                {
                    CPrintMethods tempPrintMethods = new CPrintMethods();
                    tempPrintMethods.OpenDrawer();
                }
                catch (Exception eee)
                {
                }

                //archiving
                tempOrderManager.InsertOrderArchive(tempOrderInfo);
                tempOrderManager.InsertOrderDetailsArchive(tempOrderInfo);
                tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "Tabs");
                Reload();
            }
            catch (Exception eee)
            {
            }
        }
        private void numericInputButton13_Click(object sender, EventArgs e)
        {
            try
            {
                Double tempTotal = Double.Parse(g_BalanceLabel.Text);
                Double tempInput = Double.Parse(numericInputButton13.Text.Substring(1));
                if (tempTotal > tempInput)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Paid Amount less than Balance Amount.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                CPaymentManager tempPaymentManager = new CPaymentManager();

                ///insert into payment table
                CPayment tempPayment = new CPayment();
                tempPayment.OrderID = orderID;

                //get pc id from pc ip
                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult oResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)oResult.Data;
                }

                tempPayment.PcID = tempPcInfo.PcID;
                tempPayment.TotalAmount = Double.Parse(g_BalanceLabel.Text);
                tempPayment.CashAmount = tempPayment.TotalAmount;
                tempPayment.PaymentTime = System.DateTime.Now;

                oResult = tempPaymentManager.InsertPayment(tempPayment);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPayment = (CPayment)oResult.Data;
                }

                ////update order info status
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;
                //tempOrderInfo.Status = "Paid";
                //tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                //opening cash drawer
                try
                {
                    CPrintMethods tempPrintMethods = new CPrintMethods();
                    tempPrintMethods.OpenDrawer();
                }
                catch (Exception eee)
                {
                }
                //archiving
                tempOrderManager.InsertOrderArchive(tempOrderInfo);
                tempOrderManager.InsertOrderDetailsArchive(tempOrderInfo);
                tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "Tabs");
                Reload();

            }
            catch (Exception eee)
            {
            }
        }

        private void g_PromotionsButton_Click(object sender, EventArgs e)
        {
            CDiscountForm tempDiscountForm = new CDiscountForm();
            tempDiscountForm.ShowDialog();

            if (CDiscountForm.discountType.Equals("Cancel"))
                return;

            m_dDiscountAmount = CDiscountForm.discountAmount;
            m_sDiscountType = CDiscountForm.discountType;
            TotalAmountCalculation();
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            if (m_iDataGridViewCurrentRowIndex == -1)
            {
                CMessageBox tempMessageBox = new CMessageBox("Error!", "Please select ordered food or beverage.");
                tempMessageBox.ShowDialog();
                return;
            }
            
            if (m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value == null || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString() == String.Empty)
            {
                return;
            }

            COrderDetails objOrderDetails = new COrderDetails();
            Int64 itemSequenceNumber = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value);
            int quantity = Convert.ToInt32("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value);
            double amount = Convert.ToDouble("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value);
            amount = (amount / quantity) * (quantity + 1); //Calculate the total amount
            quantity++; //Increasing the quantity of items
            Int64 productID = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value);

            objOrderDetails.ProductID = productID;
            objOrderDetails.OrderAmount = amount;
            objOrderDetails.OrderQuantity = quantity;
            objOrderDetails.OrderID = orderID;
            COrderManager objOrderManager = new COrderManager();
            objOrderManager.AddNewLocalProducts(objOrderDetails); //Increasing Items's quantity for local orders 
            m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = quantity;
            m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = amount.ToString("F02");

            m_dDataGridView.Update();
            TotalAmountCalculation();
            m_dDataGridView.ClearSelection();
        }

        private void btnPLU_Click(object sender, EventArgs e)
        {
            COrderManager objOrderManager = new COrderManager();
            this.NewOrder();
            //////Start
            //PLUPopup objPLUPopup = new PLUPopup();
            int priceTakeType;
            Int32 productPLU = 0;
            int returnVal = 0;
            Int32 productQuantity = 0;

            priceTakeType = -99;
            //objPLUPopup.ShowDialog(this);

            //if (PLUPopup.m_productCode == "Cancel")
            //{
            //    return;
            //}

            //productPLU = Convert.ToInt32("0" + PLUPopup.m_productCode);

            CCalculatorForm tableNumberForm = new CCalculatorForm("Product PLU Information", "PLU of the Product");
            tableNumberForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
            {
                CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                tempMessageBox.ShowDialog();
                return;
            }

            productPLU = Convert.ToInt32("0" + CCalculatorForm.inputResult);


            CResult objProductName = objOrderManager.GetProductByProductPLU(productPLU);
            if (Convert.ToString(objProductName.Data) == "NO")
            {
                CMessageBox tempMessageBox = new CMessageBox("Error", "Invalid PLU.Please enter valid PLU");
                tempMessageBox.ShowDialog();
                return;
            }


            ProductQuantityForm quantityForm = new ProductQuantityForm(Convert.ToString(objProductName.Data));
            quantityForm.ShowDialog();

            if (ProductQuantityForm.m_productQuantity.Equals("Cancel"))
            {
                return;
            }
            if (ProductQuantityForm.m_productQuantity.Equals("") || Int32.Parse(ProductQuantityForm.m_productQuantity) == 0)
            {
                CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                tempMessageBox.ShowDialog();
                return;
            }

            productQuantity = Convert.ToInt32("0" + ProductQuantityForm.m_productQuantity);

            
            CResult oResult = objOrderManager.GetPluDataByProductPLU(productPLU, priceTakeType, orderID, productQuantity);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                returnVal = int.Parse(oResult.Data.ToString());
            }

            if (returnVal == 0)
            {
                MessageBox.Show("Please enter valid plu product", RMSGlobal.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ///End new
            this.FillNonFoods();

            btnPLU_Click(sender, e);
        }

        private void CBarServiceForm_Load(object sender, EventArgs e)
        {
            List<OrderLogInformation> m_objOrderLogInfo = new List<OrderLogInformation>();
            CCustomerManager tempCustomerManager = new CCustomerManager();
            CResult m_objOrderLog = tempCustomerManager.GetOrderLogInformation(orderID);
            m_objOrderLogInfo = (List<OrderLogInformation>)m_objOrderLog.Data;

            int localCounter = 0;
            for (int recordCounter = 0; recordCounter < m_objOrderLogInfo.Count; recordCounter++)
            {
                if (localCounter == 0) //For first items
                {
                    if (m_objOrderLogInfo[recordCounter].FirstOrderTakenTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLogInfo[recordCounter].FirstOrderTakenTime);
                        lblFirstOrderTime.Text = dt.ToString("hh:mm tt") + " (" + m_objOrderLogInfo[recordCounter].UserName + ")";
                    }
                    else
                    {
                        lblFirstOrderTime.Text = "N/A";
                    }
                }
                else
                {
                    if (m_objOrderLogInfo[recordCounter].FirstOrderTakenTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLogInfo[recordCounter].FirstOrderTakenTime);
                        lblLastOrderTime.Text = dt.ToString("hh:mm tt") + " (" + m_objOrderLogInfo[recordCounter].UserName + ")";
                    }
                    else
                    {
                        lblLastOrderTime.Text = "N/A";
                    }
                }
                localCounter++;
            }
        }

        private void numericInputButton1_Click(object sender, EventArgs e)
        {
            SetNumber(1);
        }

        private void numericInputButton2_Click(object sender, EventArgs e)
        {
            SetNumber(2);
        }

        private void numericInputButton3_Click(object sender, EventArgs e)
        {
            SetNumber(3);
        }

        private void numericInputButton8_Click(object sender, EventArgs e)
        {
            SetNumber(4);
        }

        private void numericInputButton7_Click(object sender, EventArgs e)
        {
            SetNumber(5);
        }

        private void numericInputButton6_Click(object sender, EventArgs e)
        {
            SetNumber(6);
        }

        private void numericInputButton12_Click(object sender, EventArgs e)
        {
            SetNumber(7);
        }

        private void numericInputButton11_Click(object sender, EventArgs e)
        {
            SetNumber(8);
        }

        private void numericInputButton10_Click(object sender, EventArgs e)
        {
            SetNumber(9);
        }

        private void numericInputButton15_Click(object sender, EventArgs e)
        {
            SetNumber(0);
        }

        private void numericInputButton16_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�0.000";
        }

        private void numericInputButton14_Click(object sender, EventArgs e)
        {
            try
            {
                Double tempTotal = Double.Parse(g_BalanceLabel.Text);
                Double tempInput = Double.Parse(g_InputTextBox.Text.Substring(1));
                if (tempTotal > tempInput)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Paid Amount less than Balance Amount.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                CPaymentManager tempPaymentManager = new CPaymentManager();

                ///insert into payment table
                CPayment tempPayment = new CPayment();
                tempPayment.OrderID = orderID;

                //get pc id from pc ip
                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult oResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)oResult.Data;
                }

                tempPayment.PcID = tempPcInfo.PcID;
                tempPayment.TotalAmount = Double.Parse(g_BalanceLabel.Text);
                tempPayment.CashAmount = tempPayment.TotalAmount;
                tempPayment.PaymentTime = System.DateTime.Now;

                oResult = tempPaymentManager.InsertPayment(tempPayment);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPayment = (CPayment)oResult.Data;
                }

                ////update order info status
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;
                //tempOrderInfo.Status = "Paid";
                //tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                //opening cash drawer
                try
                {
                    CPrintMethods tempPrintMethods = new CPrintMethods();
                    tempPrintMethods.OpenDrawer();
                }
                catch (Exception eee)
                {
                }

                //archiving
                tempOrderManager.InsertOrderArchive(tempOrderInfo);
                tempOrderManager.InsertOrderDetailsArchive(tempOrderInfo);
                tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "Tabs");
                Reload();
            }
            catch (Exception eee)
            {
            }
        }

        private void numericInputButton4_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�20.00";
        }

        private void numericInputButton5_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�10.00";
        }

        private void numericInputButton9_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "�5.00";
        }

        private void functionalButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationCategory3Point > 0)
                    m_iNavigationCategory3Point--;
                else
                    return;

                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int i = 0; i < CATEGORY3PANEL_CAPACITY; i++)
                {
                    if (category3ButtonList.Count > (CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + i))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + i)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY) && (category3ButtonList.Count % CATEGORY3PANEL_CAPACITY == 0))
                        g_Category3NextButton.Enabled = false;
                    else
                        g_Category3NextButton.Enabled = true;
                }
                else
                    g_Category3NextButton.Enabled = false;

                if (m_iNavigationCategory3Point > 0)
                    g_Category3PreviousButton.Enabled = true;
                else
                    g_Category3PreviousButton.Enabled = false;
            }
            catch (Exception eee)
            {
            }
        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                    m_iNavigationCategory3Point++;
                else
                    return;

                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int categoryCounter = 0; categoryCounter < CATEGORY3PANEL_CAPACITY; categoryCounter++)
                {
                    if (category3ButtonList.Count > (CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + categoryCounter))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(CATEGORY3PANEL_CAPACITY * m_iNavigationCategory3Point + categoryCounter)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / CATEGORY3PANEL_CAPACITY) && (category3ButtonList.Count % CATEGORY3PANEL_CAPACITY == 0))
                        g_Category3NextButton.Enabled = false;
                    else
                        g_Category3NextButton.Enabled = true;
                }
                else
                    g_Category3NextButton.Enabled = false;

                if (m_iNavigationCategory3Point > 0)
                    g_Category3PreviousButton.Enabled = true;
                else
                    g_Category3PreviousButton.Enabled = false;
            }
            catch (Exception eee)
            {
            }
        }

        /*private void g_PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    m_iNavigationPoint++;
                }
                g_Category2Panel.Controls.Clear();
                for (int counter = 0; counter < CATEGORY2PANEL_CAPACITY; counter++)
                {
                    if (category2ButtonList.Count > (CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY) && (category2ButtonList.Count % CATEGORY2PANEL_CAPACITY) == 0)
                    {
                        g_NextButton.Enabled = false;
                    }
                    else
                    {
                        g_NextButton.Enabled = true;
                    }
                }
                else
                    g_NextButton.Enabled = false;

                if (m_iNavigationPoint > 0)
                {
                    g_PreviousButton.Enabled = true;
                }
                else
                {
                    g_PreviousButton.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }*/

        /*private void g_NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    m_iNavigationPoint++;
                }
                g_Category2Panel.Controls.Clear();
                for (int counter = 0; counter < CATEGORY2PANEL_CAPACITY; counter++)
                {
                    if (category2ButtonList.Count > (CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(CATEGORY2PANEL_CAPACITY * m_iNavigationPoint + counter)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / CATEGORY2PANEL_CAPACITY) && (category2ButtonList.Count % CATEGORY2PANEL_CAPACITY) == 0)
                    {
                        g_NextButton.Enabled = false;
                    }
                    else
                    {
                        g_NextButton.Enabled = true;
                    }
                }
                else
                    g_NextButton.Enabled = false;

                if (m_iNavigationPoint > 0)
                {
                    g_PreviousButton.Enabled = true;
                }
                else
                {
                    g_PreviousButton.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }*/

        
       

              
    }
}