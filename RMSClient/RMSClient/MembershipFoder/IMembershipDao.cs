using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IMembershipDao
    {
         Membership AddMembership(Membership membership);
         Membership UpdateMembership(Membership membership);
         bool DeleteMembership(long ID);
         List<Membership> GetAllMembership();
         Membership GetMembershipByID(long ID);

         Membership GetMembershipByCustomerID(long customerID);
         Membership GetMembershipByCustomerPhone(string customerPhone);
         List<Membership> GetMembershipByMembershipCardName(string membershipCardName);
         Membership GetMembershipByMembershipCardCode(string membershipCode);
         
    }
}
