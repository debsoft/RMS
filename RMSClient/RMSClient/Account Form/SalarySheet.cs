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
    public partial class SalarySheet : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public SalarySheet()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox4.ReadOnly = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SalarySheet_Load(object sender, EventArgs e)
        {
            //comboBox4.Text = this.ReadLastMonth();
            //comboBox2.Text = this.ReadLastYear();
            PopulateComboboxReason();
            PopulateComboboxPresentReason();
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox3.Visible = false;
            label1.Visible = false;
            //groupBox5.Visible = false;
        }
        private void PopulateComboboxPresentReason()
        {
            comboBox3.Items.Clear();

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
                        comboBox3.Items.Add(reader["PresentReason"].ToString());
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
        private void PopulateComboboxReason()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetPopulateHoldReason", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["HoldReason"].ToString() != "")
                        comboBox1.Items.Add(reader["HoldReason"].ToString());
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
        private string ReadLastPresentDay()
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


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Really Want to Save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Successfully Save");

                string[] data = new string[50];
                bool logic = true;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            data[j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        else
                            data[j] = "0";
                    PopulateComboboxReason();
                    logic = Insert(data);
                    if (!logic)
                        break;
                }
                if (logic)
                {
                    //MessageBox.Show("Successfully Save.");
                }
                else
                    MessageBox.Show("Not Done");
                Reset();
            }

            
        }
        //private string DuplicateId()
        //{
        //    string ret = "";
        //    SqlConnection conn = new SqlConnection(this.connectionString);
        //    String sql1 = "Select * From TbSalarySheet Where EmployeeID = '" + textBox5.Text + "' AND SalaryMonth = '" + comboBox4.Text + "'";

        //    SqlDataReader reader = null;

        //    try
        //    {
        //        conn.Open();

        //        SqlCommand comm = new SqlCommand(sql1, conn);
        //        reader = comm.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            if (textBox5.Text == reader["EmployeeID"].ToString())
        //                MessageBox.Show("Already paid salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return ret;
        //}
        private bool Insert(string[] data)
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

            comm.Parameters["@EmployeeID"].Value = data[1];
            comm.Parameters["@SalaryMonth"].Value = data[2];
            comm.Parameters["@SalaryYear"].Value = data[3];
            comm.Parameters["@PresentDay"].Value = int.Parse(data[4]);
            comm.Parameters["@InitialSalary"].Value = int.Parse(data[5]);
            comm.Parameters["@BasicSalary"].Value = double.Parse(data[6]);
            comm.Parameters["@HouseRent"].Value = double.Parse(data[7]);
            comm.Parameters["@Convey"].Value = double.Parse(data[8]);
            comm.Parameters["@Medical"].Value = double.Parse(data[9]);
            comm.Parameters["@Mobile"].Value = double.Parse(data[10]);
            comm.Parameters["@Internet"].Value = int.Parse(data[11]);
            comm.Parameters["@Arrear"].Value = int.Parse(data[12]);
            comm.Parameters["@Others"].Value = int.Parse(data[13]);
            comm.Parameters["@Absent"].Value = int.Parse(data[14]);
            comm.Parameters["@TDS"].Value = int.Parse(data[15]);
            comm.Parameters["@Advance"].Value = int.Parse(data[16]);
            comm.Parameters["@DeductionHold"].Value = int.Parse(data[17]);
            comm.Parameters["@DeductionOthers"].Value = int.Parse(data[18]);
            comm.Parameters["@NetSalary"].Value = int.Parse(data[19]);
            comm.Parameters["@HoldSalary"].Value = data[20];
            comm.Parameters["@HoldReason"].Value = data[21];
            comm.Parameters["@PresentReason"].Value = data[22];


            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //MessageBox.Show("Successfully Done", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            textBox2.Text = "0";
            textBox20.Text = "";

            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData(textBox3.Text);
            Reset();
            PopulateComboboxReason();
        }

        private void UpdateData(string sm)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetUpdate", conn);
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

            comm.Parameters["@EmployeeID"].Value = textBox5.Text;
            comm.Parameters["@SalaryMonth"].Value = comboBox4.Text;
            comm.Parameters["@SalaryYear"].Value = comboBox2.Text;
            comm.Parameters["@PresentDay"].Value = int.Parse(textBox2.Text);
            comm.Parameters["@InitialSalary"].Value = int.Parse(textBox6.Text);
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
            comm.Parameters["@NetSalary"].Value = int.Parse(textBox20.Text);
            comm.Parameters["@HoldSalary"].Value = textBox1.Text;
            comm.Parameters["@HoldReason"].Value = comboBox1.Text;
            comm.Parameters["@PresentReason"].Value = comboBox3.Text;

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

        private void button2_Click(object sender, EventArgs e)
        {



        }
        private bool EditData(string empid, string smonth)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetEdit", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = empid.Trim();

            comm.Parameters.Add("@SalaryMonth", SqlDbType.VarChar, 50);
            comm.Parameters["@SalaryMonth"].Value = smonth.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    comboBox2.Text = reader["SalaryYear"].ToString();
                    textBox2.Text = reader["PresentDay"].ToString();
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

        private void textBox12_Leave(object sender, EventArgs e)
        {


        }

        private void textBox18_Leave(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox22.Visible = true;
            
            if (comboBox4.Text == "January")
                textBox22.Text = "31";
            if (comboBox4.Text == "February")
                textBox22.Text = "29";
            if (comboBox4.Text == "March")
                textBox22.Text = "31";
            if (comboBox4.Text == "April")
                textBox22.Text = "30";
            if (comboBox4.Text == "May")
                textBox22.Text = "31";
            if (comboBox4.Text == "June")
                textBox22.Text = "30";
            if (comboBox4.Text == "July")
                textBox22.Text = "31";
            if (comboBox4.Text == "August")
                textBox22.Text = "31";
            if (comboBox4.Text == "September")
                textBox22.Text = "30";
            if (comboBox4.Text == "October")
                textBox22.Text = "31";
            if (comboBox4.Text == "November")
                textBox22.Text = "30";
            if (comboBox4.Text == "December")
                textBox22.Text = "31";
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
        private void ReadData(string snn, string nss)
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            //SqlCommand comm = new SqlCommand("dbo.UspSalarySheetEditWithGrid", conn);
            SqlCommand comm = new SqlCommand("dbo.UspSalarySheetEditWithGrid123", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@SalaryMonth", SqlDbType.VarChar, 100);
            comm.Parameters["@SalaryMonth"].Value = comboBox4.Text;

            comm.Parameters.Add("@SalaryYear", SqlDbType.VarChar, 100);
            comm.Parameters["@SalaryYear"].Value = comboBox2.Text;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["EmployeeID"].ToString(), reader["SalaryMonth"].ToString(), reader["SalaryYear"].ToString(), reader["PresentDay"].ToString(), reader["InitialSalary"].ToString(), reader["BasicSalary"].ToString(), reader["HouseRent"].ToString(), reader["Convey"].ToString(), reader["Medical"].ToString(), reader["Mobile"].ToString(), reader["Internet"].ToString(), reader["Arrear"].ToString(), reader["Others"].ToString(), reader["Absent"].ToString(), reader["TDS"].ToString(), reader["Advance"].ToString(), reader["DeductionHold"].ToString(), reader["DeductionOthers"].ToString(), reader["NetSalary"].ToString());
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
                textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                textBox16.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                textBox17.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                textBox18.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                textBox19.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                textBox20.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            }
            //textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); 

            textBox4.Text = ""+(textBox2.Text);
            textBox21.Text = "" + (textBox20.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Really Want to Change?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Column3"].Value = comboBox4.Text;
                    row.Cells["Column4"].Value = comboBox2.Text;
                    row.Cells["Column2"].Value = textBox22.Text;

                }
                MessageBox.Show("Successfully Change ...");
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ReadData(comboBox4.Text, comboBox2.Text);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = "1";
                comboBox1.Visible = true;
                label1.Visible = true;
            }
            if (!checkBox1.Checked)
            {
                textBox1.Text = "0";
                comboBox1.Visible = false;
                label1.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //groupBox5.Visible = true;
            
        }
        private void NetSalaryCal()
        {
            double Initial, PresentDay;

            Initial = double.Parse(textBox6.Text);
            PresentDay = double.Parse(textBox2.Text);            

            textBox6.Text = "" + ((Initial/PresentDay)*PresentDay);                      
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //NetSalaryCal();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //NetSalaryCal();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //textBox1.Text = "1";
                comboBox3.Visible = true;                
            }
            if (!checkBox2.Checked)
            {
                //textBox1.Text = "0";
                comboBox3.Visible = false;                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            int PresentDay, NetSalary, Absent, PresentDay1, NetSalary1;

            PresentDay = int.Parse(textBox2.Text);
            PresentDay1 = int.Parse(textBox4.Text);
            NetSalary = int.Parse(textBox20.Text);
            NetSalary1 = int.Parse(textBox21.Text);
            Absent = int.Parse(textBox15.Text);           

            if(PresentDay1!=0)
            textBox20.Text = "" + ((NetSalary / PresentDay1)*PresentDay);                        
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            int NetSalary1, NetSalary;

            NetSalary = int.Parse(textBox20.Text);
            NetSalary1 = int.Parse(textBox21.Text);

            textBox15.Text = "" + (NetSalary1 - NetSalary);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}