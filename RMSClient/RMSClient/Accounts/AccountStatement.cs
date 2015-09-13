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
    public partial class AccountStatement : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public AccountStatement()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void AccountStatement_Load(object sender, EventArgs e)
        {
            PopulateComboboxFactoryName();
        }
        private void PopulateComboboxFactoryName()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspStockOutBillNoPopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["BillNo"].ToString() != "")
                        comboBox1.Items.Add(reader["BillNo"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReadDataDateWise(comboBox1.Text);
            SearchBillWise(comboBox1.Text);
        }
        private bool SearchBillWise(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspBillWiseStockOutSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 100);
            comm.Parameters["@BillNo"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    comboBox2.Text = reader["FactoryName"].ToString();
                    dateTimePicker2.Text = reader["StockOutDate"].ToString();
                    textBox17.Text = reader["SubTotalAmount"].ToString();
                    textBox16.Text = reader["Discount"].ToString();
                    textBox18.Text = reader["NetTotalAmount"].ToString();
                    textBox19.Text = reader["Payable"].ToString();
                    textBox20.Text = reader["Due"].ToString();                    
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
        private void ReadDataDateWise(string bill)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspBillWiseStockOutSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            comm.Parameters["@BillNo"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["ProductName"].ToString(), reader["Qty"].ToString(), reader["Unit"].ToString(), reader["PricePerUnit"].ToString(), reader["TotalPrice"].ToString());
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

        private void textBox19_Leave(object sender, EventArgs e)
        {
            double Qty, Price;

            Qty = double.Parse(textBox18.Text);
            Price = double.Parse(textBox19.Text);

            textBox20.Text = "" + (Qty - Price);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateClientsAccount(comboBox1.Text);
            UpdateClientsAccountStockOut(comboBox1.Text);
        }
        private void UpdateClientsAccount(string opr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUpdateClientsAccount", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox2.Text;

            comm.Parameters.Add("@StockOutDate", SqlDbType.DateTime);
            comm.Parameters["@StockOutDate"].Value = dateTimePicker2.Value.Date;
            
            comm.Parameters.Add("@PaidDate", SqlDbType.DateTime);
            comm.Parameters["@PaidDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@SubTotalAmount", SqlDbType.Float);
            comm.Parameters["@SubTotalAmount"].Value = double.Parse(textBox17.Text);

            comm.Parameters.Add("@Discount", SqlDbType.Float);
            comm.Parameters["@Discount"].Value = double.Parse(textBox16.Text);

            comm.Parameters.Add("@NetTotalAmount", SqlDbType.Float);
            comm.Parameters["@NetTotalAmount"].Value = double.Parse(textBox18.Text);

            comm.Parameters.Add("@Payable", SqlDbType.Float);
            comm.Parameters["@Payable"].Value = double.Parse(textBox19.Text);

            comm.Parameters.Add("@Due", SqlDbType.Float);
            comm.Parameters["@Due"].Value = double.Parse(textBox20.Text);

            comm.Parameters.Add("@MoneyReceiptNo", SqlDbType.BigInt);
            comm.Parameters["@MoneyReceiptNo"].Value = int.Parse(textBox7.Text);

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 100);
            comm.Parameters["@BillNo"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated.");
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
        private void UpdateClientsAccountStockOut(string opr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUpdateClientsAccountStockOut", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@PaidDate", SqlDbType.DateTime);
            comm.Parameters["@PaidDate"].Value = dateTimePicker1.Value.Date;
            
            comm.Parameters.Add("@SubTotalAmount", SqlDbType.Float);
            comm.Parameters["@SubTotalAmount"].Value = double.Parse(textBox17.Text);

            comm.Parameters.Add("@Discount", SqlDbType.Float);
            comm.Parameters["@Discount"].Value = double.Parse(textBox16.Text);

            comm.Parameters.Add("@NetTotalAmount", SqlDbType.Float);
            comm.Parameters["@NetTotalAmount"].Value = double.Parse(textBox18.Text);

            comm.Parameters.Add("@Payable", SqlDbType.Float);
            comm.Parameters["@Payable"].Value = double.Parse(textBox19.Text);

            comm.Parameters.Add("@Due", SqlDbType.Float);
            comm.Parameters["@Due"].Value = double.Parse(textBox20.Text);

            comm.Parameters.Add("@MoneyReceiptNo", SqlDbType.BigInt);
            comm.Parameters["@MoneyReceiptNo"].Value = int.Parse(textBox7.Text);

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 100);
            comm.Parameters["@BillNo"].Value = comboBox1.Text;

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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            textBox7.Text = "0";
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";

            comboBox2.Text = "";
        }
    }
}