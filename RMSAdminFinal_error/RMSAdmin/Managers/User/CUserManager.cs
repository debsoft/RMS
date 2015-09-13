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

        public CResult LogoutUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.LogoutUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.LoginAdminUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.LoginUser(inUser);

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

        public CResult GetUserInfoByUsername(String inUsername)
        {
            try
            {
                CUserInfo oUserInfo = RMS.DataAccess.Database.Instance.UserInfo.GetUserInfoByUsername(inUsername);
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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.AddUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.UpdateUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.DeleteUser(inUser);

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

        public CResult UnlockUser(CUserInfo inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.UnlockUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.GetUser(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.UserInfo.GetUserAccess(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.ButtonColor.AddButtonColor(inUser);

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

        public CResult UpdateButtonColor(CButtonColor inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.ButtonColor.UpdateButtonColor(inUser);

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

        //public CResult UpdateReceiptStyle(CPrintStyle inUser)
        //{
        //    try
        //    {
        //        m_oResult = Database.Instance.PrintStyle.UpdatePrintStyle(inUser);

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
        //        m_oResult.IsException = true;
        //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
        //        m_oResult.SetParams(ex.Message);
        //        m_oResult.Message = ex.Message;
        //        Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
        //    }
        //    return m_oResult;
        //}



        public CResult GetButtonColor(CButtonColor inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.ButtonColor.GetButtonColor(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.PrintStyle.UpdatePrintStyle(inUser);

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


        public CResult GetPrintStyle(CPrintStyle inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.PrintStyle.GetPrintStyle(inUser);

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
