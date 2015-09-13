using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS;
using System.Data;
using RMS.Common;

namespace RMSClient.DataAccess
{
    public class CCategory4DAO : BaseDAO, ICategory4DAO
    {
        #region ICategory4DAO Members

        public RMS.Common.ObjectModel.CResult AddCat4(RMS.Common.ObjectModel.CCategory4 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat4(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Category4 exists with this name.";
                }
                else
                {
                    CResult oResult2 = GetMaxCatOrder();

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {
                        int iTempOrder = (int)oResult2.Data;

                        iTempOrder = iTempOrder + 1;

                        inUser.Category4Name = inUser.Category4Name.Replace("''", "'");
                        inUser.Category4Name = inUser.Category4Name.Replace("'", "''");

                        inUser.Category4Description = inUser.Category4Description.Replace("''", "'");
                        inUser.Category4Description = inUser.Category4Description.Replace("'", "''");


                        this.OpenConnection();
                        string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddCategory4), inUser.Category4Name, inUser.Category3ID, inUser.Category4Description, inUser.Category4TablePrice, inUser.Category4TakeAwayPrice, inUser.Category4BarPrice, inUser.Category4OrderStatus, iTempOrder, inUser.Category4ViewTable, inUser.Category4ViewBar, inUser.Category4ViewTakeAway, inUser.Rank, RMSGlobal.LogInUserName, DateTime.Now.Ticks, inUser.InitialItemQuantity, inUser.UnlimitStatus, inUser.vatIncluded, inUser.vatRate);

                        this.ExecuteNonQuery(sqlCommand);


                        #region "Added By Baruri"

                        Int32 category4_Order = 0;
                        Int32 category3_Order = 0;
                        Int32 category2_id = 0;
                        Int32 category2_order = 0;



                        this.OpenConnection();
                        sqlCommand = "select cat4_order from category4 where cat4_id=(select max(cat4_id) from category4)";
                        IDataReader objcategory3ID = this.ExecuteReader(sqlCommand);
                        if (objcategory3ID != null)
                        {
                            if (objcategory3ID.Read())
                            {
                                category4_Order = Convert.ToInt32(objcategory3ID["cat4_order"]);
                            }
                        }

                        objcategory3ID.Close();

                        sqlCommand = "select cat3_order,cat2_id from category3 where cat3_id=" + inUser.Category3ID;
                        objcategory3ID = this.ExecuteReader(sqlCommand);

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


                        CResult cresultCategoryRank = CalculateCat4Rank(category2_order, category3_Order, category4_Order);
                        Int64 cateRank = Convert.ToInt64(cresultCategoryRank.Data);

                        objcategory3ID.Close();

                        sqlCommand = "update category4 set cat4_rank=" + cateRank + " where cat4_id=(select max(cat4_id) from category4)";
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

        private bool CheckCat4(CCategory4 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat4), inUser.Category4Name, inUser.Category3ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat4_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat4_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCat4ForUpdate(CCategory4 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat4ForUpdate), inUser.Category4Name, inUser.Category3ID, inUser.Category4ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat4_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat4_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCatOrder4(CCategory4 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat4Order), inUser.Category4Order, inUser.Category3ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat4_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat4_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCatOrder4ForUpdate(CCategory4 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat4OrderForUpdate), inUser.Category4Order, inUser.Category3ID, inUser.Category4ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat4_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat4_id"].ToString());

                            return true;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        public RMS.Common.ObjectModel.CResult Cat4Delete(RMS.Common.ObjectModel.CCategory4 oCat)
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

        public RMS.Common.ObjectModel.CResult Cat4Update(RMS.Common.ObjectModel.CCategory4 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat4ForUpdate(oCat);

                if (bTempFlag)
                {
                    oResult.Message = "Category exists with this name.";
                }
                else
                {
                    int iTempCat2Order = 0;

                    int iTempCat3Order = 0;

                    CResult oResult4 = GetCategory2Order(oCat.Category3ID);

                    if (oResult4.IsSuccess && oResult4.Data != null)
                    {


                        CCat4Rank oTempCat4Rank5 = (CCat4Rank)oResult4.Data;

                        iTempCat2Order = oTempCat4Rank5.Category2Order;

                        iTempCat3Order = oTempCat4Rank5.Category3Order;

                    }
                    else
                    {
                        return oResult;
                    }

                    List<int> oTempList = new List<int>();

                    List<int> oTempList2 = new List<int>();

                    CResult oResult2 = GetOrderCandidate(oCat);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        oTempList = (List<int>)oResult2.Data;
                    }

                    CResult oResult3 = GetOrderCandidateLower(oCat, inCatOrder);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {


                        oTempList2 = (List<int>)oResult3.Data;

                    }

                    this.OpenConnectionWithTransection();

                    string sSql = "";

                    int iTempInt = 0;

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int i = 0;

                    for (i = 0; i < oTempList.Count; i++)
                    {
                        iTempInt = oTempList[i];

                        if (iTempInt == oCat.Category4ID)
                        {

                            CCat4Rank oTempCat4Rank5 = new CCat4Rank();

                            oTempCat4Rank5.Category4ID = iTempInt;

                            oTempCat4Rank5.Category4Order = oCat.Category4Order;

                            UpdateCat4Rank(oTempCat4Rank5, iTempCat2Order, iTempCat3Order);


                        }
                        else
                        {

                            iTempInt2 = oCat.Category4Order + 1 + iTempInt3;

                            iTempInt3 = iTempInt3 + 1;

                            CCat4Rank oTempCat4Rank5 = new CCat4Rank();

                            oTempCat4Rank5.Category4ID = iTempInt;

                            oTempCat4Rank5.Category4Order = iTempInt2;

                            UpdateCat4Rank(oTempCat4Rank5, iTempCat2Order, iTempCat3Order);

                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), iTempInt2, iTempInt);
                            this.ExecuteNonQuery(sSql);
                        }
                    }

