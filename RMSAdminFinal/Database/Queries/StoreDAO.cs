using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.DataAccess;

namespace Database.Queries
{
   public  class StoreDAO:BaseDAO
    {
       public List<Store> GetAllStore()
       {
           List<Store> aStores=new List<Store>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllStore));
               IDataReader aReader=this.ExecuteReader(sqlComm);
               if(aReader!=null)
               {
                   while(aReader.Read())
                   {
                       Store aStore=new Store();
                       aStore = ReadToStore(aReader);
                       aStores.Add(aStore);

                   }
               }


           }
           catch (Exception)
           {
               
             
           }
           return aStores;
       }

       private Store ReadToStore(IDataReader aReader)
       {
           Store aStore=new Store();

           try
           {
               aStore.StoreId = Convert.ToInt32(aReader["item_id"]);
           }
           catch (Exception)
           {
              
           }
           try
           {
               aStore.ItemName = (aReader["item_name"]).ToString();
           }
           catch (Exception)
           {

           }
           try
           {
               aStore.Quantity = Convert.ToDouble(aReader["quantity"]);
           }
           catch (Exception)
           {

           }

           try
           {
               aStore.Unit = (aReader["item_unit"]).ToString();
           }
           catch (Exception)
           {

           }
           try
           {
               aStore.UnitPrice = Convert.ToDouble(aReader["amount"]);
           }
           catch (Exception)
           {

           }
           try
           {
               aStore.CategoryName = (aReader["categoryname"]).ToString();
           }
           catch (Exception)
           {

           }
           try
           {
               aStore.CategoryId = Convert.ToInt32(aReader["categoryid"]);
           }
           catch (Exception)
           {

           }

           try
           {
               aStore.Amount = aStore.UnitPrice*aStore.Quantity;
           }
           catch (Exception)
           {

           }
           aStore.Damage = "Damage";
           aStore.StockOut = "StockOut";
           aStore.Purchase = "Purchase";
           aStore.Delete = "Delete";
           aStore.Return = "Return";


           

           return aStore;
       }

       public Store GetStoreByItemId(int itemId)
       {
           Store aStore = new Store();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetStoreByItemId),itemId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                     
                       aStore = ReadToStore(aReader);
                    

                   }
               }


           }
           catch (Exception)
           {


           }
           finally
           {
               this.CloseConnection();

           }
           return aStore;
       }

       public void InsertTransaction(Transaction1 aTransaction1, int category)
       {
           try
           {
               DateTime aDateTime = DateTime.Now.Date;
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertTransaction),aTransaction1.ItemName,
                                              aTransaction1.Quantity, aTransaction1.ItemUnit, aTransaction1.Amount, 
                                              aTransaction1.SupplierName, aTransaction1.TransactionType,aDateTime,category);
               this.ExecuteNonQuery(sqlComm);
           }
           catch (Exception ex)
           {

          
               //throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public string UpdateStore(Store aStore)
       {
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.UpdateStore),aStore.StoreId,aStore.Quantity,aStore.UnitPrice);
               this.ExecuteNonQuery(sqlComm);
               return "Insert Sucessfully";
           }
           catch (Exception)
           {

               return "Please Try Agian";

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public string DeleteItem(int itemId)
       {
           try
           {
               DateTime aDateTime = DateTime.Now.Date;
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.DeleteItem),itemId);
               this.ExecuteNonQuery(sqlComm);
               return "Delete Successfully";
           }
           catch (Exception ex)
           {

               return "Please try again";
               // throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
          
       }

       public List<Store> GetAllOtherStore()
       {
           List<Store> aStores = new List<Store>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllOtherStore));
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Store aStore = new Store();
                       aStore = ReadToStore(aReader);
                       aStores.Add(aStore);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aStores;
       }

       public Store GetOtherStoreByItemId(int itemId)
       {
           Store aStore = new Store();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetOtherStoreByItemId), itemId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {

                       aStore = ReadToStore(aReader);


                   }
               }


           }
           catch (Exception)
           {


           }
           finally
           {
               this.CloseConnection();

           }
           return aStore;
       }

       public void InsertOtherTransaction(Transaction1 aTransaction1,int categoryId)
       {
           try
           {
               DateTime aDateTime = DateTime.Now.Date;
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertOtherTransaction), aTransaction1.ItemName,
                                              aTransaction1.Quantity, aTransaction1.ItemUnit, aTransaction1.Amount,
                                              aTransaction1.SupplierName, aTransaction1.TransactionType, aDateTime,categoryId,aTransaction1.CauseOrPurpose);
               this.ExecuteNonQuery(sqlComm);
           }
           catch (Exception ex)
           {


               //throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public string UpdateOtherStore(Store aStore)
       {
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.UpdateOtherStore), aStore.StoreId, aStore.Quantity, aStore.UnitPrice);
               this.ExecuteNonQuery(sqlComm);
               return "Insert Sucessfully";
           }
           catch (Exception)
           {

               return "Please Try Agian";

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public string OtherDeleteItem(int itemId)
       {
           try
           {
               DateTime aDateTime = DateTime.Now.Date;
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.OtherDeleteItem), itemId);
               this.ExecuteNonQuery(sqlComm);
               return "Delete Successfully";
           }
           catch (Exception ex)
           {

               return "Please try again";
               // throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public string InsertOtherItem(Store aStore)
       {
           try
           {
               DateTime aDateTime = DateTime.Now.Date;
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertOtherItem),aStore.ItemName,aStore.Unit,0,0,aStore.CategoryId,aStore.CategoryName);
               this.ExecuteNonQuery(sqlComm);
               return "Insert Sucessfully";
           }
           catch (Exception ex)
           {
               return "Please try again";

               //throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public List<Transaction1> GetTransactionBydate(DateTime fromDate, DateTime toDate,int categoryId)
       {
           List<Transaction1> aTransactions= new List<Transaction1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetTransactionBydate),fromDate,toDate,categoryId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction1 aTransaction1= new Transaction1();
                       aTransaction1 = ReadToTransaction(aReader);
                       aTransactions.Add(aTransaction1);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aTransactions;
           
       }

       private Transaction1 ReadToTransaction(IDataReader aReader)
       {
           Transaction1 aTransaction1 = new Transaction1();

           try
           {
               aTransaction1.TransactionId = Convert.ToInt32(aReader["transaction_id"]);
           }
           catch (Exception)
           {}
           try
           {
               aTransaction1.ItemName = (aReader["item_name"]).ToString();
           }
           catch (Exception)
           { }

           try
           {
               aTransaction1.SupplierName = (aReader["supplier"]).ToString();
           }
           catch (Exception)
           { }
           try
           {
               aTransaction1.TransactionType= (aReader["transaction_type"]).ToString();
           }
           catch (Exception)
           { }

           try
           {
               aTransaction1.Amount = Convert.ToDouble(aReader["amount"]);
           }
           catch (Exception)
           { }
           try
           {
               aTransaction1.Quantity = Convert.ToDouble(aReader["quantity"]);
           }
           catch (Exception)
           { }

           try
           {
               aTransaction1.ItemUnit = (aReader["unit"]).ToString();
           }
           catch (Exception)
           { }

           try
           {
               aTransaction1.Date = Convert.ToDateTime(aReader["date"]);
           }
           catch (Exception)
           { }

           try
           {
               aTransaction1.CauseOrPurpose = (aReader["Purpose"]).ToString();
           }
           catch (Exception)
           { }
           
           
           
           return aTransaction1;
       }

       public List<Transaction1> GetOtherTransactionBydate(DateTime fromDate, DateTime toDate, int categoryId)
       {
           List<Transaction1> aTransactions = new List<Transaction1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetOtherTransactionBydate), fromDate, toDate, categoryId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction1 aTransaction1 = new Transaction1();
                       aTransaction1 = ReadToTransaction(aReader);
                       aTransactions.Add(aTransaction1);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aTransactions;
       }


       public List<Transaction1> GetOtherTransactionBydateAndTransactionType(DateTime fromDate, DateTime toDate, string transactionType)
       {
           List<Transaction1> aTransactions = new List<Transaction1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetOtherTransactionBydateAndTransactionType), fromDate, toDate, transactionType);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction1 aTransaction1 = new Transaction1();
                       aTransaction1 = ReadToTransaction(aReader);
                       aTransactions.Add(aTransaction1);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aTransactions;
       }

       public List<Transaction1> GetOtherTransactionBydateForProfit(DateTime fromDate, DateTime toDate)
       {
           List<Transaction1> aTransactions = new List<Transaction1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetOtherTransactionBydateForProfit), fromDate, toDate);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction1 aTransaction1 = new Transaction1();
                       aTransaction1 = ReadToTransactionforProfit(aReader);
                       aTransactions.Add(aTransaction1);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aTransactions;
       }

       private Transaction1 ReadToTransactionforProfit(IDataReader aReader)
       {
           Transaction1 aTransaction1 = new Transaction1();
           try
           {
               aTransaction1.Date = Convert.ToDateTime(aReader["date"]);
           }
           catch (Exception)
           { }
           try
           {
               aTransaction1.Amount = Convert.ToDouble(aReader["amount"]);
           }
           catch (Exception)
           { }

           return aTransaction1;
       }

       public List<Transaction1> GetTransactionBydateForProfit(DateTime fromDate, DateTime toDate)
       {
           List<Transaction1> aTransactions = new List<Transaction1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetTransactionBydateForProfit), fromDate, toDate);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction1 aTransaction1 = new Transaction1();
                       aTransaction1 = ReadToTransactionforProfit(aReader);
                       aTransactions.Add(aTransaction1);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aTransactions;
       }

       public List<Transaction1> showAllData(long startDate, long endDate)
       {
           List<Transaction1> aTransactions = new List<Transaction1>();

           //CResult oResult = new CResult();
           //CSearchOrderInfo oOrderInfo = new CSearchOrderInfo();

           try
           {
               this.OpenConnection();
               string sqlCommand = "";
               sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetOrderInfo), startDate.ToString(), endDate.ToString());
               //this.ExecuteNonQuery(sqlCommand);
               IDataReader oReader = this.ExecuteReader(sqlCommand);

               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       Transaction1 aTransaction1 = new Transaction1();
                       aTransaction1 = ReadToOrderTotalforProfit(oReader);
                       aTransactions.Add(aTransaction1);

                   }
               }

               //oResult.Data = oOrderInfo;
               //oResult.IsSuccess = true;

           }

           catch (Exception ex)
           {
             
           }
           finally
           {
               this.CloseConnection();
           }

           return aTransactions;
       }

       private Transaction1 ReadToOrderTotalforProfit(IDataReader oReader)
       {
           Transaction1 aTransaction1 = new Transaction1();

           try
           {
               if (oReader["Order Date-Time"] != DBNull.Value)
                   aTransaction1.Date = new DateTime(Int64.Parse(oReader["Order Date-Time"].ToString())).Date;

           }
           catch (Exception)
           {
               
              
           }
           try
           {
               if (oReader["Total Paid(Inc. Vat)"] != DBNull.Value)
                   aTransaction1.Amount =Convert.ToDouble(oReader["Total Paid(Inc. Vat)"].ToString());
               //Total Paid(Inc. Vat)
           }
           catch (Exception)
           {
               
              
           }
           return aTransaction1;
       }

       public string InsertOtherCategory(Store aStore)
       {
           try
           {
               
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertOtherCategory), aStore.ItemName);
               this.ExecuteNonQuery(sqlComm);
               return "Insert Sucessfully";
           }
           catch (Exception ex)
           {
               return "Please try again";

               //throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public List<Store> GetAllotherCategory()
       {
           List<Store> aStores = new List<Store>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllotherCategory));
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Store aStore = new Store();
                       aStore.ItemName = aReader["categoryName"].ToString();
                       aStore.StoreId = Convert.ToInt32(aReader["categoryId"]);
                       aStores.Add(aStore);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aStores;
       }

       public string InsertRawmaterialCategory(Store aStore)
       {
           try
           {

               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertRawmaterialCategory), aStore.ItemName);
               this.ExecuteNonQuery(sqlComm);
               return "Insert Sucessfully";
           }
           catch (Exception ex)
           {
               return "Please try again";

               //throw new Exception(ex.ToString());

           }
           finally
           {
               this.CloseConnection();
           }
       }

       public List<Store> GetAllRawmaterialCategory()
       {
           List<Store> aStores = new List<Store>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllRawmaterialCategory));
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Store aStore = new Store();
                       aStore.ItemName = aReader["categoryName"].ToString();
                       aStore.StoreId = Convert.ToInt32(aReader["categoryid"]);
                       aStores.Add(aStore);

                   }
               }


           }
           catch (Exception)
           {


           }
           return aStores;
       }
    }
}
