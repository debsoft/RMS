using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace RMS.DataAccess
{
    public class CCategory3DAO : BaseDAO, ICategory3DAO 
    {
        #region ICategory3DAO members
        public CResult Category3Insert(CCategory3 p_objCategory3)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckCat3(p_objCategory3);

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

                        p_objCategory3.Category3Name = p_objCategory3.Category3Name.Replace("''", "'");
                        p_objCategory3.Category3Name = p_objCategory3.Category3Name.Replace("'", "''");

                        p_objCategory3.Category3Description = p_objCategory3.Category3Description.Replace("''", "'");
                        p_objCategory3.Category3Description = p_objCategory3.Category3Description.Replace("'", "''");

                        this.OpenConnection();
                        string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddCategory3),
                            p_objCategory3.Category3Name,
                            p_objCategory3.Category2ID,
                            p_objCategory3.Category3Description,
                            p_objCategory3.Category3TablePrice,
                            p_objCategory3.Category3TakeAwayPrice,
                            p_objCategory3.Category3BarPrice,
                            p_objCategory3.Category3OrderStatus,
                            iTempOrder,
                            p_objCategory3.Category3ViewTable,
                            p_objCategory3.Category3ViewBar,
                            p_objCategory3.Category3ViewTakeAway,
                            p_objCategory3.MIRank,
                            RMS.RMSGlobal.LoginUserName,
                            DateTime.Now.Ticks,
                            p_objCategory3.MInitialQuantity,
                            p_objCategory3.MUnlimitStatus,

                            //p_objCategory3.MRetailPrice,
                            //p_objCategory3.MWholeSalePrice,
                            //p_objCategory3.MLastPurchasePrice,
                            p_objCategory3.Category3TablePrice,
                            p_objCategory3.Category3TakeAwayPrice,
                            p_objCategory3.Category3BarPrice,


                            p_objCategory3.MUnitsInStock,
                            p_objCategory3.MReorderLevel,
                            p_objCategory3.MQtyPerSaleUint,
                            p_objCategory3.MQtyPerPurchaseUnit,
                            p_objCategory3.MStandardUoM,
                            p_objCategory3.MSalesUoM,
                            p_objCategory3.MPurchaseUoM,
                            Convert.ToByte(p_objCategory3.MNonTaxableGood),
                            Convert.ToByte(p_objCategory3.MNonStockable),
                            p_objCategory3.MSupplierId,
                            p_objCategory3.MBarCode,

                            p_objCategory3.ItemSellingIn,
                            Convert.ToByte(p_objCategory3.MVatIncluded),
                            p_objCategory3.MProductType
                                              );
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
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;

        }

        public CResult RawMatinStockInsert(CCategory3 inCategory3, int inCatOrder, float AddQty, string Unit)
        
        {

            CResult objResult = new CResult();

        try
            {

                bool bTempFlag = CheckCat3ForUpdate(inCategory3);

                if (bTempFlag)
                {
                    objResult.Message = "Category exists with this name.";
                }
                else
                {

                   // string sqlCommand = "";
                 List<CCat3Rank> oTempList = new List<CCat3Rank>();

                    List<CCat3Rank> oTempList2 = new List<CCat3Rank>();

                    int iTempCat2Order = 0;

                    CResult oResult4 = GetCategory2Order(inCategory3.Category2ID);

                    if (oResult4.IsSuccess && oResult4.Data != null)
                    {


                        iTempCat2Order = (int)oResult4.Data;
                    }
                    else
                    {
                        return objResult;
                    }



                    CResult oResult2 = GetOrderCandidate(inCategory3);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        oTempList = (List<CCat3Rank>)oResult2.Data;

                    }

                    CResult oResult3 = GetOrderCandidateLower(inCategory3, inCatOrder);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {


                        oTempList2 = (List<CCat3Rank>)oResult3.Data;

                    }


                    this.OpenConnectionWithTransection();

                    string sqlCommand = "";

                    int iTempInt = 0;

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int counter = 0;

                    for (counter = 0; counter < oTempList.Count; counter++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList[counter];

                        if (oTempCat3Rank.Category3ID == inCategory3.Category3ID)
                        {

                            iTempInt2 = inCategory3.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);


                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, inCategory3.Category3Order);
                            }
                        }
                        else
                        {

                            iTempInt2 = inCategory3.Category3Order + 1 + iTempInt3;

                            iTempInt3 = iTempInt3 + 1;


                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, iTempInt2);
                            }

                           // sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                          //  this.ExecuteNonQuery(sqlCommand);
                        }
                    }

                    inCategory3.Category3Name = inCategory3.Category3Name.Replace("''", "'");
                    inCategory3.Category3Name = inCategory3.Category3Name.Replace("'", "''");

                    inCategory3.Category3Description = inCategory3.Category3Description.Replace("''", "'");
                    inCategory3.Category3Description = inCategory3.Category3Description.Replace("'", "''");


                   // sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateCategory3), inCategory3.Category3Name, inCategory3.Category2ID, inCategory3.Category3Description, inCategory3.Category3TablePrice, inCategory3.Category3TakeAwayPrice, inCategory3.Category3BarPrice, inCategory3.Category3OrderStatus, inCategory3.Category3Order, inCategory3.Category3ViewTable, inCategory3.Category3ViewBar, inCategory3.Category3ViewTakeAway, inCategory3.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks, inCategory3.MInitialQuantity, inCategory3.MUnlimitStatus, inCategory3.ItemSellingIn);

                    // sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateCategory3), inCategory3.Category3Name, inCategory3.Category2ID, inCategory3.Category3Description, inCategory3.Category3OrderStatus, inCategory3.Category3Order, inCategory3.Category3ViewTable, inCategory3.Category3ViewBar, inCategory3.Category3ViewTakeAway, inCategory3.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks, inCategory3.MInitialQuantity, inCategory3.MUnlimitStatus, inCategory3.ItemSellingIn);
                  //  this.ExecuteNonQuery(sqlCommand);

                    sqlCommand = "";

                    iTempInt3 = 1;


                    for (counter = 0; counter < oTempList2.Count; counter++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList2[counter];

                        if (oTempCat3Rank.Category3ID == inCategory3.Category3ID)
                        {

                            iTempInt2 = inCategory3.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, inCategory3.Category3Order);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, inCategory3.Category3Order);
                            }
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

                           // sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);

                  //          if (inCategory3.MProductType == "RawMaterial")

                    //        {
                      //      sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertRawMatinStock), iTempInt2, oTempCat3Rank.Category3ID, inCategory3.Category3Name, inCategory3.Category3Description, inCategory3.Category2ID, inCategory3.MStandardUoM, inCategory3.MUnitsInStock, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                            
                     //      this.ExecuteNonQuery(sqlCommand);
                    //        }
                }
                            


                        }

                    if (inCategory3.MProductType == "Raw Material")
                    {
                        float PrevQty = inCategory3.MUnitsInStock - AddQty;
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertRawMatinStock), inCategory3.Category3ID, inCategory3.Category2ID, inCategory3.Category3Name, inCategory3.Category3Description, DateTime.Now.Ticks, Unit, inCategory3.MUnitsInStock, DateTime.Now, AddQty, PrevQty);

                  this.ExecuteNonQuery(sqlCommand);
                    }

                //    this.ExecuteNonQuery(sqlCommand);
                    this.CommitTransection();

                    objResult.IsSuccess = true;

                }
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

            return objResult;

        }

        public CResult Category3Update(CCategory3 inCategory3, int inCatOrder)
        {
            CResult objResult = new CResult();

            try
            {

                bool bTempFlag = CheckCat3ForUpdate(inCategory3);

                if (bTempFlag)
                {
                    objResult.Message = "Category exists with this name.";
                }
                else
                {
                    List<CCat3Rank> oTempList = new List<CCat3Rank>();

                    List<CCat3Rank> oTempList2 = new List<CCat3Rank>();

                    int iTempCat2Order = 0;

                    CResult oResult4 = GetCategory2Order(inCategory3.Category2ID);

                    if (oResult4.IsSuccess && oResult4.Data != null)
                    {


                        iTempCat2Order = (int)oResult4.Data;
                    }
                    else
                    {
                        return objResult;
                    }



                    CResult oResult2 = GetOrderCandidate(inCategory3);

                    if (oResult2.IsSuccess && oResult2.Data != null)
                    {


                        oTempList = (List<CCat3Rank>)oResult2.Data;

                    }

                    CResult oResult3 = GetOrderCandidateLower(inCategory3, inCatOrder);

                    if (oResult3.IsSuccess && oResult3.Data != null)
                    {


                        oTempList2 = (List<CCat3Rank>)oResult3.Data;

                    }


                    this.OpenConnectionWithTransection();

                    string sqlCommand = "";

                    int iTempInt = 0;

                    int iTempInt2 = 0;

                    int iTempInt3 = 0;

                    int counter = 0;

                    for (counter = 0; counter < oTempList.Count; counter++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList[counter];

                        if (oTempCat3Rank.Category3ID == inCategory3.Category3ID)
                        {

                            iTempInt2 = inCategory3.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);


                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, inCategory3.Category3Order);
                            }
                        }
                        else
                        {

                            iTempInt2 = inCategory3.Category3Order + 1 + iTempInt3;

                            iTempInt3 = iTempInt3 + 1;


                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, iTempInt2);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, iTempInt2);
                            }

                            sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt, oTempCat3Rank.Category3ID,  RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sqlCommand);
                        }
                    }

                    inCategory3.Category3Name = inCategory3.Category3Name.Replace("''", "'");
                    inCategory3.Category3Name = inCategory3.Category3Name.Replace("'", "''");

                    inCategory3.Category3Description = inCategory3.Category3Description.Replace("''", "'");
                    inCategory3.Category3Description = inCategory3.Category3Description.Replace("'", "''");


                   sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateCategory3), inCategory3.Category3Name, inCategory3.Category2ID, inCategory3.Category3Description, inCategory3.Category3TablePrice, inCategory3.Category3TakeAwayPrice, inCategory3.Category3BarPrice, inCategory3.Category3OrderStatus, inCategory3.Category3Order, inCategory3.Category3ViewTable, inCategory3.Category3ViewBar, inCategory3.Category3ViewTakeAway, inCategory3.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks, inCategory3.MInitialQuantity, inCategory3.MUnlimitStatus, inCategory3.ItemSellingIn, inCategory3.MProductType);

                   // sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateCategory3), inCategory3.Category3Name, inCategory3.Category2ID, inCategory3.Category3Description, inCategory3.Category3OrderStatus, inCategory3.Category3Order, inCategory3.Category3ViewTable, inCategory3.Category3ViewBar, inCategory3.Category3ViewTakeAway, inCategory3.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks, inCategory3.MInitialQuantity, inCategory3.MUnlimitStatus, inCategory3.ItemSellingIn);
                    this.ExecuteNonQuery(sqlCommand);

                    sqlCommand = "";

                    iTempInt3 = 1;


                    for (counter = 0; counter < oTempList2.Count; counter++)
                    {
                        CCat3Rank oTempCat3Rank = oTempList2[counter];

                        if (oTempCat3Rank.Category3ID == inCategory3.Category3ID)
                        {

                            iTempInt2 = inCategory3.Category3Order;

                            UpdateCat3Rank(oTempCat3Rank, iTempCat2Order, inCategory3.Category3Order);

                            List<CCat4Rank> oTempCat4List = oTempCat3Rank.ChildCat4List;

                            if (oTempCat4List.Count > 0)
                            {
                                UpdateChildCat4Rank(oTempCat4List, iTempCat2Order, inCategory3.Category3Order);
                            }
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

                            sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Order), iTempInt2, oTempCat3Rank.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                            this.ExecuteNonQuery(sqlCommand);

                        }
                    }

                    this.CommitTransection();

                    objResult.IsSuccess = true;
                   
                }
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

            return objResult;
        }


        private bool CheckCat3ForUpdate(CCategory3 p_objCategory3)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Latest),
                              p_objCategory3.Category3Name,
                              p_objCategory3.Category2ID,
                              p_objCategory3.Category3Description,

                              p_objCategory3.Category3TablePrice,
                              p_objCategory3.Category3TakeAwayPrice,
                              p_objCategory3.Category3BarPrice,
                              p_objCategory3.Category3OrderStatus,
                              0,
                              p_objCategory3.Category3ViewTable,
                              p_objCategory3.Category3ViewBar,
                              p_objCategory3.Category3ViewTakeAway,
                              p_objCategory3.MIRank,
                              RMS.RMSGlobal.LoginUserName,
                              DateTime.Now.Ticks,
                              p_objCategory3.MInitialQuantity,
                              p_objCategory3.MUnlimitStatus,

                              //p_objCategory3.MRetailPrice,
                    //p_objCategory3.MWholeSalePrice,
                    //p_objCategory3.MLastPurchasePrice,

                                p_objCategory3.Category3TablePrice,
                              p_objCategory3.Category3TakeAwayPrice,
                              p_objCategory3.Category3BarPrice,
                             p_objCategory3.MUnitsInStock,
                              p_objCategory3.MReorderLevel,
                              p_objCategory3.MQtyPerSaleUint,
                              p_objCategory3.MQtyPerPurchaseUnit,
                              p_objCategory3.MStandardUoM,
                              p_objCategory3.MSalesUoM,
                              p_objCategory3.MPurchaseUoM,
                              Convert.ToByte(p_objCategory3.MNonTaxableGood),
                              Convert.ToByte(p_objCategory3.MNonStockable),
                              p_objCategory3.MSupplierId,
                              p_objCategory3.MBarCode,

                              p_objCategory3.ItemSellingIn,
                 //   Convert.ToByte(p_objCategory3.MVatIncluded),
                              p_objCategory3.Category3ID);

                // new 


                //string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateCategory3Latest),
                //    //p_objCategory3.Category3Name,
                //    //p_objCategory3.Category2ID,
                //    //p_objCategory3.Category3Description,

                //              //p_objCategory3.Category3TablePrice,
                //    //p_objCategory3.Category3TakeAwayPrice,
                //    //p_objCategory3.Category3BarPrice,
                //    //p_objCategory3.Category3OrderStatus,
                //    //0,
                //    //p_objCategory3.Category3ViewTable,
                //    //p_objCategory3.Category3ViewBar,
                //    //p_objCategory3.Category3ViewTakeAway,

                //              p_objCategory3.MIRank,
                //              RMS.RMSGlobal.LoginUserName,
                //              DateTime.Now.Ticks,
                //              p_objCategory3.MInitialQuantity,
                //              p_objCategory3.MUnlimitStatus,

                //              //p_objCategory3.MRetailPrice,
                //    //p_objCategory3.MWholeSalePrice,
                //    //p_objCategory3.MLastPurchasePrice,

                //              //  p_objCategory3.Category3TablePrice,
                //    //p_objCategory3.Category3TakeAwayPrice,
                //    //p_objCategory3.Category3BarPrice,

                //              p_objCategory3.MUnitsInStock,
                //    //p_objCategory3.MReorderLevel,

                //              //p_objCategory3.MQtyPerSaleUint,
                //    //p_objCategory3.MQtyPerPurchaseUnit,
                //    //p_objCategory3.MStandardUoM,
                //    //p_objCategory3.MSalesUoM,
                //    //p_objCategory3.MPurchaseUoM,
                //    //Convert.ToByte(p_objCategory3.MNonTaxableGood),
                //    ////Convert.ToByte(p_objCategory3.MNonStockable),
                //    //p_objCategory3.MSupplierId,
                //    //p_objCategory3.MBarCode,

                //              p_objCategory3.ItemSellingIn,
                //    //Convert.ToByte(p_objCategory3.MVatIncluded),
                //              p_objCategory3.Category3ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }


        public void Category3Update(CCategory3 inCategory3)
        {
        }
        public void Category3Delete(CCategory3 inCategory3)
        {
        }

        public List<CCategory3> GetAllCategory3()
        {
            List<CCategory3> tempCategory3List = new List<CCategory3>();
            try
            {
                this.OpenConnection();
                string sqlCommand = SqlQueries.GetQuery(Query.Category3GetAll);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory3 tempCategory3 = ReaderToCategory3(oReader);
                        tempCategory3List.Add(tempCategory3);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory3()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCategory3List;
        }

        #endregion

        #region GetAllCategory3ByCategory3ID
        public CCategory3 GetAllCategory3ByCategory3ID(int categoryID)
        {
            CCategory3 tempCategory3 = new CCategory3();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCategory3ByCategory3ID), categoryID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCategory3 = ReaderToCategory3(oReader);
                        // tempCategory3List.Add(tempCategory3);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory3()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCategory3;
        }

        #endregion



        private CCategory3 ReaderToCategory3(IDataReader inReader)
        {
            CCategory3 tempCategory3 = new CCategory3();

            if (inReader["cat3_id"] != null)
                tempCategory3.Category3ID = int.Parse(inReader["cat3_id"].ToString());

            if (inReader["cat3_name"] != null)
                tempCategory3.Category3Name = inReader["cat3_name"].ToString();

            if (inReader["cat3_order"] != null)
                tempCategory3.Category3Order = int.Parse(inReader["cat3_order"].ToString());

            if (inReader["cat2_id"] != null)
                tempCategory3.Category2ID = int.Parse(inReader["cat2_id"].ToString());

            if (inReader["description"] != null)
                tempCategory3.Category3Description = inReader["description"].ToString();


            if (inReader["table_price"] != null)
                tempCategory3.Category3TablePrice = Double.Parse(inReader["table_price"].ToString());

            if (inReader["tw_price"] != null)
                tempCategory3.Category3TakeAwayPrice = Double.Parse(inReader["tw_price"].ToString());

            if (inReader["bar_price"] != null)
                tempCategory3.Category3BarPrice = Double.Parse(inReader["bar_price"].ToString());


            if (inReader["status"] != null)
                tempCategory3.Category3OrderStatus= int.Parse(inReader["status"].ToString());

            if (inReader["view_table"] != null)
                tempCategory3.Category3ViewTable = int.Parse(inReader["view_table"].ToString());

            if (inReader["view_bar"] != null)
                tempCategory3.Category3ViewBar = int.Parse(inReader["view_bar"].ToString());

            if (inReader["view_takeaway"] != null)
                tempCategory3.Category3ViewTakeAway = int.Parse(inReader["view_takeaway"].ToString());



            try 
            {
                if (inReader["maximum_attributes"] != null)
                    tempCategory3.Category3MaximumAttributes = int.Parse(inReader["maximum_attributes"].ToString());

            }
            catch (Exception ex) { tempCategory3.Category3MaximumAttributes = 0; }

            try
            {
                if (inReader["selectable_attributes"] != null)
                    tempCategory3.Category3SelectableAttributes = int.Parse(inReader["selectable_attributes"].ToString());

            }
            catch (Exception ex) { tempCategory3.Category3SelectableAttributes = 0; }

            try
            {
                if (inReader["includedPrice"] != null)
                    tempCategory3.IncludedPrice = int.Parse(inReader["includedPrice"].ToString());

            }
            catch (Exception ex) { tempCategory3.IncludedPrice = 0; }
         

            try
            {
                if (inReader["defaultPrice"] != null)
                    tempCategory3.DefaultCount = int.Parse(inReader["defaultPrice"].ToString());

            }
            catch (Exception ex) { tempCategory3.DefaultCount = 0; }


            try
            {
                if (inReader["productType"] != null)
                    tempCategory3.MProductType = inReader["productType"].ToString();

            }
            catch (Exception ex) { tempCategory3.DefaultCount = 0; }


            try
            {
                if (inReader["RetailPrice"] != null && inReader["RetailPrice"].ToString() != "")
               // tempCategory3.MRetailPrice = Convert.ToDouble(inReader["RetailPrice"].ToString());
                tempCategory3.Category3TablePrice = Convert.ToDouble(inReader["RetailPrice"].ToString());
            }
            catch(Exception)
            {
            }


            try{if (inReader["WholeSalePrice"] != null && inReader["WholeSalePrice"].ToString() != "")
               // tempCategory3.MWholeSalePrice = Convert.ToDouble(inReader["WholeSalePrice"].ToString());
            tempCategory3.Category3TakeAwayPrice = Convert.ToDouble(inReader["WholeSalePrice"].ToString());
            }
            catch(Exception)
            {
            }

            try{if (inReader["LastPurchasePrice"] != null && inReader["LastPurchasePrice"].ToString() != "")
              //  tempCategory3.MLastPurchasePrice = Convert.ToDouble(inReader["LastPurchasePrice"].ToString());
            tempCategory3.Category3BarPrice = Convert.ToDouble(inReader["LastPurchasePrice"].ToString());
            }
            catch(Exception)
            {
            }

            try{if (inReader["UnitsInStock"] != null && inReader["UnitsInStock"].ToString() != "")
                tempCategory3.MUnitsInStock = Convert.ToInt32(inReader["UnitsInStock"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["ReorderLevel"] != null && inReader["ReorderLevel"].ToString() != "")
                tempCategory3.MReorderLevel = Convert.ToInt32(inReader["ReorderLevel"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["QTYPerSaleUint"] != null && inReader["QTYPerSaleUint"].ToString() != "")
                tempCategory3.MQtyPerSaleUint = Convert.ToInt32(inReader["QTYPerSaleUint"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["QTYPerPurchaseUnit"] != null && inReader["QTYPerPurchaseUnit"].ToString() != "")
                tempCategory3.MQtyPerPurchaseUnit = Convert.ToInt32(inReader["QTYPerPurchaseUnit"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["StandardUoM"] != null && inReader["StandardUoM"].ToString() != "")
                tempCategory3.MStandardUoM = inReader["StandardUoM"].ToString();}
            catch(Exception)
            {
            }

            try{if (inReader["SalesUoM"] != null && inReader["SalesUoM"].ToString() != "")
                tempCategory3.MSalesUoM = inReader["SalesUoM"].ToString();}
            catch(Exception)
            {
            }

            try{if (inReader["PurchaseUoM"] != null && inReader["PurchaseUoM"].ToString() != "")
                tempCategory3.MPurchaseUoM = inReader["PurchaseUoM"].ToString();}
            catch(Exception)
            {
            }

            try{if (inReader["NonTaxableGood"] != null && inReader["NonTaxableGood"].ToString() != "")
                tempCategory3.MNonTaxableGood = Convert.ToBoolean(inReader["NonTaxableGood"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["NonStockable"] != null && inReader["NonStockable"].ToString() != "")
                tempCategory3.MNonStockable = Convert.ToBoolean(inReader["NonStockable"].ToString());}
            catch(Exception)
            {
            }

            try{if (inReader["SupplierID"] != null && inReader["SupplierID"].ToString() != "")
                tempCategory3.MSupplierId = Convert.ToInt32(inReader["SupplierID"].ToString());}
            catch(Exception)
            {
            }

            try{   if (inReader["Barcode"] != null && inReader["Barcode"].ToString() != "")
                tempCategory3.MBarCode = Convert.ToString(inReader["Barcode"].ToString());}
            catch(Exception){}



            try
            {
                tempCategory3.TableCost = Convert.ToDouble(inReader["tablecost"]);
            }
            catch (Exception)
            {


            }
            try
            {
                tempCategory3.TakeAwayCost = Convert.ToDouble(inReader["takeawaycost"]);
            }
            catch (Exception)
            {


            }
            try
            {
                tempCategory3.BarCost = Convert.ToDouble(inReader["barcost"]);
            }
            catch (Exception)
            {
            }


            try
            {
                tempCategory3.VatRate = Convert.ToDouble(inReader["vat_Rate"]);
            }
            catch (Exception)
            {
            }

            try
            {
                if (inReader["unlimited_status"] != null)
                    tempCategory3.MUnlimitStatus = Convert.ToInt32(inReader["unlimited_status"]);
            }
            catch (Exception)
            {
            }



            return tempCategory3;


        }


        #region CheckCat3
        private bool CheckCat3(CCategory3 inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CheckDupCat3), inUser.Category3Name, inUser.Category2ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }
        #endregion]


        #region GetMaxCatOrder
        private CResult GetMaxCatOrder()
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = SqlQueries.GetQuery(Query.GetMaxCat3Order);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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

        #endregion


        #region   Calculate Cat3 Rank
        private CResult CalculateCat3Rank(int inCat2Order, int inCat3Order)
        {
            CResult oResult = new CResult();

            String rankNumber = "";

            try
            {
                if (inCat2Order < 10 && inCat2Order > 0)
                {
                    rankNumber = "00000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100)
                {
                    rankNumber = "0000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000)
                {
                    rankNumber = "000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 10000)
                {
                    rankNumber = "00" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100000)
                {
                    rankNumber = "0" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000000)
                {
                    rankNumber = inCat2Order.ToString().Trim();
                }

                if (inCat3Order < 10 && inCat3Order > 0)
                {
                    rankNumber += "00000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100)
                {
                    rankNumber += "0000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000)
                {
                    rankNumber += "000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 10000)
                {
                    rankNumber += "00" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100000)
                {
                    rankNumber += "0" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000000)
                {
                    rankNumber += inCat3Order.ToString().Trim();
                }

                rankNumber += "000000";

                Int64 iTempInt;

                bool bTempFlag = Int64.TryParse(rankNumber, out iTempInt);

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
        #endregion


        public List<CCategory3> GetCategory3ByCategory2ID(int cat2ID)
        {
            List<CCategory3> cCategory3List = new List<CCategory3>();

            CCategory3 tempCategory3 = new CCategory3();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCategory3ByCategory2ID), cat2ID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCategory3 = new CCategory3();

                        tempCategory3 = ReaderToCategory3(oReader);
                        if (tempCategory3 != null)
                        {
                            cCategory3List.Add(tempCategory3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetCategory3byCategoryType(string categoryType)", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetCategory3byCategoryType(string categoryType)", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetCategory3byCategoryType(string categoryType)", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return cCategory3List;
        }

        private CResult GetCategory2Order(int inCat2ID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCategory2Order), inCat2ID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
        private void UpdateCat3Rank(CCat3Rank inList, int inCat2Order, int inCat3Order)
        {

            CCat3Rank oTempCat3Rank = inList;

            CResult oResult = CalculateCat3Rank(inCat2Order, inCat3Order);

            if (oResult.IsSuccess && oResult.Data != null)
            {
                Int64 iTempRank = (Int64)oResult.Data;

                String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat3Rank), iTempRank, oTempCat3Rank.Category3ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                this.ExecuteNonQuery(sSql);
            }
        }
        private void UpdateChildCat4Rank(List<CCat4Rank> inList, int inCat2Order, int inCat3Order)
        {
            for (int counter = 0; counter < inList.Count; counter++)
            {
                CCat4Rank oTempCat3Rank = inList[counter];

                CResult oResult = CalculateCat4Rank(inCat2Order, inCat3Order, oTempCat3Rank.Category4Order);

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    Int64 iTempRank = (Int64)oResult.Data;

                    String sSql = String.Format(SqlQueries.GetQuery(Query.UpdateCat4Rank), iTempRank, oTempCat3Rank.Category4ID, RMS.RMSGlobal.LoginUserName, DateTime.Now.Ticks);
                    this.ExecuteNonQuery(sSql);
                }


            }
        }
        private CResult CalculateCat4Rank(int inCat2Order, int inCat3Order, int inCat4Order)
        {
            CResult oResult = new CResult();

            String rankNumber = "";

            try
            {
                if (inCat2Order < 10 && inCat2Order > 0)
                {
                    rankNumber = "00000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100)
                {
                    rankNumber = "0000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000)
                {
                    rankNumber = "000" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 10000)
                {
                    rankNumber = "00" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 100000)
                {
                    rankNumber = "0" + inCat2Order.ToString().Trim();
                }
                else if (inCat2Order < 1000000)
                {
                    rankNumber = inCat2Order.ToString().Trim();
                }
                else
                {
                }


                if (inCat3Order < 10 && inCat3Order > 0)
                {
                    rankNumber += "00000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100)
                {
                    rankNumber += "0000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000)
                {
                    rankNumber += "000" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 10000)
                {
                    rankNumber += "00" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 100000)
                {
                    rankNumber += "0" + inCat3Order.ToString().Trim();
                }
                else if (inCat3Order < 1000000)
                {
                    rankNumber += inCat3Order.ToString().Trim();
                }
                else
                {
                }


                if (inCat4Order < 10 && inCat4Order > 0)
                {
                    rankNumber += "00000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 100)
                {
                    rankNumber += "0000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 1000)
                {
                    rankNumber += "000" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 10000)
                {
                    rankNumber += "00" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 100000)
                {
                    rankNumber += "0" + inCat4Order.ToString().Trim();
                }
                else if (inCat4Order < 1000000)
                {
                    rankNumber += inCat4Order.ToString().Trim();
                }

                Int64 iTempInt;

                bool bTempFlag = Int64.TryParse(rankNumber, out iTempInt);

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

        private CResult GetOrderCandidate(CCategory3 oCat)
        {
            CResult oResult = new CResult();
            try
            {
                List<int> iTempList = new List<int>();

                List<CCat3Rank> oTempCat3List = new List<CCat3Rank>();

                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCat3OrderCandidate), oCat.Category2ID, oCat.Category3Order);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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


                    for (int counter = 0; counter < iTempList.Count; counter++)
                    {
                        int iTempCat2ID = iTempList[counter];

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


        private CResult GetChildCat4ByCat3(int inCat2ID)
        {
            CResult oResult = new CResult();

            List<CCat4Rank> oTempList = new List<CCat4Rank>();

            try
            {

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetChildCat4ByCat3), inCat2ID);
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

        private CCat4Rank ReaderToCat4Rank(IDataReader oReader)
        {
            CCat4Rank oItem = new CCat4Rank();

            if (oReader["cat4_id"] != null)
                oItem.Category4ID = Int32.Parse(oReader["cat4_id"].ToString());

            if (oReader["cat4_order"] != null)
                oItem.Category4Order = Int32.Parse(oReader["cat4_order"].ToString());


            return oItem;

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
                    string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCat3OrderCandidateLower), oCat.Category2ID, inCatOrder, oCat.Category3Order);
                    IDataReader oReader = this.ExecuteReader(sqlCommand);
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

                        for (int counter = 0; counter < iTempList.Count; counter++)
                        {
                            int iTempCat2ID = iTempList[counter];

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

        public bool UpdateStock(int id, double reduceAmount)
        {
            bool success = false;
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.Category3UpdateStock), reduceAmount, id);
                this.ExecuteNonQuery(sqlCommand);
                success = true;

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in Category3UpdateStock()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at Category3UpdateStock()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at Category3UpdateStock()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return success;
        }

        public string GetAllCategory3printareaByCategory3ID(int productId)
        {

            string sr = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetCategory3ByCategory3ID), productId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        sr = oReader["print_area"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory3()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            
        }
            return sr;
        }
    }

}
