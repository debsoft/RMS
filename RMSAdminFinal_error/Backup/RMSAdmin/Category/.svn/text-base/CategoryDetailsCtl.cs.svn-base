using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RMS.Common.Config;
using RMS;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using Managers.Category;

namespace RMSAdmin
{
    public partial class CategoryDetailsCtl : UserControl
    {
        private Form m_parentForm = null;
        private int m_selectedIndex = -1;
        private bool m_bGridFlag = true; // true if all category in grid

        public CategoryDetailsCtl(Form objParent)
        {
            InitializeComponent();
            m_parentForm = objParent;
        }

        #region "Manupulation Area"
        private void FillFoodCategory()
        {
            String sqlCommand = String.Empty;
            if (cmbFoodType.SelectedIndex < 0)
            {
                DataTable dtCategory = new DataTable();
                dtCategory.Columns.Add("cat2_id");
                dtCategory.Columns.Add("Category2_Name");
                dtCategory.Columns.Add("Category1_Name");
                 dtCategory.Columns.Add("Category2_Order");
                dtCategory.Columns.Add("Parent_Category_Name");
                dtCategory.Columns.Add("up");
                dtCategory.Columns.Add("del");

                dgvCategory.DataSource = dtCategory;
                return;
            }
            else
            {
                    Int32  foodTypeID = Int32.Parse(cmbFoodType.SelectedValue.ToString());

                    if (foodTypeID > 0)
                    {
                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory2ByCat1);

                        sqlCommand = String.Format(sqlCommand, foodTypeID);
                    }
                    else
                    {
                        sqlCommand = SqlQueries.GetQuery(Query.ViewAllCategory);
                    }

                    CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                    String tempConnStr = oTempDal.ConnectionString;

                    // Create a new data adapter based on the specified query.
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                   
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dgvCategory.DataSource = table;
                    table.TableName = "food_category_name";
                    table.WriteXml("food_category_name.xml");

                    dataAdapter.Dispose();
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
                sqlCommand = SqlQueries.GetQuery(Query.ViewAllFoodType);
            }
            else
            { 
             sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCat1ComboBox),parentId);
            }

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            String tempConnStr = oTempDal.ConnectionString;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                table.Rows.Add(new object[] { "0", "All" });
                cmbFoodType.DataSource = table;
                cmbFoodType.Text = "All";
            }
            else
            {
                cmbFoodType.DataSource = table;
                cmbFoodType.SelectedIndex = -1;
                FillFoodCategory();
            }

            dataAdapter.Dispose();
        }

        private void FillParentCategory()
        {
            try
            {
                String sqlCommand = SqlQueries.GetQuery(Query.ViewParentCategory);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                table.Rows.Add(new object[] { "0", "All", "up", "del" });
                DataView dv = new DataView(table);
                cmbParent.DataSource = dv;
                cmbParent.Text = "All";
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", 
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void CategoryDetailsCtl_VisibleChanged(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 parentId = Convert.ToInt32("0" + cmbParent.SelectedValue);
                this.FillFoodType(parentId);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillFoodCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string patentCategoryText = cmbParent.Text.Trim();
                string foodTypeText = cmbFoodType.Text.Trim();

                AddCategoryCtl objAddCat = new AddCategoryCtl(patentCategoryText, foodTypeText);
                objAddCat.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

                objAddCat.ParentForm.Controls[s].Controls.Clear();
                objAddCat.ParentForm.Controls[s].Controls.Add(objAddCat);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void dgvCategory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            
            try
            {
                if (e.ColumnIndex == 5)
                {
                    Int32 categoryID = Convert.ToInt32("0" + dgvCategory.Rows[e.RowIndex].Cells[0].Value);

                    UpdateCategoryCtl objUpdate = new UpdateCategoryCtl(categoryID);
                    objUpdate.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdate.ParentForm.Controls[s].Controls.Clear();
                    objUpdate.ParentForm.Controls[s].Controls.Add(objUpdate);
                }

                else if (e.ColumnIndex == 6)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected category?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int parentCatId = 0;

                        bool bTempBool = Int32.TryParse(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString(), out parentCatId);

                        if (bTempBool)
                        {
                            CCategory2 oCat = new CCategory2();

                            oCat.Category2ID = parentCatId;
                            CCategoryManager oManager = new CCategoryManager();

                            CResult oResult = oManager.DeleteCat2(oCat);

                            if (oResult.IsSuccess)
                            {
                                dgvCategory.Rows.RemoveAt(e.RowIndex);
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_selectedIndex > 0 && dgvCategory.Rows.Count > m_selectedIndex)
                {
                    int iTempInt = Int32.Parse(dgvCategory.Rows[m_selectedIndex].Cells[0].Value.ToString());

                    int iTempInt3 = Int32.Parse(dgvCategory.Rows[m_selectedIndex].Cells[3].Value.ToString());

                    CCategory2 oCat = new CCategory2();

                    oCat.Category2ID = iTempInt;

                    oCat.Category2Order = iTempInt3;

                    if ((m_selectedIndex - 1) >= 0 && dgvCategory.Rows.Count > (m_selectedIndex - 1))
                    {
                        int iTempInt2 = Int32.Parse(dgvCategory.Rows[(m_selectedIndex - 1)].Cells[0].Value.ToString());

                        int iTempInt4 = Int32.Parse(dgvCategory.Rows[(m_selectedIndex - 1)].Cells[3].Value.ToString());

                        int iTempIndex = m_selectedIndex - 1;

                        CCategory2 oCat2 = new CCategory2();

                        oCat2.Category2ID = iTempInt2;

                        oCat2.Category2Order = iTempInt4;

                        CCategoryManager oCatManager = new CCategoryManager();

                        CResult oResult = oCatManager.UpdateCategory2Order(oCat, oCat2, true);

                        if (oResult.IsSuccess)
                        {

                            if (m_bGridFlag)
                            {
                                this.FillFoodCategory();

                                dgvCategory.Rows[0].Selected = false;

                                dgvCategory.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvCategory.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                }
                            }
                            else
                            {

                                this.FillFoodCategory();

                                dgvCategory.Rows[0].Selected = false;

                                dgvCategory.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvCategory.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
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

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {

                if (m_selectedIndex >= 0 && dgvCategory.Rows.Count > m_selectedIndex)
                {
                    int iTempInt = Int32.Parse(dgvCategory.Rows[m_selectedIndex].Cells[0].Value.ToString());

                    int iTempInt3 = Int32.Parse(dgvCategory.Rows[m_selectedIndex].Cells[3].Value.ToString());


                    CCategory2 oCat = new CCategory2();

                    oCat.Category2ID = iTempInt;

                    oCat.Category2Order = iTempInt3;

                    if ((m_selectedIndex + 1) > 0 && dgvCategory.Rows.Count > (m_selectedIndex + 1))
                    {
                        int iTempInt2 = Int32.Parse(dgvCategory.Rows[(m_selectedIndex + 1)].Cells[0].Value.ToString());

                        int iTempInt4 = Int32.Parse(dgvCategory.Rows[(m_selectedIndex + 1)].Cells[3].Value.ToString());

                        int iTempIndex = m_selectedIndex + 1;
                        CCategory2 oCat2 = new CCategory2();

                        oCat2.Category2ID = iTempInt2;

                        oCat2.Category2Order = iTempInt4;

                        CCategoryManager oCatManager = new CCategoryManager();

                        CResult oResult = oCatManager.UpdateCategory2Order(oCat, oCat2, false);

                        if (oResult.IsSuccess)
                        {

                            if (m_bGridFlag)
                            {
                                this.FillFoodCategory();

                                dgvCategory.Rows[0].Selected = false;

                                dgvCategory.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvCategory.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                }
                            }
                            else
                            {

                                this.FillFoodCategory();

                                dgvCategory.Rows[0].Selected = false;

                                dgvCategory.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvCategory.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
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

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                m_selectedIndex = e.RowIndex;
            }
        }
    }
}
