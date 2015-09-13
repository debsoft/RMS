using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using RMS.Common;


namespace RMS.DataAccess
{
    public class CPaymentDAO : BaseDAO, IPaymentDAO//Changed
    {
        public Int64 m_oStartTime;
        public Int64 m_oEndTime;

        # region IPayment members

        public CPayment InsertPayment(CPayment inPayment)//Changed
        {
            CPayment tempPayment = inPayment;
            try
            {
                DateTime dtPayment = DateTime.Now;
                dtPayment = new DateTime(dtPayment.Year, dtPayment.Month, dtPayment.Day, dtPayment.Hour, dtPayment.Minute, 0);
                Int64 dateTime = dtPayment.Ticks;
                CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                CUserInfo objUserInfo = oConstant.UserInfo;

                this.OpenConnectionWithTransection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.PaymentInsert),
                    inPayment.OrderID,inPayment.PcID,inPayment.TotalAmount,inPayment.CashAmount,
                    inPayment.EFTAmount,inPayment.ChequeAmount,inPayment.VoucherAmount, inPayment.ServiceAmount,
                    inPayment.Discount, inPayment.AccountPay, inPayment.DepositID, inPayment.DepositAmount, "'" + objUserInfo.UserName + "'", 
                    dateTime, inPayment.ServiceChargeCash, inPayment.ServiceChargeEft, inPayment.ServiceChargeCheque, inPayment.ServiceChargeVoucher, 
                    inPayment.ServiceChargeAcc, inPayment.VatImposed, inPayment.GuestBill, Convert.ToByte(inPayment.Vat_stat),inPayment.TotalCost,
                    inPayment.Waiter, tempPayment.TipsAmount, inPayment.membershipDiscount,inPayment.ComplementoryMessage,inPayment.DueMessage,inPayment.PaymentPerson,
                    inPayment.ItemDiscount);

