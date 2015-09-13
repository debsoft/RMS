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
using RMSClient.DataAccess;

namespace RMS.SystemManagement
{
    public partial class DailyBalanceReport : UserControl
    {
        private double bankbalance = 0;
        BankTransactionDAO aBankTransactionDao = new BankTransactionDAO();
        List<double> amount = new List<double>();
        public DailyBalanceReport()
        {
            InitializeComponent();
            try
            {
               amount = new List<double>();
                amount = aBankTransactionDao.GetNowBankbalance(DateTime.Now);
                if (amount.Count >= 1)
                {
                    balancelabel.Text = amount[0].ToString("F02");
                }
                if (amount.Count >= 2)
                {
                    creditlabel.Text = amount[1].ToString("F02");
                }
                if (amount.Count >= 3)
                {
                    debiotamountlabel.Text = amount[2].ToString("F02");
                }
                if (amount.Count >= 4)
                {
                    otherdebitlabel.Text = amount[3].ToString("F02");
                }
                if (amount.Count >= 5)
                {
                    cashlabel.Text = amount[4].ToString("F02");
                }
            }
            catch (Exception)
            {

            }
       
        }

        private void showbutton_Click(object sender, EventArgs e)
        {
            DateTime fromdate = fromdateTimePicker.Value;
            DateTime todate = todateTimePicker.Value;
            CResult aResult = new CResult();
            aResult = aBankTransactionDao.GetBalanceReport(fromdate,todate);
            DataTable aTable = new DataTable();
            try
            {
                aTable = (DataTable)aResult.Data;

                List<CashReportDami> aCashReportDamis = new List<CashReportDami>();




                foreach (DataRow row in aTable.Rows)
                {
                    try
                    {

                 
                    CashReportDami aDami=new CashReportDami();
                    aDami.TransactionDate = Convert.ToDateTime(row["Transaction_Date"]).ToShortDateString();
                    aDami.CreditAmount = Convert.ToDouble(row["Credit_Amount"]);
                    aDami.DebitAmount = Convert.ToDouble(row["Debit_Amount"]);
                    aDami.OtherDebitAmount = Convert.ToDouble(row["Other_DEBIT"]);
                    aDami.Balance = Convert.ToDouble(row["Balance"]);
                    aDami.CashAmount = Convert.ToDouble(row["Cash_Amount"]);
                    aDami.CashBalance = Convert.ToDouble(row["Cash_Balance"]);
                    aDami.CashIn = aDami.CashAmount + aDami.DebitAmount;
                    aDami.CashOut = aDami.CreditAmount + aDami.OtherDebitAmount;
                    if (aDami.CashBalance < 0)
                    {
                        aDami.CashExtra = aDami.CashBalance * -1;
                        aDami.CashBalance = 0;
                    }
                    else aDami.CashExtra = 0;

                    aCashReportDamis.Add(aDami);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                //aCashReportDamis = (from DataRow row in aTable.Rows
                //       select new CashReportDami
                //       {
                //           TransactionDate = row["FirstName"].ToString(),
                               
                //                CreditAmount = row["FirstName"],
                //                DebitAmount = row["FirstName"],
                //                OtherDebitAmount = row["FirstName"],
                //                  Balance = row["FirstName"],
                //                CashAmount = row["FirstName"],
                //                CashBalance = row["FirstName"],
                //                CashIn =
                //                CashOut=
                //                CashExtra =

                //       }).ToList();




                double cashIn = aCashReportDamis.Sum(a => a.CashIn);
                label4.Text = cashIn.ToString("F02");
                balancedataGridView.DataSource = aCashReportDamis;
               

            }
            catch (Exception)
            {
            }
        }

        private void totalbalanceprintbutton_Click(object sender, EventArgs e)
        {
            if(amount.Count!=0)
            {
              string print= PrintReportPrepared(amount);
              PrintReport(print,5);

            }
            else
            {
                MessageBox.Show("Data Not found");
            }
        }

        private void datetodateprintbutton_Click(object sender, EventArgs e)
        {
            if (balancedataGridView.Rows.Count != 0)
            {
                int printlenght = balancedataGridView.Rows.Count + 5;
                string print = PrintReportPreparedForDateTodate(amount);
                PrintReport(print,printlenght);
            }
            else
            {
                MessageBox.Show("Data Not Found");
            }
        }

        private string PrintReportPreparedForDateTodate(List<double> doubles)
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
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Cash In: "+label4.Text,"");
            strBody += "\r\n";

            strBody += stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Transaction Date", 15+5, false);
            strBody += stringPrintFormater.GridCell("Credit Amount", 15+ 3, false);
            strBody += stringPrintFormater.GridCell("DebitAmount", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Other DEBIT", 10 + 5, false);
            strBody += stringPrintFormater.GridCell("Balance", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Cash Amount", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Cash Balance", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Cash In", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Cash Out", 15 + 3, false);
            strBody += stringPrintFormater.GridCell("Cash Extra", 15 + 3, false);
            //strBody += stringPrintFormater.GridCell("S. Charge", 15, false);
            //strBody += stringPrintFormater.GridCell("Vat", 15, false);
            //strBody += stringPrintFormater.GridCell("Discount", 15, false);
            //strBody += stringPrintFormater.GridCell("Client Name", 15, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            // strBody += "\r\n";
            int count = 0;
            int length = balancedataGridView.Rows.Count;
            //Transaction_Date, Credit_Amount,Debit_Amount,Other_DEBIT,Balance,Cash_Amount,Cash_Balance
            foreach (DataGridViewRow row in balancedataGridView.Rows)
            {
                count++;
              
                    try
                    {



                        strBody += "\r\n";
                        try
                        {
                            strBody += stringPrintFormater.GridCell(Convert.ToDateTime(row.Cells["TransactionDate"].Value).ToShortDateString(), 15 + 5, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CreditAmount"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {

                            strBody += stringPrintFormater.GridCell((row.Cells["DebitAmount"].Value).ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                       // Balance,Cash_Amount,Cash_Balance
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["OtherDebitAmount"].Value.ToString(), 10 + 5, false);
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["Balance"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CashAmount"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CashBalance"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CashIn"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CashOut"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            strBody += stringPrintFormater.GridCell(row.Cells["CashExtra"].Value.ToString(), 15 + 3, false);
                        }
                        catch (Exception)
                        {
                        }
                        //try
                        //{
                        //    strBody += stringPrintFormater.GridCell(row.Cells["servicecharge"].Value.ToString(), 15, false);
                        //}
                        //catch (Exception)
                        //{
                        //}
                        //try
                        //{
                        //    strBody += stringPrintFormater.GridCell(row.Cells["vat"].Value.ToString(), 15, false);
                        //}
                        //catch (Exception)
                        //{

                        //}
                        //try
                        //{
                        //    strBody += stringPrintFormater.GridCell(row.Cells["discount"].Value.ToString(), 15, false);
                        //}
                        //catch (Exception)
                        //{
                        //}
                        //try
                        //{
                        //    strBody += stringPrintFormater.GridCell(row.Cells["clientname"].Value.ToString(), 15, false);
                        //}
                        //catch (Exception)
                        //{
                        //}

                    }
                    catch (Exception)
                    {

                    }
                
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            }



            
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");


            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                           Checked By" + "                                                                       Prepared By         ";
            return strBody;
        }


        private void PrintReport(string printstring ,int length)
        {
            //int printlenght = oItemList.Count + 30;
            PrintDocument doc = new TextDocument(printstring, length);
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
            int printReportLogoType = 1;

            try
            {

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top + 3;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 493, 35);

                    //for Aroma Restaurant 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 50, 0);

                    //for Aroma Restaurant 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\SKYSHEEP.png"), 50, 40);

                    //for Aroma Restaurant 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 50, 0);
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

        //private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    int printReportLogoType = 1;

        //    try
        //    {

        //        TextDocument doc = (TextDocument)sender;

        //        Font font = new Font("Lucida Console", 7);

        //        float lineHeight = font.GetHeight(e.Graphics);

        //        float x = e.MarginBounds.Left;
        //        float y = e.MarginBounds.Top + 3;

        //        if (printReportLogoType == 1)
        //        {
        //            //For Birds Eye Restaurant
        //            //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

        //            //for Labamba Restaurant 
        //            e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 493, 35);

        //            //for Aroma Restaurant 
        //            //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
        //        }
        //        else if (printReportLogoType == 2)
        //        {
        //            //For Bird Eye Restaurant Logo 
        //            //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

        //            //for Labamba Restaurant 
        //            e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 50, 0);

        //            //for Aroma Restaurant 
        //            //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
        //        }
        //        else if (printReportLogoType == 3)
        //        {
        //            //For Bird Eye Restaurant Logo 
        //            //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

        //            //for Labamba Restaurant 
        //            e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\SKYSHEEP.png"), 50, 40);

        //            //for Aroma Restaurant 
        //            //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 50, 0);
        //        }


        //        doc.PageNumber += 1;

        //        while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
        //        {
        //            e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
        //            doc.Offset += 1;
        //            y += lineHeight;
        //        }

        //        if (doc.Offset < doc.Text.GetUpperBound(0))
        //        {
        //            e.HasMorePages = true;
        //        }
        //        else
        //        {
        //            doc.Offset = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Sorry! Problem occured." + ex.ToString());
        //    }

        //}

        private string PrintReportPrepared(List<double> aGuest)
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

            //   strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Balance Statement");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Report Date: " + DateTime.Now.ToShortDateString());
            //    strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("RED CHICK'N");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Credit Amount(Tk.): " + amount[1].ToString("F02"));
          
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Debit Amount(Tk.): " + amount[2].ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Balance  in Bank Amount(Tk.): " + amount[0].ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total other Debit Amount(Tk.): " + amount[3].ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Total Cash in hand Amount(Tk.): " + amount[4].ToString("F02"));
          
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
     
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");


            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                           Checked By" + "                                                                       Prepared By         ";


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


    }
}
