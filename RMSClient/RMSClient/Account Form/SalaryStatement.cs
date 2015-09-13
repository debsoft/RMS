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

namespace PayRoll.Forms
{
    public partial class SalaryStatement : Form
    {
        //string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        //string reportQuary = "";
        public SalaryStatement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.reportQuary = comboBox4.Text + "  to  " + comboBox1.Text;
            //string query = "";

            //query = "Select * From VwDatabaseWithSalarySheet Where SalaryMonth BETWEEN  '" + comboBox4.Text + "' AND  '" + comboBox1.Text + "' AND EmployeeID = @EmployeeID";

            //if (query != "")
            //{
            //    SqlConnection conn = new SqlConnection(this.connectionString);
            //    SqlCommand comm = new SqlCommand(query, conn);

            //    comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
            //    comm.Parameters["@EmployeeID"].Value = comboBox7.Text;

            //    SqlDataAdapter adap = new SqlDataAdapter();
            //    DataSets.StockOutDataSet dataset = new DataSets.StockOutDataSet();
            //    Reports.StockOutDivisionWiseDatetoDateCrystalReport crp = new Reports.StockOutDivisionWiseDatetoDateCrystalReport();

            //    try
            //    {
            //        conn.Open();
            //        adap.SelectCommand = comm;
            //        adap.Fill(dataset, "DataTable1");

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //    crp.SetDataSource(dataset);

            //    ParameterValues v = new ParameterValues();
            //    ParameterDiscreteValue dv = new ParameterDiscreteValue();

            //    dv = new ParameterDiscreteValue();
            //    dv.Value = this.reportQuary;
            //    v.Add(dv);
            //    crp.DataDefinition.ParameterFields["report_query"].ApplyCurrentValues(v);

            //    crystalReportViewer1.ReportSource = crp;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}