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
using RMS;
using System.Data.SqlClient;
using RMS.Common.ObjectModel;
using Managers.Category;

namespace RMSAdmin
{
    public partial class AddFoodTypeCtl : UserControl
    {
        private string m_selectedParent = String.Empty;
        
        public AddFoodTypeCtl()
        {
            InitializeComponent();
        }

        public AddFoodTypeCtl(string categoryName)
        {
            InitializeComponent();
            m_selectedParent = categoryName;
        }

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            if (cmbParentCategory.SelectedValue == null)
            {
                oResult.Message = " Select Parent Category.";

                return oResult;
            }

            if (txtFoodType.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = " Write name.";

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
                //table.Rows.Add(new object[]{"0","All","",""});
                cmbParentCategory.DataSource = table;
                cmbParentCategory.Text = m_selectedParent;
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message+ ". Error Occured. Please contact to your administrator.");
            }
        }

        private void AddFoodTypeCtl_Load(object sender, EventArgs e)
        {
            this.FillParentCategory();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CResult oValidResult = ValidateForm();

            if (oValidResult.IsSuccess)
            {

                int iTempCat = Int32.Parse(cmbParentCategory.SelectedValue.ToString());

                String sTempStr = txtFoodType.Text.Trim();

                CCategory1 objCategory = new CCategory1();
                objCategory.CurrentUserId = RMSGlobal.LogInUserName;
                objCategory.LoginDateTime = RMSGlobal.GetCurrentDateTime();


                objCategory.Category1Name = sTempStr;

                objCategory.ParentCatID = iTempCat;

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult = oManager.AddCategory1(objCategory);

                if (oResult.IsSuccess)
                {
                    lblSaveStatus.Text = "Category1 has been saved successfully.";
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
    }
}
