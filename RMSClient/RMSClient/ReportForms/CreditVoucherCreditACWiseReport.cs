using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.ReportForms
{
    public partial class CreditVoucherCreditACWiseReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public CreditVoucherCreditACWiseReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void CreditVoucherCreditACWiseReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxCreditAC();
        }
        private void PopulateComboboxCreditAC()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyExpenseCreditPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Credit"].ToString() != "")
                        comboBox1.Items.Add(reader["Credit"].ToString());
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
            //SqlConnection conn = new SqlConnection(this.connectionString);
            //SqlCommand comm = new SqlCommand("dbo.UspCreditVoucherCreditACWiseReport", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            //comm.Parameters.Add("@Credit", SqlDbType.VarChar, 50);
            //comm.Parameters["@Credit"].Value = comboBox1.Text;

            //SqlDataAdapter adap = new SqlDataAdapter();
            //DataSets.CreditVoucher dataset = new DataSets.CreditVoucher();
            //Reports.CreditVoucherByCreditACCrystalReport crp = new Reports.CreditVoucherByCreditACCrystalReport();

            //try
            //{
            //    conn.Open();
            //    adap.SelectCommand = comm;
            //    adap.Fill(dataset, "DataTable1");
            //    crp.SetDataSource(dataset);
            //    crystalReportViewer1.ReportSource = crp;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}

            this.reportQuary = dateTimePicker1.Text + "  to  " + dateTimePicker2.Text;
            string query = "";

            query = "Select * From TbDailyExpense Where ExpenseDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Credit = @Credit Order By ExpenseDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Credit", SqlDbType.VarChar, 50);
                comm.Parameters["@Credit"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.CreditVoucher dataset = new DataSets.CreditVoucher();
                CreditVoucherByCreditACCrystalReport crp = new CreditVoucherByCreditACCrystalReport();

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

                ParameterValues v = new ParameterValues();
                ParameterDiscreteValue dv = new ParameterDiscreteValue();

                dv = new ParameterDiscreteValue();
                dv.Value = this.reportQuary;
                v.Add(dv);
                crp.DataDefinition.ParameterFields["report_query"].ApplyCurrentValues(v);

                crystalReportViewer2.ReportSource = crp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.ReadSummary(comboBox1.Text);  
        }
        public void ReadSummary(string srr)
        {
            

            this.reportQuary = dateTimePicker1.Text + "  to  " + dateTimePicker2.Text;
            string query = "";

            query = "SELECT CompanyName, Expense, SUM(Amount) AS Amount FROM TbDailyExpense Where ExpenseDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Credit = @Credit GROUP BY CompanyName, Expense";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Credit", SqlDbType.VarChar, 50);
                comm.Parameters["@Credit"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.CreditVoucher dataset = new DataSets.CreditVoucher();
                CreditVoucherByCreditACCrystalReportSummary crp = new CreditVoucherByCreditACCrystalReportSummary();

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

                ParameterValues v = new ParameterValues();
                ParameterDiscreteValue dv = new ParameterDiscreteValue();

                dv = new ParameterDiscreteValue();
                dv.Value = this.reportQuary;
                v.Add(dv);
                crp.DataDefinition.ParameterFields["report_query"].ApplyCurrentValues(v);

                crystalReportViewer2.ReportSource = crp;
            }
        }
    }
}