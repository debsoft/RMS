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

namespace RMS
{
    public partial class DebitReport :UserControl
    {
        BankTransactionDAO aBankTransactionDao = new BankTransactionDAO();
        public DebitReport()
        {
            InitializeComponent();
        }

        private void showbutton_Click(object sender, EventArgs e)
        {
            DateTime fromtime =fromdateTimePicker.Value.Date;
            DateTime totime = todateTimePicker.Value.Date;
           CResult aResult=new CResult();
           aResult = aBankTransactionDao.GetDebitreportBydate(fromtime , totime);
            DataTable aTable=new DataTable();
            try
            {
                aTable = (DataTable)aResult.Data;
                debitdataGridView.DataSource = aTable;
                amountlabel.Text = aResult.Amount.ToString("F02");

            }
            catch (Exception)
            {
            }
            

        }
    }
}
