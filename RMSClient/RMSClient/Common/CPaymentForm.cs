using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.Payment;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using Managers.Customer;
using System.Net;
using System.Diagnostics;
using Managers.Deposit;
using System.Data.SqlClient;
using RMS.DataAccess;
using System.Collections;
using ns;
using System.IO;
using RMSUI;
using Managers.GManager;
using RMS.Utility;
using RMSClient.DataAccess;


namespace RMS.Common
{
    public partial class CPaymentForm : BaseForm
    {

        #region "Declaration Area"

        private Int64 m_iOrderID = 0;
        private Double m_dTotalAmount = 0.0;
        private Double m_dBalance = 0.0;
        private CPayment m_cPayment;
        private String m_sTableType;
        private DataTable m_dtItemList;
        private bool m_bEqualSplit = false;
        private String CurrentPaymentMethod = "";
        private CDepositUsed m_oDepositUsed;
        private CDeposit m_oDeposit;
        private COrderVoucher m_oOrderVoucher;
        private int m_iDrinksIndex = -1;
        private CCommonConstants m_cCommonConstants;
        public string m_TerminalName = String.Empty;
        public string m_OperatorName = String.Empty;

        private DataSet dsCategory2 = new DataSet();
        private DataSet dsCategory3 = new DataSet();
        private DataSet dsCategory4 = new DataSet();
        private Double m_dServiceAmount = 0.0;
        public static string m_orderUserName = String.Empty;

        private double m_serviceCharge_cash = 0.0;
        private double m_serviceCharge_cheque = 0.0;
        private double m_serviceCharge_eft = 0.0;
        private double m_serviceCharge_accounts = 0.0;
        private double m_serviceCharge_voucher = 0.0;
        private double m_restServiceCharge = 0.0;
        private double m_tobePaid = 0.0;//This variable keeps the total payment without the service charge
        private bool m_isAddServiceCharge = false;
        private double m_itemCost = 0.0;

        private double vat = Program.vat;

        private bool isVatEnabled = Program.isVatEnabled;
        private double vatTotalAmount = 0.0;
        private string gusetBillStr = "";
        private double tipsamount = 0.0;
        private decimal membershipdiscount = 0;
        private string complementoryMessage;
        private string dueMessage;
        

        private EFTCardManager eFTCardManager;

        private bool makeOpen = true;

        #endregion

        #region "Initialization Area"

        public CPaymentForm()
        {
            InitializeComponent();
        }
        public CPaymentForm(Int64 inOrderID, Double inTotalAmount, String inTableType, DataTable inItemList, decimal inDiscount, int drinksIndex, string terminalName, string operatorName, string serviceCharge,decimal inMembershipdiscount)
        {

            eFTCardManager = new EFTCardManager();

            if (!isVatEnabled)
            {
                vat = 0.00;
            }


            InitializeComponent();

            g_BalaceLabel.Text = Program.currency + "0.00";
            g_BillTotalLabel.Text = Program.currency + "0.00";
            g_CashLabel.Text = Program.currency + "0.00";
            g_ChequeLabel.Text = Program.currency + "0.00";
            g_DiscountLabel.Text = Program.currency + "0.00";
            g_EFTLabel.Text = Program.currency + "0.00";
            g_SplitAmountLabel.Text = Program.currency + "0.00";
            g_ServiceChargeLabel.Text = Program.currency + "0.00";
            g_VoucherLabel.Text = Program.currency + "0.00";
            g_AccountLabel.Text = Program.currency + "0.00";
            g_DepositUsedLabel.Text = Program.currency + "0.00";
            g_InputTextBox.Text = Program.currency + "0.00";
            membershipdiscountlabel.Text = Program.currency + "0.00";
            g_InputTextBox.MaxLength = 20;





            currencyKeyPad1.CurrencySign = Program.currency;

            m_OperatorName = operatorName;
            m_TerminalName = terminalName;

            m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            String ConnectionString = m_cCommonConstants.DBConnection;
            SqlDataAdapter daCategory3 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category3GetAll), ConnectionString);
            daCategory3.Fill(dsCategory3, "Category3");
            daCategory3.Dispose();

