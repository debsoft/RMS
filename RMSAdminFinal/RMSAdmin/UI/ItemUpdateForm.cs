using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using Common.ObjectModel;
using RMSAdmin;

namespace BistroAdmin.UI
{
    public partial class ItemUpdateForm : UserControl
    {
        private int itemId;
        public ItemUpdateForm(int id)
        {
            InitializeComponent();
            itemId = id;
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            try
            {
                UserControl uCtl = UserControlManager.UserControls.Pop();
                Panel pnlMain = (Panel)this.ParentForm.Controls["pnlContext"];
                string s = pnlMain.Name;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(uCtl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            if(ValidForm())
            {
                InventoryItem aInventoryItem=new InventoryItem();
                InventoryItemBLL aInventoryItemBll=new InventoryItemBLL();
                aInventoryItem.ItemId = itemId;
                aInventoryItem.CategoryId = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
                aInventoryItem.CategoryName = categoryNamecomboBox.Text;
                aInventoryItem.ItemName = itemNametextBox.Text;
                aInventoryItem.UnitName = unitNamecomboBox.Text;
                string result = aInventoryItemBll.UpdateItem(aInventoryItem);
                updatestatuslabel.Visible = true;
                updatestatuslabel.Text = result;
            }
        }

        private bool ValidForm()
        {
            if(categoryNamecomboBox.Text.Trim().Length==0)
            {
                updatestatuslabel.Visible = true;
                updatestatuslabel.Text = "Please Put Down Category.";
                return false;
            }
            if (unitNamecomboBox.Text.Trim().Length == 0)
            {
                updatestatuslabel.Visible = true;
                updatestatuslabel.Text = "Please Put Down Unit.";
                return false;
            }
            if (itemNametextBox.Text.Trim().Length == 0)
            {
                updatestatuslabel.Visible = true;
                updatestatuslabel.Text = "Please Put Down Item Name.";
                return false;
            }

            return true;
        }

        private void ItemUpdateForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadUnit();
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            InventoryItemBLL aInventoryItemBll=new InventoryItemBLL();
            InventoryItem aInventoryItem=new InventoryItem();
            aInventoryItem = aInventoryItemBll.GetInventoryItem(itemId);
            itemNametextBox.Text = aInventoryItem.ItemName;

            int index = SelectedIndesForFoodType(aInventoryItem.CategoryId, categoryNamecomboBox);
            categoryNamecomboBox.SelectedIndex = index;

            index = SelectedIndesForItemUnit(aInventoryItem.UnitName, unitNamecomboBox);
            unitNamecomboBox.SelectedIndex = index;
        }

        private int SelectedIndesForItemUnit(string unitName, ComboBox aComboBox)
        {
            int cnt = 0;
            int index = 0;
            foreach (Unit item in aComboBox.Items)
            {


               
                if (item.UnitName == unitName)
                {
                    index = cnt;
                }
                cnt++;

            }
            return index;
        }


        private int SelectedIndesForFoodType(int foodTypeId, ComboBox aComboBox)
        {
            int cnt = 0;
            int index = 0;
            foreach (InventoryCategory item in aComboBox.Items)
            {


                
                if (item.CategoryId == foodTypeId)
                {
                    index = cnt;
                }
                cnt++;

            }
            return index;
        }

        private void LoadUnit()
        {
            UnitCreateBLL aBll = new UnitCreateBLL();
            List<Unit> aList = new List<Unit>();
            aList = aBll.GetALLUnit();
            unitNamecomboBox.DataSource = aList;
            unitNamecomboBox.DisplayMember = "UnitName";
            unitNamecomboBox.ValueMember = "UnitId";
        }

        private void LoadCategory()
        {
            InventoryCategoryBLL aBlll = new InventoryCategoryBLL();
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
            categoryNamecomboBox.DataSource = aaList;
            categoryNamecomboBox.DisplayMember = "CategoryName";
            categoryNamecomboBox.ValueMember = "CategoryId";
        }
    }
}
