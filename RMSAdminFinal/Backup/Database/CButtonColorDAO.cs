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

        public CResult AddButtonColor(RMS.Common.ObjectModel.CButtonColor p_buttonColor)
        {
            CResult objResult = new CResult();

            p_buttonColor.ButtonName = p_buttonColor.ButtonName.Replace("''", "'");
            p_buttonColor.ButtonName = p_buttonColor.ButtonName.Replace("'", "''");
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonColor), p_buttonColor.ButtonName, p_buttonColor.ButtonColor, RMSGlobal.LogInUserName, DateTime.Now.Ticks);

                this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        public CResult GetButtonColor(RMS.Common.ObjectModel.CButtonColor p_buttonColor)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetButtonColor), p_buttonColor.ButtonID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        p_buttonColor = ReaderToButtonColor(oReader);

                        oResult.Data = p_buttonColor;

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

         public CResult UpdateButtonColor(RMS.Common.ObjectModel.CButtonColor p_buttonColor)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateButtonColor), p_buttonColor.ButtonColor, p_buttonColor.ButtonID, p_buttonColor.CurrentUserId, p_buttonColor.LoginDateTime);

                this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        private CButtonColor ReaderToButtonColor(IDataReader p_objReader)
        {
            CButtonColor oItem = new CButtonColor();

            if (p_objReader["button_id"] != null)
                oItem.ButtonID = Int32.Parse(p_objReader["button_id"].ToString());

            if (p_objReader["name"] != null)
                oItem.ButtonName = p_objReader["name"].ToString();

            if (p_objReader["color"] != null)
                oItem.ButtonColor = p_objReader["color"].ToString();

            return oItem;

        }

        #endregion
    }
}
