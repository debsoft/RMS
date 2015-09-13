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
    public class CButtonColorDAO : BaseDAO, IButtonColorDAO
    {
        #region IButtonColorDAO members
        public void ButtonColorInsert(CButtonColor inButtonColor)
        {

        }

        public void ButtonColorUpdate(CButtonColor inButtonColor)
        {
        }
        public void ButtonColorDelete(CButtonColor inButtonColor)
        {
        }

        public List<CButtonColor> GetAllButtonColor()
        {
            List<CButtonColor> tempButtonColorList = new List<CButtonColor>();

            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.ButtonColorGetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CButtonColor tempButtonColor = ReaderToButtonColor(oReader);
                        tempButtonColorList.Add(tempButtonColor);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllButtonColor()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllButtonColor()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllButtonColor()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempButtonColorList;
        }

        public CButtonColor ButtonColorGetByButtonName(String inButtonName)
        {
            CButtonColor tempButtonColor = new CButtonColor();

            try
            {
                this.OpenConnection();
                string sSql =String.Format(SqlQueries.GetQuery(Query.ButtonColorByButtonName),inButtonName);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempButtonColor = ReaderToButtonColor(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in ButtonColorGetByButtonName()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at ButtonColorGetByButtonName()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at ButtonColorGetByButtonName()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempButtonColor;
        }


        #endregion

        private CButtonColor ReaderToButtonColor(IDataReader inReader)
        {
            CButtonColor tempButtonColor = new CButtonColor();

            if (inReader["button_id"] != null)
                tempButtonColor.ButtonID = int.Parse(inReader["button_id"].ToString());

            if (inReader["name"] != null)
                tempButtonColor.ButtonName = inReader["name"].ToString();

            if (inReader["color"] != null)
                tempButtonColor.ButtonColor = inReader["color"].ToString();


            return tempButtonColor;

        }
    }
}
