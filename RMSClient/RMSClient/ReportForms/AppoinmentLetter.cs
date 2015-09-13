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
    public partial class AppoinmentLetter : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public AppoinmentLetter()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Read(comboBox1.Text);  
        }
        public void Read(string srr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM tblAppoinmentLetter WHERE Name = @Name ORDER BY Name", conn);

            comm.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            comm.Parameters["@Name"].Value = comboBox1.Text;

            SqlDataAdapter adap = new SqlDataAdapter();
            DataSets.AppoinmentDataSet dataset = new DataSets.AppoinmentDataSet();
           AppoinmentLetterCrystalReport crp = new AppoinmentLetterCrystalReport();

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

        private void AppoinmentLetter_Load(object sender, EventArgs e)
        {
            PopulateComboboxEmpID();
        }
        private void PopulateComboboxEmpID()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT Name FROM tblAppoinmentLetter ORDER BY Name", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Name"].ToString() != "")
                        comboBox1.Items.Add(reader["Name"].ToString());
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
    }
}
