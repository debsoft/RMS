using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.Common
{
    public partial class KitchenCopySettingForm : Form
    {
        public KitchenCopySettingForm()
        {
            InitializeComponent();

            DataSet tempDataSet = new DataSet();
            tempDataSet.ReadXml("Config/Mouse_Config.xml");

            if (!tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString().Equals(""))
            {
               txtCopies.Text = tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"].ToString();
            }
            if (!tempDataSet.Tables[0].Rows[0]["ShowPriceStatus"].ToString().Equals(""))
            {
                if(tempDataSet.Tables[0].Rows[0]["ShowPriceStatus"].ToString().Equals("true"))
                {
                 rdoShow.Checked=true;
                }
                else
                {
                 rdoNotShow.Checked=true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string printStatus = "";
            if (rdoShow.Checked)
            {
                printStatus = "true";
            }
            else
            {
                printStatus = "false";
            }

            DataSet tempDataSet = new DataSet();
            tempDataSet.ReadXml("Config/Mouse_Config.xml");

            tempDataSet.Tables[0].Rows[0]["KitchenCopyNumber"] = txtCopies.Text;
            tempDataSet.Tables[0].Rows[0]["ShowPriceStatus"] = printStatus;

            tempDataSet.WriteXml("Config/Mouse_Config.xml");
            this.Close();
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCopies.Text.Length > 0)
                {
                    txtCopies.Text = txtCopies.Text.Remove(txtCopies.Text.Length - 1, 1);
                }
            }
            catch (Exception eee)
            {
                throw eee;
            }
        }

        private void txtCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Num1Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("1");
        }

        private void Num2Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("2");
        }

        private void Num3Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("3");
        }

        private void Num4Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("4");
        }

        private void Num5Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("5");
        }

        private void Num6Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("6");
        }

        private void Num7Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("7");
        }

        private void Num8Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("8");
        }

        private void Num9Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("9");
        }

        private void Num0Button_Click(object sender, EventArgs e)
        {
            txtCopies.AppendText("0");
        }
    }
}
