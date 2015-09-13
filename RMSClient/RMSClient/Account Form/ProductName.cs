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

namespace SemcoGroup.Forms
{
    public partial class ProductName : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public ProductName()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.DuplicateID())
            {
                MessageBox.Show("Product Name Duplicate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Fill Product Name Before Save.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Save();
                    PopulateComboboxUnit();
                    Reset();
                }
            }
        }
        private bool DuplicateID()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From TbProductName Where ProductName = '" + textBox1.Text + "'";

            SqlDataReader reader = null;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    if (textBox1.Text == reader["ProductName"].ToString())
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
            SqlCommand comm = new SqlCommand("dbo.UspProductNameSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
            comm.Parameters["@ProductName"].Value = textBox1.Text;

            comm.Parameters.Add("@Unit", SqlDbType.VarChar, 50);
            comm.Parameters["@Unit"].Value = comboBox1.Text;

            comm.Parameters.Add("@Qty", SqlDbType.BigInt);
            comm.Parameters["@Qty"].Value = int.Parse(textBox2.Text);

            comm.Parameters.Add("@EntryDate", SqlDbType.DateTime);
            comm.Parameters["@EntryDate"].Value = dateTimePicker1.Value.Date;

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
            comboBox1.Text = "";
            textBox2.Text = "0";
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
            SqlCommand comm = new SqlCommand("dbo.UspProductNameSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["ProductName"].ToString(), reader["Unit"].ToString());
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
            PopulateComboboxUnit();
            Reset();
            
        }
        private void UpdateData()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspProductNameUpdate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
            comm.Parameters["@ProductName"].Value = textBox1.Text;

            comm.Parameters.Add("@Unit", SqlDbType.VarChar, 50);
            comm.Parameters["@Unit"].Value = comboBox1.Text;

            comm.Parameters.Add("@EntryDate", SqlDbType.DateTime);
            comm.Parameters["@EntryDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@AutoId", SqlDbType.BigInt);
            comm.Parameters["@AutoId"].Value = int.Parse(textBox5.Text);

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
            SqlCommand comm = new SqlCommand("dbo.UspProductNameDelete", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@AutoId", SqlDbType.VarChar, 50);
            comm.Parameters["@AutoId"].Value = textBox5.Text;

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
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductName_Load(object sender, EventArgs e)
        {
            PopulateComboboxUnit();
        }
        private void PopulateComboboxUnit()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUnitPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Unit"].ToString() != "")
                        comboBox1.Items.Add(reader["Unit"].ToString());
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