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
                m_oResult =RMS.DataAccess.Database.Instance.Category1.Cat1Delete(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category2.Cat2Delete(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category3.Cat3Delete(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.ParentCat.ParentCatDelete(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category4.Cat4Delete(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.ParentCat.AddParentCat(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category1.AddCat1(inUser);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at new category 1 insertion : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }


        public CResult SaveProductPLU(int productID, int categoryLabel, int productPLU)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Item.SaveProductPLU(productID, categoryLabel, productPLU);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at new category 1 insertion : " + ex.Message);
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
                m_oResult = RMS.DataAccess.Database.Instance.Category2.AddCat2(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category3.AddCat3(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category4.AddCat4(inUser);

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


        public CResult UpdateParentCat(CParentCategory inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.ParentCat.ParentCatUpdate(inUser);

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
                m_oResult = RMS.DataAccess.Database.Instance.Category1.Cat1Update(inUser);

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

        /// <summary>
        /// This function updates the order number of the category 1
        /// </summary>
        /// <param name="inUser"></param>
        /// <param name="inUser2"></param>
        /// <param name="inUpFlag"></param>
        /// <returns></returns>
        public CResult UpdateCategory1Order(CCategory1 inUser, CCategory1 inUser2, bool inUpFlag)
        {
            try
            {
                if (inUpFlag)
                {
                    //making up 

                    m_oResult = RMS.DataAccess.Database.Instance.Category1.UpdateCategory1OrderUP(inUser, inUser2);
                }
                else
                {
                    //Making down

                    m_oResult = RMS.DataAccess.Database.Instance.Category1.UpdateCategory1OrderDown(inUser, inUser2);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occur at re-ordering of the items : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in re-ordering of the items", LogLevel.Error, "CItemManager");
            }
            return m_oResult;
        }


        public CResult UpdateCategory2(CCategory2 inUser, int inCatOrder)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category2.Cat2Update(inUser, inCatOrder);

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


        public CResult UpdateCategory2Order(CCategory2 inUser, CCategory2 inUser2, bool inUpFlag)
        {
            try
            {
                if (inUpFlag)
                {
                    //up

                    m_oResult = RMS.DataAccess.Database.Instance.Category2.Cat2UpdateOrderUp(inUser, inUser2);
                }
                else
                {

                    //down

                    m_oResult = RMS.DataAccess.Database.Instance.Category2.Cat2UpdateOrderDown(inUser, inUser2);
                }


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


        public CResult UpdateCategory3Order(CCategory3 inUser, CCategory3 inUser2, bool inUpFlag)
        {
            try
            {
                if (inUpFlag)
                {
                    //up

                    m_oResult = RMS.DataAccess.Database.Instance.Category3.Cat3UpdateOrderUp(inUser, inUser2);
                }
                else
                {

                    //down

                    m_oResult = RMS.DataAccess.Database.Instance.Category3.Cat3UpdateOrderDown(inUser, inUser2);
                }


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

        public CResult UpdateCategory4Order(CCategory4 inUser, CCategory4 inUser2, bool inUpFlag)
        {
            try
            {
                if (inUpFlag)
                {
                    //up

                    m_oResult = RMS.DataAccess.Database.Instance.Category4.Cat4UpdateOrderUp(inUser, inUser2);
                }
                else
                {

                    //down

                    m_oResult = RMS.DataAccess.Database.Instance.Category4.Cat4UpdateOrderDown(inUser, inUser2);
                }


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

        public CResult UpdateAllRank()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category1.UpdateAllRank();

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


        public CResult UpdateCategory3(CCategory3 inUser, int inCatOrder)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category3.Cat3Update(inUser, inCatOrder);

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

        public CResult UpdateCategory4(CCategory4 inUser, int inCatOrder)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category4.Cat4Update(inUser, inCatOrder);

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


        public CResult GetParentCategory(CParentCategory inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.ParentCat.GetParentCategory(inUser);

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


        public CResult GetCategory1(CCategory1 inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category1.AddCat1(inUser);

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


        public CResult GetCategory2(CCategory2 inUser)
        {
            try
            {
                // m_oResult = Database.Instance.Category1.AddCat1(inUser);

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

        public CResult GetCategory3(CCategory3 inUser)
        {
            try
            {
                // m_oResult = Database.Instance.Category1.AddCat1(inUser);

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

        public CResult GetCategory4(CCategory4 inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category4.GetCategory4(inUser);

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

        public CResult GetCategoryAncestors(Int32 inLeafCatID, int inCatLevel)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.CategoryAnchestor.GetCategoryAnchestors(inLeafCatID, inCatLevel);
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

        public CResult GetCategory4(int inUser)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category4.GetCategory4(inUser);

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

        public CResult GetCategory1(Int32 inCat1ID)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category1.GetCategory1(inCat1ID);

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


        public CResult GetCategory2(Int32 inCat2ID)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category2.GetCategory2(inCat2ID);
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


        public CResult GetCategory3(Int32 inCat3ID)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category3.GetCategory3(inCat3ID);
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

        public CResult GetCategory3All()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category3.GetCategory3All();
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

        public CResult GetCategory4All()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.Category4.GetCategory4All();
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

        //public CResult GetParentCategory(CParentCategory inUser)
        //{
        //    try
        //    {
        //        m_oResult = Database.Instance.Category1.AddCat1(inUser);

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
    }
}
