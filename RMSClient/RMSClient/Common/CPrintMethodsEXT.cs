using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using RMS.DataAccess;
using System.Data.SqlClient;
using System.Data;
using RMS.Common.ObjectModel;
using RMS.SystemManagement;
using System.Windows.Forms;

namespace RMS.Common
{
    public class CPrintMethodsEXT : CPrintMethods
    {
        private PrintDocument printDoc;

        private PrintDocument printA5ReportDoc;
        private PrintDestiNation printDestiNationType;
        private String printBody;
        private PrinterConfig printerConfig;

        private StringPrintFormater strPrintFormatterforA5;
       
        public CPrintMethodsEXT()
        {
            printerConfig = new PrinterConfig();
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            printA5ReportDoc = new PrintDocument();
            printA5ReportDoc.PrintPage += new PrintPageEventHandler(printA5ReportDoc_PrintPage);
           
        }

       
     

        public void USBPrint(String printBody, PrintDestiNation printDestiNation, bool displayHeaderFooter)
        {
            StringPrintFormater strPrintFormatter = new StringPrintFormater(37);
            printDestiNationType = printDestiNation;
            if (displayHeaderFooter)
            {
                string hader = GetPrintDecorationText(PrintDecoration.HEADER);

                string[] lines;
                char[] param = { '\n' };
                lines = hader.Split(param);
                int i = 0;
                char[] trimParam = { '\r' };

                string TotalHader = "";
                foreach (string s in lines)
                {
                    TotalHader += strPrintFormatter.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }
                this.printBody = "\r\n" + printBody.Insert(0, TotalHader);
              

                string footer = GetPrintDecorationText(PrintDecoration.FOOTER);
                string TotalFooter = "";
                lines = footer.Split(param);
                foreach (string s in lines)
                {
                    TotalFooter += strPrintFormatter.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }

                this.printBody += "\r\n" + TotalFooter;
                //this.printBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                //this.printBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Developed By: www.ibacs.co.uk");  // THIS IS THE AREA OF FOOTER.CHANGE BY MITHU
                
            }
            else
            {
                this.printBody = printBody;
            }
            try
            {
                switch (printDestiNation)
                {
                    case PrintDestiNation.KITCHEN:
                        printDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.KitchenPrinterName;

                        break;
                    case PrintDestiNation.BEVARAGE:
                        printDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.BeveragePrinterName;

                        break;
                    case PrintDestiNation.CLIENT:
                        printDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.ClientPrinterName;
                        break;
                    case PrintDestiNation.Other:
                       // printDoc.DefaultPageSettings.PrinterSettings.PrinterName = "\\\\mithu-PC\\CutePDF Writer";
                        printDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.OtherPrinter;

                        break;
                    case PrintDestiNation.OtherNonFood:
                        // printDoc.DefaultPageSettings.PrinterSettings.PrinterName = "\\\\mithu-PC\\CutePDF Writer";
                         printDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.OtherNonFoodPrinter;

                        break;
                }

                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
             
        }
        

        public void USBPrintA5Report(String printBody, PrintDestiNation printDestiNation, bool displayHeaderFooter, int paperSize)
        {
            StringPrintFormater strPrintFormatter = new StringPrintFormater(paperSize);
            strPrintFormatterforA5 = new StringPrintFormater(paperSize);
            if (displayHeaderFooter)
            {
                string hader = GetPrintDecorationText(PrintDecoration.HEADER);

                string[] lines=null;
                char[] param = { '\n' };
                if (hader != null && hader.Length>0)
                lines = hader.Split(param);
                int i = 0;
                char[] trimParam = { '\r' };

                string TotalHader = "";
                if(lines!= null && lines.Length>0)
                foreach (string s in lines)
                {
                    TotalHader += strPrintFormatter.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }
                this.printBody = "\r\n" + printBody.Insert(0, TotalHader);


                string footer = GetPrintDecorationText(PrintDecoration.FOOTER);
                string TotalFooter = "";
                lines = footer.Split(param);
                foreach (string s in lines)
                {
                    //TotalFooter += strPrintFormatter.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                    TotalFooter += strPrintFormatter.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }

                this.printBody += "\r\n" + TotalFooter;
         //       this.printBody += "\r\n" + strPrintFormatter.CreateDashedLine();
           //     this.printBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Developed By: www.ibacs.co.uk");

            }
            else
            {
                this.printBody = printBody;
            }
            try
            {
                  PaperSize printPaperSize = new PaperSize("A5 (210 x 148 mm)", 400, 200);
                 //PaperSize printPaperSize = new PaperSize("My Envelope", 148, 210);

                switch (printDestiNation)
                {
                    case PrintDestiNation.KITCHEN:
                        printA5ReportDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.KitchenPrinterName;                        
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.PaperSize = printPaperSize;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 5;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Right = 5;


                        break;
                    case PrintDestiNation.BEVARAGE:
                        printA5ReportDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.BeveragePrinterName;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.PaperSize = printPaperSize;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 5;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Right = 5;

                        break;
                    case PrintDestiNation.CLIENT:
                        printA5ReportDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.ClientPrinterName;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.PaperSize = printPaperSize;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 5;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Right = 5;

                        break;
                    case PrintDestiNation.Other:
                        printA5ReportDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.OtherPrinter;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.PaperSize = printPaperSize;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 5;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Right = 5;

                        break;

                    case PrintDestiNation.OtherNonFood:
                        printA5ReportDoc.DefaultPageSettings.PrinterSettings.PrinterName = printerConfig.BeveragePrinterName;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.PaperSize = printPaperSize;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Left = 5;
                        printA5ReportDoc.PrinterSettings.DefaultPageSettings.Margins.Right = 5;

                        break;
                }

                printA5ReportDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            #region with Image 
            Font printFont = new Font("Lucida Console", 9);
            Font printFont2 = new Font("Lucida Console", 9, FontStyle.Bold);


            int printHeight;
            int printWidth;
            printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
            printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

            StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
            //For RoofTop Restaurant            
            //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 60, 2);

            //For Labamba Restaurant            
            if (printDestiNationType == PrintDestiNation.CLIENT)
            {
                //for Chandrabindu Restaurant
               // e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\chandrabindu1.png"), 60, 2);


                //for rooftop Restaurant 
               // e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 60, 2);
                
                //for labamba Restaurant
                e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 40, 0);//For POS Printer
                //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 300, 0);//For A4 Printer
            }
            else if (printDestiNationType != PrintDestiNation.BEVARAGE && printDestiNationType != PrintDestiNation.KITCHEN && printDestiNationType != PrintDestiNation.Other && printDestiNationType != PrintDestiNation.OtherNonFood)
            {
                //for rooftop Restaurant
              //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 2);

                //for labamba Restaurant 
                 e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 10, 0);//For POS Printer
                //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 310, 0);//For A4 Printer
            }

            //   e.Graphics.DrawImage(Image.FromFile("d:\\carnival-logo2.PNG"), 80, 0);


            //  e.Graphics.DrawImage("",
           // RectangleF printArea = new RectangleF(0, 60, 260, printHeight);
            RectangleF printArea = new RectangleF(0, 200, 300, printHeight);//For POS Printer
            //RectangleF printArea = new RectangleF(270, 60, 300, printHeight);//For A4 Printer
            //    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

            //  Font printFont = new Font("Lucida Console", 8);
            Font printFont1 = new Font("Lucida Console", 25, FontStyle.Bold);

            if (printDestiNationType == PrintDestiNation.BEVARAGE || printDestiNationType == PrintDestiNation.KITCHEN || printDestiNationType == PrintDestiNation.Other || printDestiNationType == PrintDestiNation.OtherNonFood)
            {
                printBody = printBody.ToUpper();

                if (!printBody.Contains("TAKE AWAY"))
                {
                    RectangleF printArea1 = new RectangleF(0, 30, 300, printHeight);
                    string substring1 = printBody.Substring(0, printBody.IndexOf("COVERS"));
                   // string substring2 = printBody.Substring(printBody.IndexOf("TABLE"), printBody.IndexOf("COVERS:") + 10 - substring1.Length);
                    string substring3 = printBody.Substring(printBody.IndexOf("COVERS:"), printBody.Length - substring1.Length  - 1);
                    string newLine = "";
                    string newLine1 = "";
                    if (printDestiNationType == PrintDestiNation.KITCHEN || printDestiNationType == PrintDestiNation.Other || printDestiNationType == PrintDestiNation.BEVARAGE)
                    {
                        newLine = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r";
                        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
                    }
                    else
                    {
                        newLine = "\r\n\r\n\r\n\r\n\r\n\r\n\r";
                        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\n\r\r\n\r";
                    }
                    //e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                    e.Graphics.DrawString(substring1, printFont1, Brushes.Black, printArea1, format);
                   // e.Graphics.DrawString(newLine + substring2, printFont1, Brushes.Black, printArea, format);
                    e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea1, format);
                }
                else
                {
                    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
                }
            }
            else
            {

                if (!printBody.Contains("Sales Report (Order Wise)") && !printBody.Contains("Spilt Bill") && !printBody.Contains("Split#"))
                {
                    // e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                    string substring1 = printBody.Substring(0, printBody.IndexOf("Order ID:"));
                    string substring11 = printBody.Substring(printBody.IndexOf("Order ID:"),
                                                             printBody.IndexOf("\r\n\nOrder Information") -
                                                             substring1.Length);
                    string substring2 = printBody.Substring(printBody.IndexOf("\r\n\nOrder Information"),
                                                            printBody.IndexOf("Total:") - substring1.Length -
                                                            substring11.Length);
                    string substringcheck = printBody.Substring(printBody.IndexOf("Total:"),
                                                                printBody.Length - substring2.Length - 1 -
                                                                substring1.Length - substring11.Length);
                    string payment = Payment(substringcheck);
                    payment += "\r\n";
                    string substring3 = substringcheck.Substring(
                        substringcheck.IndexOf(substringcheck) + payment.Length,
                        printBody.Length - substring2.Length - 1 - payment.Length - substring1.Length -
                        substring11.Length);


                    string newline0 = "";
                    string newline00 = "";
                    string newLine = "";
                    string newLine1 = "";
                    newline0 = newlinesCount(substring1);
                    newline00 = newlinesCount(substring11 + substring1);
                    newLine = newlinesCount(substring2 + substring11 + substring1);
                    newLine1 = newlinesCount(substring2 + payment + substring11 + substring1);
                    payment = AddJustString(payment, 20); // Change by Mithu

                    e.Graphics.DrawString(substring1, printFont, Brushes.Black, printArea, format);
                    e.Graphics.DrawString(newline0 + substring11, printFont2, Brushes.Black, printArea, format);
                    e.Graphics.DrawString(newline00 + substring2, printFont, Brushes.Black, printArea, format);
                    e.Graphics.DrawString(newLine + payment, printFont2, Brushes.Black, printArea, format);
                    e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea, format);
                }
                else
                {
                    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
                }




            }

