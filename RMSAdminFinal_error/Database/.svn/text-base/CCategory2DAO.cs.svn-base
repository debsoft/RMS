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
            CResult objResult = new CResult();
            try
            {
                bool blnTempFlag = CheckCat(inUser);

                if (blnTempFlag)
                {
                    objResult.Message = "Category2 exists with this name.";
                }
                else
                {
                    CResult objResult2 = GetMaxCatOrder();

                    if (objResult2.IsSuccess && objResult2.Data != null)
                    {
                        int iTempOrder = (int)objResult2.Data;

                        iTempOrder = iTempOrder + 1;

                        inUser.Category2Name = inUser.Category2Name.Replace("''", "'");
                        inUser.Category2Name = inUser.Category2Name.Replace("'", "''");

                        this.OpenConnection();
                        string sSql = String.Format(SqlQueries.GetQuery(Query.AddCategory2), inUser.Category2Name, inUser.Category1ID, iTempOrder, inUser.Category2Type, inUser.Category2Color, inUser.Category2ViewTable, inUser.Category2ViewBar, inUser.Category2ViewTakeAway, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

                        this.ExecuteNonQuery(sSql);

                        objResult.IsSuccess = true;
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
            return objResult;
        }

        private CResult GetMaxCatOrder()
        {
            CResult objResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = SqlQueries.GetQuery(Query.GetMaxCat2Order);
                IDataReader objReader = this.ExecuteReader(sqlCommand);
                if (objReader != null)
                {
                    if (objReader.Read())
                    {
                        if (objReader["max_cat2_order"] != null)
                        {
                            int iTempInt = Int32.Parse(objReader["max_cat2_order"].ToString());
                            objResult.Data = iTempInt;
                            objResult.IsSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

                objResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        public RMS.Common.ObjectModel.CResult Cat2Delete(RMS.Common.ObjectModel.CCategory2 p_objCat2)
        {
            CResult objResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory2), p_objCat2.Category2ID);
                this.ExecuteNonQuery(sSql);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                objResult.IsException = true;
                objResult.Message = ex.Message;
            }
            finally
            {
                this.CloseConnection();
            }

            return objResult;
        }

        public RMS.Common.ObjectModel.CResult Cat2Update(RMS.Common.ObjectModel.CCategory2 p_objCat2, int p_catOrder)
        {
            CResult objResult = new CResult();
            try
            {
                bool blnTempFlag = CheckCat2ForUpdate(p_objCat2);

                if (blnTempFlag)
                {
                    objResult.Message = "Category exists with this name.";
                }
                else
                {
                    p_objCat2.Category2Name = p_objCat2.Category2Name.Replace("''", "'");
                    p_objCat2.Category2Name = p_objCat2.Category2Name.Replace("'", "''");

                    List<CCat2Rank> objRankTempList1 = new List<CCat2Rank>();

                    List<CCat2Rank> objRankTempList2 = new List<CCat2Rank>();

                    CResult objResult3 = GetOrderCandidateLower(p_objCat2, p_catOrder);

                    if (objResult3.IsSuccess && objResult3.Data != null)
                    {
                        objRankTempList2 = (List<CCat2Rank>)objResult3.Data;
                    }

                    CResult oResult2 = GetOrderCandidate(p_objCat2);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {
                        objRankTempList1 = (List<CCat2Rank>)oResult2.Data;
                    }

                    this.OpenConnectionWithTransection();

                    string sqlCommand = "";

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int counter = 0;

                    for (counter = 0; counter < objRankTempList1.Count; counter++)
                    {
                        CCat2Rank oTempCat2Rank = objRankTempList1[counter];

                        if (oTempCat2Rank.Category2ID == p_objCat2.Category2ID)
                        {

                            iTempInt2 = p_objCat2.Category2Order;


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

                            iTempInt2 = p_objCat2.Category2Order + 1 + iTempInt3;


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

                            sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), iTempInt2, oTempCat2Rank.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sqlCommand);
                        }
                    }

                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2), p_objCat2.Category2Name, p_objCat2.Category1ID, p_objCat2.Category2Order, p_objCat2.Category2Type, p_objCat2.Category2Color, p_objCat2.Category2ViewTable, p_objCat2.Category2ViewBar, p_objCat2.Category2ViewTakeAway, p_objCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sqlCommand);

                    //this.CommitTransection();          

                    sqlCommand = "";

                    iTempInt3 = 1;

                    for (counter = 0; counter < objRankTempList2.Count; counter++)
                    {
                        CCat2Rank oTempCat2Rank = objRankTempList2[counter];

                        if (oTempCat2Rank.Category2ID == p_objCat2.Category2ID)
                        {

                            iTempInt2 = p_objCat2.Category2Order;


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

                            iTempInt2 = p_catOrder + iTempInt3 - 1;

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

                            sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), iTempInt2, oTempCat2Rank.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sqlCommand);
                        }
                    }

                    this.CommitTransection();

                    objResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }


        private void UpdateChildCat3Rank(List<CCat3Rank> inList, int inCat2Order)
        {
            for (int counter = 0; counter < inList.Count; counter++)
            {
                CCat3Rank oTempCat3Rank = inList[counter];

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
            for (int listCounter = 0; listCounter < inList.Count; listCounter++)
            {
                CCat4Rank oTempCat3Rank = inList[listCounter];

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
            CResult objResult = new CResult();

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
                    objResult.Data = iTempInt;

                    objResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return objResult;
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
                Console.Write(ex.Message);
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
            CResult objResult = new CResult();

            try
            {
                CCommonConstants objCommonConstants = ConfigManager.GetConfig<CCommonConstants>();

                CCat2Rank objTempRankList1 = new CCat2Rank();

                CCat2Rank objRankTempList2 = new CCat2Rank();


                CResult oResult2 = GetOrderCandidateSingle(oCat);

                if (oResult2.IsSuccess && oResult2.Data != null)
                {
                    objTempRankList1 = (CCat2Rank)oResult2.Data;
                }

                CResult oResult3 = GetOrderCandidateSingle(oCat2);

                if (oResult3.IsSuccess && oResult3.Data != null)
                {
                    objRankTempList2 = (CCat2Rank)oResult3.Data;
                }


                this.OpenConnectionWithTransection();

                List<CCat3Rank> oTempCat3List = objTempRankList1.ChildCat3List;

                List<CCat4Rank> oTempCat4List = objTempRankList1.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat2.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat2.Category2Order);
                }

                oTempCat3List = objRankTempList2.ChildCat3List;

                oTempCat4List = objRankTempList2.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, oCat.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, oCat.Category2Order);
                }


                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), objCommonConstants.MaxOrderChange, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat.Category2Order, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat2.Category2Order, oCat.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return objResult;
        }

        private bool CheckCat2ForUpdate(CCategory2 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckDupCat2ForUpdate), inUser.Category2Name, inUser.Category1ID, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private CResult GetOrderCandidate(CCategory2 p_objCat2)
        {
            CResult objResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat2Rank> oTempCat2List = new List<CCat2Rank>();

                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCat2OrderCandidate), p_objCat2.Category2Order);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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

                    for (int listCounter = 0; listCounter < iTempList.Count; listCounter++)
                    {
                        int iTempCat2ID = iTempList[listCounter];

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

                    objResult.Data = oTempCat2List;

                    objResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

                objResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        private CResult GetOrderCandidateLower(CCategory2 p_objCat2, int p_inCatOrder)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat2Rank> oTempCat2List = new List<CCat2Rank>();

                if (p_objCat2.Category2Order <= p_inCatOrder)
                {
                    oResult.Data = oTempCat2List;
                    oResult.IsSuccess = true;
                }
                else
                {
                    this.OpenConnection();
                    string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCat2OrderCandidateLower), p_inCatOrder, p_objCat2.Category2Order);
                    IDataReader oReader = this.ExecuteReader(sqlCommand);
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

                        for (int listCounter = 0; listCounter < iTempList.Count; listCounter++)
                        {
                            int iTempCat2ID = iTempList[listCounter];

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

        private CResult GetChildCat3(int p_inCat2ID)
        {
            CResult objResult = new CResult();
            List<CCat3Rank> oTempList = new List<CCat3Rank>();

            try
            {
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetChildCat3ByCat2), p_inCat2ID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCat3Rank oCat2 = ReaderToCat3Rank(oReader);
                        oTempList.Add(oCat2);
                    }

                    oReader.Close();
                    objResult.Data = oTempList;
                    objResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
            }

            return objResult;
        }

        private CResult GetChildCat4ByCat2(int p_inCat2ID)
        {
            CResult objResult = new CResult();
            List<CCat4Rank> oTempList = new List<CCat4Rank>();

            try
            {
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetChildCat4ByCat2), p_inCat2ID);
                IDataReader objReader = this.ExecuteReader(sqlCommand);
                if (objReader != null)
                {
                    while (objReader.Read())
                    {
                        CCat4Rank oCat2 = ReaderToCat4Rank(objReader);
                        oTempList.Add(oCat2);
                    }

                    objReader.Close();

                    objResult.Data = oTempList;

                    objResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
            }
            return objResult;
        }

        private CResult GetChildCat4ByCat3(int p_inCat2ID)
        {
            CResult oResult = new CResult();

            List<CCat4Rank> oTempList = new List<CCat4Rank>();

            try
            {

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetChildCat4ByCat3), p_inCat2ID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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

        public RMS.Common.ObjectModel.CResult Cat2UpdateOrderUp(RMS.Common.ObjectModel.CCategory2 p_objCat2, RMS.Common.ObjectModel.CCategory2 oCat2)
        {
            CResult objResult = new CResult();

            try
            {
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();

                CCat2Rank oTempList = new CCat2Rank();

                CCat2Rank oTempList2 = new CCat2Rank();


                CResult oResult2 = GetOrderCandidateSingle(p_objCat2);

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

                oTempCat3List = oTempList2.ChildCat3List;

                oTempCat4List = oTempList2.ChildCat4List;

                if (oTempCat3List.Count > 0)
                {
                    UpdateChildCat3Rank(oTempCat3List, p_objCat2.Category2Order);
                }

                if (oTempCat4List.Count > 0)
                {
                    UpdateChildCat4Rank(oTempCat4List, p_objCat2.Category2Order);
                }


                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oConstants.MaxOrderChange, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), oCat2.Category2Order, p_objCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory2Order), p_objCat2.Category2Order, oCat2.Category2ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return objResult;
        }

        private bool CheckCatOrder2ForUpdate(CCategory2 p_inUser)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckCat2OrderForUpdate), p_inUser.Category2Order, p_inUser.Category1ID, p_inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        public RMS.Common.ObjectModel.CResult GetCategory2(int p_inCat2ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCategory2), p_inCat2ID);
                IDataReader objReader = this.ExecuteReader(sqlCommand);
                if (objReader != null)
                {
                    if (objReader.Read())
                    {
                        CCategory2 oCat2 = ReaderToCategory2(objReader);

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

        private bool CheckCat(CCategory2 p_inUser)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckDupCat2), p_inUser.Category2Name, p_inUser.Category1ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCatOrder(CCategory2 p_inUser)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckCat2Order), p_inUser.Category2Order, p_inUser.Category1ID);

                IDataReader objReader = this.ExecuteReader(sqlCommand);
                if (objReader != null)
                {
                    if (objReader.Read())
                    {
                        if (objReader["cat2_id"] != null)
                        {
                            int iTemp = Int32.Parse(objReader["cat2_id"].ToString());

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

        #endregion
    }
}
