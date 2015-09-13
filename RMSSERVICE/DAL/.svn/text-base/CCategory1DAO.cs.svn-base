using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;


namespace RMS.DataAccess
{
    public class CCategory1DAO : BaseDAO, ICategory1DAO
    {

        public CResult AddCat1(CCategory1 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Category1 exists with this name.";
                }
                else
                {
                    bTempFlag = CheckCatOrder(inUser);

                    if (bTempFlag)
                    {
                        oResult.Message = "Category order exists. Write another order.";
                    }
                    else
                    {
                        this.OpenConnection();
                        string sSql = String.Format(SqlQueries.GetQuery(Query.AddCategory1), inUser.Category1Name, inUser.Category1Order, inUser.ParentCatID);

                        this.ExecuteNonQuery(sSql);

                        oResult.IsSuccess = true;

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
            return oResult;
        }




        private bool CheckCat(CCategory1 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat1), inUser.Category1Name);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat1_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat1_id"].ToString());

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

        private bool CheckCatOrder(CCategory1 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat1Order), inUser.Category1Order, inUser.ParentCatID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat1_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat1_id"].ToString());

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

        public CResult Cat1Delete(CCategory1 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1), oCat.Category1ID);
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

        public CResult Cat1Update(CCategory1 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1), oCat.Category1ID);
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


        public CResult GetCategory1(CCategory1 inCat)
        {
            CResult oResult = null;
            try
            {
                this.OpenConnection();
                string sSql = "";// string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                        inCat = ReaderToCategory1(oReader);
                }
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


        private CCategory1 ReaderToCategory1(IDataReader oReader)
        {
            CCategory1 oItem = new CCategory1();

           
           
            if (oReader["cat1_id"] != null)
                oItem.Category1ID = Int32.Parse(oReader["cat1_id"].ToString());

            if (oReader["cat1_name"] != null)
                oItem.Category1Name = oReader["cat1_name"].ToString();

            if (oReader["cat1_order"] != null)
                oItem.Category1Order = Int32.Parse(oReader["cat1_order"].ToString());

            if (oReader["parent_cat_id"] != null)
                oItem.ParentCatID = Int32.Parse(oReader["parent_cat_id"].ToString());

            return oItem;

        }
    }
}
