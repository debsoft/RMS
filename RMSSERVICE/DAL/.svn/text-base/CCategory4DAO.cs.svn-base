using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using RMS.Common.DataAccess;
using RMS;
using System.Data;

namespace RMSClient.DataAccess
{
    public class CCategory4DAO : BaseDAO, ICategory4DAO
    {

        public CResult Cat4Delete(CCategory4 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory4), oCat.Category4ID);
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

        public CResult AddCat4(CCategory4 inUser)
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

        private bool CheckCat(CCategory4 inUser)
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

        private bool CheckCatOrder(CCategory4 inUser)
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

        public CResult GetCategory4(CCategory4 inCat)
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
                //        oItem = ReaderToCategory4(oReader);
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

        public CResult Cat4Update(CCategory4 oCat)
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


        private CCategory4 ReaderToCategory4(IDataReader oReader)
        {
            CCategory4 oItem = new CCategory4();



            if (oReader["cat4_id"] != null)
                oItem.Category4ID = Int32.Parse(oReader["cat4_id"].ToString());

            if (oReader["cat4_name"] != null)
                oItem.Category4Name = oReader["cat4_name"].ToString();

            if (oReader["cat3_id"] != null)
                oItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["description"] != null)
                oItem.Category4Description = oReader["description"].ToString();

            if (oReader["table_price"] != null)
                oItem.Category4TablePrice = Double.Parse(oReader["table_price"].ToString());

            if (oReader["tw_price"] != null)
                oItem.Category4TakeAwayPrice = Double.Parse(oReader["tw_price"].ToString());

            if (oReader["bar_price"] != null)
                oItem.Category4BarPrice = Double.Parse(oReader["bar_price"].ToString());

            if (oReader["status"] != null)
                oItem.Category4OrderStatus = Int32.Parse(oReader["status"].ToString());

            if (oReader["cat4_order"] != null)
                oItem.Category4Order = Int32.Parse(oReader["cat4_order"].ToString());


            if (oReader["view_table"] != null)
                oItem.Category4ViewTable = Int32.Parse(oReader["view_table"].ToString());

            if (oReader["view_bar"] != null)
                oItem.Category4ViewBar = Int32.Parse(oReader["view_bar"].ToString());

            if (oReader["view_takeaway"] != null)
                oItem.Category4TakeAwayPrice = Int32.Parse(oReader["view_takeaway"].ToString());

            if (oReader["cat4_rank"] != null)
                oItem.Rank= Int64.Parse(oReader["cat4_rank"].ToString());



            return oItem;

        }
    }
}
