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
    public partial class StockOutChallenReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public StockOutChallenReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void challanNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";

            query = "Select * From TbAfterManufactureStockOut Where  ChallanNo = @ChallanNo Order By StockOutDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@ChallanNo", SqlDbType.VarChar, 50);
                comm.Parameters["@ChallanNo"].Value = challanNoComboBox.Text;

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

        private void StockOutChallenReport_Load(object sender, EventArgs e)
        {
            LoadChallenCombobox();
        }

        private void LoadChallenCombobox()
        {
            challanNoComboBox.Items.Clear();
            string query = "";

            query = "Select Distinct ChallanNo  From TbAfterManufactureStockOut  Order By ChallanNo";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ChallanNo"].ToString() != "")
                        challanNoComboBox.Items.Add(reader["ChallanNo"].ToString());
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
