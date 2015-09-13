using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;

namespace RMS.DataAccess
{
    public class CParentCategoryDAO : BaseDAO, IParentCategoryDAO
    {
        public CParentCategoryDAO()
        {
        }

        #region IParentCategoryDAO Members

        public RMS.Common.ObjectModel.CResult AddParentCat(RMS.Common.ObjectModel.CParentCategory inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckParentCat(inUser);

                if (bTempFlag)
                {
                    oResult.Message = "Parent category exists with this name.";
                }
                else
                {

                    this.OpenConnection();
                    string sSql = String.Format(SqlQueries.GetQuery(Query.AddParentCategory), inUser.ParentCatName, inUser.ParentCatID);

                    this.ExecuteNonQuery(sSql);

                    oResult.IsSuccess = true;


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

        public RMS.Common.ObjectModel.CResult GetParentCategory(RMS.Common.ObjectModel.CParentCategory inCat)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.GetParentCatByID), inCat.ParentCatID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        CParentCategory oCat = ReaderToParentCategory(oReader);

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

        private CParentCategory ReaderToParentCategory(IDataReader oReader)
        {
            CParentCategory oItem = new CParentCategory();



            if (oReader["parent_cat_id"] != null)
                oItem.ParentCatID = Int32.Parse(oReader["parent_cat_id"].ToString());

            if (oReader["parent_cat_name"] != null)
                oItem.ParentCatName = oReader["parent_cat_name"].ToString();

            return oItem;

        }

        private bool CheckParentCat(CParentCategory inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupParentCat), inUser.ParentCatName);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["parent_cat_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["parent_cat_id"].ToString());

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


        private bool CheckParentCatUpdate(CParentCategory inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupParentCatUpdate), inUser.ParentCatName, inUser.ParentCatID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["parent_cat_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["parent_cat_id"].ToString());

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

        public RMS.Common.ObjectModel.CResult ParentCatDelete(RMS.Common.ObjectModel.CParentCategory oCat)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteParentCategory), oCat.ParentCatID);
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

        public RMS.Common.ObjectModel.CResult ParentCatUpdate(RMS.Common.ObjectModel.CParentCategory oCat)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = CheckParentCatUpdate(oCat);

                if (bTempFlag)
                {
                    oResult.Message = "Parent category exists with this name.";
                }
                else
                {
                    this.OpenConnection();
                    string sSql = string.Format(SqlQueries.GetQuery(Query.UpdateParentCategory), oCat.ParentCatName, oCat.ParentCatID);
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

        #endregion
    }
}
