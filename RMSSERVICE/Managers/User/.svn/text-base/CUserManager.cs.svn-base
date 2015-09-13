using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
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

        public CResult AddUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.UserInfo.AddUser(inUser);
               
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
                m_oResult = Database.Instance.UserInfo.LogoutUser(inUser);

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
                m_oResult = Database.Instance.UserInfo.LoginUser(inUser);

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

        public CResult LoginAdminUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.UserInfo.LoginAdminUser(inUser);

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

        public CResult GetUserAccess(CUserInfo inUser)
        {
            try
            {
                m_oResult = Database.Instance.UserInfo.GetUserAccess(inUser);

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

        public CResult AddButtonColor(CButtonColor inUser)
        {
            try
            {
                m_oResult = Database.Instance.ButtonColor.AddButtonColor(inUser);

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

        public CResult UpdatePrintStyle(CPrintStyle inUser)
        {
            try
            {
                m_oResult = Database.Instance.PrintStyle.UpdatePrintStyle(inUser);

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
