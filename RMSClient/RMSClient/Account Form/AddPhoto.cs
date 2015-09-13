using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using RMS;
using RMS.Common;

namespace PayRoll.Forms
{
    public partial class AddPhoto : Form
    {
        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
        private String connectionString;
        public AddPhoto(string VR)
        {
            connectionString = oTempConstant.DBConnection;
            InitializeComponent();
            textBox1.Text = VR;
        }

        private void AddPhoto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                textBox2.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveImageInDataBase();
        }
        public void saveImageInDataBase()
        {
            byte[] EmployeePhoto = ReadImageFile(textBox2.Text);
            SqlConnection conn = new SqlConnection(this.connectionString);
            conn.Open();
            string query = "insert into tblEmployeePhoto values(@EmployeeID,@EmployeePhoto)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            cmd.Parameters["@EmployeeID"].Value = textBox1.Text;

            cmd.Parameters.Add(new SqlParameter("@EmployeePhoto", EmployeePhoto));
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Image saved.");
            else
                MessageBox.Show("Unable to save image.");
            conn.Close();
        }
        public byte[] ReadImageFile(string imageLocation)
        {
            byte[] EmployeePhoto = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            EmployeePhoto = br.ReadBytes((int)imageFileLength);
            return EmployeePhoto;
        }

    }
}