            #endregion

            #region  Without Image Area

            //Font printFont = new Font("Lucida Console", 8);
            //Font printFont1 = new Font("Lucida Console", 10);
            //// e.Graphics.DrawString(printBody, printFont, Brushes.Black, 0, 0);

            //int printHeight;
            //int printWidth;
            //printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
            //printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

            //StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
            //RectangleF printArea = new RectangleF(0, 0, 260, printHeight);

            ////  RectangleF printArea = new RectangleF(0, 0, 260, printHeight);

            //if (printDestiNationType == PrintDestiNation.BEVARAGE || printDestiNationType == PrintDestiNation.KITCHEN)
            //{
            //    printBody = printBody.ToUpper();

            //    if (printBody.Contains("TABLE"))
            //    {
            //        string substring1 = printBody.Substring(0, printBody.IndexOf("TABLE"));
            //        string substring2 = printBody.Substring(printBody.IndexOf("TABLE"), printBody.IndexOf("COVERS:") + 10 - substring1.Length);
            //        string substring3 = printBody.Substring(printBody.IndexOf("COVERS:") + 10, printBody.Length - substring1.Length - substring2.Length - 1);
            //        string newLine = "";
            //        string newLine1 = "";
            //        if (printDestiNationType == PrintDestiNation.KITCHEN)
            //        {
            //            newLine = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r";
            //            newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            //        }
            //        else
            //        {
            //            newLine = "\r\n\r\n\r\n\r\n\r\n\r";
            //            newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            //        }
            //        //e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

