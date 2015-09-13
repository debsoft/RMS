//#define VATFIXED 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using ProductCommon.ObjectModel;
//using ProductDatabase.Queries;
//using ProductCommon.Config;
//using ProductConfigService;
//using ProductManagers.Category;

using RMS.DataAccess;
using Managers.User;
using RMS;
using RMS.Common.ObjectModel;
using RMSClient.DataAccess;

namespace RMS.StockManagement
{
    public partial class AddProductItemCtl : UserControl
    {
        private string m_sParentCategoryText = string.Empty;
        private string m_sFoodTypeText = string.Empty;
        private string m_sCategoryText = string.Empty;
        private int m_iCat3ID = 0;
        List<CCategory3> cCategory3sList = new List<CCategory3>();
        private bool addStockMode = true;

     //   private bool isAddRawProduct = false;
          private bool isModifyRawProduct = false;
          private int cnt = 0;

        private CFinishedRawProductList cFinishedProductList = null;

        private double currentStock=0;
        CCategory3 objFoodItemUpdate;

        public Category categoryData;

        public Category CategoryData
        {
            get { return categoryData; }
            set { categoryData = value; }
        }
        
        public AddProductItemCtl()
        {
            InitializeComponent();
            pnel_addStock.Visible = false;
            cmbboxVatIncluded.SelectedIndex = 0;
          
        }

        public AddProductItemCtl(int cat3_id)
        {
            m_iCat3ID = cat3_id;
            InitializeComponent();
            pnel_addStock.Visible = false;
       //     cmbboxVatIncluded.SelectedIndex = 0;
            //     cmbboxVatIncluded.SelectedIndex = 0;
            LoadRawProduct();// add by deb for inventory system
           // LoadRawProduct();

        }

        public AddProductItemCtl(int cat3_id, bool addStock)
        {
            m_iCat3ID = cat3_id;
            InitializeComponent();
            addStockMode = addStock;

            if (!addStockMode)
            {
                lblReconcyle_AddStock.Text = "Reconcile Stock";
            }


            ControlCollection ctrls = this.Controls;

            foreach (Control ctl in ctrls)
            {
                Label lbl = ctl as Label;

                if (ctl.Name == "pnel_addStock" || ctl.Name == "btnSave" || ctl.Name == "btnCancel" || lbl != null)
                {

                }
                else
                {
                    ctl.Enabled = false;
                }
            }

            cmbboxVatIncluded.SelectedIndex = 0;


            LoadDataGrid();

        }

        private void AddFoodItemCtl_Load(object sender, EventArgs e)
        {
            CCategoryAncestorDAO cCategoryAncestorDao = new CCategoryAncestorDAO();
            CResult oResult = cCategoryAncestorDao.GetCategoryAnchestors(m_iCat3ID, 3);
            CCategoryAncestor oCatAnc = (CCategoryAncestor)oResult.Data;
            LoadRawMaterialCategory(); // add by deb for inventory system
            this.FillParentCategory();
            cmbParent.SelectedValue = oCatAnc.ParentCategoryID;

            Int32 parentId = Convert.ToInt32(cmbParent.SelectedValue);
            CCategory1DAO aCategory1Dao = new CCategory1DAO();
            List<CCategory1> category1s = aCategory1Dao.GetCategory1IdByParentId(parentId);

            cmbCategory1.DisplayMember = "Category1Name";
            cmbCategory1.ValueMember = "Category1ID";
            cmbCategory1.DataSource = category1s;
            cmbCategory1.SelectedValue = oCatAnc.Category1ID;
            int cat1Id = Convert.ToInt32(cmbCategory1.SelectedValue);

            FillFoodType(cat1Id);
            cmbFoodType.SelectedValue = oCatAnc.Category2ID;



            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
            FillFoodCategory(foodTypeID);
            cmbCategory.SelectedValue = m_iCat3ID;







            //cmbCategory.SelectedValue = objFoodItemUpdate.Category3ID;

            this.FillAllUoMCmb();


            if (m_iCat3ID > 0)
            {
                //         this.showExistingData();
            }


            //LoadRawProduct();
        }


      

        public AddProductItemCtl(string inParentCategoryText, string inFoodTypeText, string inCategoryText)
        {
            InitializeComponent();

            m_sParentCategoryText = inParentCategoryText;
            m_sFoodTypeText = inFoodTypeText;
            m_sCategoryText = inCategoryText;
        }
        #region "Manupulation"

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            bool bTempFlag = false;

            if (cmbParent.SelectedValue == null)
            {
                oResult.Message = "Please Select Parent Category.";

                return oResult;
            }
            else if (cmbFoodType.SelectedValue == null)
            {
                oResult.Message = "Please Select Food Type.";

                return oResult;
            }

            else if (cmbCategory.SelectedValue == null)
            {
                oResult.Message = "Please select Category.";

                return oResult;
            }
            else
            {
            }

