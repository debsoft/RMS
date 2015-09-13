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
    public partial class StockOutInvoiceReport : Form
    {
        private CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;

        public StockOutInvoiceReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void invoiceNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";

            query = "Select * From TbAfterManufactureStockOut Where  BillNo = @BillNo Order By StockOutDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
                comm.Parameters["@BillNo"].Value = invoiceNoComboBox.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                StockOutDataSet dataset = new StockOutDataSet();
                StockOutCrystalReport crp = new StockOutCrystalReport();

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

        private void StockOutInvoiceReport_Load(object sender, EventArgs e)
        {
            LoadChallenCombobox();
        }
        private void LoadChallenCombobox()
        {
            invoiceNoComboBox.Items.Clear();
            string query = "";

            query = "Select Distinct BillNo  From TbAfterManufactureStockOut  Order By BillNo";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["BillNo"].ToString() != "")
                        invoiceNoComboBox.Items.Add(reader["BillNo"].ToString());
                }
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