using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class ShowMouseForm : Form
    {
        public static bool showMouse;
        public ShowMouseForm()
        {
            InitializeComponent();

            try
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Mouse_Config.xml");

                if (tempDataSet.Tables[0].Rows[0]["ShowMouse"].ToString().ToLower().Equals("true"))
                {
                    ShowMouseCheckBox.Checked = true;
                }
                else
                {
                    ShowMouseCheckBox.Checked = false;
                }

            }
            catch (Exception ee)
            {
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Mouse_Config.xml");
                if (ShowMouseCheckBox.Checked)
                {
                    tempDataSet.Tables[0].Rows[0]["ShowMouse"] = "true";
                    Cursor.Show();
                    showMouse = true;
                }
                else
                {
                    tempDataSet.Tables[0].Rows[0]["ShowMouse"] = "false";
                    Cursor.Hide();
                    showMouse = false;
                }

                tempDataSet.WriteXml("Config/Mouse_Config.xml");
                this.Close();

            }
            catch (Exception ee)
            {
            }
        }
    }
}
