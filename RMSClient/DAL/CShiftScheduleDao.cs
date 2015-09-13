using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using RMS;

namespace RMSClient.DataAccess
{
  public  class CShiftScheduleDao : BaseDAO, IShiftScheduleDao
    {
        public RMS.Common.ObjectModel.CShiftSchedule AddShiftSchedule(RMS.Common.ObjectModel.CShiftSchedule shiftSchedule)
        {
            try
            {
                string insertSql = String.Format(SqlQueries.GetQuery(Query.AddShiftSchedule), shiftSchedule.CreationDate, shiftSchedule.ShiftNo, shiftSchedule.StartDay, shiftSchedule.StartTime, shiftSchedule.EndDay, shiftSchedule.EndTime, shiftSchedule.StartTimestamp, shiftSchedule.EndTimestamp, shiftSchedule.Isactive, shiftSchedule.ShiftId);

                this.ExecuteNonQuery(insertSql);
                this.CommitTransection();
                // tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                //  tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in AddShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at AddShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at AddShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftSchedule;
        }

        public RMS.Common.ObjectModel.CShiftSchedule UpdateShiftSchedule(RMS.Common.ObjectModel.CShiftSchedule shiftSchedule)
        {
            try
            {
                string updateSql = String.Format(SqlQueries.GetQuery(Query.UpdateShiftSchedule), shiftSchedule.CreationDate, shiftSchedule.ShiftNo, shiftSchedule.StartDay, shiftSchedule.StartTime, shiftSchedule.EndDay, shiftSchedule.EndTime, shiftSchedule.StartTimestamp, shiftSchedule.EndTimestamp, shiftSchedule.Isactive, shiftSchedule.ShiftId, shiftSchedule.ScheduleId);

                this.ExecuteNonQuery(updateSql);
                this.CommitTransection();
                //tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                //   tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return shiftSchedule;
        }

        public bool DeleteShiftSchedule( long shiftScheuleID)
        {
            try
            {
                string deletSql = String.Format(SqlQueries.GetQuery(Query.DeleteShiftSchedule), shiftScheuleID);

                this.ExecuteNonQuery(deletSql);
                this.CommitTransection();
            }

            catch (Exception ex)
            {
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in DeleteShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteShiftManage()", ex);
                }

                return false;
            }
            finally
            {
                this.CloseConnection();
            }
            return true;
        }

        public List<RMS.Common.ObjectModel.CShiftSchedule> GetAllShiftSchedule()
        {
            List<CShiftSchedule> shiftScheduleList = new List<CShiftSchedule>();

            string sSql = SqlQueries.GetQuery(Query.GetAllShiftSchedule);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);


                while (oReader.Read())
                {
                    CShiftSchedule shiftSchedule = new CShiftSchedule();

                    shiftSchedule = ReaderToShiftSchedule(oReader);

                    shiftScheduleList.Add(shiftSchedule);
                }


            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftScheduleList;
        }

        public RMS.Common.ObjectModel.CShiftSchedule GetAllShiftScheduleID(long shiftScheuleID)
        {
            CShiftSchedule shiftSchedule = new CShiftSchedule();

            string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllShiftScheduleID), shiftScheuleID);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);


                while (oReader.Read())
                {
                    shiftSchedule = ReaderToShiftSchedule(oReader);

                }


            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManageByShiftID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManageByShiftID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManageByShiftID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return shiftSchedule;
        }

        public List<CShiftSchedule> GetAllShiftScheduleByShiftID(long ShiftID)
        {
            List<CShiftSchedule> shiftScheduleList = new List<CShiftSchedule>();

            string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllShiftScheduleByShiftID), ShiftID);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);


                while (oReader.Read())
                {
                    CShiftSchedule shiftSchedule = new CShiftSchedule();

                    shiftSchedule = ReaderToShiftSchedule(oReader);

                    shiftScheduleList.Add(shiftSchedule);
                }


            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftScheduleList;
        }



        public List<CShiftSchedule> GetAllShiftSCheduleByCreationDate(DateTime creationDate)
        {
            List<CShiftSchedule> shiftScheduleList = new List<CShiftSchedule>();

            string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllShiftSCheduleByCreationDate), creationDate);

            try
            {
                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);

                while (oReader.Read())
                {
                    CShiftSchedule shiftSchedule = new CShiftSchedule();

                    shiftSchedule = ReaderToShiftSchedule(oReader);

                    shiftScheduleList.Add(shiftSchedule);
                }

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftScheduleList;
        }



        private CShiftSchedule ReaderToShiftSchedule(IDataReader inReader)
        {
            CShiftSchedule tempShiftSchedule = new CShiftSchedule();

            if (inReader["schedule_id"] != null)
                tempShiftSchedule.ScheduleId = Int64.Parse(inReader["schedule_id"].ToString());


            if (inReader["shift_id"] != null)
                tempShiftSchedule.ShiftId = Int64.Parse(inReader["shift_id"].ToString());

         

                if (inReader["shift_no"] != null)
                tempShiftSchedule.ShiftNo = Int32.Parse(inReader["shift_no"].ToString());


            if (inReader["creationDate"] != null)
                tempShiftSchedule.CreationDate = Convert.ToDateTime(inReader["creationDate"].ToString());

            if (inReader["start_day"] != null)
                tempShiftSchedule.StartDay = Convert.ToDateTime(inReader["start_day"].ToString());

            if (inReader["start_time"] != null)
                tempShiftSchedule.StartTime = Convert.ToDateTime(inReader["start_time"].ToString());

            if (inReader["end_day"] != null)
                tempShiftSchedule.EndDay = Convert.ToDateTime(inReader["end_day"].ToString());


            if (inReader["end_time"] != null)
                tempShiftSchedule.EndTime = Convert.ToDateTime(inReader["end_time"].ToString());


            if (inReader["start_timestamp"] != null)
                tempShiftSchedule.StartTimestamp = Int64.Parse(inReader["start_timestamp"].ToString());

            if (inReader["end_timestamp"] != null)
                tempShiftSchedule.EndTimestamp = Int64.Parse(inReader["end_timestamp"].ToString());          


            if (inReader["isactive"] != null)
                tempShiftSchedule.Isactive = Boolean.Parse( inReader["isactive"].ToString());


            return tempShiftSchedule;

        }


      
    }
}