            //        e.Graphics.DrawString(substring1, printFont, Brushes.Black, printArea, format);
            //        e.Graphics.DrawString(newLine + substring2, printFont1, Brushes.Black, printArea, format);
            //        e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea, format);
            //    }
            //    else
            //    {
            //        e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
            //    }
            //}
            //else
            //{
            //    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
            //}

            #endregion

        }

        private string newlinesCount(string newlines)
        {
            string newlin = string.Empty;
            for (int i = 0; i < newlines.Length; i++)
            {
                if (newlines[i] == '\n' || newlines[i] == '\r')
                {
                    newlin += newlines[i];
                }
            }
            return newlin;
        }


        private string AddJustString(string payment, int cnt)  
        {
            string str = string.Empty;
            int cn = 0;
            while (cn < cnt)
            {
                str += " ";
                cn++;
            }
            cn = 0;
            if (payment.Length != 0)
            {
                while (payment[cn] != ':')
                {
                    str += payment[cn];
                    cn++;
                }
            }
            str += ":";
            int chk = 0;
            string temp = string.Empty;
            for (int i = cn + 1; i < payment.Length; i++)
            {
                if ((payment[i] >= '0' && payment[i] <= '9') || payment[i] == '.')
                {

                    temp += payment[i];
                  
                }
            }
            cn = temp.Length;
            while (cn < 9)
            {
                str += " ";
                cn++;
            }
            str += "";
            str += temp;

            return str;
        }


