using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.SystemManagement;
using Managers.TableInfo;
using RMSUI;

namespace RMS.TableOrder
{
    public partial class PLUPopup : Form
    {
        public static string m_productCode = String.Empty;

        public PLUPopup()
        {
            InitializeComponent();
            m_productCode = "";
        }

        private void orderkeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            txtProductID.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            m_productCode = txtProductID.Text;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            m_productCode = "Cancel";
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
        }
    }
}
