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
    public partial class CreditVoucher : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public CreditVoucher()
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
                    Reset();
                }
            }
        }

        private void UPdateBalance()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblOpeningBalance SET Balance -= @Balance WHERE BalanceType = 'CASH IN HAND'", conn);
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
            String sql1 = "Select * From TbDailyExpense Where VoucherNo = '" + textBox1.Text + "'";

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
            SqlCommand comm = new SqlCommand("dbo.UspDailyExpenseSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50);
            comm.Parameters["@CompanyName"].Value = cboCompanyName.Text;
            
            comm.Parameters.Add("@ExpenseDate", SqlDbType.DateTime);
            comm.Parameters["@ExpenseDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse(textBox1.Text);
            
            comm.Parameters.Add("@Credit", SqlDbType.VarChar, 500);
            comm.Parameters["@Credit"].Value = comboBox1.Text;

            comm.Parameters.Add("@Expense", SqlDbType.VarChar, 50);
            comm.Parameters["@Expense"].Value = comboBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox2.Text);

            comm.Parameters.Add("@CreditNarration", SqlDbType.VarChar, 100);
            comm.Parameters["@CreditNarration"].Value = comboBox3.Text;

            

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

            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";

        }
        private void CreditVoucher_Load(object sender, EventArgs e)
        {
            PopulateComboboxCreditAC();
            PopulateComboboxExpense();
            PopulateComboboxExpenseNarration();
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
            SqlCommand comm = new SqlCommand("dbo.UspDailyExpenseSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@ExpenseDate", SqlDbType.DateTime);
            comm.Parameters["@ExpenseDate"].Value = dateTimePicker1.Value.Date;
            
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["CompanyName"].ToString(), reader["VoucherNo"].ToString(), reader["Credit"].ToString(), reader["Expense"].ToString(), reader["Amount"].ToString(), reader["CreditNarration"].ToString());
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
        private void PopulateComboboxCreditAC()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyExpenseCreditPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Credit"].ToString() != "")
                        comboBox1.Items.Add(reader["Credit"].ToString());
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
        private void PopulateComboboxExpenseNarration()
        {
            comboBox3.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspDailyExpenseCreditNarration", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["CreditNarration"].ToString() != "")
                        comboBox3.Items.Add(reader["CreditNarration"].ToString());
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
        private void PopulateComboboxExpense()
        {
            comboBox2.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspExpensePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Expense"].ToString() != "")
                        comboBox2.Items.Add(reader["Expense"].ToString());
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
        private void ReadDataDateWise1(string ret)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbDailyExpense WHERE VoucherNo = @VoucherNo", conn);

            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse(textBox1.Text);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["CompanyName"].ToString(), reader["VoucherNo"].ToString(), reader["Credit"].ToString(), reader["Expense"].ToString(), reader["Amount"].ToString(), reader["CreditNarration"].ToString());
                   // dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["VoucherNo"].ToString(), reader["Credit"].ToString(), reader["Expense"].ToString(), reader["Amount"].ToString(), reader["CreditNarration"].ToString());
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
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cboCompanyName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateData(textBox3.Text);
            this.ReadDataDateWise1(textBox1.Text);
            Reset();
        }
        private void UpdateData(string ty)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE TbDailyExpense SET VoucherNo = @VoucherNo, Credit = @Credit, Expense = @Expense, Amount = @Amount, CreditNarration = @CreditNarration WHERE AutoId = @AutoId", conn);

            comm.Parameters.Add("@VoucherNo", SqlDbType.BigInt);
            comm.Parameters["@VoucherNo"].Value = int.Parse(textBox1.Text);

            comm.Parameters.Add("@Credit", SqlDbType.VarChar, 500);
            comm.Parameters["@Credit"].Value = comboBox1.Text;

            comm.Parameters.Add("@Expense", SqlDbType.VarChar, 50);
            comm.Parameters["@Expense"].Value = comboBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox2.Text);

            comm.Parameters.Add("@CreditNarration", SqlDbType.VarChar, 100);
            comm.Parameters["@CreditNarration"].Value = comboBox3.Text;

            comm.Parameters.Add("@AutoId", SqlDbType.BigInt);
            comm.Parameters["@AutoId"].Value = int.Parse(textBox3.Text);

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