﻿using System;
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
    public partial class Debit_Form : UserControl
    {
        List<double> amount = new List<double>();
        public Debit_Form()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            try
            {

           
            BankTransactionDAO aBankTransactionDao = new BankTransactionDAO();
            amount = new List<double>();
            amount = aBankTransactionDao.GetNowBankbalance(debitdateTimePicker.Value);
            double cashamount = 0;
            if (amount.Count >= 1)
            {
                cashamount = amount[0];
            }
           List<double> amount1 = new List<double>();
            amount1 = aBankTransactionDao.GetNowBankbalance(DateTime.Now);
            double cashamount1 = 0;
            if (amount1.Count >= 1)
            {
                cashamount1 = amount[0];
            }


            BankTransaction aTransaction=new BankTransaction();
            if (cashamount >= Convert.ToDouble("0" + amounttextBox.Text) && (Convert.ToDouble("0" + amounttextBox.Text) != 0)
                && (cashamount1 >= Convert.ToDouble("0" + amounttextBox.Text)))
            {
                aTransaction.BankName = banknametextBox.Text;
                aTransaction.BranchName = branchnametextBox.Text;
                aTransaction.AcoountNumber = accountnumbertextBox.Text;
                aTransaction.DepositeDate = debitdateTimePicker.Value.ToShortDateString();
                aTransaction.DepositePerson = depositepersontextBox.Text;
                aTransaction.DepositeAmount = Convert.ToDouble("0" + amounttextBox.Text);
                string sr = aBankTransactionDao.InsertDebitTransaction(aTransaction);
                MessageBox.Show(sr);
            }
            else
            {
                MessageBox.Show("There is insufficient Balance");
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check input field");
               
            }
        }
    }
}