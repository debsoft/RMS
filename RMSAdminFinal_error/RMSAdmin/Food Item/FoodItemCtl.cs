using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.DataAccess;
using RMS;
using RMS.Common.Config;
using System.Data.SqlClient;
using Managers.Category;
using RMS.Common.ObjectModel;

namespace RMSAdmin
{
    public partial class FoodItemCtl : UserControl
    {
        private Form m_parentForm = null;
        private int m_selectedIndex = -1;
        private bool m_bGridFlag = true; // true if all category in grid


        private string m_productType = "";

        public string ProductType
        {
            get { return m_productType; }
            set { m_productType = value; }
        }

        

        public FoodItemCtl(Form objParent)
        {
            InitializeComponent();
            m_parentForm = objParent;
        }

        #region "Manupulation Area"
        private void FillParentCategory()
        {
            try
            {
                String queryStr = SqlQueries.GetQuery(Query.ViewParentCategory);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

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

                    CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                    String tempConnStr = oTempDal.ConnectionString;

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


        private void FillFoodItem(Int32 categoryID)
        {
            try
            {
                if (cmbCategory.SelectedIndex < 0)
                {
                    return;
                }
                else
                {
                        String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2Grid);



                        if (categoryID == 0)
                        {
                            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);

                            if (foodTypeID == 0)
                            {
                                sqlCommand = string.Format(SqlQueries.GetQuery(Query.ViewCategory3), ProductType);
                            }
                            else
                            {
                               // sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCategory3ByCat2GridByCategory1ID), foodTypeID, ProductType);
                            }
                        }
                        else
                        {
                            sqlCommand = String.Format(sqlCommand, categoryID, ProductType);
                        }

                       
                    //sqlCommand = String.Format(sqlCommand, categoryID);



                        CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                        String tempConnStr = oTempDal.ConnectionString;

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
                        dgvFoodItem.DataSource = table;

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

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

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

                cmbCategory.DataSource = table;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", 
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Int32 categoryID=Convert.ToInt32(cmbCategory.SelectedValue);
            FillFoodItem(categoryID);
        }

        private void FoodItemCtl_Load(object sender, EventArgs e)
        {
            FillParentCategory();
        }

        private void btnAddParentCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string sParentCategoryText = cmbParent.Text;
                string sFoodTypeText = cmbFoodType.Text;
                string sCategoryText = cmbCategory.Text;

                AddFoodItemCtl objAddFoodItem = new AddFoodItemCtl(sParentCategoryText, sFoodTypeText, sCategoryText);
                objAddFoodItem.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];
                objAddFoodItem.ProductType = "Finished";
                string s = pnl.Name;

                objAddFoodItem.ParentForm.Controls[s].Controls.Clear();
                objAddFoodItem.ParentForm.Controls[s].Controls.Add(objAddFoodItem);
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

                    if (m_selectedIndex >= 0 && dgvFoodItem.Rows.Count > m_selectedIndex)
                    {
                        int iTempInt = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[0].Value.ToString());

                        int iTempInt3 = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[2].Value.ToString());


                        CCategory3 oCat = new CCategory3();

                        oCat.Category3ID = iTempInt;

                        oCat.Category3Order = iTempInt3;


