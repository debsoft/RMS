using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CShiftOrderInfo
    {
        private long shiftOrderID;
        private long shiftID;
        private long orderID;
        private DateTime creationDate;
        private int shiftNo;
        private DateTime paymentCreationDate;

        public long ShiftOrderID
        {
            get { return shiftOrderID; }
            set { shiftOrderID = value; }
        }

        public long ShiftID
        {
            get { return shiftID; }
            set { shiftID = value; }
        }

        public long OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public int ShiftNo
        {
            get { return shiftNo; }
            set { shiftNo = value; }
        }


        public DateTime PaymentCreationDate
        {
            get { return paymentCreationDate; }
            set { paymentCreationDate =value; }
        }
    }
}