            if (txtProductName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = " Please enter item name.";

                return oResult;
            }

            //if (cmbSellingIn.SelectedText == "")
            //{
            //    oResult.Message = " Please enter the product selling type.";
            //    return oResult;
            //}

            //if (cmbStanUoM.SelectedText == "")
            //{
            //    oResult.Message = " Please enter the Standard UoM.";
            //    return oResult;
            //}

            if (rdoActive.Checked == false && rdoInactive.Checked == false)
            {
                oResult.Message = "Please select status.";

                return oResult;
            }

            if (!txtRetailPrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtRetailPrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = "Please enter table price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (!txtWholeSalePrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtWholeSalePrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = "Please enter takeaway price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (!txtLastPurchasePrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtLastPurchasePrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = "Please enter bar price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (txtInitialQuantity.Text.Trim().Equals(String.Empty) && (chkunstockable.Checked == false))
            {
                oResult.Message = "Please enter initial quantity status of the item.";
                return oResult;
            }
            /*
            if (cmbSellingIn.SelectedIndex<0)
            {
                oResult.Message = "Please select item selling in value.";
                cmbSellingIn.Focus();
                return oResult;
            }
            */
            oResult.IsSuccess = true;

            return oResult;
        }

        private void FillParentCategory()
        {
            try
            {

                String queryStr = SqlQueries.GetQuery(Query.ViewParentCategory);

                //  CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                // String tempConnStr = oTempDal.ConnectionString;

                // Create a new data adapter based on the specified query.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                cmbParent.DataSource = table;

                cmbRawParentCategory.DataSource = table;


                // cmbCategory.Text = m_sParentCategoryText;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + ". Error Occured. Please contact to your administrator.");
            }
        }

        private void FillFoodType(Int32 parentId)
        {
            if (cmbParent.SelectedIndex < 0)
            {
                return;

            }
            String sqlCommand = "";

            if (parentId == 0)
            {
                sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1);
            }
            else
            {
                // sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCat1ComboBox), parentId);
                //Query.ViewCategory2ByCat1ComboBox:
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCategory2ByCat1ComboBox1), parentId);
            }


            //  CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
            RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
            String tempConnStr = oConstants.DBConnection;
            // String tempConnStr = oTempDal.ConnectionString;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);

            cmbFoodType.DataSource = table;
            // cmbRawCategory1.DataSource = table;
            //  cmbFoodType.Text = m_sFoodTypeText;

