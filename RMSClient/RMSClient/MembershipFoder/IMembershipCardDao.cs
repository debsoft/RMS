using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
   public interface IMembershipCardDao
    {       
         MembershipCard AddMembershipCard(MembershipCard membershipCard);
         MembershipCard UpdateMembershipCard(MembershipCard membershipCard);
         bool DeleteMembershipCard(long ID);
        List<MembershipCard> GetAllMembershipCard();
        MembershipCard GetMembershipCardByID(long ID);

        List<MembershipCard> GetAllMembershipCardByName(string name);
        List<MembershipCard> GetAllMembershipCardByCode(string code);
    }
}
