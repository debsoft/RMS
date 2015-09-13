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
    public partial class OtherStockView : Form
    {
        public OtherStockView()
        {
            InitializeComponent();
          
            LoadGridView();
        }

        private void LoadGridView()
        {
            StoreDAO aDao = new StoreDAO();
            List<Store> aStores = new List<Store>();
            aStores = aDao.GetAllOtherStore();
            otherpurchaseStoredataGridView.DataSource = aStores;
        }

        private void otherpurchaseStoredataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {

                if (e.ColumnIndex == otherpurchaseStoredataGridView.Columns["Purchase"].Index) //when purchase
                {
                    OtherPurchaseForm aForm = new OtherPurchaseForm();
                    aForm.CategoryId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.itemnamelabel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1+2].Value).ToString();
                    aForm.unitnameLebel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[2+2].Value).ToString();
                    aForm.ShowDialog();
                    LoadGridView();
                }

                if (e.ColumnIndex == otherpurchaseStoredataGridView.Columns["Return"].Index) //when purchase
                {
                    OtherReturnForm aForm = new OtherReturnForm();
                    aForm.CategoryId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.itemnamelabel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1 + 2].Value).ToString();
                    aForm.unitnameLebel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[2 + 2].Value).ToString();
                    aForm.ShowDialog();
                    LoadGridView();
                }

                if (e.ColumnIndex == otherpurchaseStoredataGridView.Columns["StockOut"].Index) //when stockout
                {
                    OtherDamageOrStockOut aForm = new OtherDamageOrStockOut();
                    aForm.CategoryId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.otheritemnamelabel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1+2].Value).ToString();
                    aForm.otherunitnameLebel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[2+2].Value).ToString();
                    aForm.othertransactiontypelebel.Text = "Stock Out";
                    aForm.ShowDialog();
                    LoadGridView();
                }
                if (e.ColumnIndex == otherpurchaseStoredataGridView.Columns["Damage"].Index) //when damage
                {
                   OtherDamageOrStockOut aForm = new OtherDamageOrStockOut();
                   aForm.CategoryId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1].Value);
                    aForm.ItemId = Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value);
                    aForm.otheritemnamelabel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[1+2].Value).ToString();
                    aForm.otherunitnameLebel.Text = (otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[2+2].Value).ToString();
                    aForm.othertransactiontypelebel.Text = "Damage";
                    aForm.ShowDialog();
                    LoadGridView();
                }

                if (e.ColumnIndex == otherpurchaseStoredataGridView.Columns["Delete"].Index) //when delete
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete it?", "Alert!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        StoreDAO aStoreDao = new StoreDAO();
                        string sr = aStoreDao.OtherDeleteItem(Convert.ToInt32("0" + otherpurchaseStoredataGridView.Rows[e.RowIndex].Cells[0].Value));
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

        private void additembutton_Click(object sender, EventArgs e)
        {
            AddOtherItem addOtherItem=new AddOtherItem();
            addOtherItem.ShowDialog();
            LoadGridView();
        }

        private void itemNametextBox_TextChanged(object sender, EventArgs e)
        {
        
            if (itemNametextBox.Text == "" || string.IsNullOrEmpty(itemNametextBox.Text))
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllOtherStore();
                otherpurchaseStoredataGridView.DataSource = aStores;
            }
            else
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllOtherStore();
                List<Store> aastore=( from myRow in aStores.AsEnumerable()
                              where myRow.ItemName.ToUpper().StartsWith(itemNametextBox.Text.ToUpper())
                              select myRow).ToList();
               // DataView view = results.AsDataView();
                otherpurchaseStoredataGridView.DataSource = aastore;
            }
        }

        private void findItembutton_Click(object sender, EventArgs e)
        {
            // otherpurchaseStoredataGridView.DataSource = null;
            // otherpurchaseStoredataGridView.AutoGenerateColumns = false;
            if (itemNametextBox.Text == "" || string.IsNullOrEmpty(itemNametextBox.Text))
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllOtherStore();
                otherpurchaseStoredataGridView.DataSource = aStores;
            }
            else
            {
                StoreDAO aDao = new StoreDAO();
                List<Store> aStores = new List<Store>();
                aStores = aDao.GetAllOtherStore();
                List<Store> aastore = (from myRow in aStores.AsEnumerable()
                                       where myRow.ItemName.ToUpper().StartsWith(itemNametextBox.Text.ToUpper())
                                       select myRow).ToList();
                // DataView view = results.AsDataView();
                otherpurchaseStoredataGridView.DataSource = aastore;
            }

        }

        private void CategoryAddbutton_Click(object sender, EventArgs e)
        {
            AddOtherCategory addOtherCategory=new AddOtherCategory();
            addOtherCategory.ShowDialog();
        }
    }
}
