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
using RMS.DataAccess;
using RMS.Common.Config;
using RMS;
using System.Data.SqlClient;

namespace RMSAdmin
{
    public partial class AddParentCatCtl : UserControl
    {
        public AddParentCatCtl()
        {
            InitializeComponent();
        }

       #region "Manupulation Area"

         private CResult ValidateForm()
        {
            CResult oResult = new CResult();

            if (txtParentCategoryName.Text.Trim().Equals(String.Empty))
            {
                oResult.Message = "Write name.";

                return oResult;
            }
            oResult.IsSuccess = true;

            return oResult;
        }
      #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            //To Get parent catagory Order Number


            String queryStr = SqlQueries.GetQuery(Query.GetMaxParentCategoryNumber);
            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
            String tempConnStr = oTempDal.ConnectionString;
            // Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);
            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);

            int lastMaxParentValue = Convert.ToInt32(table.Rows[0]["Column1"].ToString());

            CResult oValidResult = ValidateForm();

            if (oValidResult.IsSuccess)
            {
                String sTempStr = txtParentCategoryName.Text.Trim();

                if (sTempStr.Equals(String.Empty))
                {
                    lblSaveStatus.Text = " Write the name of the category.";

                    lblSaveStatus.Visible = true;
                }
                else
                {
                    CParentCategory oTempParent = new CParentCategory();

                    oTempParent.ParentCatName = sTempStr;
                    oTempParent.ParentCatID = lastMaxParentValue+1;

                    CCategoryManager oManager = new CCategoryManager();

                    CResult oResult = oManager.AddParentCat(oTempParent);

                    if (oResult.IsSuccess)
                    {
                        lblSaveStatus.Text = " Parent category has been added successfully.";

                        lblSaveStatus.Visible = true;
                    }
                    else
                    {
                        lblSaveStatus.Text = oResult.Message;

                        lblSaveStatus.Visible = true;
                    }
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
