using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS;
using System.Data.SqlClient;
using System.Data;

namespace RMSClient.DataAccess
{
    public class EftCardDAO : BaseDAO, IEFTCardDAO
    {

        public EftCardDAO()
        { 
        
        }
        
    

        public CResult UpdateEFTCardList(EFTCard eftcard)
        {
            CResult tempResult = new CResult();

            try
            {
                string updateSql = string.Format(SqlQueries.GetQuery(Query.UpdateEftCard), eftcard.CardName, eftcard.Id);

                this.ExecuteNonQuery(updateSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateEftCard()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateEftCard()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateEftCard()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult InsertEFTCard(EFTCard eftcard)
        {
            CResult tempResult = new CResult();

            try
            {
                string insertSql = string.Format(SqlQueries.GetQuery(Query.InsertEftCard), eftcard.CardName);

                this.ExecuteNonQuery(insertSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in InsertEftCard()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at InsertEftCard()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertEftCard()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
           
        }

        public List<EFTCard> GetEftCards()
        {
            List<EFTCard> eftCards = new List<EFTCard>();
            string sSql = SqlQueries.GetQuery(Query.GetEftCatds);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);



                while (oReader.Read())
                {
                    EFTCard eftCard = new EFTCard();
                    eftCard.Id = Convert.ToInt32(oReader[0]);
                    eftCard.CardName = oReader[1].ToString();
                    eftCards.Add(eftCard);
                }


            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in getEftCards()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at getEftCards()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at getEftCards()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return eftCards;
        }


        public CResult DeleteEFTCard(EFTCard eftcard)
        {
            CResult tempResult = new CResult();

            try
            {
                string deletSql = string.Format(SqlQueries.GetQuery(Query.DeleteEftCard), eftcard.CardName);

                this.ExecuteNonQuery(deletSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in DeleteEftcard()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteEftcard()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteEftcard()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }


        public CResult InsertEFTPayment(long orderID, int cardID, string cardName)
        {
            CResult tempResult = new CResult();

            try
            {
                string insertSql = string.Format(SqlQueries.GetQuery(Query.AddEFTPayment), orderID, cardID, cardName);

                this.ExecuteNonQuery(insertSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in InsertEftPayment()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at InsertEftPayment()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertEftPayment()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult UpdateEFTPaymentByOrderID(long orderID, int cardID, string cardName)
        {

            CResult tempResult = new CResult();

            try
            {
                string updateSql = string.Format(SqlQueries.GetQuery(Query.UpdateEFTpaymentByOrderID), orderID, cardID, cardName);

                this.ExecuteNonQuery(updateSql);
                this.CommitTransection();
                tempResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateEftpayment()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateEftpayment()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateEftpayment()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }


        public bool IsCardAllReadyAssigned(long orderID)
        {
        
            int i=0;
            string sSql = string.Format(SqlQueries.GetQuery(Query.CountEFTpaymentForparticularOrderid), orderID);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);

                while (oReader.Read())
                {
                    i = Convert.ToInt32(oReader[0]);
                  
                }
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in getEftCards()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at getEftCards()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at getEftCards()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
    }
}
