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
    public partial class PerformanceAppraisalForm : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public PerformanceAppraisalForm()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            Reset();
        }
        private void Save()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspPerformanceFormSave", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50);
            comm.Parameters["@EmployeeID"].Value = cboEmployeeID.Text;

            comm.Parameters.Add("@ReviewFrom", SqlDbType.DateTime);
            comm.Parameters["@ReviewFrom"].Value = dTPFrom.Value.Date;

            comm.Parameters.Add("@ReviewTo", SqlDbType.DateTime);
            comm.Parameters["@ReviewTo"].Value = dTPTo.Value.Date;

            comm.Parameters.Add("@F1", SqlDbType.VarChar, 50);
            comm.Parameters["@F1"].Value = lbl1F.Text;
            
            comm.Parameters.Add("@R1", SqlDbType.BigInt);
            comm.Parameters["@R1"].Value = int.Parse(txt1F.Text);

            comm.Parameters.Add("@C1", SqlDbType.VarChar, 50);
            comm.Parameters["@C1"].Value = txt1C.Text;

            comm.Parameters.Add("@F2", SqlDbType.VarChar, 50);
            comm.Parameters["@F2"].Value = lbl2F.Text;

            comm.Parameters.Add("@R2", SqlDbType.BigInt);
            comm.Parameters["@R2"].Value = int.Parse(txt2F.Text);

            comm.Parameters.Add("@C2", SqlDbType.VarChar, 50);
            comm.Parameters["@C2"].Value = txt2C.Text;

            comm.Parameters.Add("@F3", SqlDbType.VarChar, 50);
            comm.Parameters["@F3"].Value = lbl3F.Text;

            comm.Parameters.Add("@R3", SqlDbType.BigInt);
            comm.Parameters["@R3"].Value = int.Parse(txt3F.Text);

            comm.Parameters.Add("@C3", SqlDbType.VarChar, 50);
            comm.Parameters["@C3"].Value = txt3C.Text;

            comm.Parameters.Add("@F4", SqlDbType.VarChar, 50);
            comm.Parameters["@F4"].Value = lbl4F.Text;

            comm.Parameters.Add("@R4", SqlDbType.BigInt);
            comm.Parameters["@R4"].Value = int.Parse(txt4F.Text);

            comm.Parameters.Add("@C4", SqlDbType.VarChar, 50);
            comm.Parameters["@C4"].Value = txt4C.Text;

            comm.Parameters.Add("@F5", SqlDbType.VarChar, 50);
            comm.Parameters["@F5"].Value = lbl5F.Text;

            comm.Parameters.Add("@R5", SqlDbType.BigInt);
            comm.Parameters["@R5"].Value = int.Parse(txt5F.Text);

            comm.Parameters.Add("@C5", SqlDbType.VarChar, 50);
            comm.Parameters["@C5"].Value = txt5C.Text;

            comm.Parameters.Add("@OverallRatings", SqlDbType.BigInt);
            comm.Parameters["@OverallRatings"].Value = int.Parse(txtOverallRatings.Text);

            comm.Parameters.Add("@OverallComments", SqlDbType.VarChar, 500);
            comm.Parameters["@OverallComments"].Value = txtOverallComments.Text;           

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
            txt1F.Text = "0";
            txt2F.Text = "0";
            txt3F.Text = "0";
            txt4F.Text = "0";
            txt5F.Text = "0";

            txt1C.Text = "";
            txt2C.Text = "";
            txt3C.Text = "";
            txt4C.Text = "";
            txt5C.Text = "";

            txtOverallRatings.Text = "0";
            txtOverallComments.Text = "";

            txtAverageRatings.Text = "0";

            cboEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtJobTitle.Text = "";
            txtDepartment.Text = "";
        }

        private void cboEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditData(cboEmployeeID.Text);
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
                    txtEmployeeName.Text = reader["EmployeeName"].ToString();
                    txtJobTitle.Text = reader["Designation"].ToString();
                    txtDepartment.Text = reader["Department"].ToString();
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

        private void PerformanceAppraisalForm_Load(object sender, EventArgs e)
        {
            PopulateComboboxID();
        }
        private void PopulateComboboxID()
        {
            cboEmployeeID.Items.Clear();
            
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
                        cboEmployeeID.Items.Add(reader["EmployeeID"].ToString());
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

        private void txt5F_Leave(object sender, EventArgs e)
        {
            txtOverallRatings.Text = "" + (int.Parse(txt1F.Text) + int.Parse(txt2F.Text) + int.Parse(txt3F.Text) + int.Parse(txt4F.Text) + int.Parse(txt5F.Text));
            txtAverageRatings.Text = ""+(int.Parse(txtOverallRatings.Text)/5);
        }
    }

}
