using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RMS.TableOrder
{
    public partial class KitchenReportForm : Form
    {
        public KitchenReportForm()
        {
            InitializeComponent();
        }

        private void KitchenReportForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}