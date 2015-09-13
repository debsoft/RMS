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
    public partial class Bank_Transaction : Form
    {
        public Bank_Transaction()
        {
            InitializeComponent();
        }

        private void debitbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            Debit_Form aForm=new Debit_Form();
            contentpanel.Controls.Add(aForm);


        }

        private void creditbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            CreditForm aForm=new CreditForm();
            contentpanel.Controls.Add(aForm);
        }

        private void othercreditbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
           OtherCreditForm aForm=new OtherCreditForm();
            contentpanel.Controls.Add(aForm);
        }

        private void debitreportbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            DebitReport aForm = new DebitReport();
            contentpanel.Controls.Add(aForm);
        }

        private void creditreportbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            CreditReport aForm = new CreditReport();
            contentpanel.Controls.Add(aForm);
        }

        private void otherDrbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            OtherDebitReport aForm = new OtherDebitReport();
            contentpanel.Controls.Add(aForm);
        }

        private void balancebutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            DailyBalanceReport aForm = new DailyBalanceReport();
            contentpanel.Controls.Add(aForm);
        }

        private void cashbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            CashForm aForm = new CashForm();
            contentpanel.Controls.Add(aForm);
        }

        private void cashreportbutton_Click(object sender, EventArgs e)
        {
            contentpanel.Controls.Clear();
            CashReport aForm = new CashReport();
            contentpanel.Controls.Add(aForm);
        }
    }
}
