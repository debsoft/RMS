using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using Database.Queries;

namespace RMSAdmin.Purchase
{
    public partial class FoodAndNoonFoodTransaction : Form
    {
        public FoodAndNoonFoodTransaction()
        {
            InitializeComponent();
        }

        private void showreportButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromdateTimePicker.Value;
            fromDate = fromDate.Date;
             DateTime toDate = todateTimePicker.Value;
            toDate = toDate.Date;
            toDate = toDate.AddDays(1);
            toDate = toDate.AddSeconds(-1);

            List<Transaction1> aTransactions=new List<Transaction1>();
            StoreDAO  aStoreDao=new StoreDAO();
            aTransactions = aStoreDao.GetTransactionBydate(fromDate, toDate, Convert.ToInt32(categorycomboBox.SelectedValue));
            fooddataGridView.DataSource = aTransactions;
        }

        private void printReportbutton_Click(object sender, EventArgs e)
        {
            List<Transaction1> aTransactions = new List<Transaction1>();
            aTransactions =(List < Transaction1 >)fooddataGridView.DataSource;

            if (aTransactions == null)
            {
                MessageBox.Show("No data Available");
                return;
            }
            int printlenght = aTransactions.Count;
            PrintDocument doc = new TextDocument(FoodAndNoonFoodReportPrint(aTransactions), printlenght);

            doc.PrintPage += this.Doc_PrintPage;


            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private string FoodAndNoonFoodReportPrint(List<Transaction1> aTransactions)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
            VariousMethod aMethod = new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Food and Noon Food Purchase Report");
            // strBody += "\r\n";


            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Date", 30, false);
            strBody += stringPrintFormater.GridCell("Item Name", 27, false);
            strBody += stringPrintFormater.GridCell("Transaction Type", 27, false);
            strBody += stringPrintFormater.GridCell("Quantity", 27, false);
            strBody += stringPrintFormater.GridCell("Item Unit", 27, false);
            strBody += stringPrintFormater.GridCell("Amount", 27, false);
            strBody += stringPrintFormater.GridCell("Supplier1", 27, false);
           


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (Transaction1 report in aTransactions)
            {
             //   if (report.TransactionType == "Purchase")
                {
                    strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 30, false);
                    strBody += stringPrintFormater.GridCell(report.ItemName, 27, false);
                    strBody += stringPrintFormater.GridCell(report.TransactionType, 27, false);
                    strBody += stringPrintFormater.GridCell(report.Quantity.ToString("F02"), 27, false);
                    strBody += stringPrintFormater.GridCell(report.ItemUnit, 27, false);
                    
                    strBody += stringPrintFormater.GridCell(report.Amount.ToString("F02"), 27, false);
                    strBody += stringPrintFormater.GridCell(report.SupplierName, 27, false);


                    strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
                }

            }


            strBody += aMethod.AddEndPart();


            return strBody;
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



                e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.jpg"), 465, 0);






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

        private void FoodAndNoonFoodTransaction_Load(object sender, EventArgs e)
        {
            StoreDAO aStoreDao = new StoreDAO();
            List<Store> aList = new List<Store>();
            aList = aStoreDao.GetAllRawmaterialCategory();
            categorycomboBox.DataSource = aList;
            categorycomboBox.ValueMember = "StoreId";
            categorycomboBox.DisplayMember = "ItemName";
        }
    }
}
