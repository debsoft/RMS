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
    public class CPcInfoDAO : BaseDAO, IPcInfoDAO
    {
        public CPcInfo PcInfoByPcIP(String inPcIP)
        {
            CPcInfo tempPcInfo = new CPcInfo();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.PcInfoByPcIP), inPcIP);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempPcInfo = ReaderToPcInfo(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in PcInfoByPcIP()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at PcInfoByPcIP()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at PcInfoByPcIP()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempPcInfo;
        }


        public List<CPcInfo> GetAllPcInfo()
        {
            List<CPcInfo> tempPcInfoList = new List<CPcInfo>();
            CPcInfo tempPcInfo = new CPcInfo();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllPcInfoBy));
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempPcInfo = ReaderToPcInfo(oReader);

                        tempPcInfoList.Add(tempPcInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllPcInfoBy()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllPcInfoBy()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllPcInfoBy()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempPcInfoList;
        }


        CPcInfo ReaderToPcInfo(IDataReader inReader)
        {
            CPcInfo tempPcInfo = new CPcInfo();

            if (inReader["pc_id"] != null)
                tempPcInfo.PcID =Int32.Parse( inReader["pc_id"].ToString());

            if (inReader["pc_ip"] != null)
                tempPcInfo.PcIP = inReader["pc_ip"].ToString();

            if (inReader["name"] != null)
                tempPcInfo.Name = inReader["name"].ToString();
            return tempPcInfo;
        }


      
    }
}
