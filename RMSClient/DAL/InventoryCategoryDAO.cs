using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
    public class InventoryCategoryDAO:BaseDAO
    {
        public List<InventoryCategory> GetAllCategory()
        {
            List<InventoryCategory> aList = new List<InventoryCategory>();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllCategory));
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        InventoryCategory aCategory = new InventoryCategory();
                        aCategory = ReaderToCategory(oReader);

                        aList.Add(aCategory);
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("GetAllCategory()",ex);

            }
            finally
            {
                this.CloseConnection();
            }
            return aList;
        }
        private InventoryCategory ReaderToCategory(IDataReader oReader)
        {
            InventoryCategory aCategory = new InventoryCategory();
            try
            {
                aCategory.CategoryId = Convert.ToInt32(oReader["IC_id"]);
            }
            catch
            {

            }
            try
            {
                aCategory.CategoryName = oReader["IC_name"].ToString();
            }
            catch
            {

            }

            return aCategory;


        }
    }
}
