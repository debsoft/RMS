using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.ReportForms
{
    public partial class StockReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public StockReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            this.Read();  
        }
        public void Read()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbProductName ORDER BY ProductName", conn);

            SqlDataAdapter adap = new SqlDataAdapter();
            DataSets.StockDataSet dataset = new DataSets.StockDataSet();
            StockCrystalReport crp = new StockCrystalReport();

            try
            {
                conn.Open();
                adap.SelectCommand = comm;
                adap.Fill(dataset, "DataTable1");
                crp.SetDataSource(dataset);
                crystalReportViewer2.ReportSource = crp;
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
