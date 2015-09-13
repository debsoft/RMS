using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS;


namespace RMS.DataAccess
{
  public  class CCategory1DAO : BaseDAO, ICategory1DAO
    {
        #region ICategory1DAO Members

        public CResult AddCat1(RMS.Common.ObjectModel.CCategory1 p_categoryInfo)
        {
           CResult objResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat(p_categoryInfo);

                if (bTempFlag)
                {
                    objResult.Message = "Category1 exists with this name.";
                }
                else
                {
                        objResult = this.GetMaxCatOrder(); //New By Baruri at 31.12.2008
                        p_categoryInfo.Category1Name = p_categoryInfo.Category1Name.Replace("''", "'");
                        p_categoryInfo.Category1Name = p_categoryInfo.Category1Name.Replace("'", "''");

                        this.OpenConnection();
                        string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddCategory1), p_categoryInfo.Category1Name, p_categoryInfo.ParentCatID,p_categoryInfo.CurrentUserId,p_categoryInfo.LoginDateTime,(Int32)objResult.Data+1);

                        this.ExecuteNonQuery(sqlCommand);

                        objResult.IsSuccess = true;
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

        /// <summary>
        /// Finding the maximum category 1 order number
        /// </summary>
        /// <returns></returns>
        private CResult GetMaxCatOrder()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = SqlQueries.GetQuery(Query.GetMaxCat1Order);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["max_cat1_order"] != null)
                        {
                            int iTempInt = Int32.Parse(oReader["max_cat1_order"].ToString());

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

        private bool CheckCat(CCategory1 p_categoryInfo)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckDupCat1), p_categoryInfo.Category1Name, p_categoryInfo.ParentCatID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckCatUpdate(CCategory1 inUser)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckDupCat1Update), inUser.Category1Name, inUser.ParentCatID, inUser.Category1ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        public CResult Cat1Delete(RMS.Common.ObjectModel.CCategory1 oCat)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1), oCat.Category1ID);
                this.ExecuteNonQuery(sSql);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                objResult.Message = ex.Message;
                objResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return objResult;
        }

       public CResult Cat1Update(RMS.Common.ObjectModel.CCategory1 oCat)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCatUpdate(oCat);

                if (bTempFlag)
                {
                    oResult.Message = "Category order exists. Write another order.";
                }
                else
                {
                    oCat.Category1Name = oCat.Category1Name.Replace("''", "'");
                    oCat.Category1Name = oCat.Category1Name.Replace("'", "''");

                    this.OpenConnection();
                    string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCategory1), oCat.Category1Name, oCat.ParentCatID, oCat.Category1ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);
                    oResult.IsSuccess = true;
                }


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

        public CResult GetCategory1(int inCat1ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory1), inCat1ID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        CCategory1 oCat = ReaderToCategory1(oReader);

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

        private CCategory1 ReaderToCategory1(IDataReader oReader)
        {
            CCategory1 oItem = new CCategory1();



            if (oReader["cat1_id"] != null)
                oItem.Category1ID = Int32.Parse(oReader["cat1_id"].ToString());

            if (oReader["cat1_name"] != null)
                oItem.Category1Name = oReader["cat1_name"].ToString();

            //if (oReader["cat1_order"] != null)
            //    oItem.Category1Order = Int32.Parse(oReader["cat1_order"].ToString());

            if (oReader["parent_cat_id"] != null)
                oItem.ParentCatID = Int32.Parse(oReader["parent_cat_id"].ToString());

            return oItem;

        }

        public CResult UpdateAllRank()
        {
            CResult oResult = new CResult();

            try
            {

                this.OpenConnectionWithTransection();
                string sSql = SqlQueries.GetQuery(Query.DeleteAllCat3Rank);
                this.ExecuteNonQuery(sSql);

                sSql = SqlQueries.GetQuery(Query.DeleteAllCat4Rank);
                this.ExecuteNonQuery(sSql);

                List<CCat3Rank> oTempCat3List = new List<CCat3Rank>();

                List<CCat4Rank> oTempCat4List = new List<CCat4Rank>();

                sSql = SqlQueries.GetQuery(Query.GetAllCat3Rank);

                IDataReader oReader = this.ExecuteReader(sSql);


                if (oReader != null)
                {
                    while (oReader.Read())
                    {

                        CCat3Rank oCat = ReaderToCat3Rank(oReader);

                        oTempCat3List.Add(oCat);


                    }
                }

                oReader.Close();


                sSql = SqlQueries.GetQuery(Query.GetAllCat4Rank);

                oReader = this.ExecuteReader(sSql);


                if (oReader != null)
                {
                    while (oReader.Read())
                    {

                        CCat4Rank oCat = ReaderToCat4Rank(oReader);

                        oTempCat4List.Add(oCat);


                    }
                }

                oReader.Close();

                int i = 0;

                for (i = 0; i < oTempCat3List.Count; i++)
                {
                    CCat3Rank oTempCat3Rank = oTempCat3List[i];

                    CResult oResult2 = CalculateCat3Rank(oTempCat3Rank.Category2Order, oTempCat3Rank.Category3Order);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {
                        Int64 iTempRank = (Int64)oResult2.Data;

                        sSql = string.Format(SqlQueries.GetQuery(Query.UpdateCat3Rank), iTempRank, oTempCat3Rank.Category3ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

                        this.ExecuteNonQuery(sSql);
                    }




                }


                for (i = 0; i < oTempCat4List.Count; i++)
                {
                    CCat4Rank oTempCat4Rank = oTempCat4List[i];

                    CResult oResult3 = CalculateCat4Rank(oTempCat4Rank.Category2Order, oTempCat4Rank.Category3Order, oTempCat4Rank.Category4Order);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {
                        Int64 iTempRank = (Int64)oResult3.Data;

                        sSql = string.Format(SqlQueries.GetQuery(Query.UpdateCat4Rank), iTempRank, oTempCat4Rank.Category4ID, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

                        this.ExecuteNonQuery(sSql);
                    }




                }

                this.CommitTransection();




                oResult.IsSuccess = true;



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

            if (oReader["cat2_order"] != null)
                oItem.Category2Order = Int32.Parse(oReader["cat2_order"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());

            if (oReader["cat4_order"] != null)
                oItem.Category4Order = Int32.Parse(oReader["cat4_order"].ToString());


            return oItem;

        }

        private CCat3Rank ReaderToCat3Rank(IDataReader oReader)
        {
            CCat3Rank oItem = new CCat3Rank();

            if (oReader["cat3_id"] != null)
                oItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["cat2_order"] != null)
                oItem.Category2Order = Int32.Parse(oReader["cat2_order"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Category3Order = Int32.Parse(oReader["cat3_order"].ToString());



            return oItem;

        }

        public CResult UpdateCategory1OrderDown(RMS.Common.ObjectModel.CCategory1 p_currentCategory, RMS.Common.ObjectModel.CCategory1 p_antiCategory)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";
            try
            {
                this.OpenConnection();
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory1Order), p_currentCategory.Category1ID, p_antiCategory.Category1OrderNumber, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory1Order), p_antiCategory.Category1ID, p_currentCategory.Category1OrderNumber, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;

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

            return oResult;
        }

        public CResult UpdateCategory1OrderUP(RMS.Common.ObjectModel.CCategory1 p_currentCategory, RMS.Common.ObjectModel.CCategory1 p_antiCategory)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";
            try
            {
                this.OpenConnection();
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory1Order), p_currentCategory.Category1ID, p_antiCategory.Category1OrderNumber, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory1Order), p_antiCategory.Category1ID, p_currentCategory.Category1OrderNumber, RMSGlobal.LogInUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;

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

            return oResult;
        }

        #endregion
    }
}
