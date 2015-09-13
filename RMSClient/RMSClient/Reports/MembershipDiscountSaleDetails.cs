using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMSClient.DataAccess;

namespace RMS.Reports
{
    public partial class MembershipDiscountSaleDetails : Form
    {
        private int memberid = 0;
        public MembershipDiscountSaleDetails(int id)
        {
            InitializeComponent();
            memberid = id;
        }

        private void MembershipDiscountSaleDetails_Load(object sender, EventArgs e)
        {
            LoadMemberDetailsReport();
        }

        private void LoadMemberDetailsReport()
        {
            try
            {
                DataTable reportDataTable = new DataTable();
                MembershipDao aMembershipDao = new MembershipDao();
                reportDataTable = aMembershipDao.LoadMemberDetailsReport(memberid);
                membershipDiscountReportDataGridView.DataSource = reportDataTable;
            }
            catch (Exception)
            {

            }
        }

        private void membershipDiscountReportDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dataGridViewColumn = membershipDiscountReportDataGridView.Columns["id"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataGridViewReportPrint aDataGridViewReportPrint = new DataGridViewReportPrint();
            aDataGridViewReportPrint.PrintA4ReportForLandscape(membershipDiscountReportDataGridView,"",0);
        }
    }
}
