using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
  public interface IMembershipCardNoDao
    {

        MembershipCardNo AddMembershipCardNo(MembershipCardNo membershipCardNo);
        MembershipCardNo UpdateMembershipCardNo(MembershipCardNo membershipCardNo);
        bool  DeleteMembershipCardNo(long ID);
        List<MembershipCardNo> GetAllMembershipCardNo();
        MembershipCardNo GetMembershipCardNoByID(long ID);


    }
}
