using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using RMS.Common;
using RMS.DataAccess;
using RMSClient.DataAccess;
using RMSUI;


namespace RMS.SystemManagement
{
    public partial class CVoidTableForm : Form
    {
        public CVoidTableForm()
        {
            InitializeComponent();            
        }        

        private void CVoidTableForm_Load(object sender, EventArgs e)
        {
           PopulateVoidTableDataGridView();
           VoidTableDataGridView.CellClick += new DataGridViewCellEventHandler(VoidTableDataGridView_CellClick);
        }

        public void PopulateVoidTableDataGridView()
        {
            try
            {
                COrderManager tempVoidTableManager = new COrderManager();
                List<CTransferOrderShow> tempOrderShowList = new List<CTransferOrderShow>();
                tempOrderShowList = (List<CTransferOrderShow>)tempVoidTableManager.AvailableTableForVoid().Data;

                if (tempOrderShowList != null)
                {
                    CTransferOrderShow[] tempOrderShowArray = tempOrderShowList.ToArray();
                    VoidTableDataGridView.RowCount = tempOrderShowArray.Length;
                    VoidTableDataGridView.AllowUserToResizeRows = false;
                    VoidTableDataGridView.Rows.Clear();

                    for (int rowCounter = 0; rowCounter < tempOrderShowArray.Length; rowCounter++)
                    {
                        int sl = rowCounter + 1;
                        String[] tempString ={ sl.ToString(), tempOrderShowArray[rowCounter].OrderType, tempOrderShowArray[rowCounter].TableNumber.ToString(), tempOrderShowArray[rowCounter].CustomerName, "Void", tempOrderShowArray[rowCounter].OrderID.ToString() };
                        VoidTableDataGridView.Rows.Add(tempString);
                    }
                }
                if (VoidTableDataGridView.RowCount < 16) VoidTableDataGridView.RowCount = 16;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        
        public void VoidTableDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VoidTableDataGridView.Columns[e.ColumnIndex].Name == "ActionButtonColumn" && e.RowIndex >= 0 && VoidTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value != null)
                {
                    DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to void this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tempDialogResult.Equals(DialogResult.No)) return;
                    //ItemInfo c = new ItemInfo();
                    //c.ShowDialog();
                    //c.Close();
                    //DialogResult tempDialogResult1 = MessageBox.Show("Ok Done", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //if (tempDialogResult1.Equals(DialogResult.No)) return;
                    else
                    {
                        String tempOldOrderID = VoidTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value.ToString();
                        int tempOldTableNumber = int.Parse(VoidTableDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value.ToString());
                        String tempOldTableType = VoidTableDataGridView.Rows[e.RowIndex].Cells["TableTypeColumn"].Value.ToString();

                        // add by mithu
                        OrderVoid aOrderVoid=new OrderVoid();
                        aOrderVoid.OrderId = Convert.ToInt32(VoidTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value);

                        COrderDetailsDAO aDao = new COrderDetailsDAO();
                        List<COrderDetails> aList = new List<COrderDetails>();
                        CResult aResult = new CResult();
                        aResult = aDao.OrderDetailsGetByOrderID(aOrderVoid.OrderId);
                        aList = (List<COrderDetails>)aResult.Data;


                        aOrderVoid.TableNumber = tempOldTableNumber;
                        aOrderVoid.RemoverId = RMS.RMSGlobal.m_iLoginUserID;
                        aOrderVoid.VoidDate = DateTime.Now;
                        COrderDetailsDAO  aCOrderDetailsDAO=new COrderDetailsDAO();
                        aOrderVoid.OrderAmount = aCOrderDetailsDAO.GetOrderAmount(aOrderVoid.OrderId);
                        COrderInfo aInfo=new COrderInfo();
                        COrderInfoDAO aCOrderInfoDao=new COrderInfoDAO();
                        aInfo = aCOrderInfoDao.GetOrderInfoByOrderID(aOrderVoid.OrderId);
                        aOrderVoid.OrderDate = aInfo.OrderTime;
                        aOrderVoid.Creator_Id = aInfo.UserID;
                        ReasonForm aReasonForm=new ReasonForm();
                        aReasonForm.ShowDialog();
                        aOrderVoid.Reason = aReasonForm.reason;

                        OrderVoidDAO aOrderVoidDao=new OrderVoidDAO();
                        aOrderVoidDao.InsertOrderForVoid(aOrderVoid);


                        DataSet tempStockDataSet = new DataSet();
                        tempStockDataSet.ReadXml("Config/StockSetting.xml");
                        bool isAllowedToOrder = Convert.ToBoolean(tempStockDataSet.Tables[0].Rows[0]["AllowedtoOrder"].ToString());
                        if (!isAllowedToOrder)
                        {
                            UpdateRawMaterial(aList);
                        }



                        COrderManager tempVoidTableManager = new COrderManager();
                        CResult tempResult = tempVoidTableManager.UpdateForVoidTable(tempOldOrderID, tempOldTableNumber, tempOldTableType, false);
                        if (tempResult.IsSuccess)
                        {
                            this.PopulateVoidTableDataGridView();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void UpdateRawMaterial(List<COrderDetails> details)
        {
            foreach (COrderDetails objDetails in details)
            {

                //Add for raw materials update
                if (objDetails.KitchenQuantity > 0)
                {
                    double quantity = objDetails.KitchenQuantity;
                    FinishedRawProductListDAO aDao = new FinishedRawProductListDAO();
                    List<CFinishedRawProductList> aList =
                        aDao.GetFinishedRawProductListByProductID(objDetails.ProductID);
                    foreach (CFinishedRawProductList list in aList)
                    {
                        aDao.FinishedRawProductUpdate(list, quantity);

                    }
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
           // Form tempForm = CFormManager.Forms.Pop();
           // tempForm.Show();
           // this.Close();
        }

        private void VoidTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}