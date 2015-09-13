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
    public class CCategory3DAO : BaseDAO, ICategory3DAO 
    {
        #region ICategory3DAO members
        public void Category3Insert(CCategory3 inCategory3)
        {
        }

        public void Category3Update(CCategory3 inCategory3)
        {
        }
        public void Category3Delete(CCategory3 inCategory3)
        {
        }

        public List<CCategory3> GetAllCategory3()
        {
            List<CCategory3> tempCategory3List = new List<CCategory3>();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.Category3GetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory3 tempCategory3 = ReaderToCategory3(oReader);
                        tempCategory3List.Add(tempCategory3);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory3()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return tempCategory3List;
        }

        #endregion

        private CCategory3 ReaderToCategory3(IDataReader inReader)
        {
            CCategory3 tempCategory3 = new CCategory3();

            if (inReader["cat3_id"] != null)
                tempCategory3.Category3ID = int.Parse(inReader["cat3_id"].ToString());

            if (inReader["cat3_name"] != null)
                tempCategory3.Category3Name = inReader["cat3_name"].ToString();

            if (inReader["cat3_order"] != null)
                tempCategory3.Category3Order = int.Parse(inReader["cat3_order"].ToString());

            if (inReader["cat2_id"] != null)
                tempCategory3.Category2ID = int.Parse(inReader["cat2_id"].ToString());

            if (inReader["description"] != null)
                tempCategory3.Category3Description = inReader["description"].ToString();


            if (inReader["table_price"] != null)
                tempCategory3.Category3TablePrice = Double.Parse(inReader["table_price"].ToString());

            if (inReader["tw_price"] != null)
                tempCategory3.Category3TakeAwayPrice = Double.Parse(inReader["tw_price"].ToString());

            if (inReader["bar_price"] != null)
                tempCategory3.Category3BarPrice = Double.Parse(inReader["bar_price"].ToString());


            if (inReader["status"] != null)
                tempCategory3.Category3OrderStatus= int.Parse(inReader["status"].ToString());

            if (inReader["view_table"] != null)
                tempCategory3.Category3ViewTable = int.Parse(inReader["view_table"].ToString());

            if (inReader["view_bar"] != null)
                tempCategory3.Category3ViewBar = int.Parse(inReader["view_bar"].ToString());

            if (inReader["view_takeaway"] != null)
                tempCategory3.Category3ViewTakeAway = int.Parse(inReader["view_takeaway"].ToString());

            return tempCategory3;

        }
    }
}
