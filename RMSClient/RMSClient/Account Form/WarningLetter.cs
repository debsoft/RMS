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
    public partial class WarningLetter : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public WarningLetter()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboWarningType.Text == "")
            {
                MessageBox.Show("Select Warning Type Before Saved.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlCommand comm = new SqlCommand("dbo.UspWarningLetterSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeID"].Value = cboEmployeeID.Text;

            comm.Parameters.Add("@WarningType", SqlDbType.VarChar, 50);
            comm.Parameters["@WarningType"].Value = cboWarningType.Text;

            comm.Parameters.Add("@WarningDate", SqlDbType.DateTime);
            comm.Parameters["@WarningDate"].Value = dTPWarningDate.Value.Date;

            comm.Parameters.Add("@WarningDetails", SqlDbType.VarChar, 500);
            comm.Parameters["@WarningDetails"].Value = txtWarningDetails.Text;          


            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Warning Created Successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cboEmployeeID.Text = "";
            cboWarningType.Text = "";
            txtWarningDetails.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void WarningLetter_Load(object sender, EventArgs e)
        {
            PopulateComboboxID();
        }
        private void PopulateComboboxID()
        {
            cboEmployeeID.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabasePopulateID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["EmployeeID"].ToString() != "")
                        cboEmployeeID.Items.Add(reader["EmployeeID"].ToString());
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

        private void cboEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditData(cboEmployeeID.Text);
        }
        private bool EditData(string empid)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbEmployeeDatabase WHERE EmployeeID = @EmployeeID", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = empid.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["EmployeeName"].ToString();
                    textBox3.Text = reader["Designation"].ToString();
                    textBox2.Text = reader["Location"].ToString();
                }
            }
            catch (Exception ex)
            {
                ret = false;
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }

            return ret;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportForms.WarningLetter sr = new ReportForms.WarningLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }
    }
}
