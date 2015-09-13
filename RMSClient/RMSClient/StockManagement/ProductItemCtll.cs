using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using ProductCommon;
//using ProductDatabase.Queries;
//using ProductCommon.Config;
//using ProductConfigService;
//using ProductCommon.Cinstants;
//using ProductCommon.ObjectModel;
//using ProductManagers.Category;
using RMS.Common.ObjectModel;
using RMSUI;

using System.IO;
using RMS.DataAccess;
using System.Drawing.Printing;
using RMS.Common;

namespace RMS.StockManagement
{
    public partial class ProductItemCtl : UserControl
    {
        private Form m_parentForm = null;
        private int m_selectedIndex = -1;
        private bool m_bGridFlag = true; // true if all category in grid

        DataTable productsTable;
        
        DataGridViewRow templaterow;
        
        //@hafiz Add variable 
         SqlDataReader dataReader ;
        public bool isViewList = false;
        public Category cCategory3Data;

        public Category CCategory3Data
        {
            get { return CCategory3Data; }
            set { cCategory3Data = value; }
        }

        public ProductItemCtl()
        {
            InitializeComponent();
            //m_parentForm = objParent;
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1.Document = this.printDocument1;
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.OnBeginPrint);
            this.printDocument1.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            cmb_price_level.SelectedIndex = 0;
            cmb_stock_level.SelectedIndex = 0;
            templaterow = new DataGridViewRow();
           
        }

