using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common;
using System.Windows.Forms;
using RMS.Reports;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections;

namespace RMS.Utility
{
  public class PrintUtility
    {
        public bool A4PrintSelectPrint(string printContent, int printContentLineCount)
        {

            //PrintDocument doc = new TextDocument(printContent, printContentLineCount);
            PrintDocument doc = new TextDocument(printContent);//@Salim

            doc.PrintPage += this.printDocument1_PrintPage;

            PrintDialog printDialog1 = new PrintDialog();

            // pageSetupDialog1 = new PageSetupDialog();


            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                // printDialog1.ShowDialog();

                if (printDialog1.PrinterSettings.PrinterName != null)
                {
                    if (printDialog1.PrinterSettings.PrinterName != null)
                    {
                        doc.DefaultPageSettings.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
                        // doc.DefaultPageSettings.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PaperSizes ;
                    }

                    doc.DefaultPageSettings.Landscape = true;
                    PrintDialog dlgSettings = new PrintDialog();
                    dlgSettings.Document = doc;

                    //if (dlgSettings.ShowDialog() == DialogResult.OK)
                    //{
                    doc.Print();
                }
            }
            return true;
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

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

        public string MultipleLine(string doc, int divisionLength, string price)
        {
            StringPrintFormater strPrintFormatter = new StringPrintFormater(37);
            string returnString = "";
            string[] lines = new string[(doc.Length / divisionLength) + 1];


            int i = 0;
            int k = 0;
            for (int j = 0; j < doc.Length; j++)
            {
                if (k == divisionLength)
                {
                    j--;
                    k = 0;
                    i++;
                }
                else
                {
                    lines[i] += doc[j];
                    k++;
                }

            }
            lines[0] = strPrintFormatter.ItemLabeledText(lines[0], price);
            int count = 0;
            foreach (string s in lines)
            {
                if (count == 0)
                    returnString += s + "\r\n";
                else
                    returnString += "   " + s + "\r\n";
                count++;
            }

            return returnString;
        }

        public string MultipleLine(string doc, int divisionLength, string price, int printformateline)
        {
           
            string returnString = "";

            StringPrintFormater strPrintFormatter = new StringPrintFormater(printformateline);

            if (doc.Length > divisionLength)
            {
                int j = 0;

                ArrayList docArray = new ArrayList();

                string tempDoc = "";

                bool isTrue = false;
                bool isFirst = true;
                do
                {
                    tempDoc = doc.Substring(0, divisionLength);

                    //  tempDoc = doc.Substring(0, divisionLength);
                    j = tempDoc.Length;
                    string check = "";
                    do
                    {
                        j--;

                    } while (tempDoc[j] != ' ' && tempDoc[j] != ',' && tempDoc[j] != '-' && tempDoc[j] != '\n' && tempDoc[j] != '[' && tempDoc[j] != ']' && tempDoc[j] != '>' && tempDoc[j] != '>' && tempDoc[j] != '<');

                    //  doc.Substring(0,j); 
                    tempDoc = doc.Substring(0, j);
                    if (isFirst)
                        isFirst = false;
                    else
                        tempDoc = "   " + tempDoc;
                    docArray.Add(tempDoc);

                    tempDoc = doc.Substring(j + 1, doc.Length - j - 1);

                    doc = tempDoc;
                } while (doc.Length > divisionLength);

                if (doc.Length > 0)
                {
                    if (printformateline > 50)
                    {
                        doc = "" + doc;
                    }
                    else
                    {
                        doc = "   " + doc;
                    }
                    docArray.Add(doc);
                }

                foreach (string substring in docArray.ToArray(typeof(string)) as string[])
                {
                    if (!isTrue)
                    {
                        returnString = strPrintFormatter.ItemLabeledText(substring, price) + "\r\n";
                    }
                    else
                    {
                        returnString += substring + "\r\n";
                    }
                    isTrue = true;
                }
            }
            else
            {
                returnString = strPrintFormatter.ItemLabeledText(doc, price) + "\r\n";
            }

            return returnString;
        }

        public string PupulateRightString(int quantity, double unitPrice, double totalAmount)
        {
            string totalString = "";

            totalString = whiteSpace(5 - quantity.ToString().Length) + quantity + whiteSpace(11 - unitPrice.ToString().Length) + unitPrice.ToString("f2")
                          + whiteSpace(10 - totalAmount.ToString().Length) + totalAmount.ToString("F2");


            return totalString;
        }

        private string whiteSpace(int whiteLength)
        {
            string whitestring = "";
            for (int i = 0; i < whiteLength; i++)
            {
                whitestring += " ";
            }

            return whitestring;
        }
    }
}
