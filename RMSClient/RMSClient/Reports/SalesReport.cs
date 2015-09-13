using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using Managers.SystemManagement;
using RMS.Common.ObjectModel;
using System.Collections;
using RMS.Common;
using System.Linq;
using System.Drawing.Printing;
using Managers.Payment;
using ns;
using RmsRemote;
using System.IO;
using System.Diagnostics;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS.Common.DataAccess;
using RMSClient.DataAccess;
using RMS.Utility;

namespace RMS.Reports
{
 
    public partial class SalesReport : BaseForm
    {
       
        List<CShiftSchedule> listCShiftSchedule = new List<CShiftSchedule>();
        List<CShiftOrderInfo> listCShiftOrderInfo = new List<CShiftOrderInfo>();

        private List<CSearchOrderInfo> oItemList;
        private StringPrintFormater stringPrintFormater;
        // private FiscalPrinter fiscalPrinter;
        CPrintMethodsEXT tempPrintMethods;

        string dateRangeText = "Daily : " + DateTime.Now.ToString("dd MMMM yyyy");

        private int printReportLogoType = 0;

        private CPaymentManager paymentManager;
        public SalesReport()
        {
            InitializeComponent();
            //IShiftScheduleDao iShiftScheduleDao = new CShiftScheduleDao();
            //listCShiftSchedule = iShiftScheduleDao.GetAllShiftSchedule();
            //// CShiftSchedule obj=new CShiftSchedule().;
            //comboBoxshift.DataSource = listCShiftSchedule;

            //comboBoxshift.DisplayMember = "ShiftId";
            //comboBoxshift.ValueMember = "ShiftId";

            IShiftOrderInfoDao iShiftOrderInfoDao = new CShiftOrderInfoDao();
            listCShiftOrderInfo = iShiftOrderInfoDao.GetAllShiftOrderInfo();
            this.ScreenTitle = "Inventory Report";

           // FormatDataTime();

        }
        DataTable tableReport;

        //private class ShiftWiseData
        //{
        //    private int _orderID;
        //    private int _product_id;
        //    private string _product_Name;
        //    private string _amount;
        //    private string _quantity;
        //    private string _totalAmount;
        //    private int _guest_count;
        //    private int _cat_level;
        //    private string _food_type;

        //    public int OrderId
        //    {
        //        get { return _orderID; }
        //        set { _orderID = value; }
        //    }

        //    public int ProductId
        //    {
        //        get { return _product_id; }
        //        set { _product_id = value; }
        //    }

        //    public string ProductName
        //    {
        //        get { return _product_Name; }
        //        set { _product_Name = value; }
        //    }

        //    public string Amount
        //    {
        //        get { return _amount; }
        //        set { _amount = value; }
        //    }

        //    public string Quantity
        //    {
        //        get { return _quantity; }
        //        set { _quantity = value; }
        //    }

        //    public string TotalAmount
        //    {
        //        get { return _totalAmount; }
        //        set { _totalAmount = value; }
        //    }

        //    public int GuestCount
        //    {
        //        get { return _guest_count; }
        //        set { _guest_count = value; }
        //    }

        //    public int CatLevel
        //    {
        //        get { return _cat_level; }
        //        set { _cat_level = value; }
        //    }

        //    public string FoodType
        //    {
        //        get { return _food_type; }
        //        set { _food_type = value; }
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //if (checkBoxDateRangeWise.Checked)
            //{

            //    DataSet dsSalesRecords = new DataSet();
            //    CResult objResult = new CResult();
            //    SystemManager objSystemMgnr = new SystemManager();
            //    m_htFoods = new Hashtable();
            //    m_htNonFoods = new Hashtable();

            //    DateTime dtStart = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            //    DateTime dtEnd = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 23, 59, 59);
            //    objResult = objSystemMgnr.GetSalesRecordsForINV(dtStart.Ticks, dtEnd.Ticks);

            //    dataGridView1.DataSource = null;

            //    DataTable dt = (DataTable)objResult.Data;


            //  //  List<ShiftWiseData> listCSearchOrderInfoForShift = new List<ShiftWiseData>();

            //    var queryforShift = from cShiftOrderInfo in listCShiftOrderInfo
            //                        where cShiftOrderInfo.ShiftID == Convert.ToInt64(listCShiftSchedule[comboBoxshift.SelectedIndex].ShiftId)
            //                        select cShiftOrderInfo;
                
            //    DataTable FilterTable = new DataTable();
            //    FilterTable = dt.Clone();
            //    foreach (var query in queryforShift.Select(item => (from summaryByOrder in dt.AsEnumerable()

            //                                                        where summaryByOrder.Field<Int64>("order_id") == item.OrderID
            //                                                        select summaryByOrder)))
            //    {
                   
            //        FilterTable = query.CopyToDataTable();
            //    }

            //    if (checkBoxISShift.Checked == true)
            //    {
            //        dt.Clear();
            //        dt = FilterTable;

            //    }

            //    tableReport = new DataTable();
            //    tableReport.Columns.Add("product_id", typeof(int));
            //    tableReport.Columns.Add("product_Name", typeof(string));
            //    tableReport.Columns.Add("amount", typeof(string));
            //    tableReport.Columns.Add("quantity", typeof(string));
            //    tableReport.Columns.Add("TotalAmount", typeof(string));//
            //    tableReport.Columns.Add("guest_count", typeof(int));
            //    tableReport.Columns.Add("cat_level", typeof(int));
            //    tableReport.Columns.Add("food_type", typeof(string));


            //    if (dt != null || dt.Rows.Count > 0)
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {


            //            tableReport.Rows.Add(Convert.ToInt16(dt.Rows[i]["product_id"]), Convert.ToString(dt.Rows[i]["product_Name"]), Convert.ToDecimal(dt.Rows[i]["amount"].ToString()).ToString("F2"), dt.Rows[i]["quantity"].ToString(), Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()).ToString("F2"), Convert.ToInt16(dt.Rows[i]["guest_count"]), Convert.ToInt16(dt.Rows[i]["cat_level"]), dt.Rows[i]["food_type"].ToString());

            //        }


            //    dataGridView1.AutoGenerateColumns = false;
            //    dataGridView1.DataSource = tableReport;

            //    decimal GrandTotal = 0, TotalQty = 0;
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        GrandTotal = GrandTotal + Convert.ToDecimal(row["TotalAmount"]);
            //        TotalQty = TotalQty + Convert.ToDecimal(row["quantity"]);
            //    }
            //    lblTotalQty.Text = TotalQty.ToString();
            //    lblTotalAmount.Text = GrandTotal.ToString("F2");
            //    lblNoOfItemsSold.Text = (dt.Rows.Count).ToString();
            //    lblFromDate.Text = dtpStart.Text;
            //    lblToDate.Text = dtpEnd.Text;
          //  }
          //  else
        //    {
              
                DataSet dsSalesRecords = new DataSet();
                CResult objResult = new CResult();
                SystemManager objSystemMgnr = new SystemManager();

               // DateTime dtNow = DateTime.Now;
                DateTime fromDate = new DateTime();
                DateTime toDate = new DateTime();
                //if (chkFromTime.Checked)
                //{
                    fromDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 7, 0, 0);
                    toDate = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 6, 59, 59);
                //}
                //else
                //{
                //    fromDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
                //    toDate = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 23, 59, 59);
                //}

