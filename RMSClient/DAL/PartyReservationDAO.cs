using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RMS;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
    public class PartyReservationDAO:BaseDAO 
    {
        public int CheckAvabilityAndInsert(Reservation partyReservation)
        {
            int reservationId = 0;
            bool check = CheckAvabilityByDateAndArea(partyReservation);
            if(check)
            {
                try
                {
                    this.OpenConnection();
                    string sqlCommand = string.Format(SqlQueries.GetQuery(Query.Insertreservation),partyReservation.PartyDate,partyReservation.FromTime,partyReservation.ToTime,partyReservation.BookingArea );
                    this.ExecuteNonQuery(sqlCommand);
                    sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                    IDataReader oReader = this.ExecuteReader(sqlCommand);
                    if (oReader != null)
                    {
                        bool bIsRead = oReader.Read();
                        if (bIsRead)
                        {
                            try
                            {
                                reservationId = Int32.Parse(oReader[0].ToString());
                            }
                            catch (Exception)
                            {
             
                            }
                            
                        }
                        oReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    return reservationId;
                }
                finally
                {
                    this.CloseConnection();
                }

            }

            return reservationId;
        }

        private bool CheckAvabilityByDateAndArea(Reservation partyReservation)
        {
            List<string> fromtimes = new List<string>();
            List<string> totimes = new List<string>();


            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.CheckAvabilityByDateAndArea), partyReservation.PartyDate,partyReservation.BookingArea);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        string fromtime = oReader["fromtime"].ToString();
                        string totime = oReader["totime"].ToString();
                        fromtimes.Add(fromtime);
                        totimes.Add(totime);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CloseConnection();
            }

            int fromminute = Getminute(partyReservation.FromTime);
            int tominute = Getminute(partyReservation.ToTime);
            if (fromtimes.Count == 0) return true;
            else
            {
                bool flag = true;
                for(int i=0;i<fromtimes.Count;i++)
                {
                    int from = Getminute(fromtimes[i]);
                    int to= Getminute(totimes[i]);
                    if((from<fromminute && to< fromminute )||(from>fromminute && to>tominute))
                    {

                    }
                    else
                    {
                        flag = false;
                    }
                }
                return flag;
            }

            
        }

        private int Getminute(string fromTime)
        {
            int minute = 0;
            try
            {
                int hour =Convert.ToInt32((fromTime[0].ToString()+fromTime[1].ToString()));
                int  mini =Convert.ToInt32((fromTime[3].ToString() + fromTime[4].ToString()));
                if(fromTime[6]=='P')
                {
                    hour += 12;
                }
                minute = mini + (hour*60);

            }
            catch (Exception)
            {
                
         
            }
            return minute;
        }

        public string InsertMainGuestItemInformation(ReservationIteminformation aIteminformation, int reservationId)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertMainGuestItemInformation),aIteminformation.ItemName,aIteminformation.UnitPrice,
                    aIteminformation.TotalPrice,reservationId);
                this.ExecuteNonQuery(sqlCommand);
                result = "ItemInsertSucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't save sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public List<ReservationIteminformation> GetMainguestIteminformationByreservationId(int reservationId)
        {
            List<ReservationIteminformation> aIteminformations=new List<ReservationIteminformation>();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMainguestIteminformationByreservationId), reservationId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        ReservationIteminformation aIteminformation=new ReservationIteminformation();
                        aIteminformation = ReaderToItem(oReader);
                        aIteminformations.Add(aIteminformation);
                    }
                }
            }
            catch (Exception ex)
            {
           
            }
            finally
            {
                this.CloseConnection();
            }
            return aIteminformations;
        }

        private ReservationIteminformation ReaderToItem(IDataReader oReader)
        {
           ReservationIteminformation aIteminformation=new ReservationIteminformation();
            try
            {
                aIteminformation.ItemName = oReader["itemname"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                aIteminformation.ItemId = Convert.ToInt32(oReader["itemid"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aIteminformation.UnitPrice = Convert.ToDouble(oReader["unitprice"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aIteminformation.TotalPrice = Convert.ToDouble(oReader["totalprice"]);
            }
            catch (Exception)
            {
            }
            aIteminformation.Delete = "Delete";

            return aIteminformation;
        }

        public string InsertotherGuestItemInformation(ReservationIteminformation aIteminformation, int reservationId)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertotherGuestItemInformation), aIteminformation.ItemName, aIteminformation.UnitPrice,
                    aIteminformation.TotalPrice, reservationId);
                this.ExecuteNonQuery(sqlCommand);
                result = "ItemInsertSucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't save sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public List<ReservationIteminformation> GetotherguestIteminformationByreservationId(int reservationId)
        {
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetotherguestIteminformationByreservationId), reservationId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        ReservationIteminformation aIteminformation = new ReservationIteminformation();
                        aIteminformation = ReaderToItem(oReader);
                        aIteminformations.Add(aIteminformation);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CloseConnection();
            }
            return aIteminformations;
        }

        public string InsertUtilityItemInformation(ReservationIteminformation aIteminformation, int reservationId)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertUtilityItemInformation), aIteminformation.ItemName, aIteminformation.UnitPrice,
                    reservationId);
                this.ExecuteNonQuery(sqlCommand);
                result = "ItemInsertSucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't save sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public List<ReservationIteminformation> GetUtilityIteminformationByreservationId(int reservationId)
        {
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetUtilityIteminformationByreservationId), reservationId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        ReservationIteminformation aIteminformation = new ReservationIteminformation();
                        aIteminformation = ReaderToUtility(oReader);
                        aIteminformations.Add(aIteminformation);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CloseConnection();
            }
            return aIteminformations;
        }

        private ReservationIteminformation ReaderToUtility(IDataReader oReader)
        {
            ReservationIteminformation aIteminformation = new ReservationIteminformation();
            try
            {
                aIteminformation.ItemName = oReader["itemname"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                aIteminformation.ItemId = Convert.ToInt32(oReader["itemid"]);
            }
            catch (Exception)
            {
            }
        
            try
            {
                aIteminformation.TotalPrice = Convert.ToDouble(oReader["price"]);
            }
            catch (Exception)
            {
            }
            aIteminformation.Delete = "Delete";

            return aIteminformation;
        }

        public string UpdatePartyReservation(Reservation partyReservation)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdatePartyReservation),partyReservation.ReservationId,partyReservation.BookingDate,
                    partyReservation.LoginPerson,partyReservation.BookingArea,partyReservation.BookingType,partyReservation.NumberOfGuest,partyReservation.NumberofOtherGuest,
                    partyReservation.MainGuestAmount,partyReservation.OtherGuestAmount,partyReservation.UtilityCostAmount,partyReservation.TotalPayableAmount,partyReservation.DepositeAmount,
                    partyReservation.DueAmount,partyReservation.SpecialInstruction,partyReservation.ClientName,partyReservation.ClientPhone,partyReservation.ClientEmail,
                    partyReservation.ServiceCharge,partyReservation.Vat,partyReservation.Discount,partyReservation.PrintPreview);
                this.ExecuteNonQuery(sqlCommand);
                result = "Reservation Update Sucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't Update sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public string DeleteItemInfromationFormainGuest(int itemid)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteItemInfromationFormainGuest), itemid);
                this.ExecuteNonQuery(sqlCommand);
                result = "Item Deleted Sucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't deleted sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public string DeleteItemInfromationFormautilityCost(int itemid)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteItemInfromationFormautilityCost), itemid);
                this.ExecuteNonQuery(sqlCommand);
                result = "Item Deleted Sucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't deleted sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public string DeleteItemInfromationForotherGuest(int itemid)
        {
            string result = "";
            try
            {
                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteItemInfromationForotherGuest), itemid);
                this.ExecuteNonQuery(sqlCommand);
                result = "Item Deleted Sucessfully";

            }
            catch (Exception ex)
            {
                result = "Couldn't deleted sucessfully";
            }
            finally
            {
                this.CloseConnection();
            }

            return result;
        }

        public ServiceCharge OrderServiceChargeGetByOrderID(int reservationId)
        {
       

            ServiceCharge tempServiceCharge = new ServiceCharge();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetReservationServiceCharge), reservationId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            tempServiceCharge.ServiceChargeAmount = Convert.ToDouble("" + oReader["svc_charge"]);
                            tempServiceCharge.ServicechargeRate = Convert.ToDouble("" + oReader["svc_chargeRate"]);
                            tempServiceCharge.OrderID = reservationId;
                        }
                        catch (Exception)
                        {
                            
                          
                        }
                        
                      
                    }
                }

              
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderServiceChargeByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderServiceChargeByreservationId()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderServiceChargeByreservationId)", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempServiceCharge;
        }

        public void UpdateOrderServiceCharge(ServiceCharge tempOrderCharge)
        {
         
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateReservationServiceCharge),
                    tempOrderCharge.ServiceChargeAmount, tempOrderCharge.ServicechargeRate, tempOrderCharge.OrderID);

                this.ExecuteNonQuery(sqlCommand);
             
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateOrderServiceCharge()", LogLevel.Error, "Database");
               
            }
            finally
            {
                this.CloseConnection();
            }
           
        }

        public void InsertOrderServiceCharge(ServiceCharge tempOrderCharge)
        {
        
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertReservationServiceCharge),
                    tempOrderCharge.OrderID, tempOrderCharge.ServiceChargeAmount, tempOrderCharge.ServicechargeRate);

                this.ExecuteNonQuery(sqlCommand);
             
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertReservationServiceCharge()", LogLevel.Error, "Database");
               
            }
            finally
            {
                this.CloseConnection();
            }
           
        }

        public ServiceCharge OrderDiscountGetByOrderID(int reservationId)
        {
            ServiceCharge tempServiceCharge = new ServiceCharge();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetReservationDiscount), reservationId);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        try
                        {
                            tempServiceCharge.ServiceChargeAmount = Convert.ToDouble("" + oReader["discount"]);
                            tempServiceCharge.ServicechargeRate = Convert.ToDouble("" + oReader["discountPercent"]);
                            tempServiceCharge.OrderID = reservationId;
                        }
                        catch (Exception)
                        {


                        }


                    }
                }


            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderDiscountGetByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured atOrderDiscountGetByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at OrderDiscountGetByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempServiceCharge;
        }

        public void UpdateOrderDiscount(ServiceCharge tempOrderCharge)
        {
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateReservationDiscount),
                    tempOrderCharge.ServiceChargeAmount, tempOrderCharge.ServicechargeRate, tempOrderCharge.OrderID);

                this.ExecuteNonQuery(sqlCommand);

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateOrderDiscount()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void InsertOrderDiscount(ServiceCharge tempOrderCharge)
        {
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertReservationDiscount),
                    tempOrderCharge.OrderID, tempOrderCharge.ServiceChargeAmount, tempOrderCharge.ServicechargeRate);

                this.ExecuteNonQuery(sqlCommand);

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderDiscoun()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
