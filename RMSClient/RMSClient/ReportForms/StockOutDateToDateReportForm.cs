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
    public partial class StockOutDateToDateReportForm : Form
    {
        private CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public StockOutDateToDateReportForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string query = "";

            query =
                String.Format(
                    "Select * From TbAfterManufactureStockOut Where  StockOutDate >='{0}' AND StockOutDate < '{1}'",
                    fromDateTimePicker.Value.Date, toDateTimePicker.Value.Date.AddDays(1));
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);



                SqlDataAdapter adap = new SqlDataAdapter();
                StockOutDataSet dataset = new StockOutDataSet();
                DateToDateStockOutCrystalReport crp = new DateToDateStockOutCrystalReport();

                try
                {
                    conn.Open();
                    adap.SelectCommand = comm;
                    adap.Fill(dataset, "DataTable1");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
                crp.SetDataSource(dataset);
                crystalReportViewer1.ReportSource = crp;
            }
        }
    }
}