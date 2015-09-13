using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Main;
using RMS.Common;
using RMSUI;

namespace RMS.TakeAway
{
    public partial class CTakeAwayTypeForm : Form
    {
        CMainForm m_mainForm=null;

        public CTakeAwayTypeForm(CMainForm objMainForm)
        {
            InitializeComponent();
            m_mainForm = objMainForm;
        }

        private void btnDeliveryType_Click(object sender, EventArgs e)
        {
            CTakeAwayForm tempTakeAwayForm = new CTakeAwayForm(1); //1 for delivery type orders
            tempTakeAwayForm.Show();
            CFormManager.Forms.Push(m_mainForm);
            this.Hide();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            CTakeAwayForm tempTakeAwayForm = new CTakeAwayForm(2); //2 for collection type orders
            tempTakeAwayForm.Show();
            CFormManager.Forms.Push(m_mainForm);
            this.Hide();
        }

        private void btnWaiting_Click(object sender, EventArgs e)
        {
            CTakeAwayForm tempTakeAwayForm = new CTakeAwayForm(3); //3 for waiting type orders
            tempTakeAwayForm.Show();
            CFormManager.Forms.Push(m_mainForm);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
