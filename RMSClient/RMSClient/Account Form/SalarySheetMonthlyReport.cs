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
    public partial class SalarySheetMonthlyReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public SalarySheetMonthlyReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalarySheetMonthlyReport_Load(object sender, EventArgs e)
        {
            comboBox4.Text = this.ReadLastMonth();
            comboBox1.Text = this.ReadLastYear();  
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
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void Read(string addgroup, string sy)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetMonthReport", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Salary_Month", SqlDbType.VarChar,20);
            comm.Parameters["@Salary_Month"].Value = comboBox4.Text;

            comm.Parameters.Add("@Salary_Year", SqlDbType.VarChar, 10);
            comm.Parameters["@Salary_Year"].Value = comboBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
            SalarySheetMonthlyCrystalReport1 crp = new SalarySheetMonthlyCrystalReport1();

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

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Read(comboBox4.Text, comboBox1.Text);
        }
    }
}