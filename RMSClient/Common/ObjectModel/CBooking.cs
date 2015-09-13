using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CBooking
    {
        private Int64 m_iBookingID;
        private Int64 m_iCustomerID;
        private string m_sBookingType;
        private string m_sStatus;
        private int m_iGuestCount;
        private int m_iTableCount;
        private Int64 m_iBookingTime;
        private string m_sComments;
        private string m_sCustomerName;
        private string m_sPhone;
        private string m_sAddress;
        private string m_bfloorAptNumber;
        private string m_sBuildingName;
        private string m_bHouseNumber;
        private string m_sStreeName;
        private string m_country;
        private string m_sCustomerTown;
        private string m_sCustomerPostalCode;


        public CBooking()
        {
            m_iBookingID = 0;
            m_iCustomerID = 0;
            m_sBookingType = String.Empty;
            m_sStatus = String.Empty;
            m_iGuestCount = 0;
            m_iTableCount = 0;
            m_iBookingTime = 0;
            m_sComments = String.Empty;
            m_bfloorAptNumber = String.Empty;
            m_sBuildingName = String.Empty;
            m_bHouseNumber = String.Empty;
            m_sStreeName = String.Empty;
            m_country = String.Empty;
            m_sCustomerTown = String.Empty;
            m_sCustomerPostalCode = String.Empty;
        }

        public String CustomerPostalCode
        {
            get { return m_sCustomerPostalCode; }
            set { m_sCustomerPostalCode = value; }
        }

        public String CustomerTown
        {
            get { return m_sCustomerTown; }
            set { m_sCustomerTown = value; }
        }

        public string CustomerCountry
        {
            get { return m_country; }
            set { m_country = value; }
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

        public Int64 BookingID
        {
            get { return m_iBookingID; }
            set { m_iBookingID = value; }
        }

        public Int64 CustomerID
        {
            get { return m_iCustomerID; }
            set { m_iCustomerID = value; }
        }

        public string BookingType
        {
            get { return m_sBookingType; }
            set { m_sBookingType = value; }
        }

        public string Status
        {
            get { return m_sStatus; }
            set { m_sStatus = value; }
        }

        public int GuestCount
        {
            get { return m_iGuestCount; }
            set { m_iGuestCount = value; }
        }

        public int TableCount
        {
            get { return m_iTableCount; }
            set { m_iTableCount = value; }
        }

        public Int64 BookingTime
        {
            get { return m_iBookingTime; }
            set { m_iBookingTime = value; }
        }

        public string Comments
        {
            get { return m_sComments; }
            set { m_sComments = value; }
        }

        public string CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }
        
        public string Phone
        {
            get { return m_sPhone; }
            set { m_sPhone = value; }
        }

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

    }
}
