using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using RMS.Common;
//using RMS.ProductManagement;


namespace RMS.StockManagement
{
    public partial class ProductForm : BaseForm
    {
       

        public ProductForm(ProductViewMode productViewMode, int cat3_id)
        {
            InitializeComponent();


            switch (productViewMode)
            {
                case ProductViewMode.LIST:
                    {
                        ProductItemCtl foodItemControl = new ProductItemCtl();
                        panelUCHolder.Controls.Add(foodItemControl);
                        foodItemControl.Dock = DockStyle.Fill;
                        ScreenTitle = "Product List";
                       
                    }
                    break;

                case ProductViewMode.INSERT:
                    {
                        AddProductItemCtl foodItemControl = new AddProductItemCtl();
                        panelUCHolder.Controls.Add(foodItemControl);
                        foodItemControl.Dock = DockStyle.Fill;
                        ScreenTitle = "Add New Product";
                      
                    }
                    break;

                case ProductViewMode.UPDATE:
                    {
                        AddProductItemCtl foodItemControl = new AddProductItemCtl(cat3_id);
                        panelUCHolder.Controls.Add(foodItemControl);
                        foodItemControl.Dock = DockStyle.Fill;
                        ScreenTitle = "Update Product";
                     
                    }
                    break;
            }
          
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
                //Form tempForm = CFormManager.Forms.Pop();
                //tempForm.Show();
                this.Close();
           
        }

        private void panelUCHolder_Paint(object sender, PaintEventArgs e)
        {

        }
    }
   
}
