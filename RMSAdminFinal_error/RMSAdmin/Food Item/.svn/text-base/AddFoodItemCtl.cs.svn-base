using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.Category;
using RMS.Common.Config;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS;

namespace RMSAdmin
{
    public partial class AddFoodItemCtl : UserControl
    {
        private string m_sParentCategoryText = string.Empty;
        private string m_sFoodTypeText = string.Empty;
        private string m_sCategoryText = string.Empty;

        public AddFoodItemCtl()
        {
            InitializeComponent();
        }

        public AddFoodItemCtl(string inParentCategoryText, string inFoodTypeText, string inCategoryText)
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

            if (rdoActive.Checked == false && rdoInactive.Checked == false)
            {
                oResult.Message = "Please select status.";

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
                    oResult.Message = "Please enter table price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (!txtTakeawayPrice.Text.Trim().Equals(String.Empty))
            {
                double iTempInt1;

                bTempFlag = Double.TryParse(txtTakeawayPrice.Text.Trim(), out iTempInt1);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = "Please enter takeaway price, only numbers are allowed.";

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
                    oResult.Message = "Please enter bar price, only numbers are allowed.";

                    return oResult;
                }

            }

            if (txtInitialQuantity.Text.Trim().Equals(String.Empty) && (chkUnlimited.Checked==false))
            {
                oResult.Message = "Please enter initial quantity status of the item.";
                return oResult;
            }

            if (cmbSellingIn.SelectedIndex<0)
            {
                oResult.Message = "Please select item selling in value.";
                cmbSellingIn.Focus();
                return oResult;
            }

            oResult.IsSuccess = true;

            return oResult;
        }

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
                cmbParent.DataSource = table;
                cmbCategory.Text = m_sParentCategoryText;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+ ". Error Occured. Please contact to your administrator.");
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
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCat1ComboBox), parentId);
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

            cmbFoodType.DataSource = table;
            cmbFoodType.Text = m_sFoodTypeText;

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
                    String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory2ByCat1);

                    sqlCommand = String.Format(sqlCommand, foodTypeID);

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
                    cmbCategory.DataSource = table;
                    cmbCategory.Text = m_sCategoryText;
                    dataAdapter.Dispose();
                }
            }
        }

        #endregion

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

        /// <summary>
        /// Saving the food item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult objResult = ValidateForm();

            if (objResult.IsSuccess)
            {
                CCategory3 objFoodItem = new CCategory3();

                objFoodItem.Category2ID = Int32.Parse(cmbCategory.SelectedValue.ToString());

                objFoodItem.Category3Name = txtProductName.Text.Trim();

                objFoodItem.Category3Description = txtDescription.Text.Trim();


                if (chkTable.Checked)
                {
                    objFoodItem.Category3ViewTable = 1;
                }

                if (chkBar.Checked)
                {
                    objFoodItem.Category3ViewBar = 1;
                }

                if (chkTakeAway.Checked)
                {
                    objFoodItem.Category3ViewTakeAway = 1;
                }

                if (!txtTablePrice.Text.Trim().Equals(String.Empty))
                {
                    objFoodItem.Category3TablePrice = Double.Parse(txtTablePrice.Text.Trim());
                }

                if (!txtTakeawayPrice.Text.Trim().Equals(String.Empty))
                {
                    objFoodItem.Category3TakeAwayPrice = Double.Parse(txtTakeawayPrice.Text.Trim());
                }

                if (!txtBarPrice.Text.Trim().Equals(String.Empty))
                {
                    objFoodItem.Category3BarPrice = Double.Parse(txtBarPrice.Text.Trim());
                }

                if (rdoActive.Checked)
                {
                    objFoodItem.Category3OrderStatus = 1;
                }
                else if (rdoInactive.Checked)
                {
                    objFoodItem.Category3OrderStatus = 0;
                }

                if (chkUnlimited.Checked)
                {
                    objFoodItem.InitialItemQuantity = 0;
                    objFoodItem.UnlimitStatus = 1;
                }
                else
                {
                    objFoodItem.InitialItemQuantity = Convert.ToInt32("0"+txtInitialQuantity.Text);
                    objFoodItem.UnlimitStatus = 0;
                }

                objFoodItem.ItemSellingIn = cmbSellingIn.Text; //Whether the item sold in quantity or weight

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.AddCategory3(objFoodItem);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = " The product has been saved successfully.";
                    lblSaveStatus.Visible = true;
                }
                else
                {
                    lblSaveStatus.Text = "The product can not be added. Please try again. ";
                    lblSaveStatus.Visible = true;
                }
            }
            else
            {
                lblSaveStatus.Text = objResult.Message;

                lblSaveStatus.Visible = true;
            }
        }

        private void AddFoodItemCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentId = Convert.ToInt32(cmbParent.SelectedValue);
            FillFoodType(parentId);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbFoodType.SelectedIndex = -1;
            cmbParent.SelectedIndex = -1;
            txtBarPrice.Clear();
            txtDescription.Clear();
            txtProductName.Clear();
            txtTablePrice.Clear();
            txtTakeawayPrice.Clear();
            rdoActive.Checked = false;
            rdoInactive.Checked = false;
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
            FillFoodCategory(foodTypeID);
        }

        private void chkUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnlimited.Checked)
            {
                txtInitialQuantity.Enabled = false;
            }
            else
            {
                txtInitialQuantity.Enabled = true;
            }
        }
    }
}
