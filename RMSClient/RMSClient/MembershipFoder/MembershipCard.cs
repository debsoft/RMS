using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class MembershipCard
    {
        public MembershipCard() { }

        public virtual long id { get; set; }
        public virtual DateTime creationDate { get; set; }
        public virtual string code { get; set; }
        public virtual string title { get; set; }
        public virtual string description { get; set; }
        public virtual string name { get; set; }
        public virtual double points { get; set; }
        public virtual double discountPercent { get; set; }
        public virtual string type { get; set; }
        public virtual System.DateTime startDate { get; set; }
        public virtual System.DateTime endDate { get; set; }
        public virtual bool isActive { get; set; }
    }
}
