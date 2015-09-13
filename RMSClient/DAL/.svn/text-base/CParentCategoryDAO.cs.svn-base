using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;



namespace RMS.DataAccess
{
    public class CParentCategoryDAO : BaseDAO, IParentCategoryDAO
    {
        #region IParentCategoryDAO members
        public void ParentCategoryInsert(CParentCategory inParentCategory)
        {

        }

        public void ParentCategoryUpdate(CParentCategory inParentCategory)
        {
        }
        public void ParentCategoryDelete(CParentCategory inParentCategory)
        {
        }

        public List<CParentCategory> GetAllParentCategory()
        {
            List<CParentCategory> tempParentCategoryList = new List<CParentCategory>();

            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.ParentCategoryGetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CParentCategory tempParentCategory = ReaderToParentCategory(oReader);
                        tempParentCategoryList.Add(tempParentCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllParentCategory()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllParentCategory()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllParentCategory()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempParentCategoryList;
        }

        #endregion

        private CParentCategory ReaderToParentCategory(IDataReader inReader)
        {
            CParentCategory tempParentCategory = new CParentCategory();

            if (inReader["parent_cat_id"] != null)
                tempParentCategory.ParentCategoryID = int.Parse(inReader["parent_cat_id"].ToString());

            if (inReader["parent_cat_name"] != null)
                tempParentCategory.ParentCategoryName = inReader["parent_cat_name"].ToString();


            return tempParentCategory;

        }
    }
}
