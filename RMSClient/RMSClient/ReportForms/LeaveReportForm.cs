using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.AnotherReport;
using RMS.Common;
using RMS.DataSets;

namespace RMS.ReportForms
{
    public partial class LeaveReportForm : Form
    {

        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public LeaveReportForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void LeaveReportForm_Load(object sender, EventArgs e)
        {
            LoadLeaveReport();

        }

        private void LoadLeaveReport()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM LeaveForm ORDER BY LeaveFrom DESC", conn);



            SqlDataAdapter adap = new SqlDataAdapter();
            LeaveReportDataSet dataset = new LeaveReportDataSet();
            LeaveCrystalReport crp = new LeaveCrystalReport();

            try
            {
                conn.Open();
                adap.SelectCommand = comm;
                adap.Fill(dataset, "DataTable1");
                crp.SetDataSource(dataset);
                crystalReportViewer1.ReportSource = crp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
