using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using System.Data;
using RMS.Common.ObjectModel;
using RMS;

namespace RMSClient.DataAccess
{
    public class CCategoryAncestorDAO : BaseDAO, ICategoryAncestorDAO
    {
        #region ICategoryAncestorDAO Members

        public RMS.Common.ObjectModel.CResult GetCategoryAnchestors(int inLeafCategoryID, int inCatLevel)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = String.Empty;

                if (inCatLevel == 4)
                {
                    sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory4Anchestor), inLeafCategoryID);
                }
                else if (inCatLevel == 3)
                {
                    sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory3Anchestor), inLeafCategoryID);
                }
                else if (inCatLevel == 2)
                {
                    sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory2Anchestor), inLeafCategoryID);
                }
                else if (inCatLevel == 1)
                {
                    sSql = string.Format(SqlQueries.GetQuery(Query.GetCategory1Anchestor), inLeafCategoryID);
                }

                IDataReader oReader = this.ExecuteReader(sSql);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oResult.Data = ReaderToCategoryAnchestor(oReader);
                    }
                }
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

        private CCategoryAncestor ReaderToCategoryAnchestor(IDataReader oReader)
        {
            CCategoryAncestor oItem = new CCategoryAncestor();

            if (oReader["cat4_id"] != null)
                oItem.Category4ID = Int32.Parse(oReader["cat4_id"].ToString());

            if (oReader["cat3_id"] != null)
                oItem.Category3ID = Int32.Parse(oReader["cat3_id"].ToString());

            if (oReader["cat2_id"] != null)
                oItem.Category2ID = Int32.Parse(oReader["cat2_id"].ToString());

            if (oReader["cat1_id"] != null)
                oItem.Category1ID = Int32.Parse(oReader["cat1_id"].ToString());

            if (oReader["parent_cat_id"] != null)
                oItem.ParentCategoryID = Int32.Parse(oReader["parent_cat_id"].ToString());

            if (oReader["cat4_order"] != null)
                oItem.Cat4Order = int.Parse(oReader["cat4_order"].ToString());

            if (oReader["cat3_order"] != null)
                oItem.Cat3Order = int.Parse(oReader["cat3_order"].ToString());

            if (oReader["cat2_order"] != null)
                oItem.Cat2Order = int.Parse(oReader["cat2_order"].ToString());


            return oItem;
        }
        #endregion
    }
}
