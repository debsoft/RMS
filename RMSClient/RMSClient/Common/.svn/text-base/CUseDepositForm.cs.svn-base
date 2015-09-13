using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.Deposit;
using RMSUI;

namespace RMS.Common
{
    public partial class CUseDepositForm : Form
    {
        private CDeposit m_oDeposit;
        public static Double usedAmount = 0.000;
        public CUseDepositForm()
        {
            InitializeComponent();
        }

        public CUseDepositForm(CDeposit inDeposit)
        {
            InitializeComponent();

            m_oDeposit = inDeposit;
            SerialNumberLabel.Text = m_oDeposit.DepositID.ToString();
            
            g_TotalLabel.Text = "£" +m_oDeposit.DepositTotalAmount.ToString("F02");
            DepositTypeLabel.Text = m_oDeposit.DepositType;
            g_BalanceLabel.Text = "£" + m_oDeposit.DepositBalance.ToString("F02");
        }

        private void SetNumber(int inDigit)
        {
            if (g_InputTextBox.Text.Length > 10)
                return;
            Double tempInput = Double.Parse(g_InputTextBox.Text.Substring(1));
            g_InputTextBox.Text = "£" + ((Double)(tempInput * 10 + inDigit * 0.01)).ToString("F02");
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            SetNumber(Int32.Parse(((Button)sender).Text));
        }

        private void g_ClearButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£0.000";
        }

        private void g_DoubleZeroButton_Click(object sender, EventArgs e)
        {
            SetNumber(0);
            SetNumber(0);
        }

        private void g_5poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£5.00";
        }

        private void g_10poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£10.00";
        }

        private void g_20poumdButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£20.00";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UseButton_Click(object sender, EventArgs e)
        {
            CDepositManager tempDepositManager = new CDepositManager();
            Double inputAmount = 0.000;
            Double.TryParse(g_InputTextBox.Text.Substring(1).Trim(), out inputAmount);

            if (inputAmount >= m_oDeposit.DepositBalance)
            {
                usedAmount = m_oDeposit.DepositBalance;
                //m_oDeposit.DepositBalance = 0.000;
                //tempDepositManager.UpdateDeposit(m_oDeposit);
            }
            else
            {
                usedAmount = inputAmount;
                //m_oDeposit.DepositBalance = m_oDeposit.DepositBalance - inputAmount;
                //tempDepositManager.UpdateDeposit(m_oDeposit);
            }
            this.Close();

        }
    }
}