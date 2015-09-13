using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;


namespace RMS.DataAccess
{
    public class CCategory2DAO : BaseDAO, ICategory2DAO
    {

        public CResult Cat2Delete(CCategory2 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory2), oCat.Category2ID);
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

        public CResult AddCat2(CCategory2 inUser)
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
                        string sSql = "";// String.Format(SqlQueries.GetQuery(Query.AddCategory1), inUser.Category1Name, inUser.Category1Order, inUser.ParentCatID);

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
        
        private bool CheckCat(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = "";// String.Format(SqlQueries.GetQuery(Query.CheckDupCat1), inUser.Category1Name);

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

        private bool CheckCatOrder(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = "";// String.Format(SqlQueries.GetQuery(Query.CheckCat1Order), inUser.Category1Order, inUser.ParentCatID);

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

        public CResult GetCategory2(CCategory2 inCat)
        {
            CResult oResult = null;
            try
            {
                this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
                //IDataReader oReader = this.ExecuteReader(sSql);
                //if (oReader != null)
                //{
                //    if (oReader.Read())
                //        oItem = ReaderToCategory2(oReader);
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

        public CResult Cat2Update(CCategory2 oCat)
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

        private CCategory2 ReaderToCategory2(IDataReader oReader)
        {
            CCategory2 oItem = new CCategory2();



            if (oReader["cat2_id"] != null)
                oItem.Category2ID = Int32.Parse(oReader["cat2_id"].ToString());

            if (oReader["cat2_name"] != null)
                oItem.Category2Name = oReader["cat2_name"].ToString();

            if (oReader["cat1_id"] != null)
                oItem.Category1ID = Int32.Parse(oReader["cat1_id"].ToString());

            if (oReader["cat2_order"] != null)
                oItem.Category2Order = Int32.Parse(oReader["cat2_order"].ToString());

            if (oReader["cat2_type"] != null)
                oItem.Category2Type = Int32.Parse(oReader["cat2_type"].ToString());

            if (oReader["cat2_color"] != null)
                oItem.Category2Color = oReader["cat2_color"].ToString();

            if (oReader["view_table"] != null)
                oItem.Category2ViewTable = Int32.Parse(oReader["view_table"].ToString());

            if (oReader["view_bar"] != null)
                oItem.Category2ViewBar = Int32.Parse(oReader["view_bar"].ToString());

            if (oReader["view_takeaway"] != null)
                oItem.Category2ViewTakeAway = Int32.Parse(oReader["view_takeaway"].ToString());

            return oItem;

        }
    }
}
