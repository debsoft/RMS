
/*
 * File name: CButtonAccess.cs 
 * Author: Md. Zahidur Rahman
 *   
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 *                     1/4/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */
using System;
using System.Collections.Generic;
using System.Text;

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
        }


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
