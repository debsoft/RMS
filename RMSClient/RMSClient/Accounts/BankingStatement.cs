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
    public partial class BankingStatement : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public BankingStatement()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b;

            a = double.Parse("0"+txtBalance.Text);
            b = double.Parse("0" + textBox2.Text);

            txtBalance.Text = "" + (a + b);

            double aa, bb;

            aa = double.Parse("0"+txtBalance.Text);
            bb = double.Parse("0"+textBox3.Text);

            txtBalance.Text = "" + (aa - bb);

            Save();            
            PopulateComboboxDesignation();
            UPdateBalance();
            txtBalance.Text = this.ReadTotalBalance();
            textBox5.Focus();
            ReadDataDateWise();
            Reset();
        }
        private void UPdateBalance()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblOpeningBalance SET Balance = @Balance WHERE BalanceType = 'CASH IN BANK'", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(txtBalance.Text);           

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
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspBankStatementSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@TransDate", SqlDbType.DateTime);
            comm.Parameters["@TransDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@TransType", SqlDbType.VarChar, 50);
            comm.Parameters["@TransType"].Value = comboBox2.Text;

            comm.Parameters.Add("@Deposit", SqlDbType.Float);
            comm.Parameters["@Deposit"].Value = double.Parse(textBox2.Text);

            comm.Parameters.Add("@Withdral", SqlDbType.Float);
            comm.Parameters["@Withdral"].Value = double.Parse(textBox3.Text);

            comm.Parameters.Add("@MemoNo", SqlDbType.VarChar, 50);
            comm.Parameters["@MemoNo"].Value = textBox5.Text;

            comm.Parameters.Add("@ChequeNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ChequeNo"].Value = textBox4.Text;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(txtBalance.Text);

            comm.Parameters.Add("@Reason", SqlDbType.VarChar, 50);
            comm.Parameters["@Reason"].Value = comboBox1.Text;

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
            //txtBalance.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

            comboBox1.Text = "";           
        }
        private void PopulateComboboxDesignation()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT Reason FROM tblBankStatement ORDER BY Reason", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Reason"].ToString() != "")
                        comboBox1.Items.Add(reader["Reason"].ToString());
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
        private void BankingStatement_Load(object sender, EventArgs e)
        {
            PopulateComboboxDesignation();
            txtBalance.Text = this.ReadTotalBalance();
            ReadDataDateWise();
        }
        private string ReadTotalBalance()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspReadTotalBalance", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ReadDataDateWise();  
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspBankStatementSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["TransDate"].ToString(), reader["TransType"].ToString(), reader["Deposit"].ToString(), reader["Withdral"].ToString(), reader["MemoNo"].ToString(), reader["ChequeNo"].ToString(), reader["Balance"].ToString(), reader["Reason"].ToString());
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Deposit")
            {
                textBox2.Focus();
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            if (comboBox2.Text == "Withdrawl")
            {
                textBox3.Focus();
                textBox2.Enabled = false;
                textBox5.Enabled = false;
            }
        }
    }
}
