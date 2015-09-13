using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common;

namespace RMS.Inventory
{
    public partial class FactorySaveForm : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public FactorySaveForm()
        {
             connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

     

        private void saveButton_Click(object sender, EventArgs e)
        {


              SqlConnection conn = new SqlConnection(this.connectionString);
              SqlCommand command = new SqlCommand("dbo.UspFactorySave", conn);
              command.CommandType = CommandType.StoredProcedure;
              command.Parameters.Add("@FactoryName", SqlDbType.VarChar).Value =factoryNameTextBox.Text;
              command.Parameters.Add("@FactoryAddress", SqlDbType.VarChar).Value =factoryAddressTextBox.Text;
              command.Parameters.Add("@FactoryPhoneNo", SqlDbType.VarChar).Value =factoryPhonrNoTextBox.Text;
              command.Parameters.Add("@HeadOffice", SqlDbType.VarChar).Value =headOficeTextBox.Text;
              command.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value =entryDateTimePicker.Value.Date;
              command.Parameters.Add("@Email", SqlDbType.VarChar).Value =emailTextBox.Text;
              command.Parameters.Add("@Phone", SqlDbType.VarChar).Value =phoneTextBox.Text;
              command.Parameters.Add("@Fax", SqlDbType.VarChar).Value =faxTextBox.Text;
              command.Parameters.Add("@LateDue", SqlDbType.Decimal).Value =Convert.ToDecimal("0"+lastDueTextBox.Text);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Factory setup has been sucessfully");
                ClearField();
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

        private void ClearField()
        {
            factoryNameTextBox.Clear();
            factoryAddressTextBox.Clear();
            factoryPhonrNoTextBox.Clear();
            headOficeTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            faxTextBox.Clear();
            lastDueTextBox.Text = "0";
        }
    }
}
