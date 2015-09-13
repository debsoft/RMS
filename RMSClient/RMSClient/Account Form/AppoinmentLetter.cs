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
using RMS.Common;

namespace PayRoll.Forms
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

        private void AppoinmentLetter_Load(object sender, EventArgs e)
        {
            PopulateComboboxCompany();
           // txtAppointedBy.Text = this.ReadLastA();
           // txtDesignationT.Text = this.ReadLastB();  
        }
        private string ReadLastA()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspReadLastAppointedBy", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private string ReadLastB()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspReadLastDesignation", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private void PopulateComboboxCompany()
        {
            cboCompanyName.Items.Clear();
            
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT CompanyName FROM tblAddCompany ORDER BY CompanyName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["CompanyName"].ToString() != "")
                        cboCompanyName.Items.Add(reader["CompanyName"].ToString());
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
            if (cboCompanyName.Text == "")
            {
                MessageBox.Show("Select Company Name Before Saved.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Save();
                Reset();
            }
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspAppoinmentLetterSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            comm.Parameters["@Name"].Value = txtName.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters["@Designation"].Value = txtDesignation.Text;

            comm.Parameters.Add("@Address", SqlDbType.VarChar, 500);
            comm.Parameters["@Address"].Value = txtAddress.Text;

            comm.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
            comm.Parameters["@DateOfJoining"].Value = dTPJoiningDate.Value.Date;

            comm.Parameters.Add("@ProbationPeriod", SqlDbType.VarChar, 50);
            comm.Parameters["@ProbationPeriod"].Value = cboProbationPeriod.Text;

            comm.Parameters.Add("@Salary", SqlDbType.Float);
            comm.Parameters["@Salary"].Value = double.Parse(txtSalary.Text);

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyName"].Value = cboCompanyName.Text;

            comm.Parameters.Add("@SalaryIncrement", SqlDbType.VarChar, 500);
            comm.Parameters["@SalaryIncrement"].Value = txtSalaryIncrement.Text;

            comm.Parameters.Add("@AppointedBy", SqlDbType.VarChar, 500);
            comm.Parameters["@AppointedBy"].Value = txtAppointedBy.Text;

            comm.Parameters.Add("@DesignationT", SqlDbType.VarChar, 500);
            comm.Parameters["@DesignationT"].Value = txtDesignationT.Text;


            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Appoinment Letter Created Successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Reset()
        {
            txtName.Text = "";
            txtDesignation.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "0";
            txtSalaryIncrement.Text = "";

            cboProbationPeriod.Text = "";
            cboCompanyName.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportForms.AppoinmentLetter sr = new ReportForms.AppoinmentLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }
    }
}
