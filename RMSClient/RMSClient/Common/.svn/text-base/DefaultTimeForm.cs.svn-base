using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.SystemManagement;
using RMSUI;

namespace RMS
{
    public partial class DefaultTimeForm : Form
    {
        private static DefaultTimeForm objDefaultTime = null;
        public bool m_kitchenCopy=false;//This variable is used to identify the kitchen copy number setting
        private int m_iSelectionIndex = 0;

        public DefaultTimeForm()
        {
            InitializeComponent();
        }

        public static DefaultTimeForm CreateInstance()
        {
            if (objDefaultTime == null)
            {
                objDefaultTime = new DefaultTimeForm();
            }
            return objDefaultTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double defaultTime = Convert.ToDouble("0" + txtDefaultTime.Text);
                SystemManager objSysManager = new SystemManager();
                objSysManager.SvaeTakeawayDefaultTime(defaultTime);
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtDefaultTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

       /* private void Num1Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("1");
        }

        private void Num2Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("2");
        }

        private void Num3Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("3");
        }

        private void Num4Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("4");
        }

        private void Num5Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("5");
        }

        private void Num6Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("6");
        }

        private void Num7Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("7");
        }

        private void Num8Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("8");
        }

        private void Num9Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("9");
        }

        private void Num0Button_Click(object sender, EventArgs e)
        {
            txtDefaultTime.AppendText("0");
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDefaultTime.Text.Length > 0)
                {
                    txtDefaultTime.Text = txtDefaultTime.Text.Remove(txtDefaultTime.Text.Length - 1, 1);
                }
            }
            catch (Exception eee)
            {
                throw eee;
            }
        }
        */
        

       
    }
}
