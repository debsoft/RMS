using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RMS
{
    namespace Common
    {
      public  class CPrinterConstants
        {
            private string m_sSqlQueryDateFormat = "DMY"; //DMY, MDY etc

            private string m_sChannel = "Tcp"; //DMY, MDY etc

            private int m_sPort = 8085;

            private int m_iLocalPrinterType = 1;
            private int m_iNetworkPrinterType = 2;

            private String m_sLocalPrinterName;
            private String m_sNetworkPrinterName;          

            #region Kitchen Printing constants(By Zahid)

            private int m_iThreadWaitTime = 5000;

            private int m_iThreadSleepTime = 5000;

            private String m_sPortName="COM1";
            
            private Mutex m_mPrintMutex = new Mutex(false);

            private int m_iPrinterPortBaudRate = 38400;
            private string m_sPrinterPortParity = "None";
            private int m_iPrinterPortDataBits = 8;
            private string m_sPrinterPortStopBits = "1";

            //private Queue<CPrintingFormat> m_qPrintingQueue = new Queue<CPrintingFormat>();      

            private byte[] m_bCutPaperCode ={ 0x1d, 0x56, 0x52 };
            private byte[] m_bTmu220CutPaperCode = { 0x1d, 0x56, 0x30 };



            private byte[] m_bBeepCode = { 0x1b, 0x1e };
            private byte[] m_bBoldOnCode ={ 0x1b, 0x45, 0x01 };
            private byte[] m_bBoldOffCode ={ 0x1b, 0x45, 0x00 };
            private byte[] m_bDoubleOnCode ={ 0x1b, 0x47, 0x01 };
            private byte[] m_bDoubleOffCode ={ 0x1b, 0x47, 0x00 };
            private byte[] m_bFontACode ={ 0x1b, 0x4d, 0x00 };
            private byte[] m_bFontBCode ={ 0x1b, 0x4d, 0x01 };
            private byte[] m_bDrawerKickCode ={ 0x1b, 0x70, 0x00, 0x19, 0x64 };
            private byte[] m_bDrawerKick100MSCode ={ 0x1b, 0x70, 0x00, 0x32, 0xc8 };
            private byte[] m_bSelectFontHRI ={ 0x1d, 0x66, 0x01 };
            private byte[] m_bPrintBarCode ={ 0x1d, 0x6b, 0x04 };//Code39
            
            private byte[] m_bPrintRedOnCode = { 0x1b, 0x72, 0x01 }; //New at 11.06.2009
            private byte[] m_bPrintRedOffCode = { 0x1b, 0x72, 0x00 };//New at 11.06.2009

            private byte[] m_bSelectFontSize = { 0x1b, 0x4d, 0x00 };//select font size

            #endregion

            public byte[] Tmu220
            {
                get { return m_bTmu220CutPaperCode; }
                set { m_bTmu220CutPaperCode = value; }
            }


            //private Queue<>
            public byte[] PrintRedCode
            {
                get { return m_bPrintRedOnCode; }
                set { m_bPrintRedOnCode = value; }
            }

            public byte[] OffRedCode
            {
                get { return m_bPrintRedOffCode; }
                set { m_bPrintRedOffCode = value; }
            }

                       
            public CPrinterConstants() {}

            public byte[] SelectFontSize
            {
                get { return m_bSelectFontSize; }
                set { m_bSelectFontSize = value; }
            }


            public byte[] SelectFontHRI
            {
                get { return m_bSelectFontHRI; }
                set { m_bSelectFontHRI = value; }
            }

            public byte[] PrintBarCode
            {
                get { return m_bPrintBarCode; }
                set { m_bPrintBarCode = value; }
            }


            public int PrinterPortBaudRate
            {
                get { return m_iPrinterPortBaudRate; }
                set { m_iPrinterPortBaudRate = value; }
            }

            public string PrinterPortParity
            {
                get { return m_sPrinterPortParity; }
                set { m_sPrinterPortParity = value; }
            }

            public int PrinterPortDataBits
            {
                get { return m_iPrinterPortDataBits; }
                set { m_iPrinterPortDataBits = value; }
            }

            public string PrinterPortStopBits
            {
                get { return m_sPrinterPortStopBits; }
                set { m_sPrinterPortStopBits = value; }
            }

            public int LocalPrinterType
            {
                get { return m_iLocalPrinterType; }
                set { m_iLocalPrinterType = value; }
            }

            public int NetworkPrinterType
            {
                get { return m_iNetworkPrinterType; }
                set { m_iNetworkPrinterType = value; }
            }

            public String LocalPrinterName
            {
                get { return m_sLocalPrinterName; }
                set { m_sLocalPrinterName = value; }
            }

            public String NetworkPrinterName
            {
                get { return m_sNetworkPrinterName; }
                set { m_sNetworkPrinterName = value; }
            }

            public String SqlQueryDateFormat
            {
                set { m_sSqlQueryDateFormat = value; }
                get { return m_sSqlQueryDateFormat; }
            }


            public String Channel
            {
                set { m_sChannel = value; }
                get { return m_sChannel; }
            }


            public int Port
            {
                set { m_sPort = value; }
                get { return m_sPort; }
            }


            #region property methods for kitchen print constants(by Zahid)

            public int ThreadWaitTime
            {
                set { m_iThreadWaitTime = value; }
                get { return m_iThreadWaitTime; }
            }

            public int ThreadSleepTime
            {
                set { m_iThreadSleepTime = value; }
                get { return m_iThreadSleepTime; }
            }

            public String PrinterPortName
            {
                set { m_sPortName = value; }
                get { return m_sPortName; }
            }

            public Mutex PrintMutex
            {
                set { m_mPrintMutex = value; }
                get { return m_mPrintMutex; }
            }

            public byte[] CutPaperCode
            {
                get { return m_bCutPaperCode; }
                set { m_bCutPaperCode = value; }
            }

            public byte[] BoldOffCode
            {
                get { return m_bBoldOffCode; }
                set { m_bBoldOffCode = value; }
            }

            public byte[] BeepCode
            {
                get { return m_bBeepCode; }
                set { m_bBeepCode = value; }
            }

            public byte[] BoldOnCode
            {
                get { return m_bBoldOnCode; }
                set { m_bBoldOnCode = value; }
            }

            public byte[] DoubleOnCode
            {
                get { return m_bDoubleOnCode; }
                set { m_bDoubleOnCode = value; }
            }

            public byte[] DoubleOffCode
            {
                get { return m_bDoubleOffCode; }
                set { m_bDoubleOffCode = value; }
            }

            public byte[] FontACode
            {
                get { return m_bFontACode; }
                set { m_bFontACode = value; }
            }

            public byte[] FontBCode
            {
                get { return m_bFontBCode; }
                set { m_bFontBCode = value; }
            }

            public byte[] DrawerKickCode
            {
                get { return m_bDrawerKickCode; }
                set { m_bDrawerKickCode = value; }
            }

            public byte[] DrawerKick100MSCode
            {
                get { return m_bDrawerKick100MSCode; }
                set { m_bDrawerKick100MSCode = value; }
            }

            #endregion
        }//CCommonConstants
       
        }
    }
