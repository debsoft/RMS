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
    public partial class DatabaseEntry : Form
    {
        public bool isUpdate = false;
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public DatabaseEntry()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.isUpdate)
            {               
                if (this.DuplicateID())
                    {
                        MessageBox.Show("Employee ID Duplicate!!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Save();
                        Reset();
                        PopulateComboboxDesignation();
                        PopulateComboboxDept();
                        PopulateComboboxSubDept();
                        PopulateComboboxID();
                        PopulateComboboxCompany();
                        PopulateComboboxBank();

                        Forms.AddPhoto ser = new Forms.AddPhoto(comboBox7.Text);
                        ser.Show();
                    }  
                
            }
            else
                MessageBox.Show("Please Press Update Button.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);        
        }
        private bool DuplicateID()
        {
            bool ret = false;
            SqlConnection conn = new SqlConnection(this.connectionString);
            String sql1 = "Select * From TbEmployeeDatabase Where EmployeeID = '" + comboBox7.Text + "'";

            SqlDataReader reader = null;
            
            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(sql1, conn);
                reader = comm.ExecuteReader();
                
                if (reader.Read())
                {
                    if (comboBox7.Text == reader["EmployeeID"].ToString())
                    {
                        ret = true;
                    }
                       // MessageBox.Show("Duplicate ID");              
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
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabaseSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = textBox1.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 30);
            comm.Parameters["@Designation"].Value = comboBox1.Text;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = comboBox7.Text;

            comm.Parameters.Add("@Department", SqlDbType.VarChar, 30);
            comm.Parameters["@Department"].Value = comboBox2.Text;

            comm.Parameters.Add("@SubDepartment", SqlDbType.VarChar, 50);
            comm.Parameters["@SubDepartment"].Value = comboBox3.Text;

            comm.Parameters.Add("@JoiningDate", SqlDbType.DateTime);
            comm.Parameters["@JoiningDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@BloodGroup", SqlDbType.VarChar, 10);
            comm.Parameters["@BloodGroup"].Value = comboBox4.Text;

            comm.Parameters.Add("@Location", SqlDbType.VarChar, 30);
            comm.Parameters["@Location"].Value = comboBox5.Text;

            comm.Parameters.Add("@EmployeeNature", SqlDbType.VarChar, 30);
            comm.Parameters["@EmployeeNature"].Value = comboBox6.Text;

            comm.Parameters.Add("@Bank", SqlDbType.VarChar, 50);
            comm.Parameters["@Bank"].Value = comboBox8.Text;

            comm.Parameters.Add("@BankAccount", SqlDbType.VarChar, 50);
            comm.Parameters["@BankAccount"].Value = textBox2.Text;

            comm.Parameters.Add("@DateofBirth", SqlDbType.DateTime);
            comm.Parameters["@DateofBirth"].Value = dateTimePicker2.Value.Date;

            comm.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
            comm.Parameters["@EmailAddress"].Value = textBox5.Text;

            comm.Parameters.Add("@PresentAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@PresentAddress"].Value = textBox3.Text;

            comm.Parameters.Add("@PermanentAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@PermanentAddress"].Value = textBox4.Text;

            comm.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ContactNo"].Value = textBox6.Text;

            comm.Parameters.Add("@FatherName", SqlDbType.VarChar, 50);
            comm.Parameters["@FatherName"].Value = txtFatherName.Text;

            comm.Parameters.Add("@Nationality", SqlDbType.VarChar, 50);
            comm.Parameters["@Nationality"].Value = cboNationality.Text;

            comm.Parameters.Add("@Religion", SqlDbType.VarChar, 50);
            comm.Parameters["@Religion"].Value = cboReligion.Text;

            comm.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
            comm.Parameters["@Gender"].Value = cboGender.Text;

            comm.Parameters.Add("@MaritalStatus", SqlDbType.VarChar, 50);
            comm.Parameters["@MaritalStatus"].Value = cboMaritalStatus.Text;

            comm.Parameters.Add("@NationalID", SqlDbType.VarChar, 50);
            comm.Parameters["@NationalID"].Value = txtNationalID.Text;

            comm.Parameters.Add("@JobDetails", SqlDbType.VarChar, 500);
            comm.Parameters["@JobDetails"].Value = txtJobDetails.Text;

            comm.Parameters.Add("@DateOfConfirmation", SqlDbType.DateTime);
            comm.Parameters["@DateOfConfirmation"].Value = dTPConfirmation.Value.Date;

            comm.Parameters.Add("@Skill", SqlDbType.VarChar, 50);
            comm.Parameters["@Skill"].Value = txtSkill.Text;

            comm.Parameters.Add("@EducationalQualification", SqlDbType.VarChar, 50);
            comm.Parameters["@EducationalQualification"].Value = txtEducationalQuali.Text;

            comm.Parameters.Add("@Reference", SqlDbType.VarChar, 50);
            comm.Parameters["@Reference"].Value = txtReference.Text;

            comm.Parameters.Add("@DateOfLastIncrement", SqlDbType.DateTime);
            comm.Parameters["@DateOfLastIncrement"].Value = dTPLastIncDate.Value.Date;

            comm.Parameters.Add("@OriginalDocumentRecord", SqlDbType.VarChar, 50);
            comm.Parameters["@OriginalDocumentRecord"].Value = txtDocRecord.Text;
            
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //DuplicateID();
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
        }
        private void FindDuplicateID()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeIDSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = comboBox7.Text;            

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                //DuplicateID();
                //MessageBox.Show("Successfully Done", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duplicate ID", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            //comboBox7.Text = "";
            comboBox8.Text = "";

            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            cboGender.Text = "";
            cboMaritalStatus.Text = "";
            cboNationality.Text = "";
            cboReligion.Text = "";

            txtEducationalQuali.Text = "";
            txtFatherName.Text = "";
            txtNationalID.Text = "";
            txtReference.Text = "";
            txtSkill.Text = "";
            txtJobDetails.Text = "";
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.isUpdate = true;
            EditData(comboBox7.Text);
        }
        private bool EditData(string empid)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabaseEdit", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar,20);
            comm.Parameters["@EmployeeID"].Value = empid.Trim();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["EmployeeName"].ToString();
                    comboBox1.Text = reader["Designation"].ToString();
                    comboBox2.Text = reader["Department"].ToString();
                    comboBox3.Text = reader["SubDepartment"].ToString();
                    dateTimePicker1.Text = reader["JoiningDate"].ToString();
                    comboBox4.Text = reader["BloodGroup"].ToString();
                    comboBox5.Text = reader["Location"].ToString();
                    comboBox6.Text = reader["EmployeeNature"].ToString();
                    comboBox8.Text = reader["Bank"].ToString();
                    textBox2.Text = reader["BankAccount"].ToString();
                    dateTimePicker2.Text = reader["DateofBirth"].ToString();
                    textBox5.Text = reader["EmailAddress"].ToString();
                    textBox6.Text = reader["ContactNo"].ToString();
                    textBox3.Text = reader["PresentAddress"].ToString();
                    textBox4.Text = reader["PermanentAddress"].ToString();
                    txtFatherName.Text = reader["FatherName"].ToString();
                    cboNationality.Text = reader["Nationality"].ToString();
                    cboReligion.Text = reader["Religion"].ToString();
                    cboGender.Text = reader["Gender"].ToString();
                    cboMaritalStatus.Text = reader["MaritalStatus"].ToString();
                    txtNationalID.Text = reader["NationalID"].ToString();
                    txtJobDetails.Text = reader["JobDetails"].ToString();
                    dTPConfirmation.Text = reader["DateOfConfirmation"].ToString();
                    txtSkill.Text = reader["Skill"].ToString();
                    txtEducationalQuali.Text = reader["EducationalQualification"].ToString();
                    txtReference.Text = reader["Reference"].ToString();
                    dTPLastIncDate.Text = reader["DateOfLastIncrement"].ToString();
                    txtDocRecord.Text = reader["OriginalDocumentRecord"].ToString();                    
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.isUpdate)
            {
                UpdateData();
                Reset();
                PopulateComboboxDesignation();
                PopulateComboboxDept();
                PopulateComboboxSubDept();
                PopulateComboboxID();
                PopulateComboboxCompany();
                PopulateComboboxBank();
            }
            else
                MessageBox.Show("Please Select Data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateData()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabaseUpdate", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeName"].Value = textBox1.Text;

            comm.Parameters.Add("@Designation", SqlDbType.VarChar, 30);
            comm.Parameters["@Designation"].Value = comboBox1.Text;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            comm.Parameters["@EmployeeID"].Value = comboBox7.Text;

            comm.Parameters.Add("@Department", SqlDbType.VarChar, 30);
            comm.Parameters["@Department"].Value = comboBox2.Text;

            comm.Parameters.Add("@SubDepartment", SqlDbType.VarChar, 50);
            comm.Parameters["@SubDepartment"].Value = comboBox3.Text;

            comm.Parameters.Add("@JoiningDate", SqlDbType.DateTime);
            comm.Parameters["@JoiningDate"].Value = dateTimePicker1.Value.Date;

            comm.Parameters.Add("@BloodGroup", SqlDbType.VarChar, 10);
            comm.Parameters["@BloodGroup"].Value = comboBox4.Text;

            comm.Parameters.Add("@Location", SqlDbType.VarChar, 30);
            comm.Parameters["@Location"].Value = comboBox5.Text;

            comm.Parameters.Add("@EmployeeNature", SqlDbType.VarChar, 30);
            comm.Parameters["@EmployeeNature"].Value = comboBox6.Text;

            comm.Parameters.Add("@Bank", SqlDbType.VarChar, 50);
            comm.Parameters["@Bank"].Value = comboBox8.Text;

            comm.Parameters.Add("@BankAccount", SqlDbType.VarChar, 50);
            comm.Parameters["@BankAccount"].Value = textBox2.Text;

            comm.Parameters.Add("@DateofBirth", SqlDbType.DateTime);
            comm.Parameters["@DateofBirth"].Value = dateTimePicker2.Value.Date;

            comm.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
            comm.Parameters["@EmailAddress"].Value = textBox5.Text;

            comm.Parameters.Add("@PresentAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@PresentAddress"].Value = textBox3.Text;

            comm.Parameters.Add("@PermanentAddress", SqlDbType.VarChar, 500);
            comm.Parameters["@PermanentAddress"].Value = textBox4.Text;

            comm.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
            comm.Parameters["@ContactNo"].Value = textBox6.Text;
            
            comm.Parameters.Add("@FatherName", SqlDbType.VarChar, 50);
            comm.Parameters["@FatherName"].Value = txtFatherName.Text;

            comm.Parameters.Add("@Nationality", SqlDbType.VarChar, 50);
            comm.Parameters["@Nationality"].Value = cboNationality.Text;

            comm.Parameters.Add("@Religion", SqlDbType.VarChar, 50);
            comm.Parameters["@Religion"].Value = cboReligion.Text;

            comm.Parameters.Add("@Gender", SqlDbType.VarChar, 50);
            comm.Parameters["@Gender"].Value = cboGender.Text;

            comm.Parameters.Add("@MaritalStatus", SqlDbType.VarChar, 50);
            comm.Parameters["@MaritalStatus"].Value = cboMaritalStatus.Text;

            comm.Parameters.Add("@NationalID", SqlDbType.VarChar, 50);
            comm.Parameters["@NationalID"].Value = txtNationalID.Text;

            comm.Parameters.Add("@JobDetails", SqlDbType.VarChar, 500);
            comm.Parameters["@JobDetails"].Value = txtJobDetails.Text;

            comm.Parameters.Add("@DateOfConfirmation", SqlDbType.DateTime);
            comm.Parameters["@DateOfConfirmation"].Value = dTPConfirmation.Value.Date;

            comm.Parameters.Add("@Skill", SqlDbType.VarChar, 50);
            comm.Parameters["@Skill"].Value = txtSkill.Text;

            comm.Parameters.Add("@EducationalQualification", SqlDbType.VarChar, 50);
            comm.Parameters["@EducationalQualification"].Value = txtEducationalQuali.Text;

            comm.Parameters.Add("@Reference", SqlDbType.VarChar, 50);
            comm.Parameters["@Reference"].Value = txtReference.Text;

            comm.Parameters.Add("@DateOfLastIncrement", SqlDbType.DateTime);
            comm.Parameters["@DateOfLastIncrement"].Value = dTPLastIncDate.Value.Date;

            comm.Parameters.Add("@OriginalDocumentRecord", SqlDbType.VarChar, 50);
            comm.Parameters["@OriginalDocumentRecord"].Value = txtDocRecord.Text;

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatabaseEntry_Load(object sender, EventArgs e)
        {
            PopulateComboboxDesignation();
            PopulateComboboxDept();
            PopulateComboboxSubDept();
            PopulateComboboxID();
            PopulateComboboxCompany();
            PopulateComboboxBank();
        }
        private void PopulateComboboxCompany()
        {
            comboBox5.Items.Clear();

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
                        comboBox5.Items.Add(reader["CompanyName"].ToString());
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


        private void PopulateComboboxBank()
        {
            comboBox8.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("SELECT DISTINCT Bank FROM TbEmployeeDatabase ORDER BY Bank", conn);
            //comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Bank"].ToString() != "")
                        comboBox8.Items.Add(reader["Bank"].ToString());
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

        private void PopulateComboboxDesignation()
        {
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabasePopulateDesignation", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Designation"].ToString() != "")
                    comboBox1.Items.Add(reader["Designation"].ToString());
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
            comboBox7.Items.Clear();

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
                    comboBox7.Items.Add(reader["EmployeeID"].ToString());
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
        private void PopulateComboboxDept()
        {
            comboBox2.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabasePopulateDept", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Department"].ToString() != "")
                    comboBox2.Items.Add(reader["Department"].ToString());
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
        private void PopulateComboboxSubDept()
        {
            comboBox3.Items.Clear();

            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspEmployeeDatabasePopulateSubDept", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["SubDepartment"].ToString() != "")
                    comboBox3.Items.Add(reader["SubDepartment"].ToString());
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
        //private string NameCount()
        //{
        //    string ret = "";
        //    SqlConnection conn = new SqlConnection(this.connectionString);
        //    SqlCommand comm = new SqlCommand("dbo.UspEmployeeNameCount", conn);
        //    comm.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        conn.Open();
        //        ret = comm.ExecuteScalar().ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return ret;
        //}
        private void button5_Click(object sender, EventArgs e)
        {
            //textBox8.Text = this.NameCount();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            //double Mobile, Internet, Arrear, Others;

            //Mobile = int.Parse(textBox9.Text);
            //Internet = int.Parse(textBox10.Text);
            //Arrear = int.Parse(textBox11.Text);
            //Others = int.Parse(textBox12.Text);

            //textBox19.Text = "" + (Mobile + Internet + Arrear + Others);
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
                      
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            //double InitialSalary, OtherConvey, Deduction;
            //InitialSalary = int.Parse(textBox3.Text);
            //OtherConvey = int.Parse(textBox19.Text);
            //Deduction = int.Parse(textBox18.Text);

            //textBox3.Text = "" + ((InitialSalary + OtherConvey) - Deduction);
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Forms.SingleEmployeeReport ser = new Forms.SingleEmployeeReport(comboBox7.Text);
            ser.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Forms.AddPhoto ser = new Forms.AddPhoto(comboBox7.Text);
            ser.Show();
        }
        
    }
}