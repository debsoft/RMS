using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BistroAdmin.BLL;
using BistroAdmin.DAO;
using Common.ObjectModel;
using Microsoft.ReportingServices.ReportRendering;
using Image = System.Drawing.Image;

namespace BistroAdmin.UI
{
    public partial class InventoryPurchaseReport : UserControl
    {
        private int printReportLogoType = 0;
        public InventoryPurchaseReport()
        {
            InitializeComponent();
            Invisible();
            label7.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            receiveSumLabel.Visible = false;
            totalSaleslabel.Visible = false;
            totalReturnlabel.Visible = false;
            totalBalancelabel.Visible = false;
            InventoryCategoryBLL aBlll = new InventoryCategoryBLL();
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
            categoryNameComboBox.DataSource = aaList;
            categoryNameComboBox.DisplayMember = "CategoryName";
            categoryNameComboBox.ValueMember = "CategoryId";


            //find out supplier
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSuppliers = new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "Name";
            supplierNamecomboBox.ValueMember = "SupplierId";
        }

        private void Invisible()
        {
            label7.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            receiveSumLabel.Visible = false;
            totalSaleslabel.Visible = false;
            totalReturnlabel.Visible = false;
            totalBalancelabel.Visible = false;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            DateTime fromdate = fromdateTimePicker.Value;
            DateTime todate = todateTimePicker.Value;
            todate = todate.AddDays(1);
            fromdate = fromdate.Date;
           todate = todate.Date;
            
            List<InventoryPurchase> aInventoryPurchases=new List<InventoryPurchase>();
            InventoryPurchaseBLL aInventoryPurchaseBll=new InventoryPurchaseBLL();
            aInventoryPurchases = aInventoryPurchaseBll.GetInventoryPurchaseBetweenDate(fromdate, todate);
           // inventoryPurchaseDataGridView.DataSource = aInventoryPurchases;
            ShowReport(aInventoryPurchases);
        }

        private void ShowReport(List<InventoryPurchase> aInventoryPurchases)
        {
            Supplier aSupplier = (Supplier) supplierNamecomboBox.SelectedItem;
            InventoryItem aItem = (InventoryItem) rawMaterialsNameComboBox.SelectedItem;
            InventoryCategory aCategory = (InventoryCategory) categoryNameComboBox.SelectedItem;
            List<InventoryPurchase> aList=new List<InventoryPurchase>();

           
            if(viewAllRawcheckBox.Checked && suppliercheckBox.Checked)
            {
                aList = (from purchase in aInventoryPurchases
                         where purchase.Supplier.SupplierId == aSupplier.SupplierId
                         select purchase).ToList();
            }
            else  if(viewAllAbovecheckBox.Checked && suppliercheckBox.Checked)
            {
                aList = (from purchase in aInventoryPurchases
                        where (purchase.Supplier.SupplierId == aSupplier.SupplierId && purchase.Category.CategoryId==aCategory.CategoryId)
                         select purchase).ToList();
            }
            else if(suppliercheckBox.Checked)
            {
                aList = (from purchase in aInventoryPurchases
                         where (purchase.Supplier.SupplierId == aSupplier.SupplierId && purchase.Item.ItemId == aItem.ItemId && 
                         purchase.Category.CategoryId == aCategory.CategoryId)
                         select purchase).ToList();
            }
            else if(viewAllRawcheckBox.Checked)
            {
                aList = aInventoryPurchases;
            }
            else if(viewAllAbovecheckBox.Checked)
            {
                aList = (from purchase in aInventoryPurchases
                         where (purchase.Category.CategoryId == aCategory.CategoryId)
                         select purchase).ToList();
            }
            else
            {
                aList = (from purchase in aInventoryPurchases
                         where (purchase.Item.ItemId == aItem.ItemId && purchase.Category.CategoryId == aCategory.CategoryId)
                         select purchase).ToList();
            }

           List<InventoryReport> aReport = ConvertReport(aList);

            double totalPrice = aReport.Sum(a => a.TotalAmount);
            balancelabel.Text = totalPrice.ToString("F02");
            inventoryPurchaseDataGridView.DataSource =aReport ;

        }

        private List<InventoryReport> ConvertReport(List<InventoryPurchase> aList)
        {
            List<InventoryReport> aReports=new List<InventoryReport>();
            foreach (InventoryPurchase purchase in aList)
            {
                InventoryReport aReport = new InventoryReport();
                aReport.AdvanceAmount = purchase.Supplier.AdvanceAmount;
                aReport.CategoryName = purchase.Category.CategoryName;
                aReport.Date = purchase.Date;
                aReport.DueAmount = purchase.Supplier.DueAmount;
                aReport.ItemName = purchase.Item.ItemName;
                aReport.PaidAmount = purchase.Supplier.PaidAmount;
                aReport.PaymentType = purchase.PaymentType;
                aReport.Quantity = purchase.Quantity;
                aReport.SupplierName = purchase.Supplier.Name;
                aReport.TotalAmount = purchase.Price;
                aReport.Unit = purchase.Unit.UnitName;
                aReport.UserName = purchase.CUserInfo.UserName;
                aReports.Add(aReport);
            }
            return aReports;
        }

        private void categoryNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InventoryItemBLL aaBll = new InventoryItemBLL();
            List<InventoryItem> aList = new List<InventoryItem>();
            if (Convert.ToInt32(categoryNameComboBox.SelectedIndex) >= 0)
            {
                InventoryCategory category = (InventoryCategory)categoryNameComboBox.SelectedItem;
                aList = aaBll.GetItemByCategory(category.CategoryId);
                rawMaterialsNameComboBox.DataSource = aList;
                rawMaterialsNameComboBox.DisplayMember = "ItemName";
                rawMaterialsNameComboBox.ValueMember = "ItemId";
            }
        }

        private void printPurchaseReportbutton_Click(object sender, EventArgs e)
        {
            InventoryPurchaseBLL aInventoryPurchaseBll = new InventoryPurchaseBLL();
            List<InventoryReport> aReports = new List<InventoryReport>();
            aReports = (List<InventoryReport>)inventoryPurchaseDataGridView.DataSource;

            if (aReports == null)
            {
                MessageBox.Show("No data Available Into GridView");
                return;
            }
            int printlenght = aReports.Count;
            PrintDocument doc = new TextDocument(aInventoryPurchaseBll.PrintPurchaseReport(aReports), printlenght);
            printReportLogoType = 1;
            doc.PrintPage += this.Doc_PrintPage;


            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            dlgSettings.UseEXDialog = true;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top - 15;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                   

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 420, 0);

                    //for Aroma Restaurant 
              
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                  

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), -12, 0);

                    //for Aroma Restaurant 
                 
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                  

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 20, 40);

                    //for Aroma Restaurant 
                    
                }


                doc.PageNumber += 1;

                while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
                {
                    e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
                    doc.Offset += 1;
                    y += lineHeight;
                }

                if (doc.Offset < doc.Text.GetUpperBound(0))
                {
                    e.HasMorePages = true;
                }
                else
                {
                    doc.Offset = 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }
        }
    }
}
