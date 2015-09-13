using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RMS.Common.ObjectModel;
//using ProductCommon.ObjectModel;
//using ProductManagers.Category;
//using ProductDatabase.Queries;
//using ProductCommon.Config;
//using ProductConfigService;


namespace RMS.StockManagement
{
    public partial class UpdateFoodItemCtl : UserControl
    {
        private Int32 m_foodItemID = 0;
        private int m_iCat3Order = 0;
        private Int64 m_iRank = 0;
        private static bool m_activeStatus = false;

        public UpdateFoodItemCtl(Int32 itemID)
        {
            InitializeComponent();
            m_foodItemID = itemID;
        }

        #region "Manupulation Area"

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            bool bTempFlag = false;

            if (txtProductName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = "Please product name.";

                return oResult;
            }

            if (txtBarCode.Text.Equals(String.Empty))
            {
                oResult.Message = " Write order.";

                return oResult;
            }
            else
            {
                int iTempInt;

                bTempFlag = Int32.TryParse(txtBarCode.Text.Trim(), out iTempInt);

                if (bTempFlag)
                {
                }
                else
                {
                    oResult.Message = " Write order, only numbers are allowed.";

                    return oResult;
                }
            }

            if (cmbParent.SelectedValue == null)
            {
                oResult.Message = " Select Parent Category.";

                return oResult;
            }
            else if (cmbFoodType.SelectedValue == null)
            {
                oResult.Message = "Please select food item";

                return oResult;
            }
            else if (cmbCategory.SelectedValue == null)
            {
                oResult.Message = "Please select category.";

                return oResult;
            }

            if (rdoActive.Checked ==false && rdoInActive.Checked==false)
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
                    oResult.Message = "Write table price, only numbers are allowed.";

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

        private void LoadExistingData()
        {
            //CCategoryManager oManager = new CCategoryManager();

            //CResult oResult = oManager.GetCategory3(m_foodItemID);
            //CCategory3 objFoodItem = new CCategory3();

            //if (oResult.IsSuccess && oResult.Data != null)
            //{
            //    objFoodItem = (CCategory3)oResult.Data;
            //    txtProductName.Text = objFoodItem.Category3Name;
            //    txtBarCode.Text = objFoodItem.Category3Order.ToString();

            //    m_iCat3Order = objFoodItem.Category3Order;

            //    txtDescription.Text = objFoodItem.Category3Description;
            //    txtTablePrice.Text = objFoodItem.Category3TablePrice.ToString("F02");
            //    txtTakeawayPrice.Text = objFoodItem.Category3TakeAwayPrice.ToString("F02");
            //    txtBarPrice.Text = objFoodItem.Category3BarPrice.ToString("F02");
            //    cmbSellingIn.Text = objFoodItem.ItemSellingIn;

            //    if (objFoodItem.UnlimitStatus==1)
            //    {
            //        txtInitialQuantity.Clear();
            //        chkUnlimited.Checked = true;
            //    }
            //    else
            //    {
            //        txtInitialQuantity.Text = objFoodItem.InitialItemQuantity.ToString();
            //    }

            //    m_iRank = objFoodItem.Rank;

            //    if (objFoodItem.Category3ViewTable == 1) chkTable.Checked = true;
            //    if (objFoodItem.Category3ViewBar == 1) chkBar.Checked = true;
            //    if (objFoodItem.Category3ViewTakeAway == 1) chkTakeAway.Checked = true;

            //}

            //oResult = oManager.GetCategoryAncestors(m_foodItemID, 3);
            //CCategoryAncestor oCatAnc = (CCategoryAncestor)oResult.Data;

            //if (oResult.IsSuccess && oResult.Data != null)
            //{
            //    int tmpCat3ID = oCatAnc.Category3ID;
            //    int tmpCat2ID = oCatAnc.Category2ID;
            //    int tmpCat1ID = oCatAnc.Category1ID;
            //    int tmpParentCatID = oCatAnc.ParentCategoryID;

               
            //    if (objFoodItem.Category3OrderStatus == 1)
            //    {
            //        m_activeStatus = true;
            //        rdoActive.Checked = true;
            //    }
            //    else if (objFoodItem.Category3OrderStatus == 0)
            //    {
            //        rdoInActive.Checked = true;
            //        m_activeStatus = false;
            //    }

            //    cmbParent.SelectedValue = tmpParentCatID;
            //    cmbFoodType.SelectedValue = tmpCat1ID;
            //    cmbCategory.SelectedValue = tmpCat2ID;

            //}
        }


        private void FillParentCategory()
        {
            try
            {
                //String sqlCommand = SqlQueries.GetQuery(Query.ViewParentCategory);

                //CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                //String tempConnStr = oTempDal.ConnectionString;

                //// Create a new data adapter based on the specified query.
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                //// Create a command builder to generate SQL update, insert, and
                //// delete commands based on selectCommand. These are used to
                //// update the database.
                //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                //// Populate a new data table and bind it to the BindingSource.
                //DataTable table = new DataTable();
                //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //dataAdapter.Fill(table);
                //cmbParent.DataSource = table;
                //dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+". Error Occured. Please contact to your administrator.");
            }
        }

