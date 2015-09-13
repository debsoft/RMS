using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.Common
{
    public partial class PayBackComfirmForm : Form
    {
        public static string m_PaybackStatus = String.Empty;
        public static string m_cancelStatus = "";
        public PayBackComfirmForm()
        {
            InitializeComponent();
            m_cancelStatus = "";
        }

        private void btnPayBack_Click(object sender, EventArgs e)
        {
            m_PaybackStatus = "Payback";
            this.Hide();
        }

        private void btnAddServiceCharge_Click(object sender, EventArgs e)
        {
            m_PaybackStatus = "Add to Service Charge";
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_cancelStatus = "Cancel";
            this.Hide();
        }
    }
}
