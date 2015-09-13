using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.SystemManagement;
using RMS.Common;
using System.Drawing.Printing;
using RMS.Utility;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using System.Data.SqlClient;


namespace RMS.Reports
{
    public partial class ItemReportForm : Form
    {
        private StringPrintFormater stringPrintFormater;
        private DateTime fromDate;
        private DateTime toDate;
        private DataTable dtFood;
        private DataTable dtNonFood;

        //private FiscalPrinter fiscalPrinter;
        CPrintMethodsEXT tempPrintMethods;
        private string dateRangeText = "";
        private bool _showAll;

        private int printReportLogoType = 0;

        public ItemReportForm(Int64 fromOID, Int64 toOID, DateTime fromDate, DateTime toDate, int orderCount, bool showAll, string _dateRangeText)
        {
            InitializeComponent();
           // fiscalPrinter = new FiscalPrinter();
            tempPrintMethods = new CPrintMethodsEXT();


            this.fromDate = fromDate;
            this.toDate = toDate;
            dateRangeText = _dateRangeText;
            _showAll = showAll;

            lblDate.Text += "  " + fromDate.ToLongDateString() + " to: " + toDate.ToLongDateString();
            lblOrderCount.Text += orderCount;


            SystemManager sysManager = new SystemManager();

            dtFood = sysManager.GetItemWiseSales(fromOID, toOID, "Food", Convert.ToByte(showAll));
            gridViewFood.DataSource = dtFood;

            dtNonFood = sysManager.GetItemWiseSales(fromOID, toOID, "NonFood", Convert.ToByte(showAll));
            gridViewNonFood.DataSource = dtNonFood;

            if (dtFood != null && dtNonFood != null)
            {
                int query =
                (from order in dtFood.AsEnumerable()
                 select order.Field<Int32>("QuantitySold")).Sum();

                lblQtySoldFood.Text += " " + query;


                int query2 =
                (from order in dtNonFood.AsEnumerable()
                 select order.Field<Int32>("QuantitySold")).Sum();

                lblQtySoldNonFood.Text += " " + query2;
                lblQtySoldTotal.Text += " " + (query2 + query);


                Double P1 = 0;
                Double P2 = 0;

                foreach (DataRow row in dtFood.Rows)
                {
                    P1 += Convert.ToDouble(row["TotalPrice"].ToString());
                }
                foreach (DataRow row in dtNonFood.Rows)
                {
                    P2 += Convert.ToDouble(row["TotalPrice"].ToString());
                }
                lblPriceFood.Text += " " + P1.ToString("F02");
                lblPriceNonFood.Text += " " + P2.ToString("F02");
                lblPriceTotal.Text += " " + (P1 + P2).ToString("F02");

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printReportLogoType = 1;
            int printlenght = dtFood.Rows.Count + dtNonFood.Rows.Count + 28;
            PrintDocument doc = new TextDocument(PrintReport(dtFood, dtNonFood), printlenght);
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

            //tempPrintMethods.USBPrint(getSummaryPrintText(dateRangeText, 29, true), PrintDestiNation.CLIENT, false);
        }
        private string PrintReport(DataTable dtFood, DataTable dtNonFood)
        {
            stringPrintFormater = new StringPrintFormater(172);

            string strBody = "";
            string header = GetPrintDecorationText(PrintDecoration.HEADER);


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
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("SALES REPORT- ITEM WISE");
          //  strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("RED CHICK'N");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Date: From - " + fromDate.ToShortDateString() + " to " + toDate.ToShortDateString());
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblOrderCount.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldFood.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldNonFood.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldTotal.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceFood.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceNonFood.Text, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceTotal.Text, "");

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS : FOOD");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Item ID", 15, false);
            strBody += stringPrintFormater.GridCell("Item Name", 45, false);
            strBody += stringPrintFormater.GridCell("Price Per Unit", 18, false);
            strBody += stringPrintFormater.GridCell("Quantity Sold", 18, false);