                this.ExecuteNonQuery(sSql);
                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempPayment.PaymentID = Int64.Parse(oReader[0].ToString());

                    }
                    oReader.Close();
                }

                sSql = String.Format(SqlQueries.GetQuery(Query.GetOrderIDFromBillPrintTime), inPayment.OrderID);
                oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead2 = oReader.Read();
                    if (bIsRead2)
                    {
                        oReader.Close();
                        //sSql = String.Format(SqlQueries.GetQuery(Query.UpdateBillPrintTime), inPayment.BillPrintTime, inPayment.PaymentTime, inPayment.OrderID);
                        sSql = String.Format(SqlQueries.GetQuery(Query.UpdateBillPrintTime), inPayment.BillPrintTime.Ticks, inPayment.PaymentTime.Ticks, inPayment.OrderID);
                        this.ExecuteNonQuery(sSql);

                    }
                    else
                    {
                        oReader.Close();
                        //sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime, inPayment.PaymentTime);
                        sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime.Ticks, inPayment.PaymentTime.Ticks);
                        this.ExecuteNonQuery(sSql);
                    }

                }
                

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertPayment()", LogLevel.Error, "Database");

               // throw new Exception("Exception occure at InsertPayment()", ex);
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return tempPayment;

        }

        public void InsertBillPrintTime(CPayment inPayment)//Changed
        {
            try
            {

                this.OpenConnection();
                //string sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime, inPayment.PaymentTime);
                string sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime.Ticks, inPayment.PaymentTime.Ticks);
                this.ExecuteNonQuery(sSql);
                

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertBillPrintTime()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at InsertBillPrintTime()", ex);
                
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void UpdatePayment(CPayment inPayment)//Changed
        {
            try
            {
                this.OpenConnectionWithTransection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.PaymentUpdate),
                    inPayment.OrderID, inPayment.PcID, inPayment.TotalAmount, inPayment.CashAmount,
                    inPayment.EFTAmount, inPayment.ChequeAmount, inPayment.VoucherAmount, inPayment.ServiceAmount,
                    inPayment.Discount, inPayment.AccountPay, inPayment.DepositID, inPayment.DepositAmount, inPayment.PaymentID, inPayment.ServiceChargeCash, inPayment.ServiceChargeEft, inPayment.ServiceChargeCheque, inPayment.ServiceChargeVoucher, inPayment.ServiceChargeAcc, inPayment.VatImposed, inPayment.GuestBill, Convert.ToByte(inPayment.Vat_stat));

                this.ExecuteNonQuery(sSql);

                sSql = String.Format(SqlQueries.GetQuery(Query.GetOrderIDFromBillPrintTime), inPayment.OrderID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead2 = oReader.Read();
                    if (bIsRead2)
                    {
                        oReader.Close();
                        //sSql = String.Format(SqlQueries.GetQuery(Query.UpdateBillPrintTime), inPayment.BillPrintTime, inPayment.PaymentTime, inPayment.OrderID);
                        sSql = String.Format(SqlQueries.GetQuery(Query.UpdateBillPrintTime), inPayment.BillPrintTime.Ticks, inPayment.PaymentTime.Ticks, inPayment.OrderID);
                        this.ExecuteNonQuery(sSql);
                    }
                    else
                    {
                        oReader.Close();
                        //sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime, inPayment.PaymentTime);
                        sSql = String.Format(SqlQueries.GetQuery(Query.InsertBillPrintTime), inPayment.OrderID, inPayment.BillPrintTime.Ticks, inPayment.PaymentTime.Ticks);
                        this.ExecuteNonQuery(sSql);
                    }
                }
                this.CommitTransection();
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdatePayment()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }
        }

       
      
        
        public void DeletePayment(CPayment inPayment)
        {
            try
            {

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.PaymentDelete),inPayment.PaymentID);

                this.ExecuteNonQuery(sSql);

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeletePayment()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at DeletePayment()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public CPayment GetPaymentByOrderID(Int64 inOrderID) 
        {
            CPayment tempPayment= new CPayment();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.PayementGetByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempPayment= ReaderToPayment(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in GetPaymentByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetPaymentByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetPaymentByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempPayment;
        }

        public double GetSortedPayment(DateTime inTime)
        {
            double MaxAmount = 0.0;
            GetTimeSpan(inTime);
            try
            {
                this.OpenConnection();

                string sSql = string.Format(SqlQueries.GetQuery(Query.GetSortedPayment),m_oStartTime,m_oEndTime);

                IDataReader oReader = this.ExecuteReader(sSql);

                CPayment tempPayment = new CPayment();
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        Double.TryParse(oReader.GetValue(0).ToString(), out MaxAmount);                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in GetSortedPayment()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetSortedPayment()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetPaymentByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return MaxAmount;
        }

        #endregion

        CPayment ReaderToPayment(IDataReader inReader)
        {
            CPayment tempPayment = new CPayment();

            if (inReader["payment_id"] != null)
            {
                tempPayment.PaymentID = Int64.Parse(inReader["payment_id"].ToString());
            }

            if (inReader["order_id"] != null)
            {
                tempPayment.OrderID = Int64.Parse(inReader["order_id"].ToString());
            }

            if (inReader["pc_id"] != null)
            {
                tempPayment.PcID = int.Parse(inReader["pc_id"].ToString());
            }

            if (inReader["total_amount"] != null)
            {
                tempPayment.TotalAmount =Double.Parse(inReader["total_amount"].ToString());
            }

            if (inReader["cash_amount"] != null)
            {
                tempPayment.CashAmount= Double.Parse(inReader["cash_amount"].ToString());
            }

            if (inReader["eft_amount"] != null)
            {
                tempPayment.EFTAmount= Double.Parse(inReader["eft_amount"].ToString());
            }

            if (inReader["cheque_amount"] != null)
            {
                tempPayment.ChequeAmount = Double.Parse(inReader["cheque_amount"].ToString());
            }

            if (inReader["voucher_amount"] != null)
            {
                tempPayment.VoucherAmount= Double.Parse(inReader["voucher_amount"].ToString());
            }

            if (inReader["service_amount"] != null)
            {
                tempPayment.ServiceAmount = Double.Parse(inReader["service_amount"].ToString());
            }


            if (inReader["discount"] != null)
            {
                tempPayment.Discount = Double.Parse(inReader["discount"].ToString());
            }


            if (inReader["account_pay"] != null)
            {
                tempPayment.AccountPay = Double.Parse(inReader["account_pay"].ToString());
            }

            if (inReader["deposit_id"] != null)
            {
                tempPayment.DepositID = Int64.Parse(inReader["deposit_id"].ToString());
            }

            if (inReader["deposit_amount"] != null)
            {
                tempPayment.DepositAmount= Double.Parse(inReader["deposit_amount"].ToString());
            }

            return tempPayment;
        }

        public void GetTimeSpan(DateTime inCurrentDate)//Changed
        {
            Int64 tempStartTime = inCurrentDate.Ticks;
            Int64 tempEndTime = inCurrentDate.AddDays(1).Ticks;

            Int64 tempCheckTime = (inCurrentDate.Date.AddHours(8)).Ticks;

            if (inCurrentDate.Ticks < tempCheckTime)
            {
                tempStartTime = tempCheckTime - 864000000000;
                tempEndTime = tempCheckTime;
            }

            else if (inCurrentDate.Ticks >= tempCheckTime)
            {
                tempStartTime = tempCheckTime;
                tempEndTime = tempCheckTime + 864000000000;
            }

            m_oStartTime = tempStartTime;
            m_oEndTime = tempEndTime;

        }

        #region "Log Area"

        public CResult GetPaymentLogDetails(Int64 startTime, Int64 endTime)
        {
            CResult tempcResult = new CResult();
            List<CPayment> paymentdetails = new List<CPayment>();
            string sqlCommand = String.Format(SqlQueries.GetQuery(Query.LogRegisterForPayment), startTime,endTime);
            IDataReader oReader = this.ExecuteReader(sqlCommand);
            if (oReader != null)
            {
                while (oReader.Read())
                {
                    CPayment tempPayment = new CPayment();
                    tempPayment = ReaderToPayment(oReader,true);
                    paymentdetails.Add(tempPayment);
                }
            }
            tempcResult.Data = paymentdetails;
            return tempcResult;
        }

       private CPayment ReaderToPayment(IDataReader inReader,bool isExists)
        {
            CPayment tempPayment = new CPayment();

            if (inReader["pc_id"] != null)
            {
                tempPayment.PcID = int.Parse(inReader["pc_id"].ToString());
            }

            if (inReader["userid"] != null)
            {
                tempPayment.UserID = Convert.ToString(inReader["userid"].ToString());
            }

            if (inReader["paymentdate"] != null)
            {
                Int64 dateTime = Convert.ToInt64(inReader["paymentdate"].ToString());
                tempPayment.PaymentTime = new DateTime(dateTime);// Convert.ToDateTime(dateTime);
            }

            if (inReader["total_amount"] != null)
            {
                tempPayment.TotalAmount = Double.Parse(inReader["total_amount"].ToString());
            }
            if (inReader["order_id"] != null)
            {
                tempPayment.OrderID = Int32.Parse(inReader["order_id"].ToString());
            }
            return tempPayment;
        }

        /// <summary>
        /// Save Drawing Opening logs
        /// </summary>
        /// <param name="terminal_id"></param>
        /// <param name="user_id"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public CPayment SaveDrawerLogs(Int32 terminal_id, string user_id, Int64 dateTime)
        {
            CPayment tempPayment = new CPayment();
            string sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveDrawerOpening), user_id, dateTime, terminal_id);
            this.ExecuteNonQuery(sqlCommand);
            sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

            IDataReader oReader = this.ExecuteReader(sqlCommand);

            if (oReader != null)
            {
                bool bIsRead = oReader.Read();
                if (bIsRead)
                {

                    tempPayment.PaymentID = Int64.Parse(oReader[0].ToString());
                }
                oReader.Close();
            }
            return tempPayment;
        }

        public CResult GetDrawerLogDetails(Int64 startTime, Int64 endTime)
        {
            CResult tempcResult = new CResult();
            List<CPayment> paymentdetails = new List<CPayment>();
            string sqlCommand = String.Format(SqlQueries.GetQuery(Query.DrawerLogdetails), startTime, endTime);
            IDataReader oReader = this.ExecuteReader(sqlCommand);
            if (oReader != null)
            {
                while (oReader.Read())
                {
                    CPayment tempPayment = new CPayment();


                    if (oReader["terminal_id"] != null)
                    {
                        tempPayment.PcID = int.Parse(oReader["terminal_id"].ToString());
                    }

                    if (oReader["userid"] != null)
                    {
                        tempPayment.UserID = Convert.ToString(oReader["userid"]);
                    }

                    if (oReader["opentime"] != null)
                    {
                        Int64 dateTime = Convert.ToInt64(oReader["opentime"].ToString());
                        tempPayment.PaymentTime = new DateTime(dateTime);// Convert.ToDateTime(dateTime);
                    }
                    paymentdetails.Add(tempPayment);
                }
            }
            tempcResult.Data = paymentdetails;
            return tempcResult;
        }


        #endregion


        public void UpdatePaymentVatStat(bool stat, long orderiD)
        {
           


            try
            {
                this.OpenConnectionWithTransection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.PaymentUpdateOnlyVatStat), Convert.ToByte(stat),  orderiD);

                this.ExecuteNonQuery(sSql);
             
                this.CommitTransection();
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdatePaymentVatStat()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public string UpdatePaymentForDueBill(CPayment aPayment, PaymentDueBill aPaymentDueBill)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.UpdatePaymentForDueBill), aPayment.OrderID, aPayment.CashAmount, aPayment.EFTAmount, aPayment.ChequeAmount);
                this.ExecuteNonQuery(sSql);
                result = "Due Bill Payment Successfully";
                int billid = CheckExistsDueBill(aPaymentDueBill);
                if (billid > 0)
                {
                    aPaymentDueBill.BillId = billid;
                    sSql = string.Format(SqlQueries.GetQuery(Query.UpdateTotalDueBillPayment), aPaymentDueBill.BillId, aPaymentDueBill.CashAmount, aPaymentDueBill.CardAmount, aPaymentDueBill.Cheque);
                    this.ExecuteNonQuery(sSql);
                }
                else
                {
                    sSql = string.Format(SqlQueries.GetQuery(Query.InsertTotalDueBillPayment), aPaymentDueBill.CashAmount, aPaymentDueBill.CardAmount, aPaymentDueBill.Cheque, DateTime.Now.Date);
                    this.ExecuteNonQuery(sSql);
                }

            }
            catch (Exception ex)
            {
                result = "Sorry Please Try again";
                Logger.Write("Exception : " + ex + " in UpdatePaymentVatStat()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        private int CheckExistsDueBill(PaymentDueBill aPaymentDueBill)
        {
            int result = 0;
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.CheckExistsDueBill), DateTime.Now.Date);
                IDataReader oReader = this.ExecuteReader(sSql);


                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        result = Convert.ToInt32(oReader[0]);
                    }

                    oReader.Close();
                }


            }
            catch (Exception ex)
            {

                Logger.Write("Exception : " + ex + " in CheckExistsDueBill()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public List<PaymentDueBill> GetTotalDuePayment(DateTime duebillfromDate, DateTime duebilltoDate)
        {
            List<PaymentDueBill> aPaymentDueBills = new List<PaymentDueBill>();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetTotalDuePayment), duebillfromDate, duebilltoDate);
                IDataReader oReader = this.ExecuteReader(sSql);


                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        PaymentDueBill aPaymentDueBill = new PaymentDueBill();
                        aPaymentDueBill = ReaderToReadDueBill(oReader);
                        aPaymentDueBills.Add(aPaymentDueBill);
                    }

                    oReader.Close();
                }


            }
            catch (Exception ex)
            {

                Logger.Write("Exception : " + ex + " in CheckExistsDueBill()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }

            return aPaymentDueBills;
        }

        private PaymentDueBill ReaderToReadDueBill(IDataReader oReader)
        {
            PaymentDueBill aPaymentDueBill = new PaymentDueBill();
            try
            {
                aPaymentDueBill.BillId = Convert.ToInt32(oReader["billId"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aPaymentDueBill.CashAmount = Convert.ToDouble(oReader["cashamount"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aPaymentDueBill.CardAmount = Convert.ToDouble(oReader["cardamount"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aPaymentDueBill.Cheque = Convert.ToDouble(oReader["chequeamount"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aPaymentDueBill.PaymentDate = Convert.ToDateTime(oReader["paymentdate"]);
            }
            catch (Exception)
            {
            }


            return aPaymentDueBill;
        }

    }
}