                toDate = toDate.AddDays(1);
        
                objResult = objSystemMgnr.GetSalesRecordsForINV(fromDate.Ticks, toDate.Ticks);

                dataGridView1.DataSource = null;

                DataTable dt = (DataTable)objResult.Data;

                tableReport = new DataTable();
                tableReport.Columns.Add("product_id", typeof(int));
                tableReport.Columns.Add("product_Name", typeof(string));
                tableReport.Columns.Add("amount", typeof(string));
                tableReport.Columns.Add("quantity", typeof(string));
                tableReport.Columns.Add("TotalAmount", typeof(string));
                tableReport.Columns.Add("guest_count", typeof(int));
                tableReport.Columns.Add("cat_level", typeof(int));
                tableReport.Columns.Add("food_type", typeof(string));
                tableReport.Columns.Add("UoM", typeof(string));
                tableReport.Columns.Add("productType", typeof(string));

                if (dt != null || dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string ItemName = "";
                        //if (dt.Rows[i]["ItemName"].ToString() == "" && dt.Rows[i]["SelectionItemName"].ToString() == "")
                        //{
                        //    ItemName = dt.Rows[i]["Miscellaneous"].ToString();

                        //}
                        //else
                        //{

                        //    ItemName = dt.Rows[i]["ItemName"].ToString();
                        //    if (ItemName == "")
                        //        ItemName = dt.Rows[i]["SelectionItemName"].ToString();

                        //}

                        tableReport.Rows.Add(Convert.ToInt16(dt.Rows[i]["product_id"]), Convert.ToString(dt.Rows[i]["product_Name"]), dt.Rows[i]["amount"].ToString(), dt.Rows[i]["quantity"].ToString(), dt.Rows[i]["TotalAmount"].ToString(), Convert.ToInt16(dt.Rows[i]["guest_count"]), Convert.ToInt16(dt.Rows[i]["cat_level"]), dt.Rows[i]["food_type"].ToString());
                    }


                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = tableReport;

