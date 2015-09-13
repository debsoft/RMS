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

namespace PayRoll.Forms
{
    public partial class LeaveForm : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public LeaveForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditData(comboBox1.Text);
        }
        private bool EditData(string empid)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM TbEmployeeDatabase WHERE EmployeeID = @EmployeeID", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = empid.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["EmployeeName"].ToString();
                    textBox3.Text = reader["Designation"].ToString();
                    textBox2.Text = reader["Location"].ToString(); 
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

        private void LeaveForm_Load(object sender, EventArgs e)
        {
            PopulateComboboxID();
            this.ReadDataDateWise();
        }
        private void PopulateComboboxID()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabasePopulateID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["EmployeeID"].ToString() != "")
                        comboBox1.Items.Add(reader["EmployeeID"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Select Leave Type Before Saved.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Save();
                Reset();
                dataGridView1.Visible = true;
                this.ReadDataDateWise();
            }
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspLeaveFormSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeID"].Value = comboBox1.Text;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = textBox1.Text;

            comm.Parameters.Add("@Location", SqlDbType.VarChar, 50);
            comm.Parameters["@Location"].Value = textBox1.Text;

            comm.Parameters.Add("@LeaveType", SqlDbType.VarChar, 50);
            comm.Parameters["@LeaveType"].Value = comboBox2.Text;

            comm.Parameters.Add("@LeaveFrom", SqlDbType.DateTime);
            comm.Parameters["@LeaveFrom"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@LeaveTo", SqlDbType.DateTime);
            comm.Parameters["@LeaveTo"].Value = dateTimePicker2.Value.Date;

            comm.Parameters.Add("@TotalDays", SqlDbType.BigInt);
            comm.Parameters["@TotalDays"].Value = int.Parse(textBox4.Text);

            comm.Parameters.Add("@Reason", SqlDbType.VarChar, 500);
            comm.Parameters["@Reason"].Value = textBox5.Text;

            comm.Parameters.Add("@Address", SqlDbType.VarChar, 500);
            comm.Parameters["@Address"].Value = txtAddress.Text;

            comm.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ContactNo"].Value = txtContactNo.Text;


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
            textBox3.Text = "";

            comboBox2.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "";

            txtAddress.Text = "";
            txtContactNo.Text = "";
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT *FROM LeaveForm ORDER BY LeaveFrom DESC", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["EmployeeID"].ToString(), reader["EmployeeName"].ToString(), reader["Location"].ToString(), reader["LeaveType"].ToString(), reader["LeaveFrom"].ToString(), reader["LeaveTo"].ToString(), reader["TotalDays"].ToString(), reader["Reason"].ToString(), reader["Address"].ToString(), reader["ContactNo"].ToString());
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
                      
            string nLabdate = "";
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Value.Date);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value.Date);

            nLabdate = (dt2 - dt1).TotalDays.ToString();

            textBox6.Text = nLabdate;

            textBox4.Text = "" + (int.Parse(textBox6.Text) + int.Parse(textBox7.Text));

            if (int.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Selected Date Format wrong.");
                textBox4.Text = "0";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string nLabdate = "";
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text);



            nLabdate = (dt2 - dt1).TotalDays.ToString();

            textBox6.Text = nLabdate;

            textBox4.Text = "" + (int.Parse(textBox6.Text) + int.Parse(textBox7.Text));

            if (int.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Selected Date Format wrong.");
                textBox4.Text = "0";
            }
        }
    }
}
