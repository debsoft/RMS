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
    public class CCategory2DAO : BaseDAO, ICategory2DAO
    {
        #region ICategory2DAO members
        public void Category2Insert(CCategory2 inCategory2)
        {
        }

        public void Category2Update(CCategory2 inCategory2)
        {
        }
        public void Category2Delete(CCategory2 inCategory2)
        {
        }

        public List<CCategory2> GetAllCategory2()
        {
            List<CCategory2> tempCategory2List = new List<CCategory2>();
            try
            {
                this.OpenConnection();
                string sqlCommand = SqlQueries.GetQuery(Query.Category2GetAll);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory2 tempCategory2 = ReaderToCategory2(oReader);
                        tempCategory2List.Add(tempCategory2);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory2()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory2()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory2()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCategory2List;
        }

        #endregion

        private CCategory2 ReaderToCategory2(IDataReader inReader)
        {
            CCategory2 tempCategory2 = new CCategory2();

            if (inReader["cat2_id"] != null)
                tempCategory2.Category2ID = int.Parse(inReader["cat2_id"].ToString());

            if (inReader["cat2_name"] != null)
                tempCategory2.Category2Name = inReader["cat2_name"].ToString();

            if(inReader["cat2_order"] != null)
                tempCategory2.Category2Order = int.Parse(inReader["cat2_order"].ToString());

            if (inReader["cat1_id"] != null)
                tempCategory2.Category1ID = int.Parse(inReader["cat1_id"].ToString());

            if (inReader["cat2_type"] != null)
                tempCategory2.Category2Type = int.Parse(inReader["cat2_type"].ToString());

            if (inReader["cat2_color"] != null)
                tempCategory2.Category2Color = inReader["cat2_color"].ToString();

            if (inReader["view_table"] != null)
                tempCategory2.Category2ViewTable = int.Parse(inReader["view_table"].ToString());

            if (inReader["view_bar"] != null)
                tempCategory2.Category2ViewBar = int.Parse(inReader["view_bar"].ToString());

            if (inReader["view_takeaway"] != null)
                tempCategory2.Category2ViewTakeAway = int.Parse(inReader["view_takeaway"].ToString());

            return tempCategory2;

        }
    }
}
