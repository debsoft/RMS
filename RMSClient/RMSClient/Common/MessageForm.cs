using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class MessageForm : Form
    {
        public static string message = "";
        public static string status = "";

        public MessageForm(string screenName, string statusType)
        {
            InitializeComponent();
            this.Text = screenName;
            messageTypeLabel.Text = statusType;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            status = "Cancel";
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(messageTextBox.Text.Trim().Length!=0)
            {
                status = "ok";
                message = messageTextBox.Text.Trim();
                this.Close();
            }
        }
    }
}
