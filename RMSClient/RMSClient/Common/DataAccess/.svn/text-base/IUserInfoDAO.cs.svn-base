using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IUserInfoDAO
    {
        void UserInsert(CUserInfo oUser);

        void UserUpdate(CUserInfo oUser);

        void UserDelete(CUserInfo oUser);

        List<CUserInfo> GetAllUser();

        CUserInfo GetUserInfoByUsername(String inUsername);

        CResult LoginUser(CUserInfo inCat);
        CResult LogoutUser(CUserInfo inUser);
        CResult GetUserAccess(CUserInfo inCat);
        CResult LoginAdminUser(CUserInfo inCat);
        CResult AddUser(CUserInfo inUser);
        CResult UpdateUser(CUserInfo inUser);
        CResult DeleteUser(CUserInfo inUser);
        CResult GetUser(CUserInfo inCat);           
    }
}
