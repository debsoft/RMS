using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace RMS.DataAccess
{
    public class CReportDAO : BaseDAO, IReportDAO
    {
        public Int64 m_oStartTime;//Changed
        public Int64 m_oEndTime;

        public CReportDAO()
        {
        }

        #region IReportDAO Members

        private CPaymentSummary ReaderToPaymentSummary(IDataReader oReader)
        {
            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            float tempTotalOtherPayment = 0;

            if (oReader["total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["total"].ToString(), out temp);
                oPaymentSummary.TotalPayment = temp;
            }

            if (oReader["cash_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["cash_total"].ToString(), out temp);
                oPaymentSummary.TotalCashPayment = temp;
            }

            if (oReader["EFT_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["EFT_total"].ToString(), out temp);
                oPaymentSummary.TotalEFTPayment = temp;
            }

            if (oReader["cheque_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["cheque_total"].ToString(), out temp);
                oPaymentSummary.TotalChequePayment = temp;
            }

            if (oReader["voucher_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["voucher_total"].ToString(), out temp);
                oPaymentSummary.TotalVoucherPayment = temp;
            }

            if (oReader["service_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["service_total"].ToString(), out temp);
                oPaymentSummary.TotalServicePayment = temp;
            }

            if (oReader["deposit_total"] != null)
            {
                float temp = 0;
                float.TryParse(oReader["deposit_total"].ToString(), out temp);
                oPaymentSummary.TotalDepositPayment = temp;
            }

            return oPaymentSummary;
        }

        public RMS.Common.ObjectModel.CPaymentSummary GetTotalPaymentSummary(long inStartDate, long inEndDate)
        {
            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            try
            {
                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotal), inStartDate, inEndDate);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oPaymentSummary = ReaderToPaymentSummary(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentSummary()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentSummary()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oPaymentSummary;
        }

        public RMS.Common.ObjectModel.CResult GetTotalReport(long inStartTime, long inEndTime)
        {
            CResult oTempResult = new CResult();
            List<CReport> oReportList = new List<CReport>();
            Int64 tempStartTime = inStartTime;
            float tempResTotal = 0;
            float tempBarTotal = 0;
            float tempRoomTotal = 0;
            float tempExeTotal = 0;

            try
            {
                while (tempStartTime < inEndTime)
                {
                    CReport oReport = new CReport();
                    Int64 tempEndTime = tempStartTime + 864000000000;
                    //if (tempEndTime > inEndTime)
                    //{
                    //    tempEndTime = inEndTime;
                    //}
                    //else ;

                    this.OpenConnection();

                    int count = 0;
                    String sSql = String.Format(SqlQueries.GetQuery(Query.GetOrderCountByDate), tempStartTime, tempEndTime);
                    IDataReader oReader = this.ExecuteReader(sSql);
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            int.TryParse(oReader["total"].ToString(), out count);
                        }
                    }
                    oReader.Close();

                    if (count > 0)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetTotalPaymentByDayNDept), tempStartTime, tempEndTime, "Resturent");
                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {
                            while (oReader.Read())
                            {
                                tempResTotal = 0;
                                float.TryParse(oReader["total"].ToString(), out tempResTotal);
                            }
                        }
                        oReader.Close();

                        sSql = String.Format(SqlQueries.GetQuery(Query.GetTotalPaymentByDayNDept), tempStartTime, tempEndTime, "BarService");
                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {
                            while (oReader.Read())
                            {
                                tempBarTotal = 0;
                                float.TryParse(oReader["total"].ToString(), out tempBarTotal);
                            }
                        }
                        oReader.Close();

                        sSql = String.Format(SqlQueries.GetQuery(Query.GetTotalPaymentByDayNDept), tempStartTime, tempEndTime, "WhiteRoom");
                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {
                            while (oReader.Read())
                            {
                                tempRoomTotal = 0;
                                float.TryParse(oReader["total"].ToString(), out tempRoomTotal);
                            }
                        }
                        oReader.Close();

                        sSql = String.Format(SqlQueries.GetQuery(Query.GetTotalPaymentByDayNDept), tempStartTime, tempEndTime, "ExecutiveBar");
                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {
                            while (oReader.Read())
                            {
                                tempExeTotal = 0;
                                float.TryParse(oReader["total"].ToString(), out tempExeTotal);
                            }
                        }
                        oReader.Close();

                        oReport.Date = tempStartTime;
                        oReport.ResturentPayment = tempResTotal;
                        oReport.BarServicePayment = tempBarTotal;
                        oReport.WhiteRoomPayment = tempRoomTotal;
                        oReport.ExecutiveBarPayment = tempExeTotal;

                        oReport.TotalPayment = (tempResTotal + tempBarTotal + tempRoomTotal + tempExeTotal);
                        oReport.VATPayment = (float)(oReport.TotalPayment * 17.5 / 100);

                        oReportList.Add(oReport);
                    }
                    tempStartTime += 864000000000;
                }
                oTempResult.Data = oReportList;
                oTempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                oTempResult.IsException = true;
                Logger.Write("Exception : " + ex + " in GetTotalReport()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalReport", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalReport()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oTempResult;
        }

        #endregion
    }
}
