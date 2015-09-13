using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMSUI;

namespace RMS
{
    public partial class ServiceChargeControl : UserControl
    {
        public static string m_serviceChargeType = "Fixed";
        public static double m_serviceChargeAmount = 0.000;
        private Form m_parent=new Form();

        public ServiceChargeControl(Form parent)
        {
            InitializeComponent();
            m_parent = parent;
        }


        private void PercentButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempPriceCalculator = new CCalculatorForm("Set Charge", "Enter charge in percentage");
            tempPriceCalculator.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CCalculatorForm.inputResult, out m_serviceChargeAmount);
            m_serviceChargeType = "Percent";
        }

        private void FixedAmountButton_Click(object sender, EventArgs e)
        {
            CPriceCalculatorForm tempPriceCalculator = new CPriceCalculatorForm("Set Charge", "Enter charge in exact amount");
            tempPriceCalculator.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CPriceCalculatorForm.inputResult, out m_serviceChargeAmount);
            m_serviceChargeType = "Fixed";
        }
    }
}
