using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.Config;
using System.Data.SqlClient;
using Microsoft.ReportingServices.DataExtensions;
using Microsoft.ReportingServices.ReportRendering;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;

namespace RMS
{
    public partial class Form1 : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        
        public Form1()
        {
            InitializeComponent();
            //ConfigManager.Init();
            //ConfigManager.ReloadConfig();
            //CDalConfig oTempConstant = ConfigManager.GetConfig<CDalConfig>();
            //MessageBox.Show(oTempConstant.ConnectionString);
            //Logger.Write("hello world");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rMSDBDataSet.order_details' table. You can move, or remove it, as needed.

            CCommonConstants tempCommonConstants=ConfigManager.GetConfig<CCommonConstants>();
            
            DataSet1 ds = new DataSet1();
            
            SqlDataAdapter tempSql = new SqlDataAdapter("select category3.cat3_name \"Item\", order_details.quantity \"Qty\",category3.table_price \"Price\" from order_details,category3 where order_details.product_id=category3.cat3_id", tempCommonConstants.DBConnection);
            tempSql.Fill(ds.PaymentSlipItems);
            
            paymentSlipItemsBindingSource.DataSource = ds;
            
         //   LocalReport report = new LocalReport();
            
         //   report.ReportPath = @"..\..\Report1.rdlc";
         //   report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Items", ds.PaymentSlipItems));
            Microsoft.Reporting.WinForms.ReportParameter[] paramList=new Microsoft.Reporting.WinForms.ReportParameter[1];
            paramList[0] = new Microsoft.Reporting.WinForms.ReportParameter("CustomerName", "Sakib");
         //   report.SetParameters(paramList);
            this.reportViewer1.LocalReport.SetParameters(paramList);


            Export(this.reportViewer1.LocalReport);
            m_currentPageIndex = 0;
            Print();
            
            this.reportViewer1.RefreshReport();
            
        
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        


        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,string fileNameExtension, Encoding encoding,string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }


        private void Export(LocalReport report)
        {
            try
            {
                string deviceInfo =
                  "<DeviceInfo>" +
                  "  <OutputFormat>EMF</OutputFormat>" +
                  "  <PageWidth>8.5in</PageWidth>" +
                  "  <PageHeight>11in</PageHeight>" +
                  "  <MarginTop>0.25in</MarginTop>" +
                  "  <MarginLeft>0.25in</MarginLeft>" +
                  "  <MarginRight>0.25in</MarginRight>" +
                  "  <MarginBottom>0.25in</MarginBottom>" +
                  "</DeviceInfo>";

                Warning[] warnings;
                m_streams = new List<Stream>();
                report.Render("Image", deviceInfo, CreateStream,out warnings);
                foreach (Stream stream in m_streams)
                    stream.Position = 0;
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.ToString());
            }
        }


        private void Print()
        {
            const string printerName = "Lexmark E120n";
            
            PrintDocument printDoc = new PrintDocument();
          //  printDoc.PrinterSettings.PrinterName = printerName;
            
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", printerName);
                //MessageBox.Show(msg, "Print Error");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

    }
}