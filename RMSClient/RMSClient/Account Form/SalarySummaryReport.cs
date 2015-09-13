using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.Forms
{
    public partial class SalarySummaryReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public SalarySummaryReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void SalarySummaryReport_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Read(comboBox4.Text, comboBox1.Text);
        }
        public void Read(string addgroup, string sy)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetSummaryReport", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@SalaryMonth", SqlDbType.VarChar, 20);
            comm.Parameters["@SalaryMonth"].Value = comboBox4.Text;

            comm.Parameters.Add("@SalaryYear", SqlDbType.VarChar, 10);
            comm.Parameters["@SalaryYear"].Value = comboBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
            SummerySheetNewReport crp = new SummerySheetNewReport();


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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}