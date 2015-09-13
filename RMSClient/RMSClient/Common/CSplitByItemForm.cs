using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using Managers.Customer;
using Managers.Payment;
using RMS.Utility;
using RMSUI;

namespace RMS.Common
{
 
    public partial class CSplitByItemForm : Form
    {
        private Int64 m_iOrderID;
        private String m_sTableType;
        private DataTable m_dtItemList= new DataTable();
        private DataTable m_dtSecondList = new DataTable();
        private List<SpiltItem> FirstSpiltItems = new List<SpiltItem>();
        private List<SpiltItem> SecondSpiltItems = new List<SpiltItem>();


        private DataTable m_dtThirdList = new DataTable();

        private Double m_dTotalAmount=0;
        private Double m_dDiscount=0;
        private Double m_dservicecharge = 0;
        private Double m_dvat = 0;
        private double ordertotal = 0;
        private int copymember = 0;

        public CSplitByItemForm()
        {
            InitializeComponent();
        }

        public CSplitByItemForm(Int64 inOrderID, Double inTotalAmount, Double inDiscount, String inTableType, DataTable inItemList,Double servicecharge, Double vat)
        {
            InitializeComponent();
            m_iOrderID = inOrderID;
            m_sTableType = inTableType;
            m_dtItemList = inItemList;
            m_dTotalAmount = inTotalAmount;
            m_dDiscount = inDiscount;
            m_dservicecharge = servicecharge;
            m_dvat = vat;
            ordertotal = (inTotalAmount+inDiscount-vat);
            m_dtSecondList = new DataTable();
            m_dtSecondList.Columns.Add("Item");
            m_dtSecondList.Columns.Add("Qty");
            m_dtSecondList.Columns.Add("Price");

            //m_dtThirdList = new DataTable();
            //m_dtThirdList.Columns.Add("Price");

            

            try
            {
                for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                {
                    SpiltItem aSpiltItem=new SpiltItem();
                    String ListBoxItem = "";
                   // String Mybox = "";
                    aSpiltItem.ItemName = m_dtItemList.Rows[rowIndex]["Item"].ToString();
                    aSpiltItem.Price = Convert.ToDouble(m_dtItemList.Rows[rowIndex]["Price"]);
                    aSpiltItem.Qty = Convert.ToInt32(m_dtItemList.Rows[rowIndex]["Qty"]);
                    FirstSpiltItems.Add(aSpiltItem);

                    ListBoxItem = m_dtItemList.Rows[rowIndex]["Qty"].ToString() + "-";

                    ListBoxItem += m_dtItemList.Rows[rowIndex]["Item"].ToString();
                    ListBoxItem += "-";
                    ListBoxItem += m_dtItemList.Rows[rowIndex]["Price"].ToString();
                                
                    g_PrintBill1ListBox.Items.Add(ListBoxItem);
                  //  g_PrintBill1ListBox.DataSource=

                    //Mybox += m_dtItemList.Rows[rowIndex]["Price"].ToString();
                    //g_PrintBill1ListBox.Items.Add(Mybox);
                
                
                }
               // g_PrintBill1ListBox.DataSource = FirstSpiltItems;



            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void g_RightAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (g_PrintBill1ListBox.SelectedItem != null)
                {
                    ///Modify DataTable
                
                    DataRow tempDataRow = m_dtItemList.Rows[g_PrintBill1ListBox.SelectedIndex];
                   


                   // DataRow temp2DataRow = m_dtSecondList.NewRow();
                   // DataRow temp3Datarow = m_dtThirdList.NewRow();
                    FillSecondList(tempDataRow);

                    
                    //temp2DataRow[0] = (Convert.ToInt32(tempDataRow[1])-1).ToString();
                    //temp2DataRow[1] = tempDataRow[0];
                    //temp2DataRow[2] = tempDataRow[2];
                  
                    ////tempDataRow.ItemArray.CopyTo(temp2DataRow.ItemArray, 0);

                    //m_dtItemList.Rows.Remove(tempDataRow);

                    //m_dtSecondList.Rows.Add(temp2DataRow);

                  

                    //String ListBoxItem = "";
                    //// String Mybox = "";

                    //ListBoxItem = temp2DataRow[0] + "-";

                    //ListBoxItem += temp2DataRow[1].ToString();
                    //ListBoxItem += "-";
                    //ListBoxItem += temp2DataRow[2].ToString();
                    //g_PrintBill2ListBox.Items.Add(ListBoxItem);

                    //g_PrintBill1ListBox.Items.Remove(g_PrintBill1ListBox.SelectedItem);
                                
                
                 
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }

            

        }

        private void FillSecondList(DataRow tempDataRow)
        {
            try
            {

          
            string itemname = tempDataRow[0].ToString();
            SpiltItem aSpiltItem = (from item in FirstSpiltItems where item.ItemName == itemname select item).Single();
            int qty = aSpiltItem.Qty;
            int flag = 0;
            
            double itemprice = aSpiltItem.Price;

            foreach (SpiltItem item in SecondSpiltItems)
            {
                if(item.ItemName==itemname)
                {
                    flag = 1;
                    item.Price += (itemprice/qty);
                    item.Qty += 1;
                }
            }
            if(flag==0)
            {
                SpiltItem aItem=new SpiltItem();
                aItem.ItemName = itemname;
                aItem.Qty = 1;
                aItem.Price = (itemprice/qty);
                SecondSpiltItems.Add(aItem);
                 DataRow temp2DataRow = m_dtSecondList.NewRow();
                 temp2DataRow[0] = tempDataRow[0];
                 temp2DataRow[1] = (Convert.ToInt32(tempDataRow[1])).ToString();
                 temp2DataRow[2] = tempDataRow[2];

                m_dtSecondList.Rows.Add(temp2DataRow);
            }
            if(qty-1==0)
            {
                SpiltItem aItem = new SpiltItem();
                aItem.ItemName = itemname;
                aItem.Qty = qty;
                aItem.Price = itemprice;
                List<SpiltItem> tempSpiltItems = new List<SpiltItem>();
                foreach (SpiltItem firstSpiltItem in FirstSpiltItems)
                {
                    if(firstSpiltItem.ItemName!=itemname)
                    {
                        tempSpiltItems.Add(firstSpiltItem);
                    }
                }
                FirstSpiltItems = tempSpiltItems;
                m_dtItemList.Rows.Remove(tempDataRow);

            }
            else if(qty-1>0)
            {
                foreach (SpiltItem spiltItem in FirstSpiltItems)
                {
                    if(spiltItem.ItemName==itemname)
                    {
                        spiltItem.Qty -= 1;
                        spiltItem.Price -= (itemprice/qty);
                    }
                }
            }
            }
            catch (Exception)
            {

             
            }

            FillFirstBox(FirstSpiltItems);
            FillSecondBox(SecondSpiltItems);

        
        }

        private void FillSecondBox(List<SpiltItem> secondSpiltItems)
        {
            try
            {
                g_PrintBill2ListBox.Items.Clear();
            }
            catch (Exception)
            {
            }

            try
            {
                foreach (SpiltItem firstSpiltItem in secondSpiltItems)
                {

                    String ListBoxItem = "";


                    ListBoxItem = firstSpiltItem.Qty.ToString();

                    ListBoxItem += firstSpiltItem.ItemName.ToString();

                    ListBoxItem += firstSpiltItem.Price.ToString();

                    g_PrintBill2ListBox.Items.Add(ListBoxItem);
                }




            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void FillFirstBox(List<SpiltItem> firstSpiltItems)
        {
            try
            {
                g_PrintBill1ListBox.Items.Clear();
            }
            catch (Exception)
            {
            }
           
            try
            {
                foreach (SpiltItem firstSpiltItem in firstSpiltItems)
                {
                     
                    String ListBoxItem = "";
             

                    ListBoxItem = firstSpiltItem.Qty.ToString();

                    ListBoxItem += firstSpiltItem.ItemName.ToString();

                    ListBoxItem += firstSpiltItem.Price.ToString();

                    g_PrintBill1ListBox.Items.Add(ListBoxItem);
                }
          



            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void g_LeftAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (g_PrintBill2ListBox.SelectedItem != null)
                {
                    ///Modify DataTable
                    DataRow tempDataRow = m_dtSecondList.Rows[g_PrintBill2ListBox.SelectedIndex];
                    FillFirstList(tempDataRow);

                    //DataRow temp2DataRow = m_dtItemList.NewRow();


                    //temp2DataRow[0] = tempDataRow[0];
                    //temp2DataRow[1] = tempDataRow[1];
                    //temp2DataRow[2] = tempDataRow[2];
                    ///tempDataRow.ItemArray.CopyTo(temp2DataRow.ItemArray, 0);

                  //  m_dtSecondList.Rows.Remove(tempDataRow);
                   // m_dtItemList.Rows.Add(temp2DataRow);
                    ///


                   // g_PrintBill1ListBox.Items.Add(g_PrintBill2ListBox.SelectedItem);
                  //  g_PrintBill2ListBox.Items.Remove(g_PrintBill2ListBox.SelectedItem);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        private void FillFirstList(DataRow tempDataRow)
        {
            try
            {

                string itemname = tempDataRow[0].ToString();
                SpiltItem aSpiltItem = (from item in SecondSpiltItems where item.ItemName == itemname select item).Single();
                int qty = aSpiltItem.Qty;
                int flag = 0;

                double itemprice = aSpiltItem.Price;

                foreach (SpiltItem item in FirstSpiltItems)
                {
                    if (item.ItemName == itemname)
                    {
                        flag = 1;
                        item.Price += (itemprice / qty);
                        item.Qty += 1;
                    }
                }
                if (flag == 0)
                {
                    SpiltItem aItem = new SpiltItem();
                    aItem.ItemName = itemname;
                    aItem.Qty = 1;
                    aItem.Price = (itemprice / qty);
                    FirstSpiltItems.Add(aItem);
                    DataRow temp2DataRow = m_dtItemList.NewRow();
                    temp2DataRow[0] = tempDataRow[0];
                    temp2DataRow[1] = tempDataRow[1];
                    temp2DataRow[2] = tempDataRow[2];
                    m_dtItemList.Rows.Add(temp2DataRow);
                }
                if (qty - 1 == 0)
                {
                    SpiltItem aItem = new SpiltItem();
                    aItem.ItemName = itemname;
                    aItem.Qty = qty;
                    aItem.Price = itemprice;
                    List<SpiltItem> tempSpiltItems = new List<SpiltItem>();
                    foreach (SpiltItem firstSpiltItem in SecondSpiltItems)
                    {
                        if (firstSpiltItem.ItemName != itemname)
                        {
                            tempSpiltItems.Add(firstSpiltItem);
                        }
                    }
                    SecondSpiltItems = tempSpiltItems;
                    m_dtSecondList.Rows.Remove(tempDataRow);

                }
                else if (qty - 1 > 0)
                {
                    foreach (SpiltItem spiltItem in SecondSpiltItems)
                    {
                        if (spiltItem.ItemName == itemname)
                        {
                            spiltItem.Qty -= 1;
                            spiltItem.Price -= (itemprice / qty);
                        }
                    }
                }
            }
            catch{
            }

            FillFirstBox(FirstSpiltItems);
            FillSecondBox(SecondSpiltItems);


        }


        private void g_CanceButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintBill(DataTable inDataTable)
        {

            double totalorderamount = (from item in SecondSpiltItems select item.Price).Sum();
            copymember++;

            int papersize = 30;
            PrintUtility  printUtility=new PrintUtility();
            StringPrintFormater strPrintFormatter = new StringPrintFormater(papersize);
            try
            {
                //CPrintMethods tempPrintMethods = new CPrintMethods();
                CPrintMethodsEXT tempPrintMethods = new CPrintMethodsEXT();

                string serialHeader = "IBACS RMS_print bill after split";
                string serialFooter = "Please Come Again";

                string serialBody = "";

                //serialBody += "\n               Guest Bill";
                serialBody += "\r\n" + strPrintFormatter.CenterTextWithWhiteSpace("Spilt Bill(1/"+copymember+")");

                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;


                if (m_sTableType.Equals("Table"))
                {
                    serialBody += "\n\nTable Number:" + tempOrderInfo.TableNumber.ToString() + " Date: " + System.DateTime.Now.ToShortDateString();
                }
                else if (m_sTableType.Equals("TakeAway"))
                {
                    serialBody += "\n\nTake Away" + " Date: " + System.DateTime.Now.ToShortDateString();

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;


                    serialBody += "\nCustomer Name: " + tempCustomerInfo.CustomerName;
                    serialBody += "\nType: " + tempOrderInfo.Status;
                    if (tempOrderInfo.Status.Equals("Delivery"))
                    {
                        serialBody += "\nAddress: " + tempCustomerInfo.CustomerAddress +
                         "\n" + tempCustomerInfo.CustomerTown + "," + tempCustomerInfo.CustomerPostalCode +
                         "\n" + tempCustomerInfo.CustomerPhone;
                    }
                }
                else if (m_sTableType.Equals("Tabs"))
                {
                    serialBody += "\n\nBar Service" + " Date: " + System.DateTime.Now.ToShortDateString();
                    if (tempOrderInfo.TableNumber != 0)
                    {
                        serialBody += "\nTab Number: " + tempOrderInfo.TableNumber.ToString();
                    }
                }

                //serialBody += "\n Order Information";
                serialBody += "\n" + strPrintFormatter.CenterTextWithDashed("Order Information");
                //serialBody += "\n----------------------------------------";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                //serialBody += "\nQty Item                         Price  ";
                serialBody += "\r\n" + strPrintFormatter.ItemLabeledText("Qty Item", "Price(" + Program.currency + ")");

                //serialBody += "\n----------------------------------------";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                
                //for (int counter = 0; counter < inDataTable.Rows.Count; counter++)
                //{
                //    DataRow tempRow = inDataTable.Rows[counter];
                    
                //   /* serialBody += "\n" + tempRow["Qty"].ToString() + "  ";
                //    serialBody += CPrintMethods.GetFixedString(tempRow["Item"].ToString(), 30);
                //    serialBody += CPrintMethods.RightAlign(tempRow["Price"].ToString(), 6);*/

                //    serialBody += "\n" + strPrintFormatter.ItemLabeledText(tempRow["Qty"].ToString() + "   " + tempRow["Item"].ToString(), tempRow["Price"].ToString());
                                   

                                     
                //}
                foreach (SpiltItem item in SecondSpiltItems)
                {
                   // serialBody += "\n" + strPrintFormatter.ItemLabeledText(item.Qty.ToString() + "   " + item.ItemName, item.Price.ToString("F02"));


                    serialBody += "\n" + strPrintFormatter.ItemLabeledText(item.Qty.ToString() + "  " +
                       printUtility.MultipleLine(item.ItemName, papersize - 10, item.Price.ToString("F02"), papersize - 3), "");
                }

               

                //serialBody += "\n----------------------------------------";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                Double discountAmount = m_dDiscount;
               // Double svat = Program.vat;
                Double billTotal = (discountAmount + m_dTotalAmount);
                //serialBody += "\nOrder Total: " + CPrintMethods.RightAlign(billTotal.ToString("F02"), 6);

                serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Order Total: ", totalorderamount.ToString("F02")); 
                if (discountAmount > 0)
                {
                    Double totalAmount = ordertotal;
                    Double discountPercent = totalorderamount * discountAmount / (totalAmount);
                    //serialBody += "\n                 Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(m_dDiscount.ToString("F02"), 6);
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Discount:", discountPercent.ToString("F02"));
                
                }

                if (m_dservicecharge > 0)
                {
                    Double totalAmount = ordertotal;
                    Double discountPercent = totalorderamount * m_dservicecharge / (totalAmount);
                    //serialBody += "\n                 Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(m_dDiscount.ToString("F02"), 6);
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Service Charge:", discountPercent.ToString("F02"));

                }
                if (m_dvat> 0)
                {
                    Double totalAmount = ordertotal;
                    Double discountPercent = (m_dvat * totalorderamount) / (totalAmount);
                    //serialBody += "\n                 Discount:(" + discountPercent.ToString("F02") + "%) " + CPrintMethods.RightAlign(m_dDiscount.ToString("F02"), 6);
                    serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Vat:", discountPercent.ToString("F02"));

                }
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();
                //serialBody += "\n                   Total Payable: " + CPrintMethods.RightAlign(m_dTotalAmount.ToString("F02"), 6);
                double totalpayable = totalorderamount + (totalorderamount * m_dservicecharge / (ordertotal)) + (totalorderamount * m_dvat / (ordertotal)) -
                        +(totalorderamount * m_dDiscount / (ordertotal));

                serialBody += "\r\n" + strPrintFormatter.SumupLabeledText("Total Payable:   ", totalpayable.ToString("F02"));

                //serialBody += "\n----------------------------------------";
                serialBody += "\r\n" + strPrintFormatter.CreateDashedLine();

                //serialBody+= "\r\n\r\n Cash Pay: "+g_CashLabel.Text;
                //serialBody+= "\r\n EFT Pay: "+g_EFTLabel.Text;
                //serialBody+= "\r\n Cheque Pay: "+g_ChequeLabel.Text;
                //serialBody+= "\r\n Voucher Pay: "+g_VoucherLabel.Text;
                //serialBody+= "\r\n "+g_BalaceLabel.Text;

               
                serialBody += "\n\nS/N: " + tempOrderInfo.SerialNo.ToString()+"\n";

                //tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());
               
                tempPrintMethods.USBPrint(serialBody, PrintDestiNation.CLIENT, true);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        private string ProcessItemNameFormat(string inItemName, int maxLength)
        {
            if (inItemName.Length <= maxLength)
            {
                return inItemName;
            }
            else
            {
                int lastTokenIndex = inItemName.LastIndexOf(" ");
                string firstLine = inItemName.Substring(0, lastTokenIndex);
                string secondLine = inItemName.Substring(lastTokenIndex + 1);

                return firstLine + "\r\n  " + secondLine;
            }
        }
        private void g_PrintGuestBillButton_Click(object sender, EventArgs e)
        {
           


            try
            {
                /*if (m_dtItemList.Rows.Count > 0)
                {
                    //PrintBill(m_dtItemList);
                }*/
                if (m_dtItemList != null)
                {
                    if (m_dtSecondList.Rows.Count > 0)
                    {


                        PrintBill(m_dtSecondList);
                        g_PrintBill2ListBox.Items.Clear();
                        SecondSpiltItems.Clear();
                        return ;
                    }
                }


                ///Update status
                ///
                COrderManager tempOrderManager = new COrderManager();
                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_iOrderID).Data;

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
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double total = 0;

           foreach (String str in g_PrintBill2ListBox.Items)
             {

                 string[] strarray = str.Split('-');
               total+=double.Parse(strarray[2].ToString());

            
             }
           MessageBox.Show(total.ToString());

        }

        
    }
}