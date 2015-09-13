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
    public partial class AfterManufactureStockOut : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;


        public AfterManufactureStockOut()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
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

                int Qty, Price;

                Qty = int.Parse(textBox21.Text);
                Price = int.Parse(textBox17.Text);

                textBox17.Text = "" + (Qty + Price);
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
        private void textBox4_Leave(object sender, EventArgs e)
        {
            double A, B;

            A = double.Parse(textBox4.Text);
            B = double.Parse(textBox5.Text);

            textBox5.Text = "" + (B - A);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            double Qty, Price;

            Qty = double.Parse(textBox4.Text);
            Price = double.Parse(textBox6.Text);

            textBox7.Text = "" + (Qty * Price);
            textBox21.Text = "" + (Qty * Price);
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
        private void PopulateComboboxEmployeeName()
        {
            comboBox3.Items.Clear();

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
                        comboBox3.Items.Add(reader["EmployeeName"].ToString());
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
            DialogResult result = MessageBox.Show("Do You Really Want to Save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Factory Name can not be blank.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (this.DuplicateBill())
                    {
                        MessageBox.Show("Bill No Duplicate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ClientsAccountSave();
                        string[] data = new string[50];
                        bool logic = true;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                if (dataGridView1.Rows[i].Cells[j].Value != null)
                                    data[j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                                else
                                    data[j] = "0";

                            logic = Insert(data);
                            UpdateCustomerDatabase(comboBox1.Text);
                            SaveAccountStatement();
                            PopulateComboboxFactoryName();
                            PopulateComboboxProductName();
                            PopulateComboboxEmployeeName();
                            
                            if (!logic)
                                break;
                            //RefreshAll();
                        }
                        if (logic)
                        {
                            MessageBox.Show("Successfully Done and Also Stock Updated.");
                        }
                        else
                            MessageBox.Show("Not Done");
                    }
                }
            }
        }
        private void RefreshAll()
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

            textBox8.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox22.Text = "";

            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";

            dataGridView1.Rows.Clear();
        }
        private bool DuplicateBill()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From TbAfterManufactureStockOut Where BillNo = '" + textBox14.Text + "'";

            SqlDataReader reader = null;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    if (textBox14.Text == reader["BillNo"].ToString())
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
        private void ClientsAccountSave()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspClientsAccountSave", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@FactoryAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@FactoryAddress"].Value = textBox9.Text;

            comm.Parameters.Add("@FactoryPhoneNo", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryPhoneNo"].Value = textBox24.Text;

            comm.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
            comm.Parameters["@PaymentDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@TotalAmount", SqlDbType.Float);
            comm.Parameters["@TotalAmount"].Value = double.Parse(textBox18.Text);

            comm.Parameters.Add("@Amount", SqlDbType.Float);
            comm.Parameters["@Amount"].Value = double.Parse(textBox19.Text);

            comm.Parameters.Add("@OrderNo", SqlDbType.VarChar, 50);
            comm.Parameters["@OrderNo"].Value = textBox13.Text;

            comm.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50);
            comm.Parameters["@InvoiceNo"].Value = textBox14.Text;

            comm.Parameters.Add("@Notes", SqlDbType.VarChar, 500);
            comm.Parameters["@Notes"].Value = textBox25.Text;

            comm.Parameters.Add("@LateDue", SqlDbType.Float);
            comm.Parameters["@LateDue"].Value = double.Parse(textBox23.Text);

            comm.Parameters.Add("@CreateDate", SqlDbType.DateTime);
            comm.Parameters["@CreateDate"].Value = dateTimePicker2.Value.Date;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //MessageBox.Show("Successfully Account Save.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void UpdateCustomerDatabase(string gf)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("UPDATE TbFactory SET LateDue = @LateDue WHERE FactoryName = @FactoryName", conn);

            comm.Parameters.Add("@LateDue", SqlDbType.Float);
            comm.Parameters["@LateDue"].Value = double.Parse(textBox23.Text);

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
        private void SaveAccountStatement()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspAccountStatementSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@StockOutDate", SqlDbType.DateTime);
            comm.Parameters["@StockOutDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            comm.Parameters["@BillNo"].Value = textBox14.Text;
            
            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@SubTotalAmount", SqlDbType.BigInt);
            comm.Parameters["@SubTotalAmount"].Value = double.Parse(textBox17.Text);

            comm.Parameters.Add("@Discount", SqlDbType.BigInt);
            comm.Parameters["@Discount"].Value = double.Parse(textBox16.Text);

            comm.Parameters.Add("@NetTotalAmount", SqlDbType.BigInt);
            comm.Parameters["@NetTotalAmount"].Value = double.Parse(textBox18.Text);

            comm.Parameters.Add("@Payable", SqlDbType.BigInt);
            comm.Parameters["@Payable"].Value = double.Parse(textBox19.Text);

            comm.Parameters.Add("@Due", SqlDbType.BigInt);
            comm.Parameters["@Due"].Value = double.Parse(textBox20.Text);

            comm.Parameters.Add("@CreateDate", SqlDbType.DateTime);
            comm.Parameters["@CreateDate"].Value = dateTimePicker2.Value.Date;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //MessageBox.Show("Successfully Save.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool Insert(string[] data)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspAfterManufactureStockOutSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@StockOutDate", SqlDbType.DateTime);
            comm.Parameters["@StockOutDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@OrderNo", SqlDbType.VarChar, 50);
            comm.Parameters["@OrderNo"].Value = textBox13.Text;

            comm.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);
            comm.Parameters["@BillNo"].Value = textBox14.Text;

            comm.Parameters.Add("@ChallanNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ChallanNo"].Value = textBox15.Text;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            comm.Parameters.Add("@FactoryUnit", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryUnit"].Value = textBox22.Text;

            comm.Parameters.Add("@FactoryAddress", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryAddress"].Value = textBox9.Text;

            comm.Parameters.Add("@HeadOffice", SqlDbType.VarChar, 50);
            comm.Parameters["@HeadOffice"].Value = textBox8.Text;

            comm.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50);
            comm.Parameters["@CustomerName"].Value = comboBox4.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 50);
            comm.Parameters["@Designation"].Value = textBox12.Text;

            comm.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ContactNo"].Value = textBox11.Text;

            comm.Parameters.Add("@Email", SqlDbType.VarChar, 50);
            comm.Parameters["@Email"].Value = textBox10.Text;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = comboBox3.Text;

            comm.Parameters.Add("@EmployeeDesignation", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeDesignation"].Value = textBox3.Text;

            comm.Parameters.Add("@EmployeeContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeContactNo"].Value = textBox2.Text;

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

            comm.Parameters.Add("@SubTotalAmount", SqlDbType.BigInt);
            comm.Parameters["@SubTotalAmount"].Value = double.Parse(textBox17.Text);

            comm.Parameters.Add("@Discount", SqlDbType.BigInt);
            comm.Parameters["@Discount"].Value = double.Parse(textBox16.Text);

            comm.Parameters.Add("@NetTotalAmount", SqlDbType.BigInt);
            comm.Parameters["@NetTotalAmount"].Value = double.Parse(textBox18.Text);

            comm.Parameters.Add("@Payable", SqlDbType.BigInt);
            comm.Parameters["@Payable"].Value = double.Parse(textBox19.Text);

            comm.Parameters.Add("@Due", SqlDbType.BigInt);
            comm.Parameters["@Due"].Value = double.Parse(textBox20.Text);

            comm.Parameters.Add("@CreateDate", SqlDbType.DateTime);
            comm.Parameters["@CreateDate"].Value = dateTimePicker2.Value.Date;


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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNo(comboBox1.Text);
            SearchItem123(comboBox1.Text);
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
                    textBox9.Text = reader["FactoryAddress"].ToString();
                    textBox8.Text = reader["HeadOffice"].ToString();
                    textBox23.Text = reader["LateDue"].ToString();
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
        private bool SearchItem123(string nick)
        {
            comboBox4.Items.Clear();
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspFactorySearchByFactoryName123", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            comm.Parameters["@FactoryName"].Value = comboBox1.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    comboBox4.Items.Add(reader["CustomerName"].ToString());
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNoByEmployee(comboBox4.Text);
        }
        private bool SearchSNNoByEmployee(string sn)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspCustomerSearchByCustomerName", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@CustomerName", SqlDbType.VarChar, 100);
            comm.Parameters["@CustomerName"].Value = sn.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox12.Text = reader["Designation"].ToString();
                    textBox11.Text = reader["ContactNo"].ToString();
                    textBox10.Text = reader["Email"].ToString();
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

        private void AfterManufactureStockOut_Load(object sender, EventArgs e)
        {
            PopulateComboboxFactoryName();
            PopulateComboboxProductName();
            PopulateComboboxEmployeeName();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSNNoByEmployee12345(comboBox3.Text);
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
                    textBox3.Text = reader["Designation"].ToString();
                    textBox2.Text = reader["ContactNo"].ToString();                    
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

        private void textBox16_Leave(object sender, EventArgs e)
        {
            double Qty, Price;

            Qty = double.Parse(textBox17.Text);
            Price = double.Parse(textBox16.Text);

            textBox18.Text = "" + (Qty - Price);
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            double Qty, Price;

            Qty = double.Parse(textBox18.Text);
            Price = double.Parse(textBox19.Text);

            textBox20.Text = "" + (Qty - Price);

            double A, B;

            A = double.Parse(textBox23.Text);
            B = double.Parse(textBox20.Text);

            textBox23.Text = "" + (A + B);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

            textBox8.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox22.Text = "";

            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";

            dataGridView1.Rows.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}