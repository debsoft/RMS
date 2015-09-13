using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS;
using Managers.User;

namespace RMSAdmin
{
    public partial class UpdateReceiptStyle : UserControl
    {
        private int m_styleID = 0;
        public UpdateReceiptStyle(Int32 styleID)
        {
            InitializeComponent();
            m_styleID = styleID;
        }

        private void UpdateReceiptStyle_Load(object sender, EventArgs e)
        {
            CPrintStyle oPrint = new CPrintStyle();

            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            oPrint.StyleID = m_styleID;   
            CUserManager oManager = new CUserManager();

            CResult oResult = oManager.GetPrintStyle(oPrint);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                oPrint = (CPrintStyle)oResult.Data;

                txtHeader.Text = oPrint.Header.Trim();

                txtMessage.Text = oPrint.Body.Trim();

                txtFooter.Text = oPrint.Footer.Trim();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String sTempHeader = txtHeader.Text.Trim();

            String sTempBody = txtMessage.Text.Trim();

            String sTempFooter = txtFooter.Text.Trim();

            CPrintStyle oPrint = new CPrintStyle();

            oPrint.Header = sTempHeader;

            oPrint.Body = sTempBody;

            oPrint.Footer = sTempFooter;

            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            oPrint.StyleID = m_styleID;// oConstant.PrintStyleID;         

            CUserManager oManager = new CUserManager();

            CResult oResult = oManager.UpdatePrintStyle(oPrint);

            if (oResult.IsSuccess)
            {

                lblSaveStatus.Text = " Receipt style is updated successfully.";

                lblSaveStatus.Visible = true;
            }
            else
            {

                lblSaveStatus.Text = " Could not update receipt style. Please try again.";

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
