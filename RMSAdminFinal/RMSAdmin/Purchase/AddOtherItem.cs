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
    public partial class AddOtherItem : Form
    {
        public AddOtherItem()
        {
            InitializeComponent();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if(itemnametextBox.Text.Length>0 && unitcomboBox.Text.Length>0)
                {
                    Store aStore=new Store();
                    aStore.ItemName = itemnametextBox.Text;
                    aStore.Unit = unitcomboBox.Text;
                    aStore.CategoryId = Convert.ToInt32(categorycomboBox.SelectedValue);
                    aStore.CategoryName = categorycomboBox.Text;
                    StoreDAO aStoreDao=new StoreDAO();
                    string sr = aStoreDao.InsertOtherItem(aStore);
                    MessageBox.Show(sr);
                    if(sr=="Insert Sucessfully")
                    {
                        this.Close();
                    }

                }
                else MessageBox.Show("Please Check Input");
            }
            catch (Exception)
            {

                MessageBox.Show("Please Check Input");
            }
        }

        private void AddOtherItem_Load(object sender, EventArgs e)
        {
            StoreDAO aStoreDao=new StoreDAO();
            List<Store> aList=new List<Store>();
            aList = aStoreDao.GetAllotherCategory();
            categorycomboBox.DataSource = aList;
            categorycomboBox.ValueMember = "StoreId";
            categorycomboBox.DisplayMember = "ItemName";
        }
    }
}
