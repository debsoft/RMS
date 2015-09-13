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
using Database;
using Database.Queries;

namespace RMSAdmin.Purchase
{
    public partial class ProfitLossReport : Form
    {
        public ProfitLossReport()
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

            List<Transaction1> otherTransactions = new List<Transaction1>();
            List<Transaction1> aTransactions = new List<Transaction1>();
            List<Transaction1> employeeTransactions = new List<Transaction1>();
            StoreDAO aStoreDao = new StoreDAO();
            EmployeeDAO aEmployeeDao=new EmployeeDAO();
            otherTransactions = aStoreDao.GetOtherTransactionBydateForProfit(fromDate, toDate);
            aTransactions = aStoreDao.GetTransactionBydateForProfit(fromDate, toDate);
            employeeTransactions = aEmployeeDao.EmployeeTransactionReportBydate(fromDate, toDate);

            Int64 startDate = new DateTime(fromdateTimePicker.Value.Year, fromdateTimePicker.Value.Month, fromdateTimePicker.Value.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = todateTimePicker.Value.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;
            List<Transaction1> saleTransactions = new List<Transaction1>();
            saleTransactions = aStoreDao.showAllData(startDate, endDate);
            toDate = todateTimePicker.Value;
            toDate = toDate.Date;
            List<ProfitLoss> aProfitLosses=new List<ProfitLoss>();
            while(fromDate<=toDate)
            {
                ProfitLoss aProfitLoss=new ProfitLoss();
                aProfitLoss.Date = fromDate;
                aProfitLoss.AccsCost = AmountCalculate(otherTransactions, fromDate);
                aProfitLoss.RMCost = AmountCalculate(aTransactions, fromDate);
                aProfitLoss.SalaryCost = AmountCalculate(employeeTransactions, fromDate);
                aProfitLoss.SaleAmount = AmountCalculate(saleTransactions, fromDate);
                double amount1 = (aProfitLoss.AccsCost + aProfitLoss.RMCost + aProfitLoss.SalaryCost);
                if (aProfitLoss.SaleAmount - amount1 < 0)
                {
                    aProfitLoss.Loss = aProfitLoss.SaleAmount - amount1;
                }
                else aProfitLoss.Profit = aProfitLoss.SaleAmount - amount1;
                aProfitLosses.Add(aProfitLoss);
                fromDate = fromDate.AddDays(1);
            }

            profitlossdataGridView.DataSource = aProfitLosses;

        }

        private double AmountCalculate(List<Transaction1> otherTransactions, DateTime fromDate)
        {
            double amount = (from transaction in otherTransactions where 
                     transaction.Date == fromDate select transaction.Amount).Sum ();
            return amount;
        }

        private void reportprintbutton_Click(object sender, EventArgs e)
        {
            List<ProfitLoss> aProfitLosses = new List<ProfitLoss>();
            aProfitLosses = (List<ProfitLoss>) profitlossdataGridView.DataSource;

            if (aProfitLosses == null)
            {
                MessageBox.Show("No data Available");
                return;
            }
            int printlenght = aProfitLosses.Count;
            PrintDocument doc = new TextDocument(ProfitLossReportPrint(aProfitLosses), printlenght);

            doc.PrintPage += this.Doc_PrintPage;


            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private string ProfitLossReportPrint(List<ProfitLoss> aProfitLosses)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
            VariousMethod aMethod = new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Profit Loss Report");
            // strBody += "\r\n";


            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Date", 30, false);
            strBody += stringPrintFormater.GridCell("Row Mat. Cost", 22, false);
            strBody += stringPrintFormater.GridCell("Accessory Cost", 22, false);
            strBody += stringPrintFormater.GridCell("Salary Cost", 22, false);
            strBody += stringPrintFormater.GridCell("Sale Amount", 22, false);
            strBody += stringPrintFormater.GridCell("Profit", 22, false);
            strBody += stringPrintFormater.GridCell("Loss", 22, false);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (ProfitLoss report in aProfitLosses)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 30, false);
                strBody += stringPrintFormater.GridCell(report.RMCost.ToString("F02"), 22, false);
                strBody += stringPrintFormater.GridCell(report.AccsCost.ToString("F02"), 22, false);
                strBody += stringPrintFormater.GridCell(report.SalaryCost.ToString("F02"), 22, false);
                strBody += stringPrintFormater.GridCell(report.SaleAmount.ToString("F02"), 22, false);
                strBody += stringPrintFormater.GridCell(report.Profit.ToString("F02"), 22, false);
                strBody += stringPrintFormater.GridCell(report.Loss.ToString("F02"), 22, false);

                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

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
    }
}
