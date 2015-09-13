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
    public partial class CustomerAccountPosting : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public CustomerAccountPosting()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Really Want to Save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                double A, B;

                A = double.Parse(textBox3.Text);
                B = double.Parse(textBox4.Text);

                textBox3.Text = "" + (A - B);
                UpdateCustomerDatabase(comboBox1.Text);
                Save();
                Reset();
            }
        }
        private void UpdateCustomerDatabase(string gf)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE TbFactory SET LateDue = @LateDue WHERE FactoryName = @FactoryName", conn);

            comm.Parameters.Add("@LateDue", SqlDbType.Float);
            comm.Parameters["@LateDue"].Value = double.Parse(textBox3.Text);

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspClientsAccountSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@FactoryAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@FactoryAddress"].Value = textBox1.Text;

            comm.Parameters.Add("@FactoryPhoneNo", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryPhoneNo"].Value = textBox2.Text;

            comm.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
            comm.Parameters["@PaymentDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@TotalAmount", SqlDbType.Float);
            comm.Parameters["@TotalAmount"].Value = double.Parse(textBox7.Text);

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox4.Text);

            comm.Parameters.Add("@OrderNo", SqlDbType.VarChar, 50);
            comm.Parameters["@OrderNo"].Value = textBox8.Text;

            comm.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50);
            comm.Parameters["@InvoiceNo"].Value = textBox5.Text;
            
            comm.Parameters.Add("@Notes", SqlDbType.VarChar, 500);
            comm.Parameters["@Notes"].Value = textBox6.Text;

            comm.Parameters.Add("@LateDue", SqlDbType.Float);
            comm.Parameters["@LateDue"].Value = double.Parse(textBox3.Text);

            comm.Parameters.Add("@CreateDate", SqlDbType.DateTime);
            comm.Parameters["@CreateDate"].Value = dateTimePicker4.Value.Date;

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
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
        }

        private void CustomerAccountPosting_Load(object sender, EventArgs e)
        {
            PopulateComboboxFactoryName();
            PopulateComboboxInvoice();
        }
        private void PopulateComboboxInvoice()
        {
            comboBox3.Items.Clear();

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
                        comboBox3.Items.Add(reader["BillNo"].ToString());
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
            SearchSNNo(comboBox1.Text);  
        }
        private bool SearchSNNo(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspFactorySearchByFactoryName", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 100);
            comm.Parameters["@FactoryName"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["FactoryAddress"].ToString();
                    textBox2.Text = reader["FactoryPhoneNo"].ToString();
                    textBox3.Text = reader["LateDue"].ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchBillWise(comboBox3.Text);
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
    }
}