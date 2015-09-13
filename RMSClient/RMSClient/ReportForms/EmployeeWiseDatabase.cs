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

namespace PayRoll.ReportForms
{
    public partial class EmployeeWiseDatabase : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public EmployeeWiseDatabase()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void EmployeeWiseDatabase_Load(object sender, EventArgs e)
        {
            PopulateComboboxEmpID();
        }
        private void PopulateComboboxEmpID()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT EmployeeID FROM TbEmployeeDatabase ORDER BY EmployeeID", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["EmployeeID"].ToString() != "")
                        comboBox1.Items.Add(reader["EmployeeID"].ToString());
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
        public void Read(string skd)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM Vw_EmployeeDatebaseWIthPhoto WHERE EmployeeID = @EmployeeID", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = comboBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DatabaseDataSet dataset = new DatabaseDataSet();
            SingleDatabaseCrystalReport1 crp = new SingleDatabaseCrystalReport1();

            try
            {
                conn.Open();
                adap.SelectCommand = comm;
                adap.Fill(dataset, "DataTable1");
                crp.SetDataSource(dataset);
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
}
