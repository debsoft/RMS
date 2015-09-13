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
    public partial class AddRawMaterialCategory : Form
    {
        public AddRawMaterialCategory()
        {
            InitializeComponent();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (categorynametextBox.Text.Length > 0)
                {
                    Store aStore = new Store();
                    aStore.ItemName = categorynametextBox.Text;
                    StoreDAO aStoreDao = new StoreDAO();
                    string sr = aStoreDao.InsertRawmaterialCategory(aStore);
                    MessageBox.Show(sr);
                    if (sr == "Insert Sucessfully")
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
    }
}