                decimal GrandTotal = 0, TotalQty = 0;
                foreach (DataRow row in dt.Rows)
                {
                    GrandTotal = GrandTotal + Convert.ToDecimal(row["TotalAmount"]);
                    TotalQty = TotalQty + Convert.ToDecimal(row["quantity"]);
                }
                lblTotalQty.Text = TotalQty.ToString();
                lblTotalAmount.Text = GrandTotal.ToString();
                lblNoOfItemsSold.Text = (dt.Rows.Count).ToString();
                lblFromDate.Text = dtpStart.Text;
                lblToDate.Text = dtpEnd.Text;
         //   }



        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();

        }






        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{

            //    Font printFont = new Font("Lucida Console", 7);
            //    // e.Graphics.DrawString(printBody, printFont, Brushes.Black, 0, 0);

            //    int printHeight;

            //    printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;

            //    StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

            //    RectangleF printArea = new RectangleF(0, 0, 1150, printHeight);
            //    e.Graphics.DrawString(PrintReport(oItemList), printFont, Brushes.Black, printArea, format);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            //}

        }


        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top -20;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 430, 15);

                    //for Aroma Restaurant 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                    //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.png"), 50, 0);

                    //for Aroma Restaurant 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                    //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.png"), 50, 40);

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
        string A4Text;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            StringPrintFormater strPrintFormatter = new StringPrintFormater(40);

            DataSet dsSalesRecords = new DataSet();
            CResult objResult = new CResult();
            SystemManager objSystemMgnr = new SystemManager();
            m_htFoods = new Hashtable();
            m_htNonFoods = new Hashtable();
            
            DateTime dtStart = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 23, 59, 59);

            //if (chkFromTime.Checked)
            //{
                dtStart = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 7, 0, 0);
                dtEnd = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 6, 59, 59);
           // }

            dtEnd = dtEnd.AddDays(1);

            objResult = objSystemMgnr.GetSalesRecords(dtStart.Ticks, dtEnd.Ticks);
            dsSalesRecords = (DataSet)objResult.Data;

            if (dsSalesRecords.Tables.Count > 0 && dsSalesRecords.Tables[0].Rows.Count > 0)
            {
                Int32 guestCounter = Convert.ToInt32(dsSalesRecords.Tables[0].Rows[0]["guest_count"]);

                CPrintMethods tempPrintMethods = new CPrintMethods();

                string serialHeader = RMSClientController.CollectHeader();

                string serialFooter = RMSClientController.CollectFooter();

                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Inventory Sales Report");
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Date of Consumption of Items");
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("From " + dtpStart.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEnd.Value.Date.ToString("dd/MM/yyyy"));
                serialBody.Add(tempSerialPrintContent);

                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "No. of Covers:" + guestCounter.ToString() + "\n";
                //serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine(); 
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Qty Item                         Price(£)";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                SortedList slorderedFoodItems = new SortedList();
                SortedList slorderedNonFoodItems = new SortedList();

                PrintUtility printUtility = new PrintUtility();
                CCategory3DAO category3DAO = new CCategory3DAO();

                foreach (DataRow dtRrow in dsSalesRecords.Tables[0].Rows)
                {
                    clsOrderReport objOrderedItems = new clsOrderReport();
                    string[] returnedValue = GetProductName(dtRrow).Split(':');

                   // string productName = Convert.ToString(returnedValue[0]);
                    string cat1ID = Convert.ToString(returnedValue[1]);

                    objOrderedItems.Quantity = Convert.ToInt32("0" + dtRrow["quantity"].ToString());
                    //  objOrderedItems.ItemName = productName;
                    string productName = "";
                    CCategory3 cat3 = category3DAO.GetAllCategory3ByCategory3ID(Convert.ToInt32(dtRrow["product_id"].ToString()));
                    if (cat3 != null && cat3.Category3Name.Length>0)
                    {
                        productName = cat3.Category3Name.Trim();
                    }
                    else
                    {
                        productName = Convert.ToString(dtRrow["product_Name"].ToString());  // @hafiz
                    }

                    objOrderedItems.ItemName = productName; //Convert.ToString(dtRrow["product_Name"].ToString());  //@Hafiz

                    objOrderedItems.Price = Convert.ToDouble(dtRrow["amount"]);
                    objOrderedItems.FoodTypeName = Convert.ToString(returnedValue[2]);

                    Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32("0" + cat1ID));
                    objOrderedItems.OrderNumber = category1OrderNumber;
                    string keyCode = category1OrderNumber + "-" + objOrderedItems.Quantity.ToString() + "-" + objOrderedItems.ItemName;

                    string tempKey = 99999 + "-" + objOrderedItems.Quantity.ToString() + "-" + objOrderedItems.ItemName; ;
                    if (Convert.ToString(dtRrow["food_type"]).Equals("Food") && Convert.ToInt16(dtRrow["product_id"]) != 0) //Separate food/nonfoods
                    {
                        if (!m_htFoods.ContainsKey(keyCode))
                        {
                            m_htFoods.Add(keyCode, objOrderedItems);
                        }
                        else
                        {
                            clsOrderReport orderReport = m_htFoods[keyCode] as clsOrderReport;
                            objOrderedItems.Quantity = objOrderedItems.Quantity + orderReport.Quantity;
                            m_htFoods[keyCode] = objOrderedItems;
                        }
                    }
                    else if (Convert.ToString(dtRrow["product_id"]).Equals("0")) //Separate food/nonfoods
                    {
                      //  m_htFoods.Add(tempKey, objOrderedItems);

                        if (!m_htFoods.ContainsKey(tempKey))
                        {
                            m_htFoods.Add(tempKey, objOrderedItems);
                        }
                        else
                        {
                            clsOrderReport orderReport = m_htFoods[tempKey] as clsOrderReport;
                            objOrderedItems.Quantity = objOrderedItems.Quantity + orderReport.Quantity;
                            m_htFoods[tempKey] = objOrderedItems;
                        }
                    }
                    else
                    {
                        //m_htNonFoods.Add(keyCode, objOrderedItems);

                        if (!m_htNonFoods.ContainsKey(keyCode))
                        {
                            m_htNonFoods.Add(keyCode, objOrderedItems);
                        }
                        else
                        {
                            clsOrderReport orderReport = m_htNonFoods[keyCode] as clsOrderReport;
                            objOrderedItems.Quantity = objOrderedItems.Quantity + orderReport.Quantity;
                            m_htNonFoods[keyCode] = objOrderedItems;
                        }
                    }
                }
                int separatorNumber = -1;
                NumericComparer nc = new NumericComparer();
                slorderedFoodItems = new SortedList(m_htFoods, nc); //Creating the sorted list from the hash table.
                slorderedNonFoodItems = new SortedList(m_htNonFoods, nc);


                SortedList slMaster1 = new SortedList();
                ArrayList arrListItems = null;

                foreach (DictionaryEntry objOrderedItems in slorderedFoodItems)
                {
                    clsOrderReport objItem = (clsOrderReport)objOrderedItems.Value;
                    string keyValue = objOrderedItems.Key.ToString();
                    string[] splitter = new string[0];
                    splitter = keyValue.Split('-');

                    if (separatorNumber != Convert.ToInt32(splitter[0]))
                    {
                        separatorNumber = Convert.ToInt32(splitter[0]);
                        arrListItems = new ArrayList();
                        arrListItems.Add(objItem);
                        slMaster1.Add(separatorNumber, arrListItems);
                    }
                    else
                    {
                        arrListItems.Add(objItem);
                        separatorNumber = Convert.ToInt32(splitter[0]);
                    }
                }

                ArrayList alReverseOrderedItem;
                foreach (DictionaryEntry deReverseOrderedItem in slMaster1)
                {
                    alReverseOrderedItem = (ArrayList)deReverseOrderedItem.Value;
                    alReverseOrderedItem.Reverse();//Reversing the current item order.

                    foreach (clsOrderReport objOrderedItems in alReverseOrderedItem)
                    {
                        if (separatorNumber != objOrderedItems.OrderNumber)
                        {
                            //tempSerialPrintContent = new CSerialPrintContent();
                            //tempSerialPrintContent.StringLine = "----------------------------------------";
                            //serialBody.Add(tempSerialPrintContent);


                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = objOrderedItems.FoodTypeName + ":";
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                            tempSerialPrintContent.ISAlredyNewLine = true;
                          //  tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                           // tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);
                              tempSerialPrintContent.StringLine += printUtility.MultipleLine(objOrderedItems.ItemName, 30,
                                                                          objOrderedItems.Price.ToString("F02"), 37);
                            serialBody.Add(tempSerialPrintContent);

                            separatorNumber = objOrderedItems.OrderNumber;
                        }
                        else
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                          //  tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                           // tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);
                            tempSerialPrintContent.StringLine += printUtility.MultipleLine(objOrderedItems.ItemName, 30,
                                                                          objOrderedItems.Price.ToString("F02"), 37);
                            tempSerialPrintContent.ISAlredyNewLine = true;
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                #region "Non food items"
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "-----------------Drinks-----------------";
                serialBody.Add(tempSerialPrintContent);


                SortedList slMaster2 = new SortedList();
                ArrayList arrListItemsNonFood = new ArrayList();

                separatorNumber = -1;

                foreach (DictionaryEntry objOrderedNonFood in slorderedNonFoodItems)
                {
                    clsOrderReport objItem = (clsOrderReport)objOrderedNonFood.Value;
                    string keyValue = objOrderedNonFood.Key.ToString();
                    string[] splitter = new string[0];
                    splitter = keyValue.Split('-');

                    if (separatorNumber != Convert.ToInt32(splitter[0]))
                    {
                        separatorNumber = Convert.ToInt32(splitter[0]);
                        arrListItemsNonFood = new ArrayList();
                        arrListItemsNonFood.Add(objItem);
                        slMaster2.Add(separatorNumber, arrListItemsNonFood);
                    }
                    else
                    {
                        arrListItemsNonFood.Add(objItem);
                        separatorNumber = Convert.ToInt32(splitter[0]);
                    }
                }

                separatorNumber = -1;
                foreach (DictionaryEntry objNonFood in slMaster2)
                {
                    ArrayList alNonFoods = (ArrayList)objNonFood.Value;
                    alNonFoods.Reverse();
                    foreach (clsOrderReport objNonFoodItem in alNonFoods)
                    {
                        if (separatorNumber != objNonFoodItem.OrderNumber)
                        {
                            //tempSerialPrintContent = new CSerialPrintContent();
                            //// tempSerialPrintContent.StringLine = "----------------------------------------";
                            //serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                        //    tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                         //   tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);
                            tempSerialPrintContent.StringLine += printUtility.MultipleLine(objNonFoodItem.ItemName, 30,
                                                                          objNonFoodItem.Price.ToString("F02"), 37);
                            serialBody.Add(tempSerialPrintContent);
                            tempSerialPrintContent.ISAlredyNewLine = true;
                            separatorNumber = objNonFoodItem.OrderNumber;
                        }
                        else
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                          //  tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                         //   tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);
                            tempSerialPrintContent.StringLine += printUtility.MultipleLine(objNonFoodItem.ItemName, 30,
                                                                        objNonFoodItem.Price.ToString("F02"), 37);
                            tempSerialPrintContent.ISAlredyNewLine = true;
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                #endregion

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();// "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Total No Of Item: " + lblNoOfItemsSold.Text;
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Total Qty: " + lblTotalQty.Text;
                serialBody.Add(tempSerialPrintContent);

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "Total Item Amount: " + lblTotalAmount.Text;
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Developed By: www.ibacs.co.uk") + "\r\n\n";
                serialBody.Add(tempSerialPrintContent);
                #region "Testing printing area"
                string printingObject = "";
                for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                {
                    if (serialBody[arrayIndex].ISAlredyNewLine)
                    {
                        printingObject += serialBody[arrayIndex].StringLine.ToString() ;
                    }
                    else
                    {
                        printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                    }
                }

                this.WriteString(printingObject);///Write to a file when print command is executed

                #endregion
                A4Text = printingObject;
                CPrintMethodsEXT tempPrintMethods1 = new CPrintMethodsEXT();
                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Print_Config.xml");
                if (dataGridView1.Rows.Count > 0)
                    if (Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["IsGuestBillPrinterSerial"]) == true)
                    {
                        //  tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, "SN".ToString());

                        tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, printingObject, serialFooter, "SN".ToString());

                    }
                    else
                    {
                        tempPrintMethods1.USBPrint(printingObject, PrintDestiNation.CLIENT, true);
                    }
                else
                {
                    MessageBox.Show("There is no record", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There is no record", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            //Int64 startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0).Ticks;
            //DateTime dtTemp = dtpEnd.Value.AddDays(1);
            //Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;

            //this.showAllData(startDate, endDate);
        }


        private List<CSearchOrderInfo> getAutoCheatOrderList(List<CSearchOrderInfo> oItemList)
        {

            //List<DayWiseReport> daywizeReportList = getCheatOrderListdayWize(oItemList);
            //List<CSearchOrderInfo> cheatOrderList = new List<CSearchOrderInfo>();


            //foreach (DayWiseReport daywizeReporItem in daywizeReportList)
            //{

            //    List<CSearchOrderInfo> OrderList = daywizeReporItem.OrderListPerday;

            //    decimal totalpaidVat = (from item in OrderList
            //                            select item.VatPaid).Sum();
            //    double reducedvat = Double.Parse(totalpaidVat.ToString()) * (Double.Parse(txtBoxCheatPercent.Text.Replace("%", "")) / 100);

            //    double temp = 0.0;

            //    foreach (CSearchOrderInfo item in OrderList)
            //    {
            //        if (temp < reducedvat)
            //        {
            //            temp += Double.Parse(item.VatPaid.ToString());
            //            cheatOrderList.Add(item);
            //        }
            //    }
            //}

            //return cheatOrderList;
            return null;
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


            //if (e.KeyValue == 13 && txtBoxSerialNumber.Text.ToLower()=="on")
            //{
            //    cheatPanel.Visible = true;
            //    txtBoxSerialNumber.Clear();

            //}
            //if (e.KeyValue == 13 && txtBoxSerialNumber.Text.ToLower() == "off")
            //{
            //    cheatPanel.Visible = false;
            //    txtBoxSerialNumber.Clear();

            //}


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
            //int rowIndex = int.Parse(e.RowIndex.ToString());
            //if (rowIndex >= 0)
            //{

            //    CSearchOrderInfo cSearchOrderInfo = (CSearchOrderInfo)dataGridView1.Rows[rowIndex].DataBoundItem;
            //    string orderID = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

            //    OrderDetails od = new OrderDetails(cSearchOrderInfo);
            //    od.ShowDialog();
            //}        
        }

        private void btnItemWiseReport_Click(object sender, EventArgs e)
        {

            //Int64 fromOID = 0;
            //Int64 toOID = 0;

            //if (oItemList.Count() == 0)
            //{
            //    MessageBox.Show("No order found in search criteria");
            //}
            //else
            //{
            //    fromOID = (from searchItem in oItemList
            //               select searchItem.OrderID).Min();

            //    toOID = (from searchItem in oItemList
            //             select searchItem.OrderID).Max();

            //    ItemReportForm itemWiseDateForm = new ItemReportForm(fromOID, toOID, dtpStart.Value, dtpEnd.Value, oItemList.Count(), radioButtonActualReport.Checked, dateRangeText);
            //    itemWiseDateForm.ShowDialog();
            //}

        }

        int maxOrder = 0;
        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            m_htFoods = new Hashtable();
            m_htNonFoods = new Hashtable();

        //    FormatDataTime();

            DataSet dsSalesRecords = new DataSet();
            CResult objResult = new CResult();
            SystemManager objSystemMgnr = new SystemManager();

            DateTime dtNow = DateTime.Now;

            DateTime dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

            //if (chkFromTime.Checked)
            //{
                dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 7, 0, 0);
                dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 6, 59, 59);
           // }

            dtEnd = dtEnd.AddDays(1);

            objResult = objSystemMgnr.GetSalesRecordsForINV(dtStart.Ticks, dtEnd.Ticks);
            StringPrintFormater strPrintFormatter = new StringPrintFormater(40);

            DataTable dt = (DataTable)objResult.Data;

            tableReport = new DataTable();
            tableReport.Columns.Add("product_id", typeof(int));
            tableReport.Columns.Add("product_Name", typeof(string));
            tableReport.Columns.Add("amount", typeof(string));
            tableReport.Columns.Add("quantity", typeof(string));
            tableReport.Columns.Add("TotalAmount", typeof(string));
            tableReport.Columns.Add("guest_count", typeof(int));
            tableReport.Columns.Add("cat_level", typeof(int));
            tableReport.Columns.Add("food_type", typeof(string));
            if (dt != null || dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    tableReport.Rows.Add(Convert.ToInt16(dt.Rows[i]["product_id"]), Convert.ToString(dt.Rows[i]["product_Name"]), dt.Rows[i]["amount"].ToString(), dt.Rows[i]["quantity"].ToString(), dt.Rows[i]["TotalAmount"].ToString(), Convert.ToInt16(dt.Rows[i]["guest_count"]), Convert.ToInt16(dt.Rows[i]["cat_level"]), dt.Rows[i]["food_type"].ToString());
                }

            if (dataGridView1.Rows.Count > 0)
                if (tableReport.Rows.Count > 0)
                {
                    // Int32 guestCounter = Convert.ToInt32(dsSalesRecords.Tables[0].Rows[0]["guest_count"]);
                    Int32 guestCounter = Convert.ToInt32(tableReport.Rows[0]["guest_count"]);
                    CPrintMethods tempPrintMethods = new CPrintMethods();

                    string serialHeader = RMSClientController.CollectHeader();

                    string serialFooter = RMSClientController.CollectFooter();

                    List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                    CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Inventory Sales Report") + "\r\n";
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Date of Consumption of Items:" + DateTime.Now.ToString("dd/MM/yyyy")) + "\r\n";
                    serialBody.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "No. of Covers:" + guestCounter.ToString() + "\n";
                    //serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine() +"\r\n";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Qty  Item                        Price(£)"+"\r\n";
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine() + "\r\n";
                    serialBody.Add(tempSerialPrintContent);

                    CCategory3DAO category3DAO = new CCategory3DAO();

                    SortedList slorderedFoodItems = new SortedList();
                    SortedList slorderedNonFoodItems = new SortedList();
                    //if (dsSalesRecords.Tables[0].Rows.Count > 0)
                    if (tableReport.Rows.Count > 0)
                    {
                        // foreach (DataRow dtRrow in dsSalesRecords.Tables[0].Rows)
                        foreach (DataRow dtRrow in tableReport.Rows)
                        {
                            clsOrderReport objOrderedItems = new clsOrderReport();
                            string[] returnedValue = GetProductName(dtRrow).Split(':');

                            //  string productName = Convert.ToString(returnedValue[0]);
                            string productName = "";
                            CCategory3 cat3 = category3DAO.GetAllCategory3ByCategory3ID(Convert.ToInt32(dtRrow["product_id"].ToString()));
                            if (cat3 != null && cat3.Category3Name.Length>0)
                            {
                                productName = cat3.Category3Name;
                            }
                            else
                            {
                              productName = Convert.ToString(dtRrow["product_Name"].ToString());  // @hafiz
                            }
                            string cat1ID = Convert.ToString(returnedValue[1]);

                            objOrderedItems.Quantity = Convert.ToInt32("0" + dtRrow["quantity"].ToString());
                            objOrderedItems.ItemName = productName;
                            objOrderedItems.Price = Convert.ToDouble(dtRrow["TotalAmount"]);
                            objOrderedItems.FoodTypeName = Convert.ToString(returnedValue[2]);
                            Int32 category1OrderNumber = 0;
                            if (cat1ID != "")
                            {
                                category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                                objOrderedItems.OrderNumber = category1OrderNumber;

                                string keyCode = category1OrderNumber + "-" + objOrderedItems.Quantity.ToString() + "-" + objOrderedItems.ItemName;

                                if (Convert.ToString(dtRrow["food_type"]).Equals("Food")) //Separate food/nonfoods
                                {
                                    m_htFoods.Add(keyCode, objOrderedItems);
                                }
                                else
                                {
                                    m_htNonFoods.Add(keyCode, objOrderedItems);
                                }
                            }
                            else
                            {
                                category1OrderNumber = maxOrder + 1;
                                objOrderedItems.OrderNumber = category1OrderNumber;

                                string keyCode = category1OrderNumber + "-" + objOrderedItems.Quantity.ToString() + "-" + objOrderedItems.ItemName;


                                if (Convert.ToString(dtRrow["food_type"]).Equals("Food")) //Separate food/nonfoods
                                {
                                    m_htFoods.Add(keyCode, objOrderedItems);
                                }
                                else
                                {
                                    m_htNonFoods.Add(keyCode, objOrderedItems);
                                }
                            }
                        }
                        int separatorNumber = -1;
                        NumericComparer nc = new NumericComparer();
                        slorderedFoodItems = new SortedList(m_htFoods, nc); //Creating the sorted list from the hash table.
                        slorderedNonFoodItems = new SortedList(m_htNonFoods, nc);


                        SortedList slMaster1 = new SortedList();
                        ArrayList arrListItems = null;

                        foreach (DictionaryEntry objOrderedItems in slorderedFoodItems)
                        {
                            clsOrderReport objItem = (clsOrderReport)objOrderedItems.Value;
                            string keyValue = objOrderedItems.Key.ToString();
                            string[] splitter = new string[0];
                            splitter = keyValue.Split('-');

                            if (separatorNumber != Convert.ToInt32(splitter[0]))
                            {
                                separatorNumber = Convert.ToInt32(splitter[0]);
                                arrListItems = new ArrayList();
                                arrListItems.Add(objItem);
                                slMaster1.Add(separatorNumber, arrListItems);
                            }
                            else
                            {
                                arrListItems.Add(objItem);
                                separatorNumber = Convert.ToInt32(splitter[0]);
                            }
                        }

                        PrintUtility printUtility = new PrintUtility();

                        ArrayList alReverseOrderedItem;

                        foreach (DictionaryEntry deReverseOrderedItem in slMaster1)
                        {
                            alReverseOrderedItem = (ArrayList)deReverseOrderedItem.Value;
                            alReverseOrderedItem.Reverse();//Reversing the current item order.

                            foreach (clsOrderReport objOrderedItems in alReverseOrderedItem)
                            {
                                if (separatorNumber != objOrderedItems.OrderNumber)
                                {
                                   
                                   

                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = objOrderedItems.FoodTypeName + ":" +"\r\n";
                                    serialBody.Add(tempSerialPrintContent);

                                    tempSerialPrintContent = new CSerialPrintContent();

                                    //tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                                    //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                                    //tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);

                                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                printUtility.MultipleLine(objOrderedItems.ItemName, 32,
                                                                          objOrderedItems.Price.ToString("F02"), 37), "");

                                    serialBody.Add(tempSerialPrintContent);

                                    separatorNumber = objOrderedItems.OrderNumber;
                                }
                                else
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    //tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                                    //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                                    //tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);

                                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                printUtility.MultipleLine(objOrderedItems.ItemName, 32,
                                                                          objOrderedItems.Price.ToString("F02"), 37), "");

                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }
                        }

                        #region "Non food items"
                        tempSerialPrintContent = new CSerialPrintContent();

                        tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n";
                      //  tempSerialPrintContent.StringLine =  "-----------------Drinks-----------------" + "\r\n";
                        serialBody.Add(tempSerialPrintContent);


                        SortedList slMaster2 = new SortedList();
                        ArrayList arrListItemsNonFood = new ArrayList();
                        separatorNumber = -1;
                        foreach (DictionaryEntry objOrderedNonFood in slorderedNonFoodItems)
                        {
                            clsOrderReport objItem = (clsOrderReport)objOrderedNonFood.Value;
                            string keyValue = objOrderedNonFood.Key.ToString();
                            string[] splitter = new string[0];
                            splitter = keyValue.Split('-');

                            if (separatorNumber != Convert.ToInt32(splitter[0]))
                            {
                                separatorNumber = Convert.ToInt32(splitter[0]);
                                arrListItemsNonFood = new ArrayList();
                                arrListItemsNonFood.Add(objItem);
                                slMaster2.Add(separatorNumber, arrListItemsNonFood);
                            }
                            else
                            {
                                arrListItemsNonFood.Add(objItem);
                                separatorNumber = Convert.ToInt32(splitter[0]);
                            }
                        }

                        separatorNumber = -1;
                        bool istrue = false;
                        foreach (DictionaryEntry objNonFood in slMaster2)
                        {
                            ArrayList alNonFoods = (ArrayList)objNonFood.Value;
                            alNonFoods.Reverse();
                            foreach (clsOrderReport objNonFoodItem in alNonFoods)
                            {
                                if (separatorNumber != objNonFoodItem.OrderNumber)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    // tempSerialPrintContent.StringLine = "----------------------------------------";
                                    serialBody.Add(tempSerialPrintContent);
                                    if (tempSerialPrintContent != null && tempSerialPrintContent.StringLine.Equals("") && !istrue)
                                    {
                                        tempSerialPrintContent = new CSerialPrintContent();
                                        tempSerialPrintContent.StringLine = objNonFoodItem.FoodTypeName + ":" +"\r\n";
                                        serialBody.Add(tempSerialPrintContent);
                                    }

                                    tempSerialPrintContent = new CSerialPrintContent();
                                    //tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                                    //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                                    //tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);
                                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText(objNonFoodItem.Quantity.ToString() + "  " +
                                                printUtility.MultipleLine(objNonFoodItem.ItemName, 32,
                                                                          objNonFoodItem.Price.ToString("F02"), 37), "");
                                    serialBody.Add(tempSerialPrintContent);

                                    separatorNumber = objNonFoodItem.OrderNumber;

                                    istrue = true;
                                }
                                else
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                   
                                    //tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                                    //tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                                    //tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);

                                    tempSerialPrintContent.StringLine = strPrintFormatter.ItemLabeledText(objNonFoodItem.Quantity.ToString() + "  " +
                                             printUtility.MultipleLine(objNonFoodItem.ItemName, 32,
                                                                       objNonFoodItem.Price.ToString("F02"), 37), "");

                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }
                        }

                        #endregion

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "----------------------------------------\r\n";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Total No Of Item: " + lblNoOfItemsSold.Text + "\r\n";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Total Qty: " + lblTotalQty.Text + "\r\n";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Total Item Amount: " + lblTotalAmount.Text + "\r\n";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine() + "\r\n";
                        serialBody.Add(tempSerialPrintContent);
                        tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = strPrintFormatter.CenterTextWithWhiteSpace("Developed By: www.ibacs.co.uk") + "\r\n\n";
                        serialBody.Add(tempSerialPrintContent);

                        #region "Testing printing area"
                        string printingObject = "";
                        for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                        {
                            printingObject += serialBody[arrayIndex].StringLine.ToString();
                        }

                        this.WriteString(printingObject);///Write to a file when print command is executed

                        #endregion
                        //@aamr Remote Print
                        CCommonConstants m_oCommonConstants;
                        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                        CLogin oLogin = new CLogin();
                        oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), m_oCommonConstants.RemoteURL);


                        CResult oResult = oLogin.GetInitialDBStr();
                        Object o = oLogin.GetType();
                        CPrintingFormat inPrintRequest = new CPrintingFormat();
                        inPrintRequest.Header = "Header";
                        inPrintRequest.Footer = "Footer";
                        inPrintRequest.Body = "Hello Remote Printing...";
                        try
                        {
                            oLogin.PostPrintingRequest(inPrintRequest);
                            PostPrintingRequest1(inPrintRequest);
                        }
                        catch (Exception ex)
                        {

                        }

                        CPrintMethodsEXT tempPrintMethods1 = new CPrintMethodsEXT();
                        DataSet tempDataSet = new DataSet();
                        tempDataSet.ReadXml("Config/Print_Config.xml");

                        if (Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["IsGuestBillPrinterSerial"]) == true)
                        {
                            // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, "SN".ToString());

                            tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, printingObject, serialFooter, "SN".ToString());

                        }
                        else
                        {
                            tempPrintMethods1.USBPrint(printingObject, PrintDestiNation.CLIENT, true);

                        }


                    }
                }
                else
                {
                    MessageBox.Show("There is no record", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }
        public void PostPrintingRequest1(CPrintingFormat inPrintRequest)
        {
            try
            {
                bool bTempFlag = false;

                Debug.WriteLine("in PostPrintingRequest 1");
                CPrintQueue.Init();
                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                //  m_oPrintRequest = inPrintRequest;

                Debug.WriteLine("in PostPrintingRequest 2");
                // m_mPrintMutex = oCommonConstants.PrintMutex;

                Debug.WriteLine("in PostPrintingRequest 3");

                try
                {
                    Debug.WriteLine("in PostPrintingRequest 4");

                    // bTempFlag = m_mPrintMutex.WaitOne(oCommonConstants.ThreadWaitTime, false);
                    bTempFlag = true;
                    Debug.WriteLine("in PostPrintingRequest 5");

                    if (bTempFlag)
                    {

                        try
                        {
                            Debug.WriteLine("in PostPrintingRequest 6");

                            //if (m_oPrintRequest != null && CPrintQueue.PrintQueue != null)
                            //{
                            //    Debug.WriteLine("in PostPrintingRequest 7");

                            CPrintQueue.PrintQueue.Enqueue(inPrintRequest);

                            //    Debug.WriteLine("in PostPrintingRequest 8");
                            //}
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        try
                        {
                            Debug.WriteLine("in PostPrintingRequest 9");

                            //  m_mPrintMutex.ReleaseMutex();

                            Debug.WriteLine("in PostPrintingRequest 10");
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine(ex1.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
        private string getSummaryPrintText(string dateString, int lineLength, bool showHeader)
        {

            return null;
        }

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
            //DialogResult dr= MessageBox.Show("Are you sure to print this Report with the fiscal print?", "Confirmation", MessageBoxButtons.OKCancel);

            //if (dr == DialogResult.OK)
            //{
            //    if (fiscalPrinter.foundPrinter())
            //    { 
            //        fiscalPrinter.PerformReportPrint(getSummaryPrintText(dateRangeText, 35, false));
            //    }
            //}
        }

        private void checkBoxMothWise_CheckedChanged(object sender, EventArgs e)
        {
            //dtpStart.Enabled=checkBoxDateRangeWise.Checked;
            //dtpEnd.Enabled=checkBoxDateRangeWise.Checked;


            //btnSetToday.Enabled=checkBoxDateRangeWise.Checked;
            //comboBoxMonthList.Enabled = !checkBoxDateRangeWise.Checked;
            //comboBoxYear.Enabled = !checkBoxDateRangeWise.Checked;
            //performSetDate();

        }


        private void comboBoxMonthList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //performSetDate();
        }

        private void btnSetToday_Click(object sender, EventArgs e)
        {
            //dtpStart.Value = DateTime.Today;
            //dtpEnd.Value = DateTime.Today;
        }

        private void performSetDate()
        {
            //if (!checkBoxDateRangeWise.Checked)
            //{
            //    dtpStart.Value = new DateTime(Convert.ToInt32(comboBoxYear.Text), comboBoxMonthList.SelectedIndex + 1, 1);
            //    dtpEnd.Value = new DateTime(Convert.ToInt32(comboBoxYear.Text), comboBoxMonthList.SelectedIndex + 1, DateTime.DaysInMonth(DateTime.Now.Year, comboBoxMonthList.SelectedIndex + 1));
            //}
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  performSetDate();
        }


        Hashtable m_htFoods = new Hashtable();
        Hashtable m_htNonFoods = new Hashtable();


        /// <summary>
        /// This functions retuns the category 1 order number
        /// </summary>
        /// <param name="p_categoryID"></param>
        /// <returns></returns>
        private Int32 GetCategory1OrderNumber(Int32 p_categoryID)
        {
            Int32 category1OrderNumber = 0;
            DataRow[] dtRow = Program.initDataSet.Tables["Category1"].Select("cat1_id = " + p_categoryID);
            if (dtRow.Length > 0)
            {
                category1OrderNumber = Convert.ToInt32("0" + dtRow[0]["Cat1_order_number"]);
            }
            maxOrder = category1OrderNumber;//@Salim
            return category1OrderNumber;
        }
        /// <summary>
        /// Finding the product name from the product ID
        /// </summary>
        /// <param name="p_dtRow"></param>
        /// <returns></returns>
        private string GetProductName(DataRow p_dtRow)
        {
            string cat1ID = String.Empty;
            string cat2ID = String.Empty;
            string cat3ID = String.Empty;
            string foodTypeName = String.Empty;

            Int64 productID = Int64.Parse(p_dtRow["product_id"].ToString());
            Int32 productLevel = Int32.Parse(p_dtRow["cat_level"].ToString());

            string tempProductName = "";
            if (productLevel == 0)
            {
                try
                {
                    tempProductName = tableReport.Rows[tableReport.Rows.Count - 1]["product_Name"].ToString();
                    foodTypeName = "Miscellaneous";
                }
                catch (Exception)
                {

                }

            }
            if (productLevel == 3)
            {
                DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + productID);

                if (tempDataRowArr.Length > 0)  //Added by Baruri .This was a bug previously when no row found.
                {
                    tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                    cat2ID = tempDataRowArr[0]["cat2_id"].ToString();
                    if (productID == 2245)
                    {
                    }
                    cat1ID = Program.initDataSet.Tables["category2"].Select("cat2_id = " + cat2ID)[0]["cat1_id"].ToString();
                    foodTypeName = Program.initDataSet.Tables["category1"].Select("cat1_id = " + cat1ID)[0]["cat1_name"].ToString();

                }
                //else if (tempDataRowArr == null || tempDataRowArr.Length == 0)
                //{
                //    CCategory3DAO category3DAO = new CCategory3DAO();
                //    CCategory3 cat = category3DAO.GetAllCategory3ByCategory3ID(Convert.ToInt32(productID.ToString()));
                //}
               
            }

            else if (productLevel == 4)
            {
                DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + productID);
                int tempCat3_id = 0;
                if (tempDataRowArr.Length > 0)
                {
                    tempCat3_id = Convert.ToInt32("0" + tempDataRowArr[0]["cat3_id"]);
                }

                tempProductName = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + productID)[0]["cat4_name"].ToString();

                tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempCat3_id);

                if (tempDataRowArr.Length > 0)//If rows found
                {
                    tempProductName += " " + tempDataRowArr[0]["cat3_name"].ToString();
                    cat2ID = tempDataRowArr[0]["cat2_id"].ToString();
                }
                cat1ID = Program.initDataSet.Tables["Category2"].Select("cat2_id = " + cat2ID)[0]["cat1_id"].ToString();
                foodTypeName = Program.initDataSet.Tables["category1"].Select("cat1_id = " + cat1ID)[0]["cat1_name"].ToString();
            }
            return tempProductName + ":" + cat1ID + ":" + foodTypeName;
        }
        private void btnCurrentDay_Click(object sender, EventArgs e)
        {
            DataSet dsSalesRecords = new DataSet();
            CResult objResult = new CResult();
            SystemManager objSystemMgnr = new SystemManager();

            DateTime dtNow = DateTime.Now;
            DateTime dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

            objResult = objSystemMgnr.GetSalesRecords(dtStart.Ticks, dtEnd.Ticks);

            DataTable dt = (DataTable)objResult.Data;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
            {
                // MessageBox.Show("There is no record", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WriteString(string s)
        {
            StreamWriter fstr_out;

            // Open the file directly using StreamWriter. 
            try
            {
                fstr_out = new StreamWriter("rms_printedcopy.txt");
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "Cannot open file.");
                return;
            }

            try
            {
                fstr_out.Write(s);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "File Error");
                return;
            }
            fstr_out.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lelFoodPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnClearFP_Click(object sender, EventArgs e)
        {

        }


        private void btnPrintA4_Click(object sender, EventArgs e)
        {
            if (tableReport == null)
            {
                MessageBox.Show("No Data found");
                return;
            }
            PrintDocument doc = new TextDocument(PrintReportA4());
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }
        private string PrintReportA4()
        {


            string strBody = "";
            stringPrintFormater = new StringPrintFormater(150);
            // strBody += "\r\n";
            //  strBody += "\r\n";
            string hader = GetPrintDecorationText(PrintDecoration.HEADER);

            printReportLogoType = 1;

            string[] lines;
            char[] param = { '\n' };
            lines = hader.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };

            string TotalHader = "";
            foreach (string s in lines)
            {
                TotalHader += stringPrintFormater.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
            }

            strBody += TotalHader;
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("INVENTORY REPORT");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Date: From - " + dtpStart.Value.Date.ToShortDateString() + " to " + dtpEnd.Value.Date.ToShortDateString());
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Order: " + oItemList.Count, "Order Total: " + lelOrderTotal_Value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Guest: " + lelGuest_Value.Text, "Service Charge: " + lelServiceCharge_Value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Food Price: " + lelFoodPrice_Value.Text, "Delivery Charge: " + "0.00");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Non Food Price: " + lelNonfoodPrice_Value.Text, "Discount: " + lelDiscount_Value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Take Away Food Price: " + lelTakeAwayFoodPrice_Value.Text, "Total Paid (ExVat): " + lelTotalpaidEXVAT_value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Take Away Non Food Price: " + lelTakeAwayNonfoodPrice_Value.Text, "Total Paid (IncVat): " + lelTotalpaidIncVAT_value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Table Food Price: " + lelTableFoodPrice_Value.Text, "Vat Total: " + lelVat_Value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Table Non Food Price: " + lelTableNonfoodPrice_Value.Text, "Cash: " + lelCashTotal_value.Text);
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("", "EFT: " + lelEftTotal_value.Text);
            // strBody += "\r\n" + stringPrintFormater.CreateDashedLine();



            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n";
            strBody += stringPrintFormater.GridCell("Item Name", 100, false);
            strBody += stringPrintFormater.GridCell("Item Price", 15, true);
            strBody += stringPrintFormater.GridCell("Item Qty", 10, true);
            strBody += stringPrintFormater.GridCell("Total Amount(" + Program.currency + ")", 25, true);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (DataRow row in tableReport.Rows)
            {
                strBody += "\r\n";
                strBody += stringPrintFormater.GridCell(row[1].ToString(), 100, false);
                strBody += stringPrintFormater.GridCell(row[2].ToString(), 15, true);
                strBody += stringPrintFormater.GridCell(row[3].ToString(), 10, true);
                strBody += stringPrintFormater.GridCell(row[4].ToString(), 25, true);

                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            }
            strBody += "\r\n" + "Total No. of Items Sold: " + lblNoOfItemsSold.Text;
            strBody += "\r\n" + "Total Orders: " + lblTotalQty.Text;
            strBody += "\r\n" + "Total Order Amount (£): " + lblTotalAmount.Text;


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + "Printed at : " + DateTime.Now.ToString("dd MMMM yyyy") + "-" + DateTime.Now.ToString("hh:mm:ss tt");

            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");
            //strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            //strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Developed By: www.ibacs.co.uk") + "\r\n\n";
            return strBody;

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

        private void SalesReport_Load(object sender, EventArgs e)
        {
       //     FormatDataTime();
           // LoadShiftManagement();
        }

        private void FormatDataTime()
        {
            chkFromTime.Checked = true;
            DateTime fromDate = new DateTime(1971,1,1, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);

            dtpStart.Value = System.DateTime.Now;
            dtpEnd.Value = System.DateTime.Now;
            DateTime firstDate = new DateTime(1971, 1, 1, 12, 0, 0);
            DateTime secondDate = new DateTime(1971, 1, 1,  6, 59, 59);
            DateTime excepTime = dtpStart.Value.AddHours(-1);

            if (fromDate >= firstDate && fromDate <= secondDate || excepTime.Day < dtpStart.Value.Day)
            {
                dtpStart.Value = dtpStart.Value.AddDays(-1);
            }
            else
            {
                dtpEnd.Value = dtpEnd.Value.AddDays(1);
            }

        }

        private void LoadShiftManagement()
        {
           // comboBoxshift.Items.Clear();

            //IShiftScheduleDao iShiftScheduleDao = new CShiftScheduleDao();
            //listCShiftSchedule = iShiftScheduleDao.GetAllShiftSchedule();

            //foreach (CShiftSchedule shiftOrderInfo in listCShiftSchedule)
            //{
            //    string duration = Utilities.GetFormatedDateTimeToString(shiftOrderInfo.StartTime) + "   To   " +
            //                     Utilities.GetFormatedDateTimeToString(shiftOrderInfo.EndTime) + "  (" + shiftOrderInfo.ShiftNo.ToString() +
            //                     ")";

            //    DateTime fromDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            //    DateTime toDate = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, dtpEnd.Value.Hour, dtpEnd.Value.Minute, 0);


            //    //if (fromDate >= shiftOrderInfo.StartTime || toDate <= shiftOrderInfo.EndTime)
            //    //{
            //    //    comboBoxshift.Items.Add(duration);
            //    //}

            //    //if (comboBoxshift.Items.Count > 0)
            //    //    comboBoxshift.SelectedIndex = 0;

            //    //try
            //    //{
            //    //    var c = Convert.ToDateTime(dtpStart.Text);
            //    //    var d = Convert.ToDateTime(dtpEnd.Text);

            //    //    var a = DateTime.Now.ToString("MM/dd/yyyy");
            //    //    var b = shiftOrderInfo.StartDay.ToString("MM/dd/yyyy");
            //    //    string[] temp = b.Split('/');
            //    //    b = temp[1] + "/" + temp[0] + "/" + temp[2];
            //    //    if ((Convert.ToDateTime(b) >= Convert.ToDateTime(dtpStart.Text)) &&
            //    //        (Convert.ToDateTime(b) <= Convert.ToDateTime(dtpEnd.Text)))
            //    //    {

            //    //        comboBoxshift.Items.Add(duration);
            //    //    }
            //    //}
            //    //catch
            //    //{
            //    //}
           // }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
