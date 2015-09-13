using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.Deposit;
using RMS.Common.ObjectModel;
using RMS.Common;
using Managers.Customer;
using System.Net;
using Managers.TableInfo;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class CNewDepositForm : Form
    {

        Int64 m_iCustomerID;
        String m_sDepositType;

        public CNewDepositForm()
        {
            InitializeComponent();
            
        }

        public CNewDepositForm(Int64 inCustomerID)
        {
            InitializeComponent();
            m_iCustomerID = inCustomerID;

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
        private void g_DoubleZeroButton_Click(object sender, EventArgs e)
        {
            SetNumber(0);
            SetNumber(0);
        }
        private void g_ClearButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£0.000";
        }
        private void g_20poumdButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£20.00";
        }
        private void g_10poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£10.00";
        }
        private void g_5poundButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = "£5.00";
        }

        private void TotalAmountCalculation()
        {
            Double tempCash = 0.000;
            Double tempEFT = 0.000;
            Double tempCheque = 0.000;
            Double tempAccount = 0.000;

            Double.TryParse(g_CashLabel.Text.Substring(1), out tempCash);
            Double.TryParse(g_EFTLabel.Text.Substring(1), out tempEFT);
            Double.TryParse(g_ChequeLabel.Text.Substring(1), out tempCheque);
            Double.TryParse(g_AccountLabel.Text.Substring(1), out tempAccount);

            Double total = tempCash + tempEFT + tempCheque + tempAccount;
            g_DepositTotalLabel.Text = "£"+total.ToString("F02");
            g_InputTextBox.Text = "£0.000";

        }
        private void g_CashButton_Click(object sender, EventArgs e)
        {
            g_CashLabel.Text = g_InputTextBox.Text;
            g_EFTLabel.Text = "£0.000";
            g_ChequeLabel.Text ="£0.000";
            g_AccountLabel.Text = "£0.000";
            m_sDepositType = "Cash";
            TotalAmountCalculation();
        }
        private void g_EFTButton_Click(object sender, EventArgs e)
        {
            g_CashLabel.Text = "£0.000";
            g_EFTLabel.Text = g_InputTextBox.Text;
            g_ChequeLabel.Text = "£0.000";
            g_AccountLabel.Text = "£0.000";
            m_sDepositType = "EFT";
            TotalAmountCalculation();
        }
        
        private void g_ChequeButton_Click(object sender, EventArgs e)
        {
            g_CashLabel.Text = "£0.000";
            g_EFTLabel.Text = "£0.000";
            g_ChequeLabel.Text = g_InputTextBox.Text;
            g_AccountLabel.Text = "£0.000";
            m_sDepositType = "Cheque";
            TotalAmountCalculation();
        }
        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CDepositManager tempDepositManager = new CDepositManager();
                CDeposit tempDeposit = new CDeposit();

                Double tempCash = 0.000;
                Double tempEFT = 0.000;
                Double tempCheque = 0.000;
                Double tempAccount = 0.000;
                Double tempTotal = 0.000;

                Double.TryParse(g_CashLabel.Text.Substring(1), out tempCash);
                Double.TryParse(g_EFTLabel.Text.Substring(1), out tempEFT);
                Double.TryParse(g_ChequeLabel.Text.Substring(1), out tempCheque);
                Double.TryParse(g_AccountLabel.Text.Substring(1), out tempAccount);
                Double.TryParse(g_DepositTotalLabel.Text.Substring(1), out tempTotal);

                if (tempTotal == 0)
                {
                    MessageBox.Show("Zero amount given for deposit. Please recheck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                tempDeposit.DepositBalance = tempTotal;
                tempDeposit.DepositTime = DateTime.Now.Ticks;
                tempDeposit.CustomerID=m_iCustomerID;
                tempDeposit.DepositTotalAmount = tempTotal;
                tempDeposit.DepositType = m_sDepositType;
                tempDeposit.Status = 1;

                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CPcInfo tempPcInfo=new CPcInfo();
                CResult oResult= tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString());
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempPcInfo = (CPcInfo)oResult.Data;
                }
                tempDeposit.PcID = tempPcInfo.PcID;

                oResult = tempDepositManager.InsertDeposit(tempDeposit);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempDeposit = (CDeposit)oResult.Data;
                }


                //get customer name & phone
                CCustomerManager tempCustomerManager= new CCustomerManager();
                CCustomerInfo tempCustomerInfo= new CCustomerInfo();
                oResult = tempCustomerManager.CustomerInfoGetByCustomerID(m_iCustomerID);
                if(oResult.IsSuccess && oResult.Data!=null)
                {
                    tempCustomerInfo = (CCustomerInfo)oResult.Data;
                }

                //string serialBody = "\r\n         Deposit Token\r\n";
                //serialBody += "\r\n         Customer Name: "+tempCustomerInfo.CustomerName;
                //serialBody += "\r\n         Phone: " + tempCustomerInfo.CustomerPhone+"\r\n";

                //serialBody += "\r\n         By " + tempDeposit.DepositType;
                //serialBody += "\r\n---------------------------------";
                //serialBody += "\r\n         Total: " + tempDeposit.DepositBalance.ToString("F02");
                //serialBody += "\r\n";
                //serialBody += "\r\nS/N: " + tempDeposit.DepositID.ToString();

                string serialBody = "\r\n                Deposit Token\r\n";
                DateTime tempODate = new DateTime(tempDeposit.DepositTime);
                string tempODateString = "Deposit Date: " + tempODate.ToLongDateString();
                serialBody += "".PadRight((int)((45 - tempODateString.Length) / 2), ' ') + tempODateString.Trim() + "\r\n";
                string tempDateString = "Reprint Date: " + DateTime.Now.ToLongDateString();
                serialBody += "".PadRight((int)((45 - tempDateString.Length) / 2), ' ') + tempDateString.Trim() + "\r\n\r\n";
                serialBody += "Customer Name: " + tempCustomerInfo.CustomerName + "\r\n";
                string tempAddressString = "Customer Address: " + tempCustomerInfo.CustomerAddress.Trim();
                if (tempAddressString.Length > 40)
                {
                    tempAddressString = tempAddressString.Substring(0, 40) + "\r\n".PadRight(19, ' ') + tempAddressString.Substring(40);
                }
                serialBody += tempAddressString + "\r\n";
                serialBody += "Phone: " + tempCustomerInfo.CustomerPhone + "\r\n\r\n";
                serialBody += "Deposit Type:     " + tempDeposit.DepositType + "\r\n";
                serialBody += "Deposited Amount: " + tempDeposit.DepositTotalAmount.ToString("F02") + "\r\n";
                double tempDepositUsed = (tempDeposit.DepositTotalAmount - tempDeposit.DepositBalance);
                serialBody += "Deposit Used:     " + tempDepositUsed.ToString("F02") + "\r\n";
                serialBody += "---------------------------------\r\n";
                serialBody += "Total Balance:    " + tempDeposit.DepositBalance.ToString("F02") + "\r\n\r\n";
                serialBody += "S/N: " + tempDeposit.DepositID.ToString() + "\r\n";

                CPrintMethods tempPrintMethods = new CPrintMethods();
                tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER,"",serialBody,"",tempDeposit.DepositID.ToString());
                this.Close();

            }
            catch (Exception eee)
            {
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void g_AccountButton_Click(object sender, EventArgs e)
        {
            g_CashLabel.Text = "£0.000";
            g_EFTLabel.Text = "£0.000";
            g_ChequeLabel.Text = "£0.000";
            g_AccountLabel.Text = g_InputTextBox.Text;
            m_sDepositType = "Account";
            TotalAmountCalculation();
        }
    }
}