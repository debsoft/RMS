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
    public partial class ItemCreateForm : UserControl
    {
        public ItemCreateForm()
        {
            InitializeComponent();
           // this.AcceptButton=savebutton;
            itemCreatelabel.Visible = false;
            InventoryCategoryBLL aBlll=new InventoryCategoryBLL();
            List<InventoryCategory> aaList=new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
           categoryNamecomboBox.DataSource = aaList;
           categoryNamecomboBox.DisplayMember = "CategoryName";
           categoryNamecomboBox.ValueMember = "CategoryId";
           UnitCreateBLL aBll = new UnitCreateBLL();
           List<Unit> aList = new List<Unit>();
           aList = aBll.GetALLUnit();
           unitNamecomboBox.DataSource = aList;
           unitNamecomboBox.DisplayMember = "UnitName";
           unitNamecomboBox.ValueMember = "UnitId";
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            
            InventoryItem aItem=new InventoryItem();
            aItem.ItemName = itemNametextBox.Text;
            aItem.CategoryId = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
            Unit aUnit=new Unit();
            aUnit = (Unit)(unitNamecomboBox.SelectedItem);
            aItem.UnitName =aUnit.UnitName;

            if (itemNametextBox.Text.Length != 0)
            {
                InventoryItemBLL aBll = new InventoryItemBLL();
                bool check = aBll.CheckExit(aItem.ItemName);
                if (!check)
                {
                    itemCreatelabel.Visible = true;
                    itemCreatelabel.Text = aBll.InsertInventoryItem(aItem);
                    itemNametextBox.Clear();
                }
                else MessageBox.Show("Item Already Exit");
            }
            else MessageBox.Show("Please Check Your Input");

        }

        private void ItemCreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
