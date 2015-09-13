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
    public partial class MarketPlanningForm : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public MarketPlanningForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Month Before Save.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Save();
                PopulateComboboxEmployeeName();
                Reset();
            } 
        }
        private void PopulateComboboxEmployeeName()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeNamePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["EmployeeName"].ToString() != "")
                        comboBox1.Items.Add(reader["EmployeeName"].ToString());
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
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspMarketPlanningSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EntryDate", SqlDbType.DateTime);
            comm.Parameters["@EntryDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@TargetMonth", SqlDbType.VarChar, 50);
            comm.Parameters["@TargetMonth"].Value = comboBox2.Text;
            
            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = comboBox1.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters["@Designation"].Value = textBox1.Text;
            
            comm.Parameters.Add("@TargetSale", SqlDbType.BigInt);
            comm.Parameters["@TargetSale"].Value = int.Parse(textBox2.Text);

            comm.Parameters.Add("@TotalSale", SqlDbType.BigInt);
            comm.Parameters["@TotalSale"].Value = int.Parse(textBox3.Text);

            comm.Parameters.Add("@Balance", SqlDbType.BigInt);
            comm.Parameters["@Balance"].Value = int.Parse(textBox4.Text);

            comm.Parameters.Add("@Lifter", SqlDbType.BigInt);
            comm.Parameters["@Lifter"].Value = int.Parse(textBox5.Text);

            comm.Parameters.Add("@NetMarketSale", SqlDbType.BigInt);
            comm.Parameters["@NetMarketSale"].Value = int.Parse(textBox6.Text);

            comm.Parameters.Add("@SalesPerchantage", SqlDbType.VarChar, 50);
            comm.Parameters["@SalesPerchantage"].Value = textBox7.Text;

            comm.Parameters.Add("@Withdral", SqlDbType.BigInt);
            comm.Parameters["@Withdral"].Value = int.Parse(textBox8.Text);

            comm.Parameters.Add("@Donation", SqlDbType.BigInt);
            comm.Parameters["@Donation"].Value = int.Parse(textBox9.Text);

            comm.Parameters.Add("@Conveyance", SqlDbType.BigInt);
            comm.Parameters["@Conveyance"].Value = int.Parse(textBox10.Text);

            comm.Parameters.Add("@MobileBill", SqlDbType.BigInt);
            comm.Parameters["@MobileBill"].Value = int.Parse(textBox11.Text);

            comm.Parameters.Add("@Others", SqlDbType.BigInt);
            comm.Parameters["@Others"].Value = int.Parse(textBox13.Text);

            comm.Parameters.Add("@Comments", SqlDbType.VarChar, 50);
            comm.Parameters["@Comments"].Value = textBox12.Text;

           

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
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "";
            textBox13.Text = "0";

            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarketPlanningForm_Load(object sender, EventArgs e)
        {
            PopulateComboboxEmployeeName();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private bool SearchSNNoByEmployee12345(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeSearchByEmployeeName", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 100);
            comm.Parameters["@EmployeeName"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["Designation"].ToString();                    
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            int a, b;

            a = int.Parse(textBox2.Text);
            b = int.Parse(textBox3.Text);

            textBox4.Text = "" + (a - b);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int a1, b1;

            a1 = int.Parse(textBox3.Text);
            b1 = int.Parse(textBox5.Text);

            textBox6.Text = "" + (a1 - b1);

            int a2, b2;

            a2 = int.Parse(textBox2.Text);
            b2 = int.Parse(textBox6.Text);

            textBox7.Text = "" + ((b2 * 100)/ a2);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNoByEmployee12345(comboBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SearchSNNoByEmployee(comboBox2.Text);
        }
        private void SearchSNNoByEmployee(string sn)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM tblMarketPlanning WHERE TargetMonth = @TargetMonth", conn);

            comm.Parameters.Add("@TargetMonth", SqlDbType.VarChar, 100);
            comm.Parameters["@TargetMonth"].Value = comboBox2.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["TargetMonth"].ToString(), reader["EmployeeName"].ToString(), reader["Designation"].ToString(), reader["TargetSale"].ToString(), reader["TotalSale"].ToString(), reader["Balance"].ToString(), reader["Lifter"].ToString(), reader["NetMarketSale"].ToString(), reader["SalesPerchantage"].ToString(), reader["Withdral"].ToString(), reader["Donation"].ToString(), reader["Conveyance"].ToString(), reader["MobileBill"].ToString(), reader["Others"].ToString(), reader["Comments"].ToString());
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
            UpdateData(textBox14.Text);
            this.SearchSNNoByEmployee(comboBox2.Text);
            Reset(); 
        }
        private void UpdateData(string dk)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE tblMarketPlanning SET TargetMonth = @TargetMonth, EmployeeName = @EmployeeName, Designation = @Designation, TargetSale = @TargetSale, TotalSale = @TotalSale, Balance = @Balance, Lifter = @Lifter, NetMarketSale = @NetMarketSale, SalesPerchantage = @SalesPerchantage, Withdral = @Withdral, Donation = @Donation, Conveyance = @Conveyance, MobileBill = @MobileBill, Others = @Others, Comments = @Comments WHERE AutoId = @AutoId", conn);

            comm.Parameters.Add("@TargetMonth", SqlDbType.VarChar, 50);
            comm.Parameters["@TargetMonth"].Value = comboBox2.Text;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = comboBox1.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters["@Designation"].Value = textBox1.Text;
            
            comm.Parameters.Add("@TargetSale", SqlDbType.BigInt);
            comm.Parameters["@TargetSale"].Value = int.Parse(textBox2.Text);

            comm.Parameters.Add("@TotalSale", SqlDbType.BigInt);
            comm.Parameters["@TotalSale"].Value = int.Parse(textBox3.Text);

            comm.Parameters.Add("@Balance", SqlDbType.BigInt);
            comm.Parameters["@Balance"].Value = int.Parse(textBox4.Text);

            comm.Parameters.Add("@Lifter", SqlDbType.BigInt);
            comm.Parameters["@Lifter"].Value = int.Parse(textBox5.Text);

            comm.Parameters.Add("@NetMarketSale", SqlDbType.BigInt);
            comm.Parameters["@NetMarketSale"].Value = int.Parse(textBox6.Text);

            comm.Parameters.Add("@SalesPerchantage", SqlDbType.VarChar, 50);
            comm.Parameters["@SalesPerchantage"].Value = textBox7.Text;

            comm.Parameters.Add("@Withdral", SqlDbType.BigInt);
            comm.Parameters["@Withdral"].Value = int.Parse(textBox8.Text);

            comm.Parameters.Add("@Donation", SqlDbType.BigInt);
            comm.Parameters["@Donation"].Value = int.Parse(textBox9.Text);

            comm.Parameters.Add("@Conveyance", SqlDbType.BigInt);
            comm.Parameters["@Conveyance"].Value = int.Parse(textBox10.Text);

            comm.Parameters.Add("@MobileBill", SqlDbType.BigInt);
            comm.Parameters["@MobileBill"].Value = int.Parse(textBox11.Text);

            comm.Parameters.Add("@Others", SqlDbType.BigInt);
            comm.Parameters["@Others"].Value = int.Parse(textBox13.Text);

            comm.Parameters.Add("@Comments", SqlDbType.VarChar, 50);
            comm.Parameters["@Comments"].Value = textBox12.Text;

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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
        }
    }
}
