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
    public partial class SupplierInformationForm : UserControl
    {
        private int printReportLogoType = 0;
        public SupplierInformationForm()
        {
            InitializeComponent();
            //find out supplier
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSuppliers = new List<Supplier>();
            aSuppliers = aSupplierBll.GetAllSupplier();
            supplierNamecomboBox.DataSource = aSuppliers;
            supplierNamecomboBox.DisplayMember = "Name";
            supplierNamecomboBox.ValueMember = "SupplierId";
        }

        private void showButton_Click(object sender, System.EventArgs e)
        {
            SupplierBLL aSupplierBll=new SupplierBLL();
            List<Supplier>aList=new List<Supplier>();
            if(viewAllsuppliercheckBox.Checked)
            {
                aList = aSupplierBll.GetAllSupplier();
                supplierdataGridView.DataSource = aList;
            }
            else
            {
                Supplier aSupplier=new Supplier();
                aSupplier = aSupplierBll.GetSupplierByid(Convert.ToInt32(supplierNamecomboBox.SelectedValue));
                aList = new List<Supplier> {aSupplier};
                supplierdataGridView.DataSource = aList;

            }
        }

        private void printReportbutton_Click(object sender, EventArgs e)
        {
            SupplierBLL aSupplierBll = new SupplierBLL();
            List<Supplier> aSupplierReports = new List<Supplier>();
            aSupplierReports = (List<Supplier>)supplierdataGridView.DataSource;
            if(aSupplierReports==null)
            {
                MessageBox.Show("No data Available Into GridView");
                return;
            }

            int printlenght = aSupplierReports.Count;
            PrintDocument doc = new TextDocument(aSupplierBll.SupplierPaymentReportPrint(aSupplierReports), printlenght);
          
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
    }
}
