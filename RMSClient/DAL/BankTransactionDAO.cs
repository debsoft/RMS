using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
    public  class BankTransactionDAO:BaseDAO
    {
        public string InsertDebitTransaction(BankTransaction aTransaction)
        {
            string result;

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertDebitTransaction),aTransaction.BankName,aTransaction.BankName,aTransaction.AcoountNumber,
                    aTransaction.DepositeDate,aTransaction.DepositePerson,aTransaction.DepositeAmount);
                this.ExecuteNonQuery(sqlCommand);
                result = "Debit Transaction Save Successfully";
            }

            catch (Exception ex)
            {
                result = "Debit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;

        }

        public string InsertCreditTransaction(BankTransaction aTransaction)
        {
            string result;

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertCreditTransaction), aTransaction.BankName, aTransaction.BankName, aTransaction.AcoountNumber,
                    aTransaction.DepositeDate, aTransaction.DepositePerson, aTransaction.DepositeAmount);
                this.ExecuteNonQuery(sqlCommand);
                result = "Credit Transaction Save Successfully";
            }

            catch (Exception ex)
            {
                result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public string InsertotherCreditTransaction(BankTransaction aTransaction)
        {
            string result;

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertotherCreditTransaction), aTransaction.BankName, aTransaction.BankName, aTransaction.AcoountNumber,
                    aTransaction.DepositeDate, aTransaction.DepositePerson, aTransaction.DepositeAmount);
                this.ExecuteNonQuery(sqlCommand);
                result = "Credit Transaction Save Successfully";
            }

            catch (Exception ex)
            {
                result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public CResult GetDebitreportBydate(DateTime fromtime, DateTime totime)
        {
            CResult aResult=new CResult();
            double amount = 0;
            try
            {

               // this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetDebitreportBydate),fromtime,totime);
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();
                aResult.Data = table;
            }

            catch (Exception ex)
            {
                
            }
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllDebitAmountByDate), fromtime, totime);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if(oReader!=null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            amount += Convert.ToDouble(oReader["Debit_Amount"]);
                        }
                        catch (Exception)
                        {
                            
                          
                        }
                    }
                }

            }

            catch (Exception ex)
            {
              //  result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }
            aResult.Amount = amount;
            return aResult;
        }

        public CResult GetCreditreportBydate(DateTime fromtime, DateTime totime)
        {
            CResult aResult = new CResult();
            double amount = 0;
            try
            {

                // this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCreditreportBydate),fromtime , totime);
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();
                aResult.Data = table;
            }

            catch (Exception ex)
            {

            }
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllCreditAmountByDate), fromtime,totime);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            amount += Convert.ToDouble(oReader["Credit_Amount"]);
                        }
                        catch (Exception)
                        {


                        }
                    }
                }

            }

            catch (Exception ex)
            {
                //  result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }
            aResult.Amount = amount;
            return aResult;
        }

        public CResult GetotherDebitreportBydate(DateTime fromtime, DateTime totime)
        {
            CResult aResult = new CResult();
            double amount = 0;
            try
            {

                // this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetotherDebitreportBydate),fromtime,totime);
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();
                aResult.Data = table;
            }

            catch (Exception ex)
            {

            }
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllotherDebitAmountByDate), fromtime,totime);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            amount += Convert.ToDouble(oReader["Other_DEBIT"]);
                        }
                        catch (Exception)
                        {


                        }
                    }
                }

            }

            catch (Exception ex)
            {
                //  result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }
            aResult.Amount = amount;
            return aResult;
        }

        public CResult GetBalanceReport(DateTime fromdate, DateTime todate)
        {
            CResult aResult = new CResult();

            try
            {

                // this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetBalanceReport), fromdate, todate);
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();
                aResult.Data = table;
            }

            catch (Exception ex)
            {

            }
            return aResult;
        }

        public List<double> GetNowBankbalance(DateTime today)
        {
            List<double >amount=new List<double>();
            double balance = 0;
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetNowBankbalance), today);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            balance = Convert.ToDouble(oReader["balanceamount"]);
                            amount.Add(balance);
                            balance = Convert.ToDouble(oReader["creditamount"]);
                            amount.Add(balance);
                            balance = Convert.ToDouble(oReader["debitamount"]);
                            amount.Add(balance);
                            balance = Convert.ToDouble(oReader["otherdebitamount"]);
                            amount.Add(balance);
                            balance = Convert.ToDouble(oReader["cashamount"]);
                            amount.Add(balance);

                        }
                        catch (Exception)
                        {


                        }
                    }
                }

            }

            catch (Exception ex)
            {
                //  result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }
            return amount;
        }

        public string InsertCashTransaction(BankTransaction aTransaction)
        {
            string result;

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertCashTransaction), aTransaction.BankName,
                    aTransaction.DepositeDate, aTransaction.DepositePerson, aTransaction.DepositeAmount);
                this.ExecuteNonQuery(sqlCommand);
                result = "Cash Transaction Save Successfully";
            }

            catch (Exception ex)
            {
                result = "Cash Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public CResult GetCashreportBydate(DateTime fromtime, DateTime totime)
        {
            CResult aResult = new CResult();
            double amount = 0;

            try
            {

                // this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCashreportBydate), fromtime,totime);
                RMS.Common.CCommonConstants oConstants = RMS.ConfigManager.GetConfig<RMS.Common.CCommonConstants>();
                String tempConnStr = oConstants.DBConnection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataAdapter.Dispose();
                aResult.Data = table;
            }

            catch (Exception ex)
            {

            }
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetAllCashAmountByDate), fromtime, totime);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
               
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            amount += Convert.ToDouble(oReader["Cash_Amount"]);
                        }
                        catch (Exception)
                        {


                        }
                    }
                }

            }

            catch (Exception ex)
            {
                //  result = "Credit Transaction Couldn,t Save Successfully";
            }
            finally
            {
                this.CloseConnection();
            }
            aResult.Amount = amount;
            return aResult;
        }



    }
}
