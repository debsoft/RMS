using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using RMSUI;

namespace RMS.Common
{
    public partial class CCalculatorForm : Form
    {
        public static string inputResult="";
        public CCalculatorForm()
        {
            InitializeComponent();
        }

        public CCalculatorForm(string title,string inputLabel)
        {
            InitializeComponent();
            this.Text = title;
            InputNameLabel.Text = inputLabel;
        }
       

       

        private void CancelButton_Click(object sender, EventArgs e)
        {
            inputResult = "Cancel";
            this.Close();
        }


        private void functionalButton1_Click(object sender, EventArgs e)
        {
            inputResult = InputTextBox.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputResult = InputTextBox.Text;
            this.Close();
        }

       

       
    }
}