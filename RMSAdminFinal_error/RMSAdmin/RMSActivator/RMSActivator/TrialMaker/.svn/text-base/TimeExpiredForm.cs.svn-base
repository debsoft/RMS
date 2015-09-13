using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftwareLocker
{
    public partial class TimeExpiredForm : Form
    {
        private static TimeExpiredForm objExpirationFrm;
        
        public TimeExpiredForm()
        {
            InitializeComponent();
        }

        public static TimeExpiredForm CreateInstance()
        {
            if (objExpirationFrm == null)
            {
                objExpirationFrm = new TimeExpiredForm();
            }
            return objExpirationFrm;
        }

        private void TimeExpiredForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objExpirationFrm = null;
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}