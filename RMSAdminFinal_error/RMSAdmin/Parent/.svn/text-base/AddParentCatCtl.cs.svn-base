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
