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
using RMSAdmin;
using RMSAdmin.UI;

namespace BistroAdmin.UI
{
    public partial class RawMaterialsItemDetails : UserControl
    {
        public RawMaterialsItemDetails()
        {
            InitializeComponent();
        }

        private void RawMaterialsItemDetails_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            InventoryCategoryBLL aBlll = new InventoryCategoryBLL();
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
            categoryNamecomboBox.DataSource = aaList;
            categoryNamecomboBox.DisplayMember = "CategoryName";
            categoryNamecomboBox.ValueMember = "CategoryId";
            if (Convert.ToInt32(categoryNamecomboBox.SelectedValue) > 0)
            {
                int categoryId = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
                LoadItemDetails(categoryId);
            }
        }

        private void categoryNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(categoryNamecomboBox.SelectedValue) > 0)
                {
                    int categoryId = Convert.ToInt32(categoryNamecomboBox.SelectedValue);
                    LoadItemDetails(categoryId);
                }
            }
            catch (Exception)
            {
                                                                                                                                               
            }
          
        }

        private void LoadItemDetails(int categoryId)
        {
            try
            {
                if (Convert.ToInt32(categoryNamecomboBox.SelectedValue) > 0)
                {
                    InventoryItemBLL aBll = new InventoryItemBLL();
                    //List<InventoryItem> aList = new List<InventoryItem>();
                    DataTable aDataTable=new DataTable();
                    aDataTable = aBll.GetItemByCategoryintoTable(categoryId);

                    //aList = aBll.GetItemByCategory(categoryId);
                    rawmaterislaItemdataGridView.DataSource = aDataTable;
                    

                }

            }
            catch
            {


            }
        }

        private void rawmaterislaItemdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {

                if (e.ColumnIndex == Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["up"].ColumnIndex))
                {
                    int itemId = Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["II_id"].Value);



                    ItemUpdateForm objUpdate = new ItemUpdateForm(itemId);
                    objUpdate.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdate.ParentForm.Controls[s].Controls.Clear();
                    objUpdate.ParentForm.Controls[s].Controls.Add(objUpdate);
                }

                else
                    if (e.ColumnIndex == Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["del"].ColumnIndex))
                    {
                        DialogResult result = MessageBox.Show("Do you want to Deleted it?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            InventoryItemBLL aItemBll = new InventoryItemBLL();
                            int itemId = Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["II_id"].Value);
                            bool res = aItemBll.DeleteItem(itemId);
                            if (res)
                            {
                                rawmaterislaItemdataGridView.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        else if (result == DialogResult.No)
                        {

                        }



                    }

            }
            catch (Exception)
            {

            }
        }

        private void rawmaterislaItemdataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {

                if (e.ColumnIndex == Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["II_name"].ColumnIndex))
                {
                    int itemId = Convert.ToInt32("0" + rawmaterislaItemdataGridView.Rows[e.RowIndex].Cells["II_id"].Value);

                    ItemExpireDateShowForm aItemExpireDateShowForm = new ItemExpireDateShowForm(itemId);
                    aItemExpireDateShowForm.ShowDialog();


                }

                

            }
            catch (Exception)
            {

            }


        }
    }
}
