using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RMS.SystemManagement
{
    public  class PrinterConfig
    {
        private  DataSet tempDataSet;

        private string kitchenPrintName = "default kitchen printer";
        private string bevaragePrintName = "default bevarage printer";
        private string clientPrintName = "";
        private string otherprinter = "";
        private string othernonprinter = "";

        private bool enablePortPrinter = false;

        //private int kitchenPrintPaperSize = 0;
        //private int beveragePrintPaperSize = 0;

        public PrinterConfig()
        {
            try
            {
                tempDataSet = new DataSet();
                tempDataSet.ReadXml("Config/Print_Config.xml");
                kitchenPrintName = tempDataSet.Tables[0].Rows[0]["KitchenPrinterName"].ToString();
                bevaragePrintName = tempDataSet.Tables[0].Rows[0]["BeveragePrinterName"].ToString();
                clientPrintName = tempDataSet.Tables[0].Rows[0]["ClientPrinterName"].ToString();
                enablePortPrinter = Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["EnableSerialPortPrinting"].ToString().ToLower());
                otherprinter = tempDataSet.Tables[0].Rows[0]["OtherPrinter"].ToString();
                othernonprinter = tempDataSet.Tables[0].Rows[0]["OtherNonFoodPrinter"].ToString();

                //OtherNonFoodPrinter
                XDocument doc = XDocument.Load("Config/Print_Config.xml");

                var authors = doc.Descendants("CPrintConfig");
                string sr = "";

                foreach (var author in authors)
                {
                     sr += author.Value;
                }
               // MessageBox.Show(sr);
                //Console.ReadLine();


                //kitchenPrintPaperSize = Convert.ToInt32(tempDataSet.Tables[0].Rows[0]["KitchenPrintPaperSize"].ToString());
                //beveragePrintPaperSize = Convert.ToInt32(tempDataSet.Tables[0].Rows[0]["KitchenPrintPaperSize"].ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        public bool SaveChanges()
        {
            bool success = false;
            try
            {
                tempDataSet.Tables[0].Rows[0]["KitchenPrinterName"]=kitchenPrintName;
                tempDataSet.Tables[0].Rows[0]["BeveragePrinterName"]=bevaragePrintName;
                tempDataSet.Tables[0].Rows[0]["ClientPrinterName"]=clientPrintName;
                tempDataSet.Tables[0].Rows[0]["EnableSerialPortPrinting"] = enablePortPrinter.ToString();
                tempDataSet.Tables[0].Rows[0]["OtherPrinter"] = otherprinter;
                 tempDataSet.Tables[0].Rows[0]["OtherNonFoodPrinter"]=othernonprinter;



                    //tempDataSet.Tables[0].Rows[0]["KitchenPrintPaperSize"] = kitchenPrintPaperSize;
                    //tempDataSet.Tables[0].Rows[0]["KitchenPrintPaperSize"] = beveragePrintPaperSize;


                tempDataSet.WriteXml("Config/Print_Config.xml");

                success= true;
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show(ex.ToString());
            }
            return success;
        }

        public string KitchenPrinterName 
        {
            get { return kitchenPrintName; }
            set { kitchenPrintName = value; }
        }
        public string BeveragePrinterName
        {
            get { return bevaragePrintName; }
            set { bevaragePrintName = value; }
        }
        public string ClientPrinterName
        {
            get { return clientPrintName; }
            set { clientPrintName = value; }
        }
        public bool EnableSerialPortPrinting
        {
            get { return enablePortPrinter; }
            set { enablePortPrinter = value; }
        }

        public string OtherPrinter
        {
            get { return otherprinter; }
            set { otherprinter = value; }
        }

        public string OtherNonFoodPrinter
        {
            get { return othernonprinter; }
            set { othernonprinter = value; }
        }

        //public int KitchenPrintPaperSize
        //{
        //    get { return kitchenPrintPaperSize; }
        //    set { kitchenPrintPaperSize = value; }
        //}


        //public int BeveragePrintPaperSize
        //{
        //    get { return beveragePrintPaperSize; }
        //    set { beveragePrintPaperSize = value; }
        //}
    }
}
