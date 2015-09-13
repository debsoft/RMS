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
    public partial class SupplierForm : UserControl
    {
        public SupplierForm()
        {
            InitializeComponent();
            actionlabel.Visible = false;
            //this.AcceptButton=supplierSavebutton;
        }

        private void supplierSavebutton_Click(object sender, EventArgs e)
        {
            Supplier aSupplier=new Supplier();
            aSupplier.Name = supplierNametextBox.Text;
          //  replace(Request.QueryString(test), "'", "''")
           // aSupplier.ContactInformation = contactInformationtextBox.Text;
            aSupplier.ContactInformation = contactInformationtextBox.Text.Replace("'", "''");
            if (supplierNametextBox.Text.Length!=0 && contactInformationtextBox.Text.Length!=0)
            {
                SupplierBLL aBll = new SupplierBLL();
                bool check = aBll.CheckExit(aSupplier.Name);
                if (!check)
                {
                    actionlabel.Visible = true;
                    actionlabel.Text = aBll.InsertSupplier(aSupplier);
                    if (actionlabel.Text != "Please Check Your Input")
                    {
                        contactInformationtextBox.Clear();
                        supplierNametextBox.Clear();
                    }
                }
                else MessageBox.Show("Supplier Already Exit");
            } else
            {
                actionlabel.Visible = true;
                actionlabel.Text = "Please Check Your Input";
            }

        }

     
    }
}
