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
//using Microsoft.Reporting.WinForms;

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

        #region Network print

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = null;

            try
            {
                stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
                if (stream != null)
                {
                    m_streams.Add(stream);
                    
                }

            }
            catch (Exception ee)
            {

            }

            return stream;

        }

        private void Export(LocalReport report)
        {
            try
            {
                string deviceInfo =
                "<DeviceInfo>" +
                " <OutputFormat>EMF</OutputFormat>" +
                " <PageWidth>8.5in</PageWidth>" +
                " <PageHeight>11in</PageHeight>" +
                " <MarginTop>0.25in</MarginTop>" +
                " <MarginLeft>0.25in</MarginLeft>" +
                " <MarginRight>0.25in</MarginRight>" +
                " <MarginBottom>0.25in</MarginBottom>" +
                "</DeviceInfo>";

                Warning[] warnings;
                m_streams = new List<Stream>();
                report.Render("Image", deviceInfo, CreateStream, out warnings);
                foreach (Stream stream in m_streams)
                    stream.Position = 0;
            }
            catch (Exception ee)
            {

            }
        }

        public void NetworkPrint(LocalReport report, String inPrinterName)
        {
            try
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
            catch (Exception ee)
            {

            }

        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
                ev.Graphics.DrawImage(pageImage, ev.PageBounds);
                m_currentPageIndex++;
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            }
            catch (Exception ee)
            {

            }
        }

        #endregion

        #region Serial Print

        private void InitSerialPort()
        {
            try
            {
                Debug.WriteLine("Entering Serial Port Initialization");
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

                Debug.WriteLine("in InitSerialPort 1");

                m_pSerialPort = new SerialPort(oConstants.PrinterPortName, oConstants.PrinterPortBaudRate);

                //m_pSerialPort.Handshake = Handshake.XOnXOff;

                Debug.WriteLine("in InitSerialPort 2");

                try
                {
                    // m_pSerialPort.BaudRate = 38400;
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

                    Debug.WriteLine("in InitSerialPort 3");

                    m_pSerialPort.DataBits = oConstants.PrinterPortDataBits;
                    Debug.WriteLine("in InitSerialPort 4");
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
                    {
                        m_pSerialPort.Close();
                    }
                    Debug.WriteLine("in InitSerialPort 5");

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
            catch (Exception ee)
            {

            }

        }
        private void DisposeSerialPort()
        {
            try
            {
                if (m_pSerialPort.IsOpen)
                {
                    m_pSerialPort.Close();
                    Debug.WriteLine("Serial Port Closed");
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine("In DisposeSerialPort Method catch");
                Debug.WriteLine(ee.ToString());
            }
        }

        //public void SerialPrint(PRINTER_TYPES inPrinterType, String inHeader, List<CSerialPrintContent> inBody, String inFooter, String inSerialNumber)
        //{
        //    try
        //    {
        //        InitSerialPort();
        //        m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
        //        if (inPrinterType == PRINTER_TYPES.NORMAL_PRINTER)
        //        {
        //            Debug.WriteLine("Write to Port Started");
        //            SerialPrintHeader();
        //            SerialPrintBody(inBody);
        //            SerialPrintFooter();
        //            SerialPrintBarCode(inSerialNumber);
        //            m_pSerialPort.Write(m_oCommonConstants.BeepCode, 0, m_oCommonConstants.BeepCode.Length);
        //            m_pSerialPort.Write(m_oCommonConstants.CutPaperCode, 0, m_oCommonConstants.CutPaperCode.Length);
        //            m_pSerialPort.Write("\n");
        //            Debug.WriteLine("Write to Port Ended");
        //        }
        //        else if (inPrinterType == PRINTER_TYPES.KITCHEN_PRINTER)
        //        {

        //        }

        //        DisposeSerialPort();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("In SerialPrint Method catch");
        //        Debug.WriteLine(ex.ToString());
        //    }
        //}

        public void SerialPrint(PRINTER_TYPES inPrinterType, String inHeader, string inBody, String inFooter, String inSerialNumber)
        {
            try
            {
                InitSerialPort();
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                if (inPrinterType == PRINTER_TYPES.NORMAL_PRINTER)
                {
                    Debug.WriteLine("Write to Port Started");
                    SerialPrintHeader();
                    m_pSerialPort.Write(inBody);
                    SerialPrintFooter();
                    SerialPrintBarCode(inSerialNumber);
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
            m_pSerialPort.Write(m_oCommonConstants.BoldOnCode, 0, m_oCommonConstants.BoldOnCode.Length);
            string Header = " MUJIBS\r\n";
            m_pSerialPort.Write(Header);
            m_pSerialPort.Write(m_oCommonConstants.BoldOffCode, 0, m_oCommonConstants.BoldOffCode.Length);

            Header += " Caerphilly Road, Cardiff\r\n";
            Header += " CF14 4AD, Tel: 02920 691515\r\n";
            Header += " www.mujibs.co.uk\r\n";
            m_pSerialPort.Write(Header);
        }

        public void SerialPrintFooter()
        {
            string Footer = " Thank you for visiting MUJIBS \r\n";
            Footer += " Please come again\r\n";
            m_pSerialPort.Write(Footer);
        }

        public void SerialPrintBarCode(String inSerialNumber)
        {
            if (inSerialNumber.Equals(""))
                return;
            m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            m_pSerialPort.Write(m_oCommonConstants.SelectFontHRI, 0, m_oCommonConstants.SelectFontHRI.Length);
            m_pSerialPort.Write(m_oCommonConstants.PrintBarCode, 0, m_oCommonConstants.PrintBarCode.Length);
            m_pSerialPort.Write(inSerialNumber);
            byte[] nullByte ={ 0x00 };
            m_pSerialPort.Write(nullByte, 0, nullByte.Length);

        }

        //public void SerialPrintBody(List<CSerialPrintContent> inBody)
        //{
        //    try
        //    {
        //        for (int i = 0; i < inBody.Count; i++)
        //        {
        //            m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
        //            if (inBody[0].Bold)
        //            {
        //                m_pSerialPort.Write(m_oCommonConstants.BoldOnCode, 0, m_oCommonConstants.BoldOnCode.Length);
        //            }
        //            m_pSerialPort.WriteLine(inBody[i].StringLine);
        //            if (inBody[0].Bold)
        //            {
        //                m_pSerialPort.Write(m_oCommonConstants.BoldOffCode, 0, m_oCommonConstants.BoldOffCode.Length);
        //            }
        //        }
        //    }
        //    catch (Exception eee)
        //    {

        //    }
        //}

        public void OpenDrawer()
        {
            try
            {
                Debug.WriteLine("Open drawer started");
                m_oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
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