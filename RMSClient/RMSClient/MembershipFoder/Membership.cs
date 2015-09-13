using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class Membership
    {
        public Membership() { }
       
        public virtual long id { get; set; }     
        public virtual long customerID  { get; set; }     
        public virtual string customerName { get; set; }     
        public virtual string customerPhone { get; set; }     
        public virtual string membershipCardType  { get; set; }     
        public virtual long mebershipCardID  { get; set; }     
        public virtual string membershipCardName  { get; set; }     
        public virtual string membershipCardTitle { get; set; }
        public virtual string membershipCardCode { get; set; }     
        public virtual float point { get; set; }     
        public virtual float discountPercentRate { get; set; }     
        public virtual DateTime startDate { get; set; }     
        public virtual DateTime endDate { get; set; }     
        public virtual DateTime issueDate  { get; set; }
        public virtual bool isActive { get; set; }     

    }
}
