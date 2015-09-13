using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class PaymentMethod : Form
    {
        public static string inputResult = "";
        public PaymentMethod()
        {
            InitializeComponent();
        }

        private void cashButton_Click(object sender, EventArgs e)
        {
            inputResult = "Cash";
            this.Close();
        }

        private void eftButton_Click(object sender, EventArgs e)
        {
            inputResult = "Card";
            this.Close();
        }

        private void chequefunctionalButton_Click(object sender, EventArgs e)
        {
            inputResult = "Cheque";
            this.Close();
        }
    }
}
