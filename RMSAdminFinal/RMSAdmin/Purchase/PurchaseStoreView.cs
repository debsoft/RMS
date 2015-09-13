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
    public partial class PurchaseStoreView : Form
    {
        public PurchaseStoreView()
        {
            InitializeComponent();
            LoadGridView();

        }
        private void LoadGridView()
        {
            StoreDAO aDao = new StoreDAO();
            List<Store> aStores = new List<Store>();
            aStores = aDao.GetAllStore();
            purchaseStoredataGridView.DataSource = aStores;
        }

        private void purchaseStoredataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {

                if(e.ColumnIndex==8) //when purchase
                {
                    PurchaseForm aForm=new PurchaseForm();
                    aForm.CategoryId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.itemnamelabel.Text = ( purchaseStoredataGridView.Rows[e.RowIndex].Cells[1+2].Value).ToString();
                    aForm.unitnameLebel.Text = (purchaseStoredataGridView.Rows[e.RowIndex].Cells[2+2].Value).ToString();
                    aForm.ShowDialog();
                    LoadGridView();
                }
                if (e.ColumnIndex == 9) //when stockout
                {
                    DamageOrStockOut aForm=new DamageOrStockOut();
                    aForm.CategoryId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.itemnamelabel.Text = (purchaseStoredataGridView.Rows[e.RowIndex].Cells[1 + 2].Value).ToString();
                    aForm.unitnameLebel.Text = (purchaseStoredataGridView.Rows[e.RowIndex].Cells[2 + 2].Value).ToString();
                    aForm.transactiontypelebel.Text = "Stock Out";
                    aForm.ShowDialog();
                    LoadGridView();
                }
                if (e.ColumnIndex == 10) //when damage
                {
                    DamageOrStockOut aForm = new DamageOrStockOut();
                    aForm.CategoryId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.itemnamelabel.Text = (purchaseStoredataGridView.Rows[e.RowIndex].Cells[1 + 2].Value).ToString();
                    aForm.unitnameLebel.Text = (purchaseStoredataGridView.Rows[e.RowIndex].Cells[2 + 2].Value).ToString();
                    aForm.transactiontypelebel.Text = "Damage";
                    aForm.ShowDialog();
                    LoadGridView();
                }

                if (e.ColumnIndex == 11) //when delete
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete it?", "Alert!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        StoreDAO aStoreDao=new StoreDAO();
                        string sr = aStoreDao.DeleteItem(Convert.ToInt32("0" + purchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value));
                        MessageBox.Show(sr);
                        LoadGridView();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }


            }
            catch (Exception)
            {
                
                
            }
        }

        private void itemNametextBox_TextChanged(object sender, EventArgs e)
        {
           
            if (itemNametextBox.Text == "" || string.IsNullOrEmpty(itemNametextBox.Text))
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllStore();
                purchaseStoredataGridView.DataSource = aStores;
            }
            else
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllStore();
                List<Store> aastore = (from myRow in aStores.AsEnumerable()
                                       where myRow.ItemName.ToUpper().StartsWith(itemNametextBox.Text.ToUpper())
                                       select myRow).ToList();
                // DataView view = results.AsDataView();
                purchaseStoredataGridView.DataSource = aastore;
            }
        }

        private void findItembutton_Click(object sender, EventArgs e)
        {
            if (itemNametextBox.Text == "" || string.IsNullOrEmpty(itemNametextBox.Text))
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllStore();
                purchaseStoredataGridView.DataSource = aStores;
            }
            else
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllStore();
                List<Store> aastore = (from myRow in aStores.AsEnumerable()
                                       where myRow.ItemName.ToUpper().StartsWith(itemNametextBox.Text.ToUpper())
                                       select myRow).ToList();
                // DataView view = results.AsDataView();
                purchaseStoredataGridView.DataSource = aastore;
            }

        }
    }
}
