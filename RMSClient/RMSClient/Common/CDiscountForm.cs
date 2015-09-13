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
    public partial class CDiscountForm : Form
    {
        public static double discountAmount = 0.000;
        public static string discountType = "Fixed";
        public CDiscountForm()
        {
            InitializeComponent();
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempPriceCalculator = new CCalculatorForm("Set Discount", "Enter discount in percentage");
            tempPriceCalculator.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CCalculatorForm.inputResult, out discountAmount);
            discountType = "Percent";
            this.Close();

        }

        private void FixedAmountButton_Click(object sender, EventArgs e)
        {
            CPriceCalculatorForm tempPriceCalculator = new CPriceCalculatorForm("Set Discount", "Enter discount in exact amount");
            tempPriceCalculator.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CPriceCalculatorForm.inputResult, out discountAmount);
            discountType = "Fixed";
            this.Close();
        }

        private void g_CancelButton_Click(object sender, EventArgs e)
        {
            discountType = "Cancel";
            this.Close();
        }


    }
}