                        if ((m_selectedIndex + 1) > 0 && dgvFoodItem.Rows.Count > (m_selectedIndex + 1))
                        {
                            int iTempInt2 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex + 1)].Cells[0].Value.ToString());

                            int iTempInt4 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex + 1)].Cells[2].Value.ToString());

                            int iTempIndex = m_selectedIndex + 1;
                            CCategory3 oCat2 = new CCategory3();

                            oCat2.Category3ID = iTempInt2;

                            oCat2.Category3Order = iTempInt4;

                            if (cmbCategory.SelectedValue != null)
                            {

                                int iTempInt10 = Int32.Parse(cmbCategory.SelectedValue.ToString());

                                oCat2.Category2ID = iTempInt10;

                                oCat.Category2ID = iTempInt10;
                            }

                            CCategoryManager oCatManager = new CCategoryManager();

                            CResult oResult = oCatManager.UpdateCategory3Order(oCat, oCat2, false);

                            if (oResult.IsSuccess)
                            {

                                if (m_bGridFlag)
                                {
                                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                                    FillFoodItem(categoryID);

                                    dgvFoodItem.Rows[0].Selected = false;

                                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                                    m_selectedIndex = iTempIndex;

                                    if (m_selectedIndex > 12)
                                    {
                                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                    }
                                }
                                else
                                {

                                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                                    FillFoodItem(categoryID);

                                    dgvFoodItem.Rows[0].Selected = false;

                                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                                    m_selectedIndex = iTempIndex;

                                    if (m_selectedIndex > 12)
                                    {
                                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                    }

                                }

                            }


                        }
                    }
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
                    if (m_selectedIndex > 0 && dgvFoodItem.Rows.Count > m_selectedIndex)
                    {
                        int iTempInt = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[0].Value.ToString());

                        int iTempInt3 = Int32.Parse(dgvFoodItem.Rows[m_selectedIndex].Cells[2].Value.ToString());

                        CCategory3 oCat = new CCategory3();

                        oCat.Category3ID = iTempInt;

                        oCat.Category3Order = iTempInt3;

                        if ((m_selectedIndex - 1) >= 0 && dgvFoodItem.Rows.Count > (m_selectedIndex - 1))
                        {
                            int iTempInt2 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex - 1)].Cells[0].Value.ToString());

                            int iTempInt4 = Int32.Parse(dgvFoodItem.Rows[(m_selectedIndex - 1)].Cells[2].Value.ToString());

                            int iTempIndex = m_selectedIndex - 1;

                            CCategory3 oCat2 = new CCategory3();

                            oCat2.Category3ID = iTempInt2;

                            oCat2.Category3Order = iTempInt4;

                            if (cmbCategory.SelectedValue != null)
                            {

                                int iTempInt10 = Int32.Parse(cmbCategory.SelectedValue.ToString());

                                oCat2.Category2ID = iTempInt10;

                                oCat.Category2ID = iTempInt10;

                            }

                            CCategoryManager oCatManager = new CCategoryManager();

                            CResult oResult = oCatManager.UpdateCategory3Order(oCat, oCat2, true);

                            if (oResult.IsSuccess)
                            {

                                if (m_bGridFlag)
                                {
                                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                                    FillFoodItem(categoryID);

                                    dgvFoodItem.Rows[0].Selected = false;

                                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                                    m_selectedIndex = iTempIndex;

                                    if (m_selectedIndex > 12)
                                    {
                                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                    }
                                }
                                else
                                {

                                    Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                                    FillFoodItem(categoryID);

                                    dgvFoodItem.Rows[0].Selected = false;

                                    dgvFoodItem.Rows[iTempIndex].Selected = true;

                                    m_selectedIndex = iTempIndex;

                                    if (m_selectedIndex > 12)
                                    {
                                        dgvFoodItem.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                    }

                                }

                            }
                    }
                }
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
                if (e.ColumnIndex == 6)
                {
                    Int32 itemID = Convert.ToInt32("0" + dgvFoodItem.Rows[e.RowIndex].Cells[0].Value);

                    UpdateFoodItemCtl objUpdate = new UpdateFoodItemCtl(itemID);
                    objUpdate.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdate.ParentForm.Controls[s].Controls.Clear();
                    objUpdate.ParentForm.Controls[s].Controls.Add(objUpdate);
                }

                else if (e.ColumnIndex == 7)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected category?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int itemID = 0;

                        bool bTempBool = Int32.TryParse(dgvFoodItem.Rows[e.RowIndex].Cells[0].Value.ToString(), out itemID);

                        if (bTempBool)
                        {
                            CCategory3 oCat = new CCategory3();

                            oCat.Category3ID = itemID;
                            CCategoryManager oManager = new CCategoryManager();

                            CResult oResult = oManager.DeleteCat3(oCat);

                            if (oResult.IsSuccess)
                            {
                                dgvFoodItem.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void dgvFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                m_selectedIndex = e.RowIndex;
            }
        }

        private void btnAddRawMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                string sParentCategoryText = cmbParent.Text;
                string sFoodTypeText = cmbFoodType.Text;
                string sCategoryText = cmbCategory.Text;

                AddFoodItemCtl objAddFoodItem = new AddFoodItemCtl(sParentCategoryText, sFoodTypeText, sCategoryText);
                objAddFoodItem.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

              objAddFoodItem.ProductType = "RawMaterial";

                objAddFoodItem.ParentForm.Controls[s].Controls.Clear();
                objAddFoodItem.ParentForm.Controls[s].Controls.Add(objAddFoodItem);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
    }
}
