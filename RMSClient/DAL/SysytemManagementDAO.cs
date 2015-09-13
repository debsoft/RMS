using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;
using System.Data.Common;


namespace RMSClient.DataAccess
{
    public class SysytemManagementDAO : BaseDAO,ISystemManagementDAO
    {
        private string m_websiteName = string.Empty;
        private Hashtable m_onlineOrdersList = null;
        private string m_accessCode = String.Empty;

        public CResult SaveDefaultTime(double p_minutes)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.DeleteDefaultTime));
                this.ExecuteNonQuery(sqlCommand);

                 sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveDefaultTime),p_minutes);
                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        #region ISystemManagementDAO Members



        /// <summary>
        /// Collecting the kitchen text
        /// </summary>
        /// <returns></returns>
        public CResult GetKitchenText()
        {
            CResult oResult = new CResult();
            SortedList slKitchenText = new SortedList();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllKitchenText));
                IDataReader objDatareader= this.ExecuteReader(sqlCommand);
                if (objDatareader != null)
                {
                    while (objDatareader.Read())
                    {
                        clsKitchenText objKitchentext=new clsKitchenText();
                        objKitchentext = this.GetKitchenText(objDatareader);
                        slKitchenText.Add(slKitchenText.Count, objKitchentext);
                    }
                    oResult.Data=slKitchenText;
                    objDatareader.Close();
                }
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private clsKitchenText GetKitchenText(IDataReader objDatareader)
        {
            clsKitchenText objKitchenText = new clsKitchenText();
            objKitchenText.KitchenTextId = Convert.ToInt32("0" + objDatareader["kicthen_text_id"]);
            objKitchenText.KitchenText = Convert.ToString(objDatareader["kitchen_text"]);
            return objKitchenText;
        }


        private clsSpecialModfifyText GetSpecialText(IDataReader objDatareader)
        {
            clsSpecialModfifyText objSpecialText = new clsSpecialModfifyText();
            objSpecialText.SpecialModfifyTextId = Convert.ToInt32("0" + objDatareader["special_modify_text_id"]);
            objSpecialText.SpecialModfifyText = Convert.ToString(objDatareader["special_modify_text"]);
            return objSpecialText;
        }

        #endregion

        #region ISystemManagementDAO Members

        CResult ISystemManagementDAO.SaveKitchenText(SortedList slKitchenText)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = "";
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveKitchenText), Convert.ToString(slKitchenText["KT"]));
                
                this.ExecuteNonQuery(sqlCommand);
              
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in SaveKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }
        #endregion

        #region ISystemManagementDAO Members

        public CResult UpdateKitchenText(int p_kitchenTextId, string p_kitchenText)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = "";
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateSpecialModifyTex), p_kitchenTextId, p_kitchenText);
                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        /// <summary>
        /// Deleting the kitchen text of the selected ID
        /// </summary>
        /// <param name="p_kitchenTextId"></param>
        /// <returns></returns>
        public CResult DeleteKitchenText(int p_kitchenTextId)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = "";
               
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.DeleteKitchenText), p_kitchenTextId);
               
                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region ISystemManagementDAO Members


        public CResult SaveSpecialModifyText(SortedList slSpecialModifyText)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = "";
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveSpecialModifyTex), Convert.ToString(slSpecialModifyText["SPTXT"]));

                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in SaveSpecialModifyText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult GetSpecialModifyText()
        {
            CResult oResult = new CResult();
            SortedList slSpecialModifyText = new SortedList();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSpecialModifyText));
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);
                if (objDatareader != null)
                {
                    while (objDatareader.Read())
                    {
                        clsSpecialModfifyText objSpecial = new clsSpecialModfifyText();
                        objSpecial = this.GetSpecialText(objDatareader);
                        slSpecialModifyText.Add(slSpecialModifyText.Count, objSpecial);
                    }
                    oResult.Data = slSpecialModifyText;
                    objDatareader.Close();
                }
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSpecialModifyText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult UpdateSpecialModifyText(int p_SpecialModifyTextId, string p_SpecialModifyText)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = "";
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateKitchenText), p_SpecialModifyTextId, p_SpecialModifyText);
                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateSpecialModifyText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult DeleteSpecialModifyText(int p_SpecialModifyTextId)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sqlCommand = "";

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.DeleteSpecialModifyTex), p_SpecialModifyTextId);

                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteSpecialModifyText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region "Order synchronization"


        public CResult SynchronizeOnlineOrders()
        {
            CResult objResult = new CResult();
            if (this.ConnectionExists() == true) //Execute ping command 
            {
                this.GenerateLatestInformation(m_websiteName + "/XML/RMSNewOrder.aspx", "3");

                this.ExtractCustomerInformation();

                this.ExtractOnlineOrders();

                this.GenerateLatestInformation(m_websiteName + "/XML/RMSNewOrder.aspx", "1");
            }
            return objResult;
        }

        #region "Manupulation Area"

        private string GenerateLatestInformation(string strURL, string removeStatus)
        {
            string retVal = "";
            strURL = strURL + "?accesscode=" + m_accessCode + "&removedata=" + removeStatus;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                //call the GetResponse() metphod to obtain a connection to the remote site:

                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                //Accumulate the data from the response stream:

                response.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return retVal;
        }

        /// <summary>
        /// Collects customer information from online
        /// </summary>
        private void ExtractCustomerInformation()
        {
            //DataSet dsCustomerInfo = new DataSet();
            //m_onlineOrdersList = new Hashtable();
            //String strURL = m_websiteName + "/XML/Online_Customer_info.xml";
            //XmlDocument doc = new XmlDocument();
            //dsCustomerInfo.ReadXml(strURL);

            //IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
            //string ipAddress = (ipEntry.AddressList[0].ToString());

            //Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("User ID=sa;Password=;Database=RMSDB;Data Source=localhost;Pooling=True;Min Pool Size=5;Max Pool Size=50");
            //string procedureName = "sp_SaveOnlineCustomerInfo";
            //DbCommand dbCommand = null;

            //if (dsCustomerInfo.Tables.Count > 0)
            //{
            //    using (DbConnection connection = db.CreateConnection())
            //    {
            //        connection.Open();
            //        DbTransaction transaction = connection.BeginTransaction();
            //        try
            //        {
            //            foreach (DataRow dtRow in dsCustomerInfo.Tables[0].Rows)
            //            {
            //                dbCommand = db.GetStoredProcCommand(procedureName);

            //                db.AddInParameter(dbCommand, "@customer_id", DbType.Int64, Convert.ToInt64("0" + dtRow["customer_id"].ToString()));
            //                db.AddInParameter(dbCommand, "@name", DbType.String, dtRow["name"].ToString());
            //                db.AddInParameter(dbCommand, "@floororapt_number", DbType.String, dtRow["floororapt_number"].ToString());
            //                db.AddInParameter(dbCommand, "@building_name", DbType.String, dtRow["building_name"].ToString());
            //                db.AddInParameter(dbCommand, "house_number", DbType.String, dtRow["house_number"].ToString());
            //                db.AddInParameter(dbCommand, "@phone", DbType.String, dtRow["phone"].ToString());
            //                db.AddInParameter(dbCommand, "@postal_code", DbType.String, dtRow["postal_code"].ToString());
            //                db.AddInParameter(dbCommand, "@town", DbType.String, dtRow["town"].ToString());
            //                db.AddInParameter(dbCommand, "@country", DbType.String, dtRow["country"].ToString());
            //                db.AddInParameter(dbCommand, "@userid", DbType.String, "Web User");
            //                db.AddInParameter(dbCommand, "@insertdate", DbType.Int64, DateTime.Now.Ticks);

            //                db.AddInParameter(dbCommand, "@terminal_id", DbType.String, ipAddress);
            //                db.AddInParameter(dbCommand, "@onlinestatus", DbType.Int32, dtRow["onlinestatus"].ToString());
            //                db.AddInParameter(dbCommand, "@street_name", DbType.String, dtRow["street_name"].ToString());

            //                db.ExecuteNonQuery(dbCommand);
            //            }
            //        }

            //        catch (Exception exp)
            //        {
            //            throw exp;
            //        }
            //        finally
            //        {
            //            doc = null;
            //            strURL = null;
            //        }
            //    }
            //}
        }

        private void ExtractOnlineOrders()
        {
            //DataSet dsOnlineOrders = new DataSet();

            //String strURL = m_websiteName + "/XML/Online_Orders.xml";
            //XmlDocument doc = new XmlDocument();
            //IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
            //string ipAddress = (ipEntry.AddressList[0].ToString());
            //dsOnlineOrders.ReadXml(strURL);

            //if (dsOnlineOrders.Tables.Count > 0)
            //{
            //    try
            //    {
            //        Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("LocalHostDatabase");
            //        string procedureName = "sp_saveonlineorders";
            //        DbCommand dbCommand = null;

            //        using (DbConnection connection = db.CreateConnection())
            //        {
            //            connection.Open();
            //            DbTransaction transaction = connection.BeginTransaction();

            //            foreach (DataRow dtRow in dsOnlineOrders.Tables[0].Rows)
            //            {
            //                dbCommand = db.GetStoredProcCommand(procedureName);

            //                db.AddInParameter(dbCommand, "@order_id", DbType.Int64, Convert.ToInt64("0" + dtRow["order_id"].ToString()));
            //                db.AddInParameter(dbCommand, "@customer_id", DbType.Int64, Convert.ToInt64("0" + dtRow["customer_id"].ToString()));
            //                db.AddInParameter(dbCommand, "@user_id", DbType.String, "Web User");
            //                db.AddInParameter(dbCommand, "@order_type", DbType.String, dtRow["order_type"].ToString());
            //                db.AddInParameter(dbCommand, "@order_time", DbType.Int64, Convert.ToInt64("0" + dtRow["order_time"].ToString()));
            //                db.AddInParameter(dbCommand, "@status", DbType.String, dtRow["status"].ToString());
            //                db.AddInParameter(dbCommand, "@guest_count", DbType.Int32, Convert.ToInt32("0" + dtRow["guest_count"].ToString()));
            //                db.AddInParameter(dbCommand, "@table_number", DbType.Int64, Convert.ToInt64("0" + dtRow["table_number"].ToString()));
            //                db.AddInParameter(dbCommand, "@table_name", DbType.String, dtRow["table_name"].ToString());
            //                db.AddInParameter(dbCommand, "@ipaddress", DbType.String, ipAddress);
            //                db.AddInParameter(dbCommand, "@online_orderid", DbType.Int64, 0);

            //                db.AddInParameter(dbCommand, "@webstatus", DbType.String, "");
            //                db.AddInParameter(dbCommand, "@webstatusnote", DbType.String, "");
            //                db.AddInParameter(dbCommand, "@OnlineStatus", DbType.Int32, Convert.ToInt32("0" + dtRow["OnlineStatus"].ToString()));
            //                db.AddInParameter(dbCommand, "@quantity", DbType.Int32, Convert.ToInt32("0" + dtRow["quantity"].ToString()));
            //                db.AddInParameter(dbCommand, "@amount", DbType.Double, Convert.ToDouble("0" + dtRow["amount"].ToString()));
            //                db.AddInParameter(dbCommand, "@remarks", DbType.String, Convert.ToString(dtRow["remarks"]));
            //                db.AddInParameter(dbCommand, "@food_type", DbType.String, Convert.ToString(dtRow["food_type"]));
            //                db.AddInParameter(dbCommand, "@pcat_name", DbType.String, Convert.ToString(dtRow["pcat_name"]));
            //                db.AddInParameter(dbCommand, "@cat1_name", DbType.String, Convert.ToString(dtRow["cat1_name"]));
            //                db.AddInParameter(dbCommand, "@cat2_name", DbType.String, Convert.ToString(dtRow["cat2_name"]));
            //                db.AddInParameter(dbCommand, "@item_name", DbType.String, Convert.ToString(dtRow["item_name"]));
            //                if (dtRow.ItemArray.Length > 18)
            //                {
            //                    db.AddInParameter(dbCommand, "@del_time", DbType.String, Convert.ToString(dtRow["delivery_time"]));
            //                }
            //                else
            //                {
            //                    db.AddInParameter(dbCommand, "@del_time", DbType.String, "NA");
            //                }
            //                db.ExecuteNonQuery(dbCommand);
            //            }
            //        }
            //    }

            //    catch (WebException exp)
            //    {
            //        throw exp;
            //    }
            //    catch (Exception exp)
            //    {
            //        throw exp;
            //    }
            //    finally
            //    {
            //        doc = null;
            //        strURL = null;
            //    }
            //}
        }

        /// <summary>
        /// This function is used to check whether network connection is exists or not. 
        /// </summary>
        /// <returns></returns>
        public bool ConnectionExists()
        {
            bool isExists = false;
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                clnt.Close();
                isExists = true;
            }
            catch (System.Exception ex)
            {
                isExists = false;
                throw ex;
            }
            return isExists;
        }

        #endregion

        #endregion

        #region ISystemManagementDAO Members


        public CResult CollectSalesReportRecords(long p_fromDate, long p_toDate)
        {
            CResult objResult = new CResult();
            DataSet dsSalesReports = new DataSet();
            try
            {
                this.OpenConnection();

                string sqlCommand = "";

                //sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSalesRecords), p_fromDate,p_toDate); //Previous

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetInventorySalesRecords), p_fromDate, p_toDate);

                string[] splitter=new string[0];
                splitter = sqlCommand.Split(';');
                sqlCommand = Convert.ToString(splitter[1]);
                dsSalesReports= this.GetDataset(sqlCommand);

                objResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in CollectSalesReportRecords()", LogLevel.Error, "Database");
                objResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            objResult.Data = dsSalesReports;
            return objResult;
        }

        #endregion


        #region Get Order information

        List<CSearchOrderInfo> ISystemManagementDAO.GetOrderInfo(Int64 startDate, Int64 endDate)
        {
            List<CSearchOrderInfo> oItemList = new List<CSearchOrderInfo>();

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
                        // oOrderInfo = orderInfoReader(oReader);
                        CSearchOrderInfo oItem = orderInfoReader(oReader);
                        oItemList.Add(oItem);

                    }
                }

                //oResult.Data = oOrderInfo;
                //oResult.IsSuccess = true;

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetOrderInfo()", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }

            return oItemList; ;
        }

         List<CArchiveItemDetails> ISystemManagementDAO.GetOrderDetailInfo(Int32 orderID)
        {
            List<CArchiveItemDetails> oItemList = new List<CArchiveItemDetails>();

            try
            {
                this.OpenConnection();
                string sqlCommand = "";
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetArchiveItemDetails), orderID.ToString());
                //this.ExecuteNonQuery(sqlCommand);
                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        // oOrderInfo = orderInfoReader(oReader);
                        CArchiveItemDetails oItem = orderDetailsInfoReader(oReader);
                        oItemList.Add(oItem);

                    }
                }

                //oResult.Data = oOrderInfo;
                //oResult.IsSuccess = true;

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetOrderInfo()", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }

            return oItemList; ;
        }
        #endregion



         public CResult CollectRawMat(long p_fromDate, long p_toDate)

         {

             CResult objResult = new CResult();

             DataTable dsSalesReports = new DataTable();//Umme
             try
             {
                 this.OpenConnection();

                 string sqlCommand = "";

                 //sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSalesRecords), p_fromDate,p_toDate); //Previous

                 sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetRawMat), p_fromDate, p_toDate);

                 string[] splitter = new string[0];
                 splitter = sqlCommand.Split(';');
                 sqlCommand = Convert.ToString(splitter[1]);

                 dsSalesReports = this.GetDatasetTable(sqlCommand);            

                 objResult.IsSuccess = true;
             }

             catch (Exception ex)
             {
                 Logger.Write("Exception : " + ex + " in CollectSalesReportRecords()", LogLevel.Error, "Database");
                 objResult.IsException = true;
             }
             finally
             {
                 this.CloseConnection();
             }
             objResult.Data = dsSalesReports;
             return objResult;
         
         }
        private CSearchOrderInfo orderInfoReader(IDataReader oReader)
        {

            CSearchOrderInfo oOrderInfo = new CSearchOrderInfo();

            if (oReader["Order ID"] != DBNull.Value)
                oOrderInfo.OrderID = Int32.Parse(oReader["Order ID"].ToString());

            if (oReader["Serial No."] != DBNull.Value)
                oOrderInfo.SerialNumber = oReader["Serial No."].ToString();

            if (oReader["Order Date-Time"] != DBNull.Value)
                oOrderInfo.OrderDateTime = new DateTime(Int64.Parse(oReader["Order Date-Time"].ToString()));
           

            if (oReader["Order Type"] != DBNull.Value)
                oOrderInfo.OrderType = oReader["Order Type"].ToString();

            if (oReader["Table No."] != DBNull.Value)
                oOrderInfo.TableNumber = Int32.Parse(oReader["Table No."].ToString());

            if (oReader["Covers"] != DBNull.Value)
                oOrderInfo.Covers = Int32.Parse(oReader["Covers"].ToString());

            if (oReader["Food Total"] != DBNull.Value)
                oOrderInfo.FoodTotal = Decimal.Parse(oReader["Food Total"].ToString());

            if (oReader["Non-Food Total"] != DBNull.Value)
                oOrderInfo.NonfoodTotal = Decimal.Parse(oReader["Non-Food Total"].ToString());

            if (oReader["Order Total"] != DBNull.Value)
                oOrderInfo.OrderTotal = Decimal.Parse(oReader["Order Total"].ToString());

            if (oReader["Discount"] != DBNull.Value)
                oOrderInfo.Discount = Decimal.Parse(oReader["Discount"].ToString());

            if (oReader["Service Charge"] != DBNull.Value)
                oOrderInfo.ServiceChargeCash = Decimal.Parse(oReader["Service Charge"].ToString());

            if (oReader["Total Paid(Ex.Vat)"] != DBNull.Value)
                oOrderInfo.TotalPaidExcludingVat = Decimal.Parse(oReader["Total Paid(Ex.Vat)"].ToString());

            if (oReader["Total Paid(Inc. Vat)"] != DBNull.Value)
                oOrderInfo.TotalPaidIncludingVat = Decimal.Parse(oReader["Total Paid(Inc. Vat)"].ToString());

            if (oReader["Vat Paid"] != DBNull.Value)
                oOrderInfo.VatPaid = Decimal.Parse(oReader["Vat Paid"].ToString());

            if (oReader["Cash Paid"] != DBNull.Value)
                oOrderInfo.CashPaid = Decimal.Parse(oReader["Cash Paid"].ToString());

            if (oReader["EFT Paid"] != DBNull.Value)
                oOrderInfo.EFTPaid = Decimal.Parse(oReader["EFT Paid"].ToString());

            if (oReader["Vat Imposed"] != DBNull.Value)
                oOrderInfo.VatImposed = oReader["Vat Imposed"].ToString();

            if (oReader["Oder Created By"] != DBNull.Value)
                oOrderInfo.OrderCreatedBy = oReader["Oder Created By"].ToString();

            if (oReader["Payment Date-Time"] != DBNull.Value)
                oOrderInfo.PaymentDateTime = new DateTime(Int64.Parse(oReader["Payment Date-Time"].ToString()));

            if (oReader["Terminal ID"] != DBNull.Value)
                oOrderInfo.TerminalID = oReader["Terminal ID"].ToString();

            if (oReader["Status"] != DBNull.Value)
                oOrderInfo.OrderStatus = oReader["Status"].ToString();

            if (oReader["Guset Bill"] != DBNull.Value)
                oOrderInfo.GuestBill = oReader["Guset Bill"].ToString();

            if (oReader["EFTCardName"] != DBNull.Value)
            {
                oOrderInfo.EFTCardName = oReader["EFTCardName"].ToString();
            }
            else
            {
                oOrderInfo.EFTCardName = "[...]";
            }

            if (oReader["vat_stat"] != DBNull.Value)
                oOrderInfo.Vat_stat = Convert.ToBoolean(oReader["vat_stat"].ToString());

            try
            {
                oOrderInfo.TotalCost = Convert.ToDouble(oReader["cost"]);
            }
            catch (Exception)
            {
                
            
            }
            try
            {
                oOrderInfo.Waiter = (oReader["waiter"]).ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                oOrderInfo.TipsAmount = Convert.ToDouble(oReader["tipsamount"]);
            }
            catch (Exception)
            {


            }
            try
            {
                oOrderInfo.MembershipDiscount = Convert.ToDouble(oReader["membershipDiscount"]);
            }
            catch (Exception)
            {


            }

            try
            {
                oOrderInfo.ComplementoryMessage = (oReader["Complementory"]).ToString();
            }
            catch (Exception)
            {
            }

            try
            {
                oOrderInfo.DueMessage = (oReader["Due"]).ToString();
            }
            catch (Exception)
            {


            }
            try
            {
                oOrderInfo.PaymentPerson = (oReader["PaymentPerson"]).ToString();
            }
            catch (Exception)
            {


            }

            try
            {
                oOrderInfo.DuePaid = Decimal.Parse((oReader["Due Paid"]).ToString());
            }
            catch (Exception)
            {


            }

            try
            {
                oOrderInfo.ComplementoryPaid = Decimal.Parse((oReader["Complementory Paid"]).ToString());
            }
            catch (Exception)
            {


            }

            try
            {
                oOrderInfo.ItemDiscount = Convert.ToDouble(oReader["ItemDiscount"]);
            }
            catch (Exception)
            {


            }


            oOrderInfo.DueBill = (double) oOrderInfo.DuePaid;


            return oOrderInfo;
        }

        private CArchiveItemDetails orderDetailsInfoReader(IDataReader oReader)
        {
            CArchiveItemDetails oOrderInfo = new CArchiveItemDetails();

            if (oReader["order_detail_id"] != DBNull.Value)
                oOrderInfo.OrderDetailID = int.Parse(oReader["order_detail_id"].ToString());
            if (oReader["cat_level"] != DBNull.Value)
                oOrderInfo.CatLevel = int.Parse(oReader["cat_level"].ToString());
            if (oReader["order_id"] != DBNull.Value)
                oOrderInfo.OrderID = int.Parse(oReader["order_id"].ToString());
            if (oReader["product_id"] != DBNull.Value)
                oOrderInfo.ProductID = int.Parse(oReader["product_id"].ToString());
            if (oReader["quantity"] != DBNull.Value)
                oOrderInfo.Quantity = int.Parse(oReader["quantity"].ToString());
            if (oReader["amount"] != DBNull.Value)
                oOrderInfo.Amount = Double.Parse(oReader["amount"].ToString());
            if (oReader["guest_count"] != DBNull.Value)
                oOrderInfo.GuestCount = int.Parse(oReader["guest_count"].ToString());

            if (oReader["item_order_time"] != DBNull.Value)
                oOrderInfo.ItemOrderTime = Int64.Parse(oReader["item_order_time"].ToString());
            if (oReader["serial_no"] != DBNull.Value)
                oOrderInfo.SerialNo = Int64.Parse(oReader["serial_no"].ToString());
            if (oReader["order_time"] != DBNull.Value)
                oOrderInfo.OrderTime = Int64.Parse(oReader["order_time"].ToString());

            if (oReader["user_name"] != DBNull.Value)
                oOrderInfo.UserName = oReader["user_name"].ToString();
            if (oReader["remarks"] != DBNull.Value)
                oOrderInfo.Remarks = oReader["remarks"].ToString();
            if (oReader["food_type"] != DBNull.Value)
                oOrderInfo.FoodType = oReader["food_type"].ToString();
            if (oReader["table_name"] != DBNull.Value)
                oOrderInfo.TableName = oReader["table_name"].ToString();
            if (oReader["item_name"] != DBNull.Value)
                oOrderInfo.ItemName = oReader["item_name"].ToString();           

            return oOrderInfo;
        }




        public CResult GetItemWiseSalesReport(long fromOID, long toOID, string foodType, Byte showAll)
        {
            CResult oResult = new CResult();
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSalesItemReportWithOrderRange),fromOID, toOID, foodType, showAll);
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);

                dt.Load(objDatareader);
                oResult.Data = dt;
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSalesItemReportWithOrderRange()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }







        public CResult CollectSalesReportRecordsForInv(long p_fromDate, long p_toDate)
        {
            CResult objResult = new CResult();

            DataTable dsSalesReports = new DataTable();//@Salim
            try
            {
                this.OpenConnection();

                string sqlCommand = "";

                //sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSalesRecords), p_fromDate,p_toDate); //Previous

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetInventorySalesRecordsInv), p_fromDate, p_toDate);

                string[] splitter = new string[0];
                splitter = sqlCommand.Split(';');
                sqlCommand = Convert.ToString(splitter[1]);

                dsSalesReports = this.GetDatasetTable(sqlCommand);     //@Salim         

                objResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in CollectSalesReportRecords()", LogLevel.Error, "Database");
                objResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            objResult.Data = dsSalesReports;
            return objResult;
        }

        public DataTable GetComplementorySales(long startDate, long endDate)
        {
            
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format("exec [dbo].[sp_GetComplementorySaleReport]{0},{1}", startDate, endDate);
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);

                dt.Load(objDatareader);
               
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSalesItemReportWithOrderRange()", LogLevel.Error, "Database");
               // oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return dt;
        }

        public DataTable GetCategoryWiseSales(long startDate, long endDate)
        {
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCategoryWiseSales), startDate, endDate);
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);

                dt.Load(objDatareader);

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSalesItemReportWithOrderRange()", LogLevel.Error, "Database");
                // oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return dt;
        }
    }
}
