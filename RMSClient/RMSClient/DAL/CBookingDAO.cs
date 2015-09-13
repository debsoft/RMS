using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS.Common;
using RMS;
using System.Data.SqlClient;

namespace RMS.DataAccess
{
    public class CBookingDAO : BaseDAO, IBookingDAO
    {
        public Int64 m_oStartTime;//Changed
        public Int64 m_oEndTime;

        public CBookingDAO()
        {
        }

        public CResult GetBookingInfoAll(DateTime inCurrentDate)
        {
            CResult tempResult = new CResult();
            GetTimeSpan(inCurrentDate);

            List<CBooking> oBookingList = new List<CBooking>();

            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.BookingInfoGetAll), m_oStartTime, m_oEndTime);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CBooking oBooking = ReaderToBooking(oReader);
                        oBookingList.Add(oBooking);
                    }
                }
                tempResult.Data = oBookingList;
                tempResult.IsSuccess = true;

                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                tempResult.IsException = true;

                Logger.Write("Exception : " + ex + " in GetBookingInfoAll()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetBookingInfoAll()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetBookingInfoAll()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;
        }

        public CResult GetBookingInfoByID(Int64 inBookingID)
        {
            CResult tempResult = new CResult();

            CBooking oBookingList = new CBooking();

            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.BookingInfoGetByID), inBookingID);

                IDataReader oReader = this.ExecuteReader(sSql);
                CBooking oBooking = new CBooking();
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oBooking = ReaderToBooking(oReader);
                    }
                }
                tempResult.Data = oBooking;
                tempResult.IsSuccess = true;

                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                tempResult.IsException = true;

                Logger.Write("Exception : " + ex + " in GetBookingInfoAll()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetBookingInfoAll()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetBookingInfoAll()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;
        }

        public CResult InsertBookingInfo(CBooking inBookingInfo)
        {
            CResult tempResult = new CResult();

            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.BookingInfoInsert), inBookingInfo.BookingType, inBookingInfo.BookingTime, inBookingInfo.CustomerID, inBookingInfo.GuestCount, inBookingInfo.Status, inBookingInfo.Comments, inBookingInfo.TableCount);

                this.ExecuteNonQuery(sSql);

                tempResult.IsSuccess = true;
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                tempResult.IsException = true;

                Logger.Write("Exception : " + ex + " in InsertBookingInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at InsertBookingInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertBookingInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;

        }

        public CResult UpdateBookingInfo(CBooking inBookingInfo)
        {
            CResult tempResult = new CResult();

            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.BookingInfoUpdate), inBookingInfo.BookingID, inBookingInfo.BookingType, inBookingInfo.BookingTime, inBookingInfo.CustomerID, inBookingInfo.GuestCount, inBookingInfo.Status, inBookingInfo.Comments, inBookingInfo.TableCount);

                this.ExecuteNonQuery(sSql);

                tempResult.IsSuccess = true;
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                tempResult.IsException = true;

                Logger.Write("Exception : " + ex + " in DeleteBookingInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteBookingInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteBookingInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;

        }

        public CResult DeleteBookingInfo(Int64 inBookingID)
        {
            CResult tempResult = new CResult();

            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.BookingInfoDelete), inBookingID);

                this.ExecuteNonQuery(sSql);

                tempResult.IsSuccess = true;
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                tempResult.IsException = true;

                Logger.Write("Exception : " + ex + " in DeleteBookingInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteBookingInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteBookingInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;

        }


        private CBooking ReaderToBooking(IDataReader oReader)
        {
            CBooking oBookingInfo = new CBooking();
            int tempTables = 0;
            int tempGuests = 0;

            if (oReader["booking_id"] != null)
                oBookingInfo.BookingID = Int64.Parse(oReader["booking_id"].ToString());

            if (oReader["customer_id"] != null)
                oBookingInfo.CustomerID = Int64.Parse(oReader["customer_id"].ToString());

            if (oReader["booking_time"] != null)
                oBookingInfo.BookingTime = Int64.Parse(oReader["booking_time"].ToString());

            if (oReader["booking_type"] != null)
                oBookingInfo.BookingType = oReader["booking_type"].ToString();

            if (oReader["status"] != null)
                oBookingInfo.Status = oReader["status"].ToString();

            if (oReader["comments"] != null)
                oBookingInfo.Comments = oReader["comments"].ToString();

            if (oReader["guest_count"] != null)
            {
                int.TryParse(oReader["guest_count"].ToString(), out tempGuests);
                oBookingInfo.GuestCount = tempGuests;
            }

            if (oReader["table_count"] != null)
            {
                int.TryParse(oReader["table_count"].ToString(), out tempTables);
                oBookingInfo.TableCount = tempTables;
            }

            if (oReader["name"] != null)
                oBookingInfo.CustomerName = oReader["name"].ToString();

            if (oReader["phone"] != null)
                oBookingInfo.Phone = oReader["phone"].ToString();

            if (oReader["address"] != null)
                oBookingInfo.Address = oReader["address"].ToString();

            return oBookingInfo;

        }

        public void GetTimeSpan(DateTime inCurrentDate)//Changed
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
