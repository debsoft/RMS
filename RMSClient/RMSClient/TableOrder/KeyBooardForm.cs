using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RMS.TableOrder
{
    public partial class KeyBooardForm : Form
    {
        public RMS.TableOrder.CTableOrderForm.OnKeyBoardPressDelegate onKeyBoardPressDelegate;
       
        public KeyBooardForm()
        {
            InitializeComponent();
            this.Location = new Point(50, 380);
            this.Size = new Size(740, 320);
           
        }

        private void KeyBooardForm_Load(object sender, EventArgs e)
        {
            onKeyBoardPressDelegate(keyboard1);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       
    }
}
