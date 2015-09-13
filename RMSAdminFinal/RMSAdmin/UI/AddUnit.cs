using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.UI
{
    public partial class AddUnit : UserControl
    {
        public AddUnit()
        {
            InitializeComponent();
            unitCreatelabel.Visible = false;
            //this.AcceptButton = unitButton;
        }

        private void unitButton_Click(object sender, EventArgs e)
        {
            string sr = string.Empty;
            sr = unitTextBox.Text;
            if(sr!="")
            {
                Unit aUnit=new Unit();
                aUnit.UnitName = sr;
               
                UnitCreateBLL aBll=new UnitCreateBLL();
                bool check = aBll.CheckExit(sr);
                if (!check)
                {
                    unitCreatelabel.Visible = true;
                    unitCreatelabel.Text = aBll.InsertUnit(aUnit);
                    unitTextBox.Clear();
                }
                else MessageBox.Show("Unit Already Exit");

            }
            else  MessageBox.Show("Please Check Your Input");
        }
    }
}
