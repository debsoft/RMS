using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.TakeAway;

namespace RMS.Main
{
    public partial class CallerIdForm : Form
    {
        private static CallerIdForm objCallerStatus = null;
        public CallerIdForm()
        {
            InitializeComponent();
        }


        public static CallerIdForm CreateInstance()
        {
            if (objCallerStatus == null)
            {
                objCallerStatus = new CallerIdForm();
            }
            return objCallerStatus;
        }

        private void CallerIdForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceptCall_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    CTakeAwayForm objTakeAway = new CTakeAwayForm();
            //    objTakeAway.ShowDialog();
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}
        }
    }
}
