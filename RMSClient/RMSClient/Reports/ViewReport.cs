using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.SystemManagement;// New added // Change by Mithu
using RMSClient.DataAccess;
using RMSUI;
using Managers.SystemManagement;
using RMS.Common.ObjectModel;
using System.Collections;
using RMS.Common;
using System.Linq;
using System.Drawing.Printing;
using Managers.Payment;
using System.Data.SqlClient;
using RMS.DataAccess;

namespace RMS.Reports
{
    public partial class ViewReport : BaseForm
    {
        private List<CSearchOrderInfo> oItemList;
        private StringPrintFormater stringPrintFormater;
        //private FiscalPrinter fiscalPrinter;
        CPrintMethodsEXT tempPrintMethods;

        string dateRangeText = "Daily : " + DateTime.Now.ToString("dd MMMM yyyy");

        private int printReportLogoType = 0;

        private List<CPcInfo> pcInfoList = new List<CPcInfo>();

        private CPaymentManager paymentManager;
        public ViewReport()
        {
            InitializeComponent();
            this.ScreenTitle = "View Report";  // New added // Change by Mithu
            // fiscalPrinter = new FiscalPrinter();
            tempPrintMethods = new CPrintMethodsEXT();
            comboBoxMonthList.SelectedIndex = 0;
            comboBoxYear.Text = DateTime.Now.Year.ToString();

            comboBoxMonthList.Enabled = !checkBoxDateRangeWise.Checked;
            comboBoxYear.Enabled = !checkBoxDateRangeWise.Checked;
            AddValueIntoTimeCombobox(); // New added
            LoadWaiter();

         



            radioButtonCheat.Checked = EnableCheatReport();

            paymentManager = new CPaymentManager();

            txtBoxCheatPercent.Text = GetCheatPercent().ToString();
            Int64 startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = DateTime.Now.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;
            cheatPanel.Visible = false;
            this.showAllData(startDate, endDate);

            LoadTerminalName();

        }


        private void AddValueIntoTimeCombobox() // New added // Change by Mithu
        {
            toMinutecomboBox.Items.Clear();
            toTimeFormatcomboBox.Items.Clear();
            toHourcomboBox.Items.Clear();
            fromHourcomboBox.Items.Clear();
            fromMinutecomboBox.Items.Clear();
            fromTimeFormatcomboBox.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                string sr = String.Empty;
                // if (i < 10) sr += "0";
                sr += i.ToString();
                fromHourcomboBox.Items.Add(sr);
                toHourcomboBox.Items.Add(sr);

            }
            for (int i = 0; i < 60; i++)
            {
                string sr = String.Empty;
                if (i < 10) sr += "0";
                sr += i.ToString();
                toMinutecomboBox.Items.Add(sr);
                fromMinutecomboBox.Items.Add(sr);

            }
            toTimeFormatcomboBox.Items.Add("AM");
            toTimeFormatcomboBox.Items.Add("PM");
            fromTimeFormatcomboBox.Items.Add("AM");
            fromTimeFormatcomboBox.Items.Add("PM");
        } // New added // Change by Mithu
       
       

        #region LoadTerminalName
        private void LoadTerminalName()
        {
            CPcInfoDAO pcInfoDAO = new CPcInfoDAO();

            pcInfoList = pcInfoDAO.GetAllPcInfo();

            foreach (CPcInfo pcInfo in pcInfoList)
            {
                cmbTerminalName.Items.Add(pcInfo.Name);
            }


            if (cmbTerminalName.Items.Count > 0)
            {
                cmbTerminalName.SelectedIndex = 0;
            }

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = dtpEnd.Value.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;

            this.showAllData(startDate, endDate);

            TimeSpan ts = new TimeSpan(endDate - startDate);
            if (ts.Days == 1)
            {
                dateRangeText = "Daily : " + dtpStart.Value.ToString("dd MMMM yyyy");
            }
            else if (!checkBoxDateRangeWise.Checked)
            {
                dateRangeText = "Monthly : " + dtpStart.Value.ToString("MMMM yyyy");
            }
            else
            {
                dateRangeText = dtpStart.Value.ToString("dd MMM yy") + " to " + dtpEnd.Value.ToString("dd MMM yy");
            }



        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = int.Parse(e.RowIndex.ToString());
            if (rowIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Vat_stat")
                {
                    CSearchOrderInfo searchItem = (CSearchOrderInfo)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    paymentManager.UpdateVatStatInPayment(!searchItem.Vat_stat, searchItem.OrderID);

                }

            }
        }


