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
    public partial class ProductStock : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;


        public ProductStock()
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
        }

        private void ProductStock_Load(object sender, EventArgs e)
        {
            this.ReadDataDateWise();
        }
        private void ReadDataDateWise()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand comm = new SqlCommand("dbo.UspProductNameSearch", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["AutoId"].ToString(), reader["ProductName"].ToString(), reader["Qty"].ToString(), reader["Unit"].ToString());
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
    }
}