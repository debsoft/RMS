using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
    public class InventoryCategoryDAO:BaseDAO 
    {
        public string InsertInventoryCategory(InventoryCategory aCategory)
        {
            string sr = string.Empty;
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertInventoryCategory),
                                               aCategory.CategoryName, aCategory.UnitId);
                this.ExecuteNonQuery(sqlComm);
                sr = "Insert Inventory Category Successfully";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex +" Try Again");
                sr = "Please Try again";
            }
            finally
            {
                this.CloseConnection();
            }
            return sr;
        }

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

                MessageBox.Show(ex + " Try Again");

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
             try
             {
                 aCategory.UnitId = Convert.ToInt32(oReader["IC_unit"]);
             }
            catch 
            {
                
            }
            return aCategory;


        }
    }
}
