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
    public partial class AddNewCompany : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
       private String connectionString;
       // string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        public AddNewCompany()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.DuplicateID())
            {
                MessageBox.Show("Company Name Duplicate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Fill Company Name Before Save.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Save();
                    Reset();
                }
            }
        }
        private bool DuplicateID()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From tblAddCompany Where CompanyName = '" + textBox1.Text + "'";

            SqlDataReader reader = null;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    if (textBox1.Text == reader["CompanyName"].ToString())
                    {
                        ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspCompanyNameSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyName"].Value = textBox1.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully Save.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox1.Text = "";            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            this.ReadDataDateWise();
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspCompanyNameSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["CompanyId"].ToString(), reader["CompanyName"].ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData();
            this.ReadDataDateWise();           
            Reset();
        }
        private void UpdateData()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspCompanyNameUpdate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyName"].Value = textBox1.Text;

            comm.Parameters.Add("@CompanyId", SqlDbType.BigInt);
            comm.Parameters["@CompanyId"].Value = int.Parse(textBox5.Text);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Really Want to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                DeleteData(textBox5.Text);
                this.ReadDataDateWise();
                Reset();
            }
        }
        private void DeleteData(string ai)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspCompanyNameDelete", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyId", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyId"].Value = textBox5.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleted.");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