                    oCat.Category4Name = oCat.Category4Name.Replace("''", "'");
                    oCat.Category4Name = oCat.Category4Name.Replace("'", "''");

                    oCat.Category4Description = oCat.Category4Description.Replace("''", "'");
                    oCat.Category4Description = oCat.Category4Description.Replace("'", "''");


                    sSql = string.Format(SqlQueries.GetQuery(Query.UpdateCategory4), oCat.Category4Name, oCat.Category3ID, oCat.Category4Description, oCat.Category4TablePrice, oCat.Category4TakeAwayPrice, oCat.Category4BarPrice, oCat.Category4OrderStatus, oCat.Category4Order, oCat.Category4ViewTable, oCat.Category4ViewBar, oCat.Category4ViewTakeAway, oCat.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks, oCat.InitialItemQuantity, oCat.UnlimitStatus, oCat.vatIncluded, oCat.vatRate);
                    this.ExecuteNonQuery(sSql);

                    iTempInt3 = 1;

                    sSql = "";


                    for (i = 0; i < oTempList2.Count; i++)
                    {
                        iTempInt = oTempList2[i];

                        if (iTempInt == oCat.Category4ID)
                        {

                            CCat4Rank oTempCat4Rank5 = new CCat4Rank();

                            oTempCat4Rank5.Category4ID = iTempInt;

                            oTempCat4Rank5.Category4Order = oCat.Category4Order;

                            UpdateCat4Rank(oTempCat4Rank5, iTempCat2Order, iTempCat3Order);
                        }
                        else
                        {

                            iTempInt2 = inCatOrder + iTempInt3 - 1;

                            iTempInt3 = iTempInt3 + 1;

                            CCat4Rank oTempCat4Rank6 = new CCat4Rank();

                            oTempCat4Rank6.Category4ID = iTempInt;

                            oTempCat4Rank6.Category4Order = iTempInt2;

                            UpdateCat4Rank(oTempCat4Rank6, iTempCat2Order, iTempCat3Order);


                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), iTempInt2, iTempInt);
                            this.ExecuteNonQuery(sSql);
                        }
                    }

                    this.CommitTransection();
                    oResult.IsSuccess = true;

                }

                //this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.UpdateCategory4), oCat.Category4Name, oCat.Category3ID, oCat.Category4Description, oCat.Category4TablePrice, oCat.Category4TakeAwayPrice, oCat.Category4BarPrice, oCat.Category4OrderStatus, oCat.Category4Order, oCat.Category4ViewTable, oCat.Category4ViewBar, oCat.Category4ViewTakeAway, oCat.Rank, oCat.Category4ID);
                //this.ExecuteNonQuery(sSql);

                //oResult.IsSuccess = true;
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
            CCategory4 objSelectionItem = new CCategory4();

            if (oReader["cat4_id"] != null)
                objSelectionItem.Category4ID = Int32.Parse(oReader["cat4_id"].ToString());

            if (oReader["cat4_name"] != null)
                objSelectionItem.Category4Name = oReader["cat4_name"].ToString();

            if (oReader["cat3_id"] != null)
                objSelectionItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["description"] != null)
                objSelectionItem.Category4Description = oReader["description"].ToString();

            if (oReader["table_price"] != null)
                objSelectionItem.Category4TablePrice = Double.Parse(oReader["table_price"].ToString());

            if (oReader["tw_price"] != null)
                objSelectionItem.Category4TakeAwayPrice = Double.Parse(oReader["tw_price"].ToString());

            if (oReader["bar_price"] != null)
                objSelectionItem.Category4BarPrice = Double.Parse(oReader["bar_price"].ToString());

            if (oReader["status"] != null)
                objSelectionItem.Category4OrderStatus = Int32.Parse(oReader["status"].ToString());

            if (oReader["cat4_order"] != null)
                objSelectionItem.Category4Order = Int32.Parse(oReader["cat4_order"].ToString());

            if (oReader["view_table"] != null)
                objSelectionItem.Category4ViewTable = Int32.Parse(oReader["view_table"].ToString());

            if (oReader["view_bar"] != null)
                objSelectionItem.Category4ViewBar = Int32.Parse(oReader["view_bar"].ToString());

            if (oReader["view_takeaway"] != null)
                objSelectionItem.Category4ViewTakeAway = Int32.Parse(oReader["view_takeaway"].ToString());

            if (oReader["slection_item_stock_quantity"] != null)
                objSelectionItem.InitialItemQuantity = Int32.Parse("0"+oReader["slection_item_stock_quantity"].ToString());
           
            if (oReader["unlimited_status"] != null)
                objSelectionItem.UnlimitStatus = Convert.ToInt32(oReader["unlimited_status"]);

            //Vat 
            if (oReader["vat_Rate"] != null)
                objSelectionItem.vatRate = Double.Parse(oReader["vat_Rate"].ToString());

            if (oReader["vat_included"] != null)
                objSelectionItem.vatIncluded = Convert.ToBoolean(oReader["vat_included"].ToString());


            if (oReader["cat4_rank"] != null)
            {
                String sTempStr = oReader["cat4_rank"].ToString();

                if (!sTempStr.Equals(String.Empty))
                {
                    objSelectionItem.Rank = Int64.Parse(sTempStr);
                }
            }

            return objSelectionItem;

        }

        public RMS.Common.ObjectModel.CResult Cat4UpdateOrderDown(RMS.Common.ObjectModel.CCategory4 oCat, RMS.Common.ObjectModel.CCategory4 oCat2)
        {
            CResult oResult = new CResult();

            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();


                int iTempCat2Order = 0;

                int iTempCat3Order = 0;

                CResult oResult4 = GetCategory2Order(oCat.Category3ID);

                if (oResult4.IsSuccess && oResult4.Data != null)
                {


                    CCat4Rank oTempCat4Rank5 = (CCat4Rank)oResult4.Data;

                    iTempCat2Order = oTempCat4Rank5.Category2Order;

                    iTempCat3Order = oTempCat4Rank5.Category3Order;

                }
                else
                {
                    return oResult;
                }

                this.OpenConnectionWithTransection();

                CCat4Rank oTempCat4Rank6 = new CCat4Rank();

                oTempCat4Rank6.Category4ID = oCat.Category4ID;

                oTempCat4Rank6.Category4Order = oCat2.Category4Order;

                UpdateCat4Rank(oTempCat4Rank6, iTempCat2Order, iTempCat3Order);


                CCat4Rank oTempCat4Rank8 = new CCat4Rank();

                oTempCat4Rank8.Category4ID = oCat2.Category4ID;

                oTempCat4Rank8.Category4Order = oCat.Category4Order;

                UpdateCat4Rank(oTempCat4Rank8, iTempCat2Order, iTempCat3Order);




                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oConstants.MaxOrderChange, oCat.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oCat.Category4Order, oCat2.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oCat2.Category4Order, oCat.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
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
                string sSql = SqlQueries.GetQuery(Query.GetMaxCat4Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["max_cat4_order"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["max_cat4_order"].ToString());

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

        public RMS.Common.ObjectModel.CResult Cat4UpdateOrderUp(RMS.Common.ObjectModel.CCategory4 oCat, RMS.Common.ObjectModel.CCategory4 oCat2)
        {
            CResult oResult = new CResult();


            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();


                int iTempCat2Order = 0;

                int iTempCat3Order = 0;

                CResult oResult4 = GetCategory2Order(oCat.Category3ID);

                if (oResult4.IsSuccess && oResult4.Data != null)
                {


                    CCat4Rank oTempCat4Rank5 = (CCat4Rank)oResult4.Data;

                    iTempCat2Order = oTempCat4Rank5.Category2Order;

                    iTempCat3Order = oTempCat4Rank5.Category3Order;

                }
                else
                {
                    return oResult;
                }

                this.OpenConnectionWithTransection();

                CCat4Rank oTempCat4Rank7 = new CCat4Rank();

                oTempCat4Rank7.Category4ID = oCat.Category4ID;

                oTempCat4Rank7.Category4Order = oCat2.Category4Order;

                UpdateCat4Rank(oTempCat4Rank7, iTempCat2Order, iTempCat3Order);


                CCat4Rank oTempCat4Rank6 = new CCat4Rank();

                oTempCat4Rank6.Category4ID = oCat2.Category4ID;

                oTempCat4Rank6.Category4Order = oCat.Category4Order;

                UpdateCat4Rank(oTempCat4Rank6, iTempCat2Order, iTempCat3Order);



                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oConstants.MaxOrderChange, oCat2.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oCat2.Category4Order, oCat.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory4Order), oCat.Category4Order, oCat2.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
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

        public RMS.Common.ObjectModel.CResult GetCategory4(int inCat4ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory4), inCat4ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        CCategory4 oCat = ReaderToCategory4(oReader);

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

        public RMS.Common.ObjectModel.CResult GetCategory4(RMS.Common.ObjectModel.CCategory4 inCat)
        {
            CResult oResult = null;
            try
            {
                this.OpenConnection();
                string sSql = "";// string.Format(SqlQueries.GetQuery(Query), gItemId);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                        inCat = ReaderToCategory4(oReader);
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

        public RMS.Common.ObjectModel.CResult GetCategory4All()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory4All));
                IDataReader oReader = this.ExecuteReader(sSql);
                List<CCategory4> oCat4List = new List<CCategory4>();
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory4 oCat = ReaderToCategory4(oReader);
                        oCat4List.Add(oCat);
                    }
                }

                oResult.Data = oCat4List;
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

        private CResult GetOrderCandidateLower(CCategory4 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                if (oCat.Category4Order <= inCatOrder)
                {

                    oResult.Data = iTempList;

                    oResult.IsSuccess = true;
                }
                else
                {

                    this.OpenConnection();
                    string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat4OrderCandidateLower), oCat.Category3ID, inCatOrder, oCat.Category4Order);
                    IDataReader oReader = this.ExecuteReader(sSql);
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            if (oReader["cat4_id"] != null)
                            {
                                int iTempInt = Int32.Parse(oReader["cat4_id"].ToString());

                                iTempList.Add(iTempInt);


                            }

                        }

                        oResult.Data = iTempList;

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


        private CResult GetOrderCandidate(CCategory4 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat4OrderCandidate), oCat.Category3ID, oCat.Category4Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["cat4_id"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["cat4_id"].ToString());

                            iTempList.Add(iTempInt);


                        }

                    }

                    oResult.Data = iTempList;

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


        private void UpdateChildCat3Rank(List<CCat3Rank> inList, int inCat2Order)
        {
            for (int i = 0; i < inList.Count; i++)
            {
                CCat3Rank oTempCat3Rank = inList[i];

                CResult oResult = CalculateCat3Rank(inCat2Order, oTempCat3Rank.Category3Order);

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    Int64 iTempRank = (Int64)oResult.Data;

                    String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat3Rank), iTempRank, oTempCat3Rank.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);
                }

            }
        }


        private void UpdateCat4Rank(CCat4Rank inList, int inCat2Order, int inCat3Order)
        {

            CCat4Rank oTempCat3Rank = inList;

            CResult oResult = CalculateCat4Rank(inCat2Order, inCat3Order, oTempCat3Rank.Category4Order);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                Int64 iTempRank = (Int64)oResult.Data;

                String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat4Rank), iTempRank, oTempCat3Rank.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);
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

        private CCat4Rank ReaderToCat4Rank2(IDataReader oReader)
        {
            CCat4Rank oItem = new CCat4Rank();

            if (oReader["cat2_order"] != null)
                oItem.Category2Order = Int32.Parse(oReader["cat2_order"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());


            return oItem;

        }


        private CResult GetCategory2Order(int inCat2ID)
        {
            CResult oResult = new CResult();


            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory23Order), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {

                        // int iTempInt = Int32.Parse(oReader["cat2_order"].ToString());

                        CCat4Rank oTempCat4Rank = ReaderToCat4Rank2(oReader);

                        oResult.Data = oTempCat4Rank;

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


        #endregion
    }
}
