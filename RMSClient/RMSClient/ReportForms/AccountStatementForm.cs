using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using RMS.AnotherReport;
using RMS.Common;
using RMS.DataSets;

namespace RMS.ReportForms
{
    public partial class AccountStatementForm : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public AccountStatementForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }



        public void Read()
        {
            this.reportQuary = fromdateTimePicker.Text + "  to  " + todateTimePicker2.Text;
            string query = "";

            query = "Select * From TbAccountStatement Where CreateDate BETWEEN  '" + fromdateTimePicker.Value.Date + "' AND  '" + todateTimePicker2.Value.Date + "' Order By AutoId";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataAdapter adap = new SqlDataAdapter();
                AccountStatementDataSet dataset = new AccountStatementDataSet();
                AccountStatementCrystalReport crp = new AccountStatementCrystalReport();

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

        private void showButton_Click(object sender, EventArgs e)
        {
            Read();
        }
    }
}
