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
    public partial class MembershipDiscountReport : Form
    {
        public MembershipDiscountReport()
        {
            InitializeComponent();
        }

        private void MembershipDiscountReport_Load(object sender, EventArgs e)
        {
            LoadMembershipDiscount();
        }

        private void LoadMembershipDiscount()
        {
            try
            {
                DataTable reportDataTable = new DataTable();
                MembershipDao aMembershipDao = new MembershipDao();
                reportDataTable = aMembershipDao.GetMembershipDiscountReport();
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

        private void membershipDiscountReportDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = int.Parse(e.RowIndex.ToString());
            if (rowIndex >= 0)
            {
                int memberId =Convert.ToInt32( membershipDiscountReportDataGridView.Rows[rowIndex].Cells["id"].Value);
                
                MembershipDiscountSaleDetails aMembershipDiscountSaleDetails=new MembershipDiscountSaleDetails(memberId);
                aMembershipDiscountSaleDetails.ShowDialog();
            }
        }

        private void nameSearchButton_Click(object sender, EventArgs e)
        {
           
                try
                {
                    membershipDiscountReportDataGridView.DataSource = null;
                    DataTable reportDataTable = new DataTable();
                    MembershipDao aMembershipDao = new MembershipDao();
                    reportDataTable = aMembershipDao.GetMembershipDiscountReport();

                    string name = txtName.Text;

                    if (reportDataTable != null)
                    {
                        DataTable selectedTable = reportDataTable.AsEnumerable()
                            .Where(r => r.Field<string>("Name").Contains(name))
                            .CopyToDataTable();

                        membershipDiscountReportDataGridView.DataSource = selectedTable;
                    }
                }
                catch (Exception)
                {

                }
            

        }

        private void cardSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                membershipDiscountReportDataGridView.DataSource = null;
                DataTable reportDataTable = new DataTable();
                MembershipDao aMembershipDao = new MembershipDao();
                reportDataTable = aMembershipDao.GetMembershipDiscountReport();

                string cardNumber = txtCode.Text;

                if (reportDataTable != null)
                {
                    DataTable selectedTable = reportDataTable.AsEnumerable()
                        .Where(r => r.Field<string>("CardNumber") == cardNumber)
                        .CopyToDataTable();

                    membershipDiscountReportDataGridView.DataSource = selectedTable;
                }
            }
            catch (Exception)
            {

            }
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            LoadMembershipDiscount();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataGridViewReportPrint aDataGridViewReportPrint = new DataGridViewReportPrint();
            aDataGridViewReportPrint.PrintA4Report(membershipDiscountReportDataGridView);
        }
    }
}
