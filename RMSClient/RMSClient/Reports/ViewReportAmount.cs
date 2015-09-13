using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using RMS.Common.ObjectModel;
using RMS.Common;

namespace RMS.Reports
{
    public partial class ViewReportAmount : Form
    {

        public DateTime startDate { set; get; } // Change by Mithu
        public DateTime endDate { set; get; } // Change by Mithu
        public List<CSearchOrderInfo> aCSearchOrderInfos { set; get; } // Change by Mithu
        public List<DatewiseTotal> DatewiseTotals { set; get; } // Change by Mithu

        private int printReportLogoType = 0; // Change by Mithu
        public ViewReportAmount()
        {
            InitializeComponent();
        }

        private void printbutton_Click(object sender, EventArgs e)
        {
            int printlenght = DatewiseTotals.Count + 30;
            PrintDocument doc = new TextDocument(PrintReport(DatewiseTotals), printlenght);
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

        private string PrintReport(List<DatewiseTotal> datewiseTotals)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
            ViewReport aReport = new ViewReport();

            string header = aReport.GetPrintDecorationText(PrintDecoration.HEADER);

            printReportLogoType = 1;
            string[] lines = null;
            char[] param = { '\n' };
            if (header != null && header.Length > 0)
                lines = header.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };

            string TotalHader = "";
            if (lines != null && lines.Length > 0)
                foreach (string s in lines)
                {
                    TotalHader += stringPrintFormater.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }


            strBody += TotalHader;

            //   strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Monthly Report");

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            double total = (from Total in datewiseTotals select Total.TotalIncV).Sum();
            double totalvat = (from tvat in datewiseTotals select tvat.VatTotal).Sum();


            strBody += "\r\n" + stringPrintFormater.ItemLabeledText( "Total Paid (IncVat): " + total.ToString("F02"),"");
             strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Vat: "+totalvat.ToString("F02"),"");
            // strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Total Cost: " + cost.ToString("F02"));
             strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Date", 25, false);
            strBody += stringPrintFormater.GridCell("Order Total", 14, false);
            strBody += stringPrintFormater.GridCell("Cash", 12, false);
            strBody += stringPrintFormater.GridCell("Card", 12, false);
            strBody += stringPrintFormater.GridCell("Due", 12, false);

            strBody += stringPrintFormater.GridCell("Vat", 12, false);
            strBody += stringPrintFormater.GridCell("Food Total", 12, false);
            strBody += stringPrintFormater.GridCell("NonF Total", 12, false);
            strBody += stringPrintFormater.GridCell("Ser.Charge", 12, false);
            strBody += stringPrintFormater.GridCell("Discount", 12, false);

            // strBody += stringPrintFormater.GridCell("ExV Total", 12, true);
            strBody += stringPrintFormater.GridCell("IncV Total", 12, false);
            strBody += stringPrintFormater.GridCell("Covers", 12, false);
            //strBody += stringPrintFormater.GridCell("Cash", 12, true);
            //strBody += stringPrintFormater.GridCell("EFT", 12, true);
            //strBody += stringPrintFormater.GridCell("EFT Card", 16, false);

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            foreach (DatewiseTotal item in datewiseTotals)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(item.Date.ToString(), 25, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(item.OrderTotal.ToString("F02"), 14, false);
                strBody += stringPrintFormater.GridCell(item.CashTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.EFTTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.DueTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.VatTotal.ToString("F02"), 12, false);

                strBody += stringPrintFormater.GridCell(item.FoodTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.NoonFoodTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.ServiceChargeTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.DiscountTotal.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.TotalIncV.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(item.Covers.ToString(), 12, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine(); // Change by Mithu ( Date to Date Seperate will be)
                // strBody += stringPrintFormater.GridCell(item.OrderTotal.ToString(), 12, true);


                // strBody += stringPrintFormater.GridCell(item.TotalPaidExcludingVat.ToString(), 12, true);


                //strBody += stringPrintFormater.GridCell(item.CashPaid.ToString(), 12, true);

                //strBody += stringPrintFormater.GridCell(item.EFTCardName.ToString(), 16, false);
                //strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            // strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");


            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                           Checked By" + "                                                                       Prepared By         ";


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
                float y = e.MarginBounds.Top + 3;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 470, 35);

                    //for Aroma Restaurant 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 50, 0);

                    //for Aroma Restaurant 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\SKYSHEEP.png"), 50, 40);

                    //for Aroma Restaurant 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 50, 0);
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
