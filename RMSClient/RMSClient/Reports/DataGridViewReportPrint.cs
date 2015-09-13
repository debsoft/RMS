using System;
using System.Collections;
using System.Collections.Generic;
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

namespace RMS.Reports
{
    public class DataGridViewReportPrint
    {
        private PrintDocument printDoc;
        StringFormat strFormat = new StringFormat();
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        private bool landscpae = false;
        private bool summary = false;
        private string stringSummary = "";
        private int line = 0;

        DataGridView reportDataGridView = new DataGridView();



        public DataGridViewReportPrint()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);

        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in reportDataGridView.Columns)
                    {
                        if (IsPrintForCol(GridCol))
                        {
                            iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                                                    (double)iTotalWidth * (double)iTotalWidth *
                                                                    ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                            iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                                                            GridCol.InheritedStyle.Font, iTmpWidth).
                                                      Height) + 11;

                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }
                    }
                }
                while (iRow <= reportDataGridView.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = reportDataGridView.Rows[iRow];
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            string TotalHader = "";
                            TotalHader = GetHeader();

                            int h = 0;
                            int width = e.MarginBounds.Left;
                            if (landscpae)
                            {
                                width += 135;
                            }

                            e.Graphics.DrawString(TotalHader, new Font(reportDataGridView.Font, FontStyle.Bold),
                                    Brushes.Black, width, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(TotalHader, new Font(reportDataGridView.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13 + h - 30);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //  String strDate = fromdateTimePicker.Value.ToShortDateString() + " To " + todateTimePicker.Value.ToShortDateString();
                            //Draw Date
                            float headerHeight = e.Graphics.MeasureString(TotalHader, new Font(reportDataGridView.Font, FontStyle.Bold), e.MarginBounds.Width).Height;
                            e.Graphics.DrawString(strDate, new Font(reportDataGridView.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(reportDataGridView.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - headerHeight);


                            if (summary)
                            {
                                e.Graphics.DrawString(stringSummary, new Font("Arial", 12, FontStyle.Bold),
                                   Brushes.Black, 100, e.MarginBounds.Top - 25);
                                summary = false;
                                iTopMargin = e.MarginBounds.Top + (line*19);
                            }
                            else iTopMargin = e.MarginBounds.Top;



                            //Draw Columns       


                            foreach (DataGridViewColumn GridCol in reportDataGridView.Columns)
                            {
                                if (IsPrintForCol(GridCol))
                                {
                                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                                             new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                                                           (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawRectangle(Pens.Black,
                                                             new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                                                           (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                                          new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                                          new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                                                         (int)arrColumnWidths[iCount], iHeaderHeight),
                                                          strFormat);
                                    iCount++;
                                }
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (IsPrint(Cel))
                            {
                                if (Cel.Value != null)
                                {
                                    e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                                new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                                (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                                }
                                //Drawing Cells Borders 
                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                                iCount++;
                            }
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetHeader()
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);

            string header = GetPrintDecorationText(PrintDecoration.HEADER);

          //  printReportLogoType = 1;
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

            return TotalHader;
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

        private bool IsPrintForCol(DataGridViewColumn gridCol)
        {

            string name = gridCol.Name;
            if (name != null)
            {
                bool check = CheckColumnName(name);
                if (!check) return false;
            }

            if (gridCol.Visible) return true;
            return false;
        }

        private bool CheckColumnName(string name)
        {
            try
            {
                if (name == "TableNumber") return false;
                if (name == "Covers") return false;
                if (name == "OrderTotalAmountWithVat") return false;
                if (name == "OrderDetails") return false;
                if (name == "CardName") return false;
                if (name == "OrderComments") return false;
            }
            catch (Exception)
            {

            }


            return true;
        }

        private bool IsPrint(DataGridViewCell cel)
        {
            string name = cel.OwningColumn.Name;

            if (name != null)
            {
                bool check = CheckColumnName(name);
                if (!check) return false;
            }

            if (cel.Visible) return true;
            return false;
        }


        private void printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                //  iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in reportDataGridView.Columns)
                {
                    if (IsPrintForCol(dgvGridCol))
                        iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void PrintA4Report(DataGridView viewreportdataGridView)
        {
            iRow = 0;
            reportDataGridView = viewreportdataGridView;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            printDialog.UseEXDialog = true;
            summary = false;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDoc.DocumentName = DateTime.Now.Ticks.ToString();
                landscpae = false;
                printDoc.Print();
            }
        }

        public void PrintA4ReportForLandscape(DataGridView viewreportdataGridView, string sum,int lin)
        {
            iRow = 0;
            reportDataGridView = viewreportdataGridView;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            printDialog.UseEXDialog = true;

            if (!string.IsNullOrEmpty(sum))
            {
                summary = true;
                line = lin;
                stringSummary = sum;
            }

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDoc.DocumentName = DateTime.Now.Ticks.ToString();
                printDoc.DefaultPageSettings.Landscape = true;
                landscpae = true;
                printDoc.Print();
            }
        }
    }
}
