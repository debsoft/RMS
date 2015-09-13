using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;


namespace Managers.Category
{
    public class CCategoryManager
    {
         private CResult m_oResult;

        public CCategoryManager()
            {
                m_oResult = new CResult(); 
            }


        public CResult DeleteCat1(CCategory1 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category1.Cat1Delete(inUser);

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

        public CResult DeleteCat2(CCategory2 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category2.Cat2Delete(inUser);

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

        public CResult DeleteCat3(CCategory3 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category3.Cat3Delete(inUser);

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


        public CResult DeleteParentCat(CParentCategory inUser)
        {
            try
            {
                m_oResult = Database.Instance.ParentCat.ParentCatDelete(inUser);

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

        public CResult DeleteCat4(CCategory4 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category4.Cat4Delete(inUser);

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


        public CResult AddParentCat(CParentCategory inUser)
        {
            try
            {
                m_oResult = Database.Instance.ParentCat.AddParentCat(inUser);

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

        public CResult AddCategory1(CCategory1 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category1.AddCat1(inUser);

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

        public CResult AddCategory2(CCategory2 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category2.AddCat2(inUser);

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

        public CResult AddCategory3(CCategory3 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category3.AddCat3(inUser);

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

        public CResult AddCategory4(CCategory4 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category4.AddCat4(inUser);

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



        public CResult UpdateCategory1(CCategory1 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category1.AddCat1(inUser);

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

        public CResult UpdateCategory2(CCategory2 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category2.AddCat2(inUser);

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

        public CResult UpdateCategory3(CCategory3 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category3.AddCat3(inUser);

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

        public CResult UpdateCategory4(CCategory4 inUser)
        {
            try
            {
                m_oResult = Database.Instance.Category4.AddCat4(inUser);

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
