using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS.Main;
using Managers.TableInfo;
using Microsoft.Reporting.WinForms;
using Managers.Customer;
using RMS.MemberShipCardNoManage;
using RmsRemote;
using Managers.Payment;
using RMS.TakeAway;
using System.Data.SqlClient;
using RMS.DataAccess;
using Managers.User;
using System.Collections;
using System.IO;
using ns;
using System.Net;
using System.Xml;
using RMSUI;
using RMS.Common.Config;
using RMS.Utility;
using RMSClient.DataAccess;

namespace RMS.TableOrder
{
    public partial class CTableOrderForm : BaseForm
    {
        #region "Declaration Area"



        private XmlDocument xmlDoc = null;
        private string currentDirectory = String.Empty;
        private List<CCategoryButton> parentCategoryButtonList; // For Food Menu

        private List<CCategoryButton> category2ButtonList;
        private List<CCategoryButton> category3ButtonList;
        private List<CCategoryButton> category4ButtonList;

        private List<CUserInfo> userList = new List<CUserInfo>();

        private int m_iParentNavigationPoint = 0;
        private int m_capacity = 10;

        private int m_iNavigationPoint = 0; //stores the point of navigation for Category2Panel 
        private int m_iNavigationCategory3Point = 0;//stores the point of navigation for ItemSelectionPanel 
        public int m_iType = 0;
        private Int64 orderID;
        public Int64 m_iTableNumber;
        private CCommonConstants m_cCommonConstants;
        private int m_iDataGridViewCurrentRowIndex = -1;
        private DataGridView m_dDataGridView;
        private int m_iSavedOrderedQty = 1;
        private bool m_bItemDescriptionClicked = false;
        private Decimal m_dDiscountAmount = 0;
        private string m_sDiscountType = "Fixed";

        private const int m_category_panel_capacity = 10;//11 old valu
        private const int m_food_item_panel_capacity = 18;//22 old value

        private DataSet dsCategory3 = new DataSet();
        private DataSet dsCategory4 = new DataSet();
        private DataSet dsCategory2 = new DataSet();
        private DataSet dsCategory1 = new DataSet();

        private DataSet dsParentCategory = new DataSet(); // Food Menu @Mahmud


        public string m_TerminalName = String.Empty;
        public string m_OperatorName = String.Empty;
        private string serviceCharge = "0";
        public string m_orderUserName = String.Empty;
        private bool m_customerEditStatus = false;
        private int m_printedCopy = 0;
        private double m_chargeAmount = 0.0;
        private string m_chargeType = "Fixed";
        private bool m_isKitchenPriceAvailable = false;
        private int m_barCopyNumber = 0;
        private bool m_isBarPriceAvailable = false;
        private Int64 m_customerID; //For showing the order log of table or takeaway type. If >0 then takeaway type order otherwise table type.
        private CResult m_objOrderLog = new CResult();
        private List<OrderLogInformation> m_objOrderLogInfo = new List<OrderLogInformation>();

        private double vat = Program.vat;

        private bool isVatEnabled = Program.isVatEnabled;
        public delegate void OnKeyBoardPressDelegate(keyboard textbox);
        private KeyBooardForm keyboardForm;
        private Membership membership = new Membership();

        #endregion

        #region "Initialization Area"

        public CTableOrderForm()
        {
            InitializeComponent();
            m_customerEditStatus = false;

            if (!isVatEnabled)
            {
                vat = 0.00;
            }


            lblOrderTotal.Text = String.Format("Sub Total: {0}", Program.currency);
            lblDiscount.Text = String.Format("Discount: {0}", Program.currency);
            lbltips.Text = String.Format("Service Charge: {0}", Program.currency);
            lbltotal.Text = String.Format("Total: {0}", Program.currency);
            lbvat.Text = String.Format("Vat: {0}", Program.currency);

            txtBoxSearchItem.ForeColor = Color.Gray;


            keyboardForm = new KeyBooardForm();
            keyboardForm.Location = new Point(50, 380);
            keyboardForm.Size = new Size(740, 320);
            keyboardForm.Hide();


        }

        public CTableOrderForm(Int64 inOrderID, int inType, Int64 inTableNumber)
        {
            InitializeComponent();

            if (!isVatEnabled)
            {
                vat = 0.00;
            }

            lblOrderTotal.Text = String.Format("Order Total: {0}", Program.currency);
            lblDiscount.Text = String.Format("Discount: {0}", Program.currency);
            lbltips.Text = String.Format("Service Charge: {0}", Program.currency);
            lbltotal.Text = String.Format("Total: {0}", Program.currency);
            lbvat.Text = String.Format("Vat Total: {0}", Program.currency);






            try
            {
                orderID = inOrderID;
                m_iTableNumber = inTableNumber;
                m_iType = inType;
                m_customerEditStatus = false;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

            txtBoxSearchItem.ForeColor = Color.Gray;

            keyboardForm = new KeyBooardForm();
            keyboardForm.Location = new Point(50, 380);
            keyboardForm.Size = new Size(740, 320);
            keyboardForm.Hide();


        }

        private void Init()
        {

            try
            {
                m_sDiscountType = "Fixed";
                m_dDiscountAmount = 0;

                parentCategoryButtonList = new List<CCategoryButton>();

                category2ButtonList = new List<CCategoryButton>();
                category3ButtonList = new List<CCategoryButton>();
                category4ButtonList = new List<CCategoryButton>();
                m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();


                //New Addition at 04/08/2011
                String ConnectionString = m_cCommonConstants.DBConnection;
                SqlDataAdapter daParentCategory = new SqlDataAdapter(SqlQueries.GetQuery(Query.ParentCategoryGetAll), ConnectionString);
                daParentCategory.Fill(dsParentCategory, "ParentCategory");
                daParentCategory.Dispose();
                //New Addition at 08/08/2008
                SqlDataAdapter daCategory3 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category3GetAll), ConnectionString);
                daCategory3.Fill(dsCategory3, "Category3");
                daCategory3.Dispose();

                SqlDataAdapter daCategory4 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category4GetAll), ConnectionString);
                daCategory4.Fill(dsCategory4, "Category4");
                daCategory4.Dispose();

