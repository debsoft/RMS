using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS.Common;


namespace RMS.DataAccess
{
    public class CCategory3DAO : BaseDAO, ICategory3DAO
    {

        #region ICategory3DAO Members

        public RMS.Common.ObjectModel.CResult AddCat3(RMS.Common.ObjectModel.CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat3(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Category exists with this name.";
                }
                else
                {
                    CResult oResult2 = GetMaxCatOrder();

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {
                        int iTempOrder = (int)oResult2.Data;

                        iTempOrder = iTempOrder + 1;

                        inUser.Category3Name = inUser.Category3Name.Replace("''", "'");
                        inUser.Category3Name = inUser.Category3Name.Replace("'", "''");

                        inUser.Category3Description = inUser.Category3Description.Replace("''", "'");
                        inUser.Category3Description = inUser.Category3Description.Replace("'", "''");

                        this.OpenConnection();
                        string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddCategory3), inUser.Category3Name, inUser.Category2ID, inUser.Category3Description, inUser.Category3TablePrice, inUser.Category3TakeAwayPrice, inUser.Category3BarPrice, inUser.Category3OrderStatus, iTempOrder, inUser.Category3ViewTable, inUser.Category3ViewBar, inUser.Category3ViewTakeAway, inUser.Rank, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                        this.ExecuteNonQuery(sqlCommand);


                        #region "Added By Baruri"

                        Int32 category3_Order = 0;
                        Int32 category2_id = 0;
                        Int32 category2_order = 0;


                        this.OpenConnection();
                        sqlCommand = "select cat3_order,cat2_id from category3 where cat3_id=(select max(cat3_id) from category3)";
                        IDataReader objcategory3ID = this.ExecuteReader(sqlCommand);
                        if (objcategory3ID != null)
                        {
                            if (objcategory3ID.Read())
                            {
                                category3_Order = Convert.ToInt32(objcategory3ID["cat3_order"]);
                                category2_id = Convert.ToInt32(objcategory3ID["cat2_id"]);
                            }
                        }

                        objcategory3ID.Close();

                        sqlCommand = "select cat2_order from category2 where cat2_id=" + category2_id;
                        objcategory3ID = this.ExecuteReader(sqlCommand);

                        if (objcategory3ID != null)
                        {
                            if (objcategory3ID.Read())
                            {
                                category2_order = Convert.ToInt32(objcategory3ID["cat2_order"]);
                            }
                        }


                        CResult cresultCategoryRank = CalculateCat3Rank(category2_order, category3_Order);
                        Int64 cateRank = Convert.ToInt64(cresultCategoryRank.Data);

                        objcategory3ID.Close();

                        sqlCommand = "update category3 set cat3_rank=" + cateRank + " where cat3_id=(select max(cat3_id) from category3)";
                        this.ExecuteNonQuery(sqlCommand);

                        this.CloseConnection();

                        #endregion


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

        private bool CheckCat3(CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat3), inUser.Category3Name, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat3_id"].ToString());

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

        private bool CheckCat3ForUpdate(CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat3ForUpdate), inUser.Category3Name, inUser.Category2ID, inUser.Category3ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat3_id"].ToString());

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

        private bool CheckCatOrder3(CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat3Order), inUser.Category3Order, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat3_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);

                oResult.IsException = true;

                oResult.Message = ex.Message;
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCatOrder3ForUpdate(CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat3OrderForUpdate), inUser.Category3Order, inUser.Category2ID, inUser.Category3ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat3_id"].ToString());

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



        public RMS.Common.ObjectModel.CResult Cat3Delete(RMS.Common.ObjectModel.CCategory3 oCat)
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

        private CResult GetOrderCandidateSingle(CCategory3 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                //CCat3Rank oTempCat2List = new CCat3Rank();


                this.OpenConnection();


                // CResult oResult2 = GetChildCat3(iTempCat2ID);

                CCat3Rank oTempCat2Rank = new CCat3Rank();

                oTempCat2Rank.Category3ID = oCat.Category3ID;

                CResult oResult3 = GetChildCat4ByCat3(oCat.Category3ID);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {
                    List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                    oTempCat2Rank.ChildCat4List = oTempChildList2;
                }

                //oTempCat2List.Add(oTempCat2Rank);


                oResult.Data = oTempCat2Rank;

                oResult.IsSuccess = true;



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

        private CResult GetChildCat4ByCat3(int inCat2ID)
        {
            CResult oResult = new CResult();

            List<CCat4Rank> oTempList = new List<CCat4Rank>();

            try
            {

                string sSql = string.Format(SqlQueries.GetQuery(Query.GetChildCat4ByCat3), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCat4Rank oCat2 = ReaderToCat4Rank(oReader);

                        oTempList.Add(oCat2);

                    }

                    oReader.Close();

                    oResult.Data = oTempList;

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
            }

            return oResult;
        }

        private CResult GetCategory2Order(int inCat2ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory2Order), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat2_order"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["cat2_order"].ToString());

                            oResult.Data = iTempInt;

                            oResult.IsSuccess = true;
                        }

                    }
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

