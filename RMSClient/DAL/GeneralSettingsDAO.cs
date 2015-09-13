using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS;
using System.Data.SqlClient;
using System.Data;

namespace RMSClient.DataAccess
{
    public class GeneralSettingsDAO : BaseDAO, IGeneralSettingsDAO
    {

        public GeneralSettingsDAO()
        { 
        
        }
        
        public CResult UpdateGeneralSettings(double vat, bool isVatEnabled, string currency)
        {
            CResult tempResult = new CResult();

            try
            {
                string updateSql = string.Format(SqlQueries.GetQuery(Query.UpdateGenerallSettings), vat,Convert.ToByte(isVatEnabled), currency);

                this.ExecuteNonQuery(updateSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }
   
            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateGeneralSettings()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateGeneralSettings()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateGeneralSettings()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }


        public CResult GetGeneralSettings()
        {
            CResult tempResult = new CResult();
            string sSql = SqlQueries.GetQuery(Query.GetGeneralSetting);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);

                GeneralSettings gSettings = new GeneralSettings();

                while (oReader.Read())
                {
                    gSettings.Vat = Convert.ToDouble(oReader[1]);
                    gSettings.IsVatEnabled = Convert.ToBoolean(oReader[2]);
                    gSettings.Currency = oReader[3].ToString(); ;
                }
                tempResult.Data = gSettings;

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetGeneralSettings()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetGeneralSettings()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetGeneralSettings()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;
        }
    }
}
