using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.Payment;
using RMS.Common.ObjectModel;
using RMSAdmin.Reports;
using RMS;
using ns;
using System.Collections;

namespace RMSAdmin
{
    public partial class ProductSalesCtl : UserControl
    {
        private RMSAdminMdiForm m_parentForm = null;
        public ProductSalesCtl(RMSAdminMdiForm p_parent)
        {
            InitializeComponent();
            m_parentForm = p_parent;
        }


        private DataTable GetInventroySalesReport(DataSet p_dsInventoryRecords)
        {
            string cat1ID = String.Empty;
            string cat2ID = String.Empty;
            string cat3ID = String.Empty;
            Hashtable htOrderedItems = new Hashtable();
            SortedList slOrderedItems = null;

            DataTable dtInventorySalesReport = new DataTable();
            dtInventorySalesReport.Columns.Add("ProductName", typeof(string));
            dtInventorySalesReport.Columns.Add("FoodTypeName", typeof(string));
            dtInventorySalesReport.Columns.Add("FoodBeverageTypeName", typeof(string));
            dtInventorySalesReport.Columns.Add("Quantity", typeof(int));
            dtInventorySalesReport.Columns.Add("Amount", typeof(double));

            foreach (DataRow dtRow in p_dsInventoryRecords.Tables[0].Rows)
            {
                Int64 productID = Int64.Parse(dtRow["product_id"].ToString());
                Int32 productLevel = Int32.Parse(dtRow["cat_level"].ToString());

                string tempProductName = "";
                if (productLevel == 3)
                {
                    DataRow[] tempDataRowArr = Program.m_foodItemRecords.Select("cat3_id = " + productID);

                    if (tempDataRowArr.Length > 0)  //Added by Baruri .This was a bug previously when no row found.
                    {
                        tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                        cat2ID = tempDataRowArr[0]["cat2_id"].ToString();
                    }

                    cat1ID = Program.m_categoryRecords.Select("cat2_id = " + cat2ID)[0]["cat1_id"].ToString();
                    cat1ID = Program.m_foodTypeRecords.Select("cat1_id = " + cat1ID)[0]["cat1_name"].ToString();
                }

                else if (productLevel == 4)
                {
                    DataRow[] tempDataRowArr = Program.m_selectionItemRecords.Select("cat4_id = " + productID);
                    int tempCat3_id = 0;
                    if (tempDataRowArr.Length > 0)
                    {
                        tempCat3_id = Convert.ToInt32("0" + tempDataRowArr[0]["cat3_id"]);
                    }

                    tempProductName = Program.m_selectionItemRecords.Select("cat4_id = " + productID)[0]["cat4_name"].ToString();


                    tempDataRowArr = Program.m_foodItemRecords.Select("cat3_id = " + tempCat3_id);

                    if (tempDataRowArr.Length > 0)//If rows found
                    {
                        tempProductName += " " + tempDataRowArr[0]["cat3_name"].ToString();
                        cat2ID = tempDataRowArr[0]["cat2_id"].ToString();
                    }
                    cat1ID = Program.m_categoryRecords.Select("cat2_id = " + cat2ID)[0]["cat1_id"].ToString();
                    cat1ID = Program.m_foodTypeRecords.Select("cat1_id = " + cat1ID)[0]["cat1_name"].ToString();
                }

                InventorySalesReport objSalesReport = new InventorySalesReport();
                objSalesReport.Quantity = Convert.ToInt32("0" + dtRow["quantity"].ToString());
                objSalesReport.ProductName = tempProductName;
                objSalesReport.Amount = Convert.ToDouble("0" + dtRow["amount"].ToString());
                objSalesReport.FoodBeverageTypeName = Convert.ToString(dtRow["food_type"]);
                objSalesReport.FoodTypeName = cat1ID;


                htOrderedItems.Add(cat1ID + "-" + objSalesReport.ProductName, objSalesReport);// Category 1 wise
            }

            NumericComparer ncomp = new NumericComparer();
            slOrderedItems = new SortedList(htOrderedItems, ncomp);

            foreach (InventorySalesReport objSalesReport in slOrderedItems.Values)
            {
                dtInventorySalesReport.Rows.Add(new object[] { objSalesReport.ProductName, objSalesReport.FoodTypeName, objSalesReport.FoodBeverageTypeName, objSalesReport.Quantity, objSalesReport.Amount });
            }
            return dtInventorySalesReport;
        }


        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dsRecords = new DataSet();
                DateTime dtCurrent = DateTime.Now;

                DateTime dtStartofDay = new DateTime(dtPickerStart.Value.Year, dtPickerStart.Value.Month, dtPickerStart.Value.Day, 0, 0, 0);
                DateTime dtEndofDay = new DateTime(dtPickerEnd.Value.Year, dtPickerEnd.Value.Month, dtPickerEnd.Value.Day, 23, 59, 59);
                CReportManager objReportMgnr = new CReportManager();
                CResult objResult = objReportMgnr.GetInventorySalesRecords(dtStartofDay.Ticks, dtEndofDay.Ticks);
                dsRecords = (DataSet)objResult.Data;
              

                DataTable dtDetails = GetInventroySalesReport(dsRecords);

                if (dsRecords.Tables[0].Rows.Count > 0)
                {
                    Int32 totalCovers = Convert.ToInt32("0" + dsRecords.Tables[0].Rows[0]["guest_count"].ToString());
                    rptSalesInterval objSales = new rptSalesInterval();
                    objSales.SetDataSource(dtDetails);

                    objSales.SetParameterValue(0, dtPickerStart.Value.ToString("dd/MM/yyyy"));
                    objSales.SetParameterValue(1, dtPickerEnd.Value.ToString("dd/MM/yyyy"));
                    objSales.SetParameterValue(2, DateTime.Now.ToString("dd/MM/yyyy"));


                    string reportHeader = RMSAdminController.CollectHeader();
                    string reportFooter = RMSAdminController.CollectFooter();
                    objSales.SetParameterValue(3, reportHeader);
                    objSales.SetParameterValue(4, reportFooter);
                    objSales.SetParameterValue(5, totalCovers.ToString());

                    RecportViewerCtl objRptViewer = new RecportViewerCtl(m_parentForm);
                    objRptViewer.cRptViewerAdmin.ReportSource = objSales;

                    m_parentForm.pnlContext.Controls.Clear();

                    objRptViewer.Parent = this;
                    m_parentForm.pnlContext.Controls.Add(objRptViewer);
                    objRptViewer.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("There is no record.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Cursor = Cursors.Default;

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
