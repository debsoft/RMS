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
    public partial class PerformanceFormReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public PerformanceFormReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void PerformanceFormReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxEmpID();
        }
        private void PopulateComboboxEmpID()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT EmployeeID FROM tblPerformanceForm ORDER BY EmployeeID", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["EmployeeID"].ToString() != "")
                        comboBox1.Items.Add(reader["EmployeeID"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Read(comboBox1.Text); 
        }
        public void Read(string srr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM Vw_PerformanceForm WHERE EmployeeID = @EmployeeID", conn);

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeID"].Value = comboBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DataSets.PerformanceDataSet dataset = new DataSets.PerformanceDataSet();
            PerformanceCrystalReport crp = new PerformanceCrystalReport();

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
