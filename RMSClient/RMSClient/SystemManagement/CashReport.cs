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
    public partial class CashReport : UserControl
    {
        BankTransactionDAO aBankTransactionDao = new BankTransactionDAO();
        public CashReport()
        {
            InitializeComponent();
        }

        private void showbutton_Click(object sender, EventArgs e)
        {
            DateTime fromDateTime= fromdateTimePicker.Value;
            DateTime toDateTime = todateTimePicker.Value;
            CResult aResult = new CResult();
            aResult = aBankTransactionDao.GetCashreportBydate(fromDateTime, toDateTime);
            DataTable aTable = new DataTable();
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
