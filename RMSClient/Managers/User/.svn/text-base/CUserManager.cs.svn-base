using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS;

namespace Managers.User
{
    public class CUserManager
    {
        private CResult m_oResult;

        public CUserManager()
        {
            m_oResult = new CResult();
        }

        public CResult LoginAdminUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.LoginUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult LogoutUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.LogoutUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at LogoutUser() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in LogoutUser()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult GetUserAccess(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.GetUserAccess(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult LoginUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.LoginUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult GetAllUser()
        {
            try
            {
                List<CUserInfo> oUserList = Database.Instance.User.GetAllUser();
                m_oResult.Data = oUserList;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllUser() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllUser()", LogLevel.Error, "CUserManager");
            }
            return m_oResult;
        }

        public CResult GetUserInfoByUsername(String inUsername)
        {
            try
            {
                CUserInfo oUserInfo = Database.Instance.User.GetUserInfoByUsername(inUsername);
                m_oResult.Data = oUserInfo;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetUserInfoByUsername() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetUserInfoByUsername()", LogLevel.Error, "CUserManager");
            }
            return m_oResult;
        }

        public CResult AddUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.AddUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult UpdateUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.UpdateUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult DeleteUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.DeleteUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

        public CResult GetUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.User.GetUser(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }

    }
}
