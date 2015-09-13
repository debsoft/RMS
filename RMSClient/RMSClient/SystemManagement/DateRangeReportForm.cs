using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using System.IO;
using Managers.SystemManagement;
using RMS.Common.ObjectModel;
using System.Collections;
using ns;
using RMSUI;

namespace RMS
{
    public partial class DateRangeReportForm : BaseForm
    {
        Hashtable m_htFoods = new Hashtable();
        Hashtable m_htNonFoods = new Hashtable();
        
        public DateRangeReportForm()
        {
            InitializeComponent();
        }

        #region "Manipulation Area"


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
            if (productLevel == 3)
            {
                DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + productID);

                if (tempDataRowArr.Length > 0)  //Added by Baruri .This was a bug previously when no row found.
                {
                    tempProductName = tempDataRowArr[0]["cat3_name"].ToString();
                    cat2ID = tempDataRowArr[0]["cat2_id"].ToString();
                }
                cat1ID = Program.initDataSet.Tables["category2"].Select("cat2_id = " + cat2ID)[0]["cat1_id"].ToString();
                foodTypeName = Program.initDataSet.Tables["category1"].Select("cat1_id = " + cat1ID)[0]["cat1_name"].ToString();
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

            return tempProductName+":"+cat1ID+":"+foodTypeName;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataSet dsSalesRecords = new DataSet();
            CResult objResult = new CResult();
            SystemManager objSystemMgnr = new SystemManager();
            m_htFoods = new Hashtable();
            m_htNonFoods = new Hashtable();

            DateTime dtStart = new DateTime(monthCalendarFrom.SelectionStart.Year, monthCalendarFrom.SelectionStart.Month, monthCalendarFrom.SelectionStart.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(monthCalendarTo.SelectionStart.Year, monthCalendarTo.SelectionStart.Month, monthCalendarTo.SelectionStart.Day, 23, 59, 59);
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
            tempSerialPrintContent.StringLine = "         Inventory Sales Report\n";
            serialBody.Add(tempSerialPrintContent);

            tempSerialPrintContent = new CSerialPrintContent();
            tempSerialPrintContent.StringLine = "Date of Consumption of Items-";
            serialBody.Add(tempSerialPrintContent);

            tempSerialPrintContent = new CSerialPrintContent();
            tempSerialPrintContent.StringLine = "From " + monthCalendarFrom.TodayDate.ToString("dd/MM/yyyy") + " To " + monthCalendarTo.TodayDate.ToString("dd/MM/yyyy");
            serialBody.Add(tempSerialPrintContent);

            tempSerialPrintContent = new CSerialPrintContent();
            tempSerialPrintContent.StringLine = "No. of Covers:" + guestCounter.ToString() + "\n";
            serialBody.Add(tempSerialPrintContent);


            tempSerialPrintContent = new CSerialPrintContent();
            tempSerialPrintContent.StringLine = "Qty Item                           Price";
            serialBody.Add(tempSerialPrintContent);

            SortedList slorderedFoodItems = new SortedList();
            SortedList slorderedNonFoodItems = new SortedList();

                foreach (DataRow dtRrow in dsSalesRecords.Tables[0].Rows)
                {
                    clsOrderReport objOrderedItems = new clsOrderReport();
                    string[] returnedValue = GetProductName(dtRrow).Split(':');

                    string productName = Convert.ToString(returnedValue[0]);
                    string cat1ID = Convert.ToString(returnedValue[1]);

                    objOrderedItems.Quantity = Convert.ToInt32("0" + dtRrow["quantity"].ToString());
                    objOrderedItems.ItemName = productName;
                    objOrderedItems.Price = Convert.ToDouble(dtRrow["amount"]);
                    objOrderedItems.FoodTypeName = Convert.ToString(returnedValue[2]);

                    Int32 category1OrderNumber = this.GetCategory1OrderNumber(Convert.ToInt32(cat1ID));
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
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "----------------------------------------";
                            serialBody.Add(tempSerialPrintContent);


                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = objOrderedItems.FoodTypeName + ":";
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                            tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                            tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);
                            serialBody.Add(tempSerialPrintContent);

                            separatorNumber = objOrderedItems.OrderNumber;
                        }
                        else
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objOrderedItems.Quantity.ToString() + "  ";
                            tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objOrderedItems.ItemName, 30);
                            tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objOrderedItems.Price.ToString("F02"), 6);
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                #region "Non food items"
                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "-----------------Drinks-----------------";
                serialBody.Add(tempSerialPrintContent);


                SortedList slMaster2 = new SortedList();
                ArrayList arrListItemsNonFood = null;

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
                            tempSerialPrintContent = new CSerialPrintContent();
                            // tempSerialPrintContent.StringLine = "----------------------------------------";
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                            tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                            tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);
                            serialBody.Add(tempSerialPrintContent);

                            separatorNumber = objNonFoodItem.OrderNumber;
                        }
                        else
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine += objNonFoodItem.Quantity.ToString() + "  ";
                            tempSerialPrintContent.StringLine += CPrintMethods.GetFixedString(objNonFoodItem.ItemName, 30);
                            tempSerialPrintContent.StringLine += CPrintMethods.RightAlign(objNonFoodItem.Price.ToString("F02"), 6);
                            serialBody.Add(tempSerialPrintContent);
                        }
                    }
                }

                #endregion

                tempSerialPrintContent = new CSerialPrintContent();
                tempSerialPrintContent.StringLine = "----------------------------------------";
                serialBody.Add(tempSerialPrintContent);

                #region "Testing printing area"
                string printingObject = "";
                for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                {
                    printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                }

                this.WriteString(printingObject);///Write to a file when print command is executed

                #endregion

                tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, "SN".ToString());
            }
            else
            {
                MessageBox.Show("There is no record", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DateRangeReportForm_Load(object sender, EventArgs e)
        {

        } 
    }
}
