using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace SoftwareLocker
{
    public partial class frmDialog : Form
    {
        private string _activationCode="";
        private string _hexCode = "";

        public frmDialog(string BaseString,
            string activaionCode,int DaysToEnd,int Runed, string info)
        {
            InitializeComponent();
            _activationCode = activaionCode;
            _hexCode = BaseString;
            lblDays.Text = DaysToEnd.ToString() + " Day(s)";
            lblTimes.Text = Runed.ToString() + " Time(s)";
            lblText.Text = info;
            if (DaysToEnd <= 0 || Runed <= 0)
            {
                lblDays.Text = "Finished";
                lblTimes.Text = "Finished";
                btnTrial.Enabled = false;
            }

            sebPassword.Select();
        }

      

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }


        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            if (sebPassword.Text.Length < 25)
            {
                MessageBox.Show("Please enter correct serial number.","RMS",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                sebPassword.Focus();
                return;
            }
            txtHexKey.Text = _hexCode;
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (_activationCode.ToUpper().Replace(" ", "") == txtActivationCode.Text.ToUpper().Replace(" ", ""))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            { 
              MessageBox.Show("Activation code is incorrect.", "RMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void sebPassword_Leave(object sender, EventArgs e)
        {
            //string userSerial = sebPassword.Text;
            //if (userSerial.ToUpper().Replace(" ", "") != "HTT4U POAGT JUR53 98DHT SNH5S".ToUpper().Replace(" ", ""))
            //{
            //    lblValidation.Text = "Invalid";
            //    lblValidation.Visible = true;
            //    sebPassword.Focus();
            //}
            //else
            //{
            //    lblValidation.Visible = false;
            //}
        }

        private void tmrRMSActivation_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeExpiredForm objExpiration = TimeExpiredForm.CreateInstance();
                objExpiration.Show();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
            catch (InvalidOperationException exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            { 
             
            }
        }

        private void frmDialog_Activated(object sender, EventArgs e)
        {
            tmrRMSActivation.Start();
        }
    }
}