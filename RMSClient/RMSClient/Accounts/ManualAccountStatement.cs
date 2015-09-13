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
    public partial class ManualAccountStatement : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public ManualAccountStatement()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void ManualAccountStatement_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchItem123(comboBox1.Text);
            SearchItem456(comboBox1.Text);
        }
        private bool SearchItem123(string nick)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbFactory WHERE FactoryName = @FactoryName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox7.Text = reader["FactoryAddress"].ToString();
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
        private bool SearchItem456(string nick)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM tblManualACBalance WHERE FactoryName = @FactoryName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox6.Text = reader["Balance"].ToString();
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Month Before Save.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Save();
                UpdateAC(comboBox1.Text);
                Reset();
                SearchItem456(comboBox1.Text);
            } 
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspManualACStatementSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@BillDate", SqlDbType.DateTime);
            comm.Parameters["@BillDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@FactoryUnit", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryUnit"].Value = textBox1.Text;

            comm.Parameters.Add("@FactoryAddress", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryAddress"].Value = textBox7.Text;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            comm.Parameters["@BillNo"].Value = textBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox3.Text);

            comm.Parameters.Add("@Less", SqlDbType.BigInt);
            comm.Parameters["@Less"].Value = double.Parse(textBox4.Text);

            comm.Parameters.Add("@PaidAmount", SqlDbType.BigInt);
            comm.Parameters["@PaidAmount"].Value = double.Parse(textBox5.Text);

            comm.Parameters.Add("@Balance", SqlDbType.BigInt);
            comm.Parameters["@Balance"].Value = double.Parse(textBox6.Text);

            comm.Parameters.Add("@Notes", SqlDbType.VarChar, 50);
            comm.Parameters["@Notes"].Value = textBox12.Text;       

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
        private void UpdateAC(string opr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblManualACBalance SET Balance = @Balance WHERE FactoryName = @FactoryName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(textBox6.Text);

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 100);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
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
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox12.Text = "";            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            double a, b;

            a = double.Parse(textBox3.Text);
            b = double.Parse(textBox6.Text);

            textBox6.Text = "" + (a + b);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            double a1, b1;

            a1 = double.Parse(textBox4.Text);
            b1 = double.Parse(textBox6.Text);

            textBox6.Text = "" + (b1 - a1);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            double a2, b2;

            a2 = double.Parse(textBox5.Text);
            b2 = double.Parse(textBox6.Text);

            textBox6.Text = "" + (b2 - a2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveBalance();
            textBox8.Text = "0";
            SearchItem456(comboBox1.Text);
        }
        private void SaveBalance()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("INSERT INTO tblManualACBalance VALUES(@FactoryName, @Balance)", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@Balance", SqlDbType.Float);
            comm.Parameters["@Balance"].Value = double.Parse(textBox8.Text);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Balance Successfully Updated.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.SearchSNNoByEmployee(comboBox1.Text);
        }
        private void SearchSNNoByEmployee(string sn)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM tblManualACStatement WHERE FactoryName = @FactoryName", conn);

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 100);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["FactoryName"].ToString(), reader["FactoryUnit"].ToString(), reader["FactoryAddress"].ToString(), reader["BillDate"].ToString(), reader["BillNo"].ToString(), reader["Amount"].ToString(), reader["Less"].ToString(), reader["PaidAmount"].ToString(), reader["Balance"].ToString(), reader["Notes"].ToString());
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
            textBox14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateAC(comboBox1.Text);
            UpdateData(textBox14.Text);
            this.SearchSNNoByEmployee(comboBox1.Text);
        }
        private void UpdateData(string dk)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblManualACStatement SET FactoryName = @FactoryName, FactoryUnit = @FactoryUnit, FactoryAddress = @FactoryAddress, BillDate = @BillDate, BillNo = @BillNo, Amount = @Amount, Less = @Less, PaidAmount = @PaidAmount, Balance = @Balance, Notes = @Notes WHERE AutoId = @AutoId", conn);

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@FactoryUnit", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryUnit"].Value = textBox1.Text;

            comm.Parameters.Add("@FactoryAddress", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryAddress"].Value = textBox7.Text;

            comm.Parameters.Add("@BillDate", SqlDbType.DateTime);
            comm.Parameters["@BillDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            comm.Parameters["@BillNo"].Value = textBox2.Text;

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox3.Text);

            comm.Parameters.Add("@Less", SqlDbType.BigInt);
            comm.Parameters["@Less"].Value = double.Parse(textBox4.Text);

            comm.Parameters.Add("@PaidAmount", SqlDbType.BigInt);
            comm.Parameters["@PaidAmount"].Value = double.Parse(textBox5.Text);

            comm.Parameters.Add("@Balance", SqlDbType.BigInt);
            comm.Parameters["@Balance"].Value = double.Parse(textBox6.Text);

            comm.Parameters.Add("@Notes", SqlDbType.VarChar, 50);
            comm.Parameters["@Notes"].Value = textBox12.Text;   

            comm.Parameters.Add("@AutoId", SqlDbType.VarChar, 50);
            comm.Parameters["@AutoId"].Value = textBox14.Text;

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