            SqlDataAdapter daCategory4 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category4GetAll), ConnectionString);
            daCategory4.Fill(dsCategory4, "Category4");
            daCategory4.Dispose();

            SqlDataAdapter tempSqlDataAdapter5 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category2GetAll), ConnectionString);
            tempSqlDataAdapter5.Fill(dsCategory2, "Category2");
            tempSqlDataAdapter5.Dispose();



            m_oDepositUsed = new CDepositUsed();
            m_oDeposit = new CDeposit();
            m_iOrderID = inOrderID;


            m_dTotalAmount = inTotalAmount;
            membershipdiscount = inMembershipdiscount;

            m_dBalance = inTotalAmount + Convert.ToDouble("0" + serviceCharge);
            m_sTableType = inTableType;
            m_dtItemList = inItemList;
            m_iDrinksIndex = drinksIndex;
            m_dServiceAmount = Convert.ToDouble("0" + serviceCharge);

            g_BalaceLabel.Text = String.Format("Balace Due {0}" + (inTotalAmount + Convert.ToDouble("0" + serviceCharge)).ToString("F02"), Program.currency);
            g_BillTotalLabel.Text = Program.currency + m_dBalance.ToString("F02");
            m_tobePaid = inTotalAmount; //Total without service charge

            g_DiscountLabel.Text = Program.currency + inDiscount.ToString();
            g_ServiceChargeLabel.Text = Program.currency + Convert.ToDouble("0" + serviceCharge).ToString("F02");
            membershipdiscountlabel.Text = Program.currency + inMembershipdiscount.ToString();

            // double grand = m_dTotalAmount + Convert.ToDouble(inDiscount);

            //Vat Claculation
            DataTable dt = inItemList;
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                vatTotalAmount += Convert.ToDouble( dt.Rows[i]["Vat"].ToString());
            }
            lblVat.Text = Program.currency + vatTotalAmount.ToString("F02");

            //   vatTotalAmount = ((m_dTotalAmount + Convert.ToDouble(inDiscount)) * (vat / 100)) / (1 + (vat / 100));
          //  lblVat.Text = Program.currency + vatTotalAmount.ToString("F02");
            
            

            //String CashButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Cash'")[0]["color"].ToString();
            //g_CashButton.BackColor = Color.FromArgb(Int32.Parse(CashButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(CashButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(CashButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            //String ChequeButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Cheque'")[0]["color"].ToString();
            //g_ChequeButton.BackColor = Color.FromArgb(Int32.Parse(ChequeButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(ChequeButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(ChequeButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            //String EFTButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'EFT'")[0]["color"].ToString();
            //g_EFTButton.BackColor = Color.FromArgb(Int32.Parse(EFTButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(EFTButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(EFTButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String VoucherButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Voucher'")[0]["color"].ToString();
            //g_VoucherButton.BackColor = Color.FromArgb(Int32.Parse(VoucherButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(VoucherButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(VoucherButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String AccountButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Account'")[0]["color"].ToString();
            //g_AccountButton.BackColor = Color.FromArgb(Int32.Parse(AccountButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(AccountButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(AccountButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String LoyaltiCardButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Loyalty Card'")[0]["color"].ToString();
            //g_LoyaltiCardButton.BackColor = Color.FromArgb(Int32.Parse(LoyaltiCardButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(LoyaltiCardButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(LoyaltiCardButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String DiscountColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Discount'")[0]["color"].ToString();
            //g_DiscountButton.BackColor = Color.FromArgb(Int32.Parse(DiscountColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(DiscountColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(DiscountColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            LoadPrintOffButton();
            LoadStatusBar(inOrderID);

        }

        public CPaymentForm(Int64 inOrderID, Double inTotalAmount, String inTableType, DataTable inItemList, Double inDiscount, int drinksIndex, string serviceCharge)
        {
            InitializeComponent();

            m_cCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            String ConnectionString = m_cCommonConstants.DBConnection;
            SqlDataAdapter daCategory3 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category3GetAll), ConnectionString);
            daCategory3.Fill(dsCategory3, "Category3");
            daCategory3.Dispose();

            SqlDataAdapter daCategory4 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category4GetAll), ConnectionString);
            daCategory4.Fill(dsCategory4, "Category4");
            daCategory4.Dispose();

            SqlDataAdapter tempSqlDataAdapter5 = new SqlDataAdapter(SqlQueries.GetQuery(Query.Category2GetAll), ConnectionString);
            tempSqlDataAdapter5.Fill(dsCategory2, "Category2");
            tempSqlDataAdapter5.Dispose();



            m_oDepositUsed = new CDepositUsed();
            m_oDeposit = new CDeposit();
            m_iOrderID = inOrderID;

            m_dTotalAmount = inTotalAmount;

            m_dBalance = inTotalAmount + Convert.ToDouble("0" + serviceCharge);
            m_sTableType = inTableType;
            m_dtItemList = inItemList;
            m_iDrinksIndex = drinksIndex;
            m_dServiceAmount = Convert.ToDouble("0" + serviceCharge);

            g_BalaceLabel.Text = String.Format("Balace Due {0}" + (inTotalAmount + Convert.ToDouble("0" + serviceCharge)).ToString("F02"), Program.currency);
            g_BillTotalLabel.Text = Program.currency + inTotalAmount.ToString("F02");
            m_tobePaid = inTotalAmount; //Total without service charge

            g_DiscountLabel.Text = Program.currency + inDiscount.ToString("F02");
            g_ServiceChargeLabel.Text = Program.currency + Convert.ToDouble("0" + serviceCharge).ToString("F02");

            //String CashButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Cash'")[0]["color"].ToString();
            //g_CashButton.BackColor = Color.FromArgb(Int32.Parse(CashButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(CashButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(CashButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            //String ChequeButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Cheque'")[0]["color"].ToString();
            //g_ChequeButton.BackColor = Color.FromArgb(Int32.Parse(ChequeButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(ChequeButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(ChequeButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            //String EFTButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'EFT'")[0]["color"].ToString();
            //g_EFTButton.BackColor = Color.FromArgb(Int32.Parse(EFTButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(EFTButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(EFTButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String VoucherButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Voucher'")[0]["color"].ToString();
            //g_VoucherButton.BackColor = Color.FromArgb(Int32.Parse(VoucherButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(VoucherButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(VoucherButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String AccountButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Account'")[0]["color"].ToString();
            //g_AccountButton.BackColor = Color.FromArgb(Int32.Parse(AccountButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(AccountButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(AccountButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String LoyaltiCardButtonColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Loyalty Card'")[0]["color"].ToString();
            //g_LoyaltiCardButton.BackColor = Color.FromArgb(Int32.Parse(LoyaltiCardButtonColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(LoyaltiCardButtonColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(LoyaltiCardButtonColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));


            //String DiscountColorString = Program.initDataSet.Tables["ButtonColor"].Select("name = 'Discount'")[0]["color"].ToString();
            //g_DiscountButton.BackColor = Color.FromArgb(Int32.Parse(DiscountColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(DiscountColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
            //        Int32.Parse(DiscountColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber));

            LoadPrintOffButton();
            LoadStatusBar(inOrderID);

        }

        #endregion

        #region "Manupulation Area"

        /*********Important*********/
        public int printlinelength = 27;//@Salim
        public int qty_length_with_twospace = 4;
        private void PrintPaymentBill(int paymentMethodIndex)
        {
            
            bool isPrintA5GuestBill = false;
            if (isPrintA5GuestBill)
            {
                PrintA5GuestBillReport(2);
            }
            else
            {

                int paperSize = 37;
                StringPrintFormater strPrintFormatter = new StringPrintFormater(37);

                COrderWaiterDao orderWaiterDao = new COrderWaiterDao(); // Change by Mithu
                COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(m_iOrderID); // Change by Mithu

                m_itemCost = 0.0;
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();
                Hashtable htOrderedItems = new Hashtable();
                SortedList slOrderedItems = new SortedList();
                //string serialHeader = "IBACS RMS";
                string serialHeader = "";
                //string serialFooter = "Please Come Again";
                string serialFooter = "";

                string serialBody = "";
               
                serialBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Bill  Payment"); // Change by Mithu
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;
                serialBody += "\r\n\r\n       Vat Reg. No: " + Program.vatRegDes; // Change by Mithu
                serialBody = "\r\nWaiter Name: " + orderWaiter.WaiterName + "\r\n";
                serialBody += "\r\n\nOrder ID:" + m_iOrderID.ToString();
                //serialBody += "\r\n" + strPrintFormatter.CreateDashedLine(); // Change by Mithu
                if (m_sTableType.Equals("Table"))
                {
                    
                    serialBody += "\r\n\nTable #" + tempOrderInfo.TableNumber.ToString(); // Change by Mithu
                    serialBody += "\r\n                    Served by:" + m_OperatorName; // Change by Mithu
                    serialBody += "\r\n\n                    Cust #" + tempOrderInfo.GuestCount.ToString();  // Change by Mithu
                    //serialBody += "\r\nDate: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"); // Change by Mithu
                    serialBody += "\r\n" + System.DateTime.Now.ToString("\r\ndd/MM/yy hh:mm tt");  // Change by Mithu
                }

                    
                else if (m_sTableType.Equals("TakeAway"))
                {
                    serialBody += "\r\n\nTake Away" + "Date: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");
                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    if (tempCustomerInfo.CustomerName.Length > 0)
                    {
                        serialBody += "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                    }
                    if (tempCustomerInfo.CustomerPhone.Length > 0)
                    {
                        serialBody += "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                    }

                    serialBody += "\r\nType: " + tempOrderInfo.Status;
                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        serialBody += "\r\nAddress:";
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            serialBody += "\r\nFloor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                        }
                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            serialBody += "\r\nBuilding Name:" + tempCustomerInfo.BuildingName;
                        }
                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            serialBody += "\r\nHouse Number:" + tempCustomerInfo.HouseNumber;
                        }
                        string[] street = new string[0];
                        street = tempCustomerInfo.StreetName.Split('-');

                        if (street.Length > 1)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                serialBody += "\r\nStreet:" + street[0].ToString();
                            }
                            if (street[1].ToString().Length > 0)
                            {
                                serialBody += "\r\n" + street[1].ToString();
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                serialBody += "\r\nStreet:" + street[0].ToString();
                            }
                        }
                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            serialBody += "\r\nPostal Code:" + tempCustomerInfo.CustomerPostalCode;
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            serialBody += "\r\nTown:" + tempCustomerInfo.CustomerTown;
                        }
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = m_iOrderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;
                        serialBody += "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                    }
                }
                else if (m_sTableType.Equals("Tabs"))
                {
                    serialBody += "\r\n\nBar Service" + " Date: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");
                    if (tempOrderInfo.TableNumber != 0)
                        serialBody += "\r\nTab Number: " + tempOrderInfo.TableNumber.ToString();
                }

                serialBody += "\r\n\nOrder Information";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                //serialBody += "\n----------------------------------------";

                #region "Local Orders"
                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                {
                    #region "For Bar service"

                    if (m_dtItemList.Columns.Count == 3) //For bar service
                    {
                        //serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                        for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                        {
                            if (rowIndex == m_iDrinksIndex)
                                // serialBody += "\r\n----------------------------------------";
                                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                            DataRow tempRow = m_dtItemList.Rows[rowIndex];
                            serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(tempRow["Qty"].ToString() + "  " +
                             tempRow["Item"].ToString(), tempRow["Price"].ToString());
                            m_itemCost += Convert.ToDouble("0" + tempRow["Price"].ToString()); //New for item cost of the bar service
                        }
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();//Separator after the bar items.
                    }
                    #endregion

                    #region "For foods separator is used "

                    else
                    {
                        string cat2ID = "";
                        string cat3ID = "";
                        string cat1ID = "";
                        Int32 internalCategoryID = 0;
                        Int32 categoryID = 0;
                        string categoryOrder = String.Empty;

                        for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                        {
                            #region "Parent Category"
                            DataRow tempRow = m_dtItemList.Rows[rowIndex];
                            categoryOrder = String.Empty;
                            if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 3)//Item from Category 3
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }

                            else if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 0)//Item from Category 3
                            {
                                cat1ID = "0";
                                cat2ID = "0";
                            }
                            else
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat3ID = dtRow[0]["cat3_id"].ToString();
                                }

                                dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }
                            #endregion

                            clsOrderReport objOrderedReport = new clsOrderReport();
                            objOrderedReport.Quantity = Convert.ToInt32("0" + tempRow["Qty"].ToString());
                            objOrderedReport.ItemName = tempRow["Item"].ToString();
                            objOrderedReport.Price = Convert.ToDouble("0" + tempRow["Price"].ToString());
                            int drinkValue = Convert.ToInt32("0" + tempRow["isdrink"].ToString());
                            if (drinkValue > 0)
                            {
                                objOrderedReport.DrinkStatus = true;
                            }
                            else
                            {
                                objOrderedReport.DrinkStatus = false;
                            }
                            Int64 rankNumber = Int64.Parse(tempRow["rank"].ToString());

                            Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                            htOrderedItems.Add(category1OrderNumber + "-" + rankNumber + "-" + objOrderedReport.ItemName, objOrderedReport);

                            m_itemCost += Convert.ToDouble("0" + tempRow["Price"].ToString());
                        }

                        NumericComparer nc = new NumericComparer();
                        slOrderedItems = new SortedList(htOrderedItems, nc);
                        int keyIndex = 0;
                        string[] valueSplitter = new string[0];
                        SortedList slDrinkItems = new SortedList();
                        SortedList slMiscellaneousItems = new SortedList();

                        PrintUtility printUtility = new PrintUtility();


                        foreach (clsOrderReport objOrderedItems in slOrderedItems.Values)
                        {
                            objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("''", "'");
                            objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("'", "''");

                            string keyValue = slOrderedItems.GetKey(keyIndex).ToString();
                            valueSplitter = keyValue.Split('-');

                            if (objOrderedItems.DrinkStatus == true) //To make all drink items consecutively
                            {
                                slDrinkItems.Add(slDrinkItems.Count, objOrderedItems);
                            }

                            else if ((categoryID != Convert.ToInt32("0" + valueSplitter[0].ToString())) && (Convert.ToInt32("0" + valueSplitter[0].ToString()) != 0)) //All the items except drinks.
                            {
                                categoryID = Convert.ToInt32("0" + valueSplitter[0].ToString());
                                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n"; //Add the separator.

                                /*serialBody += "\r\n" + objOrderedItems.Quantity.ToString() + "  ";
                                serialBody += CPrintMethods.GetFixedString(objOrderedItems.ItemName.ToString(), 29);
                                serialBody += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);*/

                                //Blocked by Salim
                                //serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                //objOrderedItems.ItemName.ToString(), objOrderedItems.Price.ToString("F02"));


                                //if (qty_length_with_twospace + objOrderedItems.ItemName.Length + objOrderedItems.Price.ToString().Length <= printlinelength)
                                //{
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + objOrderedItems.ItemName.ToString(),
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //}
                                //else
                                //{
                                //    // line 1
                                //    int itemname_firstline_length = printlinelength - 4 - 1 - objOrderedItems.Price.ToString().Length;
                                //    string itemname_first_part = objOrderedItems.ItemName.Substring(0, itemname_firstline_length);
                                //    string itemname_second_part = objOrderedItems.ItemName.Substring(itemname_firstline_length);
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + itemname_first_part,
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //    // line 2
                                //    serialBody += "\r\n   "
                                //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                //                                    " ");
                                //}

                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                                printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), paperSize - 10, objOrderedItems.Price.ToString("F02"), paperSize - 5), "");

                            }
                            else if (valueSplitter[0].ToString() == "0")
                            {
                                slMiscellaneousItems.Add(slMiscellaneousItems.Count, objOrderedItems);
                            }
                            else
                            {
                                /* serialBody += "\r\n" + objOrderedItems.Quantity.ToString() + "  ";
                                 serialBody += CPrintMethods.GetFixedString(objOrderedItems.ItemName.ToString(), 29);
                                 serialBody += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);*/
                                //Blocked by Salim
                                //serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                //objOrderedItems.ItemName.ToString(), objOrderedItems.Price.ToString("F02"));

                                //if (qty_length_with_twospace + objOrderedItems.ItemName.Length + objOrderedItems.Price.ToString().Length <= printlinelength)
                                //{
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + objOrderedItems.ItemName.ToString(),
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //}
                                //else
                                //{
                                //    // line 1
                                //    int itemname_firstline_length = printlinelength - 4 - 1 - objOrderedItems.Price.ToString().Length;
                                //    string itemname_first_part = objOrderedItems.ItemName.Substring(0, itemname_firstline_length);
                                //    string itemname_second_part = objOrderedItems.ItemName.Substring(itemname_firstline_length);
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + itemname_first_part,
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //    // line 2
                                //    serialBody += "\r\n   "
                                //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                //                                    " ");
                                //}



                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                               printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), paperSize - 10, objOrderedItems.Price.ToString("F02"), paperSize - 5), "");


                            }
                            keyIndex++;
                        }

                        //Add drinks only
                        if (slMiscellaneousItems.Count > 0)
                        {
                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous") + "\r\n";
                            foreach (clsOrderReport objOrderedItems in slMiscellaneousItems.Values)
                            {
                                objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("''", "'");
                                objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("'", "''");

                                /*  serialBody += "\r\n" + objOrderedItems.Quantity.ToString() + "  ";
                                  serialBody += CPrintMethods.GetFixedString(objOrderedItems.ItemName.ToString(), 29);
                                  serialBody += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);*/

                                //serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                //objOrderedItems.ItemName.ToString(), objOrderedItems.Price.ToString("F02"));


                                //if (qty_length_with_twospace + objOrderedItems.ItemName.Length + objOrderedItems.Price.ToString().Length <= printlinelength)
                                //{
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + objOrderedItems.ItemName.ToString(),
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //}
                                //else
                                //{
                                //    // line 1
                                //    int itemname_firstline_length = printlinelength - 4 - 1 - objOrderedItems.Price.ToString().Length;
                                //    string itemname_first_part = objOrderedItems.ItemName.Substring(0, itemname_firstline_length);
                                //    string itemname_second_part = objOrderedItems.ItemName.Substring(itemname_firstline_length);
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + itemname_first_part,
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //    // line 2
                                //    serialBody += "\r\n   "
                                //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                //                                    " ");
                                //}

                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                               printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), paperSize - 10, objOrderedItems.Price.ToString("F02"), paperSize - 5), "");

                            }
                        }


                        //Add drinks only
                        if (slDrinkItems.Count > 0)
                        {
                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n"; //Add the separator.
                            foreach (clsOrderReport objOrderedItems in slDrinkItems.Values)
                            {
                                objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("''", "'");
                                objOrderedItems.ItemName = objOrderedItems.ItemName.Replace("'", "''");

                                //serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  "+
                                //objOrderedItems.ItemName.ToString(),objOrderedItems.Price.ToString("F02"));


                                //if (qty_length_with_twospace + objOrderedItems.ItemName.Length + objOrderedItems.Price.ToString().Length <= printlinelength)
                                //{
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + objOrderedItems.ItemName.ToString(),
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //}
                                //else
                                //{
                                //    // line 1
                                //    int itemname_firstline_length = printlinelength - 4 - 1 - objOrderedItems.Price.ToString().Length;
                                //    string itemname_first_part = objOrderedItems.ItemName.Substring(0, itemname_firstline_length);
                                //    string itemname_second_part = objOrderedItems.ItemName.Substring(itemname_firstline_length);
                                //    serialBody += "\r\n"
                                //                                    + strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " + itemname_first_part,
                                //                                    " " + objOrderedItems.Price.ToString("F02"));
                                //    // line 2
                                //    serialBody += "\r\n   "
                                //                                    + strPrintFormatter.ItemLabeledText(itemname_second_part,
                                //                                    " ");
                                //}

                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                                            printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), paperSize - 10, objOrderedItems.Price.ToString("F02"), paperSize - 5), "");


                            }
                        }
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                    #endregion
                    }
                }
                #endregion

                #region "Online orders"
                else
                {
                    m_itemCost = 0.0;
                    serialBody += "\r\n-----------------------------";
                    for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                    {
                        DataRow tempRow = m_dtItemList.Rows[rowIndex];
                        serialBody += "\r\n" + strPrintFormatter.ItemLabeledText(Convert.ToInt32("0" + tempRow["Qty"]).ToString() + "  " +
                        tempRow["Item"].ToString(), Convert.ToDouble("0" + tempRow["Price"]).ToString("F02"));
                        m_itemCost += Convert.ToDouble("0" + tempRow["Price"].ToString()); //New for item cost of the bar service
                    }
                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                }
                #endregion


                Double discountAmount = Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length));
                Double searviceChargeAmount = Double.Parse(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                Double billTotal = ((searviceChargeAmount) + m_dTotalAmount);

                //serialBody += "\r\n                     Order Total: " + CPrintMethods.RightAlign(billTotal.ToString("F02"), 6);
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Order Amount: ", m_itemCost.ToString("F02")); //New at 03.03.2009
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                if (discountAmount > 0)
                {
                    Double totalAmount = m_dTotalAmount;
                    Double discountPercent = 100 * discountAmount / (m_itemCost);
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Discount(" + discountPercent.ToString("F02") + "%): ", Convert.ToDouble(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));
                }

                double itemiscount = 0;

                 COrderManager temmpOrderManager = new COrderManager();
          COrderDiscount tempOrderDiscount = new COrderDiscount();
          CResult oResult = temmpOrderManager.OrderDiscountGetByOrderID(m_iOrderID);
          if (oResult.IsSuccess && oResult.Data != null)
          {

              tempOrderDiscount = (COrderDiscount) oResult.Data;
              itemiscount = tempOrderDiscount.TotalItemDiscount;
          }


                if (itemiscount > 0)
                {

             
                    //Discount is based on the total item cost
                    //tempSerialPrintContent.StringLine = "                  Discount:(" + discountPercent.ToString("F02") + "%) " +Convert.ToDecimal(g_DiscountLabel.Text).ToString("F02");
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText(" Item Discount: ", itemiscount.ToString("F02"));

                    
                }



                serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Membership Discount: ", membershipdiscount.ToString("F02"));
               
                #region "Voucher"
                if (!g_VoucherLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Voucher Discount:", g_VoucherLabel.Text.Substring(Program.currency.Length));
                }
                #endregion


                if ((m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher) > 0) //If service charge is assigned
                {
                    CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(m_iOrderID);
                    ServiceCharge serviceCharge = cResult.Data as ServiceCharge;

                    double subtotalserviceCharg = m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher-tipsamount;
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge(" + serviceCharge.ServicechargeRate.ToString("F02") + "%): ", (subtotalserviceCharg).ToString("F02"));// + CPrintMethods.RightAlign(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02"), 6); // Change by Mithu
                }
                serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Tips Amount: ", tipsamount.ToString("F02"));
                double pvat = (billTotal * (vat / 100)) / (1 + (vat / 100));

                if (isVatEnabled) //If service charge is assigned
                {
                    // serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Vat(" + vat + "%): ", pvat.ToString("F02"));
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Vat Total(15%): ", Convert.ToDouble("0" + lblVat.Text.Substring(Program.currency.Length)).ToString("F02")); // Change by Mithu
                }

                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                double totalAmountForAddvance = 0;

                if ((m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher) > 0)
                {
                    totalAmountForAddvance = (m_dTotalAmount +
                                              (m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque +
                                               m_serviceCharge_eft + m_serviceCharge_voucher));
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Total: ", (m_dTotalAmount + (m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher)).ToString("F02"));
                }
                else
                {
                    totalAmountForAddvance = m_dTotalAmount;
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Total:", m_dTotalAmount.ToString("F02"));
                }
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody += "\r\nPayment:";

                if (!g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
                {

                    if (complementorylabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        serialBody += "\r\nReceived :" + "0.00";
                    }

                    else   serialBody += "\r\nReceived :" + g_InputTextBox.Text.Substring(Program.currency.Length);
                }
                if (!g_CashLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nCash:" + g_CashLabel.Text.Substring(Program.currency.Length);
                }
                if (!g_EFTLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nCard - " + EFTOptionForm.seletedEFTCard.CardName + " :" + g_EFTLabel.Text.Substring(Program.currency.Length);
                }
                if (!g_ChequeLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nDue:" + g_ChequeLabel.Text.Substring(Program.currency.Length);
                }

                if (!g_VoucherLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nVoucher:" + g_VoucherLabel.Text.Substring(Program.currency.Length);
                }

                if (!g_AccountLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nAccounts:" + g_AccountLabel.Text.Substring(Program.currency.Length);
                }

                if (!complementorylabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                {
                    serialBody += "\r\nComplementory:" + complementorylabel.Text.Substring(Program.currency.Length);
                }

                if (m_isAddServiceCharge == false)
                {
                    if (Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length)) > 0)
                    {
                        serialBody += "\r\nPay Back: " + g_BalaceLabel.Text.Substring(9 + Program.currency.Length) + "\n";
                    }
                }


                if(addvancecAmountCheckBox.Checked)
                {
                    serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Addvance Payment Information");
                    serialBody += "\r\nAddvance Amount:" +(Convert.ToDouble("0"+advanceAmountTextBox.Text.Trim()));
                    serialBody += "\r\nPaid Amount:" + (totalAmountForAddvance-(Convert.ToDouble("0" + advanceAmountTextBox.Text.Trim())));

                }

                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
            //    serialBody += "\r\nS/N: " + tempOrderInfo.SerialNo.ToString();
                if (Program.vatRegDes != "")
                {
                  serialBody += "\r\nVat Reg. No: " + Program.vatRegDes; // Change by Mithu
                }
                // serialBody += "\r\n\r\nDeveloped By: www.ibacs.co.uk";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();


                if(complementoryMessage!=null && complementoryMessage.Length!=0)
                {
                    serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Complementory Message");
                    serialBody += "\r\n" + GetMessageFitOnPaper(complementoryMessage);
                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                }

                if (dueMessage!=null && dueMessage.Length != 0)
                {
                    serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Due Message");
                    serialBody += "\r\n" + GetMessageFitOnPaper(dueMessage);
                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                }



                this.WriteString(serialBody);
                gusetBillStr = serialBody;
                //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                tempPrintMethods.USBPrint(serialBody, PrintDestiNation.CLIENT, true);
            }
        }

        private string GetMessageFitOnPaper(string message)
        {

            string res="";
            int cnt = 1;
            for (int i = 0; i < message.Length;i++ )
            {
                if (cnt % 37 == 0) res += "\r\n";
                res += message[i];
                cnt++;

            }
            return res;
        }

        private void LoadPrintOffButton()
        {
            try
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Print_Config.xml");
                if (tempDataSet.Tables[0].Rows[0]["PrintPaymentBill"].ToString().ToLower().Equals("true"))
                {
                    g_PrintOffButton.Text = "Printing On";
                }
                else
                {
                    g_PrintOffButton.Text = "Printing Off";
                }
            }
            catch (Exception ee)
            {
            }
        }
        private void LoadStatusBar(Int64 inOrderID)
        {
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            UserStatusLabel.Text = " Logged in as " + oConstants.UserInfo.UserName + " ";

            COrderManager oOrderManager = new COrderManager();
            COrderInfo oOrderInfo = new COrderInfo();
            CResult oResult = oOrderManager.OrderInfoByOrderID(inOrderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderInfo = (COrderInfo)oResult.Data;
            }

            if (oOrderInfo.OrderType.Equals("Table"))
            {
                TableStatusLabel.Text = " Table No. " + oOrderInfo.TableNumber + " ";
                GuestStatusLabel.Text = " Covers - " + oOrderInfo.GuestCount + " ";
                GuestStatusLabel.Visible = true;
            }
            else if (oOrderInfo.OrderType.Equals("TakeAway"))
            {
                TableStatusLabel.Text = " Take Away ";
                GuestStatusLabel.Visible = false;
            }
            else if (oOrderInfo.OrderType.Equals("Tabs"))
            {
                TableStatusLabel.Text = " Tab No. " + oOrderInfo.TableNumber + " ";
                GuestStatusLabel.Text = " Covers - " + oOrderInfo.GuestCount + " ";
                GuestStatusLabel.Visible = true;
            }

            BillNoStatusLabel.Text = " Reference No. " + oOrderInfo.SerialNo.ToString() + " ";
        }


        /// <summary>
        /// This function checks whether the actual amount of charge i.e without the service charge is completed or not
        /// </summary>
        /// <returns></returns>
        private bool IsFinishedActualAmount()
        {
            bool blnIsFinished = false;
            Double tempTotalPaid = 0.0;
            tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                 + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

            double tobePaid = Convert.ToDouble(g_BillTotalLabel.Text.Substring(Program.currency.Length));//Total payment without service charge

            if (tobePaid <= tempTotalPaid)//If actual amount is exceeded then initialize the service  charge.
            {
                blnIsFinished = true;
            }
            return blnIsFinished;
        }


        private void UpdateCalculation(int paymentMethodIndex)
        {

            try
                {
                Double tempTotalPaid = 0.0;

                Debug.WriteLine("UpdateCalc 1");
                tempTotalPaid += Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(complementorylabel.Text.Substring(Program.currency.Length));

                Debug.WriteLine("UpdateCalc 2");
                Double tempBillTotal = m_dTotalAmount + Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                Debug.WriteLine("UpdateCalc 3");
                Double tempDifference = tempBillTotal - tempTotalPaid;
                Debug.WriteLine("UpdateCalc 4");
                if (tempDifference > 0)
                {
                    m_dBalance = tempDifference;
                    g_BalaceLabel.Text = String.Format("Balance Due {0}" + m_dBalance.ToString("F02"), Program.currency);
                    Debug.WriteLine("UpdateCalc 5");
                }
                else
                {
                    if (CurrentPaymentMethod.Equals("Cash"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            g_CashLabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }
                    else if (CurrentPaymentMethod.Equals("EFT"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            g_EFTLabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }
                    else if (CurrentPaymentMethod.Equals("Due"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            g_ChequeLabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }
                    else if (CurrentPaymentMethod.Equals("Voucher"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            g_VoucherLabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }
                    else if (CurrentPaymentMethod.Equals("Account"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            g_AccountLabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }
                    else if (CurrentPaymentMethod.Equals("Discount"))
                    {
                        g_DiscountLabel.Text = Program.currency + m_dBalance.ToString("F02");
                    }
                    else if (CurrentPaymentMethod.Equals("Deposit"))
                    {
                        g_DepositUsedLabel.Text = Program.currency + m_dBalance.ToString("F02");
                    }

                    else if (CurrentPaymentMethod.Equals("Complementory"))
                    {
                        if (m_isAddServiceCharge == false)
                        {
                            complementorylabel.Text = Program.currency + m_dBalance.ToString("F02");
                        }
                    }

                    Debug.WriteLine("UpdateCalc 6");
                    m_dBalance = -tempDifference;


                    g_BalaceLabel.Text = "Pay Back " + Program.currency + (m_dBalance-tipsamount).ToString("F02");

                    Debug.WriteLine("UpdateCalc 7");
                    CPaymentManager tempPaymentManager = new CPaymentManager();


                    /***********************/
                    /********New Print******/
                    /***********************/

                    if (isCheatManuallyhandled())
                    {
                        DialogResult dresult = MessageBox.Show("Make It Open?", "Message", MessageBoxButtons.YesNo);

                        if (dresult == DialogResult.Yes)
                        {
                            makeOpen = true;
                        }
                        if (dresult == DialogResult.No)
                        {
                            makeOpen = false;
                        }
                    }

                    DataSet tempDataSet = new DataSet();
                    tempDataSet.ReadXml("Config/Print_Config.xml");
                    if (tempDataSet.Tables[0].Rows[0]["PrintPaymentBill"].ToString().ToLower().Equals("true"))
                    {
                        Debug.WriteLine("UpdateCalc 17");
                        PrintPaymentBill(paymentMethodIndex);//Payment method index .Cash=1,EFT=2,Cheque=3
                    }



                    COrderManager temmpOrderManager = new COrderManager();
          COrderDiscount tempOrderDiscount = new COrderDiscount();
          CResult ooResult = temmpOrderManager.OrderDiscountGetByOrderID(m_iOrderID);
                    double itemDiscount = 0;
          if (ooResult.IsSuccess && ooResult.Data != null)
          {

              tempOrderDiscount = (COrderDiscount) ooResult.Data;
              itemDiscount = tempOrderDiscount.TotalItemDiscount;
          }

                    //Check whether payment data exists
                    if (m_cPayment == null)
                    {
                        Debug.WriteLine("UpdateCalc 8");
                        ///insert into payment table
                        CPayment tempPayment = new CPayment();
                        tempPayment.OrderID = m_iOrderID;

                        //get pc id from pc ip
                        CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                        IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());

                        CPcInfo tempPcInfo = (CPcInfo)tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString()).Data;

                        tempPayment.PcID = tempPcInfo.PcID;
                        Debug.WriteLine("UpdateCalc 9");
                        tempPayment.TotalAmount = m_dTotalAmount;
                        tempPayment.CashAmount = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length));
                        tempPayment.EFTAmount = Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length));
                        tempPayment.ChequeAmount = Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length));
                        tempPayment.ServiceAmount = m_serviceCharge_cash + m_serviceCharge_voucher + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_accounts - tipsamount;  //Double.Parse(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                        tempPayment.VoucherAmount = Double.Parse(complementorylabel.Text.Substring(Program.currency.Length));
                        tempPayment.Discount = Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length));
                        tempPayment.AccountPay = Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length));
                        tempPayment.DepositID = m_oDeposit.DepositID;
                        tempPayment.DepositAmount = Double.Parse(g_DepositUsedLabel.Text.Substring(Program.currency.Length));
                        tempPayment.PaymentTime = System.DateTime.Now;

                        tempPayment.ServiceChargeCash = m_serviceCharge_cash;
                        tempPayment.ServiceChargeCheque = m_serviceCharge_cheque;
                        tempPayment.ServiceChargeEft = m_serviceCharge_eft;
                        tempPayment.ServiceChargeVoucher = m_serviceCharge_voucher;
                        tempPayment.ServiceChargeAcc = m_serviceCharge_accounts;

                        tempPayment.DueMessage = dueMessage;
                        tempPayment.ComplementoryMessage = complementoryMessage;


                        double totalCost = GetTotalCost(m_iOrderID);
                        tempPayment.TotalCost = totalCost;
                        tempPayment.TipsAmount = tipsamount;
                        
                        tempPayment.VatImposed = Program.vat.ToString();

                        tempPayment.membershipDiscount = (double)membershipdiscount;
                        tempPayment.ItemDiscount = itemDiscount;

                        //tempPayment.VatImposed = Program.vat.ToString();
                        tempPayment.GuestBill = gusetBillStr;
                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao(); // Change by Mithu
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(m_iOrderID); // Change by Mithu

                        try
                        {
                            tempPayment.Waiter = orderWaiter.WaiterName;
                        }
                        catch (Exception)
                        {
                            
                            
                        }
                       


                        if (makeOpen)
                            tempPayment.Vat_stat = true;
                        else
                            tempPayment.Vat_stat = false;

                        tempPayment.PaymentPerson = RMSGlobal.LoginUserName;


                        DataSet tempStockDataSet = new DataSet();
                        tempStockDataSet.ReadXml("Config/StockSetting.xml");
                        bool isAllowedToOrder = Convert.ToBoolean(tempStockDataSet.Tables[0].Rows[0]["AllowedtoOrder"].ToString());
                        if (!isAllowedToOrder)
                        {
                            COrderDetailsDAO aDao = new COrderDetailsDAO();
                            List<COrderDetails> aList = new List<COrderDetails>();
                            double cost = 0.0;
                            try
                            {
                                aList = aDao.OrderDetailsGetAll();
                                var check = from list in aList where list.OrderID == tempPayment.OrderID select list;
                                SaleReportDAO aSaleReportDao = new SaleReportDAO();
                                aSaleReportDao.InsertOrUpdateSaleRawmaterialsReport(check);
                            }
                            catch
                            {
                            }

                        }




                        CResult oResult = tempPaymentManager.InsertPayment(tempPayment);
                        if (oResult.IsSuccess && oResult.Data != null)
                        {
                            tempPayment = (CPayment)oResult.Data;
                            m_cPayment = tempPayment;
                            Debug.WriteLine("UpdateCalc 10");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("UpdateCalc 11");
                        //update payment table
                        CPayment tempPayment = new CPayment();
                        tempPayment.PaymentID = m_cPayment.PaymentID;
                        tempPayment.OrderID = m_iOrderID;

                        tempPayment.TotalAmount = m_dTotalAmount;
                        tempPayment.CashAmount = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length));
                        tempPayment.EFTAmount = Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length));
                        tempPayment.ChequeAmount = Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length));
                        tempPayment.ServiceAmount = m_serviceCharge_cash + m_serviceCharge_voucher + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_accounts - tipsamount;  //Double.Parse(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                        tempPayment.VoucherAmount = Double.Parse(complementorylabel.Text.Substring(Program.currency.Length));
                        tempPayment.Discount = Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length));
                        tempPayment.AccountPay = Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length));
                        tempPayment.DepositID = m_oDeposit.DepositID;
                        tempPayment.DepositAmount = Double.Parse(g_DepositUsedLabel.Text.Substring(Program.currency.Length));
                        tempPayment.PaymentTime = System.DateTime.Now;

                        tempPayment.ServiceChargeCash = m_serviceCharge_cash;
                        tempPayment.ServiceChargeCheque = m_serviceCharge_cheque;
                        tempPayment.ServiceChargeEft = m_serviceCharge_eft;
                        tempPayment.ServiceChargeVoucher = m_serviceCharge_voucher;
                        tempPayment.ServiceChargeAcc = m_serviceCharge_accounts;
                        tempPayment.VatImposed = Program.vat.ToString();
                        tempPayment.TipsAmount = tipsamount;
                        tempPayment.GuestBill = gusetBillStr;
                        tempPayment.membershipDiscount = (double)membershipdiscount;
                        tempPayment.ItemDiscount = itemDiscount;
                        //tempPayment.DueMessage = dueMessage;
                        //tempPayment.ComplementoryMessage = complementoryMessage;

                        if (isCheatManuallyhandled())
                        {
                            DialogResult dresult = MessageBox.Show("Make It Open?", "Message", MessageBoxButtons.YesNo);

                            if (dresult == DialogResult.Yes)
                            {
                                makeOpen = true;
                            }
                            if (dresult == DialogResult.No)
                            {
                                makeOpen = false;
                            }
                        }


                        if (makeOpen)
                            tempPayment.Vat_stat = true;
                        else
                            tempPayment.Vat_stat = false;
                        tempPayment.PaymentPerson = RMSGlobal.LoginUserName;

                        tempPaymentManager.UpdatePayment(tempPayment);
                        m_cPayment = tempPayment;
                        Debug.WriteLine("UpdateCalc 12");
                    }

                    //Update Deposit
                    CDepositManager tempDepositManager = new CDepositManager();
                    tempDepositManager.UpdateDeposit(m_oDeposit);

                    //opening cash drawer
                    try
                    {
                        CPrintMethods tempPrintMethods = new CPrintMethods();
                        tempPrintMethods.OpenDrawer();

                        #region "Tracking Area"
                        CCommonConstants m_oCommonConstants;
                        //Drawer Opening log
                        DateTime dtPayment = DateTime.Now;
                        dtPayment = new DateTime(dtPayment.Year, dtPayment.Month, dtPayment.Day, dtPayment.Hour, dtPayment.Minute, dtPayment.Second);
                        Int64 dateTime = dtPayment.Ticks;
                        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                        CUserInfo objUserInfo = m_oCommonConstants.UserInfo;
                        tempPaymentManager.SaveDrawerLogs(RMSGlobal.Terminal_Id, objUserInfo.UserName, dateTime);
                        #endregion

                        Debug.WriteLine("UpdateCalc 18");
                    }
                    catch (Exception eee)
                    {
                        Debug.WriteLine("UpdateCalc 19");
                        Debug.WriteLine(eee.ToString());
                    }

                    ///Print Payment Bill
                    ///
                    /*  DataSet tempDataSet = new DataSet();
                      tempDataSet.ReadXml("Config/Print_Config.xml");
                      if (tempDataSet.Tables[0].Rows[0]["PrintPaymentBill"].ToString().ToLower().Equals("true"))
                      {
                          Debug.WriteLine("UpdateCalc 17");
                          PrintPaymentBill(paymentMethodIndex);//Payment method index .Cash=1,EFT=2,Cheque=3
                      }
  */

                    COrderManager tempOrderManager = new COrderManager();
                    COrderInfo tempOrderInfo = null;

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper()) //If local orders are processed
                    {
                        tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);
                        Debug.WriteLine("UpdateCalc 13");
                        tempOrderManager.InsertOrderArchive(tempOrderInfo);
                        Debug.WriteLine("UpdateCalc 14");
                        tempOrderManager.InsertOrderDetailsArchive(tempOrderInfo);
                        Debug.WriteLine("UpdateCalc 15");
                    }
                    else //If online orders are processed
                    {
                        tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;
                        tempOrderManager.InsertOnlineOrderArchive(tempOrderInfo);
                        Debug.WriteLine("Online orders archiving");
                    }

                    tempOrderManager.DeleteTableInfo(tempOrderInfo.TableNumber, m_sTableType);
                    Debug.WriteLine("UpdateCalc 16");

                    //insert voucher
                    tempOrderManager.InsertOrderVoucher(m_oOrderVoucher);

                    ///back to main screen 
                    ///

                    CFormManager.Forms.Pop();
                    Form tempForm = CFormManager.Forms.Pop();
                    tempForm.Show();
                    this.Close();
                }
                g_BalaceLabel.ForeColor = Color.Red;
            }
            catch (Exception eee)
            {
                //MessageBox.Show(eee.ToString());
                Debug.WriteLine("UpdateCalc catch");
                Debug.WriteLine(eee.ToString());
            }
        }

        private double GetTotalCost(long mIOrderId)
        {
           COrderDetailsDAO aDetailsDao=new COrderDetailsDAO();
           List<COrderDetails> aDetailses=new List<COrderDetails>();
           aDetailses = (List<COrderDetails>)aDetailsDao.OrderDetailsGetByOrderID(mIOrderId).Data;
            CCategory3DAO aCCategory3Dao=new CCategory3DAO();
            List<CCategory3> aCCategory3s=new List<CCategory3>();
            aCCategory3s = aCCategory3Dao.GetAllCategory3();
            double totalcost = 0;
            foreach (COrderDetails order in aDetailses)
            {
                foreach (CCategory3 category3 in aCCategory3s)
                {
                    if(category3.Category3ID==order.ProductID)
                    {
                        totalcost += (category3.TableCost*order.OrderQuantity);
                    }
                }
            }
            return totalcost;
        }

        private void SetNumber(int inDigit)
        {
            if (g_InputTextBox.Text.Length > 15)
                return;
            Double tempInput = Double.Parse(g_InputTextBox.Text.Substring(Program.currency.Length));
            g_InputTextBox.Text = Program.currency + ((Double)(tempInput * 10 + inDigit * 0.01)).ToString("F02");
        }

        private Int32 GetCategory1OrderNumber(Int32 p_categoryID)
        {
            Int32 category1OrderNumber = 0;
            DataRow[] dtRow = Program.initDataSet.Tables["Category1"].Select("cat1_id = " + p_categoryID);
            if (dtRow.Length > 0)
            {
                category1OrderNumber = Convert.ToInt32("0" + dtRow[0]["Cat1_order_number"]);
            }
            return category1OrderNumber;
        }

        #endregion

        #region "UI Events"

        private void g_CancelButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }



        private void g_ClearButton_Click(object sender, EventArgs e)
        {
            g_InputTextBox.Text = Program.currency + "0.00";
        }

        private void g_CashButton_Click(object sender, EventArgs e)
        {

            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            double Total = Double.Parse(g_InputTextBox.Text.Substring(Program.currency.Length));
            if (m_dTotalAmount > Total)
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Your enter amount less than total amount.Click 'No' and click 'Clear' button");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            if (g_CashButton == g_CashButton)
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Do you want to pament in the cash? If click on 'No' button then click on 'Clear' button");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            g_CashLabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "Cash";

            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                       + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                        
                    }
                    m_serviceCharge_cash = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                double payBackArray = Convert.ToDouble(g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                if (Convert.ToDouble("0" + payBackArray) > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }

                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_cash = m_serviceCharge_cash + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        if (m_serviceCharge_cash < 0)
                        {
                            m_serviceCharge_cash = 0;
                        }
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion

            if (m_serviceCharge_cash < 0)
            {
                m_serviceCharge_cash = 0;
            }



            this.UpdateCalculation(1);
            g_InputTextBox.Text = Program.currency + "0.00";
            g_CashButton.Enabled = false;
        }

        private void g_EFTButton_Click(object sender, EventArgs e)
        {




            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            if (g_EFTButton == g_EFTButton)
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Do you want to pament in the card? If click on 'No' button then click on 'Clear' button");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            /*************/


            EFTOptionForm eFTOptionForm = new EFTOptionForm();

            DialogResult dr = eFTOptionForm.ShowDialog();

            if (dr == DialogResult.Cancel)
                return;

            saveEFTCardAgainsOrderid(EFTOptionForm.seletedEFTCard);


            /*********************/
            g_EFTLabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "EFT";

            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                //double tobePaid = Convert.ToDouble(g_BillTotalLabel.Text.Substring(Program.currency.Length));//Total payment without service charge

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                    }
                    m_serviceCharge_eft = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;

                    if (m_serviceCharge_eft < 0)
                    {
                        m_serviceCharge_eft = 0;
                    }
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                // string[] payBackArray = g_BalaceLabel.Text.Split();
                double balance = Convert.ToDouble(g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                if (balance > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }
                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_eft = m_serviceCharge_eft + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion

            if (m_serviceCharge_eft < 0)
            {
                m_serviceCharge_eft = 0;
            }




            UpdateCalculation(2);
            g_InputTextBox.Text = Program.currency + "0.00";
            g_EFTButton.Enabled = false;
            btnAlterEftCard.Enabled = true;
            btnAlterEftCard.Text = "'" + EFTOptionForm.seletedEFTCard.CardName + "' is chosen. Click to alter the Card Name.";
        }

        private void g_ChequeButton_Click(object sender, EventArgs e)
        {
            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            g_ChequeLabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "Due";

            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                    }
                    m_serviceCharge_cheque = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                double payBackArray = Convert.ToDouble(g_BalaceLabel.Text.Substring(9+Program.currency.Length));
                if (Convert.ToDouble("0" + payBackArray) > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }
                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_cheque = m_serviceCharge_cheque + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion
            if (m_serviceCharge_cheque < 0)
            {
                m_serviceCharge_cheque = 0;
            }

            UpdateCalculation(3);
            g_InputTextBox.Text = Program.currency.Length + "0.00";
            g_ChequeButton.Enabled = false;
        }

        private void g_VoucherButton_Click(object sender, EventArgs e)
        {
            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            //CCalculatorForm tempCalculatorForm = new CCalculatorForm("Voucher Number", "Enter Voucher Number");
            //tempCalculatorForm.ShowDialog();

            //if (CCalculatorForm.inputResult.Equals("Cancel"))
            //    return;


            Double voucherAmount = 0;
            Double.TryParse(g_InputTextBox.Text.Substring(Program.currency.Length), out voucherAmount);
            if (voucherAmount > m_dBalance)
            {
                m_dTotalAmount = m_dTotalAmount - m_dBalance;
                g_VoucherLabel.Text = Program.currency + m_dBalance.ToString("F02");
            }
            else
            {
                m_dTotalAmount = m_dTotalAmount - voucherAmount;
                g_VoucherLabel.Text = g_InputTextBox.Text;
            }

            g_BillTotalLabel.Text = Program.currency + m_dTotalAmount.ToString("F02");

            //insert order voucher
            m_oOrderVoucher = new COrderVoucher();
           // m_oOrderVoucher.VoucherID = Int64.Parse(CCalculatorForm.inputResult);
            m_oOrderVoucher.OrderID = m_iOrderID;
            m_oOrderVoucher.VoucherAmount = Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

            CurrentPaymentMethod = "Voucher";


            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                double tobePaid = Convert.ToDouble(g_BillTotalLabel.Text.Substring(Program.currency.Length));//Total payment without service charge

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                    }
                    m_serviceCharge_voucher = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;
                    if (m_serviceCharge_voucher < 0)
                    {
                        m_serviceCharge_voucher = 0;
                    }
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                double payBackAmount = Convert.ToDouble(g_BalaceLabel.Text.Substring(9+Program.currency.Length));
                if (Convert.ToDouble("0" + payBackAmount) > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }

                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_voucher = m_serviceCharge_voucher + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion

            if (m_serviceCharge_voucher < 0)
            {
                m_serviceCharge_voucher = 0;
            }

            UpdateCalculation(4);
            g_InputTextBox.Text = Program.currency + "0.00";
            g_VoucherButton.Enabled = false;
        }

        private void g_DiscountButton_Click(object sender, EventArgs e)
        {
            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            g_DiscountLabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "Discount";
            UpdateCalculation(0);
            g_InputTextBox.Text = Program.currency + "0.00";
            g_DiscountButton.Enabled = false;
        }

        private void g_AccountButton_Click(object sender, EventArgs e)
        {
            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            g_AccountLabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "Account";

            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));
                double tobePaid = Convert.ToDouble(g_BillTotalLabel.Text.Substring(Program.currency.Length));//Total payment without service charge

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                    }
                    m_serviceCharge_accounts = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                string[] payBackArray = g_BalaceLabel.Text.Split('£');
                if (Convert.ToDouble("0" + payBackArray[1]) > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }

                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_accounts = m_serviceCharge_accounts + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion

            if (m_serviceCharge_accounts < 0)
            {
                m_serviceCharge_accounts = 0;
            }

            UpdateCalculation(0);
            g_InputTextBox.Text = Program.currency + "0.00";
            g_AccountButton.Enabled = false;
        }

        private void g_InputTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double tempDifference = m_dBalance - Double.Parse(g_InputTextBox.Text.Substring(Program.currency.Length));

                if (tempDifference > 0)
                {
                    g_BalaceLabel.Text = "Balance Due " + Program.currency + tempDifference.ToString("F02");
                }
                else
                {
                    tempDifference = -tempDifference;
                    g_BalaceLabel.Text = "Pay Back " + Program.currency + tempDifference.ToString("F02");
                }
            }
            catch { }
        }

        private void g_SplitByItemtButton_Click(object sender, EventArgs e)
        {
            CSplitByItemForm tempSplitByItemForm = new CSplitByItemForm(m_iOrderID, m_dTotalAmount, Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length)), m_sTableType, m_dtItemList, Double.Parse(g_ServiceChargeLabel.Text.Substring(Program.currency.Length)), Double.Parse(lblVat.Text.Substring(Program.currency.Length)));
            tempSplitByItemForm.ShowDialog();
        }

        private void g_EqualSplitButton_Click(object sender, EventArgs e)
        {
            /* Double splitAmount = (m_dTotalAmount / 2);
             g_SplitAmountLabel.Text = "Split Amount " + Program.currency + splitAmount.ToString("F02");
             g_SplitAmountLabel.Show();
             m_bEqualSplit = true;
             */

            Double totalpayable = Double.Parse(g_BillTotalLabel.Text.Substring(Program.currency.Length));
            Double totalvat = Double.Parse(lblVat.Text.Substring(Program.currency.Length));
            CMultipleSplitForm MultipleSplitForm = new CMultipleSplitForm(m_iOrderID, totalpayable, m_dServiceAmount, Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length)), totalvat, m_sTableType, m_dtItemList, m_OperatorName, m_TerminalName);
            MultipleSplitForm.ShowDialog();

        }

        /***************************Print Guest Bill*********************/

        private void g_PrintGuestBillButton_Click(object sender, EventArgs e)
        {

            bool isPrintA5GuestBill = false;
            if (isPrintA5GuestBill)
            {
                PrintA5GuestBillReport(1);
            }
            else
            {

                StringPrintFormater strPrintFormatter = new StringPrintFormater(37);

                int printsize = 37;

                Hashtable htOrderedItems = new Hashtable();
                SortedList slOrderedItems = null;
                string cat1ID = String.Empty;

                try
                {
                    CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                    //string serialHeader = "IBACS RMS";
                    string serialHeader = "";
                    //string serialFooter = "Please Come Again";
                    string serialFooter = "";

                    string serialBody = "";

                    //serialBody += "\r\n               Guest Bill";
                    serialBody += strPrintFormatter.CenterTextWithWhiteSpace("Bill  Payment");

                    COrderManager tempOrderManager = new COrderManager();
                    COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;


                    if (m_sTableType.Equals("Table"))
                    {
                        serialBody += "\r\n\nTable Number:" + tempOrderInfo.TableNumber.ToString();
                        serialBody += "\r\n\nCovers:" + tempOrderInfo.GuestCount.ToString();
                        serialBody += "\r\nDate: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");


                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(m_iOrderID);
                                              
                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName + "\r\n";
                        }

                    }
                    else if (m_sTableType.Equals("TakeAway"))
                    {
                        serialBody += "\r\n\nTake Away" + "      Date: " + System.DateTime.Now.ToString("dd/MM/yy");
                        CCustomerManager tempCustomerManager = new CCustomerManager();
                        CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;


                        COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                        COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(m_iOrderID);

                        if (orderWaiter != null && orderWaiter.WaiterID > 0)
                        {
                            serialBody += "\r\nWaiter Name: " + orderWaiter.WaiterName + "\r\n";
                        }


                        if (tempCustomerInfo.CustomerName.Length > 0)
                        {
                            serialBody += "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                        }
                        if (tempCustomerInfo.CustomerPhone.Length > 0)
                        {
                            serialBody += "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                        }

                        serialBody += "\r\nType: " + tempOrderInfo.Status;
                        if (tempOrderInfo.Status.Equals("Delivery"))
                        {
                            serialBody += "\r\nAddress:";
                            //serialBody += "\r\n----------------------------------------";
                            serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();


                            if (tempCustomerInfo.FloorAptNumber.Length > 0)
                            {
                                serialBody += "\r\nFloor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                            }

                            if (tempCustomerInfo.BuildingName.Length > 0)
                            {
                                serialBody += "\r\nBuilding Name:" + tempCustomerInfo.BuildingName;
                            }

                            if (tempCustomerInfo.HouseNumber.Length > 0)
                            {
                                serialBody += "\r\nHouse Number:" + tempCustomerInfo.HouseNumber;
                            }

                            string[] street = new string[0];
                            street = tempCustomerInfo.StreetName.Split('-');

                            if (street.Length > 1)
                            {
                                if (street[0].ToString().Length > 0)
                                {
                                    serialBody += "\r\nStreet:" + street[0].ToString();
                                }
                                if (street[1].ToString().Length > 0)
                                {
                                    serialBody += "\r\n" + street[1].ToString();
                                }
                            }
                            else if (street.Length > 0 && street.Length < 2)
                            {
                                if (street[0].ToString().Length > 0)
                                {
                                    serialBody += "\r\nStreet:" + street[0].ToString();
                                }
                            }
                            if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                            {
                                serialBody += "\r\nPostal Code:" + tempCustomerInfo.CustomerPostalCode;
                            }
                            if (tempCustomerInfo.CustomerTown.Length > 0)
                            {
                                serialBody += "\r\nTown:" + tempCustomerInfo.CustomerTown;
                            }
                            //serialBody += "\r\n----------------------------------------";
                            serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                            CDelivery objDelivery = new CDelivery();
                            objDelivery.DeliveryOrderID = m_iOrderID;
                            CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                            objDelivery = (CDelivery)objDeliveryInfo.Data;
                            serialBody += "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                        }
                    }
                    else if (m_sTableType.Equals("Tabs"))
                    {
                        serialBody += "\r\n\nBar Service" + "      Date: " + System.DateTime.Now.ToString("dd/MM/yy");
                        if (tempOrderInfo.TableNumber != 0)
                        {
                            serialBody += "\r\nTab Number: " + tempOrderInfo.TableNumber.ToString();
                            serialBody += "\r\nGuest Number: " + tempOrderInfo.GuestCount.ToString();
                        }
                    }


                    serialBody += "\r\n\nOrder Information";
                    serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");


                    #region "Local Orders"

                    if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        string cat2ID = "";
                        string cat3ID = "";
                        Int32 internalCategoryID = 0;
                        Int32 categoryID = 0;
                        m_itemCost = 0.0;

                        string categoryOrder = String.Empty;

                        for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                        {
                            #region "Parent Category"
                            DataRow tempRow = m_dtItemList.Rows[rowIndex];
                            categoryOrder = String.Empty;
                            if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 3)//Item from Category 3
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }

                            else if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 0) //If miscellenious items are added
                            {
                                cat1ID = "0";
                                cat2ID = "0";
                            }

                            else
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat3ID = dtRow[0]["cat3_id"].ToString();
                                    if (cat3ID != "" || cat3ID != null)
                                    {
                                        dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                    }
                                    else
                                    {
                                        dtRow = null;
                                    }
                                }

                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }
                            #endregion


                            clsOrderReport objOrderedReport = new clsOrderReport();
                            objOrderedReport.Quantity = Convert.ToInt32("0" + tempRow["Qty"].ToString());
                            objOrderedReport.ItemName = tempRow["Item"].ToString();
                            objOrderedReport.Price = Convert.ToDouble("0" + tempRow["Price"].ToString());
                            int drinkValue = Convert.ToInt32("0" + tempRow["isdrink"].ToString());
                            if (drinkValue > 0)
                            {
                                objOrderedReport.DrinkStatus = true;
                            }
                            else
                            {
                                objOrderedReport.DrinkStatus = false;
                            }

                            Int64 rankNumber = Int64.Parse(tempRow["rank"].ToString());
                            Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                            htOrderedItems.Add(category1OrderNumber + "-" + rankNumber + "-" + objOrderedReport.ItemName, objOrderedReport);

                            m_itemCost += Convert.ToDouble("0" + tempRow["Price"].ToString());
                        }

                        NumericComparer nc = new NumericComparer();
                        slOrderedItems = new SortedList(htOrderedItems, nc);
                        int keyIndex = 0;
                        string[] valueSplitter = new string[0];
                        SortedList slDrinkItems = new SortedList();
                        SortedList slMiscellaneousItems = new SortedList();

                        PrintUtility printUtility = new PrintUtility();

                        foreach (clsOrderReport objOrderedItems in slOrderedItems.Values)
                        {
                            string keyValue = slOrderedItems.GetKey(keyIndex).ToString();
                            valueSplitter = keyValue.Split('-');

                            if (objOrderedItems.DrinkStatus == true) //To make all drink items consecutively
                            {
                                slDrinkItems.Add(slDrinkItems.Count, objOrderedItems);
                            }

                            else if ((categoryID != Convert.ToInt32("0" + valueSplitter[0].ToString())) && (Convert.ToInt32("0" + valueSplitter[0].ToString()) != 0)) //All the items except drinks.
                            {
                                categoryID = Convert.ToInt32("0" + valueSplitter[0].ToString());
                                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n"; //Add the separator.
                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                            printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), printsize - 7, objOrderedItems.Price.ToString("F02"), printsize - 3), "");
                            }
                            else if (valueSplitter[0].ToString() == "0")
                            {
                                slMiscellaneousItems.Add(slMiscellaneousItems.Count, objOrderedItems);//add miscellaneous items in the collection
                            }
                            else
                            {
                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), printsize - 10, objOrderedItems.Price.ToString("F02"), printsize - 5), "");
                            }
                            keyIndex++;
                        }

                        //Add miscellaneous items only
                        if (slMiscellaneousItems.Count > 0)
                        {
                            //serialBody += "\r\n--------------Miscellaneous-------------"; //Add the separator.

                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous");
                            serialBody += "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n";
                            foreach (clsOrderReport objOrderedItems in slMiscellaneousItems.Values)
                            {
                                /* serialBody += "\r\n" + objOrderedItems.Quantity.ToString() + "  ";
                                 serialBody += CPrintMethods.GetFixedString(objOrderedItems.ItemName.ToString(), 23);
                                 serialBody += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);*/

                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                                printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), printsize - 10, objOrderedItems.Price.ToString("F02"), printsize - 5), "");
                            }
                        }


                        //Add drinks only
                        if (slDrinkItems.Count > 0)
                        {
                            // serialBody += "\r\n-----------------Drinks-----------------"; //Add the separator.
                            serialBody += "\r\n" + strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n";
                            foreach (clsOrderReport objOrderedItems in slDrinkItems.Values)
                            {
                                /*serialBody += "\r\n" + objOrderedItems.Quantity.ToString() + "  ";
                                 serialBody += CPrintMethods.GetFixedString(objOrderedItems.ItemName.ToString(), 23);
                                 serialBody += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);*/

                                serialBody += strPrintFormatter.ItemLabeledText(objOrderedItems.Quantity.ToString() + "  " +
                               printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), printsize - 10, objOrderedItems.Price.ToString("F02"), printsize - 5), "");
                            }
                        }

                        //serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                        Double discountAmount = Convert.ToDouble(Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));
                        //Double billTotal = (discountAmount + m_dTotalAmount);
                        //serialBody += "\r\n                     Order Total: " + CPrintMethods.RightAlign(billTotal.ToString("F02"), 6);

                        //serialBody += "\r\n                     Order Total: " + CPrintMethods.RightAlign(m_itemCost.ToString("F02"), 6);//Item cost of the ordered products
                        serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Order Total: ", m_itemCost.ToString("F02"));
                        //if (discountAmount > 0)
                        //{
                        //    Double totalAmount = m_dTotalAmount;
                        //    Double discountPercent = 100 * discountAmount / (discountAmount + totalAmount);
                        //    serialBody += "\r\n                 Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(g_DiscountLabel.Text.Substring(Program.currency.Length), 6);
                        //}

                        if (discountAmount > 0)
                        {
                            Double totalAmount = m_dTotalAmount;
                            Double discountPercent = 100 * discountAmount / (m_itemCost); //Discount percentage of the selected products
                            // serialBody += "\r\n                Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(Convert.ToDouble(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"), 6);
                            serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Discount:(" + discountPercent.ToString("F02") + "%) ", Convert.ToDouble(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));
                        }


                        if (Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)) > 0) //If service charge is assigned
                        {
                            string tempstring = Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02");

                            serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge: ", tempstring);

                        }

                        //double payableAmount = Convert.ToDouble(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02")) + m_dTotalAmount;
                        double payableAmount = Convert.ToDouble(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02")) + (m_itemCost - discountAmount);

                        //double pvat = (payableAmount * (vat / 100));
                        payableAmount = payableAmount + Convert.ToDouble("0" + lblVat.Text.Substring(Program.currency.Length));

                        if (isVatEnabled) //If service charge is assigned
                        {
                            //serialBody += "\r\n                        Vat("+vat.ToString()+"%): " + CPrintMethods.RightAlign(pvat.ToString("F02"), 6);
                            // serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Vat(" + vat + "%): ", pvat.ToString("F02"));
                            serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Vat(" + vat + "%): ", Convert.ToDouble("0" + lblVat.Text.Substring(Program.currency.Length)).ToString("F02"));
                        }

                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                        //serialBody += "\r\n                   Total Payable: " + CPrintMethods.RightAlign(payableAmount.ToString("F02"), 6);
                        serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", payableAmount.ToString("F02"));

                        //if (Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)) == 0) //If service charge is not assigned
                        //{
                        //    //serialBody += "\r\n            Tips/Service Charge: ______";
                        //    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge:", " ______");
                        //}
                        //serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                        if (m_bEqualSplit)
                        {
                            serialBody += "\r\n" + g_SplitAmountLabel.Text;
                        }

                        serialBody += "\r\nYou've Served by:" + m_OperatorName;
                        serialBody += "\r\n" + m_TerminalName.Trim();

                        serialBody += "\r\nS/N: " + tempOrderInfo.SerialNo.ToString() + "\n";
                        serialBody += strPrintFormatter.CreateDashedLine();
                       // serialBody += "\r\nDeveloped By: www.ibacs.co.uk";


                        this.WriteString(serialBody);

                        //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                        tempPrintMethods.USBPrint(serialBody, PrintDestiNation.CLIENT, true);

                        ///Update status
                        ///

                        if (tempOrderInfo.OrderType.Equals("Table"))
                        {
                            tempOrderInfo.Status = "Billed";
                            tempOrderInfo.OrderTime = System.DateTime.Now;
                            tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                            CPaymentManager tempPaymentManager = new CPaymentManager();
                            CPayment tempPayment = new CPayment();
                            tempPayment.OrderID = tempOrderInfo.OrderID;
                            tempPayment.BillPrintTime = DateTime.Now;
                            tempPaymentManager.InsertBillPrintTime(tempPayment);
                        }
                        // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                        if (m_bEqualSplit)
                        {
                            tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                        }
                    }
                    #endregion

                    #region "Online orders"
                    else //For online order information .Added by Baruri
                    {
                        serialBody += "\r\n----------------------------------------";
                        for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                        {
                            DataRow tempRow = m_dtItemList.Rows[rowIndex];
                            serialBody += "\r\n" + Convert.ToInt32("0" + tempRow["Qty"]).ToString() + "  ";
                            serialBody += CPrintMethods.GetFixedString(tempRow["Item"].ToString(), 23);
                            serialBody += CPrintMethods.RightAlign(Convert.ToDouble("0" + tempRow["Price"]).ToString("F02"), 6);
                        }

                        serialBody += "\r\n----------------------------------------";
                        Double discountAmount = Convert.ToDouble(Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));
                        Double billTotal = (discountAmount + m_dTotalAmount);
                        serialBody += "\r\n                     Order Total: " + CPrintMethods.RightAlign(billTotal.ToString("F02"), 6);
                        if (discountAmount > 0)
                        {
                            Double totalAmount = m_dTotalAmount;
                            Double discountPercent = 100 * discountAmount / (discountAmount + totalAmount);
                            serialBody += "\r\n                 Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(discountAmount.ToString(), 6);
                        }

                        if (Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)) > 0) //If service charge is assigned
                        {
                            serialBody += "\r\n             Service Charge: " + CPrintMethods.RightAlign(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02"), 6);
                        }
                        double payableAmount = Convert.ToDouble(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02")) + (m_itemCost - discountAmount);
                        double pvat = (payableAmount * (vat / 100)) / (1 + (vat / 100));

                        if (isVatEnabled) //If service charge is assigned
                        {
                            serialBody += "\r\n                    Vat: " + CPrintMethods.RightAlign(pvat.ToString("F02"), 6);
                        }


                        serialBody += "\r\n                   Total Payable: " + CPrintMethods.RightAlign(payableAmount.ToString("F02"), 6);

                        if (Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)) == 0) //If service charge is assigned
                        {
                            serialBody += "\r\n             Service Charge: ______";
                        }
                        serialBody += "\r\n----------------------------------------";
                        if (m_bEqualSplit)
                        {
                            serialBody += "\r\n" + g_SplitAmountLabel.Text;
                        }

                        serialBody += "\r\nYou've Served by:" + m_OperatorName;
                        serialBody += "\r\n" + m_TerminalName.Trim();
                        serialBody += "\r\n              S/N: " + tempOrderInfo.SerialNo.ToString();
                        serialBody += "\r\nDeveloped By: www.ibacs.co.uk";

                        this.WriteString(serialBody);

                        tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                    }
                    #endregion
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }



        private void PrintA5GuestBillReport(int printType)
        {
            int papersize = 70;
            StringPrintFormater strPrintFormatter = new StringPrintFormater(70);

            
              Hashtable htOrderedItems = new Hashtable();
                SortedList slOrderedItems = null;
                string cat1ID = String.Empty;

            try
            {
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                //CPrintMethods tempPrintMethods = new CPrintMethods();
                int categoryID = 0;
                //serial print 
                //string serialHeader = "IBACS RMS";
                string serialHeader = "";
                //string serialFooter = "Please Come Again";
                string serialFooter = "";

                List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                CSerialPrintContent tempSerialPrintContent;
                if (printType == 2)
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("BILL PAYMENT") + "\r\n"; 
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                }
                else
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("GUEST BILL") + "\r\n" ;
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);
                }

               

                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;

                //string s=tempOrderInfo.
                if (m_sTableType.Equals("Table"))
                {
                    if (printType == 1)
                    {
                        //Order ID line remove from report for requisting user 
                        // Sajib Vai gathered user requirement 
                        //Date : 13-02-2012

                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "\r\n\nOrder ID:" + m_iOrderID.ToString();
                        //serialBody.Add(tempSerialPrintContent);
                    }

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "\r\n\nTable Number:" + tempOrderInfo.TableNumber.ToString();
                    //serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Table No: " + tempOrderInfo.TableNumber.ToString(), "") ;
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Guest No: " + tempOrderInfo.GuestCount.ToString(),"") + "\r\n";
                    tempSerialPrintContent.Bold = true;
                    serialBody.Add(tempSerialPrintContent);

                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "Covers: " + tempOrderInfo.GuestCount.ToString() + "\r\n";
                    //tempSerialPrintContent.Bold = true;
                    //serialBody.Add(tempSerialPrintContent);
                    COrderWaiterDao orderWaiterDao = new COrderWaiterDao();
                    COrderwaiter orderWaiter = orderWaiterDao.GetOrderwaiterByOrderID(m_iOrderID);
                    if (orderWaiter != null && orderWaiter.WaiterID > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Waiter Name: " + orderWaiter.WaiterName + "\r\n";
                        //tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                    }
                }
                else if (m_sTableType.Equals("TakeAway"))
                {

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nOrder Date: " + tempOrderInfo.OrderTime.ToString("dd/MM/yy hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nPrint Date: " + System.DateTime.Now.ToString("dd/MM/yy  hh:mm tt");
                    serialBody.Add(tempSerialPrintContent);


                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Type: " + tempOrderInfo.Status;
                    serialBody.Add(tempSerialPrintContent);

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                    if (tempCustomerInfo.CustomerName.Length > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nCustomer Name: " + tempCustomerInfo.CustomerName;
                        serialBody.Add(tempSerialPrintContent);
                    }

                    if (tempCustomerInfo.CustomerPhone.Length > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nPhone:" + tempCustomerInfo.CustomerPhone;
                        serialBody.Add(tempSerialPrintContent);
                    }


                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nAddress:";
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);

                        if (tempCustomerInfo.FloorAptNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Floor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.BuildingName.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Building Name:" + tempCustomerInfo.BuildingName;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        if (tempCustomerInfo.HouseNumber.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "House Number:" + tempCustomerInfo.HouseNumber;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        string[] street = new string[0];
                        street = tempCustomerInfo.StreetName.Split('-');

                        if (street.Length > 1)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }

                            if (street[1].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = street[1].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }
                        }
                        else if (street.Length > 0 && street.Length < 2)
                        {
                            if (street[0].ToString().Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                serialBody.Add(tempSerialPrintContent);
                            }
                        }

                        if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Postal Code:" + tempCustomerInfo.CustomerPostalCode;
                            serialBody.Add(tempSerialPrintContent);
                        }
                        if (tempCustomerInfo.CustomerTown.Length > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Town:" + tempCustomerInfo.CustomerTown;
                            serialBody.Add(tempSerialPrintContent);
                        }

                        //tempSerialPrintContent = new CSerialPrintContent();
                        //tempSerialPrintContent.StringLine = "Country:" + tempCustomerInfo.CustomerCountry;
                        //serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        //
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                        serialBody.Add(tempSerialPrintContent);

                        CDelivery objDelivery = new CDelivery();
                        objDelivery.DeliveryOrderID = m_iOrderID;
                        CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                        objDelivery = (CDelivery)objDeliveryInfo.Data;
                        if (objDelivery != null)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Order Information");
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();

                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.ItemLabeledText("Item", "Qnty   Unit Price   Price(" + Program.currency + ")");
                serialBody.Add(tempSerialPrintContent);
                tempSerialPrintContent = new CSerialPrintContent();
                //
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine() + "\r\n";
                serialBody.Add(tempSerialPrintContent);
                //Line after above line
                //tempSerialPrintContent = new CSerialPrintContent();
                //tempSerialPrintContent.StringLine = "----------------------------------------";
                //serialBody.Add(tempSerialPrintContent);

                if (m_orderUserName.Replace(" ", "").ToUpper() != "Web User".Replace(" ", "").ToUpper())
                    {
                        string cat2ID = "";
                        string cat3ID = "";
                        Int32 internalCategoryID = 0;
                       // Int32 categoryID = 0;
                        m_itemCost = 0.0;

                        string categoryOrder = String.Empty;

                        for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                        {
                            #region "Parent Category"
                            DataRow tempRow = m_dtItemList.Rows[rowIndex];
                            categoryOrder = String.Empty;
                            if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 3)//Item from Category 3
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory3.Tables[0].Select("cat3_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }

                            else if (Convert.ToInt32("0" + tempRow["Catlevel"].ToString()) == 0) //If miscellenious items are added
                            {
                                cat1ID = "0";
                                cat2ID = "0";
                            }

                            else
                            {
                                internalCategoryID = Convert.ToInt32("0" + tempRow["Catid"].ToString());
                                DataRow[] dtRow = dsCategory4.Tables[0].Select("cat4_id = " + internalCategoryID);
                                if (dtRow.Length > 0)
                                {
                                    cat3ID = dtRow[0]["cat3_id"].ToString();
                                    if (cat3ID != "" || cat3ID != null)
                                    {
                                        dtRow = dsCategory3.Tables[0].Select("cat3_id = " + cat3ID);
                                    }
                                    else
                                    {
                                        dtRow = null;
                                    }
                                }

                                if (dtRow.Length > 0)
                                {
                                    cat2ID = dtRow[0]["cat2_id"].ToString();
                                    DataRow[] dtRowCat2 = dsCategory2.Tables[0].Select("cat2_id = " + cat2ID);//new
                                    cat1ID = dtRowCat2[0]["cat1_id"].ToString();
                                }
                            }
                            #endregion


                            clsOrderReport objOrderedReport = new clsOrderReport();
                            objOrderedReport.Quantity = Convert.ToInt32("0" + tempRow["Qty"].ToString());
                            objOrderedReport.ItemName = tempRow["Item"].ToString();
                            objOrderedReport.Price = Convert.ToDouble("0" + tempRow["Price"].ToString());
                            int drinkValue = Convert.ToInt32("0" + tempRow["isdrink"].ToString());
                            if (drinkValue > 0)
                            {
                                objOrderedReport.DrinkStatus = true;
                            }
                            else
                            {
                                objOrderedReport.DrinkStatus = false;
                            }

                            Int64 rankNumber = Int64.Parse(tempRow["rank"].ToString());
                            objOrderedReport.ItemUnitPrice = Convert.ToDouble(tempRow["unitPrice"].ToString());

                            Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
                            htOrderedItems.Add(category1OrderNumber + "-" + rankNumber + "-" + objOrderedReport.ItemName, objOrderedReport);

                            m_itemCost += Convert.ToDouble("0" + tempRow["Price"].ToString());
                        }

                        NumericComparer nc = new NumericComparer();
                        slOrderedItems = new SortedList(htOrderedItems, nc);
                        int keyIndex = 0;
                        string[] valueSplitter = new string[0];
                        SortedList slDrinkItems = new SortedList();
                        SortedList slMiscellaneousItems = new SortedList();

                        PrintUtility printUtility = new PrintUtility();

                        foreach (clsOrderReport objOrderedItems in slOrderedItems.Values)
                        {
                            string priceString = printUtility.PupulateRightString(objOrderedItems.Quantity, objOrderedItems.ItemUnitPrice, objOrderedItems.Price);

                            string keyValue = slOrderedItems.GetKey(keyIndex).ToString();
                            valueSplitter = keyValue.Split('-');

                            if (objOrderedItems.DrinkStatus == true) //To make all drink items consecutively
                            {
                                slDrinkItems.Add(slDrinkItems.Count, objOrderedItems);
                            }

                            else if ((categoryID != Convert.ToInt32("0" + valueSplitter[0].ToString())) && (Convert.ToInt32("0" + valueSplitter[0].ToString()) != 0)) //All the items except drinks.
                            {
                                categoryID = Convert.ToInt32("0" + valueSplitter[0].ToString());


                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), papersize - 32, priceString, papersize), "");

                                serialBody.Add(tempSerialPrintContent);
                            }
                            else if (valueSplitter[0].ToString() == "0")
                            {
                                slMiscellaneousItems.Add(slMiscellaneousItems.Count, objOrderedItems);//add miscellaneous items in the collection
                            }
                            else
                            {
                              
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), papersize - 32, priceString, papersize), "");

                                serialBody.Add(tempSerialPrintContent);
                            }
                            keyIndex++;
                        }

                        //Add miscellaneous items only
                        if (slMiscellaneousItems.Count > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Miscellaneous") + "\r\n";
                            serialBody.Add(tempSerialPrintContent);
                           
                            foreach (clsOrderReport objOrderedItems in slMiscellaneousItems.Values)
                            {
                                string priceString = printUtility.PupulateRightString(objOrderedItems.Quantity, objOrderedItems.ItemUnitPrice, objOrderedItems.Price);
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), papersize - 32, priceString, papersize), "");

                                serialBody.Add(tempSerialPrintContent);
                            }
                        }


                        //Add drinks only
                        if (slDrinkItems.Count > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CenterTextWithDashed("Drinks") + "\r\n";
                            serialBody.Add(tempSerialPrintContent);

                            foreach (clsOrderReport objOrderedItems in slDrinkItems.Values)
                            {
                                string priceString = printUtility.PupulateRightString(objOrderedItems.Quantity, objOrderedItems.ItemUnitPrice, objOrderedItems.Price);
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine +=
                                                              strPrintFormatter.ItemLabeledText(
                                                              printUtility.MultipleLine(objOrderedItems.ItemName.ToString(), papersize - 32, priceString, papersize), "");

                                serialBody.Add(tempSerialPrintContent);
                            }
                        }
                }




                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);

               // strPrintFormatter.SumupLabeledText
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Order Total: ", m_itemCost.ToString("F02"));
                serialBody.Add(tempSerialPrintContent);
                
                Double discountAmount = Convert.ToDouble(Double.Parse(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));                

                if (discountAmount > 0)
                {
                    Double totalAmount = m_dTotalAmount;
                    Double discountPercent = 100 * discountAmount / (m_itemCost); //Discount percentage of the selected products                    

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Discount:(" + discountPercent.ToString("F02") + "%) ", Convert.ToDouble(g_DiscountLabel.Text.Substring(Program.currency.Length)).ToString("F02"));
                    serialBody.Add(tempSerialPrintContent);
                }


                if (Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)) > 0) //If service charge is assigned
                {
                    CResult cResult = tempOrderManager.OrderServiceChargeGetByOrderID(m_iOrderID);
                    ServiceCharge serviceCharge = cResult.Data as ServiceCharge;

                    string tempstring = Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02");
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge(" + serviceCharge .ServicechargeRate.ToString()+ "%): ", tempstring);
                    serialBody.Add(tempSerialPrintContent);
                }

               
                double payableAmount = Convert.ToDouble(Convert.ToDouble("0" + g_ServiceChargeLabel.Text.Substring(Program.currency.Length)).ToString("F02")) + (m_itemCost - discountAmount);               
                payableAmount = payableAmount + Convert.ToDouble("0" + lblVat.Text.Substring(Program.currency.Length));

                if (isVatEnabled) //If service charge is assigned
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Vat(" + vat + "%): ", Convert.ToDouble("0" + lblVat.Text.Substring(Program.currency.Length)).ToString("F02"));
                    serialBody.Add(tempSerialPrintContent);
                }

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                serialBody.Add(tempSerialPrintContent);

                
                if (printType == 2)
                {
                    if ((m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher) > 0)
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", (m_dTotalAmount + (m_serviceCharge_accounts + m_serviceCharge_cash + m_serviceCharge_cheque + m_serviceCharge_eft + m_serviceCharge_voucher)).ToString("F02"));
                        serialBody.Add(tempSerialPrintContent);                        
                    }
                    else
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", m_dTotalAmount.ToString("F02"));
                        serialBody.Add(tempSerialPrintContent);                      
                    }

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" +  strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\nPayment:";
                    serialBody.Add(tempSerialPrintContent);                  

                    if (!g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nReceived :" + g_InputTextBox.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                             
                    }
                    if (!g_CashLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nCash:" + g_CashLabel.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                             
                    }
                    if (!g_EFTLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nCard - " + EFTOptionForm.seletedEFTCard.CardName + " :" + g_EFTLabel.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                             
                    }
                    if (!g_ChequeLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nDue:" + g_ChequeLabel.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                        
                    }

                    if (!g_VoucherLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nVoucher:" + g_VoucherLabel.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                       
                    }

                    if (!g_AccountLabel.Text.Substring(Program.currency.Length).Equals("0.00"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nAccounts:" + g_AccountLabel.Text.Substring(Program.currency.Length);
                        serialBody.Add(tempSerialPrintContent);                                               
                    }

                    if (m_isAddServiceCharge == false)
                    {
                        if (Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length)) > 0)
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "\r\nPay Back: " + g_BalaceLabel.Text.Substring(9 + Program.currency.Length) + "\n";
                            serialBody.Add(tempSerialPrintContent);                                                                           
                        }
                    }

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);

                    // Serial No line remove from report for requisting user 
                    // Sajib Vai gathered user requirement 
                    //Date : 13-02-2012
                    //tempSerialPrintContent = new CSerialPrintContent();
                    //tempSerialPrintContent.StringLine = "\r\nS/N: " + tempOrderInfo.SerialNo.ToString();
                    //serialBody.Add(tempSerialPrintContent);
                                       
                    if (Program.vatRegDes != "")
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "\r\nVat Reg. No: " + Program.vatRegDes;
                        serialBody.Add(tempSerialPrintContent);                        
                    }

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);

                }
                else if(printType ==1)
                {
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable: ", payableAmount.ToString("F02"));
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + "You've Served by:" + m_OperatorName;
                    serialBody.Add(tempSerialPrintContent);


                    //Terminal Name and Serial No line remove from report for requisting user 
                    // Sajib Vai gathered user requirement 
                    //Date : 13-02-2012
                    //if (m_TerminalName.Length > 0)
                    //{
                    //    tempSerialPrintContent = new CSerialPrintContent();
                    //    tempSerialPrintContent.StringLine = "\r\n" + m_TerminalName;
                    //    serialBody.Add(tempSerialPrintContent);
                    //}

                    //if (tempOrderInfo.SerialNo.ToString().Length > 0)
                    //{
                    //    tempSerialPrintContent = new CSerialPrintContent();
                    //    tempSerialPrintContent.StringLine = "\r\n" + "S/N: " + tempOrderInfo.SerialNo.ToString();
                    //    serialBody.Add(tempSerialPrintContent);
                    //}

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\r\n" + strPrintFormatter.CreateDashedLine();
                    serialBody.Add(tempSerialPrintContent);


                    if (tempOrderInfo.OrderType.Equals("Table"))
                    {
                        tempOrderInfo.Status = "Billed";
                        tempOrderInfo.OrderTime = System.DateTime.Now;
                        tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                        CPaymentManager tempPaymentManager = new CPaymentManager();
                        CPayment tempPayment = new CPayment();
                        tempPayment.OrderID = tempOrderInfo.OrderID;
                        tempPayment.BillPrintTime = DateTime.Now;
                        tempPaymentManager.InsertBillPrintTime(tempPayment);
                    }
                    // tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                    //if (m_bEqualSplit)
                    //{
                    //    tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
                    //}
                }

                #region "Testing printing area"
                string printingObject = "";
                for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                {
                    printingObject += serialBody[arrayIndex].StringLine.ToString();
                }

                this.WriteString(printingObject);///Write to a file when print command is executed

                gusetBillStr = printingObject;
                #endregion
                            

                tempPrintMethods.USBPrintA5Report(printingObject, PrintDestiNation.CLIENT, true, papersize);
            
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void g_PrintOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Print_Config.xml");
                if (g_PrintOffButton.Text.Equals("Printing Off"))
                {
                    tempDataSet.Tables[0].Rows[0]["PrintPaymentBill"] = "true";
                    g_PrintOffButton.Text = "Printing On";
                }
                else
                {
                    tempDataSet.Tables[0].Rows[0]["PrintPaymentBill"] = "false";
                    g_PrintOffButton.Text = "Printing Off";
                }
                tempDataSet.WriteXml("Config/Print_Config.xml");
            }
            catch (Exception ee)
            {
            }
        }

        private void g_LoyaltiCardButton_Click(object sender, EventArgs e)
        {

        }

        private void g_UseDepositButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempCalculatorForm = new CCalculatorForm("Use Deposit", "Enter Deposit Serial Number");
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel") || CCalculatorForm.inputResult.Equals(""))
            {
                return;
            }
            Int64 tempDepositSerial = Int64.Parse(CCalculatorForm.inputResult);
            CDepositManager tempDepositManager = new CDepositManager();
            CDeposit tempDeposit = new CDeposit();
            CResult oResult = tempDepositManager.DepositGetByDepositID(tempDepositSerial);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempDeposit = (CDeposit)oResult.Data;

                if (tempDeposit.DepositID != 0)
                {

                    CUseDepositForm tempUseDepositForm = new CUseDepositForm(tempDeposit);
                    DialogResult dResult = tempUseDepositForm.ShowDialog();
                    if (dResult.Equals(DialogResult.Cancel))
                        return;
                    else if (dResult.Equals(DialogResult.OK))
                    {
                        if (CUseDepositForm.usedAmount > m_dBalance)
                        {
                            tempDeposit.DepositBalance = tempDeposit.DepositBalance - m_dBalance;
                        }
                        else
                        {
                            tempDeposit.DepositBalance = tempDeposit.DepositBalance - CUseDepositForm.usedAmount;
                        }
                        m_oDeposit = tempDeposit;

                        if (CUseDepositForm.usedAmount > m_dBalance)
                        {
                            m_dTotalAmount = m_dTotalAmount - m_dBalance;
                        }
                        else
                        {
                            m_dTotalAmount = m_dTotalAmount - CUseDepositForm.usedAmount;
                        }
                        g_BillTotalLabel.Text = "£" + m_dTotalAmount.ToString("F02");

                        g_DepositUsedLabel.Text = "£" + CUseDepositForm.usedAmount.ToString("F02");
                        CurrentPaymentMethod = "Deposit";
                        UpdateCalculation(0);
                        g_UseDepositButton.Enabled = false;
                    }
                }
                else
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error", "Deposit Information not found!");
                    tempMessageBox.ShowDialog();
                }
            }
        }
        #endregion

        private void CPaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void currencyKeyPad1_Load(object sender, EventArgs e)
        {

        }

        private void saveEFTCardAgainsOrderid(EFTCard eftCard)
        {

            if (eFTCardManager.AllReadyExiste(m_iOrderID))
            {
                eFTCardManager.UpdateEFTPaymentByOrderID(m_iOrderID, eftCard.Id, eftCard.CardName);
            }
            else
            {

                eFTCardManager.InsertEFTPayment(m_iOrderID, eftCard.Id, eftCard.CardName);
            }


        }

        private void btnAlterEftCard_Click(object sender, EventArgs e)
        {
            EFTOptionForm eFTOptionForm = new EFTOptionForm();

            DialogResult dr = eFTOptionForm.ShowDialog();

            if (dr == DialogResult.Cancel)
                return;

            saveEFTCardAgainsOrderid(EFTOptionForm.seletedEFTCard);
            btnAlterEftCard.Text = "'" + EFTOptionForm.seletedEFTCard.CardName + "' is chosen. Click to alter the Card Name.";
        }

        public bool isCheatManuallyhandled()
        {

            bool manual = true;
            DataSet tempDataSet;
            try
            {
                tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/ReportSetting.xml");
                manual = Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["manual"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return manual;
        }

        private void g_ServiceChargeLabel_Click(object sender, EventArgs e)
        {

        }

        private void tipsfunctionalButton_Click(object sender, EventArgs e)
        {

            CPriceCalculatorForm tempCalculatorForm = new CPriceCalculatorForm("Misc Item", "Enter Price");
            tempCalculatorForm.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            if (CPriceCalculatorForm.inputResult.Equals("0.000"))
            {
                CMessageBox tempMessageBox = new CMessageBox("Error!", "Price cannot be zero.");
                tempMessageBox.ShowDialog();
                return;
            }
            Double totalpayable = Double.Parse(g_BillTotalLabel.Text.Substring(Program.currency.Length));
            totalpayable = totalpayable - tipsamount;
            double price = Double.Parse(CPriceCalculatorForm.inputResult);
            tipsamount = price;

            
            totalpayable = totalpayable + price;
            m_dBalance = totalpayable;
            g_BillTotalLabel.Text = Program.currency + totalpayable.ToString("F02");
            g_BalaceLabel.Text = String.Format("Balace Due {0}" + (totalpayable.ToString("F02")), Program.currency);
        }

        private void complementoryButton_Click(object sender, EventArgs e)
        {
            MessageForm.message = "";
            MessageForm.status = "";
            MessageForm aMessageForm = new MessageForm("Complementory Form", "Complementory Message");
            aMessageForm.ShowDialog();
            if( MessageForm.status == "ok")
            {
                complementoryMessage = MessageForm.message;
            }
            MessageForm.message = "";
            MessageForm.status = "";
        }

        private void dueButton_Click(object sender, EventArgs e)
        {
            MessageForm.message = "";
            MessageForm.status = "";
            MessageForm aMessageForm = new MessageForm("Due Bill Form", "Due Bill  Message");
            aMessageForm.ShowDialog();
            if (MessageForm.status == "ok")
            {
                dueMessage= MessageForm.message;
            }
            MessageForm.message = "";
            MessageForm.status = "";
        }

        private void complemmentoryfunctionalButton1_Click(object sender, EventArgs e)
        {
            if (g_InputTextBox.Text.Substring(Program.currency.Length).Equals("0.00"))
            {
                CConfirmDialogBox tempConfirmDialog = new CConfirmDialogBox("Confirm", "Are you sure you want to enter zero value?");
                tempConfirmDialog.ShowDialog();

                if (CConfirmDialogBox.DialogResult.Equals("No"))
                    return;
            }

            complementorylabel.Text = g_InputTextBox.Text;
            CurrentPaymentMethod = "Complementory";

            #region "Service charge payment section"
            //New added at 16.02.2009
            if (this.IsFinishedActualAmount() == true)
            {
                Double tempTotalPaid = 0.0;
                tempTotalPaid = Double.Parse(g_CashLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_EFTLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_ChequeLabel.Text.Substring(Program.currency.Length))
                     + Double.Parse(g_AccountLabel.Text.Substring(Program.currency.Length)) + Double.Parse(g_VoucherLabel.Text.Substring(Program.currency.Length)) + Double.Parse(complementorylabel.Text.Substring(Program.currency.Length));

                double serviceCharge = Convert.ToDouble(g_ServiceChargeLabel.Text.Substring(Program.currency.Length));

                double dblAssignedServiceCharge = (m_serviceCharge_cash + m_serviceCharge_eft + m_serviceCharge_cheque + m_serviceCharge_voucher + m_serviceCharge_accounts);
                if (serviceCharge > dblAssignedServiceCharge)//If service charge is rest to pay
                {
                    double extraPayBack = 0.0;
                    if (g_BalaceLabel.Text.Contains("Pay Back"))
                    {
                        extraPayBack = Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));//For deducting the payback amount
                    }
                    m_serviceCharge_cheque = tempTotalPaid - (m_tobePaid + dblAssignedServiceCharge) - extraPayBack;
                }
            }

            if (g_BalaceLabel.Text.Contains("Pay Back"))
            {
                double payBackArray = Convert.ToDouble(g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                if (Convert.ToDouble("0" + payBackArray) > 0)
                {
                    PayBackComfirmForm objPayBack = new PayBackComfirmForm();
                    objPayBack.ShowDialog();

                    if (PayBackComfirmForm.m_cancelStatus.Replace(" ", "").ToUpper() == "Cancel".Replace(" ", "").ToUpper())
                    {
                        return;
                    }
                    if (PayBackComfirmForm.m_PaybackStatus.Replace(" ", "").ToUpper() == "Add to Service Charge".Replace(" ", "").ToUpper())
                    {
                        m_serviceCharge_cheque = m_serviceCharge_cheque + Convert.ToDouble("0" + g_BalaceLabel.Text.Substring(9 + Program.currency.Length));
                        g_BalaceLabel.Text = "Pay Back " + Program.currency + "0.00";
                        m_isAddServiceCharge = true;
                    }
                }
            }
            #endregion
            if (m_serviceCharge_cheque < 0)
            {
                m_serviceCharge_cheque = 0;
            }

            UpdateCalculation(5);
            g_InputTextBox.Text = Program.currency.Length + "0.00";
            complemmentoryfunctionalButton1.Enabled = false;
        }

        private void addvancecAmountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            advanceAmountTextBox.Enabled = addvancecAmountCheckBox.Checked;
        }


        
    }
}