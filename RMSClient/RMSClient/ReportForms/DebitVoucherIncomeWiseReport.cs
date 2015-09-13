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
    public partial class DebitVoucherIncomeWiseReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public DebitVoucherIncomeWiseReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void DebitVoucherIncomeWiseReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxIncome();
        }
        private void PopulateComboboxIncome()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyIncomeSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Income"].ToString() != "")
                        comboBox1.Items.Add(reader["Income"].ToString());
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

            query = "Select * From TbDailyIncome Where IncomeDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Income = @Income Order By IncomeDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Income", SqlDbType.VarChar, 50);
                comm.Parameters["@Income"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.DebitVoucherDataSet dataset = new DataSets.DebitVoucherDataSet();
                DebitVoucherByIncomeCrystalReport crp = new DebitVoucherByIncomeCrystalReport();

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
    }
}