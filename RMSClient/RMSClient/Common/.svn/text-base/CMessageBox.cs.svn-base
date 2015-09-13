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
    public partial class CMessageBox : Form
    {
        public CMessageBox()
        {
            InitializeComponent();
        }

        public CMessageBox(String inTitle,String inBody)
        {
            InitializeComponent();
            this.Text = inTitle;
            this.g_MessageTextBox.Text = inBody;
        }

        private void g_OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}