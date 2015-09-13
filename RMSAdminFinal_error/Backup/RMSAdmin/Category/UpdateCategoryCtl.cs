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
using System.Data.SqlClient;
using RMS;
using RMS.DataAccess;

namespace RMSAdmin
{
    public partial class UpdateCategoryCtl : UserControl
    {
        private Int32 m_categoryID = 0;
        private Int32 m_cattegoryOrder = 0;
        public UpdateCategoryCtl(Int32 categoryID)
        {
            InitializeComponent();
            m_categoryID = categoryID;
        }

        #region "Manupulation Area"


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

                DataView dv = new DataView(table);
                cmbParent.DataSource = dv;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadExistingData()
        {
            CCategoryManager oManager = new CCategoryManager();

            CResult oResult = oManager.GetCategory2(m_categoryID);
            CCategory2 oCat = new CCategory2();

            if (oResult.IsSuccess && oResult.Data != null)
            {
                oCat = (CCategory2)oResult.Data;
                txtCategoryName.Text = oCat.Category2Name;
                txtCatOrder.Text = oCat.Category2Order.ToString();

                m_cattegoryOrder = oCat.Category2Order;

                txtColorName.Text = oCat.Category2Color.ToString();


                if (oCat.Category2ViewTable == 1)
                {
                    chkTable.Checked = true;
                }
                if (oCat.Category2ViewBar == 1)
                {
                    chkBar.Checked = true;
                }
                if (oCat.Category2ViewTakeAway == 1)
                {
                    chkTakeAway.Checked = true;
                }
            }

            oResult = oManager.GetCategoryAncestors(m_categoryID, 2);
            CCategoryAncestor oCatAnc = (CCategoryAncestor)oResult.Data;

            if (oResult.IsSuccess && oResult.Data != null)
            {
                int tmpCat2ID = oCatAnc.Category2ID;
                int tmpCat1ID = oCatAnc.Category1ID;
                int tmpParentCatID = oCatAnc.ParentCategoryID;

                FillParentCategory();
                
                FillFoodType(tmpParentCatID);

                cmbParent.SelectedValue = tmpParentCatID;

                cmbFoodType.SelectedValue = tmpCat1ID;

                CComboBoxItem oItem1 = new CComboBoxItem(1, "Food");

                CComboBoxItem oItem2 = new CComboBoxItem(0, "Non Food");


                cmbCategoryType.Items.Add(oItem1);

                cmbCategoryType.Items.Add(oItem2);

                cmbCategoryType.DisplayMember = "Display";

                cmbCategoryType.ValueMember = "Value";

                if (oCat.Category2Type == 1)
                {

                    cmbCategoryType.SelectedIndex = 0;
                }
                else if (oCat.Category2Type == 0)
                {
                    cmbCategoryType.SelectedIndex = 1;

                }
            }
        }

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            bool bTempFlag = false;

            if (txtCategoryName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = "Please enter category name.";

                return oResult;
            }

            if (txtCatOrder.Text.Equals(String.Empty))
            {
                oResult.Message = " Write order.";

                return oResult;
            }
            else
            {
                int iTempInt;

                bTempFlag = Int32.TryParse(txtCatOrder.Text.Trim(), out iTempInt);

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
                oResult.Message = " Select Category1.";

                return oResult;
            }
            else if (cmbCategoryType.SelectedIndex < 0)
            {
                oResult.Message = " Select Type.";

                return oResult;
            }

            oResult.IsSuccess = true;

            return oResult;
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                String tempName = txtCategoryName.Text;
                int tempCat3Order = int.Parse(txtCatOrder.Text);
                String tempColor = txtColorName.Text.Trim();

                int tempViewTable = chkTable.Checked == true ? 1 : 0;
                int tempViewBar = chkBar.Checked == true ? 1 : 0;
                int tempViewTW = chkTakeAway.Checked == true ? 1 : 0;

                CCategory2 oCat = new CCategory2();

                oCat.Category2Name = tempName;

                oCat.Category2Order = tempCat3Order;

                oCat.Category2Color = tempColor;

                oCat.Category1ID = Int32.Parse(cmbFoodType.SelectedValue.ToString());

                oCat.Category2ID = m_categoryID;

                oCat.Category2ViewTable = tempViewTable;

                oCat.Category2ViewBar = tempViewBar;

                oCat.Category2ViewTakeAway = tempViewTW;

                oCat.Category2Type = ((CComboBoxItem)cmbCategoryType.SelectedItem).Value;


                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.UpdateCategory2(oCat, m_cattegoryOrder);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = "Category2 information is updated successfully. ";

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

        private void UpdateCategoryCtl_Load(object sender, EventArgs e)
        {
            LoadExistingData();
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

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                String redColor = clrDlg.Color.R.ToString("X");
                if (redColor.Length == 1)
                {
                    redColor = "0" + redColor;
                }

                String greenColor = clrDlg.Color.G.ToString("X");
                if (greenColor.Length == 1)
                {
                    greenColor = "0" + greenColor;
                }

                String blueColor = clrDlg.Color.B.ToString("X");
                if (blueColor.Length == 1)
                {
                    blueColor = "0" + blueColor;
                }

                String bgColorName = "#" + redColor + greenColor + blueColor;

                txtColorName.Text = bgColorName;
            }
        }
    }
}
