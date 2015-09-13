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
using Common.ObjectModel;

namespace BistroAdmin.UI
{
    public partial class InventoryKitchenStockReportForm : UserControl
    {
        private int printReportLogoType = 0;
        public InventoryKitchenStockReportForm()
        {
            InitializeComponent();
            InventoryCategoryBLL aBlll = new InventoryCategoryBLL();
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
            categoryNameComboBox.DataSource = aaList;
            categoryNameComboBox.DisplayMember = "CategoryName";
            categoryNameComboBox.ValueMember = "CategoryId";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            DateTime fromdate = fromdateTimePicker.Value;
            DateTime todate = todateTimePicker.Value;
            todate = todate.AddDays(1);
            fromdate = fromdate.Date;
            todate = todate.Date;
            todate = todate.AddSeconds(-1);
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            InventoryKitchenStockReportBLL aBll = new InventoryKitchenStockReportBLL();
            aInventoryStockReports = aBll.GetInventoryKitchenStockReportBetweenDate(fromdate, todate);
            ShowReport(aInventoryStockReports);

        }

        private void ShowReport(List<InventoryStockReport> aInventoryStockReports)
        {

            try
            {
                InventoryItem aItem = (InventoryItem)rawMaterialsNameComboBox.SelectedItem;
                InventoryCategory aCategory = (InventoryCategory)categoryNameComboBox.SelectedItem;
                List<InventoryStockReport> aList = new List<InventoryStockReport>();



                if (viewAllRawcheckBox.Checked)
                {
                    aList = aInventoryStockReports;
                }
                else if (viewAllAbovecheckBox.Checked)
                {
                    aList = (from report in aInventoryStockReports
                             where report.CategoryId == aCategory.CategoryId
                             select report).ToList();
                }
                else
                {
                    aList = (from report in aInventoryStockReports
                             where (report.ItemId == aItem.ItemId && report.CategoryId == aCategory.CategoryId)
                             select report).ToList();
                }


                double totalRawCost = aList.Sum(a => a.Price);
                rawCostingLabel.Text = "Total Raw Costing= " + totalRawCost.ToString("F02");
                double balanceAmount = aList.Sum(a => a.UnitPrice * a.BalanceQty);
                balancelabel.Text = balanceAmount.ToString("F02");

                inventorykitchenstockDataGridView.DataSource = aList;
            }
            catch (Exception)
            {

            }

           
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

        private void printkitchenStockReportbutton_Click(object sender, EventArgs e)
        {
            InventoryKitchenStockReportBLL aBll = new InventoryKitchenStockReportBLL();
            List<InventoryStockReport> aReports = new List<InventoryStockReport>();
            aReports = (List<InventoryStockReport>)inventorykitchenstockDataGridView.DataSource;
            if (aReports == null)
            {
                MessageBox.Show("No data Available Into GridView");
                return;
            }
            int printlenght = aReports.Count;
            PrintDocument doc = new TextDocument(aBll.PrintKitchenStockReport(aReports), printlenght);
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

                TextDocument doc = (TextDocument) sender;

                Font font = new Font("Lucida Console", 8);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                 

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 465, 0);

                    //for Aroma Restaurant 
                
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                  

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), -5, 0);

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

        private void InventoryKitchenStockReportForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
