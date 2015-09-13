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
    public partial class UpdateSelectionItemCtl : UserControl
    {
        private Int32 m_selectionItemCategoryID = 0;
        private int m_selectionItemOrder=0;
        private Int64 m_iRank = 0;

        public UpdateSelectionItemCtl(Int32 catID)
        {
            InitializeComponent();
            m_selectionItemCategoryID = catID;
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

            else if (rdoActive.Checked == false && rdoInactive.Checked == false)
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
                    oResult.Message = "Write bar price, only numbers are allowed.";

                    return oResult;
                }
            }

            oResult.IsSuccess = true;

            return oResult;
        }

        private void LoadExistingData()
        {
            CCategoryManager oManager = new CCategoryManager();

            CResult oResult = oManager.GetCategory4(m_selectionItemCategoryID);
            CCategory4 objSelectionOfItem = new CCategory4();

            if (oResult.IsSuccess && oResult.Data != null)
            {
                objSelectionOfItem = (CCategory4)oResult.Data;
                txtItemName.Text = objSelectionOfItem.Category4Name;
                txtOrder.Text = objSelectionOfItem.Category4Order.ToString();

                m_selectionItemOrder = objSelectionOfItem.Category4Order;

                txtDescription.Text = objSelectionOfItem.Category4Description;
                txtTablePrice.Text = objSelectionOfItem.Category4TablePrice.ToString("F02");
                txtTakeawayPrice.Text = objSelectionOfItem.Category4TakeAwayPrice.ToString("F02");
                txtBarPrice.Text = objSelectionOfItem.Category4BarPrice.ToString("F02");

                if (objSelectionOfItem.UnlimitStatus >0)
                {
                    chkunlimited.Checked = true;
                    txtInitialQuantity.Clear();
                }
                else
                {
                    txtInitialQuantity.Text = objSelectionOfItem.InitialItemQuantity.ToString();
                }

                m_iRank = objSelectionOfItem.Rank;


                if (objSelectionOfItem.Category4ViewTable == 1)
                {
                    chkTable.Checked = true;
                }
                if (objSelectionOfItem.Category4ViewBar == 1)
                {
                    chkBar.Checked = true;
                }
                if (objSelectionOfItem.Category4ViewTakeAway == 1)
                {
                    chkTakeAway.Checked = true;
                }
            }

            oResult = oManager.GetCategoryAncestors(m_selectionItemCategoryID, 4);


            if (oResult.IsSuccess && oResult.Data != null)
            {
                CCategoryAncestor oCatAnc = (CCategoryAncestor)oResult.Data;

                int tmpCat4ID = oCatAnc.Category4ID;
                int tmpCat3ID = oCatAnc.Category3ID;
                int tmpCat2ID = oCatAnc.Category2ID;
                int tmpCat1ID = oCatAnc.Category1ID;
                int tmpParentCatID = oCatAnc.ParentCategoryID;

                CComboBoxItem oItem1 = new CComboBoxItem(1, "Active");

                CComboBoxItem oItem2 = new CComboBoxItem(0, "InActive");


                if (objSelectionOfItem.Category4OrderStatus == 1)
                {

                    rdoActive.Checked = true;

                }
                else if (objSelectionOfItem.Category4OrderStatus == 0)
                {
                    rdoInactive.Checked = true;

                }
                cmbParent.SelectedValue = tmpParentCatID;
                cmbFoodType.SelectedValue = tmpCat1ID;
                cmbCategory.SelectedValue = tmpCat2ID;
                cmbFoodItem.SelectedValue = tmpCat3ID;
            }
        }

        #endregion

        private void UpdateSelectionItemCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();

            this.LoadExistingData();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                CCategory4 objSelectionofItem = new CCategory4();

                String tempName = txtItemName.Text;
                int tempCat4Order = int.Parse(txtOrder.Text);
                String tempDescription = txtDescription.Text;

                if (!txtTablePrice.Text.Trim().Equals(String.Empty))
                {
                    objSelectionofItem.Category4TablePrice = Double.Parse(txtTablePrice.Text.Trim());
                }

                if (!txtBarPrice.Text.Trim().Equals(String.Empty))
                {
                    objSelectionofItem.Category4BarPrice = Double.Parse(txtBarPrice.Text.Trim());
                }

                if (!txtTakeawayPrice.Text.Trim().Equals(String.Empty))
                {
                    objSelectionofItem.Category4TakeAwayPrice = Double.Parse(txtTakeawayPrice.Text.Trim());
                }

                int tempViewTable = chkTable.Checked == true ? 1 : 0;
                int tempViewBar = chkBar.Checked == true ? 1 : 0;
                int tempViewTW = chkTakeAway.Checked == true ? 1 : 0;



                objSelectionofItem.Category4Name = tempName;

                objSelectionofItem.Category4Order = tempCat4Order;

                objSelectionofItem.Category4Description = tempDescription;

                objSelectionofItem.Category4ViewTable = tempViewTable;

                objSelectionofItem.Category4ViewBar = tempViewBar;

                objSelectionofItem.Category4ViewTakeAway = tempViewTW;

                objSelectionofItem.Category3ID = Int32.Parse(cmbFoodItem.SelectedValue.ToString());

                objSelectionofItem.Category4ID = m_selectionItemCategoryID;

                if (rdoActive.Checked)
                {
                    objSelectionofItem.Category4OrderStatus = 1;
                }
                else
                {
                objSelectionofItem.Category4OrderStatus =0;
                }

                if (chkunlimited.Checked)
                {
                    objSelectionofItem.InitialItemQuantity = 0;
                    objSelectionofItem.UnlimitStatus = 1;
                }
                else
                {
                    objSelectionofItem.InitialItemQuantity = Convert.ToInt32("0"+txtInitialQuantity.Text);
                    objSelectionofItem.UnlimitStatus = 0;
                }

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.UpdateCategory4(objSelectionofItem, m_selectionItemOrder);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = "Item information is updated successfully. ";

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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 categoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            this.FillFoodItem(categoryID);
        }

        private void chkunlimited_CheckedChanged(object sender, EventArgs e)
        {
            if (chkunlimited.Checked)
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
