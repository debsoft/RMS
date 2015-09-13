/**
 * File name: 
 * Author: Mutawaqqil Billah
 * Date: February 19, 2006
 * 
 * 
 * Modification history:
 * Name				Date					Desc
 * 		
 *  
 * Version: 1.0
 * Copyright (c) 2006: Ibacs Ltd.
 * */

using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using RMS.Common.ObjectModel;
using System.Threading;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace RMS
{
    namespace Common
    {
        public class CCommonConstants
        {


            private string m_sSqlQueryDateFormat = "DMY"; //DMY, MDY etc

            //private static bool m_bIsRunning = false;

            private string m_sConnetionString = "";//"User ID=sa;Password=;Database=RMSDB;Data Source=localhost;Pooling=True;Min Pool Size=5;Max Pool Size=50;";
            private int m_iTableType = 0;
            private int m_iTabsType = 1;
            private int m_iTakeAwayType = 2;

            private String m_sRemoteURL = "";
            private CUserInfo m_oUserInfo;
            private int m_iPrinterType;

            public static DateTime DefaultDateTime = new DateTime(1900,1,1,0,0,0);

            private int m_iKitchenPrintFlag = 1;

            //  private Queue<CPrintingFormat> m_qPrintingQueue = new Queue<CPrintingFormat>();

            private int m_iThreadWaitTime = 20;

            private string m_sPortName = "COM1";
            private int m_iPrinterPortBaudRate = 38400;
            private string m_sPrinterPortParity = "None";
            private int m_iPrinterPortDataBits = 8;
            private string  m_sPrinterPortStopBits = "1";

            private Mutex m_mPrintMutex = new Mutex(false);

            private int m_iLocalPrinterType = 1;
            private int m_iNetworkPrinterType = 2;

            private String m_sLocalPrinterName;
            private String m_sNetworkPrinterName;
            private int m_iServerPrintingType;

            private int m_iTableOrderFoodGrid = 15;
            private int m_iTableOrderBeverageGrid = 15;
            private int m_iBarServiceFoodGrid = 15;
            private int m_iPaymentSummaryGrid = 15;
            private int m_iMargeTableGrid = 15;
            private int m_iViewReportGrid = 15;
            private int m_iReviewTransactionGrid = 15;
            private int m_iTransferTableGrid = 15;
            private int m_iVoidTableGrid = 15;
            private int m_iUnlockTableGrid = 15;

            private int m_iRefreshRate = 10000;
            

            private byte[] m_bCutPaperCode ={ 0x1d, 0x56, 0x01 };
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
            private byte[] m_bPrintBarCode ={0x1d, 0x6b, 0x04};//Code39

            public CCommonConstants() { }


            public int RefreshRate
            {
                get { return m_iRefreshRate; }
                set { m_iRefreshRate = value; }
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

            public int TableOrderFoodGrid
            {
                get { return m_iTableOrderFoodGrid; }
                set { m_iTableOrderFoodGrid = value; }
            }

            public int TableOrderBeverageGrid
            {
                get { return m_iTableOrderBeverageGrid; }
                set { m_iTableOrderBeverageGrid = value; }
            }

            public int BarServiceFoodGrid
            {
                get { return m_iBarServiceFoodGrid; }
                set { m_iBarServiceFoodGrid = value; }
            }

            public int PaymentSummaryGrid
            {
                get { return m_iPaymentSummaryGrid; }
                set { m_iPaymentSummaryGrid = value; }
            }

            public int MargeTableGrid
            {
                get { return m_iMargeTableGrid; }
                set { m_iMargeTableGrid = value; }
            }

            public int ViewReportGrid
            {
                get { return m_iViewReportGrid; }
                set { m_iViewReportGrid = value; }
            }

            public int ReviewTransactionGrid
            {
                get { return m_iReviewTransactionGrid; }
                set { m_iReviewTransactionGrid = value; }
            }

            public int TransferTableGrid
            {
                get { return m_iTransferTableGrid; }
                set { m_iTransferTableGrid = value; }
            }

            public int VoidTableGrid
            {
                get { return m_iVoidTableGrid; }
                set { m_iVoidTableGrid = value; }
            }

            public int UnlockTableGrid
            {
                get { return m_iUnlockTableGrid; }
                set { m_iUnlockTableGrid = value; }
            }


            public int KitchenPrintFlag
            {
                get { return m_iKitchenPrintFlag; }
                set { m_iKitchenPrintFlag = value; }
            }

            public int ServerPrintingType
            {
                get { return m_iServerPrintingType; }
                set { m_iServerPrintingType = value; }
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

            public String RemoteURL
            {
                get { return m_sRemoteURL; }
                set { m_sRemoteURL = value; }
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



            public int ThreadWaitTime
            {
                set { m_iThreadWaitTime = value; }
                get { return m_iThreadWaitTime; }
            }

            public string PrinterPortName
            {
                set { m_sPortName = value; }
                get { return m_sPortName; }
            }

            public Mutex PrintMutex
            {
                set { m_mPrintMutex = value; }
                get { return m_mPrintMutex; }
            }


            public int PrinterType
            {
                get { return m_iPrinterType; }
                set { m_iPrinterType = value; }
            }

            public CUserInfo UserInfo
            {
                get { return m_oUserInfo; }
                set { m_oUserInfo = value; }
            }


            //public Queue<CPrintingFormat> PrintQueue
            //{
            //    set { m_qPrintingQueue = value; }
            //    get { return m_qPrintingQueue; }
            //}

            public int TableType
            {
                get { return m_iTableType; }
                set { m_iTableType = value; }
            }

            public int TabsType
            {
                get { return m_iTabsType; }
                set { m_iTabsType = value; }
            }

            public int TakeAwayType
            {
                get { return m_iTakeAwayType; }
                set { m_iTakeAwayType = value; }
            }


            public string DBConnection
            {
                get { return m_sConnetionString; }
                set { m_sConnetionString = value; }
            }



            //public bool ProcessIsRunning
            //{
            //    set { m_bIsRunning = value; }
            //    get { return m_bIsRunning; }
            //}

        }//CCommonConstants


        /// <summary>
        /// actions for filter
        /// </summary>
        /// 

        public enum PRINTER_TYPES
        {
            
            Serial = 1,
            Normal = 2,
            NORMAL_PRINTER = 3,
            KITCHEN_PRINTER = 4


        }


        /// <summary>
        /// actions for syntax object
        /// </summary>
        /// 
        public enum EERRORNAME
        {
            NONE = 0,
            EXCEPTION_OCCURE = 1,
            USER_EXIST = 2
        }
    }//ns
}//ns
