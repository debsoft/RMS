
/*
 * File name: CButtonAccess.cs 
 * Author: Md. Zahidur Rahman
 *   
 * Description: 
 * 
 * Modification history:
 * Name	Baruri	    	Date					Desc
 *                     01/12/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RMS.Common.ObjectModel
{
    public class CCustomerInfo
    {
        private Int64 m_bCustomerID;
        private String m_sCustomerName;
        private String m_sCustomerPhone;
        private String m_sCustomerPostalCode;
        private String m_sCustomerAddress;
        private String m_sCustomerTown;
        private String m_sCustomerCounty;
        private String m_sCustomerCountry;
        private String m_sUserName;
        private Int32 m_bTerminalId;
        private Int64 m_bInsertDate;

        private string m_bfloorAptNumber;
        private string m_sBuildingName;
        private string m_bHouseNumber;
        private string m_sStreeName;
        private int m_configuredTime;
        private DataTable m_CustomerList;

        public CCustomerInfo()
        {
            m_bCustomerID = 0;
            m_sCustomerName = String.Empty;
            m_sCustomerPhone = String.Empty;
            m_sCustomerPostalCode = string.Empty;
            m_sCustomerAddress = string.Empty;
            m_sCustomerTown = string.Empty;
            m_sCustomerCounty = string.Empty;
            m_sCustomerCountry = string.Empty;
            m_sUserName = string.Empty;
            m_bTerminalId = 0;
            m_bInsertDate = 0;
            m_bfloorAptNumber = String.Empty;
            m_sBuildingName = String.Empty;
            m_bHouseNumber = String.Empty;
            m_sStreeName = String.Empty;
            m_configuredTime = 0;
            m_CustomerList = new DataTable();
        }

        public DataTable CustomerDataTable
        {
            get { return m_CustomerList; }
            set { m_CustomerList = value; }
        }

        public string FloorAptNumber
        {
            get { return m_bfloorAptNumber; }
            set { m_bfloorAptNumber = value; }
        }

        public string BuildingName
        {
            get { return m_sBuildingName; }
            set { m_sBuildingName = value; }
        }

        public string HouseNumber
        {
            get { return m_bHouseNumber; }
            set { m_bHouseNumber = value; }
        }


        public string StreetName
        {
            get { return m_sStreeName; }
            set { m_sStreeName = value; }
        }
      //  ------------------


        public string UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }

        public Int32 TerminalId
        {
            get { return m_bTerminalId; }
            set { m_bTerminalId = value; }
        }
        
        public Int32 ConfiguredTime
        {
            get { return m_configuredTime; }
            set { m_configuredTime = value; }
        }
        public Int64 InsertDate
        {
            get { return m_bInsertDate; }
            set { m_bInsertDate = value; }
        }


        public Int64 CustomerID
        {
            get { return m_bCustomerID; }
            set { m_bCustomerID = value; }
        }

        public String CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }

        public String CustomerPhone
        {
            get { return m_sCustomerPhone; }
            set { m_sCustomerPhone = value; }
        }

        public String CustomerPostalCode
        {
            get { return m_sCustomerPostalCode; }
            set { m_sCustomerPostalCode = value; }
        }

        public String CustomerAddress
        {
            get { return m_sCustomerAddress; }
            set { m_sCustomerAddress = value; }
        }

        public String CustomerTown
        {
            get { return m_sCustomerTown; }
            set { m_sCustomerTown = value; }
        }

        public String CustomerCounty
        {
            get { return m_sCustomerCounty; }
            set { m_sCustomerCounty = value; }
        }

        public String CustomerCountry
        {
            get { return m_sCustomerCountry; }
            set { m_sCustomerCountry = value; }
        }
    }
}
