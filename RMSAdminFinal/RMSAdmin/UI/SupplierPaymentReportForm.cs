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
    public partial class SupplierPaymentReportForm : UserControl
    {
        private int printReportLogoType = 0;
        public SupplierPaymentReportForm()
        {
            InitializeComponent();
            //find out supplier
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSuppliers = new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "Name";
            supplierNamecomboBox.ValueMember = "SupplierId";

            BookedPaymentTypeCombobox();

        }

        private void BookedPaymentTypeCombobox()
        {
            paymentTypecomboBox.DataSource = new List<string>
                                                 {
                                                     "Cash",
                                                     "Cheque",
                                                     "Card",
                                                     "WithoutPayment"
                                                 };

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // add for Get date
            DateTime fromdate = fromdateTimePicker.Value;
            DateTime todate = todateTimePicker.Value;
            todate = todate.AddDays(1);
            fromdate = fromdate.Date;
            todate = todate.Date;
            todate = todate.AddSeconds(-1);
            List<SupplierPaymentReport> aSupplierPaymentReports=new List<SupplierPaymentReport>();
            SupplierPaymentReportBLL aPaymentReportBll=new SupplierPaymentReportBLL();
            aSupplierPaymentReports = aPaymentReportBll.GetSupplierPaymentReportBetweenDate(fromdate,todate);
            // supplierdatapaymentGridView.DataSource = aSupplierPaymentReports;
             ShowReport(aSupplierPaymentReports);

        }

        private void ShowReport(List<SupplierPaymentReport> aSupplierPaymentReports)
        {
            List<SupplierPaymentReport>aPaymentReports=new List<SupplierPaymentReport>();
             string paymentType = paymentTypecomboBox.SelectedItem.ToString();
            Supplier aSupplier = (Supplier) supplierNamecomboBox.SelectedItem;
            string supplier = aSupplier.Name;

            if(viewAllsuppliercheckBox.Checked && paymentcheckBox.Checked)
            {
               
                aPaymentReports = (from report in aSupplierPaymentReports 
                                   where report.PaymentType == paymentType select report).ToList();
            }
            else if(paymentcheckBox.Checked)
            {
                aPaymentReports = (from report in aSupplierPaymentReports
                                   where report.PaymentType == paymentType && report.SupplierName==supplier
                                   select report).ToList();
            }
            else if(viewAllsuppliercheckBox.Checked)
            {
                aPaymentReports = aSupplierPaymentReports;
            }
            else
            {
                aPaymentReports = (from report in aSupplierPaymentReports
                                   where  report.SupplierName == supplier
                                   select report).ToList();
            }
            supplierdatapaymentGridView.DataSource = aPaymentReports;
        }

        private void printRawmaterialsReportbutton_Click(object sender, EventArgs e)
        {
            SupplierPaymentReportBLL aPaymentReportBll = new SupplierPaymentReportBLL();
            List<SupplierPaymentReport> aPaymentReports = new List<SupplierPaymentReport>();
            aPaymentReports = (List<SupplierPaymentReport>)supplierdatapaymentGridView.DataSource;
            if (aPaymentReports == null)
            {
                MessageBox.Show("No data Available Into GridView");
                return;
            }
            int printlenght = aPaymentReports.Count;
            PrintDocument doc = new TextDocument(aPaymentReportBll.SupplierPaymentReportPrint(aPaymentReports), printlenght);
            //ViewReport aReport = new ViewReport();
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

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 8);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top - 15;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                 

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 420, 0);

                    //for Aroma Restaurant 
                
                }
                else if (printReportLogoType == 2)
                {
                   

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), -12, 0);

                 
                }
                else if (printReportLogoType == 3)
                {
             

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 20, 40);

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