        private List<CSearchOrderInfo> CheckBeetweenTime(List<CSearchOrderInfo> OrderInfos) // New added // Change by Mithu
        {
            int fromHour = 0;
            int fromMin = 0;
            string formFormat = string.Empty;
            int toHour = 0;
            int toMin = 0;
            string toFormat = string.Empty;
            Boolean fromMinCheck = false;
            Boolean toMinCheck = false;
            CSearchOrderInfo aInfo = new CSearchOrderInfo();
            // string ss = cSearchOrderInfos[0].PaymentDateTime.TimeOfDay.ToString();
            //  string sr = cSearchOrderInfos[0].PaymentDateTime.Date.ToString();

            try
            {
                if (fromHourcomboBox.SelectedItem.ToString() != null)
                {
                    fromHour = Convert.ToInt32(fromHourcomboBox.SelectedItem.ToString());
                }
            }
            catch
            {

            }

            try
            {

                if (fromMinutecomboBox.SelectedItem.ToString() != null)
                {
                    fromMin = Convert.ToInt32(fromMinutecomboBox.SelectedItem.ToString());
                }
            }
            catch
            {
                fromMinCheck = true;
            }

            try
            {

                if (fromTimeFormatcomboBox.SelectedItem.ToString() != null)
                {
                    formFormat = fromTimeFormatcomboBox.SelectedItem.ToString();
                }
            }
            catch
            {
            }

            try
            {


                if (toHourcomboBox.SelectedItem.ToString() != null)
                {
                    toHour = Convert.ToInt32(toHourcomboBox.SelectedItem.ToString());
                }
            }
            catch
            {
            }

            try
            {


                if (toMinutecomboBox.SelectedItem.ToString() != null)
                {
                    toMin = Convert.ToInt32(toMinutecomboBox.SelectedItem.ToString());
                }
            }
            catch
            {
                toMinCheck = true;
            }

            try
            {

                if (toTimeFormatcomboBox.SelectedItem.ToString() != null)
                {
                    toFormat = toTimeFormatcomboBox.SelectedItem.ToString();
                }
            }
            catch
            {
            }
            string totime = string.Empty;
            string fromtime = string.Empty;
            fromtime = dtpStart.Value.Month + "/" + dtpStart.Value.Day + "/" + dtpStart.Value.Year + " ";
            totime = dtpEnd.Value.Month + "/" + dtpEnd.Value.Day + "/" + dtpEnd.Value.Year + " ";
            if (toHour == 0 && toMin == 0 && toFormat == "" && fromHour == 0 && fromMin == 0 && formFormat == "")
            {
                fromtime += "00:00:00";
                totime += "23:59:00";

            }
            else if (toHour == 0 || toFormat == "" || fromHour == 0 || formFormat == "" || fromMinCheck || toMinCheck)
            {
                MessageBox.Show("Please Check your Time Format");
                fromtime += "00:00:00";
                totime += "23:59:00";
            }
            else
            {

                if (toHour < 10)
                {
                    totime += "0";
                } totime += toHour + ":";
                if (toMin < 10)
                {
                    totime += "0";
                } totime += toMin + ":";
                totime += "00 ";

                if (fromHour < 10)
                {
                    fromtime += "0";
                } fromtime += fromHour + ":";
                if (fromMin < 10)
                {
                    fromtime += "0";
                } fromtime += fromMin + ":";
                fromtime += "00 ";
                if (toFormat == "AM")
                {
                    totime += "AM";
                }
                else totime += "PM";
                if (formFormat == "AM")
                {
                    fromtime += "AM";
                }
                else fromtime += "PM";

            }
            DateTime fromDate = DateTime.Parse(fromtime);
            DateTime toDate = DateTime.Parse(totime);
            if (fromDate > toDate)
            {
                MessageBox.Show("fromDateTime Must be Less Than Or Equal To toDateTime ");
            }

            List<CSearchOrderInfo> aSearch = new List<CSearchOrderInfo>();


            foreach (CSearchOrderInfo info in OrderInfos)
            {
                if (info.PaymentDateTime >= fromDate && info.PaymentDateTime <= toDate)
                {
                    aSearch.Add(info);
                }
            }



            return aSearch;

        } // New added // Change by Mithu

