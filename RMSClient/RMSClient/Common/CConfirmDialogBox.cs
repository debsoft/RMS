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
    public partial class CConfirmDialogBox : Form
    {
        public static string DialogResult="No";

        public CConfirmDialogBox()
        {
            InitializeComponent();
        }

        public CConfirmDialogBox(String inTitle, String inBody)
        {
            InitializeComponent();
            this.Text = inTitle;
            this.g_MessageLabel.Text = inBody;
        }

        private void g_YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = "Yes";
            this.Close();
        }

        private void g_NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = "No";
            this.Close();
        }
       
    }
}