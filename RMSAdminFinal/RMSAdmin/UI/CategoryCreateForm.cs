using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.UI
{
    public partial class CategoryCreateForm : UserControl
    {
        public CategoryCreateForm()
        {
            InitializeComponent();
            categoryCreatelabel.Visible = false;
            //UnitCreateBLL aBll = new UnitCreateBLL();
            //List<Unit> aList = new List<Unit>();
            //aList = aBll.GetALLUnit();
            //unitNamecomboBox.DataSource = aList;
            //unitNamecomboBox.DisplayMember = "UnitName";
            //unitNamecomboBox.ValueMember = "UnitId";
          //  this.AcceptButton = savebutton;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
           InventoryCategory aCategory=new InventoryCategory();
            aCategory.CategoryName = categoryNametextBox.Text;
            aCategory.UnitId = Convert.ToInt32(0);
            
            if (categoryNametextBox.Text.Length!=0)
            {
                InventoryCategoryBLL aBll=new InventoryCategoryBLL();
                bool check = aBll.CheckExit(aCategory.CategoryName);
                if (!check)
                {
                    categoryCreatelabel.Visible = true;
                    categoryCreatelabel.Text = aBll.InsertInventoryCategory(aCategory);
                    categoryNametextBox.Clear();
                }
                else MessageBox.Show("Category Already Exit");
            }
            else MessageBox.Show("Please Check Your Input");
            

        }
    }
}