        private void showAllData(Int64 startDate, Int64 endDate)
        {

            SystemManager sysManager = new SystemManager();
            oItemList = new List<CSearchOrderInfo>();
            oItemList = sysManager.GetOrderInfo2(startDate, endDate);
            oItemList = CheckBeetweenTime(oItemList); // New added // Change by Mithu


            if (radioButtonCheat.Checked)
            {
                if (ManualCheatReport())
                {
                    txtBoxCheatPercent.Visible = false;
                    oItemList = getManulCheatOrderList(oItemList);
                }
                else
                {
                    oItemList = getAutoCheatOrderList(oItemList);
                }

            }



            if (chkTerminalName.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.TerminalID == pcInfoList[cmbTerminalName.SelectedIndex].PcID.ToString()
                             select searchItem;

                oItemList = filter.ToList();
            }


            if (rbtnTable.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.OrderType == "Table" || searchItem.OrderType == "Token"
                             select searchItem;

                oItemList = filter.ToList();

            }

            if (rbtnTakeAway.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.OrderType == "TakeAway"
                             select searchItem;

                oItemList = filter.ToList();
            }


            if (dueTotalradioButton1.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.DuePaid >0
                             select searchItem;

                oItemList = filter.ToList();
            }

            if (txtBoxSerialNumber.Text != string.Empty)
            {

                var filter = from searchItem in oItemList
                             where searchItem.SerialNumber == txtBoxSerialNumber.Text
                             select searchItem;

                oItemList = filter.ToList();
            }

            if(complementoryRadioButton.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.ComplementoryMessage.Length!=0
                             select searchItem;

                oItemList = filter.ToList();
            }

            if (dueRadioButton.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.DueMessage.Length != 0
                             select searchItem;

                oItemList = filter.ToList();
            }

            if (orderComplementoryRadioButton.Checked)
            {
                var filter = from searchItem in oItemList
                             where searchItem.ComplementoryPaid > 0
                             select searchItem;

                oItemList = filter.ToList();
            }





            int totalCovers = (from item in oItemList
                               select item.Covers).Sum();
            lelGuest_Value.Text = totalCovers.ToString();

            decimal totalFood = (from item in oItemList
                                 select item.FoodTotal).Sum();
            lelFoodPrice_Value.Text = totalFood.ToString();

            decimal totalNonFood = (from item in oItemList
                                    select item.NonfoodTotal).Sum();
            lelNonfoodPrice_Value.Text = totalNonFood.ToString();

            decimal totaltableFood = (from item in oItemList
                                      where item.OrderType == "Table"
                                      select item.FoodTotal).Sum();
            lelTableFoodPrice_Value.Text = totaltableFood.ToString();


            decimal totaltableNonFood = (from item in oItemList
                                         where item.OrderType == "Table"
                                         select item.NonfoodTotal).Sum();
            lelTableNonfoodPrice_Value.Text = totaltableNonFood.ToString();


            decimal totalTakeWayFood = (from item in oItemList
                                        where item.OrderType == "TakeAway"
                                        select item.FoodTotal).Sum();
            lelTakeAwayFoodPrice_Value.Text = totalTakeWayFood.ToString();


            decimal totalTakeWayNonFood = (from item in oItemList
                                           where item.OrderType == "TakeAway"
                                           select item.NonfoodTotal).Sum();
            lelTakeAwayNonfoodPrice_Value.Text = totalTakeWayNonFood.ToString();



            /*decimal totalbarWayFood = (from item in oItemList
                                        where item.OrderType == "Bars"
                                        select item.FoodTotal).Sum();
            lelTabsFoodPrice_Value.Text = totalbarWayFood.ToString();


            decimal totalBarWayNonFood = (from item in oItemList
                                           where item.OrderType == "Bars"
                                           select item.NonfoodTotal).Sum();
            lelTabsNonfoodPrice_Value.Text = totalBarWayNonFood.ToString();*/


            decimal totalDisCount = (from item in oItemList
                                     select item.Discount).Sum();
            lelDiscount_Value.Text = totalDisCount.ToString();

            decimal totalSerViceCharge = (from item in oItemList
                                          select item.ServiceChargeCash).Sum();
            lelServiceCharge_Value.Text = totalSerViceCharge.ToString();

            decimal totalOrderTotal = (from item in oItemList
                                       select item.OrderTotal).Sum();
            lelOrderTotal_Value.Text = totalOrderTotal.ToString();

            decimal totalpaidExvat = (from item in oItemList
                                      select item.TotalPaidExcludingVat).Sum();
            lelTotalpaidEXVAT_value.Text = totalpaidExvat.ToString();

            decimal totalpaidIncvat = (from item in oItemList
                                       select item.TotalPaidIncludingVat).Sum();
            lelTotalpaidIncVAT_value.Text = totalpaidIncvat.ToString();

            decimal totalpaidvat = (from item in oItemList
                                    select item.VatPaid).Sum();
            lelVat_Value.Text = totalpaidvat.ToString();


            decimal totalcash = (from item in oItemList
                                 select item.CashPaid).Sum();
            lelCashTotal_value.Text = totalcash.ToString();

            decimal totaleft = (from item in oItemList
                                select item.EFTPaid).Sum();
            lelEftTotal_value.Text = totaleft.ToString();

            double totalCost = (from item in oItemList select item.TotalCost).Sum();
            double profit = (double)totalpaidExvat - totalCost;
            profitlebel.Text = profit.ToString("F02");


            double itemDiscount = (from item in oItemList
                                select item.ItemDiscount).Sum();
            itemDiscountlabel.Text = itemDiscount.ToString();


            if(waiterradioButton.Checked)
            {
                string sr = waitercomboBox.Text;
                oItemList = (from oitemList in oItemList where oitemList.Waiter == sr select oitemList).ToList();
            }
            else if (tableNumberradioButton.Checked)
            {
                try
                {
                    int tablenumber = Convert.ToInt32(tableNumbertextBox.Text);
                    oItemList = (from oitemList in oItemList where oitemList.TableNumber == tablenumber select oitemList).ToList();
                }
                catch (Exception)
                {
                    
                
                }
            }


            decimal dueBill = oItemList.Sum(a => a.DuePaid);
            dueTotalLabel.Text = dueBill.ToString("F02");

            decimal complementoryBill = oItemList.Sum(a => a.ComplementoryPaid);
            complementorylabel.Text = complementoryBill.ToString("F02");


            dataGridView1.DataSource = oItemList;

            dataGridView1.Columns["Vat_stat"].Visible = false;


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                Font printFont = new Font("Lucida Console", 7);
                // e.Graphics.DrawString(printBody, printFont, Brushes.Black, 0, 0);

                int printHeight;

                printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;

                StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

                RectangleF printArea = new RectangleF(0, 0, 1150, printHeight);
                e.Graphics.DrawString(PrintReport(oItemList), printFont, Brushes.Black, printArea, format);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }

        }


        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top+3;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                  //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 400, 0);

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /* printDocument1.DefaultPageSettings.Landscape = true;
           
             if (printDialog1.ShowDialog() == DialogResult.OK)
             {
                 printDocument1.Print();
             }


             */
            int printlenght = oItemList.Count + 30;
            PrintDocument doc = new TextDocument(PrintReport(oItemList), printlenght);
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

        private void btn_go_Click(object sender, EventArgs e)
        {
            Int64 startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = dtpEnd.Value.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;

            this.showAllData(startDate, endDate);
        }


        private List<CSearchOrderInfo> getAutoCheatOrderList(List<CSearchOrderInfo> oItemList)
        {

            List<DayWiseReport> daywizeReportList = getCheatOrderListdayWize(oItemList);
            List<CSearchOrderInfo> cheatOrderList = new List<CSearchOrderInfo>();


            foreach (DayWiseReport daywizeReporItem in daywizeReportList)
            {

                List<CSearchOrderInfo> OrderList = daywizeReporItem.OrderListPerday;

                decimal totalpaidVat = (from item in OrderList
                                        select item.VatPaid).Sum();
                double reducedvat = Double.Parse(totalpaidVat.ToString()) * (Double.Parse(txtBoxCheatPercent.Text.Replace("%", "")) / 100);

                double temp = 0.0;

                foreach (CSearchOrderInfo item in OrderList)
                {
                    if(item.Vat_stat == true)
                    {
                      //  temp += Double.Parse(item.VatPaid.ToString());
                        cheatOrderList.Add(item);
                    }
                    //if (temp < reducedvat)
                    //{
                    //    temp += Double.Parse(item.VatPaid.ToString());
                    //    cheatOrderList.Add(item);
                    //}
                }
            }

            return cheatOrderList;
        }


        private List<CSearchOrderInfo> getManulCheatOrderList(List<CSearchOrderInfo> oItemList)
        {

            List<CSearchOrderInfo> cheatOrderList = new List<CSearchOrderInfo>();

            var filter = from searchItem in oItemList
                         where searchItem.Vat_stat != false
                         select searchItem;

            cheatOrderList = filter.ToList();

            return cheatOrderList;

        }

        //private List<CSearchOrderInfo> getCheatOrderList(List<CSearchOrderInfo> oItemList)
        //{
        //    List<CSearchOrderInfo> cheatOrderList=new List<CSearchOrderInfo>();

        //    decimal totalpaidVat = (from item in oItemList
        //                               select item.VatPaid).Sum();


        //   double reducedvat = Double.Parse(totalpaidVat.ToString()) * (Double.Parse(txtBoxCheatPercent.Text.Replace("%",""))/100);

        //   double temp=0.0;

        //   foreach (CSearchOrderInfo item in oItemList)
        //   {
        //       if (temp < reducedvat)
        //       {
        //           temp += Double.Parse(item.VatPaid.ToString());
        //           cheatOrderList.Add(item);
        //       }
        //   }

        //    return cheatOrderList;
        //}

        private List<DayWiseReport> getCheatOrderListdayWize(List<CSearchOrderInfo> oItemList)
        {


            List<CSearchOrderInfo> orderListPerday; ;
            List<DayWiseReport> dayReportList = new List<DayWiseReport>();


            if (oItemList.Count > 0)
            {
                DateTime lowestDate = (from item in oItemList
                                       select item.OrderDateTime).Min();
                DateTime heighestDate = (from item in oItemList
                                         select item.OrderDateTime).Max();

                while (lowestDate.Date <= heighestDate.Date)
                {

                    orderListPerday = new List<CSearchOrderInfo>();

                    var filter = from searchItem in oItemList
                                 where searchItem.OrderDateTime.Date == lowestDate.Date
                                 select searchItem;

                    orderListPerday = filter.ToList();
                    if (orderListPerday.Count > 0)
                    {
                        DayWiseReport dayReport = new DayWiseReport();
                        dayReport.OrderListPerday = orderListPerday;
                        dayReportList.Add(dayReport);
                    }


                    lowestDate = lowestDate.AddDays(1);

                }

                /* for (DateTime dt = lowestDate; dt <= heighestDate; dt= dt.AddDays(1))
                 {
                     orderListPerday = new List<CSearchOrderInfo>();

                     var filter = from searchItem in oItemList
                                  where searchItem.OrderDateTime.Date == dt.Date
                                  select searchItem;

                     orderListPerday = filter.ToList();

                     DayWiseReport dayReport = new DayWiseReport();
                     dayReport.OrderListPerday = orderListPerday;
                     dayReportList.Add(dayReport);

                 }*/

            }

            return dayReportList;
        }


        private string PrintReport(List<CSearchOrderInfo> oItemList)
        {

            string strBody = "";
            stringPrintFormater = new StringPrintFormater(172);

            string header = GetPrintDecorationText(PrintDecoration.HEADER);

            printReportLogoType = 1;
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
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("SALES REPORT");
        //    strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("RED CHICK'N");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Date: From - " + dtpStart.Value.Date.ToShortDateString() + " to " + dtpEnd.Value.Date.ToShortDateString());
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Guest: " + lelGuest_Value.Text, "Food Price: " + lelFoodPrice_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Take Away Food Price: " + lelTakeAwayFoodPrice_Value.Text, "Non Food Price: " + lelNonfoodPrice_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Take Away Non Food Price: " + lelTakeAwayNonfoodPrice_Value.Text, "Total: " + lelOrderTotal_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Table Food Price: " + lelTableFoodPrice_Value.Text, "Vat Total: " + lelVat_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Table Non Food Price: " + lelTableNonfoodPrice_Value.Text, "Service Charge: " + lelServiceCharge_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Discount: " + lelDiscount_Value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Total Paid (IncVat): " + lelTotalpaidIncVAT_value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Cash: " + lelCashTotal_value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "EFT: " + lelEftTotal_value.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Due: " + dueTotalLabel.Text);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Complementory: " + complementorylabel.Text);
            //change by mithu
            double cost = (from item in oItemList select item.TotalCost).Sum();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Total Cost: " + cost.ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "Total Profit: " + profitlebel.Text);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("O/ID", 9, false);
          //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            strBody += stringPrintFormater.GridCell("Order Date-Time", 25, false);
            strBody += stringPrintFormater.GridCell("O/Type", 10, false);

            strBody += stringPrintFormater.GridCell("Cover", 7, false);
            // strBody += stringPrintFormater.GridCell("Food Total", 12, true);
            // strBody += stringPrintFormater.GridCell("NonF Total", 12, true);
            strBody += stringPrintFormater.GridCell("Order Total", 12, true);
            strBody += stringPrintFormater.GridCell("Discount", 10, true);
            strBody += stringPrintFormater.GridCell("Ser.Charge", 12, true);
            // strBody += stringPrintFormater.GridCell("ExV Total", 12, true);
            strBody += stringPrintFormater.GridCell("IncV Total", 12, true);
            strBody += stringPrintFormater.GridCell("Vat Total", 10, true);
            strBody += stringPrintFormater.GridCell("Cash", 12, true);
            strBody += stringPrintFormater.GridCell("EFT", 12, true);
            strBody += stringPrintFormater.GridCell("EFT Card", 16, false);
            strBody += stringPrintFormater.GridCell("Due", 10, false);
            strBody += stringPrintFormater.GridCell("Cost", 10, false);
            strBody += stringPrintFormater.GridCell("Waiter", 20, false);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (CSearchOrderInfo item in oItemList)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(item.OrderID.ToString(), 9, false);
              //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(item.OrderDateTime.ToString(), 25, false);
                strBody += stringPrintFormater.GridCell(item.OrderType.ToString(), 10, false);
                strBody += stringPrintFormater.GridCell(item.Covers.ToString(), 7, false);
                //  strBody += stringPrintFormater.GridCell(item.FoodTotal.ToString(), 12, true);
                //  strBody += stringPrintFormater.GridCell(item.NonfoodTotal.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.OrderTotal.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.Discount.ToString(), 10, true);
                strBody += stringPrintFormater.GridCell(item.ServiceChargeCash.ToString(), 12, true);
                // strBody += stringPrintFormater.GridCell(item.TotalPaidExcludingVat.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.TotalPaidIncludingVat.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.VatPaid.ToString(), 10, true);
                strBody += stringPrintFormater.GridCell(item.CashPaid.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.EFTPaid.ToString(), 12, true);
                strBody += stringPrintFormater.GridCell(item.EFTCardName.ToString(), 16, false);
                strBody += stringPrintFormater.GridCell(item.DuePaid.ToString(), 10, false);
                strBody += stringPrintFormater.GridCell(item.TotalCost.ToString("F02"), 10, false);
                strBody += stringPrintFormater.GridCell(item.Waiter, 20, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            // strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");


            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                           Checked By" + "                                                                       Prepared By         ";
         

            return strBody;

        }
        private void radioButtonCheat_Click(object sender, EventArgs e)
        {

        }

        private void ViewReport_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void ViewReport_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtBoxSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //lbl.Text = "Key Down: " + e.KeyValue.ToString();

            if (e.KeyValue == 13 && txtBoxSerialNumber.Text.ToLower() == "on")
            {
                dataGridView1.Columns["Vat_stat"].Visible = false;
                cheatPanel.Visible = true;
                txtBoxSerialNumber.Clear();


            }
            if (e.KeyValue == 13 && txtBoxSerialNumber.Text.ToLower() == "uhtimshafiul")
            {
                dataGridView1.Columns["Vat_stat"].Visible = true;
                txtBoxSerialNumber.Clear();

            }


        }


        public bool EnableCheatReport()
        {

            bool enabledCheatReport = false;
            DataSet tempDataSet;
            try
            {
                tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/ReportSetting.xml");
                enabledCheatReport = Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["enabled"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return enabledCheatReport;
        }
        public bool ManualCheatReport()
        {

            bool manualCheatReport = false;
            DataSet tempDataSet;
            try
            {
                tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/ReportSetting.xml");
                manualCheatReport = Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["manual"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return manualCheatReport;
        }

        public double GetCheatPercent()
        {

            double cheatamount = 60;
            DataSet tempDataSet;
            try
            {
                tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/ReportSetting.xml");
                cheatamount = Convert.ToDouble(tempDataSet.Tables[0].Rows[0]["amount"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return cheatamount;
        }

        private void btn_save_cheat_report_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = int.Parse(e.RowIndex.ToString());
            if (rowIndex >= 0)
            {

                CSearchOrderInfo cSearchOrderInfo = (CSearchOrderInfo)dataGridView1.Rows[rowIndex].DataBoundItem;
                string orderID = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                OrderDetails od = new OrderDetails(cSearchOrderInfo,0);
                od.ShowDialog();
            }
        }

        private void btnItemWiseReport_Click(object sender, EventArgs e)
        {

            Int64 fromOID = 0;
            Int64 toOID = 0;

            if (oItemList.Count() == 0)
            {
                MessageBox.Show("No order found in search criteria");
            }
            else
            {
                fromOID = (from searchItem in oItemList
                           select searchItem.OrderID).Min();

                toOID = (from searchItem in oItemList
                         select searchItem.OrderID).Max();

                ItemReportForm itemWiseDateForm = new ItemReportForm(fromOID, toOID, dtpStart.Value, dtpEnd.Value, oItemList.Count(), radioButtonActualReport.Checked, dateRangeText);
                itemWiseDateForm.ShowDialog();
            }

        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {

            /*PrintDocument doc = new TextDocument(getSummaryPrintText());
            doc.PrintPage += this.Doc_PrintPage;

            //doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }*/
            // string 

            //int printlenght = oItemList.Count + 30;
            //PrintDocument doc = new TextDocument(getSummaryPrintText(dateRangeText, 29, true), printlenght);
            //doc.PrintPage += this.Doc_PrintPage;

            //doc.DefaultPageSettings.Landscape = true;
            //PrintDialog dlgSettings = new PrintDialog();
            //dlgSettings.Document = doc;

            //if (dlgSettings.ShowDialog() == DialogResult.OK)
            //{
            //    doc.Print();
            //}

            //tempPrintMethods.USBPrint(getSummaryPrintText(dateRangeText, 29, true), PrintDestiNation.CLIENT, false); // Change by Mithu

            tempPrintMethods.USBPrint(getSummaryPrintTextCashAndCard(dateRangeText, 29, true), PrintDestiNation.CLIENT, false); // Change by Mithu

        }

        private string getSummaryPrintText(string dateString, int lineLength, bool showHeader)
        {
            stringPrintFormater = new StringPrintFormater(lineLength);
            printReportLogoType = 2;
            string strPrint = "";
            if (radioButtonActualReport.Checked)
            {
                strPrint += "\r\n" + stringPrintFormater.CenterTextWithDashed("**********") + "\r\n";
            }
            if (showHeader)
            {
               // strPrint += "\r\n" + tempPrintMethods.GetPrintDecorationText(PrintDecoration.HEADER);

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


                strPrint += TotalHader;
            }

            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Sales Report (Order Wise)");
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(dateString);

            /***************/
            /* var filter = from searchItem in oItemList
                          where searchItem.or == "Table"
                          select searchItem;

             oItemList = filter.ToList();*/

            TimeSpan ts = new TimeSpan(dtpEnd.Value.Ticks - dtpStart.Value.Ticks);
            if (ts.Days > 1)
            {

                strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
                for (int i = 0; i <= ts.Days; i++)
                {
                    var qurryDaywiseOrder = from searchItem in oItemList
                                            where searchItem.OrderDateTime.Ticks > getDayStartTicks(dtpStart.Value.AddDays(i))
                                            &&
                                            searchItem.OrderDateTime.Ticks < getDayEndTicks(dtpStart.Value.AddDays(i))
                                            select searchItem;

                    if (qurryDaywiseOrder.Count() > 0)
                    {
                        List<CSearchOrderInfo> tempList = qurryDaywiseOrder.ToList();
                        decimal totalpaidIncvat = (from item in tempList
                                                   select item.TotalPaidIncludingVat).Sum();


                        strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(dtpStart.Value.AddDays(i).ToString("dd MMM") + " Day Total:", totalpaidIncvat.ToString());




                    }


                }
            }


            /****************/

            strPrint += "\r\n";
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total Order: ", oItemList.Count.ToString());
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total Guest: ", lelGuest_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Food : ", lelFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Non Food : ", lelNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("T/W Food : ", lelTakeAwayFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("T/W Non Food : ", lelTakeAwayNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Table Food : ", lelTableFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Table Non Food : ", lelTableNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Order Total: ", lelOrderTotal_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Service Charge: ", lelServiceCharge_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Discount: ", lelDiscount_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total(ExVat): ", lelTotalpaidEXVAT_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total(IncVat): ", lelTotalpaidIncVAT_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Vat Total: ", lelVat_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Cash: ", lelCashTotal_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("EFT: ", lelEftTotal_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Due: ", dueTotalLabel.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Complementory: ", complementorylabel.Text);
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + "Printed at : ";
            strPrint += "\r\n" + DateTime.Now.ToString("dd MMMM yyyy") + "-" + DateTime.Now.ToString("hh:mm:ss tt");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("End Report");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            return strPrint;
        }

        private string getSummaryPrintTextCashAndCard(string dateString, int lineLength, bool showHeader) // Change by Mithu
        {
            stringPrintFormater = new StringPrintFormater(lineLength);
            printReportLogoType = 2;
            string strPrint = "";
            if (radioButtonActualReport.Checked)
            {
                strPrint += "\r\n" + stringPrintFormater.CenterTextWithDashed("**********") + "\r\n";
            }
            if (showHeader)
            {
                // strPrint += "\r\n" + tempPrintMethods.GetPrintDecorationText(PrintDecoration.HEADER);

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


                strPrint += TotalHader;
            }

            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Sales Report (Order Wise)");
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(dateString);

            /***************/
            /* var filter = from searchItem in oItemList
                          where searchItem.or == "Table"
                          select searchItem;

             oItemList = filter.ToList();*/

            TimeSpan ts = new TimeSpan(dtpEnd.Value.Ticks - dtpStart.Value.Ticks);
            if (ts.Days >= 1)
            {
                strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
                strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Date     Cash", "EFT"); // change by mithu
                strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
                //  serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");
                for (int i = 0; i <= ts.Days; i++)
                {
                    var qurryDaywiseOrder = from searchItem in oItemList
                                            where searchItem.OrderDateTime.Ticks > getDayStartTicks(dtpStart.Value.AddDays(i))
                                            &&
                                            searchItem.OrderDateTime.Ticks < getDayEndTicks(dtpStart.Value.AddDays(i))
                                            select searchItem;

                    if (qurryDaywiseOrder.Count() > 0)
                    {
                        List<CSearchOrderInfo> tempList = qurryDaywiseOrder.ToList();
                        decimal totalpaidIncvat = (from item in tempList
                                                   select item.TotalPaidIncludingVat).Sum();
                        decimal totalcashpaid = (from item in tempList select item.CashPaid).Sum(); //change by mithu
                        decimal totaleftpaid = (from item in tempList select item.EFTPaid).Sum();// change by mithu


                        // strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(dtpStart.Value.AddDays(i).ToString("dd MMM") + " Day Total:", totalpaidIncvat.ToString());

                        strPrint += "\r\n" + stringPrintFormater.ItemLabeledText(dtpStart.Value.AddDays(i).ToString("dd MMM") + "   " + totalcashpaid.ToString(), totaleftpaid.ToString());// change by mithu




                    }


                }
            }


            /****************/

            strPrint += "\r\n";
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total Order: ", oItemList.Count.ToString());
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total Guest: ", lelGuest_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Food : ", lelFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Non Food : ", lelNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("T/W Food : ", lelTakeAwayFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("T/W Non Food : ", lelTakeAwayNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Table Food : ", lelTableFoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Table Non Food : ", lelTableNonfoodPrice_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Order Total: ", lelOrderTotal_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Service Charge: ", lelServiceCharge_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Discount: ", lelDiscount_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total(ExVat): ", lelTotalpaidEXVAT_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Total(IncVat): ", lelTotalpaidIncVAT_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Vat Total: ", lelVat_Value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Cash: ", lelCashTotal_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("EFT: ", lelEftTotal_value.Text);
            strPrint += "\r\n" + stringPrintFormater.ItemLabeledText("Due: ", dueTotalLabel.Text);
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + "Printed at : ";
            strPrint += "\r\n" + DateTime.Now.ToString("dd MMMM yyyy") + "-" + DateTime.Now.ToString("hh:mm:ss tt");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();
            strPrint += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("End Report");
            strPrint += "\r\n" + stringPrintFormater.CreateDashedLine();

            return strPrint;
        } // Change by Mithu

        private long getDayStartTicks(DateTime dt)
        {
            Int64 startDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0).Ticks;
            return startDate;
        }
        private long getDayEndTicks(DateTime dt)
        {
            DateTime dtTemp = dt.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;
            return endDate;
        }


        private void btnFPPrintSummary_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Are you sure to print this Report with the fiscal print?", "Confirmation", MessageBoxButtons.OKCancel);

            //if (dr == DialogResult.OK)
            //{
            //    //  if (fiscalPrinter.foundPrinter())
            //    // { 
            //    //    fiscalPrinter.PerformReportPrint(getSummaryPrintText(dateRangeText, 35, false));
            //    //}
            //}

            tempPrintMethods.USBPrint(getSummaryPrintText(dateRangeText, 29, true), PrintDestiNation.CLIENT, false);// Change by Mithu
        }

        private void checkBoxMothWise_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = checkBoxDateRangeWise.Checked;
            dtpEnd.Enabled = checkBoxDateRangeWise.Checked;


            btnSetToday.Enabled = checkBoxDateRangeWise.Checked;
            comboBoxMonthList.Enabled = !checkBoxDateRangeWise.Checked;
            comboBoxYear.Enabled = !checkBoxDateRangeWise.Checked;
            performSetDate();

        }


        private void comboBoxMonthList_SelectedIndexChanged(object sender, EventArgs e)
        {
            performSetDate();
        }

        private void btnSetToday_Click(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
        }

        private void performSetDate()
        {
            if (!checkBoxDateRangeWise.Checked)
            {
                dtpStart.Value = new DateTime(Convert.ToInt32(comboBoxYear.Text), comboBoxMonthList.SelectedIndex + 1, 1);
                dtpEnd.Value = new DateTime(Convert.ToInt32(comboBoxYear.Text), comboBoxMonthList.SelectedIndex + 1, DateTime.DaysInMonth(DateTime.Now.Year, comboBoxMonthList.SelectedIndex + 1));
            }
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            performSetDate();
        }

        private void btnClearFP_Click(object sender, EventArgs e)
        {
            // if (fiscalPrinter.foundPrinter())
            //  fiscalPrinter.ClearPrinting();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            var dataGridViewColumn = dataGridView1.Columns["DueBill"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
            //essageBox.Show("Hi");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            // if (fiscalPrinter.foundPrinter())
            //  fiscalPrinter.ClearPrinting();

            // change by mithu
            Int64 startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = dtpEnd.Value.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;
            ViewReportAmount v = new ViewReportAmount();
            SystemManager sysManager = new SystemManager();
            v.aCSearchOrderInfos = sysManager.GetOrderInfo2(startDate, endDate);
            v.startDate = dtpStart.Value;
            v.endDate = dtTemp.Date;
            v.endDate = v.endDate.AddSeconds(-1);



            List<DatewiseTotal> aDatewiseTotals = new List<DatewiseTotal>();
            try
            {


                while (v.startDate.Date <= v.endDate.Date)
                {
                    DatewiseTotal aTotal = new DatewiseTotal();

                    aTotal.CashTotal = (double)
                        (from search in v.aCSearchOrderInfos
                         where search.OrderDateTime.Date == v.startDate.Date
                         select search.CashPaid).Sum();

                    aTotal.Covers = (int)
                      (from search in v.aCSearchOrderInfos
                       where search.OrderDateTime.Date == v.startDate.Date
                       select search.Covers).Sum();

                    aTotal.DiscountTotal = (double)
                        (from search in v.aCSearchOrderInfos
                         where search.OrderDateTime.Date == v.startDate.Date
                         select search.Discount).Sum();

                    aTotal.EFTTotal = (double)
                       (from search in v.aCSearchOrderInfos
                        where search.OrderDateTime.Date == v.startDate.Date
                        select search.EFTPaid).Sum();

                    aTotal.DueTotal = (double)
                      (from search in v.aCSearchOrderInfos
                       where search.OrderDateTime.Date == v.startDate.Date
                       select search.DuePaid).Sum();

                    aTotal.FoodTotal = (double)
                     (from search in v.aCSearchOrderInfos
                      where search.OrderDateTime.Date == v.startDate.Date
                      select search.FoodTotal).Sum();

                    aTotal.NoonFoodTotal = (double)
                   (from search in v.aCSearchOrderInfos
                    where search.OrderDateTime.Date == v.startDate.Date
                    select search.NonfoodTotal).Sum();

                    aTotal.OrderTotal = (double)
                 (from search in v.aCSearchOrderInfos
                  where search.OrderDateTime.Date == v.startDate.Date
                  select search.OrderTotal).Sum();

                    aTotal.ServiceChargeTotal = (double)
             (from search in v.aCSearchOrderInfos
              where search.OrderDateTime.Date == v.startDate.Date
              select search.ServiceChargeCash).Sum();

                    aTotal.TotalIncV = (double)
            (from search in v.aCSearchOrderInfos
             where search.OrderDateTime.Date == v.startDate.Date
             select search.TotalPaidIncludingVat).Sum();

                    aTotal.VatTotal = (double)
                (from search in v.aCSearchOrderInfos
                 where search.OrderDateTime.Date == v.startDate.Date
                 select search.VatPaid).Sum();

                    aTotal.Date = v.startDate.Date;

                    aDatewiseTotals.Add(aTotal);
                    v.startDate = v.startDate.AddDays(1);


                }
            }
            catch (Exception)
            {


            }
            v.DatewiseTotals = aDatewiseTotals;
            v.reportdataGridView.DataSource = aDatewiseTotals;

            v.Show();

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewReport_Load(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void waiterradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (waiterradioButton.Checked) waitercomboBox.Enabled = true;
            else waitercomboBox.Enabled = false;
        } 
        // Change by Mithu

        public void LoadWaiter()
        {
            CUserInfoDAO orderwaiterDao = new CUserInfoDAO();
           // COrderwaiter orderwaiter = new COrderwaiter();
            List<CUserInfo> auserInfo = new List<CUserInfo>();
            auserInfo = orderwaiterDao.GetAllUser();
            auserInfo = (from userInfo in auserInfo where userInfo.Type == 7 select userInfo).ToList();
            waitercomboBox.DataSource = auserInfo;
            waitercomboBox.ValueMember = "UserID";
            waitercomboBox.DisplayMember = "UserName";

        }

        private void tableNumberradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tableNumberradioButton.Checked) tableNumbertextBox.Enabled = true;
            else tableNumbertextBox.Enabled = false;
        }

        private void functionalButton2_Click(object sender, EventArgs e)
        {
            Category_Report aCategoryReport=new Category_Report();
            aCategoryReport.ShowDialog();

        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            string filename = DateTime.Now.Ticks + "viewReport";
            ConvertToExcelReport aConvertToExcelReport=new ConvertToExcelReport();
            var dataGridViewColumn = dataGridView1.Columns["GuestBill"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
            string result = aConvertToExcelReport.PrintExcel(dataGridView1, filename);
            MessageBox.Show(result);
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = true;
        }

        private void functionalButton3_Click(object sender, EventArgs e)
        {
            MembershipDiscountReport aMembershipDiscountReport=new MembershipDiscountReport();
            aMembershipDiscountReport.ShowDialog();
        }
    }
}
