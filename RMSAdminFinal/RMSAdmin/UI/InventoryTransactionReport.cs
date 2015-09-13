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

namespace BistroAdmin.UI
{
    public partial class InventoryTransactionReport : UserControl
    {
        private int printReportLogoType = 0;
        public InventoryTransactionReport()
        {
            InitializeComponent();

            InventoryCategoryBLL aBlll = new InventoryCategoryBLL();
            List<InventoryCategory> aaList = new List<InventoryCategory>();
            aaList = aBlll.GetAllCategory();
            categoryNameComboBox.DataSource = aaList;
            categoryNameComboBox.DisplayMember = "CategoryName";
            categoryNameComboBox.ValueMember = "CategoryId";


            // This used for which package is activation
            //BookedTransactionTypecomboboxForBusiness();// when Businees Package is active
             BookedTransactionTypecomboboxForProfessional();// when  Professional Package is active


        }
  


        private void BookedTransactionTypecomboboxForBusiness()
        {
            transactionNamecomboBox.DataSource = new List<string>
                                                 {
                                                     "Stock In",
                                                     "Damage_in_kitchen"
                                                 };
        }

        private void BookedTransactionTypecomboboxForProfessional()
        {
            transactionNamecomboBox.DataSource = new List<string>
                                                 {
                                                     "Send_to_Kitchen",
                                                     "Return_from_Kitchen",
                                                     "Damage_in_kitchen",
                                                     "Damage_in_Stock",
                                                     "Stock_Out_In_Kitchen"
                                                 };
        }

        private void categoryNameComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
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

        private void showButton_Click(object sender, EventArgs e)
        {


            DateTime fromdate = fromdateTimePicker.Value;
            DateTime todate = todateTimePicker.Value;
            todate = todate.AddDays(1);
           // todate = todate.AddSeconds(-1);
            fromdate = fromdate.Date;
            todate = todate.Date;
            todate = todate.AddSeconds(-1);
            List<Transaction> aTransactions=new List<Transaction>();
            TransactionBLL aTransactionBll=new TransactionBLL();
            aTransactions = aTransactionBll.GetTransactionBetweenDate(fromdate,todate);

           // inventoryTransactionDataGridView.DataSource = aTransactions;
             ShowReport(aTransactions);

        }

        private void ShowReport(List<Transaction> aTransactions)
        {
            try
            {

      
            string sr =(string) transactionNamecomboBox.SelectedItem;
            InventoryItem aItem = (InventoryItem)rawMaterialsNameComboBox.SelectedItem;
            InventoryCategory aCategory = (InventoryCategory)categoryNameComboBox.SelectedItem;
            List<Transaction> aList = new List<Transaction>();


            if (viewAllRawcheckBox.Checked && transactioncheckBox.Checked)
            {
                aList = (from aTransaction in aTransactions
                         where aTransaction.TransactionType == sr
                         select aTransaction).ToList();
            }
            else if (viewAllAbovecheckBox.Checked && transactioncheckBox.Checked)
            {
                aList = (from aTransaction in aTransactions
                         where (aTransaction.TransactionType == sr && aTransaction.Category.CategoryId == aCategory.CategoryId)
                         select aTransaction).ToList();
            }
            else if (transactioncheckBox.Checked)
            {
                aList = (from aTransaction in aTransactions
                         where (aTransaction.TransactionType == sr && aTransaction.Item.ItemId == aItem.ItemId &&
                         aTransaction.Category.CategoryId == aCategory.CategoryId)
                         select aTransaction).ToList();
            }
            else if (viewAllRawcheckBox.Checked)
            {
                aList = aTransactions;
            }
            else if (viewAllAbovecheckBox.Checked)
            {
                aList = (from aTransaction in aTransactions
                         where (aTransaction.Category.CategoryId == aCategory.CategoryId)
                         select aTransaction).ToList();
            }
            else
            {
                aList = (from aTransaction in aTransactions
                         where (aTransaction.Item.ItemId == aItem.ItemId && aTransaction.Category.CategoryId == aCategory.CategoryId)
                         select aTransaction).ToList();
            }

            List<TransationReport> aReport = ConvertReport(aList);
            inventoryTransactionDataGridView.DataSource = aReport;


            }
            catch (Exception)
            {
            }
        }

        private List<TransationReport> ConvertReport(List<Transaction> aList)
        {
            List<TransationReport> aReports=new List<TransationReport>();
            foreach (Transaction transaction in aList)
            {
                TransationReport aTransationReport=new TransationReport();
                aTransationReport.CategoryName = transaction.Category.CategoryName;
                aTransationReport.DamageReport = transaction.DamageReport;
                aTransationReport.Date = transaction.TransactionDate;
                aTransationReport.ItemName = transaction.Item.ItemName;
                aTransationReport.Quantity = transaction.Stock.Stocks;
                aTransationReport.TotalPrice = transaction.TransactionAmount;
                aTransationReport.TransactionType = transaction.TransactionType;
                aTransationReport.Unit = transaction.Unit.UnitName;
                aTransationReport.UnitPrice = transaction.Stock.UnitPrice;
                aTransationReport.UserName = transaction.UserInfo.UserName;
                aReports.Add(aTransationReport);
            }
            return aReports;
        }

        private void printTransactionReportbutton_Click(object sender, EventArgs e)
        {
            TransactionBLL aTransactionBll = new TransactionBLL();
            List<TransationReport> aReports = new List<TransationReport>();
            aReports = (List<TransationReport>)inventoryTransactionDataGridView.DataSource;

            if (aReports== null)
            {
                MessageBox.Show("No data Available Into GridView");
                return;
            }
            int printlenght = aReports.Count;
            PrintDocument doc = new TextDocument(aTransactionBll.PrintTransactionReport(aReports), printlenght);
            //ViewReport aReport = new ViewReport();
            printReportLogoType = 1;
            doc.PrintPage += this.Doc_PrintPage;
            doc.DefaultPageSettings.Landscape = true;
            
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.UseEXDialog = true;
            dlgSettings.Document = doc;

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

        private void transactionNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
