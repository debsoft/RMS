using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using Database;

namespace RMSAdmin.Purchase
{
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void supplierAddbutton_Click(object sender, EventArgs e)
        {
            Supplier1 aSuppllier =new Supplier1();

            aSuppllier.SupplierName = NametextBox.Text.Replace("'", "''");
            aSuppllier.SupplierInformation = informationtextBox.Text.Replace("'", "''");
            Supplier1DAO aDao=new Supplier1DAO();
           string sr = aDao.InsertSupplier(aSuppllier);
           if (sr == "Supplier1 Insert Successfully")
           {
               NametextBox.Clear();
               informationtextBox.Clear();
           }
           MessageBox.Show(sr);

        }
    }
}
