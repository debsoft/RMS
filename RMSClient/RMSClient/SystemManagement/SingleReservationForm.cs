using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Reports;

namespace RMS.SystemManagement
{
    public partial class SingleReservationForm : Form
    {
        private string print;
        public SingleReservationForm(string preview)
        {
            InitializeComponent();
            print = preview;
        }

        private void printbutton_Click(object sender, EventArgs e)
        {
            //int printlenght = oItemList.Count + 30;
            PrintDocument doc = new TextDocument(print, 50);
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            dlgSettings.UseEXDialog = true;// use for 64 bit operating system

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                    doc.Print();
            }

        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int printReportLogoType = 1;
                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top + 3;

                if (printReportLogoType == 1)
                {

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 400, 0);

                }
                else if (printReportLogoType == 2)
                {

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 50, 0);

                }
                else if (printReportLogoType == 3)
                {
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\SKYSHEEP.png"), 50, 40);

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

        private void SingleReservationForm_Load(object sender, EventArgs e)
        {
            printpreviewtextBox.Text = print;
        }



    }
}