        private string Payment(string substringcheck)
        {
            string sr = string.Empty;

            for (int i = 0; i < substringcheck.Length; i++)
            {
                if (substringcheck[i] == '-')
                {
                    break;
                }
                else if (substringcheck[i] != '\n' && substringcheck[i] != '\r') sr += substringcheck[i];
            }

            return sr;
        }
        public string GetPrintDecorationText(PrintDecoration printDecoration)
        {
            string firstString="[---]";
           
            string fieldName = printDecoration==PrintDecoration.HEADER? "header": "footer";
            try
            {

                string HeaderContent = HeaderFooterDataset().Tables["PrintStyle"].Select("style_name = 'normal'")[0][fieldName].ToString();
            StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
            firstString = tempStringTokenizer.NextToken();

                while (tempStringTokenizer.HasMoreTokens())
                {
                    firstString+= "\r\n"+tempStringTokenizer.NextToken();
             
                }
             }
            catch (Exception esx)
            { 
            
            
            }

            return firstString;
        }

        private void printA5ReportDoc_PrintPage(object sender, PrintPageEventArgs e) // Change by Mithu
        {
            #region with Image
            Font printFont = new Font("Lucida Console", 8);

            int printHeight;
            int printWidth;

            printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
            printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

            //printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height; //-((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
            // printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width;// -((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

            StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

            //   e.Graphics.DrawImage(Image.FromFile("d:\\carnival-logo2.PNG"), 80, 0);
            // for Aroma Restaurant
            // e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 190, 2);

            // for RoofTop Restaurant
            //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop1.png"), 80, 2);
            e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.png"), 310, 2);


            //  e.Graphics.DrawImage("",
            // For RoofTop Restaurant
            RectangleF printArea = new RectangleF(130, 80, 565, printHeight);
            // RectangleF printArea = new RectangleF(130, 80, 260, printHeight);
            //  for Aroma Restaurant
            // RectangleF printArea = new RectangleF(130, 110, 565, printHeight);

            //   e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

            #region Customize Print

            Font printFont1 = new Font("Lucida Console", 12, FontStyle.Bold);
            Font printFont2 = new Font("Lucida Console", 8, FontStyle.Bold);

            string substring1 = "";
            string substring2 = "";
            string substring3 = "";
            if (printBody.Contains("GUEST BILL"))
            {
                substring1 = printBody.Substring(0, printBody.IndexOf("GUEST") - 9);
                substring2 = printBody.Substring(printBody.IndexOf("GUEST") - 12, printBody.IndexOf("BILL") + 10 - substring1.Length);
                /// substring2 = strPrintFormatterforA5.CenterTextWithWhiteSpace(substring2.Trim());
                substring2 = "     " + substring2;
                substring3 = printBody.Substring(printBody.IndexOf("BILL") + 10, printBody.Length - substring1.Length - substring2.Length - 1);
            }
            else
            {
                substring1 = printBody.Substring(0, printBody.IndexOf("BILL") - 9);
                substring2 = printBody.Substring(printBody.IndexOf("BILL") - 12, printBody.IndexOf("PAYMENT") + 10 - substring1.Length);
                substring2 = "     " + substring2;
                substring3 = printBody.Substring(printBody.IndexOf("PAYMENT") + 10, printBody.Length - substring1.Length - substring2.Length - 1);
            }


            string newLine = "";
            string newLine1 = "";
            if (printDestiNationType == PrintDestiNation.KITCHEN)
            {
                newLine = "\r\n\r\n\r\n\r\n\r\n";
                newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            }
            else
            {
                newLine = "\r\n\r\n\r\n\r\n\r\n\r";
                newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            }
            //e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

            e.Graphics.DrawString(substring1, printFont, Brushes.Black, printArea, format);
            e.Graphics.DrawString(newLine + substring2, printFont1, Brushes.Black, printArea, format);
            e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea, format);

            #endregion
            #endregion
        }  // Change by Mithu


        //private void printA5ReportDoc_PrintPage(object sender, PrintPageEventArgs e)   // Change by Mithu
        //{
        //    #region with Image
        //    Font printFont = new Font("Lucida Console", 8);

        //    int printHeight;
        //    int printWidth;

        //    printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
        //    printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

        //    //printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height; //-((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;  \\ CHANGE BY MITHU ...........................................
        //    // printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width;// -((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

        //    StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

        //    //   e.Graphics.DrawImage(Image.FromFile("d:\\carnival-logo2.PNG"), 80, 0);
        //    //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 240, 2);


        //    //  e.Graphics.DrawImage("",
        //    //RectangleF printArea = new RectangleF(0, 80, 260, printHeight);

        //    RectangleF printArea = new RectangleF(210, 160, 490, printHeight);

        //    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

        //    #endregion
        //}  // Change by Mithu


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
    public enum PrintDecoration
    {
        HEADER,
        FOOTER
    }
    public enum PrintDestiNation
    {
        KITCHEN,
        BEVARAGE,
        CLIENT,
        Other,
        OtherNonFood
    }
}
