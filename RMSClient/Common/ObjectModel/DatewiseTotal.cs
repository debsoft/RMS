using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class DatewiseTotal
    {
        public DateTime Date { set; get; }
        public int Covers { set; get; }
        public double FoodTotal { set; get; }
        public double NoonFoodTotal { set; get; }
        public double OrderTotal { set; get; }
        public double VatTotal { set; get; }
        public double ServiceChargeTotal { set; get; }
        public double DiscountTotal { set; get; }
        public double CashTotal { set; get; }
        public double DueTotal { set; get; }
        public double EFTTotal { set; get; }
        public double TotalIncV { set; get; }
    }
}
