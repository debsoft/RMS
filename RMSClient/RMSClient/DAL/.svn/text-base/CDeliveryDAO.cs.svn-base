using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;


namespace RMS.DataAccess
{
    public class CDeliveryDAO : BaseDAO, IDeliveryDAO
    {
        public CResult InsertDelivery(CDelivery inDelivery)
        {
            CResult oResult = new CResult();

            try
            {

                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.InsertDelivery),inDelivery.DeliveryOrderID,inDelivery.DeliveryTime);
                this.ExecuteNonQuery(sSql);

                
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at OrderDetailsInsert()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

    }
}
