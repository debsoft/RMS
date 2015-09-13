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
    public class CButtonAccessDAO : BaseDAO, IButtonAccessDAO
    {
        #region IButtonAccessDAO members
        public void ButtonAccessInsert(CButtonAccess inButtonAccess)
        { 

        }

        public void ButtonAccessUpdate(CButtonAccess inButtonAccess)
        {
        }
        public void ButtonAccessDelete(CButtonAccess inButtonAccess)
        {
        }

        public List<CButtonAccess> GetAllButtonAccess()
        {
            List<CButtonAccess> tempButtonAccessList = new List<CButtonAccess>();

            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.ButtonAccessGetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CButtonAccess tempButtonAccess = ReaderToButtonAccess(oReader);
                        tempButtonAccessList.Add(tempButtonAccess);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllButtonAccess()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllButtonAccess()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllButtonAccess()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempButtonAccessList;
        }

        #endregion

        private CButtonAccess ReaderToButtonAccess(IDataReader inReader)
        {
            CButtonAccess tempButtonAccess = new CButtonAccess();

            if (inReader["user_id"] != null)
                tempButtonAccess.UserID = int.Parse(inReader["user_id"].ToString());

            if (inReader["button_id"] != null)
                tempButtonAccess.ButtonID = int.Parse(inReader["button_id"].ToString());

            
            return tempButtonAccess;

        }
    }
}
