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
    public class CCategory1DAO : BaseDAO, ICategory1DAO
    {
        #region ICategory1DAO members
        public void Category1Insert(CCategory1 inCategory1)
        {

        }

        public void Category1Update(CCategory1 inCategory1)
        {
        }
        public void Category1Delete(CCategory1 inCategory1)
        {
        }

        public List<CCategory1> GetAllCategory1()
        {
            List<CCategory1> tempCategory1List = new List<CCategory1>();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.Category1GetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CCategory1 tempCategory1 = ReaderToCategory1(oReader);
                        tempCategory1List.Add(tempCategory1);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllCategory1()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory1()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory1()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            
            return tempCategory1List;
        }

        #endregion

        private CCategory1 ReaderToCategory1(IDataReader inReader)
        {
            CCategory1 tempCategory1 = new CCategory1();

            if (inReader["cat1_id"] != null)
                tempCategory1.Category1ID = int.Parse(inReader["cat1_id"].ToString());

            if (inReader["cat1_name"] != null)
                tempCategory1.Category1Name = inReader["cat1_name"].ToString();

            if(inReader["cat1_order"] != null)
                tempCategory1.Category1Order = int.Parse(inReader["cat1_order"].ToString());

            if(inReader["parent_cat_id"] != null)
                tempCategory1.Category1ParentID = int.Parse(inReader["parent_cat_id"].ToString());

            return tempCategory1;

        }
    }
}
