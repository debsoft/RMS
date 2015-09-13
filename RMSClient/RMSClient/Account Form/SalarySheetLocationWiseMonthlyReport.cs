using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.Forms
{
    public partial class SalarySheetLocationWiseMonthlyReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public SalarySheetLocationWiseMonthlyReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void SalarySheetLocationWiseMonthlyReport_Load(object sender, EventArgs e)
        {
            comboBox4.Text = this.ReadLastMonth();
            comboBox1.Text = this.ReadLastYear();
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
        private string ReadLastMonth()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetReadLastMonth", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private string ReadLastYear()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetReadLastYear", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Read(comboBox4.Text, comboBox1.Text, comboBox5.Text);
        }
        public void Read(string addgroup, string sy, string ri)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetLocationMonthReport", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Salary_Month", SqlDbType.VarChar, 20);
            comm.Parameters["@Salary_Month"].Value = comboBox4.Text;

            comm.Parameters.Add("@Salary_Year", SqlDbType.VarChar, 10);
            comm.Parameters["@Salary_Year"].Value = comboBox1.Text;

            comm.Parameters.Add("@Location", SqlDbType.VarChar, 50);
            comm.Parameters["@Location"].Value = comboBox5.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
            SalarySheetLocationWiseMonthlyCrystalReport1 crp = new SalarySheetLocationWiseMonthlyCrystalReport1();

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}