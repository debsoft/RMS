using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS;


namespace RMS.DataAccess
{
    public class CButtonColorDAO : BaseDAO, IButtonColorDAO
    {
        #region IButtonColorDAO Members

        public CResult AddButtonColor(RMS.Common.ObjectModel.CButtonColor inUser)
        {
            CResult oResult = new CResult();

            inUser.ButtonName = inUser.ButtonName.Replace("''", "'");
            inUser.ButtonName = inUser.ButtonName.Replace("'", "''");
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonColor), inUser.ButtonName, inUser.ButtonColor, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult GetButtonColor(RMS.Common.ObjectModel.CButtonColor inCat)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetButtonColor), inCat.ButtonID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        inCat = ReaderToButtonColor(oReader);

                        oResult.Data = inCat;

                        oResult.IsSuccess = true;
                    }
                }
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

         public CResult UpdateButtonColor(RMS.Common.ObjectModel.CButtonColor inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdateButtonColor), inUser.ButtonColor, inUser.ButtonID, inUser.CurrentUserId, inUser.LoginDateTime);

                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private CButtonColor ReaderToButtonColor(IDataReader oReader)
        {
            CButtonColor oItem = new CButtonColor();

            if (oReader["button_id"] != null)
                oItem.ButtonID = Int32.Parse(oReader["button_id"].ToString());

            if (oReader["name"] != null)
                oItem.ButtonName = oReader["name"].ToString();

            if (oReader["color"] != null)
                oItem.ButtonColor = oReader["color"].ToString();

            return oItem;

        }

        #endregion
    }
}
