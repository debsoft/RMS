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
    public partial class BankStatementReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public BankStatementReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportQuary = dateTimePicker1.Text + "  to  " + dateTimePicker2.Text;
            string query = "";

            query = "Select * From tblBankStatement Where TransDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' Order By AutoId";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.BankDataSet dataset = new DataSets.BankDataSet();
                BankStatementCrystalReport crp = new BankStatementCrystalReport();

                try
                {
                    conn.Open();
                    adap.SelectCommand = comm;
                    adap.Fill(dataset, "DataTable1");
                    crp.SetDataSource(dataset);
                    ParameterValues v = new ParameterValues();
                    ParameterDiscreteValue dv = new ParameterDiscreteValue();

                    dv = new ParameterDiscreteValue();
                    dv.Value = this.reportQuary;
                    v.Add(dv);
                    crp.DataDefinition.ParameterFields["report_query"].ApplyCurrentValues(v);

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
}