            dataAdapter.Dispose();
        }

        private void FillFoodCategory(Int32 foodTypeID)
        {
            if (cmbFoodType.SelectedIndex < 0)
            {
                return;

            }
            else
            {
                if (cmbFoodType.SelectedValue != null)
                {

                    // String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory2ByCat1);
                    //String sqlCommand  = "SELECT a.cat2_id, a.cat2_name as Category2_Name FROM category2 a, category1 b, parent_category c where  a.cat1_id = b.cat1_id and b.parent_cat_id = c.parent_cat_id and a.cat1_id = {0} order by a.cat2_order asc";
                    String sqlCommand = "SELECT cat3_id, cat3_name as Category2_Name FROM category3  where  cat2_id = {0} ";

                    sqlCommand = String.Format(sqlCommand, foodTypeID);

                    // CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                    // String tempConnStr = oTempDal.ConnectionString;
                    RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                    String tempConnStr = oConstants.DBConnection;

                    // Create a new data adapter based on the specified query.
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    cmbCategory.DataSource = table;
                    //   cmbCategory.Text = m_sCategoryText;

                    DataTable table1 = new DataTable();
                    table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table1);

                    // cmbRawCategory2.DataSource = table1;

                    dataAdapter.Dispose();
                }
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {

            ProductItemCtl foodItemControl = new ProductItemCtl();
            Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];
            pnl.Controls.Clear();
            foodItemControl.isViewList = true;
            foodItemControl.CCategory3Data = categoryData;
            pnl.Controls.Add(foodItemControl);
            foodItemControl.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// Saving the food item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                CResult objResult = ValidateForm();

                if (objResult.IsSuccess)
                {
                    CCategory3 productItem = new CCategory3();
                    productItem = objFoodItemUpdate;
                    //  productItem.Category2ID = Int32.Parse(cmbCategory.SelectedValue.ToString());
                    //    productItem.Category3Name = txtProductName.Text.Trim();
                    //   productItem.Category3Description = txtDescription.Text.Trim();

                    //productItem.Category3TablePrice = objFoodItemUpdate.Category3TablePrice; 
                    //productItem.Category3TakeAwayPrice = objFoodItemUpdate.Category3TakeAwayPrice;
                    //productItem.Category3BarPrice = objFoodItemUpdate.Category3BarPrice;

                    /* start: price */


                    if (!txtRetailPrice.Text.Trim().Equals(String.Empty))
                    {
                        // productItem.MRetailPrice = Double.Parse(txtRetailPrice.Text.Trim());
                        productItem.Category3TablePrice = Double.Parse(txtRetailPrice.Text.Trim());
                    }

                    if (!txtWholeSalePrice.Text.Trim().Equals(String.Empty))
                    {
                        //productItem.MWholeSalePrice = Double.Parse(txtWholeSalePrice.Text.Trim());
                        productItem.Category3TakeAwayPrice = Double.Parse(txtWholeSalePrice.Text.Trim());
                    }

                    if (!txtLastPurchasePrice.Text.Trim().Equals(String.Empty))
                    {
                        // productItem.MLastPurchasePrice = Double.Parse(txtLastPurchasePrice.Text.Trim());
                        productItem.Category3BarPrice = Double.Parse(txtLastPurchasePrice.Text.Trim());
                    }

                    // is input price vat inluded 
                    //     if (chbVatIncluded.Checked)

                    if (cmbboxVatIncluded.SelectedIndex == 0)
                    {
                        // double vat = Program.vat / 100;

                        /*  productItem.Category3TablePrice = Convert.ToDouble( (productItem.Category3TablePrice/(1+vat)).ToString("F02"));
                          productItem.RetailPrice = Convert.ToDouble((productItem.RetailPrice / (1 + vat)).ToString("F02"));
                          productItem.Category3TakeAwayPrice = Convert.ToDouble((productItem.Category3TakeAwayPrice/(1+vat)).ToString("F02"));
                          productItem.WholeSalePrice =Convert.ToDouble(( productItem.WholeSalePrice / (1 + vat)).ToString("F02"));
                          productItem.Category3BarPrice =Convert.ToDouble(( productItem.Category3BarPrice / (1 + vat)).ToString("F02"));
                          productItem.LastPurchasePrice = Convert.ToDouble((productItem.LastPurchasePrice / (1 + vat)).ToString("F02"));
                        */


#if VATFIXED
                  //  int i = 0;

#else
                        //productItem.Category3TablePrice = (Double)Convert.ToDecimal((productItem.Category3TablePrice / (1 + vat)));
                        //productItem.MRetailPrice = (Double)Convert.ToDecimal((productItem.MRetailPrice / (1 + vat)));
                        //productItem.Category3TakeAwayPrice = (Double)Convert.ToDecimal((productItem.Category3TakeAwayPrice / (1 + vat)));
                        //productItem.MWholeSalePrice = (Double)Convert.ToDecimal((productItem.MWholeSalePrice / (1 + vat)));
                        //productItem.Category3BarPrice = (Double)Convert.ToDecimal((productItem.Category3BarPrice / (1 + vat)));
                        //productItem.MLastPurchasePrice = (Double)Convert.ToDecimal((productItem.MLastPurchasePrice / (1 + vat)));

#endif

                        //productItem.Category3TablePrice =  (Double) Convert.ToDecimal((productItem.Category3TablePrice / (1 + vat)));
                        //productItem.RetailPrice = (Double)Convert.ToDecimal((productItem.RetailPrice / (1 + vat)));
                        //productItem.Category3TakeAwayPrice = (Double)Convert.ToDecimal((productItem.Category3TakeAwayPrice / (1 + vat)));
                        //productItem.WholeSalePrice = (Double)Convert.ToDecimal((productItem.WholeSalePrice / (1 + vat)));
                        //productItem.Category3BarPrice = (Double)Convert.ToDecimal((productItem.Category3BarPrice / (1 + vat)));
                        //productItem.LastPurchasePrice = (Double)Convert.ToDecimal((productItem.LastPurchasePrice / (1 + vat)));

                    }

                    /* end: price */
                    // active or inactive


                    //if (rdoActive.Checked)
                    //{
                    //    productItem.Category3OrderStatus = 1;
                    //}
                    //else if (rdoInactive.Checked)
                    //{
                    //    productItem.Category3OrderStatus = 0;
                    //}


                    // stockable
                    if (chkunstockable.Checked)
                    {
                        productItem.MInitialQuantity = 0;
                        productItem.MUnlimitStatus = 1;
                    }
                    else
                    {
                        if (cmbSellingIn.SelectedItem.ToString() == "Per Piece" || cmbSellingIn.SelectedItem.ToString() == "")
                        {
                            productItem.MInitialQuantity = Convert.ToInt32("0" + txtInitialQuantity.Text);

                        }
                        else
                        {
                            productItem.MInitialQuantity = Convert.ToInt32("0" + txtInitialQuantity.Text);
                        }

                        productItem.MUnlimitStatus = 0;
                    }

                    //      Item selling : "Per Piece" - Whether the item sold in quantity or weight

                    productItem.ItemSellingIn = cmbSellingIn.SelectedItem.ToString();

                    productItem.MBarCode = txtBoxBarcode.Text;

                    productItem.MUnitsInStock = int.Parse(txtInitialQuantity.Text);

                    if (cmbSellingIn.SelectedItem.ToString() == "Per Piece" || cmbSellingIn.SelectedItem.ToString() == "")
                    {
                        productItem.MUnitsInStock = Convert.ToInt32("0" + txtInitialQuantity.Text);

                    }
                    else
                    {
                        productItem.MUnitsInStock = Convert.ToInt32("0" + txtInitialQuantity.Text);
                    }


                    //non stocablke
                    productItem.MNonStockable = chkunstockable.Checked;
                    productItem.MNonTaxableGood = chkNontaxable.Checked;
                    productItem.MReorderLevel = int.Parse(txtReorderLevel.Text);


                    //start: UoM
                    //if (!cmbStanUoM.SelectedValue.ToString().Equals(string.Empty))
                    //{
                    //    productItem.MStandardUoM = cmbStanUoM.SelectedValue.ToString();
                    //}

                    //if (!cmbSalesUoM.SelectedValue.ToString().Equals(string.Empty))
                    //{
                    //    productItem.MSalesUoM = cmbSalesUoM.SelectedValue.ToString();
                    //    productItem.MQtyPerSaleUint = int.Parse(txtBoxUnitPerSaleUnit.Text);
                    //}
                    //else
                    //{
                    //    productItem.MSalesUoM = cmbStanUoM.SelectedValue.ToString();
                    //    productItem.MQtyPerSaleUint = 1;
                    //}

                    //if (!cmbPurUoM.SelectedValue.ToString().Equals(string.Empty))
                    //{
                    //    productItem.MPurchaseUoM = cmbPurUoM.SelectedValue.ToString();
                    //    productItem.MQtyPerPurchaseUnit = int.Parse(txtBoxUnitPerPurchaseUnit.Text);
                    //}
                    //else
                    //{
                    //    productItem.MPurchaseUoM = cmbStanUoM.SelectedValue.ToString();
                    //    productItem.MQtyPerPurchaseUnit = 1;
                    //}



                    if (cmbboxVatIncluded.Visible)
                    {
                        productItem.MVatIncluded = !Convert.ToBoolean(cmbboxVatIncluded.SelectedIndex);
                    }
                    else
                    {
                        productItem.MVatIncluded = false;
                    }

                    if (rdbRaw.Checked)
                    {
                        productItem.MProductType = rdbRaw.Text;
                    }
                    else if (rdbFinished.Checked)
                    {
                        productItem.MProductType = rdbFinished.Text;
                    }

                    CCategory3DAO cCategory3Dao = new CCategory3DAO();
                    CResult oResult2 = new CResult();
                    if (m_iCat3ID > 0)
                    {
                        // update new category3
                        productItem.Category3ID = m_iCat3ID;
                        oResult2 = cCategory3Dao.Category3Update(productItem, 0);
                    }
                    else
                    {
                        // add new category3
                        oResult2 = cCategory3Dao.Category3Insert(productItem);
                    }
                    // end: add/update cat3


                    if (oResult2.IsSuccess)
                    {
                        lblSaveStatus.Text = " The product has been Updated successfully.";
                        lblSaveStatus.Visible = true;
                        currentStock = Convert.ToDouble(txtInitialQuantity.Text);
                    }
                    else
                    {
                        lblSaveStatus.Text = "The product can not be Updated. Please try again. ";
                        lblSaveStatus.Visible = true;
                    }
                }
                else
                {
                    lblSaveStatus.Text = objResult.Message;

                    lblSaveStatus.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cnt > 0)
            {
                Int32 parentId = Convert.ToInt32(cmbParent.SelectedValue);
                CCategory1DAO aCategory1Dao = new CCategory1DAO();
                List<CCategory1> category1s = aCategory1Dao.GetCategory1IdByParentId(parentId);
                cmbCategory1.DataSource = category1s;
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbFoodType.SelectedIndex = -1;
            cmbParent.SelectedIndex = -1;
            txtLastPurchasePrice.Clear();
            txtDescription.Clear();
            txtProductName.Clear();
            txtRetailPrice.Clear();
            txtWholeSalePrice.Clear();
            rdoActive.Checked = false;
            rdoInactive.Checked = false;
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cnt > 0)
            {
                Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
                FillFoodCategory(foodTypeID);
                //FillFoodCategory(0);
            }
        }

        private void chkUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            if (chkunstockable.Checked)
            {
                txtInitialQuantity.Enabled = false;
            }
            else
            {
                txtInitialQuantity.Enabled = true;
            }
        }


        /// <summary>
        /// return UoM datatable
        /// </summary>
        private void FillAllUoMCmb()
        {
            try
            {
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;

                // CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
                // String tempConnStr = oTempDal.ConnectionString;
                //String queryStr = SqlQueries.GetQuery(Query.GetAllUoM);
                String queryStr = SqlQueries.GetQuery(Query.GetAllUnit);

                // Create a new data adapter based on the specified query.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.                
                DataTable table = new DataTable();
                //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();

                DataRow dr = table.NewRow();
                dr[0] = -1;
                dr[1] = "";
                table.Rows.InsertAt(dr, 0);

                cmbStanUoM.DataSource = table;
                cmbStanUoM.DisplayMember = "name";
                cmbStanUoM.ValueMember = "name";

                cmbSalesUoM.DataSource = table.Copy();
                cmbSalesUoM.DisplayMember = "name";
                cmbSalesUoM.ValueMember = "name";

                cmbPurUoM.DataSource = table.Copy();
                cmbPurUoM.DisplayMember = "name";
                cmbPurUoM.ValueMember = "name";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + ". Error Occured. Please contact to your administrator.");
            }

        }

        private void cmbStanUoM_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStanUoMForSalesUoM.Text = cmbStanUoM.Text;
            lblStanUoMForPurchaseUoM.Text = cmbStanUoM.Text;
        }

        private void cmbSalesUoM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSalesUoM.Text.Trim().Equals(string.Empty))
            {
                panelconversionSales.Visible = true;
            }

            lblStanUoMForSalesUoM.Text = cmbStanUoM.Text;
            lblsalesUoM.Text = cmbSalesUoM.Text;
        }

        private void cmbPurUoM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbPurUoM.Text.Trim().Equals(string.Empty))
            {
                panelconversionPurchase.Visible = true;
            }

            lblStanUoMForPurchaseUoM.Text = cmbStanUoM.Text;
            lblPurchaseUoM.Text = cmbPurUoM.Text;
        }

        /// <summary>
        /// Show existing Data
        /// </summary>
        private void showExistingData()
        {
            CCategory3DAO cCategory3Dao = new CCategory3DAO();

            objFoodItemUpdate = new CCategory3();

            objFoodItemUpdate = cCategory3Dao.GetAllCategory3ByCategory3ID(m_iCat3ID);

            CCategoryAncestorDAO cCategoryAncestorDao = new CCategoryAncestorDAO();

            CResult oResult = cCategoryAncestorDao.GetCategoryAnchestors(m_iCat3ID, 3);
            CCategoryAncestor oCatAnc = (CCategoryAncestor)oResult.Data;

            //if (oResult.IsSuccess && oResult.Data != null)
            //{
            if (objFoodItemUpdate != null)
            {
                //objFoodItemUpdate = (CCategory3)oResult.Data;

                txtProductName.Text = objFoodItemUpdate.Category3Name;

                //txtBoxBarcode.Text = objFoodItemUpdate.MBarCode;

                txtInitialQuantity.Text = objFoodItemUpdate.MInitialQuantity.ToString();

                if (objFoodItemUpdate.MUnlimitStatus == 1)
                {
                    //txtInitialQuantity.Clear();
                    chkunstockable.Checked = true;
                }
                else
                {
                    chkunstockable.Checked = false;
                    //txtInitialQuantity.Text = objFoodItem.InitialItemQuantity.ToString();
                }

                txtReorderLevel.Text = objFoodItemUpdate.MReorderLevel.ToString();


                //  txtRetailPrice.Text = objFoodItemUpdate.MRetailPrice.ToString("F02");
                txtRetailPrice.Text = objFoodItemUpdate.Category3TablePrice.ToString("F02");


                txtDescription.Text = objFoodItemUpdate.Category3Description;

                txtInitialQuantity.Text = objFoodItemUpdate.MUnitsInStock.ToString();
                currentStock = objFoodItemUpdate.MUnitsInStock;


                chkNontaxable.Checked = objFoodItemUpdate.MNonTaxableGood;

                if (objFoodItemUpdate.MVatIncluded)
                {
#if VATFIXED
                    cmbboxVatIncluded.SelectedIndex = 0;

                    txtRetailPrice.Text = objFoodItemUpdate.RetailPrice.ToString("F02");
                    txtLastPurchasePrice.Text = objFoodItemUpdate.LastPurchasePrice.ToString("F02");
                    txtWholeSalePrice.Text = objFoodItemUpdate.WholeSalePrice.ToString("F02");
                    
#else

                    // chbVatIncluded.Checked = true;

                    //  double vat = 1 + Program.vat / 100;

                    //txtRetailPrice.Text = (objFoodItemUpdate.MRetailPrice * vat).ToString("F02");
                    //txtLastPurchasePrice.Text = (objFoodItemUpdate.MLastPurchasePrice * vat).ToString("F02");
                    //txtWholeSalePrice.Text = (objFoodItemUpdate.MWholeSalePrice * vat).ToString("F02");

                    //txtRetailPrice.Text = (objFoodItemUpdate.Category3TablePrice * vat).ToString("F02");
                    //txtLastPurchasePrice.Text = (objFoodItemUpdate.Category3TakeAwayPrice * vat).ToString("F02");
                    //txtWholeSalePrice.Text = (objFoodItemUpdate.Category3BarPrice * vat).ToString("F02");

                    txtRetailPrice.Text = objFoodItemUpdate.Category3TablePrice.ToString("F02");
                    txtLastPurchasePrice.Text = objFoodItemUpdate.Category3TakeAwayPrice.ToString("F02");
                    txtWholeSalePrice.Text = objFoodItemUpdate.Category3BarPrice.ToString("F02");

                    cmbboxVatIncluded.SelectedIndex = 0;

#endif
                }
                else
                {
                    // chbVatIncluded.Checked = false;                   

                    //txtRetailPrice.Text = objFoodItemUpdate.MRetailPrice.ToString("F02");
                    //txtLastPurchasePrice.Text = objFoodItemUpdate.MLastPurchasePrice.ToString("F02");
                    //txtWholeSalePrice.Text = objFoodItemUpdate.MWholeSalePrice.ToString("F02");
                    txtRetailPrice.Text = objFoodItemUpdate.Category3TablePrice.ToString("F02");
                    txtLastPurchasePrice.Text = objFoodItemUpdate.Category3TakeAwayPrice.ToString("F02");
                    txtWholeSalePrice.Text = objFoodItemUpdate.Category3BarPrice.ToString("F02");

                    cmbboxVatIncluded.SelectedIndex = 1;

                }


                if (objFoodItemUpdate.Category3OrderStatus > 0) rdoActive.Checked = true;
                else rdoInactive.Checked = true;

                //if (objFoodItem.ItemSellingIn == "Per Piece") cmbSellingIn.SelectedText = "Per Piece";
                //else if (objFoodItem.ItemSellingIn == "Per Weight") cmbSellingIn.SelectedText = "Per Weight";

                try
                {
                    cmbSellingIn.SelectedIndex = cmbSellingIn.FindString(objFoodItemUpdate.ItemSellingIn);
                    cmbStanUoM.SelectedIndex = cmbStanUoM.FindString(objFoodItemUpdate.MStandardUoM);
                    cmbSalesUoM.SelectedIndex = cmbSalesUoM.FindString(objFoodItemUpdate.MSalesUoM);
                    cmbPurUoM.SelectedIndex = cmbPurUoM.FindString(objFoodItemUpdate.MPurchaseUoM);

                    //cmbParent.SelectedValue = oCatAnc.ParentCategoryID;
                    //cmbFoodType.SelectedValue = oCatAnc.Category2ID;
                    //cmbCategory.SelectedValue = objFoodItemUpdate.Category3ID;
                }
                catch (Exception ex)
                {
                }
            }



            if (oResult.IsSuccess && oResult.Data != null)
            {
                int tmpCat3ID = oCatAnc.Category3ID;
                int tmpCat2ID = oCatAnc.Category2ID;
                int tmpCat1ID = oCatAnc.Category1ID;
                int tmpParentCatID = oCatAnc.ParentCategoryID;


                if (objFoodItemUpdate.Category3OrderStatus == 1)
                {
                    //m_activeStatus = true;
                    rdoActive.Checked = true;
                }
                else if (objFoodItemUpdate.Category3OrderStatus == 0)
                {
                    //rdoInActive.Checked = true;
                    //m_activeStatus = false;
                }

                //  cmbParent.SelectedValue = tmpParentCatID;
                // cmbFoodType.SelectedValue = tmpCat2ID;
                // cmbCategory.SelectedValue = tmpCat3ID;

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == 46)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (addStockMode)
            {
                lblTotalStock.Text = "Total Stock : " + (Convert.ToDouble("0" + textBox1.Text) + currentStock).ToString();
                txtInitialQuantity.Text = (Convert.ToDouble("0" + textBox1.Text) + currentStock).ToString();
            }
            else
            {
                lblTotalStock.Text = "Total Stock : " + (Convert.ToDouble("0" + textBox1.Text)).ToString();

                if (textBox1.Text != string.Empty)
                {
                    txtInitialQuantity.Text = (Convert.ToDouble("0" + textBox1.Text) + 0).ToString();
                }
                else
                {
                    txtInitialQuantity.Text = currentStock.ToString();
                }
            }

        }

        private void chkNontaxable_CheckedChanged(object sender, EventArgs e)
        {

            //   chbVatIncluded.Visible = !chkNontaxable.Checked;
            //  chbVatIncluded.Checked = !chkNontaxable.Checked;

            cmbboxVatIncluded.Visible = !chkNontaxable.Checked;
            lblVat.Visible = !chkNontaxable.Checked;
            cmbboxVatIncluded.SelectedIndex = Convert.ToInt16(chkNontaxable.Checked);
        }

        private void cmbboxVatIncluded_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetExcludedVat();
        }

        private void txtRetailPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetExcludedVat();
            }
        }

        private void txtWholeSalePrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetExcludedVat();
            }
        }

        private void txtLastPurchasePrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetExcludedVat();
            }
        }

        private void SetExcludedVat()
        {
            try
            {

                if (cmbboxVatIncluded.SelectedItem.ToString().Equals("Included"))
                {
                    if (objFoodItemUpdate != null)
                    {
                        double vat = Program.vat / 100;

                        lblVatIncludedPrice.Visible = true;

                        double retailPrice = Convert.ToDouble(txtRetailPrice.Text.ToString()) - vat;
                        double wholePrice = Convert.ToDouble(txtWholeSalePrice.Text.ToString()) - vat;
                        double purchasePrice = Convert.ToDouble(txtLastPurchasePrice.Text.ToString()) - vat;


                        lblVatIncludedPrice.Text = "Excluding Vat " +
                                                    "\n" + "      Retail Price : " + retailPrice.ToString("F2") +
                                                   "\n" + "     Whole Price : " + wholePrice.ToString("F2") +
                                                   "\n" + "Purchase Price : " + purchasePrice.ToString("F2");
                    }
                }
                else
                {
                    lblVatIncludedPrice.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddFinishedtoRawProductList_Click(object sender, EventArgs e)
        {
            AddFinishedtoRawProductList();
        }

        #region AddFinishedtoRawProductList
        private void AddFinishedtoRawProductList()
        {
            try
            {
                //  FinishedRawProductListDAO finishedRawProductDAO = new FinishedRawProductListDAO();

                FinishedRawProductListDAO finishedRawProductDAO = new FinishedRawProductListDAO();
                //     CFinishedRawProductList cfinishedproduct = new CFinishedRawProductList();

                if (isModifyRawProduct && txtRawQnty.Tag != null)
                {
                    cFinishedProductList = txtRawQnty.Tag as CFinishedRawProductList;
                }
                else
                {
                    cFinishedProductList = new CFinishedRawProductList();
                }
                InventoryItem aInventoryItem = new InventoryItem();
                aInventoryItem = (InventoryItem)cmbProductName.SelectedItem;

                // cFinishedProductList.FinishedProductID = m_iCat3ID;
                // cFinishedProductList.RawProductID = cCategory3sList[cmbProductName.SelectedIndex].Category3ID;
                // cFinishedProductList.RawProductName = cCategory3sList[cmbProductName.SelectedIndex].Category3Name;
                cFinishedProductList.FinishedProductID = m_iCat3ID;
                cFinishedProductList.RawProductID = aInventoryItem.ItemId;
                cFinishedProductList.RawProductName = aInventoryItem.ItemName;

                //try { cFinishedProductList.Qnty = Convert.ToInt32(txtRawQnty.Text); }
                //catch (Exception e)
                //{ 
                //}
                try { cFinishedProductList.Qnty = Convert.ToDouble(txtRawQnty.Text); }
                catch (Exception e)
                {
                }

                cFinishedProductList.Remarks = "";


                if (isModifyRawProduct)
                {
                    finishedRawProductDAO.FinishedRawProductListUpdate(cFinishedProductList);
                }
                else
                {
                    try
                    {
                        finishedRawProductDAO.FinishedRawProductListInsert(cFinishedProductList);
                    }
                    catch { }
                }

                RefreshFinishedRawProduct();

                LoadDataGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region RefreshFinishedRawProduct
        private void RefreshFinishedRawProduct()
        {
            txtRawQnty.Text = "0";
            txtRawQnty.Tag = null;

            btnAddFinishedtoRawProductList.Text = "Create";
            isModifyRawProduct = false;
        }
        #endregion

        #region Load Data Grid
        private void LoadDataGrid()
        {
            try
            {

                // dgvRawProductList.Rows.Clear();
                // dgvRawProductList.Refresh();


                //if (this.dgvRawProductList.DataSource != null)
                //{
                //    this.dgvRawProductList.DataSource = null;
                //}
                //else
                //{
                //    this.dgvRawProductList.Rows.Clear();
                //}

                FinishedRawProductListDAO finishedRawProductListDao = new FinishedRawProductListDAO();

                List<CFinishedRawProductList> finishedRawProductList = new List<CFinishedRawProductList>();

                finishedRawProductList = finishedRawProductListDao.GetFinishedRawProductListByProductID(m_iCat3ID);

                var data = (from c in finishedRawProductList
                            select new { RawProductID = c.RawProductID, RawProductName = c.RawProductName, Qnty = c.Qnty, obj = c }).ToList();
                dgvRawProductList.DataSource = data;


                txtRawProductQnty.Text = finishedRawProductList.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cFinishedProductList != null)
                {
                    FinishedRawProductListDAO finishedRawProductListDao = new FinishedRawProductListDAO();

                    finishedRawProductListDao.FinishedRawProductListDelete(cFinishedProductList);
                }

                cFinishedProductList = null;

                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRawCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadRawProduct();
            LoadRawMaterialItem(); // add by deb for New inventory
        }

        private void LoadRawMaterialItem()
        {
            if (cmbRawCategory2.SelectedIndex >= 0)
            {
                InventoryCategory aCategory = new InventoryCategory();
                aCategory = (InventoryCategory)cmbRawCategory2.SelectedItem;
                InventoryItemDAO aInventoryItemDao = new InventoryItemDAO();
                List<InventoryItem> aInventoryItems = new List<InventoryItem>();
                aInventoryItems = aInventoryItemDao.GetItemByCategory(aCategory.CategoryId);
                cmbProductName.DisplayMember = "ItemName";
                cmbProductName.ValueMember = "ItemId";
                cmbProductName.DataSource = aInventoryItems;
            }
        }

        private void LoadRawMaterialCategory()
        {
            InventoryCategoryDAO aCategoryDao = new InventoryCategoryDAO();
            List<InventoryCategory> aInventoryCategories = new List<InventoryCategory>();
            aInventoryCategories = aCategoryDao.GetAllCategory();
            cmbRawCategory2.DisplayMember = "CategoryName";
            cmbRawCategory2.ValueMember = "CategoryId";
            cmbRawCategory2.DataSource = aInventoryCategories;
        }


        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

          

            if (Convert.ToInt32("0"+cmbCategory.SelectedValue) > 0)
            {
                if (cnt > 0)
                {
                    m_iCat3ID = Convert.ToInt32(cmbCategory.SelectedValue);
                    this.showExistingData();
                    LoadDataGrid();
                }
                else
                {
                    this.showExistingData();
                    LoadDataGrid();
                    cnt++;
                }
            }

            }
            catch (Exception)
            {

            }

        }

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {
            grpFinishedProductRaw.Enabled = !rdbRaw.Checked;
        }

        private void rdbFinished_CheckedChanged(object sender, EventArgs e)
        {
            grpFinishedProductRaw.Enabled = rdbFinished.Checked;
        }

        private void cmbRawCategory2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //  LoadRawProduct();
        }


        #region LoadRawProduct
        private void LoadRawProduct()
        {

            try
            {
                cCategory3sList = new List<CCategory3>();

                int cat2ID = Convert.ToInt32(cmbRawCategory2.SelectedValue);

                cmbProductName.Items.Clear();

                CCategory3DAO cCategory3Dao = new CCategory3DAO();

                cCategory3sList = cCategory3Dao.GetCategory3ByCategory2ID(cat2ID);


                if (cCategory3sList != null && cCategory3sList.Count > 0)
                {
                    foreach (CCategory3 cCategory3 in cCategory3sList)
                    {
                        cmbProductName.Items.Add(cCategory3.Category3Name);
                    }
                }

                if (cmbProductName.Items.Count > 0)
                {
                    cmbProductName.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        private void dgvRawProductList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                cFinishedProductList = (CFinishedRawProductList)dgvRawProductList.Rows[e.RowIndex].Cells["obj"].Value;

                FillDataInGrid(cFinishedProductList);
            }

        }


        #region Fill Data In Grid
        private void FillDataInGrid(CFinishedRawProductList cFinishedProductList)
        {
            cmbProductName.Text = cFinishedProductList.RawProductName;
            txtRawQnty.Text = cFinishedProductList.Qnty.ToString();
            txtRawQnty.Tag = cFinishedProductList;

            btnAddFinishedtoRawProductList.Text = "Update";

            isModifyRawProduct = true;
        }
        #endregion


        private void dgvRawProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

            ProductItemCtl foodItemControl = new ProductItemCtl();
            Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];
            pnl.Controls.Clear();
            foodItemControl.isViewList = true;
            foodItemControl.CCategory3Data = categoryData;
            pnl.Controls.Add(foodItemControl);
            foodItemControl.Dock = DockStyle.Fill;
        }

        private void cmbRawParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.SelectedIndex >= 0)
            {
                unitLabel.Visible = true;
                InventoryItem aInventoryItem = new InventoryItem();
                aInventoryItem = (InventoryItem)cmbProductName.SelectedItem;
                unitLabel.Text = aInventoryItem.UnitName;
            }
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cnt > 0)
            {
                int cat1Id = Convert.ToInt32(cmbCategory1.SelectedValue);
                FillFoodType(cat1Id);
            }
        }


    }
}
