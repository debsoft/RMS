using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMSClient.DataAccess;

namespace RMS.SystemManagement
{
    public partial class CashForm :UserControl
    {
        public CashForm()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
              try
            {
            BankTransactionDAO aBankTransactionDao = new BankTransactionDAO();
            BankTransaction aTransaction = new BankTransaction();
            aTransaction.BankName = banknametextBox.Text;
            aTransaction.DepositeDate = debitdateTimePicker.Value.ToShortDateString();
            aTransaction.DepositePerson = depositepersontextBox.Text;
            aTransaction.DepositeAmount = Convert.ToDouble("0" + amounttextBox.Text);
            string sr = aBankTransactionDao.InsertCashTransaction(aTransaction);
            MessageBox.Show(sr);

            }
              catch (Exception)
              {
                  MessageBox.Show("Please Check input field");

              }
        }
    }
}