                SqlDataAdapter tempSqlDataAdapter5 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category2GetAll), ConnectionString);
                tempSqlDataAdapter5.Fill(dsCategory2, "Category2");
                tempSqlDataAdapter5.Dispose();


                SqlDataAdapter tempSqlDataAdapter6 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category1GetAll), ConnectionString);
                tempSqlDataAdapter6.Fill(dsCategory1, "Category1");
                tempSqlDataAdapter6.Dispose();

                if (m_cCommonConstants.UserInfo == null)
                    return;


                //Remove Items .This code will be optimized later
                CUserManager tempUserManager = new CUserManager();
                /*CUserAccess tempUserAccess2 = (CUserAccess)tempUserManager.GetUserAccess(m_cCommonConstants.UserInfo).Data;
                if (tempUserAccess2.RemoveItems == 1)
                    g_RemoveButton.Enabled = true;
                 else
                    g_RemoveButton.Enabled = false;*/

                if (m_iType == m_cCommonConstants.TableType)
                    this.g_ConvertButton.Text = "";
                else if (m_iType == m_cCommonConstants.TakeAwayType)
                    this.g_ConvertButton.Text = "Convert to Table";
                // For Food Menu @Mahmud
                foreach (DataRow tempDataRow in Program.initDataSet.Tables["ParentCategory"].Rows)
                {
                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["parent_cat_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["parent_cat_order"].ToString());
                    tempCategoryButton.CategoryLevel = 0;
                    tempCategoryButton.Text = tempDataRow["parent_cat_name"].ToString();



                    tempCategoryButton.Width = 110;//new at 05.03.2010            //   OLD PARENT CATEGORY SIZE AND COLOR
                    tempCategoryButton.Height = tempCategoryButton.Height - 1;
                    tempCategoryButton.BackColor = Color.LightSeaGreen;//Parent colour Change


                    ////tempCategoryButton.Width = 170;
                    ////tempCategoryButton.Height = tempCategoryButton.Height + 10;         // CHANGE MITHU
                    ////tempCategoryButton.BackColor = Color.Firebrick;


                    //#try
                    //#{
                    //# tempCategoryButton.BackColor = Color.FromArgb(Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                    //#  Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                    //#  Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                    //#}
                    //#catch (Exception exp)
                    //#{
                    //# Console.Write(exp.Message);
                    //#}
                    //tempCategoryButton.BackColor = Color.FromName(tempDataRow["cat2_color"].ToString());

                    tempCategoryButton.Click += new EventHandler(parentCategoryButton_Click);
                    parentCategoryButtonList.Add(tempCategoryButton);
                }
                // For Food Menu @Mahmud
                foodMenuPanal.Controls.Clear();

              

                foreach (CCategoryButton pcb in parentCategoryButtonList)
                {
                 //   foodMenuPanal.Controls.Add(pcb);

                    if (m_iParentNavigationPoint != 0)
                    {
                        foodMenuPanal.Controls.Clear();
                        for (int counter = 0; counter < m_capacity; counter++)
                        {
                            if (parentCategoryButtonList.Count > (m_capacity * m_iParentNavigationPoint + counter))
                            {
                                foodMenuPanal.Controls.Add(parentCategoryButtonList[(m_capacity * m_iParentNavigationPoint + counter)]);
                            }
                        }

                        if (m_iParentNavigationPoint < (parentCategoryButtonList.Count / m_capacity))
                        {
                            if ((m_iParentNavigationPoint + 1) == (parentCategoryButtonList.Count / m_capacity) && (parentCategoryButtonList.Count % m_capacity) == 0)
                            {
                                btnNextParent.Enabled = false;
                            }
                            else
                            {
                                btnNextParent.Enabled = true;
                            }
                        }
                        else
                            btnNextParent.Enabled = false;

                        if (m_iParentNavigationPoint > 0)
                            btnPrevParent.Enabled = true;
                        else
                            btnPrevParent.Enabled = false;
                    }


                    else
                    {
                        foodMenuPanal.Controls.Clear();
                        for (int counter = 0; counter < m_capacity && counter < parentCategoryButtonList.Count; counter++)
                        {
                            foodMenuPanal.Controls.Add(parentCategoryButtonList[counter]);
                        }

                        if (parentCategoryButtonList.Count > m_capacity)
                            btnNextParent.Enabled = true;
                        else
                            btnNextParent.Enabled = false;
                        btnPrevParent.Enabled = false;
                    }
                 //   #endregion

                }


                this.LoadStatusBar();

                if (m_customerEditStatus == true)//If customer edit button is pressed.This function is called for getting the latest information after modification
                {
                    this.FillSummary();
                    m_customerEditStatus = false;
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }


        }

        /// <summary>
        /// This function loads the items details information.
        /// </summary>
        private void LoadOrderDetails()
        {
           g_FoodDataGridView.Rows.Clear();
           g_BeverageDataGridView.Rows.Clear();
            FillRMSDataGridView();
            g_FoodDataGridView.ClearSelection();
            g_BeverageDataGridView.ClearSelection();

            if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
            {
                COrderManager tempOrderManager = new COrderManager();
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                CResult oResult = tempOrderManager.OrderDetailsByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;

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

                    int tempFoodType = 1;
                    if (tempCategoryLevel == 3)
                    {
                        tempFoodType = int.Parse(Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempProductID)[0].GetParentRow(Program.initDataSet.Relations["category2_to_category3"])["cat2_type"].ToString());
                    }
                    else if (tempCategoryLevel == 4)
                    {
                        int tempCat3_id = int.Parse(Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0].GetParentRow(Program.initDataSet.Relations["category3_to_category4"])["cat3_id"].ToString());
                        tempFoodType = int.Parse(Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCat3_id)[0].GetParentRow(Program.initDataSet.Relations["category2_to_category3"])["cat2_type"].ToString());
                    }
                    else
                    {
                        tempFoodType = -1;
                    }

                    DataGridView tempDataGridView = new DataGridView();
                    if (tempFoodType == 1)//Food Type
                    {
                        tempDataGridView = g_FoodDataGridView;
                    }
                    else if (tempFoodType == 0)//Nonfood Type
                    {
                        tempDataGridView = g_BeverageDataGridView;
                    }
                    else if (tempFoodType == -1)
                    {
                        if (tempOrderDetailsList[itemIndex].OrderFoodType == "Food")
                        {
                            tempDataGridView = g_FoodDataGridView;
                        }
                        else
                        {
                            tempDataGridView = g_BeverageDataGridView;
                        }
                    }

                    //if remarks exists append it... otherwise append nothing...
                    bool sele = false;
                    string appendString = "";
                    if (tempCategoryLevel != 0)
                        appendString = (tempOrderDetailsList[itemIndex].OrderRemarks.Equals("")) ? ("") : (" (" + tempOrderDetailsList[itemIndex].OrderRemarks + ")");

                    string[] tempDataGridViewRow = { 
                    tempProductName+appendString, 
                    tempOrderDetailsList[itemIndex].OrderQuantity.ToString(),
                     ((double)tempOrderDetailsList[itemIndex].VatTotal).ToString("F02"),
                    ((double)tempOrderDetailsList[itemIndex].OrderAmount).ToString("F02"),
                    tempOrderDetailsList[itemIndex].ProductID.ToString(),
                    tempOrderDetailsList[itemIndex].CategoryLevel.ToString(),
                    (Int64.MaxValue-1)+"",//max rank
                    tempOrderDetailsList[itemIndex].OrderDetailsID.ToString(),
                    tempOrderDetailsList[itemIndex].PrintedQuantity.ToString(),
                     tempOrderDetailsList[itemIndex].UnitPrice.ToString("F2"),
      
                    };

                    //not misc item... rank is specified
                    if (tempCategoryLevel != 0)
                    {
                        try
                        {
                            tempDataGridViewRow[6] = Program.initDataSet.Tables["Category" + tempCategoryLevel].Select("cat" + tempCategoryLevel + "_id = " + tempProductID)[0]["cat" + tempCategoryLevel + "_rank"].ToString();
                        }
                        catch { }
                    }
                    try
                    {
                        tempDataGridView.Rows.Add(tempDataGridViewRow);
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.ToString());
                    }
                    
                    ConvertRank();
                    if (tempDataGridView.Columns["Order_details_id"] !=null)
                    tempDataGridView.Sort(tempDataGridView.Columns["Order_details_id"], ListSortDirection.Descending);

                    if (tempDataGridView.Columns["dataGridViewTextBoxColumn5"] != null)
                        tempDataGridView.Sort(tempDataGridView.Columns["dataGridViewTextBoxColumn5"], ListSortDirection.Descending);


                    //this.FillCategory1OrderNumber();//New 
                    //tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                    tempDataGridView.Update();
                }

                //get discount
                COrderDiscount tempOrderDiscount = new COrderDiscount();
                oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDiscount = (COrderDiscount)oResult.Data;
                    m_dDiscountAmount = Convert.ToDecimal(tempOrderDiscount.Discount.ToString("F02"));
                }
            }
            else
            {
                //Loading the online orders information
                //g_FoodDataGridView.RowCount = 0;
                COrderManager tempOrderManager = new COrderManager();
                string remarks = "";
                string itemName = "";
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                CResult oResult = tempOrderManager.GetOnlineOrderDetailsByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;
                for (int counter = 0; counter < tempOrderDetailsList.Count; counter++)
                {
                    remarks = tempOrderDetailsList[counter].OrderRemarks.ToString();
                    itemName = tempOrderDetailsList[counter].ItemName.ToString();

                    if (remarks.Length > 0)
                    {
                        itemName = itemName + "(" + remarks + ")";
                    }
                    string[] tempDataGridViewRow = { 
                    itemName,
                    tempOrderDetailsList[counter].OrderQuantity.ToString(),
                    tempOrderDetailsList[counter].OrderAmount.ToString("F02"),
                    tempOrderDetailsList[counter].CategoryID.ToString(),
                    tempOrderDetailsList[counter].CategoryLevel.ToString(),
                    tempOrderDetailsList[counter].Rank.ToString(),
                    tempOrderDetailsList[counter].OrderDetailsID.ToString(),
                    tempOrderDetailsList[counter].PrintedQuantity.ToString(),
                    tempOrderDetailsList[counter].UnitPrice.ToString("F2"),
                    };

                    if (tempOrderDetailsList[counter].OrderFoodType.Replace(" ", "").ToUpper() == "Food".Replace(" ", "").ToUpper())
                    {
                        g_FoodDataGridView.Rows.Add(tempDataGridViewRow);
                        g_FoodDataGridView.Sort(g_FoodDataGridView.Columns[5], ListSortDirection.Ascending);
                    }
                    else
                    {
                        g_BeverageDataGridView.Rows.Add(tempDataGridViewRow); //If drinks 
                        g_BeverageDataGridView.Sort(g_BeverageDataGridView.Columns[5], ListSortDirection.Ascending);
                    }
                }

                //get discount
                COrderDiscount tempOrderDiscount = new COrderDiscount();
                oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDiscount = (COrderDiscount)oResult.Data;
                    m_dDiscountAmount = Convert.ToDecimal(tempOrderDiscount.Discount.ToString("F02"));
                }
            }
            this.TotalAmountCalculation();

          g_FoodDataGridView.ClearSelection();
           g_BeverageDataGridView.ClearSelection();
            try
            {
                this.SetPrintedItemBackColor(); //set the back color
            }
            catch { }
        }



        private void SetPrintedItemBackColor()
        {
            foreach (DataGridViewRow dgvRow in g_FoodDataGridView.Rows)
            {
                if (!Convert.ToString(dgvRow.Cells[1].Value).Equals("") && (Convert.ToInt32("0" + dgvRow.Cells[1].Value) == Convert.ToInt32(dgvRow.Cells[8].Value)) && (Convert.ToInt32(dgvRow.Cells[8].Value) > 0))
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.Empty;
                }
            }


            foreach (DataGridViewRow dgvRow in g_BeverageDataGridView.Rows)
            {
                if (!Convert.ToString(dgvRow.Cells[1].Value).Equals("") && (Convert.ToInt32("0" + dgvRow.Cells[1].Value) == Convert.ToInt32(dgvRow.Cells[8].Value)) && (Convert.ToInt32(dgvRow.Cells[8].Value) > 0))
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }


        private void FillCategory1OrderNumber()
        {
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
            {
                DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                if (!tempRow.Cells[0].Value.ToString().Equals(""))
                {
                    Int64 productID = Int64.Parse(tempRow.Cells[3].Value.ToString());
                    Int32 productLevel = Int32.Parse(tempRow.Cells[4].Value.ToString());
                    string categoryID = this.GetCategory1ID(productID, productLevel);
                    Int32 category1orderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(categoryID));
                    tempRow.Cells[7].Value = category1orderNumber.ToString();
                }
            }
            g_FoodDataGridView.Sort(g_FoodDataGridView.Columns[7], ListSortDirection.Ascending);
        }


        #endregion

        #region "Manupulation Area"

        /// <summary>
        /// Loading the customer information for the takeaway order.
        /// </summary>
        private void FillSummary()
        {
            try
            {
                CCustomerManager tempCustomerManager = new CCustomerManager();
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                CResult oResult = tempCustomerManager.GetCustomerTakeawayInfo(orderID);
                tempCustomerInfo = (CCustomerInfo)oResult.Data;

                m_customerID = tempCustomerInfo.CustomerID;

                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                {
                    m_objOrderLog = tempCustomerManager.GetOrderLogInformation(orderID);
                    m_objOrderLogInfo = (List<OrderLogInformation>)m_objOrderLog.Data;
                }
                else
                {
                    m_objOrderLog = tempCustomerManager.GetOnlineOrderLogInformation(orderID);
                    m_objOrderLogInfo = (List<OrderLogInformation>)m_objOrderLog.Data;
                }

                if (tempCustomerInfo.CustomerID > 0) //If takeaway type order then shows the customer information
                {
                    g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                    CustomerControl objCustomer = new CustomerControl(orderID, this, m_objOrderLogInfo);
                    g_ItemSelectionFlowLayoutPanel.Controls.Add(objCustomer);
                }
                else //For table order
                {
                    g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                    TableInformationControl objTableInfo = new TableInformationControl(orderID, this, m_objOrderLogInfo);
                    g_ItemSelectionFlowLayoutPanel.Controls.Add(objTableInfo);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// This function searches for the items in the gridview
        /// </summary>
        /// <param name="inDataGridView"></param>
        /// <param name="inValue"></param>
        /// <returns></returns>
        private int FindExistingItem(DataGridView inDataGridView, string inValue)
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
                Console.Write(exp.Message);
            }
            return -1;
        }

        /// <summary>
        /// Total Orders amount calculation
        /// </summary>
        /// <returns></returns>
        private Decimal GetOrderTotal()
        {
            Decimal tempTotal = 0;
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
            {
                if (g_FoodDataGridView[2, rowIndex].Value != null && !g_FoodDataGridView[3, rowIndex].Value.ToString().Equals(""))
                {
                    tempTotal += decimal.Parse(g_FoodDataGridView[3, rowIndex].Value.ToString());
                }
            }
            for (int beverageCounter = 0; beverageCounter < g_BeverageDataGridView.Rows.Count; beverageCounter++)
            {
                if (g_BeverageDataGridView[3, beverageCounter].Value != null && !g_BeverageDataGridView[3, beverageCounter].Value.ToString().Equals(""))
                {
                    tempTotal += decimal.Parse(g_BeverageDataGridView[3, beverageCounter].Value.ToString());
                }
            }
            return tempTotal;
        }

        /// <summary>
        /// Total amount in the gridview of the selected order
        /// </summary>
        private void TotalAmountCalculation()
        {
            try
            {
                Decimal MainFoodTotal = 0;//@Salim Only for Main Item with out additional service charge or discount
                Decimal vatTotal = 0;
                Decimal tempTotal = 0;
                for (int foodCounter = 0; foodCounter < g_FoodDataGridView.Rows.Count; foodCounter++)
                {
                    if (g_FoodDataGridView[3, foodCounter].Value != null && !g_FoodDataGridView[2, foodCounter].Value.ToString().Equals(""))
                    {
                        tempTotal += Decimal.Parse(g_FoodDataGridView[3, foodCounter].Value.ToString());
                        vatTotal += Decimal.Parse(g_FoodDataGridView[2, foodCounter].Value.ToString());
                    }
                }
                for (int beverageCounter = 0; beverageCounter < g_BeverageDataGridView.Rows.Count; beverageCounter++)
                {
                    if (g_BeverageDataGridView[3, beverageCounter].Value != null && !g_BeverageDataGridView[2, beverageCounter].Value.ToString().Equals(""))
                    {
                        tempTotal += Decimal.Parse(g_BeverageDataGridView[3, beverageCounter].Value.ToString());
                        try
                        {
                            vatTotal += Decimal.Parse(g_BeverageDataGridView[2, beverageCounter].Value.ToString());
                        }
                        catch { }
                    }
                }
                MainFoodTotal = tempTotal;
                Decimal discountAmount = 0;
                decimal membershipDiscountAmount = 0;
                if (m_sDiscountType.Equals("Fixed"))
                {
                    discountAmount = m_dDiscountAmount;
                }
                else if (m_sDiscountType.Equals("Percent"))
                {
                    discountAmount = MainFoodTotal * m_dDiscountAmount / 100;    // HOW CAN THIS BE CALCULATED IN SUCH WAY


                }

                COrderManager tempOrderManager = new COrderManager();
                COrderDiscount tempOrderDiscount = new COrderDiscount();
                CResult oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
                double itemDiscount = 0;
                if (oResult.IsSuccess && oResult.Data != null)
                {

                    tempOrderDiscount = (COrderDiscount)oResult.Data;
                    itemDiscount = tempOrderDiscount.TotalItemDiscount;


                    if (membership != null && membership.id > 0)
                    {
                        tempOrderDiscount.clientID = membership.customerID;
                        tempOrderDiscount.membershipCardID = membership.mebershipCardID;
                        tempOrderDiscount.membershipID = membership.id;
                        tempOrderDiscount.membershipPoint = membership.point;
                        tempOrderDiscount.membershipDiscountRate = membership.discountPercentRate;
                        if (tempOrderDiscount.membershipDiscountRate > 0)
                        {
                            tempOrderDiscount.membershipTotalPoint = 0;
                            tempOrderDiscount.membershipDiscountAmount = float.Parse(tempTotal.ToString()) * tempOrderDiscount.membershipDiscountRate / 100;


                        }
                        else
                        {
                            tempOrderDiscount.membershipTotalPoint = float.Parse(tempTotal.ToString()) * tempOrderDiscount.membershipTotalPoint / 100;
                            tempOrderDiscount.membershipDiscountAmount = 0;
                        }
                    }
                    else if (tempOrderDiscount.membershipID > 0 && tempOrderDiscount.membershipDiscountRate > 0)
                    {
                        tempOrderDiscount.membershipTotalPoint = 0;
                        tempOrderDiscount.membershipDiscountAmount = float.Parse(tempTotal.ToString()) * tempOrderDiscount.membershipDiscountRate / 100;

                    }

                    //update
                    tempOrderDiscount.Discount = Convert.ToDouble(discountAmount);
                    discountAmount = (decimal)tempOrderDiscount.Discount;
                    tempOrderManager.UpdateOrderDiscount(tempOrderDiscount);

                    lblMembershipDiscountValue.Text = tempOrderDiscount.membershipDiscountAmount.ToString("F2");
                    membershipDiscountAmount = decimal.Parse(tempOrderDiscount.membershipDiscountAmount.ToString());
                }
                else
                {
                    //insert
                    tempOrderDiscount.OrderID = orderID;
                    tempOrderDiscount.Discount = Convert.ToDouble(discountAmount);
                    discountAmount = (decimal)tempOrderDiscount.Discount;

                    if (membership != null && membership.id > 0)
                    {
                        tempOrderDiscount.clientID = membership.customerID;
                        tempOrderDiscount.membershipCardID = membership.mebershipCardID;
                        tempOrderDiscount.membershipID = membership.id;
                        tempOrderDiscount.membershipPoint = membership.point;
                        tempOrderDiscount.membershipDiscountRate = membership.discountPercentRate;

                        if (tempOrderDiscount.membershipDiscountRate > 0)
                        {
                            tempOrderDiscount.membershipTotalPoint = 0;
                            tempOrderDiscount.membershipDiscountAmount = float.Parse(tempTotal.ToString()) * tempOrderDiscount.membershipDiscountRate / 100;

                            lblMembershipDiscountValue.Text = tempOrderDiscount.membershipDiscountAmount.ToString("F2");
                        }
                        else
                        {
                            tempOrderDiscount.membershipTotalPoint = float.Parse(tempTotal.ToString()) * tempOrderDiscount.membershipTotalPoint / 100;
                            tempOrderDiscount.membershipDiscountAmount = 0;
                        }
                    }

                    tempOrderManager.InsertOrderDiscount(tempOrderDiscount);

                    lblMembershipDiscountValue.Text = tempOrderDiscount.membershipDiscountAmount.ToString("F2");
                    membershipDiscountAmount = decimal.Parse(tempOrderDiscount.membershipDiscountAmount.ToString());
                }

                #region "Service Charge"
                ServiceCharge tempOrderCharge = new ServiceCharge();
                CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
                double chargeAmount = 0.000;
                if (m_chargeType.Equals("Fixed"))
                {
                    if (cResult.IsSuccess && cResult.Data != null)
                    {
                        tempOrderCharge = (ServiceCharge) cResult.Data;
                        chargeAmount = tempOrderCharge.ServiceChargeAmount;
                    }
                }
                else if (m_chargeType.Equals("Percent"))
                {
                    //  chargeAmount = tempTotal * m_chargeAmount / 100;

                    chargeAmount = Convert.ToDouble(MainFoodTotal) * m_chargeAmount / 100;
                }
              
                if (cResult.IsSuccess && cResult.Data != null)
                {
                    tempOrderCharge = (ServiceCharge)cResult.Data;

                    //update
                    tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                    tempOrderManager.UpdateOrderServiceCharge(tempOrderCharge);
                }

                else
                {
                   // UpdateServiceCharge();
                    //insert
                  //  tempOrderCharge.OrderID = orderID;
                   // tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                   // tempOrderManager.InsertOrderServiceCharge(tempOrderCharge);
                }
                g_serviceCharge.Text = chargeAmount.ToString("F02");
               

                #endregion

                g_SubtotalLabel.Text = MainFoodTotal.ToString("F02");

                tempTotal = MainFoodTotal - discountAmount;

                decimal d = decimal.Round(decimal.Parse(discountAmount.ToString()), 2);
                g_DiscountLabel.Text = discountAmount.ToString("F02");
                tempTotal = tempTotal + decimal.Parse(g_serviceCharge.Text);

                //   lblVat.Text = (tempTotal * Convert.ToDecimal(vat / 100)).ToString("F02");

                // lblVat.Text = (MainFoodTotal * Convert.ToDecimal(vat / 100)).ToString("F02");

                lblVat.Text=vatTotal.ToString();
                tempTotal = MainFoodTotal + decimal.Parse(g_serviceCharge.Text) + decimal.Parse(lblVat.Text) - decimal.Parse(g_DiscountLabel.Text)-membershipDiscountAmount-(decimal) itemDiscount;
                g_AmountLabel.Text = tempTotal.ToString("F02");


                TableValueStatusLabel.Text = " Total Value £" + tempTotal.ToString("F02");

                totalItemWiseDiscountlabel.Text = itemDiscount.ToString("F02");


                try
                {
                  //  UpdateServiceCharge();
                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }


        private int GetValidTableNumber(string TableType)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                List<int> tempTableNumberList = (List<int>)tempOrderManager.GetTableNumberList(TableType).Data;

                for (int tableIndex = 0; tableIndex < tempTableNumberList.Count; tableIndex++)
                {
                    if (tempTableNumberList[tableIndex] != (tableIndex + 1))
                    {
                        return (tableIndex + 1);
                    }
                    if ((tableIndex + 1) == tempTableNumberList.Count)
                        return tempTableNumberList[tableIndex] + 1;
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return 1;
        }

        /// <summary>
        /// Making table from datagridview
        /// </summary>
        /// <param name="inDataGridView"></param>
        /// <returns></returns>
        private DataTable MakeTableFromGridview(DataGridView inDataGridView)
        {
            DataTable tempDataTable = new DataTable();
            try
            {
                tempDataTable.Columns.Add("Item");
                tempDataTable.Columns.Add("Qty");
                tempDataTable.Columns.Add("Vat");
                tempDataTable.Columns.Add("Price");
                tempDataTable.Columns.Add("Catid");
                tempDataTable.Columns.Add("Catlevel");
                tempDataTable.Columns.Add("isdrink");
                tempDataTable.Columns.Add("rank");
                tempDataTable.Columns.Add("unitPrice");
                string grigName = inDataGridView.Name;

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
                    if(tempDGRow.Cells[2].Value!=null)
                    {
                        tempDataRow["Vat"] = tempDGRow.Cells[2].Value.ToString();
                    }
                    if (tempDGRow.Cells[3].Value != null)
                    {
                        tempDataRow["Price"] = tempDGRow.Cells[3].Value.ToString();
                    }
                    if (tempDGRow.Cells[4].Value != null)
                    {
                        tempDataRow["Catid"] = tempDGRow.Cells[4].Value.ToString();
                    }
                    if (tempDGRow.Cells[5].Value != null)
                    {
                        tempDataRow["Catlevel"] = tempDGRow.Cells[5].Value.ToString();
                    }
                    if (tempDGRow.Cells[6].Value != null)
                    {
                        tempDataRow["rank"] = tempDGRow.Cells[6].Value.ToString();
                    }

                    if (tempDGRow.Cells[8].Value != null)
                    {
                        tempDataRow["unitPrice"] = tempDGRow.Cells[8].Value.ToString();
                    }

                    if (grigName == "g_FoodDataGridView")
                    {
                        tempDataRow["isdrink"] = "0";
                    }
                    else
                    {
                        tempDataRow["isdrink"] = "1";
                    }

                    tempDataTable.Rows.Add(tempDataRow);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return tempDataTable;
        }

        /// <summary>
        /// Filling up the status bar informationlike-order reference 
        /// </summary>
        private void LoadStatusBar()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            UserStatusLabel.Text = " Logged in as " + oConstants.UserInfo.UserName + " ";
            m_OperatorName = oConstants.UserInfo.UserName;
            COrderManager oOrderManager = new COrderManager();
            COrderInfo oOrderInfo = new COrderInfo();
            CResult oResult = oOrderManager.OrderInfoByOrderID(orderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderInfo = (COrderInfo)oResult.Data;
            }

            if (oOrderInfo.OrderType.Equals("Table"))
            {
                TableStatusLabel.Text = " Table No. " + oOrderInfo.TableNumber + " ";
                GuestStatusLabel.Text = " No. of Guests - " + oOrderInfo.GuestCount + " ";
                GuestStatusLabel.Visible = true;

                this.ScreenTitle = "Table No : " + oOrderInfo.TableNumber + " | No. of Guests : " + oOrderInfo.GuestCount + " ";
            }
            else if (oOrderInfo.OrderType.Equals("TakeAway"))
            {
                TableStatusLabel.Text = " Take Away ";
                GuestStatusLabel.Visible = false;
                this.ScreenTitle = "Take Away ";
            }

            BillNoStatusLabel.Text = " Reference No. " + oOrderInfo.SerialNo.ToString() + " ";
        }

        /// <summary>
        /// Fill grid view to the default rankings
        /// </summary>
        private void FillRMSDataGridView()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

            int recordCounter = g_FoodDataGridView.RowCount;

            if (recordCounter < oConstants.TableOrderFoodGrid)
            {
                for (int iterator = recordCounter; iterator < oConstants.TableOrderFoodGrid; iterator++)
                {
                    string[] str = { "", "", "", "", "", Int64.MaxValue.ToString(), "" };
                    g_FoodDataGridView.Rows.Add(str);
                }
            }

            recordCounter = g_BeverageDataGridView.RowCount;

            if (recordCounter < oConstants.TableOrderBeverageGrid)
            {
                for (int iterator = recordCounter; iterator < oConstants.TableOrderBeverageGrid; iterator++)
                {
                    string[] str = { "", "", "", "", "", Int64.MaxValue.ToString(), "" };
                    g_BeverageDataGridView.Rows.Add(str);
                }
            }
        }

        /// <summary>
        /// Convert rank from items information
        /// </summary>
        private void ConvertRank()
        {
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
            {
                g_FoodDataGridView[5, rowIndex].Value = Int64.Parse(g_FoodDataGridView[5, rowIndex].Value.ToString());
            }

            for (int beverageCounter = 0; beverageCounter < g_BeverageDataGridView.RowCount; beverageCounter++)
            {
                g_BeverageDataGridView[5, beverageCounter].Value = Int64.Parse(g_BeverageDataGridView[5, beverageCounter].Value.ToString());
            }
        }

        /// <summary>
        /// This functions retuns the category 1 order number
        /// </summary>
        /// <param name="p_categoryID"></param>
        /// <returns></returns>
        private Int32 GetCategory1OrderNumber(Int32 p_categoryID)
        {
            Int32 category1OrderNumber = 0;
            DataRow[] dtRow = Program.initDataSet.Tables["Category1"].Select("cat1_id = " + p_categoryID);
            if (dtRow.Length > 0)
            {
                category1OrderNumber = Convert.ToInt32("0" + dtRow[0]["Cat1_order_number"]);
            }
            return category1OrderNumber;
        }

        /// <summary>
        /// Printing at the kitchen
        /// </summary>
        private void KitchenPrint()
        {
            int papersize = 29;
            StringPrintFormater strPrintFormatter = new StringPrintFormater(29);
            Hashtable htOrderedItems = new Hashtable();
            SortedList slOrderedItems = null;

            try
            {
                bool itemAvailable = false;
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();
                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                COrderManager tempOrderManager = new COrderManager();
                CResult oResult = tempOrderManager.OrderInfoByOrderID(orderID);
                COrderInfo tempOrderInfo = new COrderInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }

                if (oConstant.KitchenPrintFlag == 1)
                {
                    bool otherfoodprint = false;
                    bool foodprint = false;
                    string serialHeader = "";
                    string serialFooter = "";
                    string serialBody = "";
                    string serialBody2 = "";
                    if (m_iType == m_cCommonConstants.TableType)
                    {
                        //serialBody += "\r\n\r\n        Table Number:" + m_iTableNumber.ToString();
                        serialBody += "Table Number:\r\n" + m_iTableNumber.ToString();
                        serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();
                    }

                     serialBody += "\n\r\n";
                    serialBody += strPrintFormatter.CenterTextWithWhiteSpace("Kitchen Copy");

                    if (!tempOrderInfo.Status.Equals("Seated") && m_iType == m_cCommonConstants.TableType)
                    {
                        //serialBody += "\r\nReprint";
                        serialBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Reprint");
                    }
                    serialBody += "\r\n\r\nOrder ID:" + orderID.ToString();
                    serialBody += "\r\n\r\nOrder Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody += "\r\nPrint Date:" + DateTime.Now.ToString("dd/MM/yy hh:mm tt");

                    if (m_iType == m_cCommonConstants.TableType)
                    {
                        //serialBody += "\r\n\r\n        Table Number:" + m_iTableNumber.ToString();
                        //serialBody += "\r\n\n\r\nTable Number:" + m_iTableNumber.ToString();
                        //serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();

                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName +"\r\n";
                        }
                    }
                    else if (m_iType == m_cCommonConstants.TakeAwayType)
                    {
                        //Waiter for Takeway
                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName + "\r\n";
                        }
                        //serialBody += "\r\n\r\n        Take Away";
                        serialBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Take Away");
                        serialBody += "\r\nType: " + tempOrderInfo.Status;

                        CCustomerManager tempCustomerManager = new CCustomerManager();
                        CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                        if (tempCustomerInfo.CustomerName.Length > 0) //If customer name is present
                        {
                            serialBody += "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                        }
                        if (tempCustomerInfo.CustomerPhone.Length > 0) //If customer phone number is available
                        {
                            serialBody += "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                        }


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

                            //serialBody += "\r\n----------------------------------------";

                            serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                            CDelivery objDelivery = new CDelivery();
                            objDelivery.DeliveryOrderID = orderID;
                            CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                            objDelivery = (CDelivery)objDeliveryInfo.Data;

                            serialBody += "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                        }
                    }

                    //serialBody += "\r\n\r\nOrder Information";

                    serialBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Order Information");
                    //serialBody += "\r\n---------------------------------";

                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                    if (m_isKitchenPriceAvailable == true)
                    {
                        //serialBody += "\r\nQty Item                      Price(" + Program.currency.ToString() + ")";
                        serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");

                    }
                    else
                    {
                        serialBody += "\r\nQty Item";
                        
                    }
                    serialBody2 = serialBody;
                    // serialBody += "\r\n---------------------------------";

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        string cat1ID = String.Empty;
                        string cat2ID = String.Empty;
                        string cat3ID = String.Empty;

                        string separatorCatID = String.Empty;
                        string category2Order = String.Empty; //Printing order will be according to category2 order

                        for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
                        {
                            DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                            category2Order = String.Empty;

                            if (!tempRow.Cells[0].Value.ToString().Equals(""))
                            {
                               // Int64 productID = Int64.Parse(tempRow.Cells[3].Value.ToString());
                               // Int32 productLevel = Int32.Parse(tempRow.Cells[4].Value.ToString());
                                Int64 productID = Int64.Parse(tempRow.Cells[4].Value.ToString());
                                Int32 productLevel = Int32.Parse(tempRow.Cells[5].Value.ToString());

                                if (productLevel == 3)
                                {
                                    DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + productID);
                                    if (dtRow.Length > 0)
                                    {
                                        cat2ID = dtRow[0]["cat2_id"].ToString();
                                    }
                                    cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["category1_to_category2"])["cat1_id"].ToString();
                                }
                                else if (productLevel == 4)
                                {

                                    DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + productID);
                                    if (dtRow.Length > 0)
                                    {
                                        cat3ID = dtRow[0]["cat3_id"].ToString();
                                        if (cat3ID != "" || cat3ID != null)
                                        {
                                            dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                        }
                                        else
                                        {
                                            dtRow = null;
                                        }
                                    }

                                    if (dtRow.Length > 0)
                                    {
                                        cat2ID = dtRow[0]["cat2_id"].ToString();
                                    }
                                    cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["category1_to_category2"])["cat1_id"].ToString();//Not necessary
                                }
                                else if (productLevel == 0)// && inFoodType.Equals("Indian")) //If miscellenious foods. 
                                {
                                    cat1ID = "0";
                                    cat2ID = "0";
                                }

                                #region "New "
                                CCategory3DAO aDao = new CCategory3DAO();
                                string printstatus = aDao.GetAllCategory3printareaByCategory3ID((int)productID);
                                clsOrderReport objOrderedItems = new clsOrderReport();
                               // objOrderedItems.Quantity = Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString());
                               // objOrderedItems.ItemName = tempRow.Cells[0].Value.ToString();
                              //  objOrderedItems.Price = Convert.ToDouble("0" + tempRow.Cells[2].Value.ToString());

                                //For vat grid index
                                objOrderedItems.Quantity = Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString());
                                objOrderedItems.ItemName = tempRow.Cells[0].Value.ToString();
                                objOrderedItems.Price = Convert.ToDouble("0" + tempRow.Cells[3].Value.ToString());
                                objOrderedItems.PrintArea = printstatus;

                                //htOrderedItems.Add(cat2ID + "-" + objOrderedItems.ItemName, objOrderedItems);

                                //Int64 rankNumber = Int64.Parse(tempRow.Cells[5].Value.ToString());
                                //For Vat
                                Int64 rankNumber = Int64.Parse(tempRow.Cells[6].Value.ToString());

                                Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));

                                htOrderedItems.Add(category1OrderNumber + "-" + rankNumber.ToString() + "-" + objOrderedItems.ItemName, objOrderedItems);// Category 1 wise
                                #endregion
                                itemAvailable = true;//For drinks.When drinks is avalable then no separator is used.
                            }
                        }

                        NumericComparer ncomp = new NumericComparer();
                        slOrderedItems = new SortedList(htOrderedItems, ncomp);

                        int keyIndex = 0;
                        SortedList slMiscellaneousItems = new SortedList();
                        PrintUtility printUtility = new PrintUtility();

                        string[] valueSplitter = new string[0];
                        foreach (clsOrderReport objReport in slOrderedItems.Values)
                        {
                            string keyValue = slOrderedItems.GetKey(keyIndex).ToString();
                            valueSplitter = keyValue.Split('-');

                            if ((separatorCatID.Trim() != valueSplitter[0].ToString().Trim()) && (valueSplitter[0].ToString().Trim() != "0"))//Insert separator
                            {
                                ////serialBody += "\r\n---------------------------------";
                                //serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                                //separatorCatID = valueSplitter[0].ToString().Trim();

                                ///*serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                //serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);*/

                                ////serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim(),  objReport.ItemName.ToString());

                                //if (m_isKitchenPriceAvailable == true)
                                //{
                                //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                //        printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize-3), "");                                    
                                //}
                                //else
                                //{
                                //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                //     printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 5, "", papersize), "");                                                                        

                                //}

                                if (objReport.PrintArea == "Otherfood")
                                {

                                    otherfoodprint = true;
                                    serialBody2 += "\r\n" + strPrintFormatter.CreateDashedLine();
                                    separatorCatID = valueSplitter[0].ToString().Trim();

                                    //serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";

                                    // serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));

                                        serialBody2 += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else
                                    {
                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, "");
                                        serialBody2 += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 5, "",
                                                                                    papersize), "");

                                    }

                                }
                                else
                                {

                                    foodprint = true;
                                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                                    separatorCatID = valueSplitter[0].ToString().Trim();

                                    //serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";

                                    // serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));

                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else
                                    {
                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, "");
                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 5, "",
                                                                                    papersize), "");

                                    }
                                }


                            }
                            else if (valueSplitter[0].ToString() == "0")
                            {
                                slMiscellaneousItems.Add(slMiscellaneousItems.Count, objReport);
                            }
                            else
                            {
                                ///*serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                //serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);*/

                                ////  serialBody += "\r\n" + strPrintFormatter.SumupLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString()," ");

                                //if (m_isKitchenPriceAvailable == true)
                                //{
                                //    //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);
                                //  //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), objReport.Price.ToString("F02"));
                                //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                //      printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize-3), "");                                    

                                //}
                                //else
                                //{
                                //    //serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), "");

                                //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                //     printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 5, "", papersize), "");                                    
                                //}

                                if (objReport.PrintArea == "Otherfood")
                                {
                                    otherfoodprint = true;
                                    //serialBody2 += "\r\n" + objReport.Quantity.ToString() + "  ";
                                    //serialBody2 += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);
                                        //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("\r\n" + objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));
                                        serialBody2 += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else {
                                        serialBody2 += "\r\n" + objReport.Quantity.ToString() + "  ";
                                        serialBody2 += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    }
                                }
                                else
                                {
                                    foodprint = true;
                                    //serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                    //serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);
                                        //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("\r\n" + objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));
                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else
                                    {
                                        serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                        serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    }
                                }




                            }
                            keyIndex++;
                        }

                        if (slMiscellaneousItems.Count > 0)
                        {
                            foodprint = true;
                            //serialBody += "\r\n----------Miscellaneous----------"; //separator for miscellaneous 
                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscelaneous");
                            
                            foreach (clsOrderReport objReport in slMiscellaneousItems.Values)
                            {
                                /*serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                 serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);*/

                                // serialBody += "\r\n" + strPrintFormatter.SumupLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), "");


                                if (m_isKitchenPriceAvailable == true)
                                {
                                    //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                   // serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), objReport.Price.ToString("F02"));
                                    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                     printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize-3), "");                                    
                                }

                                else
                                {
                                   // serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), "");
                                    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString().Trim() + "  " +
                                     printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 5, "", papersize), "");                                    
                                }
                            }
                        }

                        //string[] kitchenCommand = new string[0];
                        //kitchenCommand = tempOrderInfo.InitialKitchenText.Split(',');

                        //serialBody += "\r\n---------------------------------";
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody2 += "\r\n" + strPrintFormatter.CreateDashedLine();
                        CResult objKitchenText = tempOrderManager.GetKitchenTextByOrderID(orderID);
                        List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();

                        tempOrderLogInfoList = (List<OrderLogInformation>)objKitchenText.Data;

                        if (tempOrderLogInfoList.Count > 0)
                        {
                            serialBody += "\r\nKT Txt:";
                            serialBody2 += "\r\nKT Txt:";
                        }
                        for (int recordCounter = 0; recordCounter < tempOrderLogInfoList.Count; recordCounter++)
                        {
                            if (tempOrderLogInfoList[recordCounter].KitchenTextPrintStatus < 1)
                            {
                                serialBody += "\r\n- " + tempOrderLogInfoList[recordCounter].KitchenText;
                                serialBody += "\r\n- " + tempOrderLogInfoList[recordCounter].KitchenText;
                            }
                        }


                        serialBody += "\r\nOrder Prepared By:" + m_OperatorName;
                        serialBody += "\r\n" + m_TerminalName;

                        serialBody += "\r\n\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("[ E N D ]") + "\r\n\r\n";
                        serialBody2 += "\r\nOrder Prepared By:" + m_OperatorName;
                        serialBody2 += "\r\n" + m_TerminalName;

                        serialBody2 += "\r\n\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("[ E N D ]") + "\r\n\r\n";
                        //tempPrintMethods.SerialPrint(PRINTER_TYPES.KITCHEN_PRINTER, serialHeader, serialBody, serialFooter);

                        // string fullKitchenPrinttext=serialHeader+"\r\n"+serialBody+"\r\n"+serialFooter;
                        // tempPrintMethods.USBPrint(fullKitchenPrinttext, PrintDestiNation.KITCHEN, false);

                        if (itemAvailable == true) //If there is available items
                        {
                            ///Kitchen Print call
                            ///
                            CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                            tempPrintingFormat.Header = serialHeader;
                            tempPrintingFormat.Body = serialBody.ToUpper();
                            tempPrintingFormat.Footer = serialFooter;
                            tempPrintingFormat.OrderID = orderID;
                            tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;
                            CPrintingFormat tempPrintingFormat1 = new CPrintingFormat();
                            tempPrintingFormat1.Header = serialHeader;
                            tempPrintingFormat1.Body = serialBody2.ToUpper();
                            tempPrintingFormat1.Footer = serialFooter;
                            tempPrintingFormat1.OrderID = orderID;
                            tempPrintingFormat1.PrintType = (int)PRINTER_TYPES.Serial;

                            CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();

                            CLogin oLogin = new CLogin();
                            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                            for (int printCopy = 0; printCopy < m_printedCopy; printCopy++)
                            {
                                if (foodprint)
                                {
                                    string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body +
                                                      "\r\n" + tempPrintingFormat.Footer;
                                    cPrintMethods.USBPrint(fulltext, PrintDestiNation.KITCHEN, false);
                                }
                                if (otherfoodprint)
                                {
                                    string fulltext = tempPrintingFormat1.Header + "\r\n" + tempPrintingFormat1.Body + "\r\n" + tempPrintingFormat1.Footer;
                                    cPrintMethods.USBPrint(fulltext, PrintDestiNation.Other, false);
                                }
                            }

                            if (tempOrderLogInfoList.Count > 0) //If kitchen command is available.
                            {
                                this.UpdateKitchenTextPrintStatus();
                            }
                            this.WriteString(serialBody);//Writing to the specified file
                        }
                    }
                    else //For online orders all items
                    {
                        bool isItemsAvailable = false;
                        foodprint = false;
                        otherfoodprint = false;
                        serialBody += "\r\n---------------------------------";
                        for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
                        {
                          //  Int64 productID = Int64.Parse(tempRow.Cells[4].Value.ToString());
                            if (g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() != String.Empty)
                            {
                                Int64 productID = Int64.Parse(g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString());
                                CCategory3DAO aDao = new CCategory3DAO();
                                string printstatus = aDao.GetAllCategory3printareaByCategory3ID((int)productID);

                                if (printstatus == "Otherfood")
                                {
                                    otherfoodprint = true;
                                    serialBody2 += "\r\n" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() +
                                                  "  ";
                                    serialBody2 +=
                                        CPrintMethods.GetFixedString(
                                            g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString(), 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        serialBody2 += "  " +
                                                      CPrintMethods.RightAlign(
                                                          Convert.ToDouble("0" +
                                                                           g_FoodDataGridView.Rows[rowIndex].Cells[2].
                                                                               Value).ToString("F02"), 6);
                                    }
                                } else
                                {
                                    foodprint = true;
                                    serialBody += "\r\n" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() +
                                                  "  ";
                                    serialBody +=
                                        CPrintMethods.GetFixedString(
                                            g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString(), 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        serialBody += "  " +
                                                      CPrintMethods.RightAlign(
                                                          Convert.ToDouble("0" +
                                                                           g_FoodDataGridView.Rows[rowIndex].Cells[2].
                                                                               Value).ToString("F02"), 6);
                                    }

                                }
                                isItemsAvailable = true;
                            }
                        }
                        serialBody += "\r\n---------------------------------";
                        serialBody += "\r\nKT Txt:" + tempOrderInfo.InitialKitchenText;
                        serialBody += "\r\n---------------------------------";
                        serialBody += "\r\nOrder Prepared By:" + m_OperatorName;

                        serialBody += "\r\n\r\n          [ E N D ]\r\n\r\n";

                        serialBody2 += "\r\n---------------------------------";
                        serialBody2 += "\r\nKT Txt:" + tempOrderInfo.InitialKitchenText;
                        serialBody2 += "\r\n---------------------------------";
                        serialBody2 += "\r\nOrder Prepared By:" + m_OperatorName;

                        serialBody2 += "\r\n\r\n          [ E N D ]\r\n\r\n";

                        if (isItemsAvailable == false)//If there is no items in the datagrid view
                        {
                            return;
                        }
                        else
                        {
                            if (foodprint)
                            {
                                CPrintingFormat tempPrintingFormat = new CPrintingFormat();

                                CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();
                                tempPrintingFormat.Header = serialHeader;
                                tempPrintingFormat.Body = serialBody.ToUpper();

                                tempPrintingFormat.Footer = serialFooter;
                                tempPrintingFormat.OrderID = orderID;
                                tempPrintingFormat.PrintType = (int) PRINTER_TYPES.Serial;

                                CLogin oLogin = new CLogin();
                                oLogin =
                                    (RmsRemote.CLogin)
                                    Activator.GetObject(typeof (RmsRemote.CLogin), oConstant.RemoteURL);
                                // oLogin.PostPrintingRequest(tempPrintingFormat);

                                string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body + "\r\n" +
                                                  tempPrintingFormat.Footer;
                                cPrintMethods.USBPrint(fulltext, PrintDestiNation.KITCHEN, false);


                                this.WriteString(serialBody); //Writing to the specified file
                            }
                            if (otherfoodprint)
                            {
                                CPrintingFormat tempPrintingFormat = new CPrintingFormat();

                                CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();
                                tempPrintingFormat.Header = serialHeader;
                                tempPrintingFormat.Body = serialBody2.ToUpper();

                                tempPrintingFormat.Footer = serialFooter;
                                tempPrintingFormat.OrderID = orderID;
                                tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                                CLogin oLogin = new CLogin();
                                oLogin =
                                    (RmsRemote.CLogin)
                                    Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                                // oLogin.PostPrintingRequest(tempPrintingFormat);

                                string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body + "\r\n" +
                                                  tempPrintingFormat.Footer;
                                cPrintMethods.USBPrint(fulltext, PrintDestiNation.Other, false);


                                this.WriteString(serialBody); //Writing to the specified file
                            }
                        }
                    }


                    if (tempOrderInfo.Status.Equals("Seated") && tempOrderInfo.OrderType.Equals("Table"))
                    {
                        tempOrderInfo.Status = "Ordered";
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridView FilterByFoodType(DataGridView inDataGridView, string inFoodType)
        {
            DataGridView tempDataGridView = new DataGridView();
            tempDataGridView.Columns.Add(inDataGridView.Columns[0]);
            tempDataGridView.Columns.Add(inDataGridView.Columns[1]);
            tempDataGridView.Columns.Add(inDataGridView.Columns[2]);
            return tempDataGridView;
        }

        private string GetCategoryName(int categoryID)
        {
            string categoryName = "";
            foreach (DataRow tempDataRow in Program.initDataSet.Tables["Category2"].Rows)
            {
                if (categoryID == int.Parse(tempDataRow["cat2_id"].ToString()))
                {
                    categoryName = tempDataRow["cat2_name"].ToString();
                }
            }

            return categoryName;
        }

        private string GetCategory1ID(Int64 productID, Int32 productLevel)
        {
            string cat1ID = "";
            string cat2ID = "";
            string cat3ID = "";
            if (productLevel == 3)
            {
                DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + productID);
                if (dtRow.Length > 0)
                {
                    cat2ID = dtRow[0]["cat2_id"].ToString();
                }
                cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["category1_to_category2"])["cat1_id"].ToString();
            }
            else if (productLevel == 4)
            {
                DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + productID);
                if (dtRow.Length > 0)
                {
                    cat3ID = dtRow[0]["cat3_id"].ToString();
                    if (cat3ID != "" || cat3ID != null)
                    {
                        dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                    }
                    else
                    {
                        dtRow = null;
                    }
                }

                if (dtRow.Length > 0)
                {
                    cat2ID = dtRow[0]["cat2_id"].ToString();
                }
                //cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["_to_category2"])["cat1_id"].ToString();//Not necessary // Change by Mithu


            }
            return cat1ID;
        }

        /// <summary>
        /// Writes all the data to the specified file 
        /// </summary>
        /// <param name="s"></param>
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
        #endregion


        #region  "UI Events"

        private void CTableOrderForm_Shown(object sender, EventArgs e)
        {
            g_FoodDataGridView.ClearSelection();
            g_BeverageDataGridView.ClearSelection();
        }
        private void parentCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                category2ButtonList.Clear();
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                CCategoryButton parentCategoryButton = (CCategoryButton)sender;
                int parentCategoryButtonID = parentCategoryButton.CategoryID;
                // MessageBox.Show(parentCategoryButton.Text);
                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
                String tempConnStr = oTempDal.ConnectionString;
                SqlConnection conn = new SqlConnection(tempConnStr);
                DataTable table = new DataTable();
                try
                {
                    string sql = "select c2.cat2_id,c2.cat2_name,c2.cat2_order,c2.cat2_color from  category2 c2,category1 c1 where c1.cat1_id=c2.cat1_id and c1.parent_cat_id=" + parentCategoryButtonID;

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, tempConnStr);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);


                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                    dataAdapter.Fill(table);

                    dataAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

                if (table != null)
                {
                    //DataSet dsCategory2 = table[0];

                    foreach (DataRow tempDataRow in table.Rows)
                    {
                        CCategoryButton tempCategoryButton = new CCategoryButton();
                        tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat2_id"].ToString());
                        tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat2_order"].ToString());
                        tempCategoryButton.CategoryLevel = 2;




                        tempCategoryButton.Text = tempDataRow["cat2_name"].ToString();
                        tempCategoryButton.Width = 110;//new at 05.03.2010                // OLD CATEGORY2 SIZE 
                        tempCategoryButton.Height = tempCategoryButton.Height - 1;


                        //tempCategoryButton.Text = tempDataRow["cat2_name"].ToString();
                        //    h= 160;//new at 05.03.2010                     //  OLD CATEGORY2 SIZE  MITHU
                        //tempCategoryButton.Height = tempCategoryButton.Height + 10;


                        try
                        {
                            tempCategoryButton.BackColor = Color.FromArgb(Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                                Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                                Int32.Parse(tempDataRow["cat2_color"].ToString().Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                        }
                        catch (Exception exp)
                        {
                            Console.Write(exp.Message);
                        }
                        //tempCategoryButton.BackColor = Color.FromName(tempDataRow["cat2_color"].ToString());
                        tempCategoryButton.Click += new EventHandler(Category2Button_Click);
                        category2ButtonList.Add(tempCategoryButton);
                    }
                    #region "Added by Baruri at 14.10.2008 for resolving the navigation point"
                    if (m_iNavigationPoint != 0)
                    {
                        g_Category2Panel.Controls.Clear();
                        for (int counter = 0; counter < m_category_panel_capacity; counter++)
                        {
                            if (category2ButtonList.Count > (m_category_panel_capacity * m_iNavigationPoint + counter))
                            {
                                g_Category2Panel.Controls.Add(category2ButtonList[(m_category_panel_capacity * m_iNavigationPoint + counter)]);
                            }
                        }

                        if (m_iNavigationPoint < (category2ButtonList.Count / m_category_panel_capacity))
                        {
                            if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / m_category_panel_capacity) && (category2ButtonList.Count % m_category_panel_capacity) == 0)
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


                    else
                    {
                        g_Category2Panel.Controls.Clear();
                        for (int counter = 0; counter < m_category_panel_capacity && counter < category2ButtonList.Count; counter++)
                        {
                            g_Category2Panel.Controls.Add(category2ButtonList[counter]);
                        }

                        if (category2ButtonList.Count > m_category_panel_capacity)
                            g_NextButton.Enabled = true;
                        else
                            g_NextButton.Enabled = false;
                        g_PreviousButton.Enabled = false;
                    }
                    #endregion
                    // this.LoadStatusBar();
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
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
                    if (Int32.Parse(tempDataRow["status"].ToString()) == 0)
                    {
                        continue;
                    }

                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat3_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat3_order"].ToString());
                    tempCategoryButton.CategoryLevel = 3;
                    tempCategoryButton.SellingQuantityorWeight = Convert.ToString(tempDataRow["selling_in"]);

                    tempCategoryButton.Text = tempDataRow["cat3_name"].ToString();
                    tempCategoryButton.BackColor = tempCategory2Button.BackColor;
                    tempCategoryButton.Width = 130;
                    tempCategoryButton.FlatAppearance.BorderColor = Color.Black;
                    tempCategoryButton.FlatStyle = FlatStyle.Popup;

                    if (tempDataRow["productType"].ToString()=="Finished")
                    {
                    tempCategoryButton.Click += new EventHandler(Category3Button_Click);
                    category3ButtonList.Add(tempCategoryButton);
                    }
                }
                m_iNavigationCategory3Point = 0;
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();

                for (int iterator = 0; iterator < m_food_item_panel_capacity && iterator < category3ButtonList.Count; iterator++)
                {
                    g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[iterator]);
                }

                if (category3ButtonList.Count > m_food_item_panel_capacity)
                {
                    g_Category3NextButton.Enabled = true;
                }
                else
                {
                    g_Category3NextButton.Enabled = false;
                }

                if (m_iNavigationCategory3Point > 0)
                {
                    g_Category3PreviousButton.Enabled = true;
                }
                else
                {
                    g_Category3PreviousButton.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void Category3Button_Click(object sender, EventArgs e)
        {

            //get item qty

            CCategoryButton tempCategory3Button = (CCategoryButton)sender;
            RMSGlobal.m_sellinginvalue = tempCategory3Button.SellingQuantityorWeight; //Used to identify the product whether sold in quantity or weight

            int tempCategory3ID = tempCategory3Button.CategoryID;
            if (m_bItemDescriptionClicked)
            {
                string tempItemDescription = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3ID)[0]["description"].ToString();
                if (!tempItemDescription.Equals(""))
                {
                    CMessageBox tempMessageBox = new CMessageBox("Item Description", tempItemDescription);
                    tempMessageBox.ShowDialog();
                }
                else
                {
                    CMessageBox tempMessageBox = new CMessageBox("Item Description", "No information available.");
                    tempMessageBox.ShowDialog();
                }
                m_bItemDescriptionClicked = false;
                return;
            }

            int tempFoodType = int.Parse(Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3ID)[0].GetParentRow(Program.initDataSet.Relations["category2_to_category3"])["cat2_type"].ToString());
            DataGridView tempDataGridView = new DataGridView();
            if (tempFoodType == 0)
            {
                tempDataGridView = g_BeverageDataGridView;
            }
            else
            {
                tempDataGridView = g_FoodDataGridView;
            }

            DataRow[] tempDataRowArray = Program.initDataSet.Tables["Category4"].Select("cat3_id = " + tempCategory3ID.ToString());

            category4ButtonList.Clear();

            COrderInfoDAO aOrderInfoDao = new COrderInfoDAO();
            COrderInfo aCOrderInfo = aOrderInfoDao.GetOrderInfoByOrderID(orderID);

            if (tempDataRowArray.Length != 0)
            {


                foreach (DataRow tempDataRow in tempDataRowArray)
                {
                    if (Int32.Parse(tempDataRow["status"].ToString()) == 0)
                    {
                        continue;
                    }
                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat4_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat4_order"].ToString());
                    tempCategoryButton.CategoryLevel = 4;
                    tempCategoryButton.Text = tempDataRow["cat4_name"].ToString();
                    tempCategoryButton.BackColor = tempCategory3Button.BackColor;
                    category4ButtonList.Add(tempCategoryButton);
                }

                keyboardForm.Hide();
                CCategory4Form tempCategory4Form = new CCategory4Form(tempCategory3ID, category4ButtonList, tempCategory3Button.Text);
                tempCategory4Form.ShowDialog();

                CCategoryButton tempCategory4Button = CCategory4Form.m_cbResult;
                m_iSavedOrderedQty = CCategory4Form.ItemQTY;
                if (tempCategory4Button == null)
                {
                    return;
                }
                else   //insert into table and datagridview
                {
                    DataRow[] temp2DataRowArray = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempCategory4Button.CategoryID.ToString());
                    if (temp2DataRowArray.Length != 0)
                    {
                        //category4 + categpry3
                        string ItemName = temp2DataRowArray[0]["cat4_name"].ToString() + " " + tempCategory3Button.Text;
                        string tableTypePrice = string.Empty;
                        if (m_iType == m_cCommonConstants.TableType)
                        {
                            tableTypePrice = temp2DataRowArray[0]["table_price"].ToString();
                        }
                        else if (m_iType == m_cCommonConstants.TakeAwayType)
                        {
                            tableTypePrice = temp2DataRowArray[0]["tw_price"].ToString();
                        }

                        int tempSearchResult = FindExistingItem(tempDataGridView, ItemName);


                        // vat_included
                        double vatRate = 0;
                        bool vat_included = false;
                        double vatAmountRate = 0;
                        try
                        {
                            vatRate = Convert.ToDouble(temp2DataRowArray[0]["vat_Rate"].ToString());
                            vat_included = Convert.ToBoolean(temp2DataRowArray[0]["vat_included"].ToString());

                            if (vat_included)
                            {
                                vatAmountRate = (Double.Parse(tableTypePrice) * vatRate) / 100;

                                // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
                                tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
                            }
                            else
                            {
                                vatAmountRate = 0.00;
                            }


                        }
                        catch (Exception ex) { }

                        COrderManager tempOrderManager = new COrderManager();
                        COrderDetails tempOrderDetails = new COrderDetails();
                       

                        if (tempSearchResult != -1)
                        {
                            int tempRowIndex = tempSearchResult;
                            int qty = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                            tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
                            tempDataGridView.Rows[tempRowIndex].Cells[3].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
                            //update Order_details table
                            tempOrderDetails.OrderID = orderID;
                            tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[7].Value.ToString());
                            tempOrderDetails.ProductID = tempCategory4Button.CategoryID;
                            tempOrderDetails.CategoryLevel = tempCategory4Button.CategoryLevel;
                            tempOrderDetails.OrderQuantity = qty;
                            tempOrderDetails.UnitPrice = Convert.ToDouble(tableTypePrice);
                            tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                            tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                            tempOrderDetails.OnlineItemSequenceNumber = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[6].Value.ToString());
                            tempOrderDetails.PrintedQuantity = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[8].Value.ToString());

                            if (aCOrderInfo.VatComplementory) vatRate =vatAmountRate= 0;
                            if (vat_included)
                            {
                                // tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * vatAmountRate;
                                tempOrderDetails.VatTotal = qty * vatAmountRate;
                                tempDataGridView.Rows[tempRowIndex].Cells[2].Value = qty * vatAmountRate;
                            }
                            else
                            {
                                tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * (vatRate / 100);
                            }

                            if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                            {
                                tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                            }
                            else
                            {
                                tempOrderManager.UpdateOnlineOrderDetails(tempOrderDetails);//for online orders
                            }
                        }
                        else
                        {
                            //Insert into Order_details table
                            tempOrderDetails.OrderID = orderID;
                            tempOrderDetails.ProductID = tempCategory4Button.CategoryID;
                            tempOrderDetails.CategoryLevel = tempCategory4Button.CategoryLevel;
                            tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                            tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                            tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                            tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                            tempOrderDetails.UnitPrice = Convert.ToDouble(tableTypePrice);
                          //  tempOrderDetails.Product_Name = temp2DataRowArray[0]["cat3_name"].ToString();
                            if (aCOrderInfo.VatComplementory) vatRate = 0;
                            if (vat_included)
                            {
                                tempOrderDetails.VatTotal = 0;
                                tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * (vatRate / 100);
                                // tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * vatAmountRate;
                            }
                            else
                            {
                                tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * (vatRate / 100);
                            }

                            tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;

                            string category1ID = this.GetCategory1ID(tempOrderDetails.ProductID, tempOrderDetails.CategoryLevel);
                            //Int32 cat1Order = this.GetCategory1OrderNumber(Convert.ToInt32(category1ID)); // Change by Mithu

                            if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                            {
                                tempOrderDetails = (COrderDetails)tempOrderManager.InsertOrderDetails(tempOrderDetails).Data;
                                string[] tempDataGridViewRow = new string[] 
                                { ItemName, 
                                  m_iSavedOrderedQty.ToString(),
                                  ((double)tempOrderDetails.VatTotal).ToString("F02"),
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory4Button.CategoryID.ToString(),
                                  "4",
                                  temp2DataRowArray[0]["cat4_rank"].ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString(),
                                  "0",
                                  tempOrderDetails.UnitPrice.ToString("F2")
                                };

                                tempDataGridView.Rows.Add(tempDataGridViewRow);
                            }
                            else //For online orders
                            {
                                tempOrderDetails.ItemName = ItemName;
                                tempOrderDetails = (COrderDetails)tempOrderManager.InsertOnlineOrderDetails(tempOrderDetails).Data;
                                string[] tempDataGridViewRow = new string[] 
                                { ItemName, 
                                  m_iSavedOrderedQty.ToString(), 
                                  ((double)tempOrderDetails.VatTotal).ToString("F02"),
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory4Button.CategoryID.ToString(),
                                  "4",
                                  tempOrderDetails.OnlineItemSequenceNumber.ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString(),"0",
                                  tempOrderDetails.UnitPrice.ToString("F2")
                                };

                                tempDataGridView.Rows.Add(tempDataGridViewRow);
                            }
                        }

                        if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper()) //If local orders are considered
                        {
                            this.ConvertRank();
                        }

                        tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);

                        tempDataGridView.Update();
                        TotalAmountCalculation();
                    }
                }
            }
            else //There is no category4
            {
                keyboardForm.Hide();
                try
                {
                    CCalculatorForm tempCalculatorForm = new CCalculatorForm("Order Quantity", "Item Quantity");
                    tempCalculatorForm.ShowDialog();

                    if (CCalculatorForm.inputResult.Equals("Cancel"))
                        return;

                    string str = CCalculatorForm.inputResult;
                    str = (str == "") ? "1" : str;

                    if (Int32.Parse(str) == 0)
                    {
                        CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                        tempMessageBox.ShowDialog();
                        return;
                    }

                    int tempOrderedQty = Int32.Parse(str);
                    m_iSavedOrderedQty = tempOrderedQty;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                DataGridViewRow tempDataGridViewRow = new DataGridViewRow();
                tempDataGridViewRow.CreateCells(tempDataGridView);

                DataRow[] temp2DataRowArray = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCategory3Button.CategoryID.ToString());
                if (temp2DataRowArray.Length != 0)
                {
                    string tableTypePrice = string.Empty;
                    if (m_iType == m_cCommonConstants.TableType)
                    {
                        tableTypePrice = temp2DataRowArray[0]["table_price"].ToString();
                    }
                    else if (m_iType == m_cCommonConstants.TakeAwayType)
                    {
                        tableTypePrice = temp2DataRowArray[0]["tw_price"].ToString();
                    }

                    // vat_included
                    double vatRate = 0;
                    bool vat_included = false;
                    double vatAmountRate = 0;
                 
                    try
                    {
                        vatRate = Convert.ToDouble(temp2DataRowArray[0]["vat_Rate"].ToString());
                        vat_included = Convert.ToBoolean(temp2DataRowArray[0]["vat_included"].ToString());

                        if (vat_included)
                        {
                            vatAmountRate = (Double.Parse(tableTypePrice) * vatRate) / 100;

                            // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
                            tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
                        }
                        else
                        {
                            vatAmountRate = 0.00;
                        }


                    }
                    catch (Exception ex) { }


                    COrderManager tempOrderManager = new COrderManager();
                    COrderDetails tempOrderDetails = new COrderDetails();

                    int tempResult = FindExistingItem(tempDataGridView, temp2DataRowArray[0]["cat3_name"].ToString());
                    if (tempResult != -1)
                    {
                        //update Order_details table
                        int tempRowIndex = tempResult;
                        int qty = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                        tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
                        tempDataGridView.Rows[tempRowIndex].Cells[3].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
                        tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[7].Value.ToString());
                        tempOrderDetails.OrderID = orderID;
                        tempOrderDetails.ProductID = tempCategory3Button.CategoryID;
                        tempOrderDetails.CategoryLevel = tempCategory3Button.CategoryLevel;
                        tempOrderDetails.UnitPrice = Convert.ToDouble(tableTypePrice);
                        tempOrderDetails.OrderQuantity = qty;
                        tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                        tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                        tempOrderDetails.OnlineItemSequenceNumber = Convert.ToInt64("0" + tempDataGridView.Rows[tempRowIndex].Cells[6].Value.ToString());
                        tempOrderDetails.PrintedQuantity = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[8].Value.ToString());
                        if (aCOrderInfo.VatComplementory) vatAmountRate = 0;
                        if (vat_included)
                        {
                            tempOrderDetails.VatTotal = qty * vatAmountRate;
                            tempDataGridView.Rows[tempRowIndex].Cells[2].Value = tempOrderDetails.VatTotal;
                        }
                        else
                        {
                            tempOrderDetails.VatTotal = 0.00;
                        }

                        if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                        {
                            tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                        }
                        else
                        {
                            tempOrderManager.UpdateOnlineOrderDetails(tempOrderDetails);
                        }

                    }
                    else
                    {
                        //Insert into Order_details table
                        tempOrderDetails.OrderID = orderID;
                        tempOrderDetails.ProductID = tempCategory3Button.CategoryID;
                        tempOrderDetails.CategoryLevel = tempCategory3Button.CategoryLevel;
                        tempOrderDetails.UnitPrice = Convert.ToDouble(tableTypePrice);
                        tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                        tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity * Double.Parse(tableTypePrice);
                        tempOrderDetails.OrderFoodType = tempFoodType == 1 ? ("Food") : ("Nonfood");
                        tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                        tempOrderDetails.Product_Name = temp2DataRowArray[0]["cat3_name"].ToString();
                        tempOrderDetails.UOM = temp2DataRowArray[0]["uom"].ToString();
                        tempOrderDetails.Product_Type = temp2DataRowArray[0]["productType"].ToString();
                        if (aCOrderInfo.VatComplementory) vatRate = vatAmountRate = 0;
                        try
                        {
                            if (vat_included)
                            {
                                tempOrderDetails.VatTotal = 0;
                                tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * (vatRate / 100);
                                // tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * vatAmountRate;
                            }
                            else
                            {
                                tempOrderDetails.VatTotal = tempOrderDetails.OrderAmount * (vatRate / 100);
                            }
                        }
                        catch { }

                        try
                        {
                            tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;

                        }
                        catch { }

                        string category1ID = this.GetCategory1ID(tempOrderDetails.ProductID, tempOrderDetails.CategoryLevel);
                        Int32 cat1Order = this.GetCategory1OrderNumber(Convert.ToInt32(category1ID));

                        if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                        {
                            tempOrderDetails = (COrderDetails)tempOrderManager.InsertOrderDetails(tempOrderDetails).Data;
                            string[] temp2DataGridViewRow = new string[] 
                                { temp2DataRowArray[0]["cat3_name"].ToString(), 
                                  m_iSavedOrderedQty.ToString(),
                                  tempOrderDetails.VatTotal.ToString("F2"),
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory3Button.CategoryID.ToString(),
                                  "3",
                                  temp2DataRowArray[0]["cat3_rank"].ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString(),"0",
                                    tempOrderDetails.UnitPrice.ToString("F2")
                                };
                            tempDataGridView.Rows.Add(temp2DataGridViewRow);
                        }
                        else
                        {
                            tempOrderDetails.ItemName = temp2DataRowArray[0]["cat3_name"].ToString();
                            tempOrderDetails = (COrderDetails)tempOrderManager.InsertOnlineOrderDetails(tempOrderDetails).Data;
                            string[] temp2DataGridViewRow = new string[] 
                                {temp2DataRowArray[0]["cat3_name"].ToString(),
                                  m_iSavedOrderedQty.ToString(),
                                    tempOrderDetails.VatTotal.ToString(),
                                  ((double)(Double.Parse(tableTypePrice)*m_iSavedOrderedQty)).ToString("F02"),
                                  tempCategory3Button.CategoryID.ToString(),
                                  "3",
                                  tempOrderDetails.OnlineItemSequenceNumber.ToString(),//For online order sequence number is category rank.
                                  tempOrderDetails.OrderDetailsID.ToString(),"0", //0 For first time.
                                  tempOrderDetails.UnitPrice.ToString("F2")
                                };
                            tempDataGridView.Rows.Add(temp2DataGridViewRow);
                        }
                    }

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        this.ConvertRank();
                    }
                    tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                    try
                    {
                        tempDataGridView.Update();
                    }
                    catch { }
                        TotalAmountCalculation();
                    
                    
                }
            }
            g_FoodDataGridView.ClearSelection();
            g_BeverageDataGridView.ClearSelection();
            m_iSavedOrderedQty = 1;

            keyboardForm.Hide();

            this.SetPrintedItemBackColor();

        }

        private void g_NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationPoint < (category2ButtonList.Count / m_category_panel_capacity))
                {
                    m_iNavigationPoint++;
                }
                g_Category2Panel.Controls.Clear();
                for (int capacityCounter = 0; capacityCounter < m_category_panel_capacity; capacityCounter++)
                {
                    if (category2ButtonList.Count > (m_category_panel_capacity * m_iNavigationPoint + capacityCounter))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(m_category_panel_capacity * m_iNavigationPoint + capacityCounter)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / m_category_panel_capacity))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / m_category_panel_capacity) && (category2ButtonList.Count % m_category_panel_capacity) == 0)
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
                Console.Write(exp.Message);
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
                g_Category2Panel.Controls.Clear();
                for (int i = 0; i < m_category_panel_capacity; i++)
                {
                    if (category2ButtonList.Count > (m_category_panel_capacity * m_iNavigationPoint + i))
                    {
                        g_Category2Panel.Controls.Add(category2ButtonList[(m_category_panel_capacity * m_iNavigationPoint + i)]);
                    }
                }

                if (m_iNavigationPoint < (category2ButtonList.Count / m_category_panel_capacity))
                {
                    if ((m_iNavigationPoint + 1) == (category2ButtonList.Count / m_category_panel_capacity) && (category2ButtonList.Count % m_category_panel_capacity) == 0)
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
                Console.Write(exp.Message);
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
                for (int counter = 0; counter < m_food_item_panel_capacity; counter++)
                {
                    if (category3ButtonList.Count > (m_food_item_panel_capacity * m_iNavigationCategory3Point + counter))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(m_food_item_panel_capacity * m_iNavigationCategory3Point + counter)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / m_food_item_panel_capacity))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / m_food_item_panel_capacity) && (category3ButtonList.Count % m_food_item_panel_capacity == 0))
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
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void g_Category3NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iNavigationCategory3Point < (category3ButtonList.Count / m_food_item_panel_capacity))
                    m_iNavigationCategory3Point++;

                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                for (int capacityCounter = 0; capacityCounter < m_food_item_panel_capacity; capacityCounter++)
                {
                    if (category3ButtonList.Count > (m_food_item_panel_capacity * m_iNavigationCategory3Point + capacityCounter))
                    {
                        g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[(m_food_item_panel_capacity * m_iNavigationCategory3Point + capacityCounter)]);
                    }
                }

                if (m_iNavigationCategory3Point < (category3ButtonList.Count / m_food_item_panel_capacity))
                {
                    if ((m_iNavigationCategory3Point + 1) == (category3ButtonList.Count / m_food_item_panel_capacity) && (category3ButtonList.Count % m_food_item_panel_capacity == 0))
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void g_ExitButton_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                CTableInfo tempTableInfo = new CTableInfo();
                tempTableInfo.TableNumber = m_iTableNumber;
                tempTableInfo.Status = 0;
                string tableType = "";
                if (m_iType == m_cCommonConstants.TableType)
                    tableType = "Table";
                else if (m_iType == m_cCommonConstants.TakeAwayType)
                    tableType = "TakeAway";
               tempTableInfo.TableType = tableType;
                //tempTableInfo.TableType = m_TerminalName;
                tempOrderManager.UpdateTableInfo(tempTableInfo);

                CMainForm tempMainForm = (CMainForm)CFormManager.Forms.Pop();
                tempMainForm.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void g_SpecialButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iDataGridViewCurrentRowIndex == -1)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Please select ordered food or beverage.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                CSpecialModifyForm tempKeyBoardForm = new CSpecialModifyForm();
                tempKeyBoardForm.ShowDialog();

                string sResult = CSpecialModifyForm.Content;
                if (sResult.Equals("") || sResult.Equals("Cancel"))
                {
                    return;
                }

                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper()) //For local order
                {
                    COrderManager tempOrderManager = new COrderManager();
                    COrderDetails tempOrderDetails = (COrderDetails)tempOrderManager.OrderDetailsByOrderDetailID(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString())).Data;

                    if (tempOrderDetails.OrderRemarks.Equals(""))
                    {
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value
                        = m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString() + " (" + sResult + ")";
                    }
                    else if (tempOrderDetails.CategoryLevel == 0)
                    {
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value
                        = m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString() + sResult;
                    }
                    else
                    {
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value
                        = m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString().Substring(0, m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells["Item"].Value.ToString().LastIndexOf('(')) + " (" + sResult + ")";
                    }

                    tempOrderDetails.OrderRemarks = sResult;
                    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                }
                else
                {
                    COrderManager tempOrderManager = new COrderManager();
                    COrderDetails tempOrderDetails = new COrderDetails();

                    if (sResult.Length > 0)
                    {
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value
                        = m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString() + " (" + sResult + ")";
                    }
                    tempOrderDetails.OnlineItemSequenceNumber = Convert.ToInt64(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value);
                    tempOrderDetails.OrderRemarks = sResult;
                    tempOrderManager.UpdateOnlineItemSpecial(tempOrderDetails);
                    this.LoadOrderDetails();
                }

                m_dDataGridView.Update();
                m_iDataGridViewCurrentRowIndex = -1;
                m_dDataGridView.ClearSelection();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int TotalItems()
        {
            int totalItems = 0;
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
            {
                if (!g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    totalItems += Convert.ToInt32("0" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString());
                }
            }

            for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
            {
                if (!g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    totalItems += Convert.ToInt32("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value.ToString());
                }
            }

            return totalItems;
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
                if (m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    return;
                }

                int totalQuantity = Convert.ToInt32(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString());
               // int printedQuantity = Convert.ToInt32(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value.ToString());
                int printedQuantity = Convert.ToInt32(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[8].Value.ToString());

                //If printed items are equal to total quantity or greater 
                if (totalQuantity <= printedQuantity)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Printed", "Current item(s) has already been sent to kitchen.");
                    tempMessageBox.ShowDialog();
                    return;
                }


                COrderManager tempOrderManager1 = new COrderManager();
                CResult oResult1 = tempOrderManager1.OrderDetailsByOrderDetailID(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value.ToString()));
                COrderDetails aDetails = new COrderDetails();
                if (oResult1.IsSuccess && oResult1.Data != null)
                {
                    aDetails = (COrderDetails)oResult1.Data;
                }
                if (aDetails.GuestPrintQuantity >= totalQuantity)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Printed", " All ready Guest Bill Printed so that impossible of item decrease");
                    tempMessageBox.ShowDialog();
                    return;
                }



                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".ToUpper().Replace(" ", "")) //If the order is not online order
                {

                    COrderManager tempOrderManager = new COrderManager();
                    //int qty = Int32.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString());
                    ////Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());

                    ////For Vat and Unit vat
                    //Double itemTotalVat = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());
                    //Double unitVat = itemTotalVat / qty;
                    //itemTotalVat = itemTotalVat - unitVat;
                    //Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value.ToString());
                    //Double unitPrice = amount / qty;


                    int qty = Int32.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString());
                    //Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());

                    //For Vat and Unit vat
                    Double itemTotalVat = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());
                    Double unitVat = itemTotalVat / qty;
                    // itemTotalVat = itemTotalVat - unitVat;
                    Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value.ToString());
                    Double unitPrice = amount / qty;



                    if (qty == 1)
                    {
                        tempOrderManager.DeleteOrderDetails(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value.ToString()));
                        m_dDataGridView.Rows.RemoveAt(m_iDataGridViewCurrentRowIndex);
                    }
                    else
                    {
                        qty = qty - 1;
                        if (qty < 1)
                        {
                            qty = 0;
                        }

                        COrderDetails tempOrderDetails = new COrderDetails();
                    //    CResult oResult = tempOrderManager.OrderDetailsByOrderDetailID(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString()));
                        CResult oResult = tempOrderManager.OrderDetailsByOrderDetailID(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value.ToString()));

                        if (oResult.IsSuccess && oResult.Data != null)
                        {
                            tempOrderDetails = (COrderDetails)oResult.Data;
                        }
                        //tempOrderDetails.OrderQuantity = qty;
                        //tempOrderDetails.OrderAmount = qty * unitPrice;
                        //tempOrderDetails.PrintedQuantity = tempOrderDetails.PrintedQuantity - 1;

                        //Add by deb
                        tempOrderDetails.OrderQuantity = qty;
                        tempOrderDetails.OrderAmount = qty * unitPrice;
                        tempOrderDetails.VatTotal = unitVat * qty;



                        if (tempOrderDetails.PrintedQuantity <= 0)
                        {
                            tempOrderDetails.PrintedQuantity = 0;
                        }
                        //tempOrderDetails.OrderDetailsID = Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString());
                        tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;
                        tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = qty;

                        //m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value = tempOrderDetails.PrintedQuantity;
                       // m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = ((double)(qty * unitPrice)).ToString("F02");
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[8].Value = tempOrderDetails.PrintedQuantity;
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value = ((double)(qty * unitPrice)).ToString("F02");
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = ((double)(unitVat * qty)).ToString("F02");

                    }
                }
                else //Proceed for online order
                {
                    if (this.TotalItems() < 2)
                    {
                        MessageBox.Show("You can not remove all the items from online", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    COrderManager tempOrderManager = new COrderManager();
                    int qty = Int32.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString());
                    Double amount = Double.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString());
                    Double unitPrice = amount / qty;
                    if (qty == 1)
                    {
                        tempOrderManager.DeleteOnlineOrderDetails(Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value.ToString())); //Taking the order sequence number.Here named category ranking 
                        m_dDataGridView.Rows.RemoveAt(m_iDataGridViewCurrentRowIndex);
                    }
                    else
                    {
                        qty = qty - 1;
                        if (qty < 1)
                        {
                            qty = 0;
                        }

                        COrderDetails tempOrderDetails = new COrderDetails();

                        tempOrderDetails.OrderQuantity = qty;
                        tempOrderDetails.OrderAmount = qty * unitPrice;
                        tempOrderDetails.OnlineItemSequenceNumber = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value);

                        tempOrderDetails.OrderDetailsID = Int64.Parse(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value.ToString());
                        tempOrderManager.UpdateOnlineOrderDetails(tempOrderDetails);
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = qty;


                        ///For printed items
                        int printedItems = Convert.ToInt32(m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value) - 1;
                        if (printedItems < 1)
                        {
                            printedItems = 0;
                        }
                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value = printedItems;

                        m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = ((double)(qty * unitPrice)).ToString("F02");
                    }
                }
                m_dDataGridView.Update();
                TotalAmountCalculation();
                m_dDataGridView.ClearSelection();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.SetPrintedItemBackColor(); //set the back color
        }

        private void g_ItemDescriptionButton_Click(object sender, EventArgs e)
        {
            m_bItemDescriptionClicked = true;
        }

        private void g_QuantityButton_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void g_ConvertButton_Click(object sender, EventArgs e)
        {
           
        }

        private void g_PayCloseButton_Click(object sender, EventArgs e)
        {
         



                try
                {
                    string tableType = "";
                    if (m_iType == m_cCommonConstants.TableType)
                        tableType = "Table";
                    else
                        tableType = "TakeAway";

                    DataTable tempItemTable = new DataTable();

                    tempItemTable = MakeTableFromGridview(g_FoodDataGridView);
                    int drinksIndex = tempItemTable.Rows.Count;
                    tempItemTable.Merge(MakeTableFromGridview(g_BeverageDataGridView));
                    if (drinksIndex == tempItemTable.Rows.Count)
                        drinksIndex = -1;

                    CPaymentForm tempPaymentForm = new CPaymentForm(orderID, Double.Parse(g_AmountLabel.Text) - Double.Parse("0" + g_serviceCharge.Text), tableType, tempItemTable, decimal.Parse(g_DiscountLabel.Text), drinksIndex, m_TerminalName, m_OperatorName, g_serviceCharge.Text, decimal.Parse(lblMembershipDiscountValue.Text));
                    // CPaymentForm tempPaymentForm = new CPaymentForm(orderID, Double.Parse(g_AmountLabel.Text) , tableType, tempItemTable, decimal.Parse(g_DiscountLabel.Text), drinksIndex, m_TerminalName, m_OperatorName, g_serviceCharge.Text);
                    CPaymentForm.m_orderUserName = m_orderUserName;
                    tempPaymentForm.Show();

                    CFormManager.Forms.Push(this);
                    this.Hide();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

          
            
        }

        private void g_FoodDataGridView_Click(object sender, EventArgs e)
        {
            if (g_FoodDataGridView.RowCount != 0)
            {
                m_iDataGridViewCurrentRowIndex = g_FoodDataGridView.CurrentRow.Index;
                m_dDataGridView = g_FoodDataGridView;
            }
            g_BeverageDataGridView.ClearSelection();
        }

        private void g_BeverageDataGridView_Click(object sender, EventArgs e)
        {
            if (g_BeverageDataGridView.RowCount != 0)
            {
                m_iDataGridViewCurrentRowIndex = g_BeverageDataGridView.CurrentRow.Index;
                m_dDataGridView = g_BeverageDataGridView;
            }
            g_FoodDataGridView.ClearSelection();
        }

        private void g_SendButton_Click(object sender, EventArgs e)
        {

            
                COrderManager objOrderManager = new COrderManager();
                SortedList slPrintingItems = new SortedList();
                //m_isKitchenCopyPrinted = false;//This variable is used to identify whether the online ordered items are prnted at kitchen or not.If true then printed


                KitchenPrintForm objKitchenPrint = new KitchenPrintForm();
                objKitchenPrint.ShowDialog();

                if (objKitchenPrint.DialogResult == DialogResult.Cancel)
                {
                    return;
                }


                try
                {

                    DataSet tempStockDataSet = new DataSet();
                    tempStockDataSet.ReadXml("Config/StockSetting.xml");

                    bool isAllowedToOrder = Convert.ToBoolean(tempStockDataSet.Tables[0].Rows[0]["AllowedtoOrder"].ToString());

                    if (!isAllowedToOrder)
                    {
                        if (!CheckStockControl())
                        {
                            return;
                        }
                    }

                }
                catch (Exception)
                {

                }

                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Mouse_Config.xml");

                if (!tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString().Equals(""))
                {
                    m_printedCopy = Convert.ToInt32("0" + tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString());
                }



                if (!tempDataSet.Tables[0].Rows[0]["BarCopyNumber"].ToString().Equals(""))
                {
                    m_barCopyNumber = Convert.ToInt32("0" + tempDataSet.Tables[0].Rows[0]["BarCopyNumber"].ToString());
                }


                if (!tempDataSet.Tables[0].Rows[0]["ShowPriceStatus"].ToString().Equals(""))
                {
                    if (Convert.ToString(tempDataSet.Tables[0].Rows[0]["ShowPriceStatus"].ToString()).Replace(" ", "").ToUpper() == "true".Replace(" ", "").ToUpper())
                    {
                        m_isKitchenPriceAvailable = true;
                    }
                    else
                    {
                        m_isKitchenPriceAvailable = false;
                    }
                }

                if (!tempDataSet.Tables[0].Rows[0]["BarPriceStatus"].ToString().Equals(""))
                {
                    if (Convert.ToString(tempDataSet.Tables[0].Rows[0]["BarPriceStatus"].ToString()).Replace(" ", "").ToUpper() == "true".Replace(" ", "").ToUpper())
                    {
                        m_isBarPriceAvailable = true;
                    }
                    else
                    {
                        m_isBarPriceAvailable = false;
                    }
                }

                int printingItem = KitchenPrintForm.m_PrintingItems;

                if (printingItem == 1)//Print all items
                {
                    KitchenPrint();//New

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        slPrintingItems = this.GetProductIdList(1);
                        objOrderManager.UpdatePrintedQuantity(slPrintingItems);
                    }
                    else
                    {
                        slPrintingItems = this.GetProductIdList(2);
                        objOrderManager.UpdateOnlineOrderPrintedQuantity(slPrintingItems);
                    }

                    this.PrintAllBeverage();

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        slPrintingItems = this.GetProductIdList(3);
                        objOrderManager.UpdatePrintedQuantity(slPrintingItems);
                    }
                    else
                    {
                        slPrintingItems = this.GetProductIdList(4);
                        objOrderManager.UpdateOnlineOrderPrintedQuantity(slPrintingItems);
                    }

                    this.LoadOrderDetails();
                }

                else if (printingItem == 2) //Print new food items
                {
                    KitchenCopyForNewFoodItems();

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        slPrintingItems = this.GetProductIdList(1);
                        objOrderManager.UpdatePrintedQuantity(slPrintingItems);
                    }
                    else
                    {
                        slPrintingItems = this.GetProductIdList(2);
                        objOrderManager.UpdateOnlineOrderPrintedQuantity(slPrintingItems);
                    }

                    this.PrintNewBeverage();

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        slPrintingItems = this.GetProductIdList(3);
                        objOrderManager.UpdatePrintedQuantity(slPrintingItems);
                    }
                    else
                    {
                        slPrintingItems = this.GetProductIdList(4);
                        objOrderManager.UpdateOnlineOrderPrintedQuantity(slPrintingItems);
                    }

                    this.LoadOrderDetails();
                
                btnOrderLog_Click(sender, e);
            }

            
        }


        /// <summary>
        /// Modification of the print status.After first print the command is not included with kitchen copy.
        /// </summary>
        private void UpdateKitchenTextPrintStatus()
        {
            COrderManager objOrderManager = new COrderManager();
            objOrderManager.UpdateOrderKitchenStatus(orderID);
        }

        private void PrintNewBeverage()
        {
            int papersize = 29;
            StringPrintFormater strPrintFormatter = new StringPrintFormater(29);

            string Cat1ID = String.Empty;
            bool blnToBePrinted = false;

            try
            {
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                //string serialHeader = "IBACS RMS";

                string serialHeader = "";
                string serialFooter = "";
                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                List<CSerialPrintContent> serialBody2 = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;
                //tempSerialPrintContent.StringLine = "               Beverages/Non-Food\n";

                if (m_iType == m_cCommonConstants.TableType)
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "             Table No:" + m_iTableNumber.ToString();

                    tempSerialPrintContent.StringLine = "Table No:\r\n" + m_iTableNumber.ToString();



                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();

                    //tempSerialPrintContent.StringLine = "             Guest No:" +tempOrderInfo.GuestCount.ToString() + "\r\n";
                    tempSerialPrintContent.StringLine = "Covers:" + tempOrderInfo.GuestCount.ToString();

                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Beverages/Non-Food");
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

            

                //string s=tempOrderInfo.
                if (m_iType == m_cCommonConstants.TableType)
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order ID:" + orderID.ToString();
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    ////tempSerialPrintContent.StringLine = "             Table No:" + m_iTableNumber.ToString();

                    //tempSerialPrintContent.StringLine = "\r\n\nTable No:" + m_iTableNumber.ToString();



                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    //serialBody2.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();

                    ////tempSerialPrintContent.StringLine = "             Guest No:" +tempOrderInfo.GuestCount.ToString() + "\r\n";
                    //tempSerialPrintContent.StringLine = "Covers:" + tempOrderInfo.GuestCount.ToString();

                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    //serialBody2.Add(tempSerialPrintContent);


                    COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                    COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                    if (orderWaiter != null && orderWaiter.WaiterID > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Waiter Name: " + orderWaiter.WaiterName +"\r\n" ;
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);
                    }
                    
                }
                else if (m_iType == m_cCommonConstants.TakeAwayType)
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Type:" + tempOrderInfo.Status;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Customer Name:" + tempCustomerInfo.CustomerName;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Phone:" + tempCustomerInfo.CustomerPhone;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Address:";
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();

                        //tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Floor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Building Name:" + tempCustomerInfo.BuildingName;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "House Number:" + tempCustomerInfo.HouseNumber;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
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
                                serialBody2.Add(tempSerialPrintContent);
                            }

                            if (street[1].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = street[1].ToString();
                                serialBody.Add(tempSerialPrintContent);
                                serialBody2.Add(tempSerialPrintContent);
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                                serialBody2.Add(tempSerialPrintContent);
                            }
                        }

                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Postal Code:" + tempCustomerInfo.CustomerPostalCode;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Town:" + tempCustomerInfo.CustomerTown;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        tempSerialPrintContent = new CSerialPrintContent();

                        //tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = orderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;
                        if (objDelivery != null)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Information";
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();

                //tempSerialPrintContent.StringLine = "----------------------------------------";

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                if (m_isBarPriceAvailable == true)
                {
                    //tempSerialPrintContent.StringLine = "Qty Item                      Price(" + Program.currency.ToString() + ")";
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");

                }
                else
                {
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "");
                }
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody.Add(tempSerialPrintContent);
               // serialBody2 = serialBody;
                bool nonfood = false;
                bool othernoonfood = false;
                PrintUtility printUtility = new PrintUtility();

                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                {
                    Hashtable htOrderedItems = new Hashtable();
                    string categoryOrder = String.Empty;

                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];

                        int totalItem = Convert.ToInt32("0" + tempRow.Cells[1].Value);
                        int printItem = Convert.ToInt32("0" + tempRow.Cells[8].Value);                             // Here index number was 7 and now change index number is 8 by mithu
                        if ((!tempRow.Cells[0].Value.ToString().Equals("")) && (totalItem > printItem))
                        {
                            blnToBePrinted = true;
                            tempSerialPrintContent = new CSerialPrintContent();
                            int productId = Convert.ToInt32(tempRow.Cells[4].Value.ToString());
                            CCategory3DAO aDao = new CCategory3DAO();
                            string printstatus = aDao.GetAllCategory3printareaByCategory3ID(productId);
                            double price = (Convert.ToDouble("0" + tempRow.Cells[3].Value.ToString()) / Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString())) * (totalItem - printItem);//change for kitchen

                            //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                            if (printstatus == "OtherNonfood")
                            {
                                othernoonfood = true;
                                tempSerialPrintContent = new CSerialPrintContent();

                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(totalItem-printItem) + "  " +
                                      printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, price.ToString("F02"), papersize - 3), ""); //change for kitchen

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(totalItem - printItem) + "  " +
                                       printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 5, "", papersize), "");

                                }

                                serialBody2.Add(tempSerialPrintContent);

                            }
                            else
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                nonfood = true;
                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(totalItem - printItem) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 10, price.ToString("F02"), papersize - 3), ""); //change for kitchen

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(totalItem - printItem) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 5, "", papersize), "");

                                }

                                serialBody.Add(tempSerialPrintContent);
                               // itemAvailable = true;
                            }
                        }
                    }
                }

                else
                {
                    //For online orders
                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "----------------------------------------\r\n";
                    //serialBody.Add(tempSerialPrintContent);

                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.RowCount; rowIndex++)
                    {
                        DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];
                        int totalItem = Convert.ToInt32("0" + tempRow.Cells[1].Value);
                        int printItem = Convert.ToInt32("0" + tempRow.Cells[7].Value);

                        if ((!tempRow.Cells[0].Value.ToString().Equals("")) && (totalItem > printItem))
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            int productId = Convert.ToInt32(tempRow.Cells[4].Value.ToString());
                            CCategory3DAO aDao = new CCategory3DAO();
                            string printstatus = aDao.GetAllCategory3printareaByCategory3ID(productId);
                            double price = (Convert.ToDouble("0" + tempRow.Cells[3].Value.ToString()) / Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString())) * (totalItem - printItem); //change for kitchen

                            //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                            if (printstatus == "OtherNonfood")
                            {
                                othernoonfood = true;
                                tempSerialPrintContent = new CSerialPrintContent();

                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(totalItem - printItem) + "  " +
                                      printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, price.ToString("F02"), papersize - 3), "");//change for kitchen

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(totalItem - printItem) + "  " +
                                       printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 5, "", papersize), "");

                                }

                                serialBody2.Add(tempSerialPrintContent);

                            }
                            else
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                nonfood = true;
                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(totalItem - printItem) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 10, price.ToString("F02"), papersize - 3), "");  ////change for kitchen

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(totalItem - printItem) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 5, "", papersize), "");

                                }

                                serialBody.Add(tempSerialPrintContent);
                                //itemAvailable = true;
                            }
                            blnToBePrinted = true;
                        }
                    }
                }


                tempSerialPrintContent = new CSerialPrintContent();

                //tempSerialPrintContent.StringLine = "----------------------------------------";
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                //New at 22.08.2008
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Prepared By:" + m_OperatorName;
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = m_TerminalName.Trim();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                #region "Testing printing area"
                string printingObject = "";
                string printingObject2 = "";

                for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                {
                    printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                }
                for (int arrayIndex = 0; arrayIndex < serialBody2.Count; arrayIndex++)
                {
                    printingObject2 += serialBody2[arrayIndex].StringLine.ToString() + "\r\n";
                }

                if (blnToBePrinted == true) //If there is new items
                {
                    if (nonfood)
                    {
                        for (int printCopy = 0; printCopy < m_barCopyNumber; printCopy++)
                        {
                            //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                            // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString(),true);

                            string fullPrintingText = serialHeader + "\r\n" + printingObject + "\r\n" + serialFooter;
                            tempPrintMethods.USBPrint(fullPrintingText, PrintDestiNation.BEVARAGE, false);
                        }


                        this.WriteString(printingObject); ///Write to a file when print command is executed
                    }
                    if (othernoonfood)
                    {
                        for (int printCopy = 0; printCopy < m_barCopyNumber; printCopy++)
                        {
                            //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                            // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString(),true);

                            string fullPrintingText = serialHeader + "\r\n" + printingObject2 + "\r\n" + serialFooter;
                            tempPrintMethods.USBPrint(fullPrintingText, PrintDestiNation.OtherNonFood, false);
                        }


                        this.WriteString(printingObject); ///Write to a file when print command is executed
                    }
                    blnToBePrinted = false;
                }

                #endregion

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintAllBeverage()
        {
            int papersize = 29;

            StringPrintFormater strPrintFormatter = new StringPrintFormater(29);
            string Cat1ID = String.Empty;
            bool itemAvailable = false;
            try
            {
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();
                //string serialHeader = "IBACS RMS";
                //string serialFooter = "Please Come Again";

                string serialHeader = "";
                string serialFooter = "";

                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                List<CSerialPrintContent> serialBody2 = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();

                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;


                if (m_iType == m_cCommonConstants.TableType)
                {


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Table No: \r\n" + m_iTableNumber.ToString();
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Covers:" + tempOrderInfo.GuestCount.ToString();
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);
                }
                //tempSerialPrintContent.StringLine = "               Beverages/Non-Foods\n";
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Beverages/Non-Foods") +"\r\n";
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

             

                if (m_iType == m_cCommonConstants.TableType)
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order ID:" + orderID.ToString();
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Table No:" + m_iTableNumber.ToString();
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    //serialBody2.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Covers:" + tempOrderInfo.GuestCount.ToString() ;
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    //serialBody2.Add(tempSerialPrintContent);

                    COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                    COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                    if (orderWaiter != null && orderWaiter.WaiterID > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Waiter Name: " + orderWaiter.WaiterName +"\r\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);
                    }
                }
                else if (m_iType == m_cCommonConstants.TakeAwayType)
                {


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date:" + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Take Away");
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                    COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                    if (orderWaiter != null && orderWaiter.WaiterID > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine =  "\r\n" + "Waiter Name: " + orderWaiter.WaiterName + "\r\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);
                    }

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Type:" + tempOrderInfo.Status;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Customer Name:" + tempCustomerInfo.CustomerName;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Phone:" + tempCustomerInfo.CustomerPhone;
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);


                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Address:";
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Floor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Building Name:" + tempCustomerInfo.BuildingName;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "House Number:" + tempCustomerInfo.HouseNumber;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
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
                                serialBody2.Add(tempSerialPrintContent);
                            }

                            if (street[1].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = street[1].ToString();
                                serialBody.Add(tempSerialPrintContent);
                                serialBody2.Add(tempSerialPrintContent);
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                                serialBody2.Add(tempSerialPrintContent);
                            }
                        }

                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Postal Code:" + tempCustomerInfo.CustomerPostalCode;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Town:" + tempCustomerInfo.CustomerTown;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }

                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        serialBody2.Add(tempSerialPrintContent);

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = orderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;
                        if (objDelivery != null)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                            serialBody.Add(tempSerialPrintContent);
                            serialBody2.Add(tempSerialPrintContent);
                        }
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Information";
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);


                tempSerialPrintContent = new CSerialPrintContent();
             
                if (m_isBarPriceAvailable == true)
                {
                    //tempSerialPrintContent.StringLine = "Qty Item                      Price(" + Program.currency.ToString() + ")";

                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");
                }
                else
                {
                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText("Qty Item", "");
                }
                

                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();

                //tempSerialPrintContent.StringLine = "----------------------------------------";
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);
               // serialBody2 = serialBody;

                PrintUtility printUtility = new PrintUtility();
                bool nonfood = false;
                bool othernoonfood = false;


                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                {
                    Hashtable htOrderedItems = new Hashtable();
                    string categoryOrder = String.Empty;

                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];

                        if (!tempRow.Cells[0].Value.ToString().Equals(""))
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            int productId= Convert.ToInt32( tempRow.Cells[4].Value.ToString());
                            CCategory3DAO aDao = new CCategory3DAO();
                            string printstatus = aDao.GetAllCategory3printareaByCategory3ID(productId);

                            //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                            if (printstatus == "OtherNonfood")
                            {
                                othernoonfood = true;
                                tempSerialPrintContent = new CSerialPrintContent();

                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                      printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[3].Value).ToString("F02"), papersize - 3), "");

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                       printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 5, "", papersize), "");

                                }

                                serialBody2.Add(tempSerialPrintContent);

                            }
                            else
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                nonfood=true;
                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 10,
                                                Convert.ToDouble("0" +
                                                                 g_BeverageDataGridView.Rows[rowIndex].Cells[3].Value).
                                                    ToString("F02"), papersize - 3), "");

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 5, "", papersize), "");

                                }

                                serialBody.Add(tempSerialPrintContent);
                                itemAvailable = true;
                            }
                        }
                    }
                }

                else
                {

                    //For online orders
                    tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "----------------------------------------\r\n";

                    tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);
                    serialBody2.Add(tempSerialPrintContent);

                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.RowCount; rowIndex++)
                    {
                        DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];
                        if (Convert.ToInt32("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) > 0)
                        {
                            //tempSerialPrintContent = new CSerialPrintContent();
                            ////  tempSerialPrintContent.StringLine += Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  ";
                            ////  tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), 30);



                            //if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                            //{
                            //   // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                            //    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                            //     printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    


                            //}
                            //else
                            //{
                            //    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                            //    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                            //     printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 5, "", papersize), "");                                    


                            //}
                            //serialBody.Add(tempSerialPrintContent);
                            //itemAvailable = true;

                            tempSerialPrintContent = new CSerialPrintContent();
                            int productId = Convert.ToInt32(tempRow.Cells[4].Value.ToString());
                            CCategory3DAO aDao = new CCategory3DAO();
                            string printstatus = aDao.GetAllCategory3printareaByCategory3ID(productId);

                            //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                            if (printstatus == "OtherNonfood")
                            {
                                othernoonfood = true;
                                tempSerialPrintContent = new CSerialPrintContent();

                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                      printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[3].Value).ToString("F02"), papersize - 3), "");

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                       printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 5, "", papersize), "");

                                }

                                serialBody2.Add(tempSerialPrintContent);

                            }
                            else
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                nonfood = true;
                                if (m_isBarPriceAvailable == true) //Is bar price available or not for online order
                                {
                                    //   tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"));

                                    // tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " +
                                    //  printUtility.MultipleLine(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), papersize - 10, Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), papersize-3), "");                                    

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 10,
                                                Convert.ToDouble("0" +
                                                                 g_BeverageDataGridView.Rows[rowIndex].Cells[3].Value).
                                                    ToString("F02"), papersize - 3), "");

                                }
                                else
                                {
                                    //tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  " + Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), "");

                                    tempSerialPrintContent.StringLine +=
                                        strPrintFormatter.ItemLabeledText(
                                            Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) +
                                            "  " +
                                            printUtility.MultipleLine(
                                                Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value),
                                                papersize - 5, "", papersize), "");

                                }

                                serialBody.Add(tempSerialPrintContent);
                                itemAvailable = true;
                            }



                        }
                    }
                }


                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";

                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                //New at 22.08.2008
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Order Prepared By :" + m_OperatorName;
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = m_TerminalName.Trim();
                serialBody.Add(tempSerialPrintContent);
                serialBody2.Add(tempSerialPrintContent);

           

            
                             
                                                 

                if (itemAvailable == true) //If there is items for printing
                {
                    if (nonfood)
                    {
                        string printingObject = ""; //Write to the text file
                        for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                        {
                            printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                        }
                        this.WriteString(printingObject);///Write to a file when print command is executed
                        for (int printCopy = 0; printCopy < m_barCopyNumber; printCopy++)
                        {
                            //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                            //  tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString(),true);



                            string fulltext = serialHeader + "\r\n" + printingObject + "\r\n" + serialFooter;
                            tempPrintMethods.USBPrint(fulltext, PrintDestiNation.BEVARAGE, false);
                        }
                    }
                    //this.WriteString(printingObject2);///Write to a file when print command is executed   
                    if(othernoonfood)
                    {
                        string printingObject2 = ""; //Write to the text file
                        for (int arrayIndex = 0; arrayIndex < serialBody2.Count; arrayIndex++)
                        {
                            printingObject2 += serialBody2[arrayIndex].StringLine.ToString() + "\r\n";
                        }
                        this.WriteString(printingObject2);///Write to a file when print command is executed   
                        ///  for (int printCopy = 0; printCopy < m_barCopyNumber; printCopy++)
                        {
                            //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                            //  tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString(),true);



                            string fulltext = serialHeader + "\r\n" + printingObject2 + "\r\n" + serialFooter;
                            tempPrintMethods.USBPrint(fulltext, PrintDestiNation.OtherNonFood, false);
                        }
                    }


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This function prints all the new food item
        /// </summary>
        private void KitchenCopyForNewFoodItems()
        {
            Hashtable htOrderedItems = new Hashtable();
            SortedList slOrderedItems = null;
            int papersize = 29;
            StringPrintFormater strPrintFormatter = new StringPrintFormater(29);


            try
            {
                bool itemAvailable = false;
                // CPrintMethods tempPrintMethods = new CPrintMethods();

                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();
                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                COrderManager tempOrderManager = new COrderManager();
                CResult oResult = tempOrderManager.OrderInfoByOrderID(orderID);
                COrderInfo tempOrderInfo = new COrderInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }

                if (oConstant.KitchenPrintFlag == 1)
                {
                    bool otherfoodprint = false;
                    bool foodprint = false;
                    string serialHeader = "";
                    string serialFooter = "";
                    string serialBody = "";
                    string serialBody2 = "";
                   


                    if (m_iType == m_cCommonConstants.TableType)
                    {
                        //serialBody += "\r\n\r\n        Table Number:" + m_iTableNumber.ToString();
                        serialBody += "Table Number:\r\n" + m_iTableNumber.ToString();
                        serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();
                    }

                    serialBody += "\r\nKitchen Copy";

                   // serialBody2 += "Kitchen Copy";

                    if (!tempOrderInfo.Status.Equals("Seated") && m_iType == m_cCommonConstants.TableType)
                    {
                        serialBody += "\r\nReprint";
                        
                    }
                    serialBody += "\r\n\r\nOrder ID:" + orderID.ToString();
                    serialBody += "\r\n\r\nOrder Date:" + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody += "\r\nPrint Date:" + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");
                    if (m_iType == m_cCommonConstants.TableType)
                    {
                        serialBody += "\r\n\r\nTable Number:" + m_iTableNumber.ToString();
                        serialBody += "\r\nCovers:" + tempOrderInfo.GuestCount.ToString();

                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName;
                        }
                    }
                    else if (m_iType == m_cCommonConstants.TakeAwayType)
                    {
                        serialBody += "\r\n\r\nTake Away";

                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName;
                        }

                        serialBody += "\r\nType: " + tempOrderInfo.Status;
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

                            //serialBody += "\r\n----------------------------------------";

                            serialBody += strPrintFormatter.CreateDashedLine();

                            CDelivery objDelivery = new CDelivery();
                            objDelivery.DeliveryOrderID = orderID;
                            CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                            objDelivery = (CDelivery)objDeliveryInfo.Data;

                            serialBody += "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                        }
                    }

                    serialBody += "\r\n\r\nOrder Information"+"\r\n";
                    //serialBody += "\r\n---------------------------------";

                    serialBody += strPrintFormatter.CreateDashedLine();

                    if (m_isKitchenPriceAvailable == true)
                    {
                        // serialBody += "\r\nQty Item                      Price(" + Program.currency.ToString() + ")";
                        serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");
                    }
                    else
                    {
                        serialBody += "\r\nQty Item";
                    }
                    // serialBody += "\r\n---------------------------------";
                    serialBody2 = serialBody;

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        string cat1ID = String.Empty;
                        string cat2ID = String.Empty;
                        string cat3ID = String.Empty;

                        string separatorCatID = String.Empty;
                        string category2Order = String.Empty; //Printing order will be according to category2 order

                        for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
                        {
                            DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                            if (Int32.Parse("0" + tempRow.Cells[1].Value) > Int32.Parse("0" + tempRow.Cells[8].Value)) //If there is new item.Greater when new items are added and nor printed.
                            {
                                category2Order = String.Empty;

                                if (!tempRow.Cells[0].Value.ToString().Equals(""))
                                {
                                    Int64 productID = Int64.Parse(tempRow.Cells[4].Value.ToString());
                                    Int32 productLevel = Int32.Parse(tempRow.Cells[5].Value.ToString());

                                    //bool valid = false;
                                    if (productLevel == 3)
                                    {
                                        DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + productID);
                                        if (dtRow.Length > 0)
                                        {
                                            cat2ID = dtRow[0]["cat2_id"].ToString();
                                        }
                                        cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["category1_to_category2"])["cat1_id"].ToString();
                                    }
                                    else if (productLevel == 4)
                                    {

                                        DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + productID);
                                        if (dtRow.Length > 0)
                                        {
                                            cat3ID = dtRow[0]["cat3_id"].ToString();
                                            if (cat3ID != "" || cat3ID != null)
                                            {
                                                dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                            }
                                            else
                                            {
                                                dtRow = null;
                                            }
                                        }

                                        if (dtRow.Length > 0)
                                        {
                                            cat2ID = dtRow[0]["cat2_id"].ToString();
                                            //DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                            //cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                        }
                                        cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0].GetParentRow(Program.initDataSet.Relations["category1_to_category2"])["cat1_id"].ToString();//Not necessary
                                        //string parentCatName = Program.initDataSet.Tables["Category1"].Select("cat1_id = " + cat1ID)[0].GetParentRow(Program.initDataSet.Relations["parent_category_to_category1"])["parent_cat_name"].ToString();
                                        //if (parentCatName.Equals(p_foodType))
                                        //{
                                        //    valid = true;
                                        //}
                                    }
                                    else if (productLevel == 0)// && p_foodType.Equals("Indian")) //If miscellenious foods. 
                                    {
                                        cat1ID = "0";
                                        cat2ID = "0";
                                        //valid = true;
                                    }

                                    //if (valid)
                                    //{
                                    #region "New "
                                    CCategory3DAO aDao= new CCategory3DAO();
                                    string printstatus = aDao.GetAllCategory3printareaByCategory3ID((int)productID);

                                    clsOrderReport objOrderedItems = new clsOrderReport();
                                    objOrderedItems.Quantity = Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString()) - Convert.ToInt32("0" + tempRow.Cells[8].Value.ToString());
                                    objOrderedItems.ItemName = tempRow.Cells[0].Value.ToString();
                                    objOrderedItems.Price = (Convert.ToDouble("0" + tempRow.Cells[3].Value.ToString()) / Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString())) * objOrderedItems.Quantity; //Price of the rest product
                                    objOrderedItems.PrintArea = printstatus;
                                    //htOrderedItems.Add(cat2ID + "-" + objOrderedItems.ItemName, objOrderedItems);

                                    Int64 rankNumber = Int64.Parse(tempRow.Cells[6].Value.ToString());
                                    Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));

                                    htOrderedItems.Add(category1OrderNumber + "-" + rankNumber.ToString() + "-" + objOrderedItems.ItemName, objOrderedItems);// Category 1 wise
                                    #endregion
                                    itemAvailable = true;//For drinks.When drinks is avalable then no separator is used.
                                    //}
                                }
                            }
                        }

                        NumericComparer ncomp = new NumericComparer();
                        slOrderedItems = new SortedList(htOrderedItems, ncomp);

                        int keyIndex = 0;
                        SortedList slMiscellaneousItems = new SortedList();

                        PrintUtility printUtility = new PrintUtility();

                        string[] valueSplitter = new string[0];
                        foreach (clsOrderReport objReport in slOrderedItems.Values)
                        {
                            string keyValue = slOrderedItems.GetKey(keyIndex).ToString();
                            valueSplitter = keyValue.Split('-');

                            if ((separatorCatID.Trim() != valueSplitter[0].ToString().Trim()) && (valueSplitter[0].ToString().Trim() != "0"))//Insert separator
                            {
                                // serialBody += "\r\n---------------------------------";
                                if (objReport.PrintArea == "Otherfood")
                                {

                                    otherfoodprint = true;
                                serialBody2 += "\r\n" + strPrintFormatter.CreateDashedLine();
                                separatorCatID = valueSplitter[0].ToString().Trim();

                                //serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";

                                // serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                if (m_isKitchenPriceAvailable == true)
                                {
                                    //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                    //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));

                                    serialBody2 += "\r\n" +
                                                  strPrintFormatter.ItemLabeledText(
                                                      objReport.Quantity.ToString() + "  " +
                                                      printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                objReport.Price.ToString("F02"),
                                                                                papersize - 3), "");

                                }
                                else
                                {
                                    //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, "");
                                    serialBody2 += "\r\n" +
                                                  strPrintFormatter.ItemLabeledText(
                                                      objReport.Quantity.ToString() + "  " +
                                                      printUtility.MultipleLine(objReport.ItemName, papersize - 5, "",
                                                                                papersize), "");

                                }

                            } else
                                {

                                    foodprint = true;
                                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                                    separatorCatID = valueSplitter[0].ToString().Trim();

                                    //serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";

                                    // serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));

                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else
                                    {
                                        //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName, "");
                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 5, "",
                                                                                    papersize), "");

                                    }
                                }
                            }
                            else if (valueSplitter[0].ToString() == "0")
                            {
                                slMiscellaneousItems.Add(slMiscellaneousItems.Count, objReport);
                            }
                            else
                            {
                                if (objReport.PrintArea == "Otherfood")
                                {
                                    otherfoodprint = true;
                                    //serialBody2 += "\r\n" + objReport.Quantity.ToString() + "  ";
                                    //serialBody2 += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);
                                        //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("\r\n" + objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));
                                        serialBody2 += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else {
                                        serialBody2 += "\r\n" + objReport.Quantity.ToString() + "  ";
                                        serialBody2 += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    }
                                }
                                else
                                {
                                    foodprint = true;
                                   // serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                   // serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);
                                        //    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("\r\n" + objReport.Quantity.ToString() + "  " + objReport.ItemName, objReport.Price.ToString("F02"));
                                        serialBody += "\r\n" +
                                                      strPrintFormatter.ItemLabeledText(
                                                          objReport.Quantity.ToString() + "  " +
                                                          printUtility.MultipleLine(objReport.ItemName, papersize - 10,
                                                                                    objReport.Price.ToString("F02"),
                                                                                    papersize - 3), "");

                                    }
                                    else
                                    {
                                        serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                        serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);
                                    }

                                }
                            }
                            keyIndex++;
                        }

                        if (slMiscellaneousItems.Count > 0)
                        {
                            foodprint = true;
                            //serialBody += "\r\n----------Miscellaneous----------"; //separator for miscellaneous 
                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous");
                            foreach (clsOrderReport objReport in slMiscellaneousItems.Values)
                            {
                                /*serialBody += "\r\n" + objReport.Quantity.ToString() + "  ";
                                serialBody += CPrintMethods.GetFixedString(objReport.ItemName, 20);*/
                              //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), "");

                                if (m_isKitchenPriceAvailable == true)
                                {
                                    //serialBody += "  " + CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);

                                   // serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), objReport.Price.ToString("F02"));
                                    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                   printUtility.MultipleLine(objReport.ItemName, papersize - 10, objReport.Price.ToString("F02"), papersize - 3), "");                                    

              
                                }
                                else
                                {
                                   // serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(), "");
                                    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                      printUtility.MultipleLine(objReport.ItemName, papersize - 5, "", papersize), "");                                    

                                }
                            }
                        }

                        //serialBody += "\r\n---------------------------------";

                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody2 += "\r\n" + strPrintFormatter.CreateDashedLine();

                        CResult objKitchenText = tempOrderManager.GetKitchenTextByOrderID(orderID);
                        List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();
                        tempOrderLogInfoList = (List<OrderLogInformation>)objKitchenText.Data;

                        if (tempOrderLogInfoList.Count > 0)
                        {
                            serialBody += "\r\nKT Txt:";
                            serialBody2 += "\r\nKT Txt:";
                        }
                        for (int recordCounter = 0; recordCounter < tempOrderLogInfoList.Count; recordCounter++)
                        {
                            if (tempOrderLogInfoList[recordCounter].KitchenTextPrintStatus < 1)
                            {
                                serialBody += "\r\n- " + tempOrderLogInfoList[recordCounter].KitchenText;
                                serialBody2 += "\r\n- " + tempOrderLogInfoList[recordCounter].KitchenText;
                            }
                        }

                        serialBody += "\r\nOrder Prepared By:" + m_OperatorName;
                        serialBody += "\r\n" + m_TerminalName;
                        serialBody += "\r\n\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("[ E N D ]") + "\r\n\r\n";
                        serialBody2 += "\r\nOrder Prepared By:" + m_OperatorName;
                        serialBody2 += "\r\n" + m_TerminalName;
                        serialBody2 += "\r\n\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("[ E N D ]") + "\r\n\r\n";
                        //tempPrintMethods.SerialPrint(PRINTER_TYPES.KITCHEN_PRINTER, serialHeader, serialBody, serialFooter);

                        if (itemAvailable == true) //If items are available
                        {
                            CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                            tempPrintingFormat.Header = serialHeader;
                            tempPrintingFormat.Body = serialBody.ToUpper();
                            tempPrintingFormat.Footer = serialFooter;
                            tempPrintingFormat.OrderID = orderID;
                            tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;


                             CPrintingFormat tempPrintingFormat1 = new CPrintingFormat();
                            tempPrintingFormat1.Header = serialHeader;
                            tempPrintingFormat1.Body = serialBody2.ToUpper();
                            tempPrintingFormat1.Footer = serialFooter;
                            tempPrintingFormat1.OrderID = orderID;
                            tempPrintingFormat1.PrintType = (int)PRINTER_TYPES.Serial;

                            CLogin oLogin = new CLogin();
                            oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);

                            CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();
                            for (int printCopy = 0; printCopy < m_printedCopy; printCopy++)
                            {
                                // oLogin.PostPrintingRequest(tempPrintingFormat);
                                if (foodprint)
                                {
                                    string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body +
                                                      "\r\n" + tempPrintingFormat.Footer;
                                    cPrintMethods.USBPrint(fulltext, PrintDestiNation.KITCHEN, false);
                                }
                                if(otherfoodprint)
                                {
                                  string  fulltext = tempPrintingFormat1.Header + "\r\n" + tempPrintingFormat1.Body + "\r\n" + tempPrintingFormat1.Footer;
                                    cPrintMethods.USBPrint(fulltext, PrintDestiNation.Other, false);
                                }
                            }

                            if (tempOrderLogInfoList.Count > 0) //If kitchen command is available.
                            {
                                this.UpdateKitchenTextPrintStatus();
                            }
                            this.WriteString(serialBody);//Writing to the specified file
                        }
                    }
                    else //For online orders
                    {
                        bool isItemsAvailable = false;
                        foodprint = false;
                        otherfoodprint = false;
                        serialBody += "\r\n---------------------------------";
                        for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
                        {
                            //  Int64 productID = Int64.Parse(tempRow.Cells[4].Value.ToString());
                            if (g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() != String.Empty)
                            {
                                Int64 productID = Int64.Parse(g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString());
                                CCategory3DAO aDao = new CCategory3DAO();
                                string printstatus = aDao.GetAllCategory3printareaByCategory3ID((int)productID);

                                if (printstatus == "Otherfood")
                                {
                                    otherfoodprint = true;
                                    serialBody2 += "\r\n" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() +
                                                  "  ";
                                    serialBody2 +=
                                        CPrintMethods.GetFixedString(
                                            g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString(), 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        serialBody2 += "  " +
                                                      CPrintMethods.RightAlign(
                                                          Convert.ToDouble("0" +
                                                                           g_FoodDataGridView.Rows[rowIndex].Cells[2].
                                                                               Value).ToString("F02"), 6);
                                    }
                                }
                                else
                                {
                                    foodprint = true;
                                    serialBody += "\r\n" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() +
                                                  "  ";
                                    serialBody +=
                                        CPrintMethods.GetFixedString(
                                            g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString(), 20);
                                    if (m_isKitchenPriceAvailable == true)
                                    {
                                        serialBody += "  " +
                                                      CPrintMethods.RightAlign(
                                                          Convert.ToDouble("0" +
                                                                           g_FoodDataGridView.Rows[rowIndex].Cells[2].
                                                                               Value).ToString("F02"), 6);
                                    }

                                }
                                isItemsAvailable = true;
                            }
                        }
                        serialBody += "\r\n---------------------------------";
                        serialBody += "\r\nKT Txt:" + tempOrderInfo.InitialKitchenText;
                        serialBody += "\r\n---------------------------------";
                        serialBody += "\r\nOrder Prepared By:" + m_OperatorName;

                        serialBody += "\r\n\r\n          [ E N D ]\r\n\r\n";

                        serialBody2 += "\r\n---------------------------------";
                        serialBody2 += "\r\nKT Txt:" + tempOrderInfo.InitialKitchenText;
                        serialBody2 += "\r\n---------------------------------";
                        serialBody2 += "\r\nOrder Prepared By:" + m_OperatorName;

                        serialBody2 += "\r\n\r\n          [ E N D ]\r\n\r\n";

                        if (isItemsAvailable == false)//If there is no items in the datagrid view
                        {
                            return;
                        }
                        else
                        {
                            if (foodprint)
                            {
                                CPrintingFormat tempPrintingFormat = new CPrintingFormat();

                                CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();
                                tempPrintingFormat.Header = serialHeader;
                                tempPrintingFormat.Body = serialBody.ToUpper();

                                tempPrintingFormat.Footer = serialFooter;
                                tempPrintingFormat.OrderID = orderID;
                                tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                                CLogin oLogin = new CLogin();
                                oLogin =
                                    (RmsRemote.CLogin)
                                    Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                                // oLogin.PostPrintingRequest(tempPrintingFormat);

                                string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body + "\r\n" +
                                                  tempPrintingFormat.Footer;
                                cPrintMethods.USBPrint(fulltext, PrintDestiNation.KITCHEN, false);


                                this.WriteString(serialBody); //Writing to the specified file
                            }
                            if (otherfoodprint)
                            {
                                CPrintingFormat tempPrintingFormat = new CPrintingFormat();

                                CPrintMethodsEXT cPrintMethods = new CPrintMethodsEXT();
                                tempPrintingFormat.Header = serialHeader;
                                tempPrintingFormat.Body = serialBody2.ToUpper();

                                tempPrintingFormat.Footer = serialFooter;
                                tempPrintingFormat.OrderID = orderID;
                                tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                                CLogin oLogin = new CLogin();
                                oLogin =
                                    (RmsRemote.CLogin)
                                    Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                                // oLogin.PostPrintingRequest(tempPrintingFormat);

                                string fulltext = tempPrintingFormat.Header + "\r\n" + tempPrintingFormat.Body + "\r\n" +
                                                  tempPrintingFormat.Footer;
                                cPrintMethods.USBPrint(fulltext, PrintDestiNation.Other, false);


                                this.WriteString(serialBody); //Writing to the specified file
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SortedList GetProductIdList(int p_toBeCollectedProduct)
        {
            SortedList slProductList = new SortedList();

            //Local order food
            if (p_toBeCollectedProduct == 1) //1 For new food item
            {
                foreach (DataGridViewRow dgvRow in g_FoodDataGridView.Rows)
                {
                    if (!Convert.ToString(dgvRow.Cells[1].Value).Equals(""))
                    {
                        PrintedItems objPrintedItem = new PrintedItems();
                        /*
                        objPrintedItem.ProductID = Convert.ToInt64("0" + dgvRow.Cells[3].Value.ToString());
                        objPrintedItem.PrintedQuantity = Convert.ToInt32(dgvRow.Cells[7].Value.ToString());
                        objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dgvRow.Cells[1].Value.ToString());
                        objPrintedItem.OrderID = orderID;
                        objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dgvRow.Cells[6].Value.ToString());
                        */
                        //For Vat Including
                        objPrintedItem.ProductID = Convert.ToInt64("0" + dgvRow.Cells[4].Value.ToString());
                        objPrintedItem.PrintedQuantity = Convert.ToInt32(dgvRow.Cells[8].Value.ToString());
                        objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dgvRow.Cells[1].Value.ToString());
                        objPrintedItem.OrderID = orderID;
                        objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dgvRow.Cells[7].Value.ToString());

                        if (objPrintedItem.TotalQuantity - objPrintedItem.PrintedQuantity > 0)
                        {
                            slProductList.Add(objPrintedItem.OrderDetailsID, objPrintedItem);
                        }
                    }
                }
            }
            ///Online order food
            else if (p_toBeCollectedProduct == 2)
            {
                foreach (DataGridViewRow dtRow in g_FoodDataGridView.Rows)
                {
                    if (!Convert.ToString(dtRow.Cells[1].Value).Equals(""))
                    {
                        PrintedItems objPrintedItem = new PrintedItems();
                        objPrintedItem.OnlineItemOrderNumber = Convert.ToInt64("0" + dtRow.Cells[5].Value.ToString());
                        objPrintedItem.PrintedQuantity = Convert.ToInt32(dtRow.Cells[7].Value.ToString());
                        objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dtRow.Cells[1].Value.ToString());
                        objPrintedItem.OrderID = orderID;
                        objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dtRow.Cells[6].Value.ToString());
                        if (objPrintedItem.TotalQuantity - objPrintedItem.PrintedQuantity > 0)
                        {
                            slProductList.Add(objPrintedItem.OnlineItemOrderNumber, objPrintedItem);
                        }
                    }
                }
            }

                //Local order drink
            else if (p_toBeCollectedProduct == 3)
            {
                foreach (DataGridViewRow dtRow in g_BeverageDataGridView.Rows)
                {
                    if (!Convert.ToString(dtRow.Cells[1].Value).Equals(""))
                    {
                        PrintedItems objPrintedItem = new PrintedItems();
                     //   objPrintedItem.ProductID = Convert.ToInt64("0" + dtRow.Cells[3].Value.ToString());
                     //   objPrintedItem.PrintedQuantity = Convert.ToInt32(dtRow.Cells[7].Value.ToString());
                       // objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dtRow.Cells[1].Value.ToString());
                      //  objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dtRow.Cells[6].Value.ToString());
                      //  objPrintedItem.OrderID = orderID;

                        //for vat
                        objPrintedItem.ProductID = Convert.ToInt64("0" + dtRow.Cells[4].Value.ToString());
                        objPrintedItem.PrintedQuantity = Convert.ToInt32(dtRow.Cells[8].Value.ToString());
                        objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dtRow.Cells[1].Value.ToString());
                        objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dtRow.Cells[7].Value.ToString());
                        objPrintedItem.OrderID = orderID;
                      

                        if (objPrintedItem.TotalQuantity - objPrintedItem.PrintedQuantity > 0)
                        {
                            slProductList.Add(objPrintedItem.OrderDetailsID, objPrintedItem);
                        }
                    }
                }
            }

                //Online order drink
            else if (p_toBeCollectedProduct == 4)
            {
                foreach (DataGridViewRow dtRow in g_BeverageDataGridView.Rows)
                {
                    if (!Convert.ToString(dtRow.Cells[1].Value).Equals(""))
                    {
                        PrintedItems objPrintedItem = new PrintedItems();
                        objPrintedItem.OnlineItemOrderNumber = Convert.ToInt64("0" + dtRow.Cells[5].Value.ToString());
                        objPrintedItem.PrintedQuantity = Convert.ToInt32(dtRow.Cells[7].Value.ToString());
                        objPrintedItem.TotalQuantity = Convert.ToInt32("0" + dtRow.Cells[1].Value.ToString());
                        objPrintedItem.OrderDetailsID = Convert.ToInt64("0" + dtRow.Cells[6].Value.ToString());
                        objPrintedItem.OrderID = orderID;
                        if (objPrintedItem.TotalQuantity - objPrintedItem.PrintedQuantity > 0)
                        {
                            slProductList.Add(objPrintedItem.OnlineItemOrderNumber, objPrintedItem);
                        }
                    }
                }
            }

            return slProductList;
        }


        private void g_MiscButton_Click(object sender, EventArgs e)
        {
            try
            {
                CKeyBoardForm tempKeyBoardForm = new CKeyBoardForm("Misc Item", "Enter Item Name or Description", true);
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
                  double price = Double.Parse(CPriceCalculatorForm.inputResult);
                //change by mithu

                        CPriceCalculatorForm tempCalculatorForm1 = new CPriceCalculatorForm("Misc Item", "Enter vat");
                     tempCalculatorForm1.ShowDialog();

                if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                    return;

                if (CPriceCalculatorForm.inputResult.Equals("0.000"))
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Vat cannot be zero.");
                    tempMessageBox.ShowDialog();
                    return;
                }

                double addmisvat=Double.Parse(CPriceCalculatorForm.inputResult);



                try
                {
                    CCalculatorForm tempQtyCalculatorForm = new CCalculatorForm("Order Quantity", "Item Quantity");
                    tempQtyCalculatorForm.ShowDialog();

                    if (CCalculatorForm.inputResult.Equals("Cancel"))
                        return;

                    string str = CCalculatorForm.inputResult;
                    str = (str == "") ? "1" : str;

                    if (Int32.Parse(str) == 0)
                    {
                        CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                        tempMessageBox.ShowDialog();
                        return;
                    }

                    int tempOrderedQty = Int32.Parse(str);
                    m_iSavedOrderedQty = tempOrderedQty;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


              

                COrderManager tempOrderManager = new COrderManager();
                COrderDetails tempOrderDetails = new COrderDetails();
                DataGridView tempDataGridView = null;

                if (CKeyBoardForm.m_foodType == true) //If miscelleneous item is food
                {
                    tempDataGridView = g_FoodDataGridView;
                }
                else
                {
                    tempDataGridView = g_BeverageDataGridView;
                }


                int tempResult = FindExistingItem(tempDataGridView, CKeyBoardForm.Content);
                if (tempResult != -1)
                {
                    //update Order_details table
                    int tempRowIndex = tempResult;
                    tempDataGridView.Rows[tempRowIndex].Cells[1].Value = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                    tempOrderDetails.OrderDetailsID = Int64.Parse(tempDataGridView.Rows[tempRowIndex].Cells[7].Value.ToString());
                    tempOrderDetails.OrderID = orderID;
                    tempOrderDetails.ProductID = 0;
                    tempOrderDetails.CategoryLevel = 0;
                    tempOrderDetails.OrderRemarks = CKeyBoardForm.Content;
                    tempOrderDetails.Product_Name = CKeyBoardForm.Content;
                    tempOrderDetails.OrderQuantity = Int32.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString());
                    tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity*price;
                    tempOrderDetails.VatTotal = (addmisvat*tempOrderDetails.OrderAmount)/100.0;
                    tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;
                    tempOrderDetails.OrderFoodType = "Food";
                    tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;

                    tempDataGridView.Rows[tempRowIndex].Cells[2].Value = tempOrderDetails.VatTotal.ToString("F02");
                    tempDataGridView.Rows[tempRowIndex].Cells[3].Value = tempOrderDetails.OrderAmount.ToString("F02");


                    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                }
                else
                {
                    //Insert into Order_details table
                    tempOrderDetails.OrderID = orderID;
                    tempOrderDetails.ProductID = 0;
                    tempOrderDetails.CategoryLevel = 0;
                    tempOrderDetails.OrderRemarks = CKeyBoardForm.Content;
                    tempOrderDetails.Product_Name = CKeyBoardForm.Content;
                    tempOrderDetails.OrderQuantity = m_iSavedOrderedQty;
                    tempOrderDetails.ItemOrderTime = DateTime.Now.Ticks;
                    tempOrderDetails.OrderAmount = tempOrderDetails.OrderQuantity*price;
                    tempOrderDetails.VatTotal = (addmisvat * tempOrderDetails.OrderAmount) / 100.0;
                    tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;

                    if (CKeyBoardForm.m_foodType == true)
                    {
                        tempOrderDetails.OrderFoodType = "Food";
                    }
                    else
                    {
                        tempOrderDetails.OrderFoodType = "Nonfood";
                    }

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        tempOrderDetails = (COrderDetails)tempOrderManager.InsertOrderDetails(tempOrderDetails).Data;
                        string[] tempDataGridViewRow = new string[] 
                                { CKeyBoardForm.Content, 
                                  m_iSavedOrderedQty.ToString(), 
                                  tempOrderDetails.VatTotal.ToString("F02"),
                                  tempOrderDetails.OrderAmount.ToString("F02"),
                                  "0",
                                  "0",
                                  Int64.MaxValue-1+"",
                                  tempOrderDetails.OrderDetailsID.ToString(),"0" //0 for printed item quantity
                                };
                        tempDataGridView.Rows.Add(tempDataGridViewRow);
                    }
                    else
                    {
                        tempOrderDetails.ItemName = CKeyBoardForm.Content;
                        tempOrderDetails = (COrderDetails)tempOrderManager.InsertOnlineOrderDetails(tempOrderDetails).Data;

                        string[] tempDataGridViewRow = new string[] 
                                { CKeyBoardForm.Content, 
                                  m_iSavedOrderedQty.ToString(),
                                   tempOrderDetails.VatTotal.ToString("F02"),
                                  tempOrderDetails.OrderAmount.ToString("F02"),
                                  "0",
                                  "0",
                                  tempOrderDetails.OnlineItemSequenceNumber.ToString(),
                                  tempOrderDetails.OrderDetailsID.ToString(),"0" //0 for printed item quantity
                                };
                        tempDataGridView.Rows.Add(tempDataGridViewRow);
                    }
                }

                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper()) //Rank is applicable only for local order only
                {
                    this.ConvertRank();
                }

                tempDataGridView.Sort(tempDataGridView.Columns[5], ListSortDirection.Ascending);
                tempDataGridView.Update();
                TotalAmountCalculation();
                m_iSavedOrderedQty = 1;
                g_FoodDataGridView.ClearSelection();
                g_BeverageDataGridView.ClearSelection();
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        public int printlinelength = 27;
        public int qty_length_with_twospace = 4;
        private void g_PrintGuestBillButton_Click(object sender, EventArgs e)
        {

            COrderDetailsDAO aDao = new COrderDetailsDAO();
            aDao.UpdateGuestQuantity(orderID);


            bool isPrintA5SizeReport = false;
            
                if (isPrintA5SizeReport)
                {
                    PrintA5GuestBillReport();
                }

                else
                {
                    int papersize = 37;
                    StringPrintFormater strPrintFormatter = new StringPrintFormater(37);

                    string Cat1ID = String.Empty;

                    try
                    {
                        CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                        //CPrintMethods tempPrintMethods = new CPrintMethods();
                        int categoryID = 0;
                        //serial print 
                        //string serialHeader = "IBACS RMS";
                        string serialHeader = "";
                        //string serialFooter = "Please Come Again";
                        string serialFooter = "";

                        List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                        CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Guest Bill");
                        tempSerialPrintContent.Bold = true;


                        serialBody.Add(tempSerialPrintContent);

                        COrderManager tempOrderManager = new COrderManager();
                        COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;



                        //string s=tempOrderInfo.
                        if (m_iType == m_cCommonConstants.TableType)
                        {

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("                            MUSAK-11"); // Change by Mithu
                            //tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + orderID.ToString();

                            serialBody.Add(tempSerialPrintContent);


                            //tempSerialPrintContent = new CSerialPrintContent();
                            //tempSerialPrintContent.StringLine = "\r\n\nTable Number:" + tempOrderInfo.TableNumber.ToString();
                            //serialBody.Add(tempSerialPrintContent);
                            COrderWaiterDao orderWaiterDao = new COrderWaiterDao(); // Change by Mithu
                            COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID); // Change by Mithu

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n\r\nVat Registration No: " + Program.vatRegDes.ToString();
                            //tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                            serialBody.Add(tempSerialPrintContent);
                            tempSerialPrintContent.StringLine = "\r\nWaiter Name: " + orderWaiter.WaiterName + "\r\n"; // Change by Mithu
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + orderID.ToString();
                            //tempSerialPrintContent.StringLine = "\r\nTable No: " + m_iTableNumber.ToString() + "\r\n";
                            tempSerialPrintContent.Bold = true;
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                            //tempSerialPrintContent.StringLine = "Covers: " + tempOrderInfo.GuestCount.ToString() + "\r\n";
                            tempSerialPrintContent.Bold = true;
                            serialBody.Add(tempSerialPrintContent);




                            

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nTable No: " + m_iTableNumber.ToString() + "\r\n";
                            
                            // tempSerialPrintContent.Bold = true;
                            serialBody.Add(tempSerialPrintContent);
                            //try
                            //{
                            //   tempSerialPrintContent = new CSerialPrintContent();
                            //    tempSerialPrintContent.StringLine = "Vat Registration : " + Program.vatRegDes + "\r\n";
                            //   serialBody.Add(tempSerialPrintContent);
                            //}
                            //catch { }

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Covers: " + tempOrderInfo.GuestCount.ToString() + "\r\n";
                            
                            
                            //tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Order Information");
                            serialBody.Add(tempSerialPrintContent);
                            
                        }
                        else if (m_iType == m_cCommonConstants.TakeAwayType)
                        {

                            tempSerialPrintContent = new CSerialPrintContent();

                            tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + orderID.ToString();
                            //tempSerialPrintContent.StringLine = "\r\nTable No: " + m_iTableNumber.ToString() + "\r\n";
                            tempSerialPrintContent.Bold = true;
                            serialBody.Add(tempSerialPrintContent);
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nOrder Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                            serialBody.Add(tempSerialPrintContent);


                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nType: " + tempOrderInfo.Status;
                            serialBody.Add(tempSerialPrintContent);


                            COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                            COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + "Waiter Name: " + orderWaiter.WaiterName + "\r\n";
                            // tempSerialPrintContent.Bold = true;
                            serialBody.Add(tempSerialPrintContent);

                            CCustomerManager tempCustomerManager = new CCustomerManager();
                            CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                            if (tempCustomerInfo.CustomerName.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                                serialBody.Add(tempSerialPrintContent);
                            }

                            if (tempCustomerInfo.CustomerPhone.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                                serialBody.Add(tempSerialPrintContent);
                            }


                            if (tempOrderInfo.Status.Equals("Delivery"))
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\nAddress:";
                                serialBody.Add(tempSerialPrintContent);

                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
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

                                //tempSerialPrintContent = new CSerialPrintContent();
                                //tempSerialPrintContent.StringLine = "Country:" + tempCustomerInfo.CustomerCountry;
                                //serialBody.Add(tempSerialPrintContent);

                                tempSerialPrintContent = new CSerialPrintContent();
                                //
                                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                                serialBody.Add(tempSerialPrintContent);

                                CDelivery objDelivery = new CDelivery();
                                objDelivery.DeliveryOrderID = orderID;
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
                        tempSerialPrintContent.StringLine = "\r\n\nOrder Information";
                        serialBody.Add(tempSerialPrintContent);
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");
                        serialBody.Add(tempSerialPrintContent);

                        //Line after above line
                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "----------------------------------------";
                        //serialBody.Add(tempSerialPrintContent);

                        if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                        {
                            Hashtable htOrderedItems = new Hashtable();
                            SortedList slorderedItems = null;

                            string categoryOrder = String.Empty;
                            int internalCategoryID = 0;
                            //Modification By Baruri at 04/08/2008
                            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
                            {
                                internalCategoryID = 0;
                                string cat3ID = String.Empty;
                                string cat2ID = String.Empty;
                                string cat1ID = String.Empty;

                                DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                                categoryOrder = String.Empty;

                                if (!tempRow.Cells[0].Value.ToString().Equals(""))
                                {
                                    #region "Parent Category"


                                    if (Convert.ToInt32("0" + tempRow.Cells[5].Value.ToString()) == 3)//Item from Category 3
                                    {
                                        internalCategoryID = Convert.ToInt32("0" + tempRow.Cells[4].Value.ToString());
                                        DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + internalCategoryID);
                                        if (dtRow.Length > 0)
                                        {
                                            cat2ID = dtRow[0]["cat2_id"].ToString();
                                            DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                            cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                        }
                                    }
                                    else if (Convert.ToInt32("0" + tempRow.Cells[5].Value.ToString()) == 0)
                                    {
                                        cat1ID = "0";
                                        cat2ID = "0";
                                    }

                                    else
                                    {
                                        internalCategoryID = Convert.ToInt32("0" + tempRow.Cells[4].Value.ToString());
                                        DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + internalCategoryID);
                                        if (dtRow.Length > 0)
                                        {
                                            cat3ID = dtRow[0]["cat3_id"].ToString();
                                            if (cat3ID != "" || cat3ID != null)
                                            {
                                                dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                            }
                                            else
                                            {
                                                dtRow = null;
                                            }
                                        }

                                        if (dtRow.Length > 0)
                                        {
                                            cat2ID = dtRow[0]["cat2_id"].ToString();
                                            DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                            cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                        }
                                    }
                                    #endregion

                                    clsOrderReport objOrderedItems = new clsOrderReport();
                                    objOrderedItems.Quantity = Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString());
                                    objOrderedItems.ItemName = tempRow.Cells[0].Value.ToString();
                                    //objOrderedItems.Price = Convert.ToDouble("0" + tempRow.Cells[2].Value.ToString());
                                    //ater adding vat col in grid index  is changed
                                    objOrderedItems.Price = Convert.ToDouble("0" + tempRow.Cells[3].Value.ToString());
                                    //htOrderedItems.Add(cat2ID + "-" + objOrderedItems.ItemName, objOrderedItems);//Showing the products according to categpry 2
                                    Int64 rankNumber = Int64.Parse(tempRow.Cells[5].Value.ToString());

                                    Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                                    htOrderedItems.Add(category1OrderNumber + "-" + rankNumber + "-" + objOrderedItems.ItemName, objOrderedItems);//Category 1 wise separator
                                }
                            }

                            NumericComparer nc = new NumericComparer();
                            slorderedItems = new SortedList(htOrderedItems, nc);

                            int keyIndex = 0;
                            string[] valueSplitter = new string[0];
                            SortedList slMiscellaneousItems = new SortedList(); //Only for miscellenious category

                            PrintUtility printUtility = new PrintUtility();

                            foreach (clsOrderReport objReport in slorderedItems.Values)
                            {
                                string keyValue = slorderedItems.GetKey(keyIndex).ToString();
                                valueSplitter = keyValue.Split('-');

                                if ((categoryID != Convert.ToInt32("0" + valueSplitter[0].ToString())) && Convert.ToInt32("0" + valueSplitter[0].ToString()) != 0)//Insert separator
                                {
                                    categoryID = Convert.ToInt32("0" + valueSplitter[0].ToString());
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n";
                                    serialBody.Add(tempSerialPrintContent);

                                    tempSerialPrintContent = new CSerialPrintContent();

                                    /*tempSerialPrintContent.StringLine += objReport.Quantity.ToString() + "  ";
                                     tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objReport.ItemName, 30);
                                     tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);*/

                                    //tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                    //objReport.ItemName.ToString(), objReport.Price.ToString("F02"));

                                    //if (qty_length_with_twospace + objReport.ItemName.Length + objReport.Price.ToString().Length <= printlinelength)
                                    //{
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(),
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //}
                                    //else
                                    //{
                                    //    // line 1
                                    //    int itemname_firstline_length = printlinelength - 4 - 1 - objReport.Price.ToString().Length;
                                    //    string itemname_first_part = objReport.ItemName.Substring(0, itemname_firstline_length);
                                    //    string itemname_second_part = objReport.ItemName.Substring(itemname_firstline_length);
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + itemname_first_part,
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //    // line 2
                                    //    tempSerialPrintContent.StringLine += "\r\n   "
                                    //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                    //                                    " ");
                                    //}

                                    tempSerialPrintContent.StringLine +=
                                                                        strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                                                       printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");


                                    serialBody.Add(tempSerialPrintContent);
                                }
                                else if (valueSplitter[0].ToString() == "0") //Used for miscellenious items. i.e these items have no parent category.
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();

                                    /*tempSerialPrintContent.StringLine += objReport.Quantity.ToString() + "  ";
                                    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objReport.ItemName, 30);
                                    tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);*/

                                    //tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                    //objReport.ItemName.ToString(), objReport.Price.ToString("F02"));


                                    //if (qty_length_with_twospace + objReport.ItemName.Length + objReport.Price.ToString().Length <= printlinelength)
                                    //{
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(),
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //}
                                    //else
                                    //{
                                    //    // line 1
                                    //    int itemname_firstline_length = printlinelength - 4 - 1 - objReport.Price.ToString().Length;
                                    //    string itemname_first_part = objReport.ItemName.Substring(0, itemname_firstline_length);
                                    //    string itemname_second_part = objReport.ItemName.Substring(itemname_firstline_length);
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + itemname_first_part,
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //    // line 2
                                    //    tempSerialPrintContent.StringLine += "\r\n   "
                                    //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                    //                                    " ");
                                    //}

                                    tempSerialPrintContent.StringLine +=
                                                                   strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                                                    printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");

                                    slMiscellaneousItems.Add(slMiscellaneousItems.Count, tempSerialPrintContent);
                                }
                                else
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();

                                    /*tempSerialPrintContent.StringLine += objReport.Quantity.ToString() + "  ";
                                    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objReport.ItemName, 30);
                                    tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objReport.Price.ToString("F02"), 6);*/

                                    //tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                    //objReport.ItemName.ToString(), objReport.Price.ToString("F02"));
                                    //if (qty_length_with_twospace + objReport.ItemName.Length + objReport.Price.ToString().Length <= printlinelength)
                                    //{
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + objReport.ItemName.ToString(),
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //}
                                    //else
                                    //{
                                    //    // line 1
                                    //    int itemname_firstline_length = printlinelength - 4 - 1 - objReport.Price.ToString().Length;
                                    //    string itemname_first_part = objReport.ItemName.Substring(0, itemname_firstline_length);
                                    //    string itemname_second_part = objReport.ItemName.Substring(itemname_firstline_length);
                                    //    tempSerialPrintContent.StringLine += "\r\n"
                                    //                                    + strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " + itemname_first_part,
                                    //                                    " " + objReport.Price.ToString("F02"));
                                    //    // line 2
                                    //    tempSerialPrintContent.StringLine += "\r\n   "
                                    //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                    //                                    " ");
                                    //}

                                    tempSerialPrintContent.StringLine +=
                                                                  strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                                                                    printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");


                                    serialBody.Add(tempSerialPrintContent);
                                }
                                keyIndex++;
                            }

                            //Add the miscellaneous items with the separator
                            if (slMiscellaneousItems.Count > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous") + "\r\n";
                                serialBody.Add(tempSerialPrintContent);

                                foreach (CSerialPrintContent tempSerialContent in slMiscellaneousItems.Values)
                                {
                                    serialBody.Add(tempSerialContent);
                                }
                            }

                            for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
                            {
                                DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];

                                if (rowIndex == 0 && (!tempRow.Cells[0].Value.ToString().Equals("")))
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n";
                                    serialBody.Add(tempSerialPrintContent);
                                }

                                if (!tempRow.Cells[0].Value.ToString().Equals(""))
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();

                                    /*tempSerialPrintContent.StringLine = tempRow.Cells[1].Value.ToString() + "  ";
                                    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(tempRow.Cells[0].Value.ToString(), 30);
                                    tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(tempRow.Cells[2].Value.ToString(), 6);*/

                                    tempSerialPrintContent.StringLine +=
                                                                     strPrintFormatter.ItemLabeledText(tempRow.Cells[1].Value.ToString() + "  " +
                                                                   printUtility.MultipleLine(tempRow.Cells[0].Value.ToString(), papersize - 10, tempRow.Cells[3].Value.ToString(), papersize - 5), "");


                                    //tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(tempRow.Cells[1].Value.ToString() + "  " +
                                    //tempRow.Cells[0].Value.ToString(), tempRow.Cells[2].Value.ToString());


                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }
                        }

                        else
                        {
                            //For online orders
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                            serialBody.Add(tempSerialPrintContent);

                            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
                            {
                                if (Convert.ToInt32("0" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value) > 0)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();


                                    /*  tempSerialPrintContent.StringLine += Convert.ToString(g_FoodDataGridView.Rows[rowIndex].Cells[1].Value) + "  ";
                                      tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(Convert.ToString(g_FoodDataGridView.Rows[rowIndex].Cells[0].Value), 30);
                                      tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(Convert.ToDouble("0" + g_FoodDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), 6);*/
                                    //**************//
                                    tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() + "  " +
                                    (g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString()), (Convert.ToDouble("0" + g_FoodDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02")));

                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }


                            for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.RowCount; rowIndex++)
                            {
                                if (Convert.ToInt32("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) > 0)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();


                                    /*tempSerialPrintContent.StringLine += Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) + "  ";
                                    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(Convert.ToString(g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value), 30);
                                    tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02"), 6);*/

                                    tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value.ToString() + "  " +
                                   (g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value.ToString()), (Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02")));

                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }
                        }

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);
                        decimal discountAmount = decimal.Parse(g_DiscountLabel.Text);
                        Decimal totalAmount = Decimal.Parse(g_AmountLabel.Text);
                        Decimal billTotal = discountAmount + totalAmount;

                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "                      Order Total: " + billTotal.ToString("F02");
                        //serialBody.Add(tempSerialPrintContent);

                        //New at 02.03.2009
                        tempSerialPrintContent = new CSerialPrintContent();
                        // tempSerialPrintContent.StringLine = "                      Order Total: " + this.GetOrderTotal().ToString("F02");

                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Order Amount: ", GetOrderTotal().ToString("F02"));

                        serialBody.Add(tempSerialPrintContent);


                        if (discountAmount > 0)
                        {
                            decimal itemCost = this.GetOrderTotal();
                            tempSerialPrintContent = new CSerialPrintContent();
                            decimal discountPercent = 100 * discountAmount / (itemCost); //Discount is based on the total item cost
                            //tempSerialPrintContent.StringLine = "                  Discount:(" + discountPercent.ToString("F02") + "%) " +Convert.ToDecimal(g_DiscountLabel.Text).ToString("F02");
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Discount(" + discountPercent.ToString("F02") + "%): ", Convert.ToDecimal(g_DiscountLabel.Text).ToString("F02"));

                            serialBody.Add(tempSerialPrintContent);
                        }

                        double itemiscount = Convert.ToDouble(totalItemWiseDiscountlabel.Text);

                        if (itemiscount > 0)
                        {
                           
                            tempSerialPrintContent = new CSerialPrintContent();
                            //Discount is based on the total item cost
                            //tempSerialPrintContent.StringLine = "                  Discount:(" + discountPercent.ToString("F02") + "%) " +Convert.ToDecimal(g_DiscountLabel.Text).ToString("F02");
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText(" Item Discount: ", itemiscount.ToString("F02"));

                            serialBody.Add(tempSerialPrintContent);
                        }



                        if (Convert.ToDouble("0" + g_serviceCharge.Text) > 0) //If service charge is assigned
                        {
                            CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
                            ServiceCharge serviceCharge = cResult.Data as ServiceCharge;

                            tempSerialPrintContent = new CSerialPrintContent();
                            //tempSerialPrintContent.StringLine = "               Service Charge: " + Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02");
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge(" + serviceCharge.ServicechargeRate.ToString("F02") + "%): ", Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02"));

                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (isVatEnabled) //If vat is assigned
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            //tempSerialPrintContent.StringLine = "                          Vat("+vat.ToString()+"%): " + Convert.ToDecimal("0" + lblVat.Text).ToString("F02");
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Vat Total(15%) : ", Convert.ToDecimal("0" + lblVat.Text).ToString("F02"));

                            serialBody.Add(tempSerialPrintContent);
                        }

                        //tempSerialPrintContent = new CSerialPrintContent();
                        //double payableAmount = Convert.ToDouble("0" + g_serviceCharge.Text) + Convert.ToDouble("0" + g_AmountLabel.Text);
                        //tempSerialPrintContent.StringLine = "                    Total Payable: " + payableAmount.ToString("F02");
                        //serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();

                        // tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        decimal payableAmount = Convert.ToDecimal(Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02")) + Convert.ToDecimal(this.GetOrderTotal()) - Convert.ToDecimal(Convert.ToDecimal("0" + g_DiscountLabel.Text).ToString("F02"));
                        payableAmount = Convert.ToDecimal(Convert.ToDouble(payableAmount) * (1 + vat / 100));

                        //tempSerialPrintContent.StringLine = "                    Total Payable: " + payableAmount.ToString("F02");

                        //tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", payableAmount.ToString("F02"));
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total: ", Convert.ToDecimal("0" + g_AmountLabel.Text).ToString("F02"));

                        serialBody.Add(tempSerialPrintContent);


                        //if (Convert.ToDouble("0" + g_serviceCharge.Text) == 0)//If service charge is not assigned then blank for assigining.
                        //{
                        //    tempSerialPrintContent = new CSerialPrintContent();
                        //    //tempSerialPrintContent.StringLine = "               Service Charge:______";

                        //    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge:", " ______");
                        //    serialBody.Add(tempSerialPrintContent);
                        //}

                        tempSerialPrintContent = new CSerialPrintContent();

                        // tempSerialPrintContent.StringLine = "----------------------------------------";
                        tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);

                        //New at 22.08.2008
                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "You've Served by :" + m_OperatorName;
                        tempSerialPrintContent.StringLine = "\r\nYou've Served by:" + m_OperatorName;

                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + m_TerminalName.Trim();
                        serialBody.Add(tempSerialPrintContent);
                        //------------------------
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nS/N: " + tempOrderInfo.SerialNo.ToString() + "\n";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "----------------------------------------";

                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();


                        serialBody.Add(tempSerialPrintContent);

                        //For Vat Registration Number

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nVat Registration No : " + Program.vatRegDes.ToString(); // Change by Mithu
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "----------------------------------------";

                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();


                        serialBody.Add(tempSerialPrintContent);



                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "\r\nDeveloped By: www.ibacs.co.uk";
                        //serialBody.Add(tempSerialPrintContent);


                        #region "Testing printing area"
                        string printingObject = "";
                        for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                        {
                            printingObject += serialBody[arrayIndex].StringLine.ToString();
                        }

                        this.WriteString(printingObject);///Write to a file when print command is executed


                        #endregion

                        // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                        tempPrintMethods.USBPrint(printingObject, PrintDestiNation.CLIENT, true);
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
                        this.ChangeGuestBillPrintStatus();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            

           
        }

        private void PrintA5GuestBillReport() // Change by Mithu
        {
            int papersize = 70;
            StringPrintFormater strPrintFormatter = new StringPrintFormater(70);

            string Cat1ID = String.Empty;

            try
            {
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                //CPrintMethods tempPrintMethods = new CPrintMethods();
                int categoryID = 0;
                //serial print 
                //string serialHeader = "IBACS RMS";
                string serialHeader = "";
                //string serialFooter = "Please Come Again";
                string serialFooter = "";

                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("GUEST BILL");
                tempSerialPrintContent.Bold = true;


                serialBody.Add(tempSerialPrintContent);

                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;

                //string s=tempOrderInfo.
                if (m_iType == m_cCommonConstants.TableType)
                {
                    //Order ID line remove from report for requisting user 
                    // Sajib Vai gathered user requirement 
                    //Date : 13-02-2012
                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + orderID.ToString();
                    //serialBody.Add(tempSerialPrintContent);


                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "\r\n\nTable Number:" + tempOrderInfo.TableNumber.ToString();
                    //serialBody.Add(tempSerialPrintContent);                   

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Table No: " + m_iTableNumber.ToString(), "") + "\r\n";
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText("Guest No: " + tempOrderInfo.GuestCount.ToString(), "") + "\r\n";
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Print Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt") + "\r\n";
                    serialBody.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Covers: " + tempOrderInfo.GuestCount.ToString() + "\r\n";
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                    COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
                    if (orderWaiter != null && orderWaiter.WaiterID > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Waiter Name: " + orderWaiter.WaiterName + "\r\n";
                        //tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                    }
                } // Change by Mithu

        //private void PrintA5GuestBillReport() // Change by Mithu
        //{
        //    int papersize = 70;
        //    StringPrintFormater strPrintFormatter = new StringPrintFormater(70);

        //    string Cat1ID = String.Empty;

        //    try
        //    {
        //        CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

        //        //CPrintMethods tempPrintMethods = new CPrintMethods();
        //        int categoryID = 0;
        //        //serial print 
        //        //string serialHeader = "IBACS RMS";
        //        string serialHeader = "";
        //        //string serialFooter = "Please Come Again";
        //        string serialFooter = "";

        //        List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
        //        CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
        //        //tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Guest Bill");
        //        tempSerialPrintContent.Bold = true;


        //        serialBody.Add(tempSerialPrintContent);

        //        COrderManager tempOrderManager = new COrderManager();
        //        COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;

        //        //string s=tempOrderInfo.
        //        if (m_iType == m_cCommonConstants.TableType)
        //        {

        //            tempSerialPrintContent = new CSerialPrintContent();
        //            //tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + orderID.ToString();

        //            serialBody.Add(tempSerialPrintContent);


        //            //tempSerialPrintContent = new CSerialPrintContent();
        //            //tempSerialPrintContent.StringLine = "\r\n\nTable Number:" + tempOrderInfo.TableNumber.ToString();
        //            //serialBody.Add(tempSerialPrintContent);


        //            tempSerialPrintContent = new CSerialPrintContent();
        //            //tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
        //            serialBody.Add(tempSerialPrintContent);

        //            tempSerialPrintContent = new CSerialPrintContent();
        //            //tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Table No: " + m_iTableNumber.ToString(), "Covers: " + tempOrderInfo.GuestCount.ToString()) + "\r\n";
        //            tempSerialPrintContent.Bold = true;
        //            serialBody.Add(tempSerialPrintContent);

        //            //tempSerialPrintContent = new CSerialPrintContent();
        //            //tempSerialPrintContent.StringLine = "Covers: " + tempOrderInfo.GuestCount.ToString() + "\r\n";
        //            //tempSerialPrintContent.Bold = true;
        //            //serialBody.Add(tempSerialPrintContent);
        //            COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
        //            COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(orderID);
        //            if (orderWaiter != null && orderWaiter.WaiterID > 0)
        //            {
        //                tempSerialPrintContent = new CSerialPrintContent();
        //                tempSerialPrintContent.StringLine = "Waiter Name: " + orderWaiter.WaiterName + "\r\n";
        //                //tempSerialPrintContent.Bold = true;
        //                serialBody.Add(tempSerialPrintContent);
        //            }
        //        } // Change by Mithu
                else if (m_iType == m_cCommonConstants.TakeAwayType)
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nOrder Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Type: " + tempOrderInfo.Status;
                    serialBody.Add(tempSerialPrintContent);

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    if (tempCustomerInfo.CustomerName.Length > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                        serialBody.Add(tempSerialPrintContent);
                    }

                    if (tempCustomerInfo.CustomerPhone.Length > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                        serialBody.Add(tempSerialPrintContent);
                    }


                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nAddress:";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
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

                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "Country:" + tempCustomerInfo.CustomerCountry;
                        //serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        //
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = orderID;
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
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Order Information");
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Item", "Qnty   Unit Price   Price(" + Program.currency + ")");
                serialBody.Add(tempSerialPrintContent);

                //Line after above line
                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";
                //serialBody.Add(tempSerialPrintContent);
                #region Populate List 
                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                {
                    Hashtable htOrderedItems = new Hashtable();
                    SortedList slorderedItems = null;

                    string categoryOrder = String.Empty;
                    int internalCategoryID = 0;
                    //Modification By Baruri at 04/08/2008
                    for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
                    {
                        internalCategoryID = 0;
                        string cat3ID = String.Empty;
                        string cat2ID = String.Empty;
                        string cat1ID = String.Empty;

                        DataGridViewRow tempRow = g_FoodDataGridView.Rows[rowIndex];
                        categoryOrder = String.Empty;

                        if (!tempRow.Cells[0].Value.ToString().Equals(""))
                        {
                            #region "Parent Category"

                            if (Convert.ToInt32("0" + tempRow.Cells[4].Value.ToString()) == 3)//Item from Category 3
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow.Cells[3].Value.ToString());
                                DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }
                            else if (Convert.ToInt32("0" + tempRow.Cells[4].Value.ToString()) == 0)
                            {
                                cat1ID = "0";
                                cat2ID = "0";
                            }

                            else
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow.Cells[3].Value.ToString());
                                DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat3ID = dtRow[0]["cat3_id"].ToString();
                                    if (cat3ID != "" || cat3ID != null)
                                    {
                                        dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                    }
                                    else
                                    {
                                        dtRow = null;
                                    }
                                }

                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }
                            #endregion

                            clsOrderReport objOrderedItems = new clsOrderReport();
                            objOrderedItems.Quantity = Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString());
                            objOrderedItems.ItemName = tempRow.Cells[0].Value.ToString();
                            objOrderedItems.Price = Convert.ToDouble("0" + tempRow.Cells[2].Value.ToString());
                            objOrderedItems.ItemUnitPrice = Convert.ToDouble("0" + tempRow.Cells[8].Value.ToString());
                            //htOrderedItems.Add(cat2ID + "-" + objOrderedItems.ItemName, objOrderedItems);//Showing the products according to categpry 2
                            Int64 rankNumber = Int64.Parse(tempRow.Cells[5].Value.ToString());

                            Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                            htOrderedItems.Add(category1OrderNumber + "-" + rankNumber + "-" + objOrderedItems.ItemName, objOrderedItems);//Category 1 wise separator
                        }
                    }
                #endregion

                    NumericComparer nc = new NumericComparer();
                    slorderedItems = new SortedList(htOrderedItems, nc);

                    int keyIndex = 0;
                    string[] valueSplitter = new string[0];
                    SortedList slMiscellaneousItems = new SortedList(); //Only for miscellenious category

                    PrintUtility printUtility = new PrintUtility();

                    foreach (clsOrderReport objReport in slorderedItems.Values)
                    {
                        string keyValue = slorderedItems.GetKey(keyIndex).ToString();
                        valueSplitter = keyValue.Split('-');

                        string priceString = printUtility.PupulateRightString(objReport.Quantity, objReport.ItemUnitPrice, objReport.Price);//objReport.Quantity.ToString() + "     " + objReport.ItemUnitPrice.ToString("f2") + "     " + objReport.Price.ToString("F02");
                     

                        if ((categoryID != Convert.ToInt32("0" + valueSplitter[0].ToString())) && Convert.ToInt32("0" + valueSplitter[0].ToString()) != 0)//Insert separator
                        {
                            categoryID = Convert.ToInt32("0" + valueSplitter[0].ToString());
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n";
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                         
                            //tempSerialPrintContent.StringLine +=
                            //                                    strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                            //                                   printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");

                            tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 32, priceString, papersize ), "");


                            serialBody.Add(tempSerialPrintContent);
                        }
                        else if (valueSplitter[0].ToString() == "0") //Used for miscellenious items. i.e these items have no parent category.
                        {
                            tempSerialPrintContent = new CSerialPrintContent();

                         

                            //tempSerialPrintContent.StringLine +=
                            //                               strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                            //                                printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");

                            tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 32, priceString, papersize ), "");


                            slMiscellaneousItems.Add(slMiscellaneousItems.Count, tempSerialPrintContent);
                        }
                        else
                        {
                            tempSerialPrintContent = new CSerialPrintContent();

                         

                            //tempSerialPrintContent.StringLine +=
                            //                              strPrintFormatter.ItemLabeledText(objReport.Quantity.ToString() + "  " +
                            //                                printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 10, objReport.Price.ToString("F02"), papersize - 5), "");

                            tempSerialPrintContent.StringLine +=
                                                             strPrintFormatter.ItemLabeledText(
                                                             printUtility.MultipleLine(objReport.ItemName.ToString(), papersize - 32, priceString, papersize), "");


                            serialBody.Add(tempSerialPrintContent);
                        }

                        keyIndex++;
                    }

                    //Add the miscellaneous items with the separator
                    if (slMiscellaneousItems.Count > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous") + "\r\n";
                        serialBody.Add(tempSerialPrintContent);

                        foreach (CSerialPrintContent tempSerialContent in slMiscellaneousItems.Values)
                        {
                            serialBody.Add(tempSerialContent);
                        }
                    }

                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow tempRow = g_BeverageDataGridView.Rows[rowIndex];

                        if (rowIndex == 0 && (!tempRow.Cells[0].Value.ToString().Equals("")))
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n";
                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (!tempRow.Cells[0].Value.ToString().Equals(""))
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                        //    string priceString1 = tempRow.Cells[1].Value.ToString() + "   " + tempRow.Cells[8].Value.ToString() + "   " + tempRow.Cells[2].Value.ToString();

                            string priceString = printUtility.PupulateRightString(Convert.ToInt32("0" + tempRow.Cells[1].Value.ToString()), Convert.ToDouble("0"+tempRow.Cells[8].Value.ToString()), Convert.ToDouble("0"+tempRow.Cells[2].Value.ToString()));//objReport.Quantity.ToString() + "     " + objReport.ItemUnitPrice.ToString("f2") + "     " + objReport.Price.ToString("F02");
                     

