using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMS.SystemManagement
{
    public partial class ReasonForm : Form
    {
        public string reason = "";

        public ReasonForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            reason = reasontextBox.Text;
            this.Close();

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            reason = "";
            this.Close();
        }
    }
}
