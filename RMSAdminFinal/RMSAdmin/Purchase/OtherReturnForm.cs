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
using Database.Queries;

namespace RMSAdmin.Purchase
{
    public partial class OtherReturnForm : Form
    {
        public int ItemId { set; get; }
        public int CategoryId { set; get; }
        public OtherReturnForm()
        {
            InitializeComponent();
            List<Supplier1> aSuppliers = new List<Supplier1>();
            Supplier1DAO aDao = new Supplier1DAO();
            aSuppliers = aDao.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "SupplierName";
            supplierNamecomboBox.ValueMember = "SupplierId";
        }


        private void savebutton_Click(object sender, EventArgs e)
        {
            Store aStore = new Store();
            StoreDAO aStoreDao = new StoreDAO();
            aStore = aStoreDao.GetOtherStoreByItemId(ItemId);
            Transaction1 aTransaction1 = new Transaction1();
            aTransaction1.ItemName = aStore.ItemName;
            aTransaction1.TransactionType = "Return";
            aTransaction1.SupplierName = supplierNamecomboBox.Text;
            aTransaction1.Amount = Convert.ToDouble(amounttextBox.Text);
            aTransaction1.Quantity = Convert.ToDouble(quantitytextBox.Text);
            aTransaction1.ItemUnit = aStore.Unit;

            aStoreDao.InsertOtherTransaction(aTransaction1, CategoryId);

            double newstore = aStore.Amount + Convert.ToDouble(amounttextBox.Text);
            double newquantity = aStore.Quantity + Convert.ToDouble(quantitytextBox.Text);
            double unitprice = 0;
            if (newquantity != 0)
            {
                unitprice = (newstore / newquantity);

            }
            else unitprice = 0;
            aStore.UnitPrice = unitprice;
            aStore.Quantity = newquantity;
            string sr = aStoreDao.UpdateOtherStore(aStore);
            MessageBox.Show(sr);
            if (sr == "Insert Sucessfully")
            {
                this.Close();
            }


        }
    }
}
