using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PayRoll.Forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReadWriteClass cc = new ReadWriteClass();

            //if (cc.WriteToNewFile(Path.Combine(Application.StartupPath, "account.dat"), textBox1.Text + ";" + textBox2.Text + ";"))
            //{
            //    MessageBox.Show("Successfuly Changed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //    MessageBox.Show("Successfuly not Changed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}