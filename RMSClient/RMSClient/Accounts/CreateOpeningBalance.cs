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
    public partial class CreateOpeningBalance : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public CreateOpeningBalance()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            Reset();
            ReadDataDateWise();
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspOpeningBalanceSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@BalanceType", SqlDbType.VarChar, 50);
            comm.Parameters["@BalanceType"].Value = cboBalanceType.Text;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(txtBalance.Text);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Opening Balance Created Successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtBalance.Text = "0";
            cboBalanceType.Text = "";
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspOpeningBalanceSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["BalanceType"].ToString(), reader["Balance"].ToString());
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cboBalanceType.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
                txtBalance.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void CreateOpeningBalance_Load(object sender, EventArgs e)
        {
            ReadDataDateWise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateData();
            this.ReadDataDateWise();
            Reset();
        }
        private void UpdateData()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspOpeningBalanceUpdate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(txtBalance.Text);

            comm.Parameters.Add("@AutoId", SqlDbType.BigInt);
            comm.Parameters["@AutoId"].Value = int.Parse(textBox5.Text);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated Successfully.");
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
    }
}
