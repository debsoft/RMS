using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using RMS.Common;
using System.Threading;
//using RMS.Common.ObjectModel;
using System.Collections;
using RMS;
//using Microsoft.Reporting.WinForms;
using RMS.Common.ObjectModel;
using System.Diagnostics;
using Managers.TableInfo;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace RMSSvc
{
    public class CPrintThread
    {
        public SerialPort m_pSerialPort;        
        private Mutex m_mPrintMutex;
       
        public CPrintThread()
        {            
        }

        //private void InitSerialPort()
        //{
        //    m_pSerialPort = new SerialPort();

        //    CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

        //    try
        //    {
        //        m_pSerialPort.PortName = oCommonConstants.PrinterPortName;
        //        m_pSerialPort.BaudRate = 19200;
        //        m_pSerialPort.Parity = Parity.None;
        //        m_pSerialPort.DataBits = 8;
        //        m_pSerialPort.StopBits = StopBits.One;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        private void InitSerialPort()
        {
            
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();


            m_pSerialPort = new SerialPort(oConstants.PrinterPortName, oConstants.PrinterPortBaudRate);

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


                m_pSerialPort.DataBits = oConstants.PrinterPortDataBits;

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

                //m_pSerialPort.Open();
            }
            catch (Exception ex)
            {

            }
        }


        private void DisposeSerialPort()
        {
            if (m_pSerialPort.IsOpen)
            {
                m_pSerialPort.Close();
            }
        }

        public void run()
        {
            try
            {
                Debug.WriteLine("in print thread 1");

                bool bTempFlag = false;

                List<CPrintingFormat> tempPrintRequest = new List<CPrintingFormat>();

                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
                m_mPrintMutex = oCommonConstants.PrintMutex;
                Queue<CPrintingFormat> tempPrintQueue = new Queue<CPrintingFormat>();

                while (true)
                {                   

                    try
                    {
                       bTempFlag =  m_mPrintMutex.WaitOne(oCommonConstants.ThreadWaitTime, false);

                       if (bTempFlag)
                       {

                           tempPrintQueue = CPrintQueue.PrintQueue;

                           if (tempPrintQueue != null)
                           {
                               while (tempPrintQueue.Count > 0)
                               {
                                   Debug.WriteLine("in print thread 2");

                                   tempPrintRequest.Add(tempPrintQueue.Dequeue());
                               }
                           }

                           try
                           {
                               m_mPrintMutex.ReleaseMutex();
                           }
                           catch (Exception ex)
                           {
                           }

                       }
                    }
                    catch (Exception ex)
                    {
                    }                   

                   

                    if (tempPrintQueue != null && tempPrintRequest.Count > 0)
                    {

                        MessageBox.Show("printing0");
                        Debug.WriteLine("in print thread 3");

                        // SerialPrint(tempPrintRequest.ToArray());//blocked by mehedi
                        
                        //new code by mehedi for usbprint
                        CPrintMethodsEXT printMethod = new CPrintMethodsEXT();
                         for (int i = 0; i < tempPrintRequest.ToArray().Length; i++)
                         {
                             CPrintingFormat oTempPrint = tempPrintRequest.ToArray()[i];

                             string tempstring=oTempPrint.Header;
                             tempstring+="\r\n"+oTempPrint.Body;
                             tempstring+="\r\n"+oTempPrint.Footer;
                             printMethod.USBPrint(tempstring, false);
                         }


                        Debug.WriteLine("in print thread 4");
                    }

                    tempPrintRequest.Clear();

                    Thread.Sleep(oCommonConstants.ThreadSleepTime);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void SerialPrintHeader()
        {
            try
            {
                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                //m_pSerialPort.Write(oCommonConstants.BoldOnCode, 0, oCommonConstants.BoldOnCode.Length);
                string Header = " MUJIBS\r\n";
                m_pSerialPort.Write(Header);
                //m_pSerialPort.Write(oCommonConstants.BoldOffCode, 0, oCommonConstants.BoldOffCode.Length);

                Header += " Caerphilly Road, Cardiff\r\n";
                Header += " CF14 4AD, Tel: 02920 691515\r\n";
                Header += " www.mujibs.co.uk\r\n";
                m_pSerialPort.Write(Header);
            }
            catch (Exception ex)
            {
            }
        }

        public void SerialPrintFooter()
        {
            try
            {
                string Footer = " Thank you for visiting MUJIBS \r\n";
                Footer += " Please come again\r\n";
                m_pSerialPort.Write(Footer);
            }
            catch (Exception ex)
            {
            }
        }

        public void LocalInstalledPrint(CPrintingFormat inPrintRequest)
        {
            KitchenPrintForm tempForm = new KitchenPrintForm();

            //LocalReport tempReport = new LocalReport();
            //tempForm.reportViewer1.LocalReport.ReportEmbeddedResource = "RMS.TableOrder.KitchenReport.rdlc";
            //LocalReport tempReport = tempForm.reportViewer1.LocalReport;
            //  tempReport.ReportPath = @"..\..\TableOrder\KitchenReport.rdlc";
            KitchenPrintDataSet tempDataSet = new KitchenPrintDataSet();
            tempDataSet.Items.Merge(inPrintRequest.KDataTable);
            //tempDataSet.Items.Merge(DataGridViewToDataTable(g_FoodDataGridView));
            //tempDataSet.Items.Merge(DataGridViewToDataTable(g_BeverageDataGridView));
            //tempForm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Items", tempDataSet.Items));
            tempForm.ItemsBindingSource.DataSource = tempDataSet;
            ReportParameter[] paramList = new ReportParameter[3];
            COrderManager tempOrderManager = new COrderManager();
            COrderInfo tempOrderInfo = new COrderInfo();
            CResult oResult = tempOrderManager.OrderInfoByOrderID(inPrintRequest.OrderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                tempOrderInfo = (COrderInfo)oResult.Data;
            }
            paramList[0] = new ReportParameter("TableNumber", tempOrderInfo.TableNumber.ToString());
            paramList[1] = new ReportParameter("Header", "IBACS RMS");
            paramList[2] = new ReportParameter("Footer", "Please Come Again.");
            //tempReport.SetParameters(paramList);
            tempForm.reportViewer1.LocalReport.SetParameters(paramList);

            CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();
            CPrintMethods oPrintMethod = new CPrintMethods();
            oPrintMethod.NetworkPrint(tempForm.reportViewer1.LocalReport, oCommonConstants.LocalPrinterName);
            tempForm.reportViewer1.RefreshReport();
            tempForm.Show();
        }

        public void SerialPrint(CPrintingFormat[] inPrintRequest)
        {

            try
            {

                Debug.WriteLine("in serial print 1");

                InitSerialPort();

                Debug.WriteLine("in serial print 2");

                CCommonConstants oCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                for (int i = 0; i < inPrintRequest.Length; i++)
                {
                    try
                    {
                        Debug.WriteLine("in serial print 3");

                        CPrintingFormat oTempPrint = inPrintRequest[i];

                        if (oTempPrint.PrintType == (int)PRINTER_TYPES.Normal)
                        {
                            Debug.WriteLine("in serial print 4");

                            CPrintMethods oPrintMethod = new CPrintMethods();
                          //  LocalReport oTempLocalReport = oTempPrint.KitchenReport;

                            //if (oTempLocalReport != null)
                            //{

                                Debug.WriteLine("in serial print 5");

                                //oPrintMethod.NetworkPrint(oTempLocalReport, oCommonConstants.LocalPrinterName);
                                LocalInstalledPrint(oTempPrint);

                                Debug.WriteLine("in serial print 6");

                                //InitSerialPort();

                                m_pSerialPort.Open();

                                Debug.WriteLine("in serial print 7");

                                m_pSerialPort.Write("\r\n\r\n\r\n");
                                //m_pSerialPort.Write("\x1bd1");

                                //m_pSerialPort.Write("\r\n\r\n\r\n");
                                m_pSerialPort.Write(oCommonConstants.BeepCode, 0, oCommonConstants.BeepCode.Length);
                                m_pSerialPort.Write(oCommonConstants.CutPaperCode, 0, oCommonConstants.CutPaperCode.Length);
                                m_pSerialPort.Write("\n");


                                Debug.WriteLine("in serial print 8");

                                DisposeSerialPort();

                                Debug.WriteLine("in serial print 9");

                                ///update status
                                COrderManager tempOrderManager = new COrderManager();
                                COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(oTempPrint.OrderID).Data;

                                Debug.WriteLine("in serial print 10");

                                if (tempOrderInfo.OrderType.Equals("Table"))
                                {

                                    Debug.WriteLine("in serial print 11");

                                    tempOrderInfo.Status = "Ordered";
                                    tempOrderInfo.OrderTime = System.DateTime.Now;
                                    tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                                    Debug.WriteLine("in serial print 12");

                                }
                            //}
                            else
                            {
                                Debug.WriteLine("in serial print 4a");
                            }

                        }
                        else if (oTempPrint.PrintType == (int)PRINTER_TYPES.Serial)
                        {
                           // Debug.WriteLine("in serial print 13");

                            m_pSerialPort.Open();

                            //Debug.WriteLine("in serial print 14");

                            //m_pSerialPort.Write(oCommonConstants.BoldOnCode, 0, oCommonConstants.BoldOnCode.Length);
                            //m_pSerialPort.Write(inPrintRequest[i].Header);

                           // Debug.WriteLine("in serial print 15");
                            //m_pSerialPort.Write(oCommonConstants.BoldOffCode, 0, oCommonConstants.BoldOffCode.Length);
                            //m_pSerialPort.Write(inPrintRequest[i].Body);

                           // SerialPrintHeader();

                           // Debug.WriteLine("in serial print 15a");

                            m_pSerialPort.Write(oCommonConstants.SelectFontSize, 0, oCommonConstants.SelectFontSize.Length);


                            m_pSerialPort.Write(inPrintRequest[i].Body);

                           // Debug.WriteLine("in serial print 15b");

                            //SerialPrintFooter();

                            
                           // Debug.WriteLine("in serial print 16");
                            //m_pSerialPort.Write(inPrintRequest[i].Footer);

                          //  Debug.WriteLine("in serial print 17");
                            //m_pSerialPort.Write(m_oCommonConstants.CutPaperCode, 0, oCommonConstants.CutPaperCode.Length);
                            m_pSerialPort.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                           // m_pSerialPort.Write("\x1bd1");

                            //m_pSerialPort.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                            m_pSerialPort.Write(oCommonConstants.BeepCode, 0, oCommonConstants.BeepCode.Length);
                            m_pSerialPort.Write(oCommonConstants.CutPaperCode, 0, oCommonConstants.CutPaperCode.Length);
                            m_pSerialPort.Write("\n");


                           // Debug.WriteLine("in serial print 18");

                            DisposeSerialPort();

                           // Debug.WriteLine("in serial print 19");

                            ///update status
                            COrderManager tempOrderManager = new COrderManager();
                            COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(oTempPrint.OrderID).Data;

                           // Debug.WriteLine("in serial print 20");

                            if (tempOrderInfo.OrderType.Equals("Table"))
                            {
                                Debug.WriteLine("in serial print 21");

                                tempOrderInfo.Status = "Ordered";
                                tempOrderInfo.OrderTime = System.DateTime.Now;
                                tempOrderManager.UpdateOrderInfo(tempOrderInfo);

                                Debug.WriteLine("in serial print 22");
                            }

                        }
                        else
                        {
                        }
                    }

                    catch (Exception ex)
                    {
                    }

                }


            }
            catch (Exception ex)
            {
            }
        }

      
    }
}
