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
    public partial class AddMonthlySalary : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public AddMonthlySalary()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Insert();
            Reset();
            comboBox7.Text = this.ReadLastMonth();
            comboBox6.Text = this.ReadLastYear();
            textBox6.Text = this.ReadLastPresent();
        }
        private bool Insert()
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters.Add("@SalaryMonth", SqlDbType.VarChar, 20);
            comm.Parameters.Add("@SalaryYear", SqlDbType.VarChar, 10);
            comm.Parameters.Add("@PresentDay", SqlDbType.BigInt);
            comm.Parameters.Add("@InitialSalary", SqlDbType.BigInt);
            comm.Parameters.Add("@BasicSalary", SqlDbType.Float);
            comm.Parameters.Add("@HouseRent", SqlDbType.Float);
            comm.Parameters.Add("@Convey", SqlDbType.Float);
            comm.Parameters.Add("@Medical", SqlDbType.Float);
            comm.Parameters.Add("@Mobile", SqlDbType.Float);
            comm.Parameters.Add("@Internet", SqlDbType.BigInt);
            comm.Parameters.Add("@Arrear", SqlDbType.BigInt);
            comm.Parameters.Add("@Others", SqlDbType.BigInt);
            comm.Parameters.Add("@Absent", SqlDbType.BigInt);
            comm.Parameters.Add("@TDS", SqlDbType.BigInt);
            comm.Parameters.Add("@Advance", SqlDbType.BigInt);
            comm.Parameters.Add("@DeductionHold", SqlDbType.BigInt);
            comm.Parameters.Add("@DeductionOthers", SqlDbType.BigInt);
            comm.Parameters.Add("@NetSalary", SqlDbType.BigInt);
            comm.Parameters.Add("@HoldSalary", SqlDbType.VarChar, 1);
            comm.Parameters.Add("@HoldReason", SqlDbType.VarChar, 100);
            comm.Parameters.Add("@PresentReason", SqlDbType.VarChar, 100);

            comm.Parameters["@EmployeeID"].Value = comboBox1.Text;
            comm.Parameters["@SalaryMonth"].Value = comboBox7.Text;
            comm.Parameters["@SalaryYear"].Value = comboBox6.Text;
            comm.Parameters["@PresentDay"].Value = int.Parse(textBox6.Text);
            comm.Parameters["@InitialSalary"].Value = int.Parse(textBox20.Text);
            comm.Parameters["@BasicSalary"].Value = int.Parse(textBox7.Text);
            comm.Parameters["@HouseRent"].Value = int.Parse(textBox8.Text);
            comm.Parameters["@Convey"].Value = int.Parse(textBox9.Text);
            comm.Parameters["@Medical"].Value = int.Parse(textBox10.Text);
            comm.Parameters["@Mobile"].Value = int.Parse(textBox11.Text);
            comm.Parameters["@Internet"].Value = int.Parse(textBox12.Text);
            comm.Parameters["@Arrear"].Value = int.Parse(textBox13.Text);
            comm.Parameters["@Others"].Value = int.Parse(textBox14.Text);
            comm.Parameters["@Absent"].Value = int.Parse(textBox15.Text);
            comm.Parameters["@TDS"].Value = int.Parse(textBox16.Text);
            comm.Parameters["@Advance"].Value = int.Parse(textBox17.Text);
            comm.Parameters["@DeductionHold"].Value = int.Parse(textBox18.Text);
            comm.Parameters["@DeductionOthers"].Value = int.Parse(textBox19.Text);
            comm.Parameters["@NetSalary"].Value = int.Parse(textBox21.Text);
            comm.Parameters["@HoldSalary"].Value = textBox5.Text;
            comm.Parameters["@HoldReason"].Value = comboBox2.Text;
            comm.Parameters["@PresentReason"].Value = comboBox5.Text;


            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully Done", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private void Reset()
        {
            textBox1.Text = "";
            //textBox2.Text = "0";
            //textBox4.Text = "0";
            textBox3.Text = "";            

            comboBox1.Text = "";
            //comboBox2.Text = "";
            //comboBox4.Text = "";            
        }
        private void AddMonthlySalary_Load(object sender, EventArgs e)
        {
            PopulateComboboxID();
            //comboBox7.Text = this.ReadLastMonth();
            //comboBox6.Text = this.ReadLastYear();
            textBox6.Text = this.ReadLastPresent();
            comboBox5.Visible = false;
            PopulateComboboxPresentReason();
        }
        private void PopulateComboboxPresentReason()
        {
            comboBox5.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetPopulatePresentReason", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["PresentReason"].ToString() != "")
                        comboBox5.Items.Add(reader["PresentReason"].ToString());
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
        private string ReadLastMonth()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetReadLastMonth", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private string ReadLastYear()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetReadLastYear", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private string ReadLastPresent()
        {
            string ret = "";
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetReadLastPresentDay", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                ret = comm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                conn.Close();
            }
            return ret;
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            EditData(comboBox1.Text);
        }
        private bool EditData(string empid)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabaseEdit", conn);
            comm.CommandType = CommandType.StoredProcedure;

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
                    //textBox4.Text = reader["NetSalary"].ToString(); 
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

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //textBox1.Text = "1";
                comboBox5.Visible = true;
            }
            if (!checkBox2.Checked)
            {
                //textBox1.Text = "0";
                comboBox5.Visible = false;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            
        }
        private void SalaryCal()
        {
            int Initial, Basic, House, Convey, Medical, PF;

            //Initial = int.Parse(textBox20.Text);
            Basic = int.Parse(textBox7.Text);
            House = int.Parse(textBox8.Text);
            Convey = int.Parse(textBox9.Text);
            Medical = int.Parse(textBox10.Text);
            PF = int.Parse(textBox18.Text);

            //textBox7.Text = "" + (Basic * 0.65);
            textBox8.Text = "" + (Basic * 0.40);
            textBox9.Text = "" + (Basic * 0.05);
            textBox10.Text = "" + (Basic * 0.05);
            textBox18.Text = "" + (Basic * 0.10);

            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            NetSalary();  
        }
        private void NetSalary()
        {
            double Basic, House, Convey, Medical, Mobile, Internet, Arrear, Others, Absent, TDS, Advance, DeductionHold, DeductionOthers;

            Basic = double.Parse(textBox7.Text);
            House = double.Parse(textBox8.Text);
            Convey = double.Parse(textBox9.Text);
            Medical = double.Parse(textBox10.Text);

            Mobile = double.Parse(textBox11.Text);
            Internet = double.Parse(textBox12.Text);
            Arrear = double.Parse(textBox13.Text);
            Others = double.Parse(textBox14.Text);

            Absent = double.Parse(textBox15.Text);
            TDS = double.Parse(textBox16.Text);
            Advance = double.Parse(textBox17.Text);
            DeductionHold = double.Parse(textBox18.Text);
            DeductionOthers = double.Parse(textBox19.Text);

            textBox21.Text = "" + (((Basic + House + Convey + Medical) + (Mobile + Internet + Arrear + Others)) - (Absent + TDS + Advance + DeductionHold + DeductionOthers));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            SalaryCal();
            textBox11.Focus();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}