        #region "Manupulation Area"
        private void FillParentCategory()
        {
            try
            {
              //  String queryStr = "";
                String queryStr = SqlQueries.GetQuery(Query.ViewParentCategory);

              //  CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;

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
                //table.Rows.Add(new object[] { "0", "All", "", "" });
                cmbParent.DataSource = table;
                //cmbParent.Text = "All";
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+". Error Occured. Please contact to your administrator.");
            }
        }

        private void FillCategory1ByID(int parentCategoryID)
        {
            if (cmbParent.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                if (cmbParent.SelectedValue != null)
                {
                    //int iTempInt = Int32.Parse(cmbParentCategory.SelectedValue.ToString());

                    String sqlCommand = String.Empty;

                    if (cmbParent.SelectedValue.ToString() == "0")
                    {
                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1);
                    }
                    else
                    {
                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1ByParentCat);
                    }

                    sqlCommand = String.Format(sqlCommand, parentCategoryID);

                    RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                 //   CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

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
                    //table.Rows.Add(new object[]{"0","All","",0,"",""});
                    cmbFoodType.DataSource = table;

                  

                    dataAdapter.Dispose();
                }
            }
        }


        private void FillFoodItem(Int32 categoryID, int searchType)
        {
            productsTable = new DataTable();

            try
            {
                if (cmbCategory.SelectedIndex < 0)
                {
                    return;
                }
                else
                {
                    String sqlCommand = "";
                    
                    //search Type Normal
                    if (searchType == 1)
                    {
                        //sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2Grid);
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCategory3ByCat2Grid), categoryID);

                        if (categoryID == 0)
                        {
                            sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2GridAll);
                        }
                    }
                    else if(searchType ==2)
                    {
                      //  search Type Out of Reorder Level  

                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2Grid);

                        if (categoryID == 0)
                        {
                            sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2AndOutofReorderGridAll);
                        }
                        
                    }
                    else if(searchType == 3)
                    {
                        //search Type Out of Stock 

                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2AndOutofStockGrid);

                        if (categoryID == 0)
                        {
                            sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2AndOutofStockGridAll);
                        }
                    }


                  // sqlCommand = String.Format(sqlCommand, categoryID);
                    RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                    String tempConnStr = oConstants.DBConnection;


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    // DataTable table = new DataTable();
                    productsTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(productsTable);

                    // dataReader = commandBuilder.DataAdapter


                    dgvFoodItem.DataSource = productsTable;


                    //dgvFoodItem.DataSource = productsTable;

                    dataAdapter.Dispose();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FillCategory(Int32 foodTypeID)
        {
            try
            {
                if (cmbFoodType.SelectedIndex < 0)
                {
                    return;
                }


                String queryStr = SqlQueries.GetQuery(Query.ViewCategory2ByCat1ComboBox);

                queryStr = String.Format(queryStr, foodTypeID);

                // CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);

                //cmbCategory.DisplayMember = "cat2_name";

                //cmbCategory.ValueMember = "cat2_id";

                //  cmbCategory.DataSource = table;

                dataAdapter.Dispose();



                cmbCategory.DisplayMember = "name";
                cmbCategory.ValueMember = "id";

                cmbCategory.Items.Clear();
                foreach (DataRow row in table.Rows)
                {
                    cmbCategory.Items.Add(new Category(row["cat2_name"].ToString(), Convert.ToInt32(row["cat2_id"])));
                }
                cmbCategory.Items.Insert(0, new Category("All", 0));
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // @Salim quirey for outof stock
        private void FillOutOfStockItem()
        {
            productsTable = new DataTable();

            try
            {
                if (cmbCategory.SelectedIndex < 0)
                {
                    return;
                }
                else
                {
                    String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2Grid);

                    //if (categoryID == 0)
                    //{
                    //    sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2GridAll);
                    //}

                    //sqlCommand = String.Format(sqlCommand, categoryID);

                    RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                    String tempConnStr = oConstants.DBConnection;


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);



                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    // DataTable table = new DataTable();
                    productsTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(productsTable);

                    // dataReader = commandBuilder.DataAdapter


                    dgvFoodItem.DataSource = productsTable;


                    //dgvFoodItem.DataSource = productsTable;

                    dataAdapter.Dispose();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        #endregion


        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentCategoryID = Convert.ToInt32(cmbParent.SelectedValue);
            FillCategory1ByID(parentCategoryID);
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
                FillCategory(foodTypeID);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category ctg = (Category)cmbCategory.SelectedItem;
           // Int32 categoryID=Convert.ToInt32(cmbCategory.SelectedValue);
            FillFoodItem(ctg.id, 1);
        }

        private void FoodItemCtl_Load(object sender, EventArgs e)
        {
                FillParentCategory();

                if (isViewList)
                {
                    cmbCategory.Text = cCategory3Data.name;
                   // FillFoodItem(cCategory3Data.id, 1);
                }
        }

        private void btnAddParentCategory_Click(object sender, EventArgs e)
        {
            try
            {
              

                AddProductItemCtl objAddFoodItem = new AddProductItemCtl();
                objAddFoodItem.Parent = this.ParentForm;
            //    UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];

                string s = pnl.Name;

             //   objAddFoodItem.Margin = 5;
                objAddFoodItem.Dock = DockStyle.Fill;
                pnl.Controls.Clear();
                pnl.Controls.Add(objAddFoodItem);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {

                    //if (m_selectedIndex >= 0 && dgvFoodItem.Rows.Count > m_selectedIndex)
                    //{
                    //    int iTempInt = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[0].Value.ToString());

                    //    int iTempInt3 = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[2].Value.ToString());


                    //    CCategory3 oCat = new CCategory3();

                    //    oCat.Category3ID = iTempInt;

                    //    oCat.Category3Order = iTempInt3;


                    //    if ((m_selectedIndex + 1) > 0 && dgvFoodItem.Rows.Count > (m_selectedIndex + 1))
                    //    {
                    //        int iTempInt2 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex + 1)].Cells[0].Value.ToString());

                    //        int iTempInt4 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex + 1)].Cells[2].Value.ToString());

                    //        int iTempIndex = m_selectedIndex + 1;
                    //        CCategory3 oCat2 = new CCategory3();

                    //        oCat2.Category3ID = iTempInt2;

                    //        oCat2.Category3Order = iTempInt4;

                    //        if (cmbCategory.SelectedValue != null)
                    //        {

                    //            int iTempInt10 = Int32.Parse(cmbCategory.SelectedValue.ToString());

                    //            oCat2.Category2ID = iTempInt10;

                    //            oCat.Category2ID = iTempInt10;
                    //        }

                    //        CCategoryManager oCatManager = new CCategoryManager();

                    //        CResult oResult = oCatManager.UpdateCategory3Order(oCat, oCat2, false);

                    //        if (oResult.IsSuccess)
                    //        {

                    //            if (m_bGridFlag)
                    //            {
                    //                Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    //                FillFoodItem(categoryID);

                    //                dgvFoodItem.Rows[0].Selected = false;

                    //                dgvFoodItem.Rows[iTempIndex].Selected = true;

                    //                m_selectedIndex = iTempIndex;

                    //                if (m_selectedIndex > 12)
                    //                {
                    //                    dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                    //                }
                    //            }
                    //            else
                    //            {

                    //                Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    //                FillFoodItem(categoryID);

                    //                dgvFoodItem.Rows[0].Selected = false;

                    //                dgvFoodItem.Rows[iTempIndex].Selected = true;

                    //                m_selectedIndex = iTempIndex;

                    //                if (m_selectedIndex > 12)
                    //                {
                    //                    dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                    //                }

                    //            }

                    //        }


                    //    }
                    //}
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", 
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                //    if (m_selectedIndex > 0 && dgvFoodItem.Rows.Count > m_selectedIndex)
                //    {
                //        int iTempInt = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[0].Value.ToString());

                //        int iTempInt3 = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[2].Value.ToString());

                //        CCategory3 oCat = new CCategory3();

                //        oCat.Category3ID = iTempInt;

                //        oCat.Category3Order = iTempInt3;

                //        if ((m_selectedIndex - 1) >= 0 && dgvFoodItem.Rows.Count > (m_selectedIndex - 1))
                //        {
                //            int iTempInt2 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex - 1)].Cells[0].Value.ToString());

                //            int iTempInt4 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex - 1)].Cells[2].Value.ToString());

                //            int iTempIndex = m_selectedIndex - 1;

                //            CCategory3 oCat2 = new CCategory3();

                //            oCat2.Category3ID = iTempInt2;

                //            oCat2.Category3Order = iTempInt4;

                //            if (cmbCategory.SelectedValue != null)
                //            {

                //                int iTempInt10 = Int32.Parse(cmbCategory.SelectedValue.ToString());

                //                oCat2.Category2ID = iTempInt10;

                //                oCat.Category2ID = iTempInt10;

                //            }

                //            CCategoryManager oCatManager = new CCategoryManager();

                //            CResult oResult = oCatManager.UpdateCategory3Order(oCat, oCat2, true);

                //            if (oResult.IsSuccess)
                //            {

                //                if (m_bGridFlag)
                //                {
                //                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                //                    FillFoodItem(categoryID);

                //                    dgvFoodItem.Rows[0].Selected = false;

                //                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                //                    m_selectedIndex = iTempIndex;

                //                    if (m_selectedIndex > 12)
                //                    {
                //                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                //                    }
                //                }
                //                else
                //                {

                //                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                //                    FillFoodItem(categoryID);

                //                    dgvFoodItem.Rows[0].Selected = false;

                //                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                //                    m_selectedIndex = iTempIndex;

                //                    if (m_selectedIndex > 12)
                //                    {
                //                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                //                    }

                //                }

                //            }
                //    }
                //}
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFoodItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            
            try
            {
                if (e.ColumnIndex == 11)
                {
                    Int32 itemID = Convert.ToInt32("0" + dgvFoodItem.Rows[e.RowIndex].Cells[0].Value);
                    AddProductItemCtl objUpdate = new AddProductItemCtl(itemID, true);
                    Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];
                    try { objUpdate.categoryData = (Category)cmbCategory.SelectedItem; }
                    catch (Exception)
                    {
                    }
                    BaseForm fmr = ParentForm as BaseForm;
                    fmr.ScreenTitle = "";
                    pnl.Controls.Clear();                   
                    pnl.Controls.Add(objUpdate);

                }
                if (e.ColumnIndex == 12)
                {
                    Int32 itemID = Convert.ToInt32("0" + dgvFoodItem.Rows[e.RowIndex].Cells[0].Value);
                    AddProductItemCtl objUpdate = new AddProductItemCtl(itemID, false);
                    try { objUpdate.categoryData = (Category)cmbCategory.SelectedItem; }
                    catch (Exception)
                    {
                    }
                    Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];
                 
                    try
                    {
                        BaseForm fmr = ParentForm as BaseForm;
                        fmr.ScreenTitle = "";
                    }
                    catch (Exception) { }
                    
                       pnl.Controls.Clear();
                    pnl.Controls.Clear();
                   
                    pnl.Controls.Add(objUpdate);

                }
                
                if (e.ColumnIndex == 13)
                {
                    Int32 itemID = Convert.ToInt32("0" + dgvFoodItem.Rows[e.RowIndex].Cells[0].Value);
                    AddProductItemCtl objUpdate = new AddProductItemCtl(itemID);
                   try{ objUpdate.categoryData = (Category) cmbCategory.SelectedItem;}
                    catch(Exception)
                    {
                    }
                    Panel pnl = (Panel)this.ParentForm.Controls["panelUCHolder"];


                    try
                    {
                        BaseForm fmr = ParentForm as BaseForm;
                        fmr.ScreenTitle = "";
                    }
                    catch (Exception) { }

                    pnl.Controls.Clear();
                    pnl.Controls.Clear();
                   
                    pnl.Controls.Add(objUpdate);
                }
                else if (e.ColumnIndex == 14)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected category?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int itemID = 0;

                        bool bTempBool = Int32.TryParse(dgvFoodItem.Rows[e.RowIndex].Cells[0].Value.ToString(), out itemID);

                        //if (bTempBool)
                        //{
                        //    CCategory3 oCat = new CCategory3();

                        //    oCat.Category3ID = itemID;
                        //    CCategoryManager oManager = new CCategoryManager();

                        //    CResult oResult = oManager.DeleteCat3(oCat);

                        //    if (oResult.IsSuccess)
                        //    {
                        //        dgvFoodItem.Rows.RemoveAt(e.RowIndex);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception exp)
            {
               MessageBox.Show(exp.Message);
               return;
            }
        }

        private void dgvFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                m_selectedIndex = e.RowIndex;
            }
        }

        private void FillProductsWithAdvancedQuery()
        {
             
        }

        private void cmb_stock_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable td = new DataTable();
            txt_stock_level.Enabled = cmb_stock_level.SelectedIndex > 2;
            txt_stock_level_2.Enabled = cmb_stock_level.SelectedIndex == 5;

            if (cmb_stock_level.SelectedIndex == 0 && productsTable!=null)
            {

                IEnumerable<DataRow> query =
                from order in productsTable.AsEnumerable()
                select order;
                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }
            }
            if (cmb_stock_level.SelectedIndex == 1)
            {

                   IEnumerable<DataRow> query =
                   from order in productsTable.AsEnumerable()
                   where order.Field<Double>("ReorderLevel") >= order.Field<Double>("UnitsInStock")
                   orderby order.Field<Double>("UnitsInStock") ascending
                   select order;

                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }


            }
            else if (cmb_stock_level.SelectedIndex == 2)
            {
                IEnumerable<DataRow> query =
                from order in productsTable.AsEnumerable()
                where order.Field<Double>("UnitsInStock") <= 0
                select order;

                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }

            }
            lbl_no_row_found.Visible = !(td.Rows.Count > 0);
            dgvFoodItem.Visible = (td.Rows.Count > 0);

            
        }

        private void cmb_price_level_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            txt_price_level.Enabled = cmb_price_level.SelectedIndex > 0;
            txt_price_level_2.Enabled = cmb_price_level.SelectedIndex == 3;


            if (cmb_price_level.SelectedIndex == 0 && productsTable!=null)
            {
                IEnumerable<DataRow> query =
                   from order in productsTable.AsEnumerable()
                   select order;

                if (query.Count() > 0)
                {
                    DataTable td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }
               
            }
           
        }

        private void txt_item_name_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                IEnumerable<DataRow> query =
                                    from order in productsTable.AsEnumerable()
                                    where order.Field<String>("BarCode")==txt_barcode.Text.Trim()
                                    select order;


                if (query.Count()>0)
                {
                    DataTable td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }

                else
                {
                    MessageBox.Show("No product found.");

                }

            }
        }

        private void txt_price_level_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_price_level_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' ||  e.KeyChar == 46 )
            {
                e.Handled = false;
            }
            else if(e.KeyChar == 13)
            {
                e.Handled = true;
                HandlePriceFilter(txt_price_level.Text, txt_price_level_2.Text);
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HandleStockFilter(string str1, string str2)
        {

            DataTable td = new DataTable();
   
            double val1 = Convert.ToDouble("0" + str1);
            double val2 = Convert.ToDouble("0" + str2);
           
            IEnumerable<DataRow> query =
            from order in productsTable.AsEnumerable()
            select order;


            
           if (cmb_stock_level.SelectedIndex == 3)
            {

                query =
                from order in productsTable.AsEnumerable()
                where order.Field<Double>("UnitsInStock") <= val1
                orderby order.Field<Double>("UnitsInStock") descending
                select order;


                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;

                }

            }

           else if (cmb_stock_level.SelectedIndex == 4)
            {
                try
                {

                    query =
                    from order in productsTable.AsEnumerable()
                    where order.Field<Double>("UnitsInStock") >= val1
                    orderby order.Field<Double>("UnitsInStock") ascending
                    select order;


                    if (query.Count() > 0)
                    {
                        td = query.CopyToDataTable<DataRow>();
                        dgvFoodItem.DataSource = td;

                    }
                }
                catch (Exception) { }

            }
           else if (cmb_stock_level.SelectedIndex == 5)
            {
                query =
                               from order in productsTable.AsEnumerable()
                               where (order.Field<Double>("UnitsInStock") >= val1
                                   && order.Field<Double>("UnitsInStock") <= val2)
                               orderby order.Field<Double>("UnitsInStock") ascending
                               select order;


                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;

                }

            }
           else if (cmb_stock_level.SelectedIndex == 6)
            {

                query =
                from order in productsTable.AsEnumerable()
                where order.Field<Double>("UnitsInStock") == val1
                select order;


                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;

                }

            }

            lbl_no_row_found.Visible = !(query.Count() > 0);
            dgvFoodItem.Visible = (query.Count() > 0);

        }
        private void HandlePriceFilter(string str1, string str2)
        {
            
            DataTable td =new DataTable();
            td.Locale = System.Globalization.CultureInfo.InvariantCulture;
            double val1 = Convert.ToDouble("0" + str1);
            double val2 = Convert.ToDouble("0" + str2);
            IEnumerable<DataRow> query=
             from order in productsTable.AsEnumerable()
             select order;
              

            if (cmb_price_level.SelectedIndex == 1)
            {

                query =
                   from order in productsTable.AsEnumerable()
                   where order.Field<Double>("RetailPrice") <= val1
                   orderby order.Field<Double>("RetailPrice") descending
                   select order;

                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                   
                }
              

            }
            else if (cmb_price_level.SelectedIndex == 2)
            {
                query =
                from order in productsTable.AsEnumerable()
                where order.Field<Double>("RetailPrice") >= val1

                orderby order.Field<Double>("RetailPrice") ascending
                select order;

                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                  
                }
               
             
            }
            else if (cmb_price_level.SelectedIndex == 3)
            {

                query =
                from order in productsTable.AsEnumerable()
                where (order.Field<Double>("RetailPrice") >= val1
                    && order.Field<Double>("RetailPrice") <= val2)
                orderby order.Field<Double>("RetailPrice") ascending
                select order;

             
                if (query.Count() > 0)
                {
                     td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                    
                }
               
            }

            else if (cmb_price_level.SelectedIndex == 4)
            {

                 query =
                 from order in productsTable.AsEnumerable()
                 where order.Field<Double>("RetailPrice") == val1
                 select order;


                if (query.Count() > 0)
                {
                    td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                   
                }
               
            }

            lbl_no_row_found.Visible = !(query.Count() > 0);
            dgvFoodItem.Visible = (query.Count() > 0);

          
        }
        private void txt_price_level_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 13)
            {
                e.Handled = true;
                HandlePriceFilter(txt_price_level.Text, txt_price_level_2.Text);

            }
            else
            {
                e.Handled = true;
            }
        }

        private void dgvFoodItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblRowCount.Text = dgvFoodItem.Rows.Count + " product(s) found";
         
            dgvFoodItem.Visible = true;
         
            lbl_no_row_found.Visible = false;

            foreach (DataGridViewRow row in dgvFoodItem.Rows)
            {
                double stock = 0;
                try
                {
                    stock = Convert.ToDouble(row.Cells["UnitsInStock"].Value);
                }
                catch (Exception ex)
                {
                }
                double reorderLabel = 0;
                try
                {
                    reorderLabel = Convert.ToDouble(row.Cells["ReorderLevel"].Value);
                }
                catch (Exception ex)
                {
                }

                if (stock < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (stock == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

                else if (stock <= reorderLabel && stock > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            

        }

        private void txt_item_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                IEnumerable<DataRow> query =
                        from order in productsTable.AsEnumerable()
                        where order.Field<String>("Category3_Name").Contains(txt_item_name.Text)
                        select order;


                if (query.Count() > 0)
                {
                    DataTable td = query.CopyToDataTable<DataRow>();
                    dgvFoodItem.DataSource = td;
                }

                lbl_no_row_found.Visible = !(query.Count() > 0);
                dgvFoodItem.Visible = (query.Count() > 0);
            }
        }

        private void txt_stock_level_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 13)
            {
                e.Handled = true;
                HandleStockFilter(txt_stock_level.Text, txt_stock_level_2.Text);
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_stock_level_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 13)
            {
                e.Handled = true;
                HandleStockFilter(txt_stock_level.Text, txt_stock_level_2.Text);
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnExportProductListCSV_Click(object sender, EventArgs e)
        {
            exportToCSV();
        }


        private void exportToCSV()
        {



            SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
            saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();

            saveFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialogCSV.FilterIndex = 1;
            saveFileDialogCSV.RestoreDirectory = true;

            //if (rdbSelectedTable.Checked)
            //{
            string tableName = "ProductList";

            string fullPath = "";
            try
            {
                FolderSelect dlg = new FolderSelect();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo info = dlg.info;
                    fullPath = dlg.fullPath;
                }
                else
                {
                    return;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            fullPath = fullPath + "\\" + tableName + ".csv";

            exportToCSVfile(fullPath);

        }



        private void exportToCSVfile(string fileOut)
        {

            //      SqlConnection conn = new SqlConnection(DBForm.sqlConnString);
            //     string sqlQuery = "select * from " + this.lbxTables.SelectedItem.ToString();
            //    SqlCommand command = new SqlCommand(sqlQuery, conn);
            //   conn.Open();


            // productsTable.d

            //     SqlDataReader dr = command.ExecuteReader();


            //     DataTable dtSchema = dr.GetSchemaTable();


                   StreamWriter sw = new StreamWriter(fileOut, false, Encoding.Unicode);

            //      string strRow;
            //        if (this.chkFirstRowColumnNames.Checked)
            //      {
            //            sw.WriteLine(columnNames(dtSchema, this.separator));
            //       }

            string strRow = "";

            string separator = "\t";

            //strRow += "cat1 ";
            //strRow += separator;

            //strRow += "cat2 ";
            //strRow += separator;

            strRow += "Item ID";
            strRow += separator;

            strRow += "Product Name";
            strRow += separator;

            strRow += "Retail Price";
            strRow += separator;

            strRow += "Whole Price";
            strRow += separator;

            strRow += "Last Purchase Price";
            strRow += separator;

            strRow += "Vat Included";
            strRow += separator;

            strRow += "Non Tax ableGood";
            strRow += separator;

            strRow += "Qnty Per S.U.";
            strRow += separator;

            strRow += "Qnty Per P U";
            strRow += separator;

            strRow += "Stock";
            strRow += separator;


            sw.WriteLine(strRow);

            foreach (DataGridViewRow row in dgvFoodItem.Rows)
            {
                int itemID = Convert.ToInt32(row.Cells["cat3_id"].Value);

           //     CCategoryManager oManager = new CCategoryManager();
                CCategory3DAO cCategory3Dao = new CCategory3DAO();
                CCategory3 objFoodItemUpdate = cCategory3Dao.GetAllCategory3ByCategory3ID(itemID);
             //   CCategory3 objFoodItemUpdate = (CCategory3)oResult.Data;

                //   foreach (DataRow row in productsTable.Rows)
                //    {
                strRow = "";

                //Category Name
                //try
                //{

                //    strRow += Convert.ToString(row.Cells["cat1"].Value);
                //}
                //catch (Exception ex) { strRow += ""; }
                //strRow += separator;

                ////Category2_Name
                //try { strRow += Convert.ToString(row.Cells["cat2"].Value); }
                //catch (Exception ex) { strRow += ""; }
                //strRow += separator;

                //Item ID

                //  int itemID = 0;

                try
                {
                    strRow += Convert.ToString(itemID);
                }
                catch (Exception ex) { strRow += ""; }
                strRow += separator;



                //Product Name
                try { strRow += objFoodItemUpdate.Category3Name; }
                catch (Exception ex) { strRow += "  "; }
                strRow += separator;

                //Retail Sale Price
              //  try { strRow += objFoodItemUpdate.MRetailPrice.ToString("F2"); }
                try { strRow += objFoodItemUpdate.Category3TablePrice.ToString("F2"); }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //WholeSalePrice
               // try { strRow += Convert.ToString(objFoodItemUpdate.MWholeSalePrice.ToString("F2")); }
                try { strRow += Convert.ToString(objFoodItemUpdate.Category3TakeAwayPrice.ToString("F2")); }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //LastPurchasePrice
               // try { strRow += Convert.ToString(objFoodItemUpdate.MLastPurchasePrice.ToString("F2")); }
                try { strRow += Convert.ToString(objFoodItemUpdate.Category3BarPrice.ToString("F2")); }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //VatIncluded
                try
                {
                    strRow += objFoodItemUpdate.MVatIncluded.ToString();
                }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //NonTaxableGood
                try
                {
                    strRow += objFoodItemUpdate.MNonTaxableGood.ToString();
                }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //QTYPerSaleUint
                try
                {

                    strRow += objFoodItemUpdate.MQtyPerSaleUint.ToString();
                }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //QTYPerPurchaseUnit
                try
                {

                    strRow += objFoodItemUpdate.MQtyPerPurchaseUnit.ToString();
                }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;

                //Stock
                try
                {
                    strRow += objFoodItemUpdate.MUnitsInStock.ToString();

                }
                catch (Exception ex) { strRow += "   "; }
                strRow += separator;


                sw.WriteLine(strRow);
            }

            
            sw.Close();
          
            MessageBox.Show("CSV file Created Successful");
        }

        private void txt_price_level_TextChanged_1(object sender, EventArgs e)
        {

        }
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;

        private string[] lines;
        string strBody = "";
        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Lucida Console", 7);//@Salim Change Font Size      
            int printHeight;
            int printWidth;
            printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
            printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;
            StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
            RectangleF printArea = new RectangleF(0, 0, 260, printHeight);
            e.Graphics.DrawString(strBody, printFont, Brushes.Black, printArea, format);


        }
        // OnBeginPrint 
        private void OnBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
            {

                lines = strBody.Split(param);
            }
            else
            {
                lines = strBody.Split(param);

            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        private void btnPrintOutOfStock_Click(object sender, EventArgs e)
        {
            Category ctg = (Category)cmbCategory.SelectedItem;
            FillFoodItem(ctg.id, 3);
            PrintStockControl(3);

        }

        #region PrintStockControl
        private void PrintStockControl(int printType)
        {
              strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(40);
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Carnival Restaruant");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Road # 35; House # 1; Gulshan # 2");
            if (printType == 1)
            {
                strBody += "\r\n\n" + stringPrintFormater.CenterTextWithWhiteSpace("STOCK REPORT");
            }
            else if(printType == 2)
            {
                strBody += "\r\n\n" + stringPrintFormater.CenterTextWithWhiteSpace("Reorder Level OF STOCK REPORT");   
            }
            else if (printType == 2)
            {
                strBody += "\r\n\n" + stringPrintFormater.CenterTextWithWhiteSpace("OUT OF STOCK REPORT");
            }
            

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(DateTime.Now.ToLongDateString());
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 20, false);
            strBody += stringPrintFormater.GridCell("Qty", 5, true);
            strBody += stringPrintFormater.GridCell("Unit", 15, true);

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            double balanceQnty = 0;
            double currentQnty = 0;
            string itemName = "";

            foreach (DataGridViewRow row in dgvFoodItem.Rows)
            {
               // string[] _Item = row.Cells["Category3_Name"].Value.ToString().Split('.');
               // string Item = _Item[0];
               // string[] _Current_Stock = row.Cells["UnitsInStock"].Value.ToString().Split('.');
               // string Current_Stock = _Current_Stock[0];
               //// string[] _Balance_Unit = row.Cells["Balance_Unit"].Value.ToString().Split('.');
              //  string Balance_Unit = _Balance_Unit[0];

                try { currentQnty = Convert.ToDouble(row.Cells["UnitsInStock"].Value.ToString()); }
                catch(Exception )
                {
                    currentQnty = 0;
                }

                string uom="Kg";
                balanceQnty += currentQnty;

                strBody += "\r\n" + stringPrintFormater.GridCell(row.Cells["Category3_Name"].Value.ToString(), 20, false);
                strBody += stringPrintFormater.GridCell(currentQnty.ToString(), 5, true);
                strBody += stringPrintFormater.GridCell(balanceQnty.ToString(), 15, true);
               // strBody += stringPrintFormater.GridCell(row.Cells["uom"].Value.ToString(), 15, true);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("End Report");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("ibacs.co.uk");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Margins margins = new Margins(10, 10, 10, 10);
                printDocument1.DefaultPageSettings.Margins = margins;
                printDocument1.Print();
            }
        }
        #endregion


        private void btnViewOutOfStock_Click(object sender, EventArgs e)
        {
            //Category ctg = (Category)cmbCategory.SelectedItem;
            //FillFoodItem(ctg.id, 3);

            //Category ctg = (Category)cmbCategory.SelectedItem;
            //FillFoodItem(ctg.id, 3);
            IEnumerable<DataRow> query =
                       from order in productsTable.AsEnumerable()
                       where order.Field<String>("Category3_Name").Contains(txt_item_name.Text)
                       select order;


            if (query.Count() > 0)
            {
                DataTable td = query.CopyToDataTable<DataRow>();
                dgvFoodItem.DataSource = td;
            }

            lbl_no_row_found.Visible = !(query.Count() > 0);
            dgvFoodItem.Visible = (query.Count() > 0);


        }

        private void btnOutofReorderLevel_Click(object sender, EventArgs e)
        {
            Category ctg = (Category)cmbCategory.SelectedItem;
            FillFoodItem(ctg.id, 2);
        }

        private void functionalButton2_Click(object sender, EventArgs e)
        {
            PrintStockControl(1);
        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            Category ctg = (Category)cmbCategory.SelectedItem;
            FillFoodItem(ctg.id, 2);
            PrintStockControl(2);
        }

        private void dgvFoodItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

   

}


    public class Category
    {
        private string _name;
        private int _id;

      public  Category(string name, int id)
        {
            _name = name;
            _id = id;
        }

        public override string ToString()
        { return _name; }

        public int id
        {
            get { return _id; }
        }

        public string name
        {
            get { return _name; }
        }

    }
}
