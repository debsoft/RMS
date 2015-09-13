using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using Database.Queries;

namespace RMSAdmin.Purchase
{
    public partial class DamageOrStockOut : Form
    {
        public int ItemId { set; get; }
        public int CategoryId { set; get; }
        public DamageOrStockOut()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            Store aStore = new Store();
            StoreDAO aStoreDao = new StoreDAO();
            aStore = aStoreDao.GetStoreByItemId(ItemId);
            Transaction1 aTransaction1 = new Transaction1();
            aTransaction1.ItemName = aStore.ItemName;
            aTransaction1.TransactionType = transactiontypelebel.Text;
            aTransaction1.Amount = Convert.ToDouble(quantitytextBox.Text)*aStore.UnitPrice;
            aTransaction1.Quantity = Convert.ToDouble(quantitytextBox.Text);
            aTransaction1.ItemUnit = aStore.Unit;
            aTransaction1.CauseOrPurpose = purposeTextBox.Text.Trim();

              aStore.Quantity -= Convert.ToDouble(quantitytextBox.Text);
              if (aStore.Quantity >= 0)
              {

                  aStoreDao.InsertTransaction(aTransaction1,CategoryId);

                  string sr = aStoreDao.UpdateStore(aStore);
                  MessageBox.Show(sr);
                  if (sr == "Insert Sucessfully")
                  {
                      this.Close();
                  }
              }
              else   MessageBox.Show("Not Enough quantity");
        }
    }
}
