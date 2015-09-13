using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;

namespace RMS.DataAccess
{
    public class CItemDAO : BaseDAO, IItemDAO
    {
        public CItemDAO()
        {

        }

        public void DeleteExpiredItems()
        {
            try
            {
                //CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
                //this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteExpiredItem), oTempConstant.ITEM_EXPIRE_DAYS);
                //this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteExpiredItems()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at DeleteExpiredItems()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }


        #region IItemDAO Members

      public  CResult SaveProductPLU(int productID, int categoryLabel, int productPLU)
        {
            Int32 categoryID = 0;
            CResult objResult = new CResult();  
            int resultantValue = -1;
            this.OpenConnection();
            string sqlCommand = "";

            this.OpenConnection();

                sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetProduct3IDFromPLU), productPLU);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["cat3_id"] != null)
                        {
                            categoryID = Int32.Parse(oReader["cat3_id"].ToString());

                            objResult.Data = categoryID;

                            objResult.IsSuccess = true;
                        }
                    }
                }

                oReader.Close();

                if (categoryID == 0) //If after category 3 no item found.
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetProduct4IDFromPLU), productPLU);
                    oReader = this.ExecuteReader(sqlCommand);
                    if (oReader != null)
                    {
                        if (oReader.Read())
                        {
                            if (oReader["cat4_id"] != null)
                            {
                                categoryID = Int32.Parse(oReader["cat4_id"].ToString());

                                objResult.Data = categoryID;

                                objResult.IsSuccess = true;
                            }
                        }
                    }
                    oReader.Close();
                }
          

            if (categoryID == 0)//If no product for the PLU
            {
                if (categoryLabel == 3)
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.SaveProduct3PLU), productPLU, productID);
                }
                else
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.SaveProduct4PLU), productPLU, productID);
                }
                this.ExecuteNonQuery(sqlCommand);
            }
            else
            {
                resultantValue = 1;
                objResult.Data = resultantValue;
            }
            objResult.Data = resultantValue;
            return objResult;
        }

        #endregion
    }
}
