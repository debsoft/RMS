using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
    public class SaleReportDAO:BaseDAO
    {
        public void InsertOrUpdateSaleRawmaterialsReport(IEnumerable<COrderDetails> check)
        {
            FinishedRawProductListDAO finishedRawProductListDao = new FinishedRawProductListDAO();
             KitchenStockDAO aKitchenStockDao=new KitchenStockDAO();
                    
            try
            {
                this.OpenConnection();
                foreach (COrderDetails cOrderDetailse in check)
                {
                    List<CFinishedRawProductList> finishedRawProductList =
                        finishedRawProductListDao.GetFinishedRawProductListByProductID(
                            Convert.ToInt32(cOrderDetailse.ProductID));
                    //aKitchenStockDao.UpdateStock(Convert.ToInt32(finishedRawProduct.RawProductID),
                    //   finishedRawProduct.Qnty * (orderDetails.OrderQuantity - orderDetails.KitchenQuantity));

                    foreach (CFinishedRawProductList finishedRawProduct in finishedRawProductList)
                    {
                        int flag = 0;
                          KitchenStock aKitchenStock=new KitchenStock();
                          aKitchenStock = aKitchenStockDao.GetStockByItemidFrominventory_kitchen_stock((int)finishedRawProduct.RawProductID);
                        string sqlComm = String.Format(SqlQueries.GetQuery(Query.ExitOrNot), aKitchenStock.ItemId,
                                                       DateTime.Now.Date);
                        IDataReader aReader = this.ExecuteReader(sqlComm);
                        if(aReader!=null)
                        {
                            while(aReader.Read())
                            {
                                flag = Convert.ToInt32(aReader["sale_id"]);
                            }
                            aReader.Close();
                        }
                        if(flag==0)
                        {
                             sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertSalereport), aKitchenStock.ItemId,
                                    cOrderDetailse.OrderQuantity*finishedRawProduct.Qnty,aKitchenStock.UnitPrice*cOrderDetailse.OrderQuantity*finishedRawProduct.Qnty, 
                                    DateTime.Now.Date);
                            this.ExecuteNonQuery(sqlComm);
                        }
                        if (flag > 0)
                        {
                            sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateSalereport),
                                          cOrderDetailse.OrderQuantity * finishedRawProduct.Qnty,
                                          aKitchenStock.UnitPrice * cOrderDetailse.OrderQuantity * finishedRawProduct.Qnty, flag);
                            this.ExecuteNonQuery(sqlComm);
                        }



                    }
                  
                }

            }
            catch (Exception ex)
            {

                throw new Exception("InsertOrUpdateSaleRawmaterialsReport()",ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
