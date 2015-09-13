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
    public partial class DebitVoucher : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public DebitVoucher()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill Voucher No Before Save.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (this.DuplicateID())
                {
                    MessageBox.Show("Voucher No Duplicate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Save();
                    UPdateBalance();
                    this.ReadDataDateWise(dateTimePicker1.Text);
                    PopulateComboboxDebitAC();
                    PopulateComboboxIncome();
                    PopulateComboboxDebitNarration();
                    Reset();
                }
            }
        }

        private void UPdateBalance()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblOpeningBalance SET Balance += @Balance WHERE BalanceType = 'CASH IN HAND'", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(textBox2.Text);

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


        private bool DuplicateID()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From TbDailyIncome Where VoucherNo = '" + textBox1.Text + "'";

            SqlDataReader reader = null;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    if (textBox1.Text == reader["VoucherNo"].ToString())
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
            SqlCommand comm = new SqlCommand("dbo.UspDailyIncomeSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyName"].Value = cboCompanyName.Text;
            
            comm.Parameters.Add("@IncomeDate", SqlDbType.DateTime);
            comm.Parameters["@IncomeDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse(textBox1.Text);

            comm.Parameters.Add("@PaymentMode", SqlDbType.VarChar, 500);
            comm.Parameters["@PaymentMode"].Value = textBox3.Text;

            comm.Parameters.Add("@Debit", SqlDbType.VarChar, 500);
            comm.Parameters["@Debit"].Value = comboBox1.Text;

            comm.Parameters.Add("@Income", SqlDbType.VarChar, 50);
            comm.Parameters["@Income"].Value = comboBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox2.Text);

            comm.Parameters.Add("@DebitNarration", SqlDbType.VarChar, 500);
            comm.Parameters["@DebitNarration"].Value = comboBox3.Text;

            



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
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "";

            comboBox2.Text = "";
            comboBox1.Text = "";

        }

        private void DebitVoucher_Load(object sender, EventArgs e)
        {
            PopulateComboboxDebitAC();
            PopulateComboboxIncome();
            PopulateComboboxDebitNarration();
            this.ReadDataDateWise(dateTimePicker1.Text);
            PopulateComboboxCompany();
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
        private void ReadDataDateWise(string ret)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyIncomeSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@IncomeDate", SqlDbType.DateTime);
            comm.Parameters["@IncomeDate"].Value = dateTimePicker1.Value.Date;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["CompanyName"].ToString(), reader["VoucherNo"].ToString(), reader["Debit"].ToString(), reader["Income"].ToString(), reader["Amount"].ToString(), reader["PaymentMode"].ToString(), reader["DebitNarration"].ToString());
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
        private void PopulateComboboxDebitAC()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyIncomeDebitPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Debit"].ToString() != "")
                        comboBox1.Items.Add(reader["Debit"].ToString());
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
        private void PopulateComboboxDebitNarration()
        {
            comboBox3.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT DebitNarration FROM TbDailyIncome ORDER BY DebitNarration", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DebitNarration"].ToString() != "")
                        comboBox3.Items.Add(reader["DebitNarration"].ToString());
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
        private void PopulateComboboxIncome()
        {
            comboBox2.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspIncomePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Income"].ToString() != "")
                        comboBox2.Items.Add(reader["Income"].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ReadDataDateWise1(textBox1.Text);
        }
        private void ReadDataDateWise1(string ty)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbDailyIncome WHERE VoucherNo = @VoucherNo", conn);

            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse("0"+textBox1.Text);
            
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                   // dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["VoucherNo"].ToString(), reader["Debit"].ToString(), reader["Income"].ToString(), reader["Amount"].ToString(), reader["PaymentMode"].ToString());
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["CompanyName"].ToString(), reader["VoucherNo"].ToString(), reader["Debit"].ToString(), reader["Income"].ToString(), reader["Amount"].ToString(), reader["PaymentMode"].ToString(), reader["DebitNarration"].ToString());
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
                textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cboCompanyName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateData(textBox4.Text);
            this.ReadDataDateWise1(textBox1.Text);
            Reset();
        }
        private void UpdateData(string ty)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE TbDailyIncome SET VoucherNo = @VoucherNo, Debit = @Debit, Income = @Income, Amount = @Amount, PaymentMode = @PaymentMode WHERE AutoId = @AutoId", conn);
           
            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse(textBox1.Text);

            comm.Parameters.Add("@Debit", SqlDbType.VarChar, 500);
            comm.Parameters["@Debit"].Value = comboBox1.Text;

            comm.Parameters.Add("@Income", SqlDbType.VarChar, 50);
            comm.Parameters["@Income"].Value = comboBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox2.Text);

            comm.Parameters.Add("@PaymentMode", SqlDbType.VarChar, 500);
            comm.Parameters["@PaymentMode"].Value = textBox3.Text;

            comm.Parameters.Add("@AutoId", SqlDbType.BigInt);
            comm.Parameters["@AutoId"].Value = int.Parse(textBox4.Text);

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
    }
}