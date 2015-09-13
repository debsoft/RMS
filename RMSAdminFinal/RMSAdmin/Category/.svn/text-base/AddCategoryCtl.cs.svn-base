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
    public partial class AddCategoryCtl : UserControl
    {
        private string m_sParentCategoryText = String.Empty;
        private string m_sFoodTypeText = String.Empty;

        public AddCategoryCtl()
        {
            InitializeComponent();
        }

        public AddCategoryCtl(string inPCatText, string inFoodTypeText)
        {
            InitializeComponent();
            m_sParentCategoryText = inPCatText;
            m_sFoodTypeText = inFoodTypeText;
        }

        #region "Manupulation Area"
        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            if (cmbParent.SelectedValue == null)
            {
                oResult.Message = " Select Parent category.";

                return oResult;
            }
            else if (cmbFoodType.SelectedValue == null)
            {
                oResult.Message = "Please select Food Type.";

                return oResult;
            }

            else if (cmbCategoryType.SelectedIndex < 0)
            {
                oResult.Message = "Please select category type.";

                return oResult;
            }

            if (txtCategoryName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = "Please enter category name.";

                return oResult;
            }

            oResult.IsSuccess = true;

            return oResult;
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
                cmbParent.Text = m_sParentCategoryText;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult oValidResult = ValidateForm();

            if (oValidResult.IsSuccess)
            {
                CCategory2 oTempCat = new CCategory2();

                oTempCat.Category1ID = Int32.Parse(cmbFoodType.SelectedValue.ToString());

                oTempCat.Category2Type = Int32.Parse(((CComboBoxItem)cmbCategoryType.SelectedItem).Value.ToString());

                oTempCat.Category2Name = txtCategoryName.Text.Trim();

                oTempCat.Category2Color = txtColorName.Text.Trim();


                if (chkTable.Checked)
                {
                    oTempCat.Category2ViewTable = 1;
                }

                if (chkTakeAway.Checked)
                {
                    oTempCat.Category2ViewBar = 1;
                }

                if (chkBar.Checked)
                {
                    oTempCat.Category2ViewTakeAway = 1;
                }


                CCategoryManager oManager = new CCategoryManager();
                CResult oResult = oManager.AddCategory2(oTempCat);

                if (oResult.IsSuccess)
                {
                    lblSaveStatus.Text = "Category has been saved successfully.";
                    lblSaveStatus.Visible = true;
                }
                else
                {
                    lblSaveStatus.Text = oResult.Message;
                    lblSaveStatus.Visible = true;
                }
            }
            else
            {
                lblSaveStatus.Text = oValidResult.Message;
                lblSaveStatus.Visible = true;
            }
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
            cmbFoodType.SelectedIndex = -1;
            cmbParent.SelectedIndex = -1;
            cmbCategoryType.SelectedIndex = -1;
            txtCategoryName.Clear();
            txtColorName.Clear();
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

        private void cmbCategoryType_DropDown(object sender, EventArgs e)
        {
            CComboBoxItem oItem1 = new CComboBoxItem(1, "Food");

            CComboBoxItem oItem2 = new CComboBoxItem(0, "Non Food");

            oItem2.Display = "Non Food";

            oItem2.Value = 0;

            cmbCategoryType.Items.Clear();

            cmbCategoryType.Items.Add(oItem1);

            cmbCategoryType.Items.Add(oItem2);

            cmbCategoryType.DisplayMember = "Display";

            cmbCategoryType.ValueMember = "Value";
        }

        private void AddCategoryCtl_Load(object sender, EventArgs e)
        {
            FillParentCategory();
        }

        private void cmbParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 parentId = Convert.ToInt32(cmbParent.SelectedValue);
            FillFoodType(parentId);
        }
    }
}
