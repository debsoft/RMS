using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RMS.Common;
using RMS.DataAccess;
using Managers.TableInfo;
using Microsoft.ReportingServices.ReportRendering;
using RMS.Common.ObjectModel;
using RMSUI;

namespace RMS.TakeAway
{
    public partial class CRecentOrderForm : BaseForm
    {
        public static Hashtable m_htPreviousOrders=new Hashtable();
        Int64 m_iCustomerID;

        public CRecentOrderForm()
        {
            InitializeComponent();
        }

        public CRecentOrderForm(Int64 inCustomerID,String inCustomerName,String inPhone,String inAddress)
        {
            InitializeComponent();
            CustomerNameLabel.Text = inCustomerName;
            CustomerPhoneLabel.Text = inPhone;
            CustomerAddressLabel.Text = inAddress;
            m_iCustomerID = inCustomerID;
            OrderDataGridView.Rows.Clear();
            FillRMSDataGridView();
            

            CCommonConstants oConstant= ConfigManager.GetConfig<CCommonConstants>();
            string sSql=String.Format(SqlQueries.GetQuery(Query.GetRecentOrderByCustomerID),inCustomerID);//Collecting the orders of the selected customer.
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSql, oConstant.DBConnection);
            DataSet oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet, "RecentOrder");

            DataRowCollection oOrderList = oDataSet.Tables["RecentOrder"].Rows;

            for (int orderIndex = 0; orderIndex < oOrderList.Count; orderIndex++)
            {
                DataRow oRow = oOrderList[orderIndex];
                DateTime orderTime=new DateTime(Int64.Parse(oRow["order_time"].ToString()));
                string[] dataGridRow={
                    oRow["serial_no"].ToString(),
                    orderTime.ToShortDateString(),
                    oRow["total_amount"].ToString(),
                    "Re-Order",
                    oRow["order_id"].ToString()
                    };
                OrderDataGridView.Rows.Add(dataGridRow);
                OrderDataGridView.Update();
                if (OrderDataGridView.RowCount > 3) //Only three records are shown
                {
                    return;
                }
            }
            if(OrderDataGridView.RowCount<10)
            {
                OrderDataGridView.RowCount = 10;
            }
        }

        private void ShowItemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                ItemDataGridView.Rows.Clear();
                Int64 tempOrderID = Int64.Parse(OrderDataGridView.CurrentRow.Cells[4].Value.ToString());

                COrderManager tempOrderManager = new COrderManager();
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                CResult oResult = tempOrderManager.OrderDetailsArchiveByOrderID(tempOrderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;
                }

                for (int itemIndex = 0; itemIndex < tempOrderDetailsList.Count; itemIndex++)
                {
                    Int64 tempProductID = tempOrderDetailsList[itemIndex].ProductID;
                    int tempCategoryLevel = tempOrderDetailsList[itemIndex].CategoryLevel;

                    string tempProductName = "";
                    if (tempCategoryLevel == 3)
                    {
                        DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempProductID);
                        tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                    }
                    else if (tempCategoryLevel == 4)
                    {
                        int tempCat3_id = int.Parse(Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0].GetParentRow(Program.initDataSet.Relations["category3_to_category4"])["cat3_id"].ToString());
                        tempProductName = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCat3_id)[0]["cat3_name"].ToString();
                        tempProductName += " " + Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempProductID)[0]["cat4_name"].ToString();
                    }
                    else if (tempCategoryLevel == 0)
                        tempProductName = tempOrderDetailsList[itemIndex].OrderRemarks;



                    //if remarks exists append it... otherwise append nothing...
                    string appendString = "";
                    if (tempCategoryLevel != 0)
                        appendString = (tempOrderDetailsList[itemIndex].OrderRemarks.Equals("")) ? ("") : (" (" + tempOrderDetailsList[itemIndex].OrderRemarks + ")");

                    string[] tempDataGridViewRow = { 
                    tempProductName+appendString, 
                    tempOrderDetailsList[itemIndex].OrderQuantity.ToString(),
                    ((double)tempOrderDetailsList[itemIndex].OrderAmount).ToString("F02"),
                    tempOrderDetailsList[itemIndex].ProductID.ToString(),
                    tempOrderDetailsList[itemIndex].CategoryLevel.ToString(),
                    Int64.MaxValue.ToString(),//max rank
                    tempOrderDetailsList[itemIndex].OrderDetailsID.ToString()
                    };


                    //not misc item... rank is specified
                    if (tempCategoryLevel != 0)
                        tempDataGridViewRow[5] = Program.initDataSet.Tables["Category" + tempCategoryLevel].Select("cat" + tempCategoryLevel + "_id = " + tempProductID)[0]["cat" + tempCategoryLevel + "_rank"].ToString();

                    ItemDataGridView.Rows.Add(tempDataGridViewRow);
                    ItemDataGridView.Sort(ItemDataGridView.Columns[5], ListSortDirection.Ascending);
                    ItemDataGridView.Update();
                }

                //get discount
                g_DiscountLabel.Text = "0.000";
                COrderDiscount tempOrderDiscount = new COrderDiscount();
                oResult = tempOrderManager.OrderDiscountGetByOrderID(tempOrderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDiscount = (COrderDiscount)oResult.Data;
                    g_DiscountLabel.Text = tempOrderDiscount.Discount.ToString("F02");
                }

                Double tempTotal = 0.0;
                for (int rowIndex = 0; rowIndex < ItemDataGridView.Rows.Count; rowIndex++)
                {
                    if (ItemDataGridView[2, rowIndex].Value != null && !ItemDataGridView[2, rowIndex].Value.ToString().Equals(""))
                    {
                        tempTotal += Double.Parse(ItemDataGridView[2, rowIndex].Value.ToString());
                    }
                }

                tempTotal = tempTotal - tempOrderDiscount.Discount;

                g_AmountLabel.Text = tempTotal.ToString("F02");
                FillRMSDataGridView();
            }
            catch (FormatException exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FillRMSDataGridView()
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

            int rowCount = ItemDataGridView.RowCount;

            if (rowCount < oConstants.TableOrderFoodGrid)
            {
                for (int rowCounter = rowCount; rowCounter < oConstants.TableOrderFoodGrid; rowCounter++)
                {
                    string[] str ={ "", "", "", "", "", "9999999999999999999", "" };
                    ItemDataGridView.Rows.Add(str);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(OrderDataGridView.Columns[e.ColumnIndex].Name.Equals("Reorder") && e.RowIndex>=0 && OrderDataGridView[0,e.RowIndex].Value!=null)
            {
                Int64 oldOrderID = 0;
                Int64.TryParse(OrderDataGridView["OrderID", e.RowIndex].Value.ToString(), out oldOrderID);
                COrderManager tempOrderManager = new COrderManager();
                COrderInfoArchive tempOrderInfo = new COrderInfoArchive();
                List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
                m_htPreviousOrders = new Hashtable();
                CResult oResult = tempOrderManager.OrderInfoArchiveByOrderID(oldOrderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderInfo = (COrderInfoArchive)oResult.Data;
                }

                oResult = tempOrderManager.OrderDetailsArchiveByOrderID(oldOrderID);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempOrderDetailsList = (List<COrderDetails>)oResult.Data;
                }
                m_htPreviousOrders.Add("orderinfo", tempOrderInfo);
                m_htPreviousOrders.Add("orderdetail", tempOrderDetailsList);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}