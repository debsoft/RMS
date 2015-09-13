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
using System.Configuration;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.ReportForms
{
    public partial class DebitVoucherDatetoDateReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public DebitVoucherDatetoDateReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportQuary = dateTimePicker1.Text + "  to  " + dateTimePicker2.Text;
            string query = "";

            query = "Select * From TbDailyIncome Where IncomeDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' Order By IncomeDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.DebitVoucherDataSet dataset = new DataSets.DebitVoucherDataSet();
                DebitVoucherDatetoDateCrystalReport crp = new DebitVoucherDatetoDateCrystalReport();

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

        private void DebitVoucherDatetoDateReport_Load(object sender, EventArgs e)
        {

        }
    }
}