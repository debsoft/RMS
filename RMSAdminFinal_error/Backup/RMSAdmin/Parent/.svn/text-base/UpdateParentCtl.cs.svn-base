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
    public partial class UpdateParentCtl : UserControl
    {
        private int m_iParentCat = 0;
        private string m_parentCatName = "";

        public UpdateParentCtl(Int32 p_categoryId,string p_catName)
        {
            InitializeComponent();
            m_iParentCat = p_categoryId;
            m_parentCatName = p_catName;
        }

        #region "Manupulation Area"

        private CResult ValidateForm()
        {
            CResult objResult = new CResult();

            if (txtParentCategoryName.Text.Trim().Equals(String.Empty))
            {
                objResult.Message = " Write name.";

                return objResult;
            }
            objResult.IsSuccess = true;

            return objResult;
        }
        #endregion


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CResult oResult = ValidateForm();

            if (oResult.IsSuccess)
            {
                CParentCategory objParentCat = new CParentCategory();

                objParentCat.ParentCatName = txtParentCategoryName.Text.Trim();

                objParentCat.ParentCatID = m_iParentCat;

                CCategoryManager oManager = new CCategoryManager();

                CResult oResult2 = oManager.UpdateParentCat(objParentCat);

                if (oResult2.IsSuccess)
                {
                    lblSaveStatus.Text = "Parent category information has been updated successfully. ";

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

        private void UpdateParentCtl_Load(object sender, EventArgs e)
        {
            txtParentCategoryName.Text = m_parentCatName;
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
