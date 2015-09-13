using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;


namespace RMS.DataAccess
{
    public class CCategory3DAO : BaseDAO, ICategory3DAO 
    {
        public CResult Cat3Delete(CCategory3 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory3), oCat.Category3ID);
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

        public CResult AddCat3(CCategory3 inUser)
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

        private bool CheckCat(CCategory3 inUser)
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

        private bool CheckCatOrder(CCategory3 inUser)
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

        public CResult GetCategory3(CCategory3 inCat)
        {
            CResult oResult = null;
            //try
            //{
            //    this.OpenConnection();
            //    string sSql = string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
            //    IDataReader oReader = this.ExecuteReader(sSql);
            //    if (oReader != null)
            //    {
            //        if (oReader.Read())
            //            oItem = ReaderToCategory3(oReader);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

            //    oResult.IsException = true;
            //}
            //finally
            //{
            //    this.CloseConnection();
            //}
            return oResult;
        }

        public CResult Cat3Update(CCategory3 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1));
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

        private CCategory3 ReaderToCategory3(IDataReader oReader)
        {
            CCategory3 oItem = new CCategory3();



            if (oReader["cat3_id"] != null)
                oItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["cat3_name"] != null)
                oItem.Category3Name = oReader["cat3_name"].ToString();

            if (oReader["cat2_id"] != null)
                oItem.Category2ID = Int32.Parse(oReader["cat2_id"].ToString());

            if (oReader["description"] != null)
                oItem.Category3Description = oReader["description"].ToString();

            if (oReader["table_price"] != null)
                oItem.Category3TablePrice = Double.Parse(oReader["table_price"].ToString());

            if (oReader["tw_price"] != null)
                oItem.Category3TakeAwayPrice = Double.Parse(oReader["tw_price"].ToString());

            if (oReader["bar_price"] != null)
                oItem.Category3BarPrice = Double.Parse(oReader["bar_price"].ToString());

            if (oReader["status"] != null)
                oItem.Category3OrderStatus = Int32.Parse(oReader["status"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());


            if (oReader["view_table"] != null)
                oItem.Category3ViewTable = Int32.Parse(oReader["view_table"].ToString());

            if (oReader["view_bar"] != null)
                oItem.Category3ViewBar = Int32.Parse(oReader["view_bar"].ToString());

            if (oReader["view_takeaway"] != null)
                oItem.Category3Order = Int32.Parse(oReader["view_takeaway"].ToString());

            if (oReader["cat3_rank"] != null)
                oItem.Rank = Int64.Parse(oReader["cat3_rank"].ToString());


            return oItem;

        }
    }
}
