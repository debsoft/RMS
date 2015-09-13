using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BistroAdmin.UI;
using RMS.Common.Config;
using System.Data.SqlClient;
using RMS.DataAccess;
using RMS;
using RMSAdmin.Purchase;
using RMSAdmin.Reports;
using Managers.Payment;
using RMS.Common.ObjectModel;
using System.Collections;
using ns;

namespace RMSAdmin
{
    public partial class RMSAdminMdiForm : Form
    {
        public RMSAdminMdiForm()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit from the application? ",RMSGlobal.MessageBoxTitle,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnParentCategory_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            ParentDetailsCtl objParent = new ParentDetailsCtl(this);
            objParent.Parent = this;
            pnlContext.Controls.Add(objParent);
            objParent.Dock = DockStyle.Fill;
        }

        private void RMSAdminMdiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnFoodType_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            pnlContext.Controls.Clear();
            FoodTypeCtl objFoodType = new FoodTypeCtl(this);
            objFoodType.Parent = this;
            pnlContext.Controls.Add(objFoodType);
            objFoodType.Dock = DockStyle.Fill;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnFoodItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                FoodItemCtl objFoodItem = new FoodItemCtl(this);
                objFoodItem.Parent = this;
                pnlContext.Controls.Add(objFoodItem);
                objFoodItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnSelectionItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                SelectionItemCtl objSelectedItem = new SelectionItemCtl(this);
                objSelectedItem.Parent = this;
                pnlContext.Controls.Add(objSelectedItem);
                objSelectedItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnColors_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ButtonColorCtl objBtnColor = new ButtonColorCtl(this);
                objBtnColor.Parent = this;
                pnlContext.Controls.Add(objBtnColor);
                objBtnColor.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                UserDetailsCtl objUsers = new UserDetailsCtl(this);
                objUsers.Parent = this;
                pnlContext.Controls.Add(objUsers);
                objUsers.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnreceiptStyle_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ReceiptDetailsCtl objReceipt = new ReceiptDetailsCtl(this);
                objReceipt.Parent = this;
                pnlContext.Controls.Add(objReceipt);
                objReceipt.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void proMnuParent_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            ParentDetailsCtl objParent = new ParentDetailsCtl(this);
            objParent.Parent = this;
            pnlContext.Controls.Add(objParent);
            objParent.Dock = DockStyle.Fill;
        }

        private void proMnuFoodType_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            pnlContext.Controls.Clear();
            FoodTypeCtl objFoodType = new FoodTypeCtl(this);
            objFoodType.Parent = this;
            pnlContext.Controls.Add(objFoodType);
            objFoodType.Dock = DockStyle.Fill;
        }

        private void proMnuCategory_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                CategoryDetailsCtl objCatDetails = new CategoryDetailsCtl(this);
                objCatDetails.Parent = this;
                pnlContext.Controls.Add(objCatDetails);
                objCatDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void proMnuFoodItems_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                FoodItemCtl objFoodItem = new FoodItemCtl(this);
                objFoodItem.Parent = this;
                pnlContext.Controls.Add(objFoodItem);
                objFoodItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void proMnuSelectionItems_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                SelectionItemCtl objSelectedItem = new SelectionItemCtl(this);
                objSelectedItem.Parent = this;
                pnlContext.Controls.Add(objSelectedItem);
                objSelectedItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void mnuButtonColor_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuMainUsers_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuMainReceipt_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuMainSwitching_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPLU_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                PluListCtl objProductList = new PluListCtl(this);
                objProductList.Parent = this;
                pnlContext.Controls.Add(objProductList);
                objProductList.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        private void CollectParentCategory()
        {
            try
            {
                String sqlCommand = SqlQueries.GetQuery(Query.ViewParentCategory);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

                // Create a new data adapter based on the specified query.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable parentCategory = new DataTable();
                parentCategory.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(parentCategory);

                rptParentCategory objParentCategory = new rptParentCategory();
                objParentCategory.SetDataSource(parentCategory);
                string reportHeader = RMSAdminController.CollectHeader();
                string reportFooter = RMSAdminController.CollectFooter();
                objParentCategory.SetParameterValue(0, reportHeader);
                objParentCategory.SetParameterValue(1, reportFooter);

                dataAdapter.Dispose();

                

                RecportViewerCtl objRptViewer = new RecportViewerCtl(this);
                objRptViewer.cRptViewerAdmin.ReportSource = objParentCategory;


                pnlContext.Controls.Clear();

                objRptViewer.Parent = this;
                pnlContext.Controls.Add(objRptViewer);
                objRptViewer.Dock = DockStyle.Fill;


            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void rptMnuFoodType_Click(object sender, EventArgs e)
        {
            
        }

        private void CollectFoodType()
        {
            String sqlCommand = String.Empty;

            sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1);

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            String tempConnStr = oTempDal.ConnectionString;

            // Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);

            rptFoodType objFoodType = new rptFoodType();
            objFoodType.SetDataSource(table);
            string reportHeader = RMSAdminController.CollectHeader();
            string reportFooter = RMSAdminController.CollectFooter();
            objFoodType.SetParameterValue(0, reportHeader);
            objFoodType.SetParameterValue(1, reportFooter);


            dataAdapter.Dispose();

           

            RecportViewerCtl objRptViewer = new RecportViewerCtl(this);
            objRptViewer.cRptViewerAdmin.ReportSource = objFoodType;


            pnlContext.Controls.Clear();

            objRptViewer.Parent = this;
            pnlContext.Controls.Add(objRptViewer);
            objRptViewer.Dock = DockStyle.Fill;
        }

        private void usersTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                UserDetailsCtl objUsers = new UserDetailsCtl(this);
                objUsers.Parent = this;
                pnlContext.Controls.Add(objUsers);
                objUsers.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void parentCatTsButton_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            ParentDetailsCtl objParent = new ParentDetailsCtl(this);
            objParent.Parent = this;
            pnlContext.Controls.Add(objParent);
            objParent.Dock = DockStyle.Fill;
        }

        private void tsMnuViewToolBox_Click(object sender, EventArgs e)
        {
            if (rmsAdminToolStrip.Visible)
            {
                rmsAdminToolStrip.Visible = false;
                tsMnuViewToolBox.Checked = false;
            }
            else
            {
                rmsAdminToolStrip.Visible = true;
                rmsAdminToolStrip.Select();
                tsMnuViewToolBox.Checked = true;
            }
        }

        private void foodTypeTsButton_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            pnlContext.Controls.Clear();
            FoodTypeCtl objFoodType = new FoodTypeCtl(this);
            objFoodType.Parent = this;
            pnlContext.Controls.Add(objFoodType);
            objFoodType.Dock = DockStyle.Fill;
        }

        private void categoryTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                CategoryDetailsCtl objCatDetails = new CategoryDetailsCtl(this);
                objCatDetails.Parent = this;
                pnlContext.Controls.Add(objCatDetails);
                objCatDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void foodItemTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                FoodItemCtl objFoodItem = new FoodItemCtl(this);
                objFoodItem.ProductType = "Finished";
                objFoodItem.Parent = this;
                objFoodItem.btnAddFoodItem.Visible = true;
                objFoodItem.btnAddRawMaterial.Visible = false;
                
                pnlContext.Controls.Add(objFoodItem);
                objFoodItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                SelectionItemCtl objSelectedItem = new SelectionItemCtl(this);
                objSelectedItem.Parent = this;
                pnlContext.Controls.Add(objSelectedItem);
                objSelectedItem.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tsMnuButtonColors_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ButtonColorCtl objBtnColor = new ButtonColorCtl(this);
                objBtnColor.Parent = this;
                pnlContext.Controls.Add(objBtnColor);
                objBtnColor.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tsMnuReceiptStyle_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ReceiptDetailsCtl objReceipt = new ReceiptDetailsCtl(this);
                objReceipt.Parent = this;
                pnlContext.Controls.Add(objReceipt);
                objReceipt.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tsMnuItemManual_Click(object sender, EventArgs e)
        {
            Process fileOpening = new Process();
            fileOpening.StartInfo.FileName = "/Config/admin_help.chm";
            fileOpening.Start();
        }

        private void tsMnuItemAbout_Click(object sender, EventArgs e)
        {
            rmsAdminAboutBox objAbout = new rmsAdminAboutBox();
            objAbout.ShowDialog();
        }

        private void tsMnuUsers_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                UserDetailsCtl objUsers = new UserDetailsCtl(this);
                objUsers.Parent = this;
                pnlContext.Controls.Add(objUsers);
                objUsers.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void buttoncolorTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ButtonColorCtl objBtnColor = new ButtonColorCtl(this);
                objBtnColor.Parent = this;
                pnlContext.Controls.Add(objBtnColor);
                objBtnColor.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void receiptStyleTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                ReceiptDetailsCtl objReceipt = new ReceiptDetailsCtl(this);
                objReceipt.Parent = this;
                pnlContext.Controls.Add(objReceipt);
                objReceipt.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tssubmnuitemParent_Click(object sender, EventArgs e)
        {
            this.CollectParentCategory();
        }

        private void tssubmnuitemFoodType_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.CollectFoodType();
            this.Cursor = Cursors.Default;
        }

        private void tssubmnuLogoff_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void RMSAdminMdiForm_Load(object sender, EventArgs e)
        {
            tssubmnuLogoff.Text = "Log off " + RMSGlobal.LogInUserName;
            tsLblCurrentUser.Text ="Current User: "+ RMSGlobal.LogInUserName;
            tsLblLoginTime.Text = "Login Time: "+DateTime.Now.ToString("hh:m:ss tt");
        }

        private void userManualTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process fileOpening = new Process();
                fileOpening.StartInfo.FileName = "/Config/admin_help.chm";

                fileOpening.Start();
            }
            catch { }
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

        

        private void tsRptInventorySoldToday_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dsRecords = new DataSet();
                DateTime dtCurrent = DateTime.Now;

                DateTime dtStartofDay = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, 0, 0, 0);
                DateTime dtEndofDay = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, 23, 59, 59);
                CReportManager objReportMgnr = new CReportManager();
                CResult objResult = objReportMgnr.GetInventorySalesRecords(dtStartofDay.Ticks, dtEndofDay.Ticks);
                
                dsRecords = (DataSet)objResult.Data;

                DataTable dtDetails = GetInventroySalesReport(dsRecords);

                if (dtDetails.Rows.Count > 0)
                {
                    string reportHeader = RMSAdminController.CollectHeader();
                    string reportFooter = RMSAdminController.CollectFooter();
                    Int32 totalCovers = Convert.ToInt32("0" + dsRecords.Tables[0].Rows[0]["guest_count"].ToString());

                    rptCurrentdaySalesReport objCurrentSales = new rptCurrentdaySalesReport();
                    objCurrentSales.SetDataSource(dtDetails);
                    objCurrentSales.SetParameterValue(0, reportHeader);
                    objCurrentSales.SetParameterValue(1, reportFooter);
                    objCurrentSales.SetParameterValue(2, totalCovers.ToString());

                    RecportViewerCtl objRptViewer = new RecportViewerCtl(this);
                    objRptViewer.cRptViewerAdmin.ReportSource = objCurrentSales;


                    pnlContext.Controls.Clear();

                    objRptViewer.Parent = this;
                    pnlContext.Controls.Add(objRptViewer);
                    objRptViewer.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("There is no record.",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tsRptInventorybyInterval_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
            pnlContext.Controls.Clear();
            ProductSalesCtl objSalesProduct = new ProductSalesCtl(this);
            objSalesProduct.Parent = this;
            pnlContext.Controls.Add(objSalesProduct);
            objSalesProduct.Dock = DockStyle.Fill;
        }

        private void pluTsButton_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                PluListCtl objPLU = new PluListCtl(this);
                objPLU.Parent = this;
                pnlContext.Controls.Add(objPLU);
                objPLU.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void proMnuPLU_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                PluListCtl objPLU = new PluListCtl(this);
                objPLU.Parent = this;
                pnlContext.Controls.Add(objPLU);
                objPLU.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void tssubmnuitemCategory_Click(object sender, EventArgs e)
        {

        }

        private void RMSAdminMdiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void tsMenuItemClear_Click(object sender, EventArgs e)
        {
            pnlContext.Controls.Clear();
        }

        private void toolStripButtonRawMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                FoodItemCtl objFoodItem = new FoodItemCtl(this);

                objFoodItem.btnAddFoodItem.Visible = false;
                objFoodItem.btnAddRawMaterial.Visible = true;
                objFoodItem.btnAddRawMaterial.Location = new Point(681, 9);

                objFoodItem.ProductType = "RawMaterial";


                objFoodItem.Parent = this;

                pnlContext.Controls.Add(objFoodItem);
                objFoodItem.Dock = DockStyle.Fill;

            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        private void pnlContext_Paint(object sender, PaintEventArgs e)
        {

        }

        private void foodAndNoonfoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseStoreView aView=new PurchaseStoreView();
            aView.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier=new AddSupplier();
            addSupplier.ShowDialog();
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherStockView aOtherStockView=new OtherStockView();
            aOtherStockView.ShowDialog();
        }

        private void foodAndNoonFoodReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodAndNoonFoodTransaction aForm=new FoodAndNoonFoodTransaction();
            aForm.Show();
        }

        private void otherItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherTransactionView aView=new OtherTransactionView();
            aView.ShowDialog();
        }

        private void employeeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryForm aForm= new SalaryForm();
            aForm.ShowDialog();

        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProfitLossReport aReport=new ProfitLossReport();
            aReport.ShowDialog();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSalaryReport aEmployeeSalaryReport=new EmployeeSalaryReport();
            aEmployeeSalaryReport.ShowDialog();
        }




        private void supplierCreate_Click(object sender, EventArgs e)
        {
            //SupplierForm aForm=new SupplierForm();
            //aForm.Show();

            try
            {
                pnlContext.Controls.Clear();
                SupplierForm aRawMaterialsItemDetails = new SupplierForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }


        }

        private void addUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddUnit add=new AddUnit();
            //add.Show();

            try
            {
                pnlContext.Controls.Clear();
                AddUnit aRawMaterialsItemDetails = new AddUnit();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void categoryCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CategoryCreateForm aForm=new CategoryCreateForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                CategoryCreateForm aRawMaterialsItemDetails = new CategoryCreateForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }

        }

        private void itemCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ItemCreateForm aForm=new ItemCreateForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                ItemCreateForm aRawMaterialsItemDetails = new ItemCreateForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void purchaseCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InventoryPurchaseForm aForm=new InventoryPurchaseForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                InventoryPurchaseForm aRawMaterialsItemDetails = new InventoryPurchaseForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

       

        private void allTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TransactionForm aForm=new TransactionForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                TransactionForm aRawMaterialsItemDetails = new TransactionForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InventoryPurchaseReport aForm=new InventoryPurchaseReport();
            //aForm.Show();
            try
            {
                pnlContext.Controls.Clear();
                InventoryPurchaseReport aRawMaterialsItemDetails = new InventoryPurchaseReport();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InventoryTransactionReport aForm=new InventoryTransactionReport();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                InventoryTransactionReport aRawMaterialsItemDetails = new InventoryTransactionReport();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void inventoryStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InventoryStockReportForm aForm=new InventoryStockReportForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                InventoryStockReportForm aRawMaterialsItemDetails = new InventoryStockReportForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void inventoryKitchenStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InventoryKitchenStockReportForm aForm=new InventoryKitchenStockReportForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                InventoryKitchenStockReportForm aRawMaterialsItemDetails = new InventoryKitchenStockReportForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void paymentSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SupplierPayment aForm=new SupplierPayment();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                SupplierPayment aRawMaterialsItemDetails = new SupplierPayment();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void supplierInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SupplierInformationForm aForm=new SupplierInformationForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                SupplierInformationForm aRawMaterialsItemDetails = new SupplierInformationForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void supplierPaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SupplierPaymentReportForm aForm=new SupplierPaymentReportForm();
            //aForm.ShowDialog();
            try
            {
                pnlContext.Controls.Clear();
                SupplierPaymentReportForm aRawMaterialsItemDetails = new SupplierPaymentReportForm();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }

        private void itemDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContext.Controls.Clear();
                RawMaterialsItemDetails aRawMaterialsItemDetails = new RawMaterialsItemDetails();
                aRawMaterialsItemDetails.Parent = this;
                pnlContext.Controls.Add(aRawMaterialsItemDetails);
                aRawMaterialsItemDetails.Dock = DockStyle.Fill;
            }
            catch (Exception exp)
            {

            }
        }



    }
}

