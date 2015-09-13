using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMSUI;

namespace RMS.TableOrder
{
    public partial class ChargeAmountForm : Form
    {
        public static string m_serviceChargeType = "Fixed";
        public static double m_serviceChargeAmount = 0.000;

        public ChargeAmountForm()
        {
            InitializeComponent();
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempPriceCalculator = new CCalculatorForm("Set Charge", "Enter charge in percentage");
            tempPriceCalculator.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CCalculatorForm.inputResult, out m_serviceChargeAmount);
            m_serviceChargeType = "Percent";
            this.Close();
        }

        private void FixedAmountButton_Click(object sender, EventArgs e)
        {
            CPriceCalculatorForm tempPriceCalculator = new CPriceCalculatorForm("Set Charge", "Enter charge in exact amount");
            tempPriceCalculator.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CPriceCalculatorForm.inputResult, out m_serviceChargeAmount);
            m_serviceChargeType = "Fixed";
            this.Close();
        }

        private void g_CancelButton_Click(object sender, EventArgs e)
        {
            m_serviceChargeType = "Cancel";
            this.Close();
        }

        private void btnFixed_5_Click(object sender, EventArgs e)
        {
            m_serviceChargeType = "Percent";
            m_serviceChargeAmount = 5.00;
            this.Close();
        }

        private void btnFixed_10_Click(object sender, EventArgs e)
        {
            m_serviceChargeType = "Percent";
            m_serviceChargeAmount = 10.00;
            this.Close();
        }

        private void btnFixed_15_Click(object sender, EventArgs e)
        {
            m_serviceChargeType = "Percent";
            m_serviceChargeAmount = 15.00;
            this.Close();
        }

        private void btnFixed_20_Click(object sender, EventArgs e)
        {
            m_serviceChargeType = "Percent";
            m_serviceChargeAmount = 20.00;
            this.Close();
        }
     
    }
}
