using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using RMS;
using RMS.AnotherReport;
using RMS.Common;

namespace PayRoll.Forms
{
    public partial class SingleEmployeeReport : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public SingleEmployeeReport(string VR)
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
            textBox1.Text = VR;
        }

        private void SingleEmployeeReport_Load(object sender, EventArgs e)
        {
            this.Read(textBox1.Text);
        }
        public void Read(string skd)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM Vw_EmployeeDatebaseWIthPhoto WHERE EmployeeID = @EmployeeID", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = textBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
            SingleDatabaseCrystalReport1 crp = new SingleDatabaseCrystalReport1();

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

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
