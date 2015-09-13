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
    public partial class CreditVoucherExpenseWiseReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        string reportQuary = ""; 
        public CreditVoucherExpenseWiseReport()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void CreditVoucherExpenseWiseReport_Load(object sender, EventArgs e)
        {
            PopulateComboboxExpense();
        }
        private void PopulateComboboxExpense()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspExpensePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Expense"].ToString() != "")
                        comboBox1.Items.Add(reader["Expense"].ToString());
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
            //SqlCommand comm = new SqlCommand("dbo.UspCreditVoucherExpenseWiseReport", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            //comm.Parameters.Add("@Expense", SqlDbType.VarChar, 50);
            //comm.Parameters["@Expense"].Value = comboBox1.Text;

            //SqlDataAdapter adap = new SqlDataAdapter();
            //DataSets.CreditVoucher dataset = new DataSets.CreditVoucher();
            //Reports.CreditVoucherByExpenserystalReport crp = new Reports.CreditVoucherByExpenserystalReport();

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

            query = "Select * From TbDailyExpense Where ExpenseDate BETWEEN  '" + dateTimePicker1.Value.Date + "' AND  '" + dateTimePicker2.Value.Date + "' AND Expense = @Expense Order By ExpenseDate";
            if (query != "")
            {

                SqlConnection conn = new SqlConnection(this.connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@Expense", SqlDbType.VarChar, 50);
                comm.Parameters["@Expense"].Value = comboBox1.Text;

                SqlDataAdapter adap = new SqlDataAdapter();
                DataSets.CreditVoucher dataset = new DataSets.CreditVoucher();
                CreditVoucherByExpenserystalReport crp = new CreditVoucherByExpenserystalReport();

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