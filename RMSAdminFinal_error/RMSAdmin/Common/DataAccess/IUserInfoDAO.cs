using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IUserInfoDAO
    {
        CResult AddUser(CUserInfo inUser);

        CResult UpdateUser(CUserInfo inUser);

        CResult DeleteUser(CUserInfo inUser);

        CResult GetUser(CUserInfo inCat);

        CResult GetUserAccess(CUserInfo inCat);

        CResult LoginUser(CUserInfo inCat);

        CUserInfo GetUserInfoByUsername(String inUsername);

        CResult UnlockUser(CUserInfo inUser);

        CResult LogoutUser(CUserInfo inUser);

        CResult LoginAdminUser(CUserInfo inCat);
    }
}
