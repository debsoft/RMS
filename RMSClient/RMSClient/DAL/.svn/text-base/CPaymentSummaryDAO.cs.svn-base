using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using RMS.Common.DataAccess;

namespace RMS.DataAccess
{
    public class CPaymentSummaryDAO : BaseDAO, IPaymentSummaryDAO
    {
        public Int64 m_oStartTime;
        public Int64 m_oEndTime;

        public CPaymentSummaryDAO()
        {
            CPaymentSummary oPaymentSummary = new CPaymentSummary();
        }

        # region IPaymentSummaryDAO members

        public CResult GetTotalPaymentForViewReport(DateTime inCurrentDate)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
            try
            {
                this.OpenConnection();

                String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
                        oPaymentSummaryList.Add(oPaymentSummary);
                    }
                }
                tempResult.Data = oPaymentSummaryList;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReport()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentForViewReport", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentSummaryByOrder()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult GetTotalPaymentForViewReportBySearch(DateTime inCurrentDate, string inRefNo, string inPrice, string inTableNo, bool inRef, bool inPr, bool inTable)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
            try
            {
                this.OpenConnection();
                int tempTableNo = 0;
                float tempPrice = 0;
                int.TryParse(inTableNo, out tempTableNo);
                float.TryParse(inPrice, out tempPrice);

                String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);
                if (inRef && inPr && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByAll), m_oStartTime, m_oEndTime, inRefNo, tempTableNo, tempPrice);
                else if (inRef && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRefNTable), m_oStartTime, m_oEndTime, inRefNo, tempTableNo);
                else if (inRef && inPr) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRefNPrice), m_oStartTime, m_oEndTime, inRefNo, tempPrice);
                else if (inPr && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByTableNPrice), m_oStartTime, m_oEndTime, tempTableNo, tempPrice);
                else if (inRef) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRef), m_oStartTime, m_oEndTime, inRefNo);
                else if (inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByTable), m_oStartTime, m_oEndTime, tempTableNo);
                else if (inPr) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByPrice), m_oStartTime, m_oEndTime, tempPrice);
                else sSql = "";//String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
                        oPaymentSummaryList.Add(oPaymentSummary);
                    }
                }
                tempResult.Data = oPaymentSummaryList;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReport()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentForViewReport", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentSummaryByOrder()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult GetTotalPaymentForViewReportByPC(DateTime inCurrentDate, int inPCID)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);
            List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
            try
            {
                this.OpenConnection();

                String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByPC), m_oStartTime, m_oEndTime, inPCID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
                        oPaymentSummaryList.Add(oPaymentSummary);
                    }
                }
                tempResult.Data = oPaymentSummaryList;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReportByPC()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentForViewReportByPC()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentSummaryByOrderByPC()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult GetTotalPaymentSummary(DateTime inCurrentDate)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            try
            {
                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotal), m_oStartTime, m_oEndTime);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oPaymentSummary = ReaderToPaymentSummary(oReader);
                    }
                }
                tempResult.Data = oPaymentSummary;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary()", LogLevel.Error, "Database");
                tempResult.IsException = true;
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
            return tempResult;

        }

        public CResult GetTotalPaymentSummaryByOrderType(DateTime inCurrentDate, String inOrderType)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            try
            {
                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotalByOrderType), m_oStartTime, m_oEndTime, inOrderType);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oPaymentSummary = ReaderToPaymentSummary(oReader);
                    }
                }
                tempResult.Data = oPaymentSummary;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary()", LogLevel.Error, "Database");
                tempResult.IsException = true;
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
            return tempResult;
        }

        public CResult GetTotalPaymentSummaryByPC(DateTime inCurrentDate, int inPCID)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            try
            {
                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotalByPC), m_oStartTime, m_oEndTime, inPCID);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oPaymentSummary = ReaderToPaymentSummary(oReader);
                    }
                }
                tempResult.Data = oPaymentSummary;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummaryByPC()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentSummaryByPC()", ex);
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
            return tempResult;

        }

        public CResult GetTotalPaymentByTypeNDate(String inType, DateTime inCurrentDate)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            float tempSummaryByType = 0;
            try
            {
                inType = inType.Replace("''", "'");
                inType = inType.Replace("'", "''");

                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotal), m_oStartTime, m_oEndTime, inType);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["type_total"] != null)
                            float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
                    }
                }
                tempResult.Data = tempSummaryByType;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentByType()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentByType(()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;

        }

        public CResult GetTotalPaymentByTypeNDateByOrderType(String inType, DateTime inCurrentDate, String inOrderType)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            float tempSummaryByType = 0;
            try
            {
                inType = inType.Replace("''", "'");
                inType = inType.Replace("'", "''");

                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotalByOrderType), m_oStartTime, m_oEndTime, inType, inOrderType);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["type_total"] != null)
                            float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
                    }
                }
                tempResult.Data = tempSummaryByType;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentByType()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentByType(()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult GetTotalPaymentByTypeNDateNPC(String inType, DateTime inCurrentDate, int inPCID)
        {
            CResult tempResult = new CResult();
            float tempSummaryByType = 0;
            GetTimeSpan(inCurrentDate);
            try
            {
                inType = inType.Replace("''", "'");
                inType = inType.Replace("'", "''");

                this.OpenConnection();
                String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotalByPC), m_oStartTime, m_oEndTime, inType, inPCID);

                IDataReader oReader = this.ExecuteReader(sSql1);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (oReader["type_total"] != null)
                            float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
                    }
                }
                tempResult.Data = tempSummaryByType;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetTotalPaymentByTypeNPC()", LogLevel.Error, "Database");
                tempResult.IsException = true;
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetTotalPaymentByTypeNPC(()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;

        }

        #endregion

        //# region IPaymentSummaryDAO members        

        //public List<CPaymentSummaryByOrder> GetTotalPaymentForViewReport(DateTime inCurrentDate)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
        //    try
        //    {
        //        this.OpenConnection();

        //        String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
        //                oPaymentSummaryList.Add(oPaymentSummary);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReport()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentForViewReport", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummaryByOrder()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummaryList;
        //}

        //public List<CPaymentSummaryByOrder> GetTotalPaymentForViewReportBySearch(DateTime inCurrentDate, string inRefNo, string inPrice, string inTableNo, bool inRef, bool inPr, bool inTable)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
        //    try
        //    {
        //        this.OpenConnection();
        //        int tempTableNo = 0;
        //        float tempPrice = 0;
        //        int.TryParse(inTableNo, out tempTableNo);
        //        float.TryParse(inPrice, out tempPrice);

        //        String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);
        //        if (inRef && inPr && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByAll), m_oStartTime, m_oEndTime, inRefNo, tempTableNo, tempPrice);
        //        else if (inRef && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRefNTable), m_oStartTime, m_oEndTime, inRefNo, tempTableNo);
        //        else if (inRef && inPr) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRefNPrice), m_oStartTime, m_oEndTime, inRefNo, tempPrice);
        //        else if (inPr && inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByTableNPrice), m_oStartTime, m_oEndTime, tempTableNo, tempPrice);
        //        else if (inRef) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByRef), m_oStartTime, m_oEndTime, inRefNo);
        //        else if (inTable) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByTable), m_oStartTime, m_oEndTime, tempTableNo);
        //        else if (inPr) sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByPrice), m_oStartTime, m_oEndTime, tempPrice);
        //        else sSql = "";//String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReport), m_oStartTime, m_oEndTime);

        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
        //                oPaymentSummaryList.Add(oPaymentSummary);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReport()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentForViewReport", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummaryByOrder()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummaryList;
        //}

        //public List<CPaymentSummaryByOrder> GetTotalPaymentForViewReportByPC(DateTime inCurrentDate, int inPCID)
        //{
        //    GetTimeSpan(inCurrentDate);
        //    List<CPaymentSummaryByOrder> oPaymentSummaryList = new List<CPaymentSummaryByOrder>();
        //    try
        //    {
        //        this.OpenConnection();

        //        String sSql = String.Format(SqlQueries.GetQuery(Query.OrderShowForViewReportByPC), m_oStartTime, m_oEndTime, inPCID);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CPaymentSummaryByOrder oPaymentSummary = ReaderToPaymentForViewReport(oReader);
        //                oPaymentSummaryList.Add(oPaymentSummary);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentForViewReportByPC()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentForViewReportByPC()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummaryByOrderByPC()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummaryList;
        //}

        //public CPaymentSummary GetTotalPaymentSummary(DateTime inCurrentDate)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    CPaymentSummary oPaymentSummary = new CPaymentSummary();
        //    try
        //    {
        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotal), m_oStartTime, m_oEndTime);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                oPaymentSummary = ReaderToPaymentSummary(oReader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentSummary()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummary()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummary;

        //}

        //public CPaymentSummary GetTotalPaymentSummaryByOrderType(DateTime inCurrentDate, String inOrderType)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    CPaymentSummary oPaymentSummary = new CPaymentSummary();
        //    try
        //    {
        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotalByOrderType), m_oStartTime, m_oEndTime, inOrderType);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                oPaymentSummary = ReaderToPaymentSummary(oReader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentSummary()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummary()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummary;
        //}

        //public CPaymentSummary GetTotalPaymentSummaryByPC(DateTime inCurrentDate, int inPCID)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    CPaymentSummary oPaymentSummary = new CPaymentSummary();
        //    try
        //    {
        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentSummaryGetTotalByPC), m_oStartTime, m_oEndTime, inPCID);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                oPaymentSummary = ReaderToPaymentSummary(oReader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentSummaryByPC()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentSummaryByPC()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentSummary()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oPaymentSummary;

        //}

        //public float GetTotalPaymentByTypeNDate(String inType, DateTime inCurrentDate)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    float tempSummaryByType = 0;
        //    try
        //    {
        //        inType = inType.Replace("''", "'");
        //        inType = inType.Replace("'", "''");

        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotal), m_oStartTime, m_oEndTime, inType);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                if (oReader["type_total"] != null)
        //                    float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentByType()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentByType(()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return tempSummaryByType;

        //}

        //public float GetTotalPaymentByTypeNDateByOrderType(String inType, DateTime inCurrentDate, String inOrderType)
        //{
        //    GetTimeSpan(inCurrentDate);

        //    float tempSummaryByType = 0;
        //    try
        //    {
        //        inType = inType.Replace("''", "'");
        //        inType = inType.Replace("'", "''");

        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotalByOrderType), m_oStartTime, m_oEndTime, inType, inOrderType);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                if (oReader["type_total"] != null)
        //                    float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentByType()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentByType(()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return tempSummaryByType;
        //}

        //public float GetTotalPaymentByTypeNDateNPC(String inType, DateTime inCurrentDate, int inPCID)
        //{
        //    float tempSummaryByType = 0;
        //    GetTimeSpan(inCurrentDate);
        //    try
        //    {
        //        inType = inType.Replace("''", "'");
        //        inType = inType.Replace("'", "''");

        //        this.OpenConnection();
        //        String sSql1 = String.Format(SqlQueries.GetQuery(Query.PaymentGetTypeTotalByPC), m_oStartTime, m_oEndTime, inType, inPCID);

        //        IDataReader oReader = this.ExecuteReader(sSql1);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                if (oReader["type_total"] != null)
        //                    float.TryParse(oReader["type_total"].ToString(), out tempSummaryByType);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetTotalPaymentByTypeNPC()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at GetTotalPaymentByTypeNPC(()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetTotalPaymentByType(", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return tempSummaryByType;

        //}

        //#endregion


        private CPaymentSummaryByOrder ReaderToPaymentForViewReport(IDataReader oReader)
        {
            CPaymentSummaryByOrder oPaymentSummary = new CPaymentSummaryByOrder();
            float tempTotalOtherPayment = 0;

            if (oReader["order_id"] != null)
                oPaymentSummary.OrderID = Int64.Parse(oReader["order_id"].ToString());

            if (oReader["order_type"] != null)
                oPaymentSummary.OrderType = oReader["order_type"].ToString();

            if (oReader["table_number"] != null)
                oPaymentSummary.TableNumber = int.Parse(oReader["table_number"].ToString());

            if (oReader["total_amount"] != null)
                oPaymentSummary.TotalPayment = float.Parse(oReader["total_amount"].ToString());

            if (oReader["cash_amount"] != null)
            {
                oPaymentSummary.TotalCashPayment = float.Parse(oReader["cash_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalCashPayment;
            }

            if (oReader["EFT_amount"] != null)
            {
                oPaymentSummary.TotalEFTPayment = float.Parse(oReader["EFT_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalEFTPayment;
            }

            if (oReader["cheque_amount"] != null)
            {
                oPaymentSummary.TotalChequePayment = float.Parse(oReader["cheque_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalChequePayment;
            }

            if (oReader["voucher_amount"] != null)
            {
                oPaymentSummary.TotalVoucherPayment = float.Parse(oReader["voucher_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalVoucherPayment;
            }

            if (oReader["service_amount"] != null)
            {
                oPaymentSummary.TotalServicePayment = float.Parse(oReader["service_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalServicePayment;
            }

            if (oReader["deposit_amount"] != null)
            {
                oPaymentSummary.TotalDepositePayment = float.Parse(oReader["deposit_amount"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalServicePayment;
            }

            if (oReader["discount"] != null)
            {
                oPaymentSummary.Discount = float.Parse(oReader["discount"].ToString());
            }

            if (oPaymentSummary.TotalOtherPayment != 0) oPaymentSummary.TotalOtherPayment = oPaymentSummary.TotalPayment - tempTotalOtherPayment;

            return oPaymentSummary;

        }

        private CPaymentSummary ReaderToPaymentSummary(IDataReader oReader)
        {
            CPaymentSummary oPaymentSummary = new CPaymentSummary();
            float tempTotalOtherPayment = 0;

            if (oReader["total"] != null)
                oPaymentSummary.TotalPayment = float.Parse(oReader["total"].ToString());

            if (oReader["cash_total"] != null)
            {
                oPaymentSummary.TotalCashPayment = float.Parse(oReader["cash_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalCashPayment;
            }

            if (oReader["EFT_total"] != null)
            {
                oPaymentSummary.TotalEFTPayment = float.Parse(oReader["EFT_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalEFTPayment;
            }

            if (oReader["cheque_total"] != null)
            {
                oPaymentSummary.TotalChequePayment = float.Parse(oReader["cheque_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalChequePayment;
            }

            if (oReader["voucher_total"] != null)
            {
                oPaymentSummary.TotalVoucherPayment = float.Parse(oReader["voucher_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalVoucherPayment;
            }

            if (oReader["service_total"] != null)
            {
                oPaymentSummary.TotalServicePayment = float.Parse(oReader["service_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalServicePayment;
            }

            if (oReader["discount_total"] != null)
            {
                oPaymentSummary.TotalDiscount = float.Parse(oReader["discount_total"].ToString());
            }

            if (oReader["deposit_total"] != null)
            {
                oPaymentSummary.TotalDepositePayment = float.Parse(oReader["deposit_total"].ToString());
                tempTotalOtherPayment += oPaymentSummary.TotalServicePayment;
            }

            if (oReader["guest_total"] != null)
                oPaymentSummary.GuestServedCount = int.Parse(oReader["guest_total"].ToString());

            if (oReader["table_total"] != null)
                oPaymentSummary.TableServedCount = int.Parse(oReader["table_total"].ToString());

            if (oPaymentSummary.TotalPayment != 0 && tempTotalOtherPayment < oPaymentSummary.TotalPayment) oPaymentSummary.TotalOtherPayment = oPaymentSummary.TotalPayment - tempTotalOtherPayment;

            return oPaymentSummary;

        }

        public void GetTimeSpan(DateTime inCurrentDate)
        {
            Int64 tempStartTime = inCurrentDate.Ticks;
            Int64 tempEndTime = inCurrentDate.AddDays(1).Ticks;

            Int64 tempCheckTime = (inCurrentDate.Date.AddHours(8)).Ticks;

            if (inCurrentDate.Ticks < tempCheckTime)
            {
                tempStartTime = tempCheckTime - 864000000000;
                tempEndTime = tempCheckTime;
            }

            else if (inCurrentDate.Ticks >= tempCheckTime)
            {
                tempStartTime = tempCheckTime;
                tempEndTime = tempCheckTime + 864000000000;
            }

            m_oStartTime = tempStartTime;
            m_oEndTime = tempEndTime;

        }

    }
}
