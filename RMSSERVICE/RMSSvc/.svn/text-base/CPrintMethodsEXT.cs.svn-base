using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RMS.Common.ObjectModel;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace RMS.Common
{
    public class CPrintMethodsEXT : CPrintMethods
    {
        private PrintDocument printDoc;
        private String printBody;

        public CPrintMethodsEXT()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        public void USBPrint(String printBody, bool displayHeaderFooter)
        {
            this.printBody = printBody;
           
            try
            {
                MessageBox.Show("printing");
                printDoc.Print();

            }
            catch (Exception ex)
            {

            }

        }

        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Lucida Console", 10);
            e.Graphics.DrawString(printBody, printFont, Brushes.Black, 0, 0);
        }

    }
}
