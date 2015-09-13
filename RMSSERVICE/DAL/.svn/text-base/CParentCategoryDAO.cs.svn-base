using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;


namespace RMS.DataAccess
{
    public class CParentCategoryDAO : BaseDAO, IParentCategoryDAO
    {

        public CParentCategoryDAO()
        {
        }


        public CResult ParentCatDelete(CParentCategory oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteParentCategory), oCat.ParentCatID);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ItemDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public CResult AddParentCat(CParentCategory inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckParentCat(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Parent category exists with this name.";
                }
                else
                {
                    this.OpenConnection();
                    string sSql = String.Format(SqlQueries.GetQuery(Query.AddParentCategory), inUser.ParentCatName);

                    this.ExecuteNonQuery(sSql);

                    oResult.IsSuccess = true;

                }
               
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }




        private bool CheckParentCat(CParentCategory inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupParentCat), inUser.ParentCatName);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["parent_cat_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["parent_cat_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        public CResult ParentCatUpdate(CParentCategory oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = "";// string.Format(SqlQueries.GetQuery(Query.DeleteCategory1), oCat.Category1ID);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ItemDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public CResult GetParentCategory(CParentCategory inCat)
        {
            CResult oResult = null;
            try
            {
                //this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
                //IDataReader oReader = this.ExecuteReader(sSql);
                //if (oReader != null)
                //{
                //    if (oReader.Read())
                //        oItem = ReaderToCategory1(oReader);
                //}
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private CParentCategory ReaderToParentCategory(IDataReader oReader)
        {
            CParentCategory oItem = new CParentCategory();



            if (oReader["parent_cat_id"] != null)
                oItem.ParentCatID = Int32.Parse(oReader["parent_cat_id"].ToString());

            if (oReader["parent_cat_name"] != null)
                oItem.ParentCatName = oReader["parent_cat_name"].ToString();

            if (oReader["parent_cat_order"] != null)
                oItem.Order = Int32.Parse(oReader["parent_cat_order"].ToString());

           
            return oItem;

        }
    }
}
