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
using RMS.DataAccess;
using RMS;
using RMS.Common.ObjectModel;
using Managers.Category;

namespace RMSAdmin
{
    public partial class SelectionItemCtl : UserControl
    {
        private Form m_parentForm = null;
        private bool m_bGridFlag = true; // true if all category in grid
        private int m_iSelectedIndex = -1;

        public SelectionItemCtl(Form objParent)
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
                MessageBox.Show(exp.Message+ "Error Occured. Please contact to your administrator.");
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
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
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
                    String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory3ByCat2ComboBox);

                    sqlCommand = String.Format(sqlCommand, categoryID);

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
                    cmbFoodItem.DataSource = table;

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

                cmbCategory.DisplayMember = "cat2_name";

                cmbCategory.ValueMember = "cat2_id";

                cmbCategory.DataSource = table;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillSelectedItems(Int32 foodItemID)
        {
            if (cmbFoodItem.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                    String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory4ByCat3);

                    sqlCommand = String.Format(sqlCommand, foodItemID);

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

                    dgvSelectionItem.DataSource = table;

                    dataAdapter.Dispose();
            }
        }


        #endregion

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            this.FillFoodItem(categoryID);
        }

        private void SelectionItemCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentID=Convert.ToInt32(cmbParent.SelectedValue);
            FillCategory1ByID(parentID);
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
            this.FillCategory(foodTypeID);
        }

        private void cmbFoodItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodItemID=Convert.ToInt32(cmbFoodItem.SelectedValue);
            FillSelectedItems(foodItemID);
        }

        private void btnAddSelectionItems_Click(object sender, EventArgs e)
        {
            try
            {
                string sParentCategoryText = cmbParent.Text;
                string sFoodTypeText = cmbFoodType.Text;
                string sCategoryText = cmbCategory.Text;
                string sFoodItem = cmbFoodItem.Text;

                AddSelectionItemCtl objAddFoodType = new AddSelectionItemCtl(sParentCategoryText, sFoodTypeText, sCategoryText, sFoodItem);
                objAddFoodType.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

                objAddFoodType.ParentForm.Controls[s].Controls.Clear();
                objAddFoodType.ParentForm.Controls[s].Controls.Add(objAddFoodType);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void dgvSelectionItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            try
            {
                if (e.ColumnIndex == 7)
                {
                    Int32 itemID = Convert.ToInt32("0" + dgvSelectionItem.Rows[e.RowIndex].Cells[0].Value);

                    UpdateSelectionItemCtl objSelection = new UpdateSelectionItemCtl(itemID);
                    objSelection.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objSelection.ParentForm.Controls[s].Controls.Clear();
                    objSelection.ParentForm.Controls[s].Controls.Add(objSelection);
                }

                else if (e.ColumnIndex == 8)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected food type?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int selectItemCatId = 0;

                        bool bTempBool = Int32.TryParse(dgvSelectionItem.Rows[e.RowIndex].Cells[0].Value.ToString(), out selectItemCatId);

                        if (bTempBool)
                        {
                            CCategory4 objSelectItem = new CCategory4();

                            objSelectItem.Category4ID = selectItemCatId;
                            CCategoryManager oManager = new CCategoryManager();

                            CResult oResult = oManager.DeleteCat4(objSelectItem);

                            if (oResult.IsSuccess)
                            {
                                dgvSelectionItem.Rows.RemoveAt(e.RowIndex);
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

        private void SelectionItemCtl_VisibleChanged(object sender, EventArgs e)
        {
            this.FillParentCategory();

            Int32 foodItemID = Convert.ToInt32(cmbFoodItem.SelectedValue);
            FillSelectedItems(foodItemID);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                    if (m_iSelectedIndex > 0 && dgvSelectionItem.Rows.Count > m_iSelectedIndex)
                    {
                        int iTempInt = Int32.Parse(dgvSelectionItem.Rows[m_iSelectedIndex].Cells[0].Value.ToString());

                        int iTempInt3 = Int32.Parse(dgvSelectionItem.Rows[m_iSelectedIndex].Cells[2].Value.ToString());

                        CCategory4 oCat = new CCategory4();

                        oCat.Category4ID = iTempInt;

                        oCat.Category4Order = iTempInt3;

                        if ((m_iSelectedIndex - 1) >= 0 && dgvSelectionItem.Rows.Count > (m_iSelectedIndex - 1))
                        {
                            int iTempInt2 = Int32.Parse(dgvSelectionItem.Rows[(m_iSelectedIndex - 1)].Cells[0].Value.ToString());

                            int iTempInt4 = Int32.Parse(dgvSelectionItem.Rows[(m_iSelectedIndex - 1)].Cells[2].Value.ToString());

                            int iTempIndex = m_iSelectedIndex - 1;

                            CCategory4 oCat2 = new CCategory4();

                            oCat2.Category4ID = iTempInt2;

                            oCat2.Category4Order = iTempInt4;

                            if (cmbFoodItem.SelectedValue != null)
                            {
                                int iTempInt10 = Int32.Parse(cmbFoodItem.SelectedValue.ToString());

                                oCat.Category3ID = iTempInt10;

                                oCat2.Category3ID = iTempInt10;
                            }

                            CCategoryManager oCatManager = new CCategoryManager();

                            CResult oResult = oCatManager.UpdateCategory4Order(oCat, oCat2, true);

                            if (oResult.IsSuccess)
                            {

                                if (m_bGridFlag)
                                {
                                    Int32 foodItemID = Convert.ToInt32(cmbFoodItem.SelectedValue);
                                    FillSelectedItems(foodItemID);

                                    dgvSelectionItem.Rows[0].Selected = false;

                                    dgvSelectionItem.Rows[iTempIndex].Selected = true;

                                    m_iSelectedIndex = iTempIndex;

                                    if (m_iSelectedIndex > 12)
                                    {
                                        dgvSelectionItem.FirstDisplayedScrollingRowIndex = m_iSelectedIndex - 12;
                                    }
                                }
                                else
                                {

                                    Int32 foodItemID = Convert.ToInt32(cmbFoodItem.SelectedValue);
                                    FillSelectedItems(foodItemID);

                                    dgvSelectionItem.Rows[0].Selected = false;

                                    dgvSelectionItem.Rows[iTempIndex].Selected = true;

                                    m_iSelectedIndex = iTempIndex;

                                    if (m_iSelectedIndex > 12)
                                    {
                                        dgvSelectionItem.FirstDisplayedScrollingRowIndex = m_iSelectedIndex - 12;
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

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                    if (m_iSelectedIndex >= 0 && dgvSelectionItem.Rows.Count > m_iSelectedIndex)
                    {
                        int iTempInt = Int32.Parse(dgvSelectionItem.Rows[m_iSelectedIndex].Cells[0].Value.ToString());

                        int iTempInt3 = Int32.Parse(dgvSelectionItem.Rows[m_iSelectedIndex].Cells[2].Value.ToString());


                        CCategory4 oCat = new CCategory4();

                        oCat.Category4ID = iTempInt;

                        oCat.Category4Order = iTempInt3;

                        if ((m_iSelectedIndex + 1) > 0 && dgvSelectionItem.Rows.Count > (m_iSelectedIndex + 1))
                        {
                            int iTempInt2 = Int32.Parse(dgvSelectionItem.Rows[(m_iSelectedIndex + 1)].Cells[0].Value.ToString());

                            int iTempInt4 = Int32.Parse(dgvSelectionItem.Rows[(m_iSelectedIndex + 1)].Cells[2].Value.ToString());

                            int iTempIndex = m_iSelectedIndex + 1;
                            CCategory4 oCat2 = new CCategory4();

                            oCat2.Category4ID = iTempInt2;

                            oCat2.Category4Order = iTempInt4;

                            if (cmbFoodItem.SelectedValue != null)
                            {
                                int iTempInt10 = Int32.Parse(cmbFoodItem.SelectedValue.ToString());

                                oCat.Category3ID = iTempInt10;

                                oCat2.Category3ID = iTempInt10;
                            }

                            CCategoryManager oCatManager = new CCategoryManager();

                            CResult oResult = oCatManager.UpdateCategory4Order(oCat, oCat2, false);

                            if (oResult.IsSuccess)
                            {

                                if (m_bGridFlag)
                                {
                                    Int32 foodItemID = Convert.ToInt32(cmbFoodItem.SelectedValue);
                                    FillSelectedItems(foodItemID);

                                    dgvSelectionItem.Rows[0].Selected = false;

                                    dgvSelectionItem.Rows[iTempIndex].Selected = true;

                                    m_iSelectedIndex = iTempIndex;

                                    if (m_iSelectedIndex > 12)
                                    {
                                        dgvSelectionItem.FirstDisplayedScrollingRowIndex = m_iSelectedIndex - 12;
                                    }
                                }
                                else
                                {

                                    Int32 foodItemID = Convert.ToInt32(cmbFoodItem.SelectedValue);
                                    FillSelectedItems(foodItemID);

                                    dgvSelectionItem.Rows[0].Selected = false;

                                    dgvSelectionItem.Rows[iTempIndex].Selected = true;

                                    m_iSelectedIndex = iTempIndex;

                                    if (m_iSelectedIndex > 12)
                                    {
                                        dgvSelectionItem.FirstDisplayedScrollingRowIndex = m_iSelectedIndex - 12;
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

        private void dgvSelectionItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                m_iSelectedIndex = e.RowIndex;
            }
        }
    }
}
