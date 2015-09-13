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
    public partial class FoodTypeCtl : UserControl
    {
        private Form m_parentForm = null;
        private int m_selectedIndex = -1;
        private bool m_bGridFlag = true; // true if all category in grid

        public FoodTypeCtl(Form objParent)
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
                //table.Rows.Add(new object[]{"0","All","",""});
                cmbParentCategory.DataSource = table;
                //cmbParentCategory.Text = "All";
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+ ". Error Occured. Please contact to your administrator.");
            }
        }

        private void FillCategory1ByID(int parentCategoryID)
        {
            if (cmbParentCategory.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                if (cmbParentCategory.SelectedValue != null)
                {
                    //int iTempInt = Int32.Parse(cmbParentCategory.SelectedValue.ToString());

                    String sqlCommand = String.Empty;

                    if (cmbParentCategory.SelectedValue.ToString() == "0")
                    {
                        sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1);
                    }
                    else
                    {
                       sqlCommand= SqlQueries.GetQuery(Query.ViewCategory1ByParentCat);
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

                    dgvFoodTypeList.DataSource = table;

                    dataAdapter.Dispose();
                }
            }
        }

        #endregion


        private void FoodTypeCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void cmbParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentCatId = Convert.ToInt32(cmbParentCategory.SelectedValue);
            this.FillCategory1ByID(parentCatId);
        }

        private void btnAddFoodType_Click(object sender, EventArgs e)
        {
            try
            {
                AddFoodTypeCtl objAddFoodType = new AddFoodTypeCtl(cmbParentCategory.Text.ToString());
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


        private void FoodTypeCtl_VisibleChanged(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_selectedIndex > 0 && dgvFoodTypeList.Rows.Count > m_selectedIndex)
                {
                    int currentCategoryID = Int32.Parse(dgvFoodTypeList.Rows[m_selectedIndex].Cells[0].Value.ToString());

                    int currentcategoryOrdernumber = Int32.Parse(dgvFoodTypeList.Rows[m_selectedIndex].Cells[3].Value.ToString());

                    CCategory1 oCat = new CCategory1();

                    oCat.Category1ID = currentCategoryID;

                    oCat.Category1OrderNumber = currentcategoryOrdernumber;

                    if ((m_selectedIndex - 1) >= 0 && dgvFoodTypeList.Rows.Count > (m_selectedIndex - 1))
                    {
                        int antiCategoryID = Int32.Parse(dgvFoodTypeList.Rows[(m_selectedIndex - 1)].Cells[0].Value.ToString());

                        int antiCategoryOrderNumber = Int32.Parse(dgvFoodTypeList.Rows[(m_selectedIndex - 1)].Cells[3].Value.ToString());

                        int iTempIndex = m_selectedIndex - 1;

                        CCategory1 oCat2 = new CCategory1();

                        oCat2.Category1ID = antiCategoryID;

                        oCat2.Category1OrderNumber = antiCategoryOrderNumber;

                        CCategoryManager oCatManager = new CCategoryManager();

                        CResult oResult = oCatManager.UpdateCategory1Order(oCat, oCat2, true);

                        if (oResult.IsSuccess)
                        {

                            if (m_bGridFlag)
                            {
                                Int32 foodTypeID=Convert.ToInt32(cmbParentCategory.SelectedValue);
                                FillCategory1ByID(foodTypeID);

                                dgvFoodTypeList.Rows[0].Selected = false;

                                dgvFoodTypeList.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvFoodTypeList.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                }
                            }
                            else
                            {

                                Int32 foodTypeID = Convert.ToInt32(cmbParentCategory.SelectedValue);
                                FillCategory1ByID(foodTypeID);

                                dgvFoodTypeList.Rows[0].Selected = false;

                                dgvFoodTypeList.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvFoodTypeList.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
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
                if (m_selectedIndex >= 0 && dgvFoodTypeList.Rows.Count > m_selectedIndex)
                {
                    int currentCategoryID = Int32.Parse(dgvFoodTypeList.Rows[m_selectedIndex].Cells[0].Value.ToString());

                    int currentCategoryOrder = Int32.Parse(dgvFoodTypeList.Rows[m_selectedIndex].Cells[3].Value.ToString());


                    CCategory1 oCat = new CCategory1();

                    oCat.Category1ID = currentCategoryID;

                    oCat.Category1OrderNumber = currentCategoryOrder;

                    if ((m_selectedIndex + 1) > 0 && dgvFoodTypeList.Rows.Count > (m_selectedIndex + 1))
                    {
                        int antiCategoryID = Int32.Parse(dgvFoodTypeList.Rows[(m_selectedIndex + 1)].Cells[0].Value.ToString());

                        int antiCategoryOrder = Int32.Parse(dgvFoodTypeList.Rows[(m_selectedIndex + 1)].Cells[3].Value.ToString());

                        int iTempIndex = m_selectedIndex + 1;
                        CCategory1 oCat1 = new CCategory1();

                        oCat1.Category1ID = antiCategoryID;

                        oCat1.Category1OrderNumber = antiCategoryOrder;

                        CCategoryManager oCatManager = new CCategoryManager();

                        CResult oResult = oCatManager.UpdateCategory1Order(oCat, oCat1, false);

                        if (oResult.IsSuccess)
                        {

                            if (m_bGridFlag)
                            {
                                Int32 foodTypeID = Convert.ToInt32(cmbParentCategory.SelectedValue);
                                FillCategory1ByID(foodTypeID);

                                dgvFoodTypeList.Rows[0].Selected = false;

                                dgvFoodTypeList.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvFoodTypeList.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
                                }
                            }
                            else
                            {

                                Int32 foodTypeID = Convert.ToInt32(cmbParentCategory.SelectedValue);
                                FillCategory1ByID(foodTypeID);

                                dgvFoodTypeList.Rows[0].Selected = false;

                                dgvFoodTypeList.Rows[iTempIndex].Selected = true;

                                m_selectedIndex = iTempIndex;

                                if (m_selectedIndex > 12)
                                {
                                    dgvFoodTypeList.FirstDisplayedScrollingRowIndex = m_selectedIndex - 12;
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

      
        private void dgvFoodTypeList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {
                if (e.ColumnIndex == 4)
                {
                    Int32 foodTypeID = Convert.ToInt32("0" + dgvFoodTypeList.Rows[e.RowIndex].Cells[0].Value);
                    string foodTypeName = Convert.ToString(dgvFoodTypeList.Rows[e.RowIndex].Cells[1].Value);

                    EditFoodTypeCtl objFoodType = new EditFoodTypeCtl(foodTypeID, foodTypeName);
                    objFoodType.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objFoodType.ParentForm.Controls[s].Controls.Clear();
                    objFoodType.ParentForm.Controls[s].Controls.Add(objFoodType);
                }

                else if (e.ColumnIndex == 5)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected food type?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int foodTypeID = 0;

                        bool bTempBool = Int32.TryParse(dgvFoodTypeList.Rows[e.RowIndex].Cells[0].Value.ToString(), out foodTypeID);

                        if (bTempBool)
                        {
                            CCategory1 objFoodType = new CCategory1();

                            objFoodType.Category1ID = foodTypeID;
                            CCategoryManager oManager = new CCategoryManager();

                            CResult oResult = oManager.DeleteCat1(objFoodType);

                            if (oResult.IsSuccess)
                            {
                                dgvFoodTypeList.Rows.RemoveAt(e.RowIndex);
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

        private void dgvFoodTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                m_selectedIndex = e.RowIndex;
            }
        }
    }
}
