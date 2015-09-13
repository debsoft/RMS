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
    public partial class UserAccount : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public UserAccount()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("User Id can not be blank!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                Save();
                Reset();
                PopulateCombobox();
            }
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUserAccountSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@UserId", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@Password", SqlDbType.VarChar,100);
            comm.Parameters.Add("@ReTypePassword", SqlDbType.VarChar, 100);
            comm.Parameters.Add("@UserRole", SqlDbType.VarChar, 100);

            comm.Parameters["@Name"].Value = textBox1.Text;
            comm.Parameters["@Designation"].Value = comboBox1.Text;
            comm.Parameters["@UserId"].Value = textBox2.Text;
            comm.Parameters["@Password"].Value = textBox3.Text;
            comm.Parameters["@ReTypePassword"].Value = textBox4.Text;
            comm.Parameters["@UserRole"].Value = comboBox2.Text;

            try
            {

                conn.Open();

                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully Done", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }
        private void PopulateCombobox()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUserAccountPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Designation"].ToString() != "")
                        comboBox1.Items.Add(reader["Designation"].ToString());
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

        private void UserAccount_Load(object sender, EventArgs e)
        {
            PopulateCombobox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditData(textBox2.Text);
        }
        private bool EditData(string empid)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUserAccountEdit", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@UserId", SqlDbType.VarChar, 20);
            comm.Parameters["@UserId"].Value = empid.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["Name"].ToString();
                    comboBox1.Text = reader["Designation"].ToString();
                    textBox3.Text = reader["Password"].ToString();
                    textBox4.Text = reader["ReTypePassword"].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData();
            Reset();
            PopulateCombobox();
        }
        private void UpdateData()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUserAccountUpdate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@UserId", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@Password", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@ReTypePassword", SqlDbType.VarChar, 50);
            comm.Parameters.Add("@UserRole", SqlDbType.VarChar, 100);

            comm.Parameters["@Name"].Value = textBox1.Text;
            comm.Parameters["@Designation"].Value = comboBox1.Text;
            comm.Parameters["@UserId"].Value = textBox2.Text;
            comm.Parameters["@Password"].Value = textBox3.Text;
            comm.Parameters["@ReTypePassword"].Value = textBox4.Text;
            comm.Parameters["@UserRole"].Value = comboBox2.Text;

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
            this.Close();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text != textBox3.Text)
            {
                MessageBox.Show("Password Not Match!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.DuplicateID())
            {
                MessageBox.Show("User ID Duplicate!!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool DuplicateID()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From TbUserAccount Where UserId = '" + textBox2.Text + "'";

            SqlDataReader reader = null;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    if (textBox2.Text == reader["UserId"].ToString())
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
    }
}