            strBody += stringPrintFormater.GridCell("Total Price", 18, false);
            strBody += stringPrintFormater.GridCell("Total Cost", 18, false);
            strBody += stringPrintFormater.GridCell("Profit", 18, false);
            strBody += stringPrintFormater.GridCell("Profit(%)", 18, false);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (DataRow row in dtFood.Rows)
            {

                strBody += "\r\n" + stringPrintFormater.GridCell(row[0].ToString(), 15, false);
                strBody += stringPrintFormater.GridCell(row[1].ToString(), 45, false);
                strBody += stringPrintFormater.GridCell(row[2].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[3].ToString(), 18, false);

                strBody += stringPrintFormater.GridCell(row[4].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[5].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[6].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[7].ToString(), 18, false);


                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS : NON FOOD");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            foreach (DataRow row in dtNonFood.Rows)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(row[0].ToString(), 15, false);
                strBody += stringPrintFormater.GridCell(row[1].ToString(), 45, false);
                strBody += stringPrintFormater.GridCell(row[2].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[3].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[4].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[5].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[6].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row[7].ToString(), 18, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

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
                #region with Image
                //Font printFont = new Font("Lucida Console", 8);


                //int printHeight;
                //int printWidth;
                //printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
                //printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

                //StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

                ////   e.Graphics.DrawImage(Image.FromFile("d:\\carnival-logo2.PNG"), 80, 0);
                //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 60, 2);


                ////  e.Graphics.DrawImage("",
                //RectangleF printArea = new RectangleF(0, 60, 260, printHeight);

                ////    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                ////  Font printFont = new Font("Lucida Console", 8);
                //Font printFont1 = new Font("Lucida Console", 10);

                //if (printDestiNationType == PrintDestiNation.BEVARAGE || printDestiNationType == PrintDestiNation.KITCHEN)
                //{
                //    printBody = printBody.ToUpper();

                //    string substring1 = printBody.Substring(0, printBody.IndexOf("TABLE"));
                //    string substring2 = printBody.Substring(printBody.IndexOf("TABLE"), printBody.IndexOf("COVERS:") + 10 - substring1.Length);
                //    string substring3 = printBody.Substring(printBody.IndexOf("COVERS:") + 10, printBody.Length - substring1.Length - substring2.Length - 1);
                //    string newLine = "";
                //    string newLine1 = "";
                //    if (printDestiNationType == PrintDestiNation.KITCHEN)
                //    {
                //        newLine = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r";
                //        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
                //    }
                //    else
                //    {
                //        newLine = "\r\n\r\n\r\n\r\n\r\n\r";
                //        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
                //    }
                //    //e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                //    e.Graphics.DrawString(substring1, printFont, Brushes.Black, printArea, format);
                //    e.Graphics.DrawString(newLine + substring2, printFont1, Brushes.Black, printArea, format);
                //    e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea, format);
                //}
                //else
                //{
                //    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
                //}

                #endregion

                #region  Image

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                //    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 400, 0);

                     //for Aroma Restaurant 
                     //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
                    
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                  //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 0,0);

                    //for Aroma Restaurant 
                 //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                //    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 35, 40);

                    //for Aroma Restaurant 
                   // e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
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

                #endregion


                #region Without Image 
                
                //TextDocument doc = (TextDocument)sender;

                //Font font = new Font("Lucida Console", 7);

                //float lineHeight = font.GetHeight(e.Graphics);

                //float x = e.MarginBounds.Left;
                //float y = e.MarginBounds.Top ;
               

                //doc.PageNumber += 1;

                //while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
                //{
                //    e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
                //    doc.Offset += 1;
                //    y += lineHeight;
                //}

                //if (doc.Offset < doc.Text.GetUpperBound(0))
                //{
                //    e.HasMorePages = true;
                //}
                //else
                //{
                //    doc.Offset = 0;
                //}

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }

        }

        private void btnRPPrintSummary_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new TextDocument(getSummaryPrintDoc(dateRangeText, 29, true));
            doc.PrintPage += this.Doc_PrintPage;

            //doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }


            // tempPrintMethods.USBPrint(getSummaryPrintDoc(dateRangeText, 29), PrintDestiNation.CLIENT, false);
        }