        public RMS.Common.ObjectModel.CResult Cat3Update(RMS.Common.ObjectModel.CCategory3 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();

            try
            {

                bool bTempFlag = CheckCat3ForUpdate(oCat);

                if (bTempFlag)
                {
                    oResult.Message = "Category exists with this name.";
                }
                else
                {
                    List<CCat3Rank> oTempList = new List<CCat3Rank>();

                    List<CCat3Rank> oTempList2 = new List<CCat3Rank>();

                    int iTempCat2Order = 0;

                    CResult oResult4 = GetCategory2Order(oCat.Category2ID);

                    if (oResult4.IsSuccess && oResult4.Data != null)
                    {


                        iTempCat2Order = (int)oResult4.Data;
                    }
                    else
                    {
                        return oResult;
                    }



                    CResult oResult2 = GetOrderCandidate(oCat);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        oTempList = (List<CCat3Rank>)oResult2.Data;

                    }

                    CResult oResult3 = GetOrderCandidateLower(oCat, inCatOrder);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {


                        oTempList2 = (List<CCat3Rank>)oResult3.Data;

                    }


                    this.OpenConnectionWithTransection();

                    string sSql = "";

                    int iTempInt = 0;

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int i = 0;

                    for (i = 0; i < oTempList.Count; i++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList[i];

                        if (oTempCat3Rank.Category3ID == oCat.Category3ID)
                        {

                            iTempInt2 = oCat.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);


                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat.Category3Order);
                            }

                            // sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID);
                            // this.ExecuteNonQuery(sSql);
                        }
                        else
                        {

                            iTempInt2 = oCat.Category3Order + 1 + iTempInt3;

                            iTempInt3 = iTempInt3 + 1;


                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, iTempInt2);
                            }

                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sSql);
                        }
                    }

                    oCat.Category3Name = oCat.Category3Name.Replace("''", "'");
                    oCat.Category3Name = oCat.Category3Name.Replace("'", "''");

                    oCat.Category3Description = oCat.Category3Description.Replace("''", "'");
                    oCat.Category3Description = oCat.Category3Description.Replace("'", "''");


                    sSql = string.Format(SqlQueries.GetQuery(Query.UpdateCategory3), oCat.Category3Name, oCat.Category2ID, oCat.Category3Description, oCat.Category3TablePrice, oCat.Category3TakeAwayPrice, oCat.Category3BarPrice, oCat.Category3OrderStatus, oCat.Category3Order, oCat.Category3ViewTable, oCat.Category3ViewBar, oCat.Category3ViewTakeAway, oCat.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);

                    sSql = "";

                    iTempInt3 = 1;


                    for (i = 0; i < oTempList2.Count; i++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList2[i];

                        if (oTempCat3Rank.Category3ID == oCat.Category3ID)
                        {

                            iTempInt2 = oCat.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, oCat.Category3Order);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat.Category3Order);
                            }

                            //sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID);
                            //this.ExecuteNonQuery(sSql);

                        }
                        else
                        {

                            iTempInt2 = inCatOrder + iTempInt3 - 1;

                            iTempInt3 = iTempInt3 + 1;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, iTempInt2);
                            }

                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sSql);


                            // sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID);
                            // this.ExecuteNonQuery(sSql);
                        }
                    }




                    this.CommitTransection();



                    oResult.IsSuccess = true;

                }


                //oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in Cat3Update()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at Cat3Update()", ex);
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
                oItem.Category3ViewTakeAway = Int32.Parse(oReader["view_takeaway"].ToString());

            //if (oReader["cat3_rank"] != null)
            //    oItem.Rank = Int64.Parse(oReader["cat3_rank"].ToString());

            if (oReader["cat3_rank"] != null)
            {
                String sTempStr = oReader["cat3_rank"].ToString();

                if (!sTempStr.Equals(String.Empty))
                {
                    oItem.Rank = Int64.Parse(sTempStr);
                }
            }

            return oItem;

        }

        public RMS.Common.ObjectModel.CResult Cat3UpdateOrderDown(RMS.Common.ObjectModel.CCategory3 oCat, RMS.Common.ObjectModel.CCategory3 oCat2)
        {
            CResult oResult = new CResult();

            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

                int iTempCat2Order = 0;

                CCat3Rank oTempList = new CCat3Rank();

                CCat3Rank oTempList2 = new CCat3Rank();

                CResult oResult4 = GetCategory2Order(oCat.Category2ID);

                if (oResult4.IsSuccess && oResult4.Data != null)
                {


                    iTempCat2Order = (int)oResult4.Data;
                }
                else
                {
                    return oResult;
                }


                CResult oResult2 = GetOrderCandidateSingle(oCat);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {


                    oTempList = (CCat3Rank)oResult2.Data;
                }


                CResult oResult3 = GetOrderCandidateSingle(oCat2);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {

                    oTempList2 = (CCat3Rank)oResult3.Data;
                }


                this.OpenConnectionWithTransection();

                //for (int i = 0; i < oTempList.Count; i++)
                //{
                //   CCat3Rank oTempCat2Rank = oTempList[i];

                UpdateCat3Rank(oTempList, iTempCat2Order, oCat2.Category3Order);

                List<CCat4Rank> oTempCat4List = oTempList.ChildCat4List;

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat2.Category3Order);
                }

                // }

                //  for (int i = 0; i < oTempList2.Count; i++)
                //  {
                //  CCat3Rank oTempCat2Rank = oTempList2[i]; 

                UpdateCat3Rank(oTempList2, iTempCat2Order, oCat.Category3Order);

                oTempCat4List = oTempList2.ChildCat4List;

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat.Category3Order);
                }

                //}


                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oConstants.MaxOrderChange, oCat.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oCat.Category3Order, oCat2.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oCat2.Category3Order, oCat.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                this.RollBackTransection();

            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        private CResult GetMaxCatOrder()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.GetMaxCat3Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["max_cat3_order"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["max_cat3_order"].ToString());

                            oResult.Data = iTempInt;

                            oResult.IsSuccess = true;
                        }

                    }
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

        public RMS.Common.ObjectModel.CResult Cat3UpdateOrderUp(RMS.Common.ObjectModel.CCategory3 oCat, RMS.Common.ObjectModel.CCategory3 oCat2)
        {
            CResult oResult = new CResult();


            try
            {
                int iTempCat2Order = 0;

                CCat3Rank oTempList = new CCat3Rank();

                CCat3Rank oTempList2 = new CCat3Rank();

                CResult oResult4 = GetCategory2Order(oCat.Category2ID);

                if (oResult4.IsSuccess && oResult4.Data != null)
                {


                    iTempCat2Order = (int)oResult4.Data;
                }
                else
                {
                    return oResult;
                }


                CResult oResult2 = GetOrderCandidateSingle(oCat);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {


                    oTempList = (CCat3Rank)oResult2.Data;
                }


                CResult oResult3 = GetOrderCandidateSingle(oCat2);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {

                    oTempList2 = (CCat3Rank)oResult3.Data;
                }

                int i = 0;

                this.OpenConnectionWithTransection();

                //for ( i = 0; i < oTempList.Count; i++)
                //{
                // CCat3Rank oTempCat2Rank = oTempList[i];  

                UpdateCat3Rank(oTempList, iTempCat2Order, oCat2.Category3Order);

                List<CCat4Rank> oTempCat4List = oTempList.ChildCat4List;

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat2.Category3Order);
                }

                // }

                // for ( i = 0; i < oTempList2.Count; i++)
                // {
                // oTempCat2Rank = oTempList2[i];   

                UpdateCat3Rank(oTempList2, iTempCat2Order, oCat.Category3Order);

                oTempCat4List = oTempList2.ChildCat4List;

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, oCat.Category3Order);
                }

                // }

                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oConstants.MaxOrderChange, oCat2.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oCat2.Category3Order, oCat.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), oCat.Category3Order, oCat2.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                this.RollBackTransection();

            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public RMS.Common.ObjectModel.CResult GetCategory3(int inCat3ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory3), inCat3ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        CCategory3 oCat = ReaderToCategory3(oReader);

                        oResult.Data = oCat;

                        oResult.IsSuccess = true;
                    }
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

        public RMS.Common.ObjectModel.CResult GetCategory3All()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory3All));
                IDataReader oReader = this.ExecuteReader(sSql);
                List<CCategory3> oCat3List = new List<CCategory3>();
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory3 oCat = ReaderToCategory3(oReader);
                        oCat3List.Add(oCat);
                    }
                }

                oResult.Data = oCat3List;
                oResult.IsSuccess = true;

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

        private CResult GetOrderCandidateLower(CCategory3 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat3Rank> oTempCat3List = new List<CCat3Rank>();

                if (oCat.Category3Order <= inCatOrder)
                {

                    oResult.Data = oTempCat3List;

                    oResult.IsSuccess = true;
                }
                else
                {

                    this.OpenConnection();
                    string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat3OrderCandidateLower), oCat.Category2ID, inCatOrder, oCat.Category3Order);
                    IDataReader oReader = this.ExecuteReader(sSql);
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            if (oReader["cat3_id"] != null)
                            {
                                int iTempInt = Int32.Parse(oReader["cat3_id"].ToString());

                                iTempList.Add(iTempInt);


                            }

                        }

                        oReader.Close();

                        for (int i = 0; i < iTempList.Count; i++)
                        {
                            int iTempCat2ID = iTempList[i];

                            // CResult oResult2 = GetChildCat3(iTempCat2ID);

                            CCat3Rank oTempCat2Rank = new CCat3Rank();

                            oTempCat2Rank.Category3ID = iTempCat2ID;

                            CResult oResult3 = GetChildCat4ByCat3(iTempCat2ID);

                            if (oResult3.IsSuccess && oResult3.Data != null)
                            {
                                List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                                oTempCat2Rank.ChildCat4List = oTempChildList2;
                            }

                            oTempCat3List.Add(oTempCat2Rank);
                        }

                        oResult.Data = oTempCat3List;

                        oResult.IsSuccess = true;
                    }
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

        private CResult GetOrderCandidate(CCategory3 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat3Rank> oTempCat3List = new List<CCat3Rank>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat3OrderCandidate), oCat.Category2ID, oCat.Category3Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["cat3_id"].ToString());

                            iTempList.Add(iTempInt);


                        }

                    }

                    oReader.Close();


                    for (int i = 0; i < iTempList.Count; i++)
                    {
                        int iTempCat2ID = iTempList[i];

                        // CResult oResult2 = GetChildCat3(iTempCat2ID);

                        CCat3Rank oTempCat2Rank = new CCat3Rank();

                        oTempCat2Rank.Category3ID = iTempCat2ID;

                        CResult oResult3 = GetChildCat4ByCat3(iTempCat2ID);

                        if (oResult3.IsSuccess && oResult3.Data != null)
                        {
                            List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                            oTempCat2Rank.ChildCat4List = oTempChildList2;
                        }

                        oTempCat3List.Add(oTempCat2Rank);
                    }

                    oResult.Data = oTempCat3List;

                    oResult.IsSuccess = true;
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


        private void UpdateCat3Rank(CCat3Rank inList, int inCat2Order, int inCat3Order)
        {

            CCat3Rank oTempCat3Rank = inList;

            CResult oResult = CalculateCat3Rank(inCat2Order, inCat3Order);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                Int64 iTempRank = (Int64)oResult.Data;

                String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat3Rank), iTempRank, oTempCat3Rank.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);
            }


        }


        private void UpdateChildCat4Rank(List<CCat4Rank> inList, int inCat2Order, int inCat3Order)
        {
            for (int i = 0; i < inList.Count; i++)
            {
                CCat4Rank oTempCat3Rank = inList[i];

                CResult oResult = CalculateCat4Rank(inCat2Order, inCat3Order, oTempCat3Rank.Category4Order);

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    Int64 iTempRank = (Int64)oResult.Data;

                    String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat4Rank), iTempRank, oTempCat3Rank.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);
                }


            }
        }

        private CResult CalculateCat4Rank(int inCat2Order, int inCat3Order, int inCat4Order)
        {
            CResult oResult = new CResult();

            String sTempStr = "";

            try
            {
                if (inCat2Order < 10 && inCat2Order > 0)
                {
                    sTempStr = "00000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100)
                {
                    sTempStr = "0000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000)
                {
                    sTempStr = "000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 10000)
                {
                    sTempStr = "00" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100000)
                {
                    sTempStr = "0" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000000)
                {
                    sTempStr = inCat2Order.ToString().Trim();
                }
                else
                {
                }


                if (inCat3Order < 10 && inCat3Order > 0)
                {
                    sTempStr += "00000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100)
                {
                    sTempStr += "0000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000)
                {
                    sTempStr += "000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 10000)
                {
                    sTempStr += "00" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100000)
                {
                    sTempStr += "0" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000000)
                {
                    sTempStr += inCat3Order.ToString().Trim();
                }
                else
                {
                }


                if (inCat4Order < 10 && inCat4Order > 0)
                {
                    sTempStr += "00000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 100)
                {
                    sTempStr += "0000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 1000)
                {
                    sTempStr += "000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 10000)
                {
                    sTempStr += "00" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 100000)
                {
                    sTempStr += "0" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 1000000)
                {
                    sTempStr += inCat4Order.ToString().Trim();
                }
                else
                {
                }

                Int64 iTempInt;

                bool bTempFlag = Int64.TryParse(sTempStr, out iTempInt);

                if (bTempFlag)
                {
                    oResult.Data = iTempInt;

                    oResult.IsSuccess = true;
                }


            }
            catch (Exception ex)
            {
            }

            return oResult;
        }

        private CResult CalculateCat3Rank(int inCat2Order, int inCat3Order)
        {
            CResult oResult = new CResult();

            String sTempStr = "";

            try
            {
                if (inCat2Order < 10 && inCat2Order > 0)
                {
                    sTempStr = "00000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100)
                {
                    sTempStr = "0000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000)
                {
                    sTempStr = "000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 10000)
                {
                    sTempStr = "00" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100000)
                {
                    sTempStr = "0" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000000)
                {
                    sTempStr = inCat2Order.ToString().Trim();
                }
                else
                {
                }


                if (inCat3Order < 10 && inCat3Order > 0)
                {
                    sTempStr += "00000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100)
                {
                    sTempStr += "0000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000)
                {
                    sTempStr += "000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 10000)
                {
                    sTempStr += "00" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100000)
                {
                    sTempStr += "0" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000000)
                {
                    sTempStr += inCat3Order.ToString().Trim();
                }
                else
                {
                }


                sTempStr += "000000";

                Int64 iTempInt;

                bool bTempFlag = Int64.TryParse(sTempStr, out iTempInt);

                if (bTempFlag)
                {
                    oResult.Data = iTempInt;

                    oResult.IsSuccess = true;
                }


            }
            catch (Exception ex)
            {
            }

            return oResult;
        }


        private CCat4Rank ReaderToCat4Rank(IDataReader oReader)
        {
            CCat4Rank oItem = new CCat4Rank();

            if (oReader["cat4_id"] != null)
                oItem.Category4ID = Int32.Parse(oReader["cat4_id"].ToString());

            if (oReader["cat4_order"] != null)
                oItem.Category4Order = Int32.Parse(oReader["cat4_order"].ToString());


            return oItem;

        }

        private CCat3Rank ReaderToCat3Rank(IDataReader oReader)
        {
            CCat3Rank oItem = new CCat3Rank();

            if (oReader["cat3_id"] != null)
                oItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());


            return oItem;

        }



        #endregion
    }
}
