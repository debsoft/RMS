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
    public partial class CompanyWiseDatabaseReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public CompanyWiseDatabaseReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void CompanyWiseDatabaseReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxCompany();
        }
        private void PopulateComboboxCompany()
        {
            comboBox5.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT CompanyName FROM tblAddCompany ORDER BY CompanyName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["CompanyName"].ToString() != "")
                        comboBox5.Items.Add(reader["CompanyName"].ToString());
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
            this.Read(comboBox5.Text);
        }
        public void Read(string s)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM Vw_EmployeeDatebaseWIthPhoto WHERE CompanyName = @CompanyName ORDER BY EmployeeID", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 30);
            comm.Parameters["@CompanyName"].Value = comboBox5.Text;
            
            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
           DatabaseCrystalReport1 crp = new DatabaseCrystalReport1();

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
