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
    public partial class CPriceCalculatorForm : Form
    {
        public static string inputResult = "";

        public CPriceCalculatorForm()
        {
            InitializeComponent();
        }

        public CPriceCalculatorForm(string title, string inputLabel)
        {
            InitializeComponent();
            this.Text = title;
            InputNameLabel.Text = inputLabel;
        }

        private void SetNumber(int inDigit)
        {
            if (InputTextBox.Text.Length > 10)
                return;
            Double tempInput = Double.Parse(InputTextBox.Text);
            
            InputTextBox.Text = ((Double)(tempInput * 10 + inDigit * 0.01)).ToString("F02");
        }

       /* private void OneButton_Click(object sender, EventArgs e)
        {
            SetNumber(1);
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            SetNumber(2);
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            SetNumber(3);
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            SetNumber(4);
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            SetNumber(5);
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            SetNumber(6);
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            SetNumber(7);
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            SetNumber(8);
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            SetNumber(9);
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            SetNumber(0);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "0.00";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            inputResult = "Cancel";
            this.Close();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            inputResult = InputTextBox.Text;
            this.Close();
        }      
         
          */

        private void numericInputButton1_Click(object sender, EventArgs e)
        {
            SetNumber(1);
        }

        private void numericInputButton2_Click(object sender, EventArgs e)
        {
            SetNumber(2);
        }

        private void numericInputButton3_Click(object sender, EventArgs e)
        {
            SetNumber(3);
        }

        private void numericInputButton8_Click(object sender, EventArgs e)
        {
            SetNumber(4);
        }

        private void numericInputButton7_Click(object sender, EventArgs e)
        {
            SetNumber(5);
        }

        private void numericInputButton6_Click(object sender, EventArgs e)
        {
            SetNumber(6);
        }

        private void numericInputButton12_Click(object sender, EventArgs e)
        {
            SetNumber(7);
        }

        private void numericInputButton11_Click(object sender, EventArgs e)
        {
            SetNumber(8);
        }

        private void numericInputButton10_Click(object sender, EventArgs e)
        {
            SetNumber(9);
        }

        private void numericInputButton15_Click(object sender, EventArgs e)
        {
            SetNumber(0);
        }

        private void numericInputButton14_Click(object sender, EventArgs e)
        {
            inputResult = InputTextBox.Text;
            this.Close();
        }

        private void numericInputButton16_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "0.00";
        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            inputResult = "Cancel";
            this.Close();
        }
    }
}