using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
   public  class InventoryItemDAO:BaseDAO
    {
       public string InsertInventoryItem(InventoryItem aItem)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertInventoryItem),
                                              aItem.ItemName, aItem.CategoryId,aItem.UnitName);
               this.ExecuteNonQuery(sqlComm);
               sr = "Insert Inventory Item Successfully";
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex + " Try Again");
               sr = "Please Try again";
           }
           finally
           {
               this.CloseConnection();
           }
           return sr;
       }

       public List<InventoryItem> GetItemByCategory(int categoryId)
       {

           List<InventoryItem> aItems=new List<InventoryItem>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetItemByCategory),
                                              categoryId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if(aReader!=null)
               {
                   while(aReader.Read())
                   {
                       InventoryItem aItem=new InventoryItem();
                       aItem = ItemReader(aReader);
                       aItems.Add(aItem);
                   }
               }

           }
           catch (Exception ex)
           {

               MessageBox.Show(ex + " Should be input missing");
           }

           finally
           {
               this.CloseConnection();
           }
           return aItems;
       }

       private InventoryItem ItemReader(IDataReader aReader)
       {
           InventoryItem aItem=new InventoryItem();
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
           try
           {
               aItem.CategoryId = Convert.ToInt32(aReader["IC_id"]);
           }
           catch
           {


           }

           return aItem;
       }

       public List<InventoryItem> GetAllItem()
       {
           List<InventoryItem> aItems = new List<InventoryItem>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetAllItem));
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

               MessageBox.Show(ex + " Should be input missing");
           }

           finally
           {
               this.CloseConnection();
           }
           return aItems;
       }


       public string UpdateItem(InventoryItem item)
       {
           string result = "";
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateInventoryItem), item.ItemId, item.ItemName, item.CategoryId, item.CategoryName, item.UnitName);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateInventoryKitchenStock), item.ItemId, item.ItemName, item.CategoryId, item.CategoryName, item.UnitName);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateInventoryPurchase), item.ItemId, item.ItemName, item.CategoryId, item.CategoryName, item.UnitName);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateInventoryStock), item.ItemId, item.ItemName, item.CategoryId, item.CategoryName, item.UnitName);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateFinishedRawProductList), item.ItemId, item.ItemName, item.CategoryId, item.CategoryName, item.UnitName);
               this.ExecuteNonQuery(sqlComm);

               result = "Item Updated Sucessfully";


           }
           catch (Exception ex)
           {
               result = " Sorry Please Try Again";
           }
           finally
           {
               this.CloseConnection();
           }
           return result;
       }
       public InventoryItem GetInventoryItem(int itemId)
       {
           InventoryItem aItem = new InventoryItem();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetInventoryItem),
                                              itemId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {

                       aItem = ItemReader(aReader);

                   }
               }

           }
           catch (Exception ex)
           {

               MessageBox.Show(ex + " Should be input missing");
           }

           finally
           {
               this.CloseConnection();
           }
           return aItem;
       }

       public DataTable GetItemByCategoryintoTable(int categoryId)
       {

           DataTable aTable = new DataTable();
           try
           {
               RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
               string tempConnStr = oConstants.DBConnection;
               string query = string.Format("SELECT II_id ,II_name,IC_id,unit_name ,'Update' as up, 'Delete' as del from inventory_item where IC_id={0}", categoryId);
               SqlDataAdapter dataAdapter = new SqlDataAdapter(query, tempConnStr);
               SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
               aTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
               dataAdapter.Fill(aTable);

           }
           catch (Exception ee)
           {
               MessageBox.Show(ee.Message + ". Error Occured. Please contact to your administrator.");
           }
           return aTable;
       }

       public bool DeleteItem(int itemId)
       {
           bool result;
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.DeleteInventoryItem), itemId);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.DeleteInventoryKitchenStock), itemId);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.DeleteInventoryPurchase), itemId);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.DeleteInventoryStock), itemId);
               this.ExecuteNonQuery(sqlComm);
               sqlComm = String.Format(SqlQueries.GetQuery(Query.DeleteFinishedRawProductList), itemId);
               this.ExecuteNonQuery(sqlComm);

               result = true;


           }
           catch (Exception ex)
           {
               result = false;
           }
           finally
           {
               this.CloseConnection();
           }
           return result;
       }
    }
}
