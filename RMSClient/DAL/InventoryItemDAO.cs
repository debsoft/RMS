using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
   public  class InventoryItemDAO:BaseDAO
    {
       public List<InventoryItem> GetItemByCategory(int categoryId)
       {

           List<InventoryItem> aItems = new List<InventoryItem>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetItemByCategory),
                                              categoryId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       InventoryItem aItem = new InventoryItem();
                       aItem = ItemReader(aReader);
                       aItems.Add(aItem);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetItemByCategory()",ex);
           }

           finally
           {
               this.CloseConnection();
           }
           return aItems;
       }

       private InventoryItem ItemReader(IDataReader aReader)
       {
           InventoryItem aItem = new InventoryItem();
           try
           {
               aItem.ItemId = Convert.ToInt32(aReader["II_id"]);
           }
           catch
           {


           }
           try
           {
               aItem.ItemName = aReader["II_name"].ToString();
           }
           catch
           {


           }
           try
           {
               aItem.UnitName = aReader["unit_name"].ToString();
           }
           catch
           {


           }

           return aItem;
       }

    }
}
