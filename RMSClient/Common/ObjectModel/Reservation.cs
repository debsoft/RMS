using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class Reservation
    {
        public int ReservationId { set; get; }
        public DateTime BookingDate { set; get; }
        public string LoginPerson { set; get; }
        public string BookingArea { set; get; }
        public string BookingType { set; get; }
        public DateTime PartyDate { set; get; }
        public string FromTime { set; get; }
        public string ToTime { set; get; }
        public int NumberOfGuest { set; get; }
        public int NumberofOtherGuest { set; get; }
        public double MainGuestAmount { set; get; }
        public double OtherGuestAmount { set; get; }
        public double UtilityCostAmount { set; get; }
        public double ServiceCharge { set; get; }
        public double Discount { set; get; }
        public double Vat { set; get; }
        public double TotalPayableAmount { set; get; }
        public double DepositeAmount { set; get; }
        public double DueAmount { set; get; }
        public string SpecialInstruction { set; get; }
        public string ClientName { set; get; }
        public string ClientPhone { set; get; }
        public string ClientEmail { set; get; }
        public string PrintPreview { set; get; }




    }
}
