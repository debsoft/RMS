using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.Category;
using RMS.Common.ObjectModel;
using System.Text.RegularExpressions;

namespace RMSAdmin
{
    public partial class AddProductPluCtl : UserControl
    {
        public AddProductPluCtl(string productID,string productName)
        {
            InitializeComponent();

            txtProductName.Tag = productID;
            txtProductName.Text = productName;
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
            string[] productInfo = txtProductName.Tag.ToString().Split('-');

            int productID = Convert.ToInt32(productInfo[0].ToString());
            int productLabel = Convert.ToInt32(productInfo[1].ToString());
            int pluNumber = Convert.ToInt32("0"+txtPlu.Text.Trim());

            CCategoryManager oManager = new CCategoryManager();

            CResult oResult = oManager.SaveProductPLU(productID, productLabel, pluNumber);

            if (Convert.ToInt32(oResult.Data) > -1)
            {
                lblSaveStatus.Text = "This PLU is already existed.";
                lblSaveStatus.ForeColor = Color.White;
                lblSaveStatus.Visible = true;
            }
            else
            {
                lblSaveStatus.Text = "This PLU has been saved successfully.";
                lblSaveStatus.Visible = true;
                lblSaveStatus.ForeColor = Color.White;
            }
        }

        private void txtPlu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check input data only int value
            Regex rxNumber = new Regex("^[0-9]*$");
            if ((e.KeyChar.ToString()!="\b") && (!rxNumber.IsMatch(e.KeyChar.ToString())))
            {
                lelPLUCheck.Visible = true;
                e.Handled = true;
            }
            else
            {
                lelPLUCheck.Visible = false;
            }
        }
    }
}
