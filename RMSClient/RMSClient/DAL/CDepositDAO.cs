using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;


namespace RMS.DataAccess
{
    public class CDepositDAO : BaseDAO, IDepositDAO
    {
        #region IDepositDAO members

        public CResult InsertDeposit(CDeposit inDeposit)
        {
            CResult oResult = new CResult();

            try
            {

                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.DepositInsert), inDeposit.DepositBalance, inDeposit.DepositTime, inDeposit.CustomerID, inDeposit.DepositTotalAmount,inDeposit.PcID,inDeposit.Status,inDeposit.DepositType);
                this.ExecuteNonQuery(sSql);

                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        inDeposit.DepositID = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }

                oResult.Data = inDeposit;
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

        public CResult UpdateDeposit(CDeposit inDeposit)
        {
            CResult oResult = new CResult();

            try
            {

                this.OpenConnection();
                string sSql;
                
                sSql = String.Format(SqlQueries.GetQuery(Query.DepositUpdate), inDeposit.DepositBalance, inDeposit.DepositTime, inDeposit.CustomerID, inDeposit.DepositTotalAmount, inDeposit.PcID, inDeposit.Status, inDeposit.DepositType, inDeposit.DepositID);
                
                this.ExecuteNonQuery(sSql);


                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateDeposit()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at OrderDetailsInsert()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public CResult GetDepositByDepositID(Int64 inDepositID)
        {
            CResult oResult = new CResult();

            try
            {
                CDeposit tempDeposit = new CDeposit();
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.DepositGetByDepositID), inDepositID);


                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempDeposit = ReaderToDeposit(oReader);
                    }
                    oReader.Close();
                }

                oResult.Data = tempDeposit;
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

        public CResult InsertDepositUsed(CDepositUsed inDepositUsed)
        {
            CResult oResult = new CResult();

            try
            {

                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.InsertDepositUsed), inDepositUsed.DepositID, inDepositUsed.UsedAmount);
                this.ExecuteNonQuery(sSql);

                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        inDepositUsed.DepositUseID = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }

                oResult.Data = inDepositUsed;
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDepositUsed()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at OrderDetailsInsert()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        #endregion


        private CDeposit ReaderToDeposit(IDataReader inReader)
        {
            CDeposit tempDeposit = new CDeposit();

            if (inReader["deposit_id"] != null)
                tempDeposit.DepositID = Int64.Parse(inReader["deposit_id"].ToString());


            if (inReader["balance"] != null)
                tempDeposit.DepositBalance = Double.Parse(inReader["balance"].ToString());


            if (inReader["deposit_time"] != null)
                tempDeposit.DepositTime = Int64.Parse(inReader["deposit_time"].ToString());

            if (inReader["customer_id"] != null)
                tempDeposit.CustomerID = Int64.Parse(inReader["customer_id"].ToString());

            if (inReader["total_amount"] != null)
                tempDeposit.DepositTotalAmount = Double.Parse(inReader["total_amount"].ToString());

            if (inReader["pc_id"] != null)
                tempDeposit.PcID = Int32.Parse(inReader["pc_id"].ToString());

            if (inReader["status"] != null)
                tempDeposit.Status = Int32.Parse(inReader["status"].ToString());

            if (inReader["deposit_type"] != null)
                tempDeposit.DepositType = inReader["deposit_type"].ToString();

            return tempDeposit;

        }
    }
}