        private void btnFPPrintSummary_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to print this Report with the fiscal print?", "Confirmation", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
               // if (fiscalPrinter.foundPrinter())
                 //   fiscalPrinter.PerformReportPrint(getSummaryPrintDoc(dateRangeText, 35, false));
            }
        }

        private string getSummaryPrintDoc(string dateString, int lineLength, bool showHeader)
        {
            printReportLogoType = 2;

            stringPrintFormater = new StringPrintFormater(lineLength);


            string strPrint = "";
            if (_showAll)
            {
                strPrint += "\r\n" + stringPrintFormater.CenterTextWithDashed("**********") + "\r\n";
            }
            if (showHeader)
            {
               // strPrint += "\r\n" + tempPrintMethods.GetPrintDecorationText(PrintDecoration.HEADER);

                string header = GetPrintDecorationText(PrintDecoration.HEADER);


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


                strPrint += TotalHader;
            }
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Sales Report (Item Wise)");
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(dateString);

            strPrint += "\r\n";
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + lblQtySoldFood.Text;
            strPrint += "\r\n" + lblQtySoldNonFood.Text;
            strPrint += "\r\n" + lblQtySoldTotal.Text;
            strPrint += "\r\n" + lblPriceFood.Text;
            strPrint += "\r\n" + lblPriceNonFood.Text;
            strPrint += "\r\n" + lblPriceTotal.Text;
          //  strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
         //   strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Item(s)");
         //   strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            // strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Sold Food Qty:", stringPrintFormater.CenterTextWithWhiteSpace("Items Price(" +Program.currency +")"));
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            //  strPrint += "\r\n";
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("FOOD ITEM");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            Utility.PrintUtility printUtility = new Utility.PrintUtility();
            foreach (DataRow row in dtFood.Rows)
            {

                strPrint += "\r\n" + (row[1].ToString());
                strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(row[2].ToString() + " x " + row[3].ToString(), row[4].ToString());
                //strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

                //  strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(printUtility.MultipleLine(row[2].ToString(), 33, "", 38) + " x " + row[3].ToString(), row[4].ToString());
            }


            strPrint += "\r\n\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("NON FOOD ITEM");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();


            foreach (DataRow row in dtNonFood.Rows)
            {
                strPrint += "\r\n" + (row[1].ToString());
                strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(row[2].ToString() + " x " + row[3].ToString(), row[4].ToString());
                //strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            }

            //PrintUtility printUtility = new PrintUtility();

            //foreach (DataRow row in dtFood.Rows)
            //{

            //    strPrint += "\r\n" + printUtility.MultipleLine((row[1].ToString()),36,"",36 );
            //    strPrint +=   stringPrintFormater.ItemLabeledText(row[2].ToString() + " x " + row[3].ToString(), row[4].ToString());
            //    strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            //}



            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + "Printed at : ";
            strPrint += "\r\n" + DateTime.Now.ToString("dd MMMM yyyy") + "-" + DateTime.Now.ToString("hh:mm:ss tt");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("End Report");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            //MessageBox.Show(strPrint);

            return strPrint;


        }


        public string GetPrintDecorationText(PrintDecoration printDecoration)
        {
            string firstString = "[---]";

            string fieldName = printDecoration == PrintDecoration.HEADER ? "header" : "footer";
            try
            {

                string HeaderContent = HeaderFooterDataset().Tables["PrintStyle"].Select("style_name = 'normal'")[0][fieldName].ToString();
                StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
                firstString = tempStringTokenizer.NextToken();

                while (tempStringTokenizer.HasMoreTokens())
                {
                    firstString += "\r\n" + tempStringTokenizer.NextToken();

                }
            }
            catch (Exception esx)
            {


            }

            return firstString;
        }

        private DataSet HeaderFooterDataset()
        {
            DataSet tempDataSet = new DataSet();

            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            string tempConnectionString = oConstants.DBConnection;
            string sSql = SqlQueries.GetQuery(Query.GetPrintStyles);
            SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sSql, tempConnectionString);
            tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

            return tempDataSet;
        }  
    }
}
