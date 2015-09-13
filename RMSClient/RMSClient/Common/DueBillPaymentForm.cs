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
    public partial class DueBillPaymentForm : Form
    {
        public static string inputResult = "";
        public DueBillPaymentForm()
        {
            InitializeComponent();
            g_InputTextBox.Text = Program.currency + "0.00";
            currencyKeyPad1.CurrencySign = Program.currency;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            inputResult = "Cancel";
            this.Close();
        }

        private void enterbutton_Click(object sender, EventArgs e)
        {
            inputResult = g_InputTextBox.Text;
            this.Close();
        }
    }
}
