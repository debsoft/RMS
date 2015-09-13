using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.TableOrder
{
    public partial class KitchenPrintForm : Form
    {
        public static Int32 m_PrintingItems = 0;
        public KitchenPrintForm()
        {
            InitializeComponent();
            m_PrintingItems = 0;
        }

        private void btnSendNew_Click(object sender, EventArgs e)
        {
            m_PrintingItems = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            m_PrintingItems = 1;
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
