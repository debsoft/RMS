using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS;
using RMS.Common;

namespace RMS.DataAccess
{
    public class CCategory2DAO : BaseDAO, ICategory2DAO
    {
        #region ICategory2DAO Members

        public RMS.Common.ObjectModel.CResult AddCat2(RMS.Common.ObjectModel.CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Category2 exists with this name.";
                }
                else
                {
                    CResult oResult2 = GetMaxCatOrder();

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {
                        int iTempOrder = (int)oResult2.Data;

                        iTempOrder = iTempOrder + 1;

                        inUser.Category2Name = inUser.Category2Name.Replace("''", "'");
                        inUser.Category2Name = inUser.Category2Name.Replace("'", "''");

                        this.OpenConnection();
                        string sSql = String.Format(SqlQueries.GetQuery(Query.AddCategory2), inUser.Category2Name, inUser.Category1ID, iTempOrder, inUser.Category2Type, inUser.Category2Color, inUser.Category2ViewTable, inUser.Category2ViewBar, inUser.Category2ViewTakeAway, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

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

        private CResult GetMaxCatOrder()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.GetMaxCat2Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["max_cat2_order"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["max_cat2_order"].ToString());

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

        public RMS.Common.ObjectModel.CResult Cat2Delete(RMS.Common.ObjectModel.CCategory2 oCat)
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

                //throw new Exception("Exception occure at ItemDelete()", ex);

                oResult.IsException = true;

                oResult.Message = ex.Message;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public RMS.Common.ObjectModel.CResult Cat2Update(RMS.Common.ObjectModel.CCategory2 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat2ForUpdate(oCat);

                if (bTempFlag)
                {
                    oResult.Message = "Category exists with this name.";
                }
                else
                {
                    oCat.Category2Name = oCat.Category2Name.Replace("''", "'");
                    oCat.Category2Name = oCat.Category2Name.Replace("'", "''");

                    List<CCat2Rank> oTempList = new List<CCat2Rank>();

                    List<CCat2Rank> oTempList2 = new List<CCat2Rank>();


                    CResult oResult3 = GetOrderCandidateLower(oCat, inCatOrder);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {

                        oTempList2 = (List<CCat2Rank>)oResult3.Data;
                    }

                    CResult oResult2 = GetOrderCandidate(oCat);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        oTempList = (List<CCat2Rank>)oResult2.Data;
                    }



                    this.OpenConnectionWithTransection();

                    string sSql = "";

                    int iTempInt = 0;

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int i = 0;

                    for (i = 0; i < oTempList.Count; i++)
                    {
                        CCat2Rank oTempCat2Rank = oTempList[i];

                        if (oTempCat2Rank.Category2ID == oCat.Category2ID)
                        {

                            iTempInt2 = oCat.Category2Order;


                            //iTempInt3 = iTempInt3 + 1;

                            List<CCat3Rank> oTempCat3List = oTempCat2Rank.ChildCat3List;

                            List<CCat4Rank> oTempCat4List = oTempCat2Rank.ChildCat4List;

                            if (oTempCat3List.Count > 0)
                            {
                                UpdateChildCat3Rank(oTempCat3List, iTempInt2);
                            }

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempInt2);
                            }

                        }
                        else
                        {

                            iTempInt2 = oCat.Category2Order + 1 + iTempInt3;


                            iTempInt3 = iTempInt3 + 1;

                            List<CCat3Rank> oTempCat3List = oTempCat2Rank.ChildCat3List;

                            List<CCat4Rank> oTempCat4List = oTempCat2Rank.ChildCat4List;

                            if (oTempCat3List.Count > 0)
                            {
                                UpdateChildCat3Rank(oTempCat3List, iTempInt2);
                            }

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempInt2);
                            }

                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), iTempInt2, oTempCat2Rank.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sSql);
                        }
                    }

                    sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2), oCat.Category2Name, oCat.Category1ID, oCat.Category2Order, oCat.Category2Type, oCat.Category2Color, oCat.Category2ViewTable, oCat.Category2ViewBar, oCat.Category2ViewTakeAway, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);

                    //this.CommitTransection();          

                    sSql = "";

                    iTempInt3 = 1;

                    for (i = 0; i < oTempList2.Count; i++)
                    {
                        CCat2Rank oTempCat2Rank = oTempList2[i];

                        if (oTempCat2Rank.Category2ID == oCat.Category2ID)
                        {

                            iTempInt2 = oCat.Category2Order;


                            //iTempInt3 = iTempInt3 + 1;

                            List<CCat3Rank> oTempCat3List = oTempCat2Rank.ChildCat3List;

                            List<CCat4Rank> oTempCat4List = oTempCat2Rank.ChildCat4List;

                            if (oTempCat3List.Count > 0)
                            {
                                UpdateChildCat3Rank(oTempCat3List, iTempInt2);
                            }

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempInt2);
                            }
                        }
                        else
                        {

                            iTempInt2 = inCatOrder + iTempInt3 - 1;

                            iTempInt3 = iTempInt3 + 1;

                            List<CCat3Rank> oTempCat3List = oTempCat2Rank.ChildCat3List;

                            List<CCat4Rank> oTempCat4List = oTempCat2Rank.ChildCat4List;

                            if (oTempCat3List.Count > 0)
                            {
                                UpdateChildCat3Rank(oTempCat3List, iTempInt2);
                            }

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempInt2);
                            }

                            sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), iTempInt2, oTempCat2Rank.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sSql);
                        }
                    }

                    this.CommitTransection();

                    oResult.IsSuccess = true;
                }


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


        private void UpdateChildCat4Rank(List<CCat4Rank> inList, int inCat2Order)
        {
            for (int i = 0; i < inList.Count; i++)
            {
                CCat4Rank oTempCat3Rank = inList[i];

                CResult oResult = CalculateCat4Rank(inCat2Order, oTempCat3Rank.Category3Order, oTempCat3Rank.Category4Order);

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

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());


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

        public RMS.Common.ObjectModel.CResult Cat2UpdateOrderDown(RMS.Common.ObjectModel.CCategory2 oCat, RMS.Common.ObjectModel.CCategory2 oCat2)
        {
            CResult oResult = new CResult();

            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

                CCat2Rank oTempList = new CCat2Rank();

                CCat2Rank oTempList2 = new CCat2Rank();


                CResult oResult2 = GetOrderCandidateSingle(oCat);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {


                    oTempList = (CCat2Rank)oResult2.Data;
                }


                CResult oResult3 = GetOrderCandidateSingle(oCat2);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {

                    oTempList2 = (CCat2Rank)oResult3.Data;
                }


                this.OpenConnectionWithTransection();

                //for (int i = 0; i < oTempList.Count; i++)
                //{
                //    CCat2Rank oTempCat2Rank = oTempList[i];

                List<CCat3Rank> oTempCat3List = oTempList.ChildCat3List;

                List<CCat4Rank> oTempCat4List = oTempList.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat2.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat2.Category2Order);
                }

                // }

                //for (int k = 0; k < oTempList2.Count; k++)
                // {
                //CCat2Rank oTempCat2Rank = oTempList2[k];

                oTempCat3List = oTempList2.ChildCat3List;

                oTempCat4List = oTempList2.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat.Category2Order);
                }

                // }


                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oConstants.MaxOrderChange, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat.Category2Order, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat2.Category2Order, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
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

        private bool CheckCat2ForUpdate(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat2ForUpdate), inUser.Category2Name, inUser.Category1ID, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat2_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat2_id"].ToString());

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

        private CResult GetOrderCandidate(CCategory2 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat2Rank> oTempCat2List = new List<CCat2Rank>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat2OrderCandidate), oCat.Category2Order);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["cat2_id"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["cat2_id"].ToString());

                            iTempList.Add(iTempInt);


                        }

                    }

                    oReader.Close();

                    for (int i = 0; i < iTempList.Count; i++)
                    {
                        int iTempCat2ID = iTempList[i];

                        CResult oResult2 = GetChildCat3(iTempCat2ID);

                        CCat2Rank oTempCat2Rank = new CCat2Rank();

                        oTempCat2Rank.Category2ID = iTempCat2ID;



                        if (oResult2.IsSuccess && oResult2.Data != null)
                        {
                            List<CCat3Rank> oTempChildList = (List<CCat3Rank>)oResult2.Data;

                            oTempCat2Rank.ChildCat3List = oTempChildList;

                        }

                        CResult oResult3 = GetChildCat4ByCat2(iTempCat2ID);

                        if (oResult3.IsSuccess && oResult3.Data != null)
                        {
                            List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                            oTempCat2Rank.ChildCat4List = oTempChildList2;
                        }

                        oTempCat2List.Add(oTempCat2Rank);
                    }

                    oResult.Data = oTempCat2List;

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

        private CResult GetOrderCandidateLower(CCategory2 oCat, int inCatOrder)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat2Rank> oTempCat2List = new List<CCat2Rank>();

                if (oCat.Category2Order <= inCatOrder)
                {

                    oResult.Data = oTempCat2List;

                    oResult.IsSuccess = true;
                }
                else
                {

                    this.OpenConnection();
                    string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat2OrderCandidateLower), inCatOrder, oCat.Category2Order);
                    IDataReader oReader = this.ExecuteReader(sSql);
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            if (oReader["cat2_id"] != null)
                            {
                                int iTempInt = Int32.Parse(oReader["cat2_id"].ToString());

                                iTempList.Add(iTempInt);


                            }

                        }

                        oReader.Close();


                        for (int i = 0; i < iTempList.Count; i++)
                        {
                            int iTempCat2ID = iTempList[i];

                            CResult oResult2 = GetChildCat3(iTempCat2ID);

                            CCat2Rank oTempCat2Rank = new CCat2Rank();

                            oTempCat2Rank.Category2ID = iTempCat2ID;



                            if (oResult2.IsSuccess && oResult2.Data != null)
                            {
                                List<CCat3Rank> oTempChildList = (List<CCat3Rank>)oResult2.Data;

                                oTempCat2Rank.ChildCat3List = oTempChildList;

                            }

                            CResult oResult3 = GetChildCat4ByCat2(iTempCat2ID);

                            if (oResult3.IsSuccess && oResult3.Data != null)
                            {
                                List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                                oTempCat2Rank.ChildCat4List = oTempChildList2;
                            }

                            oTempCat2List.Add(oTempCat2Rank);
                        }

                        oResult.Data = oTempCat2List;

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

        private CResult GetOrderCandidateSingle(CCategory2 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat2Rank> oTempCat2List = new List<CCat2Rank>();


                this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.GetCat2OrderCandidateLower), inCatOrder, oCat.Category2Order);
                // IDataReader oReader = this.ExecuteReader(sSql);

                //for (int i = 0; i < iTempList.Count; i++)
                //{
                int iTempCat2ID = oCat.Category2ID;

                CResult oResult2 = GetChildCat3(oCat.Category2ID);

                CCat2Rank oTempCat2Rank = new CCat2Rank();

                oTempCat2Rank.Category2ID = iTempCat2ID;



                if (oResult2.IsSuccess && oResult2.Data != null)
                {
                    List<CCat3Rank> oTempChildList = (List<CCat3Rank>)oResult2.Data;

                    oTempCat2Rank.ChildCat3List = oTempChildList;

                }

                CResult oResult3 = GetChildCat4ByCat2(oCat.Category2ID);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {
                    List<CCat4Rank> oTempChildList2 = (List<CCat4Rank>)oResult3.Data;

                    oTempCat2Rank.ChildCat4List = oTempChildList2;
                }

                // oTempCat2List.Add(oTempCat2Rank);
                //}

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

        private CResult GetChildCat3(int inCat2ID)
        {
            CResult oResult = new CResult();

            List<CCat3Rank> oTempList = new List<CCat3Rank>();

            try
            {

                string sSql = string.Format(SqlQueries.GetQuery(Query.GetChildCat3ByCat2), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCat3Rank oCat2 = ReaderToCat3Rank(oReader);

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

        private CResult GetChildCat4ByCat2(int inCat2ID)
        {
            CResult oResult = new CResult();

            List<CCat4Rank> oTempList = new List<CCat4Rank>();

            try
            {

                string sSql = string.Format(SqlQueries.GetQuery(Query.GetChildCat4ByCat2), inCat2ID);
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

        public RMS.Common.ObjectModel.CResult Cat2UpdateOrderUp(RMS.Common.ObjectModel.CCategory2 oCat, RMS.Common.ObjectModel.CCategory2 oCat2)
        {
            CResult oResult = new CResult();


            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

                CCat2Rank oTempList = new CCat2Rank();

                CCat2Rank oTempList2 = new CCat2Rank();


                CResult oResult2 = GetOrderCandidateSingle(oCat);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {


                    oTempList = (CCat2Rank)oResult2.Data;
                }


                CResult oResult3 = GetOrderCandidateSingle(oCat2);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {

                    oTempList2 = (CCat2Rank)oResult3.Data;
                }


                this.OpenConnectionWithTransection();


                //for (int i = 0; i < oTempList.Count; i++)
                //{
                //    CCat2Rank oTempCat2Rank = oTempList[i];

                List<CCat3Rank> oTempCat3List = oTempList.ChildCat3List;

                List<CCat4Rank> oTempCat4List = oTempList.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat2.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat2.Category2Order);
                }

                // }

                //for (int i = 0; i < oTempList2.Count; i++)
                //{
                //CCat2Rank oTempCat2Rank = oTempList2[i];

                oTempCat3List = oTempList2.ChildCat3List;

                oTempCat4List = oTempList2.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat.Category2Order);
                }

                // }

                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oConstants.MaxOrderChange, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat2.Category2Order, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat.Category2Order, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
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

        private bool CheckCatOrder2ForUpdate(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat2OrderForUpdate), inUser.Category2Order, inUser.Category1ID, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat2_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat2_id"].ToString());

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

        public RMS.Common.ObjectModel.CResult GetCategory2(int inCat2ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory2), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        CCategory2 oCat2 = ReaderToCategory2(oReader);

                        oResult.Data = oCat2;

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

        private bool CheckCat(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupCat2), inUser.Category2Name, inUser.Category1ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat2_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat2_id"].ToString());

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
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckCat2Order), inUser.Category2Order, inUser.Category1ID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat2_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["cat2_id"].ToString());

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

        #endregion
    }
}
