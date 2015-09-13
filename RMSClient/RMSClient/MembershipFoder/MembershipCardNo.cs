using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class MembershipCardNo
    {
        public MembershipCardNo() { }

        public virtual long id { get; set; }
        public virtual string code { get; set; }
        public virtual long cardId { get; set; }
        public virtual bool isActive { get; set; }

    }
}
