using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
   public  class InventoryKitchenStockReportDAO:BaseDAO
    {


        public void InsertInventoryKitchenStock(List<InventoryStockReport> aInventoryStockReports)
        {
            try
            {
                this.OpenConnection();
                foreach (InventoryStockReport report in aInventoryStockReports)
                {
                    string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertInventoryKitchenStockReport),
                                                   report.CategoryId, report.CategoryName, report.ItemId,
                                                   report.ItemName, report.ReceivedQty, report.SendQty, report.DamageQty,
                                                   report.BalanceQty, report.Date = DateTime.Today.AddDays(-1));
                    this.ExecuteNonQuery(sqlComm);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("InsertInventoryKitchenStock", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public bool CheckInsertOrNotForKitchen()
        {
            int flag = 0;
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.CheckInsertOrNotForKitchen), DateTime.Today.AddDays(-1));
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                        flag++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("CheckInsertOrNotForKitchen()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            if (flag > 0) return false;
            return true;
        }

        public List<InventoryStockReport> GetInventoryStockReportBetweenDateForKitchen(DateTime fromdate, DateTime todate)
        {
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetInventoryStockReportBetweenDateForKitchen), fromdate,
                                               todate);
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                        InventoryStockReport aReport = new InventoryStockReport();
                        aReport = ReaderToReadAllStock(aReader);
                        aInventoryStockReports.Add(aReport);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("GetInventoryStockReportBetweenDateForKitchen()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return aInventoryStockReports;
        }

        private InventoryStockReport ReaderToReadAllStock(IDataReader aReader)
        {
            InventoryStockReport aStockReport = new InventoryStockReport();
            try
            {
                aStockReport.CategoryId = Convert.ToInt32(aReader["category_id"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.CategoryName = (aReader["category_name"]).ToString();
            }
            catch
            {
            }
            try
            {
                aStockReport.ItemId = Convert.ToInt32(aReader["item_id"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.ItemName = (aReader["item_name"]).ToString();
            }
            catch
            {
            }


            try
            {
                aStockReport.BalanceQty = Convert.ToDouble(aReader["balance"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.SendQty = Convert.ToDouble(aReader["send"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.ReceivedQty = Convert.ToDouble(aReader["received"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.DamageQty = Convert.ToDouble(aReader["damage"]);
            }
            catch
            {
            }
            try
            {
                aStockReport.Date = Convert.ToDateTime(aReader["date"]);
            }
            catch
            {
            }

          


            return aStockReport;

        }


       public List<InventoryStockReport> GetInventoryKitchenStockReportBetweenDate(DateTime fromdate, DateTime todate)
       {
           List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetInventoryKitchenStockReportBetweenDate), fromdate,
                                              todate);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       InventoryStockReport aReport = new InventoryStockReport();
                       aReport = ReaderToReadAllStock(aReader);
                       aInventoryStockReports.Add(aReport);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetInventoryStockReportBetweenDate()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aInventoryStockReports;
       }

       public List<InventoryStockReport> GetSaleReport(DateTime fromdate, DateTime todate)
       {
           List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetSaleReport), fromdate,
                                              todate);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       InventoryStockReport aReport = new InventoryStockReport();
                       aReport = ReaderToReadSaleReport(aReader);
                       aInventoryStockReports.Add(aReport);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetSaleReport()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aInventoryStockReports;
       }

       private InventoryStockReport ReaderToReadSaleReport(IDataReader aReader)
       {
           InventoryStockReport aStockReport = new InventoryStockReport();
           try
           {
               aStockReport.Date = Convert.ToDateTime(aReader["date"]);
           }
           catch
           {
           }
           try
           {
               aStockReport.ItemId = Convert.ToInt32(aReader["item_id"]);
           }
           catch
           {
           }
           try
           {
               aStockReport.SaleQty = Convert.ToDouble(aReader["item_qty"]);
           }
           catch
           {
           }
           try
           {
               aStockReport.Price = Convert.ToDouble(aReader["sale_price"]);
           }
           catch
           {
           }
           return aStockReport;
       }
    }
}
