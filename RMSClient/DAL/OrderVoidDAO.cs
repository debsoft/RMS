using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RMS;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
   public  class OrderVoidDAO:BaseDAO
    {
       public void InsertOrderForVoid(OrderVoid aOrderVoid)
       {
           try
           {
               this.OpenConnection();
               string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertOrderForVoid),aOrderVoid.OrderId,aOrderVoid.Creator_Id,aOrderVoid.RemoverId,
                   aOrderVoid.OrderAmount,aOrderVoid.OrderDate,aOrderVoid.VoidDate,aOrderVoid.TableNumber,aOrderVoid.Reason);

               this.ExecuteNonQuery(sqlCommand);
           }
           catch (Exception ex)
           {
               Logger.Write("Exception : " + ex + " in AddNewOnlineProducts()", LogLevel.Error, "Database");

               throw new Exception("Exception occure at AddNewOnlineProducts()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
       }

       public void InsertItemForVoid(ItemVoid aItemVoid)
       {
           try
           {
               this.OpenConnection();
               string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertItemForVoid), aItemVoid.OrderId, aItemVoid.Creator_Id, aItemVoid.RemoverId,
                   aItemVoid.ItemName, aItemVoid.Quantity, aItemVoid.Amount, aItemVoid.VoidDate, aItemVoid.Reason);

               this.ExecuteNonQuery(sqlCommand);
           }
           catch (Exception ex)
           {
               Logger.Write("Exception : " + ex + " in AddNewOnlineProducts()", LogLevel.Error, "Database");

               throw new Exception("Exception occure at AddNewOnlineProducts()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
       }

       public List<OrderVoid> GetAllOrderVoid(DateTime startDate, DateTime endDate)
       {
           List<OrderVoid> oItemList=new List<OrderVoid>();
           try
           {
               this.OpenConnection();
               string sqlCommand = "";
               sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllOrderVoid), startDate, endDate);
               //this.ExecuteNonQuery(sqlCommand);
               IDataReader oReader = this.ExecuteReader(sqlCommand);

               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       // oOrderInfo = orderInfoReader(oReader);
                       OrderVoid oItem = ordervoidReader(oReader);
                       oItemList.Add(oItem);

                   }
               }

               //oResult.Data = oOrderInfo;
               //oResult.IsSuccess = true;

           }

           catch (Exception ex)
           {
               Logger.Write("Exception : " + ex + " in GetAllOrderVoid()", LogLevel.Error, "Database");
           }
           finally
           {
               this.CloseConnection();
           }
           return oItemList;

       }

       private OrderVoid ordervoidReader(IDataReader oReader)
       {
          OrderVoid oItem =new OrderVoid();

           try
           {
               oItem.OrderId = Convert.ToInt32(oReader["order_id"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.CreatorName = (oReader["creatorname"]).ToString();
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.RemoverName = (oReader["removername"]).ToString();
           }
           catch (Exception)
           {
           }

           try
           {
               oItem.OrderAmount = Convert.ToDouble(oReader["order_amount"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.TableNumber = Convert.ToInt32(oReader["table_number"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.OrderDate = Convert.ToDateTime(oReader["order_date"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.VoidDate = Convert.ToDateTime(oReader["void_date"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.Reason = (oReader["reason"]).ToString();
           }
           catch (Exception)
           {
           }



           return oItem;
       }

       public List<ItemVoid> GetAllItemVoid(DateTime startDate, DateTime endDate)
       {
           List<ItemVoid> oItemList = new List<ItemVoid>();
           try
           {
               this.OpenConnection();
               string sqlCommand = "";
               sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllItemVoid), startDate, endDate);
               //this.ExecuteNonQuery(sqlCommand);
               IDataReader oReader = this.ExecuteReader(sqlCommand);

               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       // oOrderInfo = orderInfoReader(oReader);
                       ItemVoid oItem = ItemvoidReader(oReader);
                       oItemList.Add(oItem);

                   }
               }

               //oResult.Data = oOrderInfo;
               //oResult.IsSuccess = true;

           }

           catch (Exception ex)
           {
               Logger.Write("Exception : " + ex + " in GetAllOrderVoid()", LogLevel.Error, "Database");
           }
           finally
           {
               this.CloseConnection();
           }
           return oItemList;
       }

       private ItemVoid ItemvoidReader(IDataReader oReader)
       {
           ItemVoid oItem = new ItemVoid();

           try
           {
               oItem.OrderId = Convert.ToInt32(oReader["order_id"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.CreatorName = (oReader["creatorname"]).ToString();
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.RemoverName = (oReader["removername"]).ToString();
           }
           catch (Exception)
           {
           }

           try
           {
               oItem.Amount= Convert.ToDouble(oReader["amount"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.Quantity = Convert.ToDouble(oReader["item_quantity"]);
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.VoidDate = Convert.ToDateTime(oReader["time"]);
           }
           catch (Exception)
           {
           }
         
           try
           {
               oItem.Reason = (oReader["reason"]).ToString();
           }
           catch (Exception)
           {
           }
           try
           {
               oItem.ItemName = (oReader["item_name"]).ToString();
           }
           catch (Exception)
           {
           }



           return oItem;
       }
    }
}
