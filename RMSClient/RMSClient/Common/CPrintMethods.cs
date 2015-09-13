using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO.Ports;
using RmsRemote;
using RMS.Common.ObjectModel;
using System.Diagnostics;
using RMS.DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace RMS.Common
{
    public class CPrintMethods
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private CCommonConstants m_oCommonConstants;
        public SerialPort m_pSerialPort;

        public CPrintMethods()
        {

        }

        public static string CentreAlign(string inStr, int maxChar)
        {
            int strLen = inStr.Length;

            if (strLen >= maxChar)
            {
                return inStr;
            }
            else
            {
                int diff = maxChar - strLen;

                int spaceCount = diff / 2;

                string spaces = "";
                int i=0;
                for (i = 0; i < spaceCount; i++)
                {
                    spaces += " ";
                }

                return spaces + inStr + spaces;
            }
        }
        public static string RightAlign(string inStr, int maxChar)
        {
            int strLen = inStr.Length;

            if (strLen >= maxChar)
            {
                return inStr;
            }
            else
            {
                int diff = maxChar - strLen;

                int spaceCount = diff;

                string spaces = "";
                int i = 0;
                for (i = 0; i < spaceCount; i++)
                {
                    spaces += " ";
                }

                return spaces + inStr;
            }
        }
        public static string GetFixedString(string inStr, int maxLength)
        {
            inStr = ProcessItemNameFormat(inStr, maxLength);
            if (inStr.Length == maxLength)
            {
                return inStr;
            }
            else if (inStr.Length > maxLength)
            {
                string tempSpaces = "";
                for (int j = inStr.Length; j <maxLength+maxLength+6; j++)
                    tempSpaces += " ";
                return inStr + tempSpaces;
            }
            else
            {
                string tempStr = inStr;
                for (int i = inStr.Length; i <= maxLength; i++)
                {
                    tempStr += " ";
                }
                return tempStr;
            }

        }
        public static string ProcessItemNameFormat(string inItemName, int maxLength)
        {
            if (inItemName.Length <= maxLength)
                return inItemName;
            else
            {
                //int lastTokenIndex = inItemName.LastIndexOf(" ");
                
                string firstLine = inItemName.Substring(0,maxLength);
                string secondLine = inItemName.Substring(maxLength + 1);

                return firstLine + "\r\n   " + secondLine;
            }
        }


        #region Network print

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream=null;
            try
            {
                stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
                m_streams.Add(stream);
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
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
                report.Render("Image", deviceInfo, CreateStream, out warnings);
                foreach (Stream stream in m_streams)
                    stream.Position = 0;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public void NetworkPrint(LocalReport report, String inPrinterName)
        {
            string printerName = inPrinterName;

            Export(report);
            m_currentPageIndex = 0;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;

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

        #endregion

        #region Serial Print

        private void InitSerialPort()
        {
            Debug.WriteLine("Entering Serial Port Initialization");
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();


            m_pSerialPort = new SerialPort(oConstants.PrinterPortName, oConstants.PrinterPortBaudRate);

            //m_pSerialPort.Handshake = Handshake.XOnXOff;

            Debug.WriteLine("Baud Rate Set");
            try
            {
                //   m_pSerialPort.BaudRate = 38400;
                //m_pSerialPort.Parity = Parity.None;
                switch (oConstants.PrinterPortParity)
                {
                    case "None":
                        m_pSerialPort.Parity = Parity.None;
                        break;

                    case "Odd":
                        m_pSerialPort.Parity = Parity.Odd;
                        break;

                    case "Even":
                        m_pSerialPort.Parity = Parity.Even;
                        break;

                    case "Mark":
                        m_pSerialPort.Parity = Parity.Mark;
                        break;

                    case "Space":
                        m_pSerialPort.Parity = Parity.Space;
                        break;
                    default:
                        m_pSerialPort.Parity = Parity.None;
                        break;
                }

                Debug.WriteLine("Parity Set");
                m_pSerialPort.DataBits = oConstants.PrinterPortDataBits;
                Debug.WriteLine("Data Bits Set");
                //m_pSerialPort.StopBits = StopBits.One;

                switch (oConstants.PrinterPortStopBits)
                {
                    case "1":
                        m_pSerialPort.StopBits = StopBits.One;
                        break;

                    case "1.5":
                        m_pSerialPort.StopBits = StopBits.OnePointFive;
                        break;

                    case "2":
                        m_pSerialPort.StopBits = StopBits.Two;
                        break;

                    default:
                        m_pSerialPort.StopBits = StopBits.One;
                        break;
                }
                Debug.WriteLine("Stop Bits Set");
                Debug.WriteLine("PortName:" + m_pSerialPort.PortName);
                if (m_pSerialPort.IsOpen)
                    m_pSerialPort.Close();
                m_pSerialPort.Open();
                Debug.WriteLine("Serial Port Opened");
                Debug.WriteLine("PortName:" + m_pSerialPort.PortName);
                Debug.WriteLine("Baud Rate:" + m_pSerialPort.BaudRate.ToString());
                Debug.WriteLine("Data Bits:" + m_pSerialPort.DataBits.ToString());
                Debug.WriteLine("Parity:" + m_pSerialPort.Parity.ToString());
                Debug.WriteLine("Stop Bits:" + m_pSerialPort.StopBits.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("In InitSerialPort Method catch");
                Debug.WriteLine(ex.ToString());
            }
        }
        private void DisposeSerialPort()
        {
            try
            {
                if (m_pSerialPort.IsOpen)
                {
                    m_pSerialPort.Close();
                }
                Debug.WriteLine("Serial Port Closed");
            }
            catch (Exception ee)
            {
                Debug.WriteLine("In DisposeSerialPort Method catch");
                Debug.WriteLine(ee.ToString());
            }
        }

        /// <summary>
        /// Converts a string to byte array
        /// </summary>
        /// <param name="StringToConvert"></param>
        /// <returns></returns>
        public byte[] ToByteArray(string StringToConvert)
        {
            string[] CharArray = StringToConvert.Split(',');

            byte[] ByteArray = new byte[CharArray.Length];

            for (int counter = 0; counter < CharArray.Length; counter++)
            {
                ByteArray[counter] = Convert.ToByte(Convert.ToInt32(CharArray[counter].ToString()));
            }

            return ByteArray;
        }

        public void SerialPrint(PRINTER_TYPES inPrinterType, String inHeader, List<CSerialPrintContent> inBody, String inFooter,String inSerialNumber)
        {
            try
            {
                InitSerialPort();
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                m_oCommonConstants.CutPaperCode = ToByteArray(RMSGlobal.m_printer_kitchen_cut_command); //Added by at 08.07.2009 . Cut command is taken from the xml file.

                if (inPrinterType == PRINTER_TYPES.NORMAL_PRINTER)
                {
                    Debug.WriteLine("Write to Port Started");
                    SerialPrintHeader();
                    SerialPrintBody(inBody);
                    SerialPrintFooter();
                    //SerialPrintBarCode(inSerialNumber);
                    m_pSerialPort.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                    m_pSerialPort.Write(m_oCommonConstants.BeepCode, 0, m_oCommonConstants.BeepCode.Length);
                    m_pSerialPort.Write(m_oCommonConstants.CutPaperCode, 0, m_oCommonConstants.CutPaperCode.Length);
                    m_pSerialPort.Write("\n");
                    Debug.WriteLine("Write to Port Ended");
                }
                else if (inPrinterType == PRINTER_TYPES.KITCHEN_PRINTER)
                {

                }
                DisposeSerialPort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("In SerialPrint Method catch");
                Debug.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// This function is used to print the bar copy without header and footer.
        /// </summary>
        /// <param name="inPrinterType"></param>
        /// <param name="inHeader"></param>
        /// <param name="inBody"></param>
        /// <param name="inFooter"></param>
        /// <param name="inSerialNumber"></param>
        /// <param name="isBarService"></param>
        public void SerialPrint(PRINTER_TYPES inPrinterType, String inHeader, List<CSerialPrintContent> inBody, String inFooter, String inSerialNumber,bool isBarService)
        {
            try
            {
                InitSerialPort();
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                m_oCommonConstants.CutPaperCode = ToByteArray(RMSGlobal.m_printer_kitchen_cut_command); //Added by at 08.07.2009

                if (inPrinterType == PRINTER_TYPES.NORMAL_PRINTER)
                {
                    Debug.WriteLine("Write to Port Started");
                   // SerialPrintHeader();
                    SerialPrintBody(inBody);
                    //SerialPrintFooter();
                    //SerialPrintBarCode(inSerialNumber);
                    m_pSerialPort.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                    m_pSerialPort.Write(m_oCommonConstants.BeepCode, 0, m_oCommonConstants.BeepCode.Length);
                    m_pSerialPort.Write(m_oCommonConstants.CutPaperCode, 0, m_oCommonConstants.CutPaperCode.Length);
                    m_pSerialPort.Write("\n");
                    Debug.WriteLine("Write to Port Ended");
                }
                else if (inPrinterType == PRINTER_TYPES.KITCHEN_PRINTER)
                {

                }

                DisposeSerialPort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("In SerialPrint Method catch");
                Debug.WriteLine(ex.ToString());
            }
        }
       
        
        
        
        public void SerialPrint(PRINTER_TYPES inPrinterType, String inHeader, string inBody, String inFooter,String inSerialNumber)
        {
            try
            {
                InitSerialPort();
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                m_oCommonConstants.CutPaperCode = ToByteArray(RMSGlobal.m_printer_kitchen_cut_command); //Added by at 08.07.2009

                if (inPrinterType == PRINTER_TYPES.NORMAL_PRINTER)
                {
                    Debug.WriteLine("Write to Port Started");
                    SerialPrintHeader();
                    m_pSerialPort.Write(inBody);
                    SerialPrintFooter();
                   // SerialPrintBarCode(inSerialNumber);
                   // m_pSerialPort.Write("\r\n              VAT No: 870028049\r\n");
                    m_pSerialPort.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                    m_pSerialPort.Write(m_oCommonConstants.BeepCode, 0, m_oCommonConstants.BeepCode.Length);
                    m_pSerialPort.Write(m_oCommonConstants.CutPaperCode, 0, m_oCommonConstants.CutPaperCode.Length);
                    m_pSerialPort.Write("\n");
                    Debug.WriteLine("Write to Port Ended");
                }
                else if (inPrinterType == PRINTER_TYPES.KITCHEN_PRINTER)
                {

                }
                DisposeSerialPort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("In SerialPrint Method catch");
                Debug.WriteLine(ex.ToString());
            }
        }

        public void SerialPrintHeader()
        {
            try
            {
                Debug.WriteLine("printing header");

                //Get Header From DataBase
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                string tempConnectionString = oConstants.DBConnection;
                string sSql = SqlQueries.GetQuery(Query.GetPrintStyles);
                SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sSql, tempConnectionString);
                DataSet tempDataSet = new DataSet();
                tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

                string HeaderContent = tempDataSet.Tables["PrintStyle"].Select("style_name = 'normal'")[0]["header"].ToString();
                StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
                string firstString = tempStringTokenizer.NextToken();

                m_pSerialPort.Write(m_oCommonConstants.BoldOnCode, 0, m_oCommonConstants.BoldOnCode.Length);
               // m_pSerialPort.Write(m_oCommonConstants.PrintItalicCodeOn, 0, m_oCommonConstants.PrintItalicCodeOn.Length); //Ne at 11.06.2009
                m_pSerialPort.WriteLine(CentreAlign(firstString, 40));
                m_pSerialPort.Write(m_oCommonConstants.BoldOffCode, 0, m_oCommonConstants.BoldOffCode.Length); //Ne at 11.06.2009
               
               // m_pSerialPort.Write(m_oCommonConstants.PrintItalicCodeOff, 0, m_oCommonConstants.PrintItalicCodeOff.Length);

               // m_pSerialPort.Write(m_oCommonConstants.DoubleOffCode, 0, m_oCommonConstants.DoubleOffCode.Length);//New for testing


                while (tempStringTokenizer.HasMoreTokens())
                {
                    string nextString = tempStringTokenizer.NextToken();
                    m_pSerialPort.WriteLine(CentreAlign(nextString, 40));
                }

                Debug.WriteLine("header print ended");
            }
            catch (Exception eee)
            {
                Debug.WriteLine("Error in SerialPrintHeader");
                Debug.WriteLine(eee.ToString());
            }
        }



        public void SerialPrintFooter()
        {
            try
            {
                Debug.WriteLine("printing footer");

                //Get Footer From DataBase
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                string tempConnectionString = oConstants.DBConnection;
                string sqlCommand = SqlQueries.GetQuery(Query.GetPrintStyles);
                SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sqlCommand, tempConnectionString);
                DataSet tempDataSet = new DataSet();
                tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

                string HeaderContent ="\r\n\t"+ tempDataSet.Tables["PrintStyle"].Select("style_name = 'normal'")[0]["footer"].ToString();
                StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
                string firstString = tempStringTokenizer.NextToken();

                m_pSerialPort.WriteLine(CentreAlign(firstString, 40));

                while (tempStringTokenizer.HasMoreTokens())
                {
                    string nextString = tempStringTokenizer.NextToken();
                    m_pSerialPort.WriteLine(CentreAlign(nextString, 40));
                }

                m_pSerialPort.Write("\r\n");
                Debug.WriteLine("footer print ended");
            }
            catch (Exception eee)
            {
                Debug.WriteLine("Error in SerialPrintFooter");
                Debug.WriteLine(eee.ToString());
            }
        }


        public void SerialPrintBarCode(String inSerialNumber)
        {
            try
            {
                if (inSerialNumber.Equals(""))
                {
                    return;
                }
                Debug.WriteLine("printing barcode");
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                m_pSerialPort.Write(m_oCommonConstants.SelectFontHRI, 0, m_oCommonConstants.SelectFontHRI.Length);
                m_pSerialPort.Write(m_oCommonConstants.PrintBarCode, 0, m_oCommonConstants.PrintBarCode.Length);
                m_pSerialPort.Write(inSerialNumber);
                byte[] nullByte ={ 0x00 };
                m_pSerialPort.Write(nullByte, 0, nullByte.Length);
                Debug.WriteLine("printing barcode ended");
            }
            catch (Exception eee)
            {
                Debug.WriteLine("Error in SerialPrintBarCode");
                Debug.WriteLine(eee.ToString());
            }
        }


        public void SerialPrintBody(List<CSerialPrintContent> inBody)
        {
            try
            {
                for (int counter = 0; counter < inBody.Count; counter++)
                {
                    m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                    if (inBody[0].Bold)
                    {
                        m_pSerialPort.Write(m_oCommonConstants.BoldOnCode, 0, m_oCommonConstants.BoldOnCode.Length);
                    }
                   
                    m_pSerialPort.WriteLine(inBody[counter].StringLine);
                    
                    if (inBody[0].Bold)
                    {
                        m_pSerialPort.Write(m_oCommonConstants.BoldOffCode, 0, m_oCommonConstants.BoldOffCode.Length);
                    }
                }
            }
            catch (Exception eee)
            {
                Debug.WriteLine("In SerialPrintBody Method catch");
                Debug.WriteLine(eee.ToString());
            }
        }

        public void OpenDrawer()
        {
            try
            {
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                Debug.WriteLine("Open drawer started");
                InitSerialPort();
                Debug.WriteLine("Open drawer code sent");
                m_pSerialPort.Write(m_oCommonConstants.DrawerKickCode, 0, m_oCommonConstants.DrawerKickCode.Length);
                Debug.WriteLine("Open drawer code send ended");
                DisposeSerialPort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("In OpenDrawer Method catch");
                Debug.WriteLine(ex.ToString());
            }
        }
        #endregion


       

    }
}