        private void FillFoodType(Int32 parentId)
        {
            //if (cmbParent.SelectedIndex < 0)
            //{
            //    return;

            //}
            //String sqlCommand = "";

            //if (parentId == 0)
            //{
            //    sqlCommand = SqlQueries.GetQuery(Query.ViewCategory1);
            //}
            //else
            //{
            //    sqlCommand = String.Format(SqlQueries.GetQuery(Query.ViewCat1ComboBox), parentId);
            //}


            //CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            //String tempConnStr = oTempDal.ConnectionString;

            //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

            //// Create a command builder to generate SQL update, insert, and
            //// delete commands based on selectCommand. These are used to
            //// update the database.
            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            //// Populate a new data table and bind it to the BindingSource.
            //DataTable table = new DataTable();
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //dataAdapter.Fill(table);

            //cmbFoodType.DataSource = table;

            //dataAdapter.Dispose();
        }

        private void FillFoodCategory(Int32 foodTypeID)
        {
            if (cmbFoodType.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                //if (cmbFoodType.SelectedValue != null)
                //{
                //    String sqlCommand = SqlQueries.GetQuery(Query.ViewCategory2ByCat1);

                //    sqlCommand = String.Format(sqlCommand, foodTypeID);

                //    CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                //    String tempConnStr = oTempDal.ConnectionString;


                //    // Create a new data adapter based on the specified query.
                //    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                //    // Create a command builder to generate SQL update, insert, and
                //    // delete commands based on selectCommand. These are used to
                //    // update the database.
                //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                //    // Populate a new data table and bind it to the BindingSource.
                //    DataTable table = new DataTable();
                //    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //    dataAdapter.Fill(table);
                //    cmbCategory.DataSource = table;
                //    dataAdapter.Dispose();
                //}
            }
        }

        #endregion


        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentId = Convert.ToInt32(cmbParent.SelectedValue);
            FillFoodType(parentId);
        }

        private void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 foodTypeID = Convert.ToInt32(cmbFoodType.SelectedValue);
            FillFoodCategory(foodTypeID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //CResult oResult = ValidateForm();

            //if (oResult.IsSuccess)
            //{
            //    CCategory3 objFoodItem = new CCategory3();
            //    String tempName = txtProductName.Text;
            //    int tempCat3Order = int.Parse(txtBarCode.Text);
            //    String tempDescription = txtDescription.Text;

            //    if (!txtTablePrice.Text.Trim().Equals(String.Empty))
            //    {
            //        objFoodItem.Category3TablePrice = Double.Parse(txtTablePrice.Text.Trim());
            //    }

            //    if (!txtBarPrice.Text.Trim().Equals(String.Empty))
            //    {
            //        objFoodItem.Category3BarPrice = Double.Parse(txtBarPrice.Text.Trim());
            //    }

            //    if (!txtTakeawayPrice.Text.Trim().Equals(String.Empty))
            //    {
            //        objFoodItem.Category3TakeAwayPrice = Double.Parse(txtTakeawayPrice.Text.Trim());
            //    }
               

            //    int tempViewTable = chkTable.Checked == true ? 1 : 0;
            //    int tempViewBar = chkBar.Checked == true ? 1 : 0;
            //    int tempViewTW = chkTakeAway.Checked == true ? 1 : 0;


            //    objFoodItem.Category3Name = tempName;

            //    objFoodItem.Category3Order = tempCat3Order;

            //    objFoodItem.Category3Description = tempDescription;

            //    objFoodItem.Category3ViewTable = tempViewTable;

            //    objFoodItem.Category3ViewBar = tempViewBar;

            //    objFoodItem.Category3ViewTakeAway = tempViewTW;

            //    objFoodItem.Category3ID = m_foodItemID;

            //    if (chkUnlimited.Checked)
            //    {
            //        objFoodItem.InitialItemQuantity =0;
            //        objFoodItem.UnlimitStatus = 1;
            //    }
            //    else
            //    {
            //        objFoodItem.InitialItemQuantity = Convert.ToInt32("0" + txtInitialQuantity.Text);
            //        objFoodItem.UnlimitStatus = 0;
            //    }
            //    objFoodItem.ItemSellingIn = cmbSellingIn.Text;

            //    objFoodItem.Category2ID = Int32.Parse(cmbCategory.SelectedValue.ToString());

            //    if (m_activeStatus==true)
            //    {
            //        objFoodItem.Category3OrderStatus = 1;
            //    }
            //    else if (m_activeStatus)
            //    {
            //        objFoodItem.Category3OrderStatus = 0;
            //    }

            //    CCategoryManager oManager = new CCategoryManager();

            //    CResult oResult2 = oManager.UpdateCategory3(objFoodItem, m_iCat3Order);

            //    if (oResult2.IsSuccess)
            //    {
            //        lblSaveStatus.Text = "Food item has been updated successfully. ";

            //        lblSaveStatus.Visible = true;
            //    }
            //    else
            //    {
            //        lblSaveStatus.Text = oResult2.Message;

            //        lblSaveStatus.Visible = true;
            //    }
            //}
            //else
            //{
            //    lblSaveStatus.Text = oResult.Message;

            //    lblSaveStatus.Visible = true;
            //}
        }

        private void UpdateFoodItemCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
            this.LoadExistingData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
             //   UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
              //  pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
              //  UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
               // pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActive.Checked == true)
            {
                m_activeStatus = true;
            }
            else
            {
                m_activeStatus = false;
            }
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
