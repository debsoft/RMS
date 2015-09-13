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
    public partial class DebitVoucherDebitACWiseReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public DebitVoucherDebitACWiseReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void DebitVoucherDebitACWiseReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxDebitAC();
        }
        private void PopulateComboboxDebitAC()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyIncomeDebitPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Debit"].ToString() != "")
                        comboBox1.Items.Add(reader["Debit"].ToString());
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
            this.reportQuary = dateTimePicker1.Text + "  to  " + dateTimePicker2.Text;
            string query = "";

            query = "Select * From TbDailyIncome Where IncomeDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Debit = @Debit Order By IncomeDate";

            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Debit", SqlDbType.VarChar, 50);
                comm.Parameters["@Debit"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.DebitVoucherDataSet dataset = new DataSets.DebitVoucherDataSet();
               DebitVoucherByDebitACCrystalReport crp = new DebitVoucherByDebitACCrystalReport();

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

            query = "SELECT CompanyName, Income, SUM(Amount) AS Amount FROM TbDailyIncome Where IncomeDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Debit = @Debit GROUP BY CompanyName, Income";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Debit", SqlDbType.VarChar, 50);
                comm.Parameters["@Debit"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.DebitVoucherDataSet dataset = new DataSets.DebitVoucherDataSet();
                DebitVoucherByDebitACCrystalReportSummary crp = new DebitVoucherByDebitACCrystalReportSummary();

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