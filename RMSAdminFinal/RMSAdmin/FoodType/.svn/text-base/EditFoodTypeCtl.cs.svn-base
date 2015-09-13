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
    public partial class EditFoodTypeCtl : UserControl
    {
        public EditFoodTypeCtl(Int32 foodTypeID,string foodTypeName)
        {
            InitializeComponent();
            txtFoodType.Text = foodTypeName;
            txtFoodType.Tag = foodTypeID;
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
                //cmbParentCategory.Text = "All";
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message +". Error Occured. Please contact to your administrator.");
            }
        }

        private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            if (txtFoodType.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = " Write name.";

                return oResult;
            }


            if (cmbParentCategory.SelectedValue == null)
            {
                oResult.Message = " Select Parent Category.";

                return oResult;
            }

            oResult.IsSuccess = true;

            return oResult;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                CCategory1 objFoodType = new CCategory1();

                objFoodType.Category1Name = txtFoodType.Text.Trim();

                //oCat.Category1Order = Int32.Parse(textBox2.Text.Trim());

                objFoodType.ParentCatID = Int32.Parse(cmbParentCategory.SelectedValue.ToString());

                objFoodType.Category1ID = Convert.ToInt32("0"+txtFoodType.Tag);

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.UpdateCategory1(objFoodType);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = "Food type has been updated successfully.";

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

        private void EditFoodTypeCtl_Load(object sender, EventArgs e)
        {
            FillParentCategory();
        }
    }
}
