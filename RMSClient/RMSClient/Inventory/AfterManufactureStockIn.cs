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

namespace PayRoll.Inventory
{
    public partial class AfterManufactureStockIn : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;


        public AfterManufactureStockIn()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void AfterManufactureStockIn_Load(object sender, EventArgs e)
        {
            PopulateComboboxProductName();
            PopulateComboboxSupplierName();
        }
        private void PopulateComboboxSupplierName()
        {
            cboSupplierName.Items.Clear();
            
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT SupplierName FROM TbAfterManufactureStockIn ORDER BY SupplierName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["SupplierName"].ToString() != "")
                        cboSupplierName.Items.Add(reader["SupplierName"].ToString());
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
        private void PopulateComboboxProductName()
        {
            comboBox2.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspProductNamePopulate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ProductName"].ToString() != "")
                        comboBox2.Items.Add(reader["ProductName"].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Product Name !!!");
            }
            else
            {
                UpdateStockItem(comboBox2.Text);
                dataGridView1.Rows.Add(comboBox2.Text, textBox4.Text, textBox1.Text, textBox6.Text, textBox7.Text);
                comboBox2.Text = "";
                textBox4.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox5.Text = "0";
                textBox1.Text = "";

                comboBox2.Focus();
            }
        }
        private void UpdateStockItem(string opr)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspUpdateAfterManufactureStock", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@Qty", SqlDbType.BigInt);
            comm.Parameters["@Qty"].Value = int.Parse(textBox5.Text);

            comm.Parameters.Add("@ProductName", SqlDbType.VarChar, 100);
            comm.Parameters["@ProductName"].Value = comboBox2.Text;

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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Really Want to Save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string[] data = new string[50];
                bool logic = true;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            data[j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        else
                            data[j] = "0";

                    logic = Insert(data);
                    PopulateComboboxProductName();
                    PopulateComboboxSupplierName();

                    if (!logic)
                        break;
                }
                if (logic)
                {
                    MessageBox.Show("Successfully Done and Also Stock Updated.");
                }
                else
                    MessageBox.Show("Not Done");
            }
        }
        private bool Insert(string[] data)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspAfterManufactureStockInSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@StockInDate", SqlDbType.DateTime);
            comm.Parameters["@StockInDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@SupplierName", SqlDbType.VarChar, 50);
            comm.Parameters["@SupplierName"].Value = cboSupplierName.Text;

            comm.Parameters.Add("@Address", SqlDbType.VarChar, 500);
            comm.Parameters["@Address"].Value = txtAddress.Text;

            comm.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ContactNo"].Value = txtContactNo.Text;

            comm.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
            comm.Parameters["@ProductName"].Value = data[0];

            comm.Parameters.Add("@Qty", SqlDbType.VarChar, 50);
            comm.Parameters["@Qty"].Value = data[1];

            comm.Parameters.Add("@Unit", SqlDbType.VarChar, 50);
            comm.Parameters["@Unit"].Value = data[2];

            comm.Parameters.Add("@PricePerUnit", SqlDbType.VarChar, 50);
            comm.Parameters["@PricePerUnit"].Value = data[3];

            comm.Parameters.Add("@TotalPrice", SqlDbType.VarChar, 50);
            comm.Parameters["@TotalPrice"].Value = data[4];


            try
            {
                conn.Open();
                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                ret = false;
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNo1(comboBox2.Text);
        }
        private bool SearchSNNo1(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspStockSearchByProductName", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@ProductName", SqlDbType.VarChar, 100);
            comm.Parameters["@ProductName"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["Unit"].ToString();
                    textBox5.Text = reader["Qty"].ToString();
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

        private void textBox4_Leave(object sender, EventArgs e)
        {
            double A, B;

            A = double.Parse(textBox4.Text);
            B = double.Parse(textBox5.Text);

            textBox5.Text = "" + (B + A);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            double Qty, Price;

            Qty = double.Parse(textBox4.Text);
            Price = double.Parse(textBox6.Text);

            textBox7.Text = "" + (Qty * Price);
        }

        private void cboSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNo121(cboSupplierName.Text);
        }
        private bool SearchSNNo121(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbAfterManufactureStockIn WHERE SupplierName = @SupplierName", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@SupplierName", SqlDbType.VarChar, 100);
            comm.Parameters["@SupplierName"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    txtAddress.Text = reader["Address"].ToString();
                    txtContactNo.Text = reader["ContactNo"].ToString();
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