//                            string priceString = tempRow.Cells[1].Value.ToString() + "   " + tempRow.Cells[8].Value.ToString() + "   " + tempRow.Cells[2].Value.ToString();

                               //tempSerialPrintContent.StringLine +=
                               //                              strPrintFormatter.ItemLabeledText(tempRow.Cells[1].Value.ToString() + "  " +
                               //                            printUtility.MultipleLine(tempRow.Cells[0].Value.ToString(), papersize - 10, tempRow.Cells[2].Value.ToString(), papersize - 5), "");

                            tempSerialPrintContent.StringLine +=
                                                          strPrintFormatter.ItemLabeledText(
                                                        printUtility.MultipleLine(tempRow.Cells[0].Value.ToString(), papersize - 32, priceString, papersize ), "");
                            
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                else
                {
                    //For online orders
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);

                    for (int rowIndex = 0; rowIndex < g_FoodDataGridView.RowCount; rowIndex++)
                    {
                        if (Convert.ToInt32("0" + g_FoodDataGridView.Rows[rowIndex].Cells[1].Value) > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();

                            tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.ItemLabeledText(g_FoodDataGridView.Rows[rowIndex].Cells[1].Value.ToString() + "  " +
                            (g_FoodDataGridView.Rows[rowIndex].Cells[0].Value.ToString()), (Convert.ToDouble("0" + g_FoodDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02")));

                            serialBody.Add(tempSerialPrintContent);
                        }
                    }


                    for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.RowCount; rowIndex++)
                    {
                        if (Convert.ToInt32("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value) > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                      
                            tempSerialPrintContent.StringLine += strPrintFormatter.ItemLabeledText(g_BeverageDataGridView.Rows[rowIndex].Cells[1].Value.ToString() + "  " +
                           (g_BeverageDataGridView.Rows[rowIndex].Cells[0].Value.ToString()), (Convert.ToDouble("0" + g_BeverageDataGridView.Rows[rowIndex].Cells[2].Value).ToString("F02")));

                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                decimal discountAmount = decimal.Parse(g_DiscountLabel.Text);
                Decimal totalAmount = Decimal.Parse(g_AmountLabel.Text);
                Decimal billTotal = discountAmount + totalAmount;

                //New at 02.03.2009
                tempSerialPrintContent = new CSerialPrintContent();
            
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Order Total: ", GetOrderTotal().ToString("F02"));

                serialBody.Add(tempSerialPrintContent);


                if (discountAmount > 0)
                {
                    decimal itemCost = this.GetOrderTotal();
                    tempSerialPrintContent = new CSerialPrintContent();
                    decimal discountPercent = 100 * discountAmount / (itemCost); //Discount is based on the total item cost
         
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Discount:(" + discountPercent.ToString("F02") + "%) ", Convert.ToDecimal(g_DiscountLabel.Text).ToString("F02"));

                    serialBody.Add(tempSerialPrintContent);
                }

                if (Convert.ToDouble("0" + g_serviceCharge.Text) > 0) //If service charge is assigned
                {
                    CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
                    ServiceCharge serviceCharge = cResult.Data as ServiceCharge;

                    tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "               Service Charge: " + Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02");
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge(" + serviceCharge.ServicechargeRate.ToString() + "%): ", Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02"));

                    serialBody.Add(tempSerialPrintContent);
                }

                if (isVatEnabled) //If vat is assigned
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "                          Vat("+vat.ToString()+"%): " + Convert.ToDecimal("0" + lblVat.Text).ToString("F02");
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Vat(" + vat.ToString() + "%): ", Convert.ToDecimal("0" + lblVat.Text).ToString("F02"));

                    serialBody.Add(tempSerialPrintContent);
                }

                tempSerialPrintContent = new CSerialPrintContent();

                // tempSerialPrintContent.StringLine = "----------------------------------------";
                tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
          
                tempSerialPrintContent = new CSerialPrintContent();
                decimal payableAmount = Convert.ToDecimal(Convert.ToDecimal("0" + g_serviceCharge.Text).ToString("F02")) + Convert.ToDecimal(this.GetOrderTotal()) - Convert.ToDecimal(Convert.ToDecimal("0" + g_DiscountLabel.Text).ToString("F02"));
                payableAmount = Convert.ToDecimal(Convert.ToDouble(payableAmount) * (1 + vat / 100));

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", Convert.ToDecimal("0" + g_AmountLabel.Text).ToString("F02"));

                serialBody.Add(tempSerialPrintContent);


                tempSerialPrintContent = new CSerialPrintContent();

                // tempSerialPrintContent.StringLine = "----------------------------------------";
                tempSerialPrintContent.StringLine += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);

                //New at 22.08.2008
                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "You've Served by :" + m_OperatorName;
                tempSerialPrintContent.StringLine = "\r\nYou've Served by:" + m_OperatorName;

                serialBody.Add(tempSerialPrintContent);


                //Terminal Name and Serial No line remove from report for requisting user 
                // Sajib Vai gathered user requirement 
                //Date : 13-02-2012
                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "\r\n" + m_TerminalName.Trim();
                //serialBody.Add(tempSerialPrintContent);
                ////------------------------
                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "\r\nS/N: " + tempOrderInfo.SerialNo.ToString() + "\n";
                //serialBody.Add(tempSerialPrintContent);

                
                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();


                serialBody.Add(tempSerialPrintContent);

                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "\r\nDeveloped By: www.ibacs.co.uk";
                //serialBody.Add(tempSerialPrintContent);


                #region "Testing printing area"
                string printingObject = "";
                for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                {
                    printingObject += serialBody[arrayIndex].StringLine.ToString();
                }

                this.WriteString(printingObject);///Write to a file when print command is executed


                #endregion

                // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                tempPrintMethods.USBPrintA5Report(printingObject, PrintDestiNation.CLIENT, true, papersize);
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
                this.ChangeGuestBillPrintStatus();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Changing the print status of the printed orders
        /// </summary>
        private void ChangeGuestBillPrintStatus()
        {
            COrderManager objOrderManager = new COrderManager();
            objOrderManager.ChangeGuestBillPrintStatus(orderID);
        }

        private void CTableOrderForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                this.Init();
        }

        private void g_PromotionsButton_Click(object sender, EventArgs e)
        {
            CResult aCResult=new CResult();
            CUserInfoDAO aUserInfoDao=new CUserInfoDAO();
            CUserInfo aUserInfo = new CUserInfo();
            aUserInfo.UserID = RMSGlobal.m_iLoginUserID;
            aCResult = aUserInfoDao.GetUser(aUserInfo);
            aUserInfo = (CUserInfo)aCResult.Data;

            if (aUserInfo.Type != 0)
            {
                MessageBox.Show("You are not correct person to give discount");
                return;
            }
            


            //CDiscountForm tempDiscountForm = new CDiscountForm();
            //tempDiscountForm.ShowDialog();

            //if (CDiscountForm.discountType.Equals("Cancel"))
            //    return;

            //m_dDiscountAmount = Convert.ToDecimal(CDiscountForm.discountAmount);
            //m_sDiscountType = CDiscountForm.discountType;
            //double discountAmount = 0;

            //List<COrderDetails> aCOrderDetailses=new List<COrderDetails>();
            //foreach (DataGridViewRow row in g_FoodDataGridView.Rows)
            //{

            //    if(Convert.ToBoolean(row.Cells["foodselect"].Value)==true)
            //    {
            //        COrderDetails aCOrderDetails=new COrderDetails();
            //        aCOrderDetails.ProductID = Convert.ToInt32(row.Cells["Cat_id"].Value);
            //        aCOrderDetails.OrderQuantity = Convert.ToInt32(row.Cells["Qty"].Value);
            //        aCOrderDetails.UnitPrice = Convert.ToDouble(row.Cells["unitPrice"].Value);
            //        aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["Order_details_id"].Value);
            //        aCOrderDetails.OrderAmount = Convert.ToDouble(row.Cells["Price"].Value);
            //        aCOrderDetails.DiscountAmount = (((double)m_dDiscountAmount)*aCOrderDetails.OrderAmount)/100;
            //        discountAmount += aCOrderDetails.DiscountAmount;
            //        aCOrderDetailses.Add(aCOrderDetails);

            //    }

            //}

            //foreach (DataGridViewRow row in g_BeverageDataGridView.Rows)
            //{

            //    if (Convert.ToBoolean(row.Cells["nonfoodselect"].Value) == true)
            //    {
            //        COrderDetails aCOrderDetails = new COrderDetails();
            //        aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["dataGridViewTextBoxColumn5"].Value);
            //        aCOrderDetails.OrderAmount = Convert.ToDouble(row.Cells["dataGridViewTextBoxColumn7"].Value);
            //        aCOrderDetails.DiscountAmount = (((double)m_dDiscountAmount) * aCOrderDetails.OrderAmount) / 100;
            //        discountAmount += aCOrderDetails.DiscountAmount;
            //        aCOrderDetailses.Add(aCOrderDetails);

            //    }

            //}
            //COrderDetailsDAO aOrderDetailsDao=new COrderDetailsDAO();
            //string result = aOrderDetailsDao.UpdateItemWiseDiscount(aCOrderDetailses);
            //MessageBox.Show(result);




             //COrderManager tempOrderManager = new COrderManager();
             //   COrderDiscount tempOrderDiscount = new COrderDiscount();
             //   CResult oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
             //   if (oResult.IsSuccess && oResult.Data != null)
             //   {

             //       tempOrderDiscount = (COrderDiscount)oResult.Data;


             //       if (membership != null && membership.id > 0)
             //       {
             //           tempOrderDiscount.clientID = membership.customerID;
             //           tempOrderDiscount.membershipCardID = membership.mebershipCardID;
             //           tempOrderDiscount.membershipID = membership.id;
             //           tempOrderDiscount.membershipPoint = membership.point;
             //           tempOrderDiscount.membershipDiscountRate = membership.discountPercentRate;
                    
             //       }
                   

             //       //update
             //        tempOrderDiscount.Discount = Convert.ToDouble(discountAmount);
             //       tempOrderManager.UpdateOrderDiscount(tempOrderDiscount);

                 
             //   }
             //   else
             //   {
             //       //insert
             //       tempOrderDiscount.OrderID = orderID;
             //         tempOrderDiscount.Discount = Convert.ToDouble(discountAmount);

             //       if (membership != null && membership.id > 0)
             //       {
             //           tempOrderDiscount.clientID = membership.customerID;
             //           tempOrderDiscount.membershipCardID = membership.mebershipCardID;
             //           tempOrderDiscount.membershipID = membership.id;
             //           tempOrderDiscount.membershipPoint = membership.point;
             //           tempOrderDiscount.membershipDiscountRate = membership.discountPercentRate;

                   
             //       }

             //       tempOrderManager.InsertOrderDiscount(tempOrderDiscount);
             //   }


            CDiscountForm tempDiscountForm = new CDiscountForm();
            tempDiscountForm.ShowDialog();

            if (CDiscountForm.discountType.Equals("Cancel"))
                return;

            m_dDiscountAmount = Convert.ToDecimal(CDiscountForm.discountAmount);
            m_sDiscountType = CDiscountForm.discountType;
            TotalAmountCalculation();
        }

        private void CTableOrderForm_Activated(object sender, EventArgs e)
        {
            try
            {
                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CResult oResult = tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                CPcInfo tempPcInfo = new CPcInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)oResult.Data;
                }
                m_TerminalName = "Terminal Name:" + tempPcInfo.Name;
                this.SetPrintedItemBackColor();
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void g_ServiceChargeButton_Click(object sender, EventArgs e)
        {
            Double MainFoodTotal = 0;//@Salim Only for Main Item with out additional service charge or discount
            Double tempTotal = 0.0;
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
            {
                if (g_FoodDataGridView[3, rowIndex].Value != null && !g_FoodDataGridView[3, rowIndex].Value.ToString().Equals(""))
                {
                    tempTotal += Double.Parse(g_FoodDataGridView[3, rowIndex].Value.ToString());
                }
            }
            for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
            {
                if (g_BeverageDataGridView[3, rowIndex].Value != null && !g_BeverageDataGridView[3, rowIndex].Value.ToString().Equals(""))
                {
                    tempTotal += Double.Parse(g_BeverageDataGridView[3, rowIndex].Value.ToString());
                }
            }
            MainFoodTotal = tempTotal;
            ChargeAmountForm tempChargeForm = new ChargeAmountForm();//Change by Mithu
            tempChargeForm.ShowDialog(); //Change by Mithu


            //ServiceChargeControl objSvcCtl = new ServiceChargeControl(this);//Change by Mithu
            //g_ItemSelectionFlowLayoutPanel.Controls.Clear();//Change by Mithu
            //g_ItemSelectionFlowLayoutPanel.Controls.Add(objSvcCtl);//Change by Mithu

            if (ChargeAmountForm.m_serviceChargeType.Equals("Cancel"))//Change by Mithu
                return;

            m_chargeAmount = ChargeAmountForm.m_serviceChargeAmount;//Change by Mithu
            m_chargeType = ChargeAmountForm.m_serviceChargeType;//Change by Mithu

            Double chargeAmount = 0.000;
            Double servicechargeRate = 0.000;
            if (m_chargeType.Equals("Fixed"))//Change by Mithu
            {
                chargeAmount = m_chargeAmount;//Change by Mithu

                servicechargeRate =  m_chargeAmount * 100 / MainFoodTotal;//Change by Mithu

            }
            else if (m_chargeType.Equals("Percent"))//Change by Mithu
            {
              chargeAmount = tempTotal * m_chargeAmount / 100;//Change by Mithu

            //chargeAmount = MainFoodTotal * 10 / 100; // Change by Mithu
              chargeAmount = MainFoodTotal * m_chargeAmount / 100;

              servicechargeRate = m_chargeAmount;
            }//Change by Mithu
            COrderManager tempOrderManager = new COrderManager();
            ServiceCharge tempOrderCharge = new ServiceCharge();
            CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
            if (cResult.IsSuccess && cResult.Data != null)
            {
                tempOrderCharge = (ServiceCharge)cResult.Data;

                //update
                tempOrderCharge.OrderID = orderID;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                tempOrderManager.UpdateOrderServiceCharge(tempOrderCharge);
            }

            else
            {
                //insert
                tempOrderCharge.OrderID = orderID;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                tempOrderManager.InsertOrderServiceCharge(tempOrderCharge);
            }
           

         
            serviceCharge = chargeAmount.ToString("F02"); //Service charge amount
            g_serviceCharge.Text = chargeAmount.ToString("F02");

            tempTotal = (tempTotal + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text));
            //Field for vat
          //  lblVat.Text = (MainFoodTotal * (vat / 100)).ToString("F02");

            //  g_AmountLabel.Text = (tempTotal + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text)).ToString(); //Deduct the discount amount

            // g_AmountLabel.Text = (tempTotal * (1 + (vat / 100))).ToString("F02");
            g_AmountLabel.Text = (MainFoodTotal + double.Parse(lblVat.Text) + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text)).ToString("F02");
           // this.ServiceChargeModification();
        }

        private void ServiceChargeModification()
        {
            double chargeAmount = double.Parse(g_serviceCharge.Text);//Charge amount from the label

            COrderManager tempOrderManager = new COrderManager();
            ServiceCharge tempOrderCharge = new ServiceCharge();
            CResult oResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempOrderCharge = (ServiceCharge)oResult.Data;

                //update service charge
                tempOrderCharge.ServiceChargeAmount = chargeAmount;
                tempOrderCharge.OrderID = orderID;
                tempOrderManager.UpdateOrderServiceCharge(tempOrderCharge);
            }
            else
            {
                //insert service charge
                tempOrderCharge.OrderID = orderID;
                tempOrderCharge.ServiceChargeAmount = chargeAmount;
                tempOrderManager.InsertOrderServiceCharge(tempOrderCharge);
            }
        }


        #endregion


        private void g_SeatButton_Click(object sender, EventArgs e)
        {
            if (m_iDataGridViewCurrentRowIndex == -1)
            {
                CMessageBox tempMessageBox = new CMessageBox("Error!", "Please select ordered food or beverage.");
                tempMessageBox.ShowDialog();
                return;
            }

            if (m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value == null || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value == null || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value == "" || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString() == "" || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value.ToString().Length < 1 || m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value.ToString().Length < 1)
            {
                return;
            }
            try
            {
                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper()) //If local order is considered
                {
                    COrderDetails objOrderDetails = new COrderDetails();
                    Int64 itemSequenceNumber = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value);
                    int quantity = Convert.ToInt32("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value);
                    double vat = Convert.ToDouble("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value);
                    double amount = Convert.ToDouble("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value);

                    //
                    double vateRate = vat / quantity;
                    double totalVat = (vateRate) * (quantity + 1);
                    objOrderDetails.VatTotal = totalVat;
                    amount = (amount / quantity) * (quantity + 1); //Calculate the total amount
                    quantity++; //Increasing the quantity of items
                    Int64 productID = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[4].Value);

                    objOrderDetails.ProductID = productID;
                    objOrderDetails.OrderAmount = amount;
                    objOrderDetails.OrderQuantity = quantity;
                    objOrderDetails.OrderID = orderID;
                    objOrderDetails.Amount_with_vat = objOrderDetails.OrderAmount + objOrderDetails.VatTotal;
                    objOrderDetails.OrderDetailsID = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[7].Value);
                    COrderManager objOrderManager = new COrderManager();
                    objOrderManager.AddNewLocalProducts(objOrderDetails); //Increasing Items's quantity for local orders 
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = quantity;
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = totalVat.ToString("F02");
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value = amount.ToString("F02");

                }
                else
                {
                    COrderDetails objOrderDetails = new COrderDetails();
                    Int64 itemSequenceNumber = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[5].Value);
                    int quantity = Convert.ToInt32("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value);
                    double vat = Convert.ToDouble("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value);
                    double amount = Convert.ToDouble("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value);
                    double vateRate = amount / quantity;
                    double totalVat = (vateRate) * (quantity + 1);
                    objOrderDetails.VatTotal = totalVat;
                    amount = (amount / quantity) * (quantity + 1); //Calculate the total amount
                    quantity++; //Increasing the quantity of items

                    objOrderDetails.OnlineItemSequenceNumber = itemSequenceNumber;
                    objOrderDetails.OrderAmount = amount;
                    objOrderDetails.OrderQuantity = quantity;
                    objOrderDetails.OrderDetailsID = Convert.ToInt64("0" + m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[6].Value);
                    COrderManager objOrderManager = new COrderManager();
                    objOrderManager.AddNewOnlineProducts(objOrderDetails);
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[1].Value = quantity;
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[2].Value = totalVat.ToString("F02");
                    m_dDataGridView.Rows[m_iDataGridViewCurrentRowIndex].Cells[3].Value = amount.ToString("F02");
                }

                m_dDataGridView.Update();
                TotalAmountCalculation();
                m_dDataGridView.ClearSelection();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            this.SetPrintedItemBackColor(); //set the back color
        }

        private void btnKitchenText_Click(object sender, EventArgs e)
        {
            try
            {
                KitchenTextPrintForm objKitchenTextFrm = new KitchenTextPrintForm(m_TerminalName);
                objKitchenTextFrm.m_orderID = orderID;
                objKitchenTextFrm.ShowDialog();
                btnOrderLog_Click(sender, e);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void CTableOrderForm_Load(object sender, EventArgs e)
        {
            //g_ServiceChargeButton.Enabled = false; // Change by Mithu
            //dtpStart.Visible = false;
            xmlDoc = new XmlDocument();
            string executableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo executableFileInfo = new FileInfo(executableName);
            currentDirectory = executableFileInfo.DirectoryName + "\\Config";
            xmlDoc.Load(currentDirectory + "\\CommonConstants.xml");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("CCommonConstants/PrinterTypeName");

            this.Init();
            this.LoadOrderDetails();
            this.FillSummary();//New added by baruri at 31.01.2009   


            CUserManager tempUserManager = new CUserManager();
            CResult tempResult = tempUserManager.GetAllUser();
            if (tempResult.IsSuccess)
            {
                 userList = new List<CUserInfo>();
                userList = (List<CUserInfo>)tempResult.Data;              
            }
        }

        //private void btnPLU_Click(object sender, EventArgs e)
        //{
            
            
        //    int priceTakeType;
        //    Int32 productPLU = 0;
        //    int returnVal = 0;
        //    Int32 productQuantity = 0;
        //    COrderManager objOrderManager = new COrderManager();


        //    if (m_iType == m_cCommonConstants.TableType)
        //    {
        //        priceTakeType = 1;
        //    }
        //    else if (m_iType == m_cCommonConstants.TakeAwayType)
        //    {
        //        priceTakeType = 2;
        //    }
        //    else
        //    {
        //        priceTakeType = 3;
        //    }

        //    CCalculatorForm tableNumberForm = new CCalculatorForm("Product PLU Information", "PLU of the Product");
        //    tableNumberForm.ShowDialog();

        //    if (CCalculatorForm.inputResult.Equals("Cancel"))
        //        return;

        //    if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
        //    {
        //        CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
        //        tempMessageBox.ShowDialog();
        //        return;
        //    }

        //    productPLU = Convert.ToInt32("0" + CCalculatorForm.inputResult);



        //    CResult objProductName = objOrderManager.GetProductByProductPLU(productPLU);
        //    if (Convert.ToString(objProductName.Data) == "NO")
        //    {
        //        CMessageBox tempMessageBox = new CMessageBox("Error", "Invalid PLU.Please enter valid PLU");
        //        tempMessageBox.ShowDialog();
        //        return;
        //    }


        //    ProductQuantityForm quantityForm = new ProductQuantityForm(Convert.ToString(objProductName.Data));
        //    quantityForm.ShowDialog();

        //    if (ProductQuantityForm.m_productQuantity.Equals("Cancel"))
        //    {
        //        return;
        //    }
        //    if (ProductQuantityForm.m_productQuantity.Equals("") || Int32.Parse(ProductQuantityForm.m_productQuantity) == 0)
        //    {
        //        CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
        //        tempMessageBox.ShowDialog();
        //        return;
        //    }

        //    productQuantity = Convert.ToInt32("0" + ProductQuantityForm.m_productQuantity);



        //    CResult oResult = objOrderManager.GetPluDataByProductPLU(productPLU, priceTakeType, orderID, productQuantity);

        //    if (oResult.IsSuccess && oResult.Data != null)
        //    {
        //        returnVal = int.Parse(oResult.Data.ToString());

        //        //for vat includr option

        //        String queryStr = SqlQueries.GetQuery(Query.LastPLUOrderDetails);
        //        CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
        //        String tempConnStr = oTempDal.ConnectionString;
        //        // Create a new data adapter based on the specified query.
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);
        //        // Populate a new data table and bind it to the BindingSource.
        //        DataTable table = new DataTable();
        //        //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //        dataAdapter.Fill(table);

        //        int CategoryID = Convert.ToInt32(table.Rows[0]["product_id"].ToString());
        //        Double amount = Convert.ToDouble(table.Rows[0]["amount"].ToString());

        //        int catLavel=Convert.ToInt32(table.Rows[0]["cat_level"].ToString());
        //        //vat in cat Three

        //        double vatRate = 0;
        //        bool vat_included = false;
        //        double vatAmountRate = 0;
        //        if(catLavel==3)
        //        {
        //        DataRow[] temp2DataRowArray = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + CategoryID.ToString());

        //        vatRate = 0;
        //        vat_included = false;
        //        vatAmountRate = 0;
        //        try
        //        {
        //            vatRate = Convert.ToDouble(temp2DataRowArray[0]["vat_Rate"].ToString());
        //            vat_included = Convert.ToBoolean(temp2DataRowArray[0]["vat_included"].ToString());

        //            if (vat_included)
        //            {
        //                vatAmountRate = (amount * vatRate) / 100;

        //                // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
        //                // tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
        //            }
        //            else
        //            {
        //                vatAmountRate = 0.00;
        //            }

        //        }
        //        catch (Exception ex) { }
                
        //        }

        //        if(catLavel==4)
        //        {
        //            DataRow[] temp3DataRowArray = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + CategoryID);

        //        vatRate = 0;
        //        vat_included = false;
        //        vatAmountRate = 0;
        //        try
        //        {
        //            vatRate = Convert.ToDouble(temp3DataRowArray[0]["vat_Rate"].ToString());
        //            vat_included = Convert.ToBoolean(temp3DataRowArray[0]["vat_included"].ToString());

        //            if (vat_included)
        //            {
        //                vatAmountRate = (amount * vatRate) / 100;

        //                // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
        //                // tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
        //            }
        //            else
        //            {
        //                vatAmountRate = 0.00;
        //            }

        //        }
        //        catch (Exception ex) { }

        //        }



        //        //string tableTypePrice = string.Empty;
        //        //if (m_iType == m_cCommonConstants.TableType)
        //        //{
        //        //    tableTypePrice = temp2DataRowArray[0]["table_price"].ToString();
        //        //}
        //        //else if (m_iType == m_cCommonConstants.TakeAwayType)
        //        //{
        //        //    tableTypePrice = temp2DataRowArray[0]["tw_price"].ToString();
        //        //}

                

        //        COrderManager tempOrderManager = new COrderManager();
        //        COrderDetails tempOrderDetails = new COrderDetails();



        //        if (returnVal == 1)
        //        {
        //            //update Order_details table
        //            //int tempRowIndex = tempResult;
        //            //int qty = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
        //            //tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
        //            //tempDataGridView.Rows[tempRowIndex].Cells[2].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
        //            tempOrderDetails.OrderDetailsID = Convert.ToInt32(table.Rows[0]["order_detail_id"].ToString());
        //            tempOrderDetails.OrderID =Convert.ToInt32(table.Rows[0]["order_id"].ToString());
        //            tempOrderDetails.ProductID =Convert.ToInt32( table.Rows[0]["product_id"].ToString());
        //            tempOrderDetails.CategoryLevel = Convert.ToInt32(table.Rows[0]["cat_level"].ToString());
        //            tempOrderDetails.UnitPrice = 0.00;
        //            tempOrderDetails.OrderQuantity = Convert.ToInt32(table.Rows[0]["quantity"].ToString());
        //            tempOrderDetails.OrderAmount = Convert.ToDouble(table.Rows[0]["amount"].ToString());
        //            tempOrderDetails.OrderFoodType = table.Rows[0]["food_type"].ToString();
        //           // tempOrderDetails.OnlineItemSequenceNumber = Convert.ToInt64("0" + tempDataGridView.Rows[tempRowIndex].Cells[5].Value.ToString());
        //           // tempOrderDetails.PrintedQuantity = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[7].Value.ToString());
        //            if (vat_included)
        //            {
        //                tempOrderDetails.VatTotal = vatAmountRate;
        //            }
        //            else
        //            {
        //                tempOrderDetails.VatTotal = 0.00;
        //            }

        //            //if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
        //            //{
        //            //    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
        //            //}
        //            //else
        //            //{
        //            //    tempOrderManager.UpdateOnlineOrderDetails(tempOrderDetails);
        //            //}

        //            try
        //            {
        //                tempOrderManager.UpdateOrderDetails(tempOrderDetails);
        //            }
        //            catch { }
        //        }


        //        //tempOrderDetails.VatTotal = vatAmountRate;
        //        //tempOrderDetails.OrderDetailsID =Convert.ToInt32(table.Rows[0]["order_detail_id"].ToString());
        //        //try 
        //        //{ 
        //        //tempOrderManager.UpdateOrderDetails(tempOrderDetails);
        //        //}
        //        //catch { }


        //    }

        //    if (returnVal == 0)
        //    {
        //        MessageBox.Show("Please enter valid plu product", RMSGlobal.MessageBoxTitle,
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        COrderDetailsDAO orderDetailsDao = new COrderDetailsDAO();               
        //        orderDetailsDao.UpdateOrderDetailsPricebyPLUProductTablePrice(productPLU, orderID, priceTakeType);               

        //    }

        //    this.LoadOrderDetails();
            
        //    btnPLU_Click(sender, e);
              
            
        //}



        private void btnPLU_Click(object sender, EventArgs e)
        {


            int priceTakeType;
            Int32 productPLU = 0;
            int returnVal = 0;
            Int32 productQuantity = 0;
            COrderManager objOrderManager = new COrderManager();


            if (m_iType == m_cCommonConstants.TableType)
            {
                priceTakeType = 1;
            }
            else if (m_iType == m_cCommonConstants.TakeAwayType)
            {
                priceTakeType = 2;
            }
            else
            {
                priceTakeType = 3;
            }

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


            // Add for find updating order_detail
            int id = productPLU;
            long order = orderID;
            COrderDetailsDAO aDao = new COrderDetailsDAO();
            List<COrderDetails> aList = aDao.OrderDetailsGetAll();

            //  CResult objProductName = objOrderManager.GetProductByProductPLU(productPLU, priceTakeType);
            CResult objProductName = objOrderManager.GetProductByProductPLU(productPLU);

            var check = (from orderdetail in aList
                         where (orderdetail.OrderID == orderID && orderdetail.ProductID == objProductName.Productid)
                         select orderdetail);




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


            // Add for updating order_detail when orderwith same product
            if (check.Count() == 1)
            {

                COrderDetails aOrderDetails = new COrderDetails();
                aOrderDetails = check.Single();
                //double vat = aOrderDetails.Amount_with_vat - aOrderDetails.OrderAmount;
                //vat = (vat * 100) / aOrderDetails.OrderAmount;
                productQuantity += aOrderDetails.OrderQuantity;
                aOrderDetails.OrderQuantity = productQuantity;
                aOrderDetails.OrderAmount = aOrderDetails.UnitPrice * productQuantity;
                aOrderDetails.PrintedQuantity = aOrderDetails.PrintedQuantity;
                aOrderDetails.VatTotal = (objProductName.VateRate * aOrderDetails.OrderAmount) / 100.0;
                aOrderDetails.Amount_with_vat = aOrderDetails.OrderAmount + aOrderDetails.VatTotal;

                COrderDetailsDAO aCOrderDetailsDao = new COrderDetailsDAO();
                aCOrderDetailsDao.OrderDetailsUpdate(aOrderDetails);

                //COrderDetailsDAO orderDetailsDao = new COrderDetailsDAO();
                //orderDetailsDao.UpdateOrderDetailsPricebyPLUProductTablePrice(productPLU, orderID, priceTakeType);


            }


            if (check.Count() == 0)
            {
                CResult oResult = objOrderManager.GetPluDataByProductPLU(productPLU, priceTakeType, orderID,
                                                                         productQuantity);

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    returnVal = int.Parse(oResult.Data.ToString());

                    //for vat includr option

                    String queryStr = SqlQueries.GetQuery(Query.LastPLUOrderDetails);
                    CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
                    String tempConnStr = oTempDal.ConnectionString;
                    // Create a new data adapter based on the specified query.
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);
                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);

                    int CategoryID = Convert.ToInt32(table.Rows[0]["product_id"].ToString());
                    Double amount = Convert.ToDouble(table.Rows[0]["amount"].ToString());

                    int catLavel = Convert.ToInt32(table.Rows[0]["cat_level"].ToString());
                    //vat in cat Three

                    double vatRate = 0;
                    bool vat_included = false;
                    double vatAmountRate = 0;
                    if (catLavel == 3)
                    {
                        DataRow[] temp2DataRowArray =
                            Program.initDataSet.Tables["Category3"].Select("cat3_id = " + CategoryID.ToString());

                        vatRate = 0;
                        vat_included = false;
                        vatAmountRate = 0;
                        try
                        {
                            vatRate = Convert.ToDouble(temp2DataRowArray[0]["vat_Rate"].ToString());
                            vat_included = Convert.ToBoolean(temp2DataRowArray[0]["vat_included"].ToString());

                            if (vat_included)
                            {
                                vatAmountRate = (amount * vatRate) / 100;

                                // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
                                // tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
                            }
                            else
                            {
                                vatAmountRate = 0.00;
                            }

                        }
                        catch (Exception ex)
                        {
                        }

                    }

                    if (catLavel == 4)
                    {
                        DataRow[] temp3DataRowArray =
                            Program.initDataSet.Tables["Category4"].Select("cat4_id = " + CategoryID);

                        vatRate = 0;
                        vat_included = false;
                        vatAmountRate = 0;
                        try
                        {
                            vatRate = Convert.ToDouble(temp3DataRowArray[0]["vat_Rate"].ToString());
                            vat_included = Convert.ToBoolean(temp3DataRowArray[0]["vat_included"].ToString());

                            if (vat_included)
                            {
                                vatAmountRate = (amount * vatRate) / 100;

                                // tableTypePrice = (Double.Parse(tableTypePrice) - vatAmountRate).ToString();
                                // tableTypePrice = Convert.ToDouble(tableTypePrice).ToString();
                            }
                            else
                            {
                                vatAmountRate = 0.00;
                            }

                        }
                        catch (Exception ex)
                        {
                        }

                    }



                    //string tableTypePrice = string.Empty;
                    //if (m_iType == m_cCommonConstants.TableType)
                    //{
                    //    tableTypePrice = temp2DataRowArray[0]["table_price"].ToString();
                    //}
                    //else if (m_iType == m_cCommonConstants.TakeAwayType)
                    //{
                    //    tableTypePrice = temp2DataRowArray[0]["tw_price"].ToString();
                    //}



                    COrderManager tempOrderManager = new COrderManager();
                    COrderDetails tempOrderDetails = new COrderDetails();



                    if (returnVal == 1)
                    {
                        //update Order_details table
                        //int tempRowIndex = tempResult;
                        //int qty = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[1].Value.ToString()) + m_iSavedOrderedQty;
                        //tempDataGridView.Rows[tempRowIndex].Cells[1].Value = qty;
                        //tempDataGridView.Rows[tempRowIndex].Cells[2].Value = ((double)(Double.Parse(tableTypePrice) * qty)).ToString("F02");
                        tempOrderDetails.OrderDetailsID = Convert.ToInt32(table.Rows[0]["order_detail_id"].ToString());
                        tempOrderDetails.OrderID = Convert.ToInt32(table.Rows[0]["order_id"].ToString());
                        tempOrderDetails.ProductID = Convert.ToInt32(table.Rows[0]["product_id"].ToString());
                        tempOrderDetails.CategoryLevel = Convert.ToInt32(table.Rows[0]["cat_level"].ToString());
                        tempOrderDetails.UnitPrice = 0.00;
                        tempOrderDetails.OrderQuantity = Convert.ToInt32(table.Rows[0]["quantity"].ToString());
                        tempOrderDetails.OrderAmount = Convert.ToDouble(table.Rows[0]["amount"].ToString());
                        tempOrderDetails.OrderFoodType = table.Rows[0]["food_type"].ToString();
                        // tempOrderDetails.OnlineItemSequenceNumber = Convert.ToInt64("0" + tempDataGridView.Rows[tempRowIndex].Cells[5].Value.ToString());
                        // tempOrderDetails.PrintedQuantity = int.Parse(tempDataGridView.Rows[tempRowIndex].Cells[7].Value.ToString());
                        if (vat_included)
                        {
                            tempOrderDetails.VatTotal = vatAmountRate;
                        }
                        else
                        {
                            tempOrderDetails.VatTotal = 0.00;
                        }

                        //if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                        //{
                        //    tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                        //}
                        //else
                        //{
                        //    tempOrderManager.UpdateOnlineOrderDetails(tempOrderDetails);
                        //}

                        try
                        {
                            tempOrderDetails.Amount_with_vat = tempOrderDetails.OrderAmount + tempOrderDetails.VatTotal;
                            tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                        }
                        catch
                        {
                        }
                    }


                    //tempOrderDetails.VatTotal = vatAmountRate;
                    //tempOrderDetails.OrderDetailsID =Convert.ToInt32(table.Rows[0]["order_detail_id"].ToString());
                    //try 
                    //{ 
                    //tempOrderManager.UpdateOrderDetails(tempOrderDetails);
                    //}
                    //catch { }


                }

                if (returnVal == 0)
                {
                    MessageBox.Show("Please enter valid plu product", RMSGlobal.MessageBoxTitle,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    COrderDetailsDAO orderDetailsDao = new COrderDetailsDAO();
                    orderDetailsDao.UpdateOrderDetailsPricebyPLUProductTablePrice(productPLU, orderID, priceTakeType);

                }
            }

            this.LoadOrderDetails();

            btnPLU_Click(sender, e);


        }





        private void btnOrderLog_Click(object sender, EventArgs e)
        {
            if (m_customerID > 0) //If takeaway type order then shows the customer information
            {
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                CustomerControl objCustomer = new CustomerControl(orderID, this, m_objOrderLogInfo);
                g_ItemSelectionFlowLayoutPanel.Controls.Add(objCustomer);
            }
            else //For table order
            {
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();
                TableInformationControl objTableInfo = new TableInformationControl(orderID, this, m_objOrderLogInfo);
                g_ItemSelectionFlowLayoutPanel.Controls.Add(objTableInfo);
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (m_customerID < 1) //If table type order is considered.
            {
                COrderManager tempOrderManager = new COrderManager();
                CKeyBoardForm tempKeyBoardForm = new CKeyBoardForm("Change Table Name", "Please Enter the Name of the Table");
                tempKeyBoardForm.ShowDialog();
                if (CKeyBoardForm.Content.Equals("Cancel")) //If cancelled then exit.
                {
                    return;
                }

                CCalculatorForm tempCalculatorForm = new CCalculatorForm("Guest Quantity Information", "Guest Quantity");
                tempCalculatorForm.ShowDialog();

                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(orderID).Data;
                if (!CKeyBoardForm.Content.Equals("") && !CKeyBoardForm.Content.Equals("Cancel"))
                {
                    tempOrderInfo.TableName = CKeyBoardForm.Content;
                }

                if (!CCalculatorForm.inputResult.Equals("") && !CCalculatorForm.inputResult.Equals("Cancel") && !(Int32.Parse(CCalculatorForm.inputResult) == 0))
                    tempOrderInfo.GuestCount = Convert.ToInt32(CCalculatorForm.inputResult);
                tempOrderManager.UpdateOrderInfo(tempOrderInfo);
            }
        }

        private void txtBoxSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchKeey = ((TextBox)sender).Text;

                DataRow[] tempDataRowArray = Program.initDataSet.Tables["Category3"].Select("cat3_name like '" + searchKeey + "%'");

                category3ButtonList.Clear();
                foreach (DataRow tempDataRow in tempDataRowArray)
                {
                    if (Int32.Parse(tempDataRow["status"].ToString()) == 0)
                    {
                        continue;
                    }

                    CCategoryButton tempCategoryButton = new CCategoryButton();
                    tempCategoryButton.CategoryID = int.Parse(tempDataRow["cat3_id"].ToString());
                    tempCategoryButton.CategoryOrder = int.Parse(tempDataRow["cat3_order"].ToString());
                    tempCategoryButton.CategoryLevel = 3;
                    tempCategoryButton.SellingQuantityorWeight = Convert.ToString(tempDataRow["selling_in"]);

                    tempCategoryButton.Text = tempDataRow["cat3_name"].ToString();


                    //set btn color

                    DataRow[] tempDataRowsFromCat2 = Program.initDataSet.Tables["Category2"].Select("cat2_id =" + tempDataRow["cat2_id"].ToString());

                    string clorcode = tempDataRowsFromCat2[0]["cat2_color"].ToString();
                    tempCategoryButton.BackColor = Color.FromArgb(Int32.Parse(clorcode.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(clorcode.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(clorcode.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));




                    // tempCategoryButton.BackColor = tempCategory2Button.BackColor;
                    tempCategoryButton.Width = 130;
                    tempCategoryButton.FlatAppearance.BorderColor = Color.Black;
                    tempCategoryButton.FlatStyle = FlatStyle.Popup;


                    tempCategoryButton.Click += new EventHandler(Category3Button_Click);
                    category3ButtonList.Add(tempCategoryButton);
                }
                m_iNavigationCategory3Point = 0;
                g_ItemSelectionFlowLayoutPanel.Controls.Clear();

                for (int iterator = 0; iterator < m_food_item_panel_capacity && iterator < category3ButtonList.Count; iterator++)
                {
                    g_ItemSelectionFlowLayoutPanel.Controls.Add(category3ButtonList[iterator]);
                }

                if (category3ButtonList.Count > m_food_item_panel_capacity)
                {
                    g_Category3NextButton.Enabled = true;
                }
                else
                {
                    g_Category3NextButton.Enabled = false;
                }

                if (m_iNavigationCategory3Point > 0)
                {
                    g_Category3PreviousButton.Enabled = true;
                }
                else
                {
                    g_Category3PreviousButton.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void txtBoxSearchItem_Click(object sender, EventArgs e)
        {
            if (txtBoxSearchItem.Text == "search item")
            {
                txtBoxSearchItem.Text = string.Empty;
                txtBoxSearchItem.ForeColor = Color.Black;
            }



            keyboardForm.TopMost = true;
            keyboardForm.onKeyBoardPressDelegate = new OnKeyBoardPressDelegate(this.changeSearchtextFieldWithText);
            keyboardForm.Show();
            keyboardForm.Location = new Point(50, 380);
            keyboardForm.Size = new Size(740, 320);


        }

        private void changeSearchtextFieldWithText(keyboard textbox)
        {
            textbox.ControlToInputText = txtBoxSearchItem;

        }

        private void btnSetOrderWaiter_Click(object sender, EventArgs e)
        {
            try
            {
                WaiterForm waiterForm = new WaiterForm();
                waiterForm.UserList = userList;
                waiterForm.ShowDialog();

                if (waiterForm.DialogResult == DialogResult.OK)
                {
                    COrderWaiterDao orderwaiterDao = new COrderWaiterDao();
                    COrderwaiter orderwaiter = new COrderwaiter();

                    orderwaiter = orderwaiterDao.GetOrderwaiterByOrderID(orderID);
                    if (orderwaiter != null && orderwaiter.ID > 0 && orderwaiter.WaiterID != waiterForm.UserInfoData.UserID)
                    {
                        orderwaiter.OrderID = orderID;
                        orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                        orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                        orderwaiterDao.UpdateOrderwaiter(orderwaiter);
                    }
                    else if (orderwaiter.ID==0)
                    {
                        orderwaiter.OrderID = orderID;
                        orderwaiter.WaiterID = waiterForm.UserInfoData.UserID;
                        orderwaiter.WaiterName = waiterForm.UserInfoData.UserName;
                        orderwaiterDao.InsertOrderwaiter(orderwaiter);
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void btnNextParent_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iParentNavigationPoint < (parentCategoryButtonList.Count / m_capacity))
                {
                    m_iParentNavigationPoint++;
                }
                foodMenuPanal.Controls.Clear();
                for (int capacityCounter = 0; capacityCounter < m_capacity; capacityCounter++)
                {
                    if (parentCategoryButtonList.Count > (m_capacity * m_iParentNavigationPoint + capacityCounter))
                    {
                        foodMenuPanal.Controls.Add(parentCategoryButtonList[(m_capacity * m_iParentNavigationPoint + capacityCounter)]);
                    }
                }

                if (m_iParentNavigationPoint < (parentCategoryButtonList.Count / m_capacity))
                {
                    if ((m_iParentNavigationPoint + 1) == (parentCategoryButtonList.Count / m_capacity) && (parentCategoryButtonList.Count % m_capacity) == 0)
                    {
                        btnNextParent.Enabled = false;
                    }
                    else
                    {
                        btnNextParent.Enabled = true;
                    }
                }
                else
                    btnNextParent.Enabled = false;

                if (m_iParentNavigationPoint > 0)
                    btnPrevParent.Enabled = true;
                else
                    btnPrevParent.Enabled = false;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void btnPrevParent_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_iParentNavigationPoint > 0)
                {
                    m_iParentNavigationPoint--;
                }
                foodMenuPanal.Controls.Clear();
                for (int i = 0; i < m_capacity; i++)
                {
                    if (parentCategoryButtonList.Count > (m_capacity * m_iParentNavigationPoint + i))
                    {
                        foodMenuPanal.Controls.Add(parentCategoryButtonList[(m_capacity * m_iParentNavigationPoint + i)]);
                    }
                }

                if (m_iParentNavigationPoint < (parentCategoryButtonList.Count / m_capacity))
                {
                    if ((m_iParentNavigationPoint + 1) == (parentCategoryButtonList.Count / m_capacity) && (parentCategoryButtonList.Count % m_capacity) == 0)
                    {
                        btnNextParent.Enabled = false;
                    }
                    else
                    {
                        btnNextParent.Enabled = true;
                    }
                }
                else
                    btnNextParent.Enabled = false;

                if (m_iParentNavigationPoint > 0)
                    btnPrevParent.Enabled = true;
                else
                    btnPrevParent.Enabled = false;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private bool CheckStockControl()
        {
            CCategory3DAO cCategory3Dao = new CCategory3DAO();

            COrderManager tempOrderManager = new COrderManager();
            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();

            CResult oResult = tempOrderManager.OrderDetailsByOrderID(orderID);

            if (oResult.IsSuccess && oResult.Data != null)
                tempOrderDetailsList = (List<COrderDetails>)oResult.Data;

            string stockMessage = "Stock is unavailable ";
            bool isStockAvailable = true;


            foreach (COrderDetails orderDetail in tempOrderDetailsList)
            {
                CCategory3 cCategory3 = cCategory3Dao.GetAllCategory3ByCategory3ID(Convert.ToInt32(orderDetail.ProductID));

                if ((orderDetail.OrderQuantity - orderDetail.KitchenQuantity) > cCategory3.MUnitsInStock && cCategory3.MNonStockable)
                {
                    //stockMessage += "\n   " + orderDetail.Product_Name + "  " + (orderDetail.OrderQuantity - cCategory3.MUnitsInStock);
                    stockMessage += "\n   " + cCategory3.Category3Name + ": Needed: " + (orderDetail.OrderQuantity - orderDetail.KitchenQuantity) + " But Have " + (cCategory3.MUnitsInStock);
                    isStockAvailable = false;
                }

            }


            if (!isStockAvailable)
            {
                CUserInfoDAO aUserInfoDao = new CUserInfoDAO();
                CUserInfo aUserInfo = new CUserInfo();
                aUserInfo = aUserInfoDao.GetUserInfoByUsername(RMSGlobal.LoginUserName);
                if (aUserInfo.Type == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do You Proceed", "Stock Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isStockAvailable = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }

            }


            if (!isStockAvailable || !CheckRawProduct(tempOrderDetailsList))
            {
                CMessageBox cMessageBox = new CMessageBox("Finished Product", stockMessage);
                cMessageBox.ShowDialog();
                //MessageBox.Show(stockMessage);
                return false;
            }
            else
            {
                foreach (COrderDetails orderDetails in tempOrderDetailsList)
                {
                    CCategory3 cCategory3 = cCategory3Dao.GetAllCategory3ByCategory3ID(Convert.ToInt32(orderDetails.ProductID));
                    if (!cCategory3.MNonStockable)
                    {
                        cCategory3Dao.UpdateStock(Convert.ToInt32(orderDetails.ProductID), orderDetails.OrderQuantity - orderDetails.KitchenQuantity);
                        COrderDetailsDAO cOrderDetailsDao = new COrderDetailsDAO();
                        cOrderDetailsDao.UpdateKitchenQuantity(orderDetails);
                    }
                }
            }

            //   parrentForm.scre

            return true;
        }

        #region CheckRawProduct
        private bool CheckRawProduct(List<COrderDetails> tempOrderDetailsList)
        {
            CCategory3DAO cCategory3Dao = new CCategory3DAO();
            FinishedRawProductListDAO finishedRawProductListDao = new FinishedRawProductListDAO();

            string stockMessage = "Stock is unavailable ";
            bool isStockAvailable = true;
            KitchenStockDAO aKitchenStockDao = new KitchenStockDAO();

            foreach (COrderDetails orderDetail in tempOrderDetailsList)
            {
                List<CFinishedRawProductList> finishedRawProductList = finishedRawProductListDao.GetFinishedRawProductListByProductID(Convert.ToInt32(orderDetail.ProductID));

                foreach (CFinishedRawProductList finishedRawProduct in finishedRawProductList)
                {

                    // CCategory3 cCategory3 = cCategory3Dao.GetAllCategory3ByCategory3ID(Convert.ToInt32(finishedRawProduct.RawProductID));
                    KitchenStock aKitchenStock = new KitchenStock();
                    //  KitchenStockDAO aKitchenStockDao=new KitchenStockDAO();
                    aKitchenStock = aKitchenStockDao.GetStockByItemidFrominventory_kitchen_stock((int)finishedRawProduct.RawProductID);

                    //List<CCategory3> aList = cCategory3Dao.GetAllCategory3();
                    //var temp = from acategory in aList where acategory.Category2ID == cCategory3.Category2ID select acategory;


                    if (finishedRawProduct.Qnty * (orderDetail.OrderQuantity - orderDetail.KitchenQuantity) > aKitchenStock.Stocks)
                    {
                        stockMessage += "\n   " + finishedRawProduct.RawProductName + ": Needed: " + finishedRawProduct.Qnty *
                            (orderDetail.OrderQuantity - orderDetail.KitchenQuantity) + "\n " + " But Have: " + (aKitchenStock.Stocks);
                        isStockAvailable = false;
                    }
                }

            }


            if(!isStockAvailable)
            {
                CUserInfoDAO aUserInfoDao=new CUserInfoDAO();
                CUserInfo aUserInfo=new CUserInfo();
                aUserInfo = aUserInfoDao.GetUserInfoByUsername(RMSGlobal.LoginUserName);
                if (aUserInfo.Type == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do You Proceed", "Stock Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        isStockAvailable = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }

            }




            if (!isStockAvailable)
            {
                CMessageBox cMessageBox = new CMessageBox("Raw Product", stockMessage);
                cMessageBox.ShowDialog();
                return false;
            }
            else
            {
                foreach (COrderDetails orderDetails in tempOrderDetailsList)
                {
                    List<CFinishedRawProductList> finishedRawProductList =
                        finishedRawProductListDao.GetFinishedRawProductListByProductID(
                            Convert.ToInt32(orderDetails.ProductID));


                    foreach (CFinishedRawProductList finishedRawProduct in finishedRawProductList)
                    {
                        aKitchenStockDao.UpdateStock(Convert.ToInt32(finishedRawProduct.RawProductID),
                                                  finishedRawProduct.Qnty * (orderDetails.OrderQuantity - orderDetails.KitchenQuantity));

                    }
                    COrderDetailsDAO cOrderDetailsDao = new COrderDetailsDAO();
                    cOrderDetailsDao.UpdateKitchenQuantity(orderDetails);
                }
            }

            return true;
        }
        #endregion

        private void foodMenuPanal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void g_Category2Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempOrderManager = new COrderManager();
                CResult oResult = tempOrderManager.OrderInfoByOrderID(orderID);
                COrderInfo tempOrderInfo = new COrderInfo();
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfo)oResult.Data;
                }
                List<COrderShow> tempOrderShowList = new List<COrderShow>();
                oResult = tempOrderManager.OrderListShowByStatus("Paid");
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderShowList = (List<COrderShow>)oResult.Data;
                }

                if (tempOrderInfo.OrderType.Equals("Table"))
                {
                    tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "Table");

                    CTakeAwayForm tempTakeAway = new CTakeAwayForm(orderID);
                    tempTakeAway.Show();
                    CFormManager.Forms.Push(this);
                    this.Hide();
                }
                else if (tempOrderInfo.OrderType.Equals("TakeAway"))
                {
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

                    bool found = false;
                    for (int counter = 0; counter < tempOrderShowList.Count; counter++)
                    {
                        if (int.Parse(tableNumber) == tempOrderShowList[counter].TableNumber && tempOrderShowList[counter].OrderType.Equals("Table"))
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

                    tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, "TakeAway");

                    tempOrderInfo.OrderType = "Table";
                    tempOrderInfo.Status = "Seated";
                    tempOrderInfo.TableNumber = int.Parse(tableNumber);
                    //tempOrderInfo.TableName = "Table " + tableNumber;
                    tempOrderInfo.GuestCount = int.Parse(tableGuest);

                    CTableInfo tempTableInfo = new CTableInfo();
                    tempTableInfo.TableNumber = tempOrderInfo.TableNumber;
                    tempTableInfo.TableType = "Table";
                    tempOrderManager.InsertTableInfo(tempTableInfo);
                    ////g_ConvertButton.Text = "Convert to Take Away";

                    tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delivaryfromkitchneButton_Click(object sender, EventArgs e)
        {
            string sr = "DelivaryFromKitchen";
            COrderInfoDAO aCOrderInfoDao=new COrderInfoDAO();
            string ss= aCOrderInfoDao.UpdateOrderInfoDAOForDelivary(sr,(Int32)orderID);
            MessageBox.Show(ss);
        }

        private void functionalButton1_Click_1(object sender, EventArgs e)
        {
            
            
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void g_FoodDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


      public void  UpdateServiceCharge()
        {
             Double MainFoodTotal = 0;//@Salim Only for Main Item with out additional service charge or discount
            Double tempTotal = 0.0;
            for (int rowIndex = 0; rowIndex < g_FoodDataGridView.Rows.Count; rowIndex++)
            {
                if (g_FoodDataGridView[3, rowIndex].Value != null && !g_FoodDataGridView[3, rowIndex].Value.ToString().Equals(""))
                {
                    tempTotal += Double.Parse(g_FoodDataGridView[3, rowIndex].Value.ToString());
                }
            }
            for (int rowIndex = 0; rowIndex < g_BeverageDataGridView.Rows.Count; rowIndex++)
            {
                if (g_BeverageDataGridView[3, rowIndex].Value != null && !g_BeverageDataGridView[3, rowIndex].Value.ToString().Equals(""))
                {
                    tempTotal += Double.Parse(g_BeverageDataGridView[3, rowIndex].Value.ToString());
                }
            }
            MainFoodTotal = tempTotal;
            ChargeAmountForm tempChargeForm = new ChargeAmountForm();//Change by Mithu
           // tempChargeForm.ShowDialog(); //Change by Mithu


            //ServiceChargeControl objSvcCtl = new ServiceChargeControl(this);//Change by Mithu
            //g_ItemSelectionFlowLayoutPanel.Controls.Clear();//Change by Mithu
            //g_ItemSelectionFlowLayoutPanel.Controls.Add(objSvcCtl);//Change by Mithu

            //if (ChargeAmountForm.m_serviceChargeType.Equals("Cancel"))//Change by Mithu
            //    return;

            m_chargeAmount = 0.0; //Change by Mithu
            m_chargeType = "Percent";//Change by Mithu

            Double chargeAmount = 0.000;
            Double servicechargeRate = 0.000;
            if (m_chargeType.Equals("Fixed"))//Change by Mithu
            {
                chargeAmount = m_chargeAmount;//Change by Mithu

                servicechargeRate =  m_chargeAmount * 100 / MainFoodTotal;//Change by Mithu

            }
            else if (m_chargeType.Equals("Percent"))//Change by Mithu
            {
              chargeAmount = tempTotal * m_chargeAmount / 100;//Change by Mithu

            //chargeAmount = MainFoodTotal * 10 / 100; // Change by Mithu
              chargeAmount = MainFoodTotal * m_chargeAmount / 100;

            servicechargeRate = chargeAmount;
            }//Change by Mithu
            COrderManager tempOrderManager = new COrderManager();
            ServiceCharge tempOrderCharge = new ServiceCharge();
            CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(orderID);
            if (cResult.IsSuccess && cResult.Data != null)
            {
                tempOrderCharge = (ServiceCharge)cResult.Data;

                //update
                tempOrderCharge.OrderID = orderID;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                tempOrderManager.UpdateOrderServiceCharge(tempOrderCharge);
            }

            else
            {
                //insert
                tempOrderCharge.OrderID = orderID;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                tempOrderManager.InsertOrderServiceCharge(tempOrderCharge);
            }
           

         
            serviceCharge = chargeAmount.ToString("F02"); //Service charge amount
            g_serviceCharge.Text = chargeAmount.ToString("F02");

            tempTotal = (tempTotal + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text));
            //Field for vat
          //  lblVat.Text = (MainFoodTotal * (vat / 100)).ToString("F02");

            //  g_AmountLabel.Text = (tempTotal + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text)).ToString(); //Deduct the discount amount

            // g_AmountLabel.Text = (tempTotal * (1 + (vat / 100))).ToString("F02");
            g_AmountLabel.Text = (MainFoodTotal + double.Parse(lblVat.Text) + double.Parse(g_serviceCharge.Text) - double.Parse(g_DiscountLabel.Text) -double.Parse(lblMembershipDiscountValue.Text)).ToString("F02");
           // this.ServiceChargeModification();
        }

      private void membershipfunctionalButton_Click(object sender, EventArgs e)
      {
          try
          {

              CMemberShipAddForm tempCustomerInfoForm = new CMemberShipAddForm("Add", null);

              tempCustomerInfoForm.ISSetMemberShipCard = true;
              tempCustomerInfoForm.btnFindCustomer.Visible = false;
              tempCustomerInfoForm.btnSearchByPhone.Visible = false;
              tempCustomerInfoForm.btnSelect.Visible = true;
              tempCustomerInfoForm.FinishButton.Visible = false;

              //tempCustomerInfoForm.Show();
              //CFormManager.Forms.Push(this);
              //this.Hide();              

             tempCustomerInfoForm.ShowDialog(this);

              if (tempCustomerInfoForm.DialogResult == DialogResult.OK)
              {
                  membership = tempCustomerInfoForm.MembershipData;

                  TotalAmountCalculation();
              }

          }
          catch (Exception exp)
          {
              Console.Write(exp.Message);
          }
      }

      private void complementoryButton_Click(object sender, EventArgs e)
      {
          CResult aCResult = new CResult();
          CUserInfoDAO aUserInfoDao = new CUserInfoDAO();
          CUserInfo aUserInfo = new CUserInfo();
          aUserInfo.UserID = RMSGlobal.m_iLoginUserID;
          aCResult = aUserInfoDao.GetUser(aUserInfo);
          aUserInfo = (CUserInfo)aCResult.Data;

          if (aUserInfo.Type != 0)
          {
              MessageBox.Show("You are not correct person to give Order Complementory Opportunity");
              return;
          }


          COrderInfoDAO aOrderInfoDao=new COrderInfoDAO();
          string result = aOrderInfoDao.UpdateOrderComplementory(orderID,true);
          LoadOrderDetails();
          MessageBox.Show(result);
      }

      private void itemComplementoryButton_Click(object sender, EventArgs e)
      {

          CResult aCResult = new CResult();
          CUserInfoDAO aUserInfoDao = new CUserInfoDAO();
          CUserInfo aUserInfo = new CUserInfo();
          aUserInfo.UserID = RMSGlobal.m_iLoginUserID;
          aCResult = aUserInfoDao.GetUser(aUserInfo);
          aUserInfo = (CUserInfo)aCResult.Data;

          if (aUserInfo.Type != 0)
          {
              MessageBox.Show("You are not correct person to give Item Complementory Opportunity");
              return;
          }



          COrderInfoDAO aOrderInfoDao=new COrderInfoDAO();
          foreach (DataGridViewRow row in g_FoodDataGridView.Rows)
          {

              if (Convert.ToBoolean(row.Cells["complementoryfood"].Value) == true)
              {
                  COrderDetails aCOrderDetails = new COrderDetails();

                  aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["Order_details_id"].Value);

                  string result = aOrderInfoDao.UpdateItemComplementory(aCOrderDetails.OrderDetailsID);

              }

          }

          foreach (DataGridViewRow row in g_BeverageDataGridView.Rows)
          {

              if (Convert.ToBoolean(row.Cells["complementorynonfood"].Value) == true)
              {
                  COrderDetails aCOrderDetails = new COrderDetails();
                  aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["dataGridViewTextBoxColumn5"].Value);
                  string result = aOrderInfoDao.UpdateItemComplementory(aCOrderDetails.OrderDetailsID);
 

              }

          }

          LoadOrderDetails();
      }

      private void vatComplementoryButton_Click(object sender, EventArgs e)
      {
          CResult aCResult = new CResult();
          CUserInfoDAO aUserInfoDao = new CUserInfoDAO();
          CUserInfo aUserInfo = new CUserInfo();
          aUserInfo.UserID = RMSGlobal.m_iLoginUserID;
          aCResult = aUserInfoDao.GetUser(aUserInfo);
          aUserInfo = (CUserInfo)aCResult.Data;

          if (aUserInfo.Type != 0)
          {
              MessageBox.Show("You are not correct person to give Order Vat Complementory Opportunity");
              return;
          }


          COrderInfoDAO aOrderInfoDao = new COrderInfoDAO();
          string result = aOrderInfoDao.UpdateOrderVatComplementory(orderID, true);
          LoadOrderDetails();
          MessageBox.Show(result);
      }

      private void functionalButton1_Click_2(object sender, EventArgs e)
      {
          CResult aCResult = new CResult();
          CUserInfoDAO aUserInfoDao = new CUserInfoDAO();
          CUserInfo aUserInfo = new CUserInfo();
          aUserInfo.UserID = RMSGlobal.m_iLoginUserID;
          aCResult = aUserInfoDao.GetUser(aUserInfo);
          aUserInfo = (CUserInfo)aCResult.Data;

          if (aUserInfo.Type != 0)
          {
              MessageBox.Show("You are not correct person to give Item Complementory Opportunity");
              return;
          }



          CDiscountForm tempDiscountForm = new CDiscountForm();
          tempDiscountForm.ShowDialog();

          if (CDiscountForm.discountType.Equals("Cancel"))
              return;

        double   discountAmount = Convert.ToDouble(CDiscountForm.discountAmount);
        string   discountType = CDiscountForm.discountType;



          COrderDetailsDAO aOrderInfoDao = new COrderDetailsDAO();
          foreach (DataGridViewRow row in g_FoodDataGridView.Rows)
          {

              if (Convert.ToBoolean(row.Cells["complementoryfood"].Value) == true)
              {
                  COrderDetails aCOrderDetails = new COrderDetails();

                  aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["Order_details_id"].Value);

                  aCOrderDetails = aOrderInfoDao.OrderDetailsGetByOrderDetailID(aCOrderDetails.OrderDetailsID);

                  double totalAmount = aCOrderDetails.UnitPrice*aCOrderDetails.OrderQuantity;
                  double discount=0;
                  if (discountType == "Fixed")
                  {
                      discount = discountAmount;
                  } else
                  {
                      discount = (totalAmount*discountAmount)/100.0;
                  }

                  aCOrderDetails.DiscountAmount = discount;

                  string result = aOrderInfoDao.UpdateItemWiseDiscountForItem(aCOrderDetails);

              }

          }

          foreach (DataGridViewRow row in g_BeverageDataGridView.Rows)
          {

              if (Convert.ToBoolean(row.Cells["complementorynonfood"].Value) == true)
              {
                  COrderDetails aCOrderDetails = new COrderDetails();
                  aCOrderDetails.OrderDetailsID = Convert.ToInt64(row.Cells["dataGridViewTextBoxColumn5"].Value);
                  aCOrderDetails = aOrderInfoDao.OrderDetailsGetByOrderDetailID(aCOrderDetails.OrderDetailsID);
                  double totalAmount = aCOrderDetails.UnitPrice * aCOrderDetails.OrderQuantity;
                  double discount = 0;
                  if (discountType == "Fixed")
                  {
                      discount = discountAmount;
                  }
                  else
                  {
                      discount = (totalAmount * discountAmount) / 100.0;
                  }

                  aCOrderDetails.DiscountAmount = discount;
                  string result = aOrderInfoDao.UpdateItemWiseDiscountForItem(aCOrderDetails);

              }

          }



          CResult oResult1 = aOrderInfoDao.OrderDetailsGetByOrderID(orderID);
         List<COrderDetails> aOrderDetailses = oResult1.Data as List<COrderDetails>;
          double totalItemDiscount = 0;
          if (aOrderDetailses != null)
          {
               totalItemDiscount = aOrderDetailses.Sum(a => a.DiscountAmount);
          }




          COrderManager tempOrderManager = new COrderManager();
          COrderDiscount tempOrderDiscount = new COrderDiscount();
          CResult oResult = tempOrderManager.OrderDiscountGetByOrderID(orderID);
          if (oResult.IsSuccess && oResult.Data != null)
          {

              tempOrderDiscount = (COrderDiscount)oResult.Data;



              tempOrderDiscount.TotalItemDiscount = totalItemDiscount;
              tempOrderManager.UpdateOrderDiscount(tempOrderDiscount);


          }
          else
          {
              //insert
              tempOrderDiscount.OrderID = orderID;
              tempOrderDiscount.TotalItemDiscount = totalItemDiscount;
              tempOrderManager.InsertOrderDiscount(tempOrderDiscount);
          }



          LoadOrderDetails();
      }


    }
}