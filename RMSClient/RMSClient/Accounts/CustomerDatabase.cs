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

namespace PayRoll.Accounts
{
    public partial class CustomerDatabase : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public CustomerDatabase()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData(textBox5.Text);
            dataGridView1.Visible = true;
            if (checkBox1.Checked)
            {
                ReadDataDateWise();
            }
            if (checkBox2.Checked)
            {
                ReadDataDateWiseFactory(comboBox1.Text);
            }
            Reset(); 
        }
        private void UpdateData(string gf)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE TbFactory SET LateDue = @LateDue WHERE AutoId = @AutoId", conn);
           
            comm.Parameters.Add("@LateDue", SqlDbType.Float);
            comm.Parameters["@LateDue"].Value = double.Parse(textBox7.Text);

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
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "0";
            textBox7.Text = "0";            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbFactory ORDER BY FactoryName", conn);
            
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["FactoryName"].ToString(), reader["FactoryAddress"].ToString(), reader["LateDue"].ToString());
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
        private void ReadDataDateWiseFactory(string rt)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbFactory WHERE FactoryName = @FactoryName", conn);

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;
            
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["FactoryName"].ToString(), reader["FactoryAddress"].ToString(), reader["LateDue"].ToString());
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
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (checkBox1.Checked)
            {
                ReadDataDateWise();
            }
            if (checkBox2.Checked)
            {
                ReadDataDateWiseFactory(comboBox1.Text);
            }
        }

        private void CustomerDatabase_Load(object sender, EventArgs e)
        {
            PopulateComboboxFactoryName();
        }
        private void PopulateComboboxFactoryName()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspFactoryNamePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["FactoryName"].ToString() != "")
                        comboBox1.Items.Add(reader["FactoryName"].ToString());
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