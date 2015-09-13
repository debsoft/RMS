using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Reports;

namespace RMS.SystemManagement
{
    public partial class ReservationReport : Form
    {
        public ReservationReport()
        {
            InitializeComponent();
        }

        private void reportShowbutton_Click(object sender, EventArgs e)
        {
            DataTable productsTable = new DataTable();
            DateTime startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            DateTime enddate = dtpEnd.Value.AddDays(1);
            
            string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetReservationReportByDateToDate),startDate,enddate);
           
            RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
            String tempConnStr = oConstants.DBConnection;


            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            productsTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
           dataAdapter.Fill(productsTable);


            reportdataGridView.DataSource = productsTable;

            dataAdapter.Dispose();
        }

        private void reportdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sr =  ( reportdataGridView.Rows[e.RowIndex].Cells[15].Value).ToString();
                SingleReservationForm aSingleReservationForm=new SingleReservationForm(sr);
                aSingleReservationForm.ShowDialog();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void printDetailsfunctionalButton_Click(object sender, EventArgs e)
        {
            PrintDocument();
        }

        private void PrintDocument()
        {
            int printlenght = reportdataGridView.Rows.Count + 30;
            PrintDocument doc = new TextDocument(PrintReport(), printlenght);
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

        private string PrintReport()
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);

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
            strBody += "\r\n";
            strBody +=  stringPrintFormater.CreateDashedLine();
            strBody += "\r\n"+stringPrintFormater.GridCell("Booking Date", 15, false);
            strBody += stringPrintFormater.GridCell("Creator", 20, false);
            strBody +=  stringPrintFormater.GridCell("Party Date", 15, false);
            strBody += stringPrintFormater.GridCell("Guest", 10, false);
            strBody += stringPrintFormater.GridCell("P. Amount", 15, false);
            strBody += stringPrintFormater.GridCell("D. Amount", 15, false);
            strBody += stringPrintFormater.GridCell("Due Amount", 15, false);
            strBody += stringPrintFormater.GridCell("S. Charge", 15, false);
            strBody += stringPrintFormater.GridCell("Vat", 15, false);
            strBody += stringPrintFormater.GridCell("Discount", 15, false);
            strBody += stringPrintFormater.GridCell("Client Name", 15, false);
            strBody +=  "\r\n"+ stringPrintFormater.CreateDashedLine();
           // strBody += "\r\n";
            int count = 0;
            int length = reportdataGridView.Rows.Count;

            foreach (DataGridViewRow  row in reportdataGridView.Rows)
            {
                count++;
                if (count != length)
                {
                    try
                    {



                        strBody += "\r\n";
                        try
                        {
                            strBody += stringPrintFormater.GridCell(Convert.ToDateTime(row.Cells["BookingDate"].Value).ToShortDateString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["Creator"].Value.ToString(), 20, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {

                            strBody += stringPrintFormater.GridCell(Convert.ToDateTime(row.Cells["partydate"].Value).ToShortDateString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["Total Guest"].Value.ToString(), 10, false);
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["totalpayableamount"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["depositeamount"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["dueamount"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["servicecharge"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["vat"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["discount"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["clientname"].Value.ToString(), 15, false);
                        }
                        catch (Exception)
                        {
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            }





            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");
            strBody += "\r\n\r\n\r\n" + "                     ------------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                     Signature Executive Chef" + "                                                             Signature Managemant  ";

            return strBody;
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
    }
}
