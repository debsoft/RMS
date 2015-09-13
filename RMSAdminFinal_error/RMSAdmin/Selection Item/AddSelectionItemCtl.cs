using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.Config;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS;
using RMS.Common.ObjectModel;
using Managers.Category;

namespace RMSAdmin
{
    public partial class AddSelectionItemCtl : UserControl
    {
        private string m_sParentCategoryText = string.Empty;
        private string m_sFoodTypeText = string.Empty;
        private string m_sCategoryText = string.Empty;
        private string m_sFoodItemText = string.Empty;

        public AddSelectionItemCtl()
        {
            InitializeComponent();
        }

        public AddSelectionItemCtl(string inParentCategoryText, string inFoodTypeText, string inCategoryText, string inFoodItemText)
        {
            InitializeComponent();

            m_sParentCategoryText = inParentCategoryText;
            m_sFoodTypeText = inFoodTypeText;
            m_sCategoryText = inCategoryText;
            m_sFoodItemText = inFoodItemText;
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
                cmbParent.Text = m_sParentCategoryText;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+ ". Error Occured. Please contact to your administrator.");
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
                    cmbFoodType.Text = m_sFoodTypeText;
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
                    cmbFoodItem.Text = m_sFoodItemText;

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
                cmbCategory.Text = m_sCategoryText;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            bool bTempFlag = false;

            if (cmbParent.SelectedValue == null)
            {
                oResult.Message = " Please select parent category.";

                return oResult;
            }
            else if (cmbFoodType.SelectedValue == null)
            {
                oResult.Message = "Please select food type.";

                return oResult;
            }

            else if (cmbCategory.SelectedValue == null)
            {
                oResult.Message = "Please select category";

                return oResult;
            }

            else if (cmbFoodItem.SelectedValue == null)
            {
                oResult.Message = "Please select food item";

                return oResult;
            }

            else if (rdoActive.Checked==false && rdoInactive.Checked==false)
            {
                oResult.Message = "Please Select Status.";

                return oResult;
            }


            if (txtItemName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = "Please enter item name";

                return oResult;
            }


            if (!txtTablePrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtTablePrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = " Write table price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (!txtTakeAwayPrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtTakeAwayPrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = " Write takeaway price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (!txtBarPrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtBarPrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = " Write bar price, only numbers are allowed.";

                    return oResult;
                }

            }

            oResult.IsSuccess = true;

            return oResult;
        }
        #endregion
        private void AddSelectionItemCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentID = Convert.ToInt32(cmbParent.SelectedValue);
            FillCategory1ByID(parentID);
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
            this.FillCategory(foodTypeID);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            this.FillFoodItem(categoryID);
        }

        private void btnDone_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbParent.SelectedIndex = -1;
            cmbFoodType.SelectedIndex = -1;
            cmbFoodItem.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            txtBarPrice.Clear();
            txtTablePrice.Clear();
            txtTakeAwayPrice.Clear();
            txtDesc.Clear();
            txtItemName.Clear();
            rdoActive.Checked = false;
            rdoInactive.Checked = false;
            chkBar.Checked = false;
            chkTable.Checked = false;
            chkTakeAway.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                CCategory4 objSelectionOfItem = new CCategory4();

                objSelectionOfItem.Category4Name = txtItemName.Text.Trim();

                objSelectionOfItem.Category3ID = Int32.Parse(cmbFoodItem.SelectedValue.ToString());

                objSelectionOfItem.Category4Description = txtDesc.Text.Trim();

                if (rdoActive.Checked)
                { 
                 objSelectionOfItem.Category4OrderStatus=1;
                }
                else
                {
                 objSelectionOfItem.Category4OrderStatus=0;
                }

                if (!txtTablePrice.Text.Trim().Equals(String.Empty))
                {

                    objSelectionOfItem.Category4TablePrice = Double.Parse(txtTablePrice.Text.Trim());

                }

                if (!txtTakeAwayPrice.Text.Trim().Equals(String.Empty))
                {

                    objSelectionOfItem.Category4TakeAwayPrice = Double.Parse(txtTakeAwayPrice.Text.Trim());

                }

                if (!txtBarPrice.Text.Trim().Equals(String.Empty))
                {

                    objSelectionOfItem.Category4BarPrice = Double.Parse(txtBarPrice.Text.Trim());

                }

                if (chkTable.Checked)
                {
                    objSelectionOfItem.Category4ViewTable = 1;
                }

                if (chkBar.Checked)
                {
                    objSelectionOfItem.Category4ViewBar = 1;
                }

                if (chkTakeAway.Checked)
                {
                    objSelectionOfItem.Category4ViewTakeAway = 1;
                }

                if (chkUnlimited.Checked)
                {
                    objSelectionOfItem.InitialItemQuantity = 0;
                    objSelectionOfItem.UnlimitStatus = 1;
                }
                else
                {
                    objSelectionOfItem.UnlimitStatus = 0;
                    objSelectionOfItem.InitialItemQuantity = Convert.ToInt32("0"+txtStockQuantity.Text);
                }


                try
                {
                    objSelectionOfItem.vatRate = Convert.ToDouble(txtVateRate.Text.ToString());
                }
                catch
                {
                    objSelectionOfItem.vatRate = 0.00;
                }

                if (chkVateIncluded.Checked)
                {
                    objSelectionOfItem.vatIncluded = true;
                }
                else
                {
                    objSelectionOfItem.vatIncluded = false;
                }

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.AddCategory4(objSelectionOfItem);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = " The product has been saved successfully.";

                    lblSaveStatus.Visible = true;
                }
                else
                {
                    lblSaveStatus.Text = oResult2.Message;

                    lblSaveStatus.Visible = true;
                }
            }
            else
            {
                lblSaveStatus.Text = oResult.Message;

                lblSaveStatus.Visible = true;
            }
        }

        private void chkUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnlimited.Checked)
            {
                txtStockQuantity.Enabled = false;
            }
            else
            {
                txtStockQuantity.Enabled = true;
            }
        }
    }
}
