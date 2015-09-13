using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Diagnostics;


namespace RMS.DataAccess
{
    public class CUserInfoDAO : BaseDAO, IUserInfoDAO 
    {
        public CUserInfoDAO()
        {
        }

        public CResult AddUser(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.AddUser), inUser.UserName, inUser.Password, inUser.Type, inUser.Status, inUser.Gender);
                    
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }
        

        public CResult UpdateUser(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1));
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ItemDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }
       

        public CResult DeleteUser(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCategory1));
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ItemDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public CResult GetUser(CUserInfo inCat)
        {
            CResult oResult = null;
            try
            {
                //this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
                //IDataReader oReader = this.ExecuteReader(sSql);
                //if (oReader != null)
                //{
                //    if (oReader.Read())
                //        oItem = ReaderToCategory1(oReader);
                //}
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult LogoutUser(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCurrentUser), inUser.UserID);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ItemDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public CResult LoginUser(CUserInfo inCat)
        {
           
            CResult oResult = new CResult();

            CUserInfo oUser = new CUserInfo();
            try
            {
                this.OpenConnection();

                
                string sSql = string.Format(SqlQueries.GetQuery(Query.LoginUser), inCat.UserName);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {

                       
                        oUser = ReaderToUserInfo(oReader);

                        if ((!oUser.Password.Equals(String.Empty)) && oUser.Password.Equals(inCat.Password) && oUser.Status != 0)
                        {                            
                            //oReader.Close();
                            //sSql = string.Format(SqlQueries.GetQuery(Query.CheckCurrentUser), oUser.UserName);
                            // oReader = this.ExecuteReader(sSql);

                             oResult.Data = oUser;

                             oResult.IsSuccess = true;

                             //if (oReader != null)
                             //{
                                
                             //    if (oReader.Read())
                             //    {
                                     
                             //        if (oReader["user_id"] != null)
                             //        {                                        
                             //            int iTempInt5 = Int32.Parse(oReader["user_id"].ToString());

                             //            oResult.Message = "User already logged in.";

                             //        }
                                     
                             //    }

                             //    else
                             //    {
                             //        oReader.Close();
                                    
                             //        sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCurrentUser), oUser.UserID);

                             //        this.ExecuteNonQuery(sSql);                                     

                             //        sSql = string.Format(SqlQueries.GetQuery(Query.AddCurrentUser), oUser.UserID, inCat.PCID);

                             //        this.ExecuteNonQuery(sSql);                                     
                                     
                             //        oResult.Data = oUser;

                             //        oResult.IsSuccess = true;

                                    
                             //    }
                             //}// if null

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in LoginUser() in CUserInfoDAO ", LogLevel.Error, "Database");

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult LoginAdminUser(CUserInfo inCat)
        {

            CResult oResult = new CResult();

            CUserInfo oUser = new CUserInfo();
            try
            {
                this.OpenConnection();


                string sSql = string.Format(SqlQueries.GetQuery(Query.LoginUser), inCat.UserName);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {


                    if (oReader.Read())
                    {


                        oUser = ReaderToUserInfo(oReader);

                        if ((!oUser.Password.Equals(String.Empty)) && oUser.Password.Equals(inCat.Password) && oUser.Status != 0)
                        {
                           oResult.IsSuccess = true;

                           oResult.Data = oUser;


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in LoginUser() in CUserInfoDAO ", LogLevel.Error, "Database");

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private CUserInfo ReaderToUserInfo(IDataReader oReader)
        {
            CUserInfo oItem = new CUserInfo();

            if (oReader["user_id"] != null)
                oItem.UserID = Int32.Parse(oReader["user_id"].ToString());

            if (oReader["user_name"] != null)
                oItem.UserName = oReader["user_name"].ToString();

            if (oReader["password"] != null)
                oItem.Password = oReader["password"].ToString();

            if (oReader["type"] != null)
                oItem.Type = Int32.Parse(oReader["type"].ToString());

            if (oReader["status"] != null)
                oItem.Status = Int32.Parse(oReader["status"].ToString());

            if (oReader["gender"] != null)
                oItem.Gender = oReader["gender"].ToString();

            return oItem;

        }

        public CResult GetUserAccess(CUserInfo inCat)
        {
            CResult oResult = new CResult();

            CUserAccess oUserAccess = new CUserAccess();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetUserAccess), inCat.UserID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    //if (oReader.Read())
                    //    oItem = ReaderToUserAccess(oReader);

                    while (oReader.Read())
                    {
                        oUserAccess = ReaderToUserAccess(oReader, oUserAccess);
                        //oItemList.Add(oItem);
                    }

                    oResult.Data = oUserAccess;

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private CUserAccess ReaderToUserAccess(IDataReader oReader, CUserAccess oUserAccess)
        {
            CUserInfo oItem = new CUserInfo();

            String sTempStr = String.Empty;

            if (oReader["name"] != null)
            {
                sTempStr = oReader["name"].ToString();

                if (sTempStr.Equals("OpenDrawer"))
                {
                    oUserAccess.OpenDrawer = 1;
                }
                else if (sTempStr.Equals("ReviewTransaction"))
                {

                    oUserAccess.ReviewTransaction = 1;
                }
                else if (sTempStr.Equals("VoidTable"))
                {
                    oUserAccess.VoidTable = 1;
                }
                else if (sTempStr.Equals("ViewReport"))
                {

                    oUserAccess.ViewReport = 1;

                }
                else if (sTempStr.Equals("TransferTable"))
                {

                    oUserAccess.TransferTable = 1;

                }
                else if (sTempStr.Equals("TillReporting"))
                {

                    oUserAccess.TillReporting = 1;
                }
                else if (sTempStr.Equals("MergeTable"))
                {

                    oUserAccess.MergeTable = 1;
                }
                else if (sTempStr.Equals("ExitRMS"))
                {

                    oUserAccess.ExitRms = 1;
                }
                else if (sTempStr.Equals("UnlockTable"))
                {

                    oUserAccess.UnlockTable = 1;
                }

                else if (sTempStr.Equals("Booking"))
                {

                    oUserAccess.Booking = 1;
                }
                else if (sTempStr.Equals("Users"))
                {

                    oUserAccess.Users = 1;
                }
                else if (sTempStr.Equals("Deposit"))
                {

                    oUserAccess.Deposit = 1;
                }
                else if (sTempStr.Equals("Customers"))
                {

                    oUserAccess.Customers = 1;
                }
                else if (sTempStr.Equals("UpdateItems"))
                {

                    oUserAccess.UpdateItems = 1;
                }
                else if (sTempStr.Equals("RemoveItems"))
                {

                    oUserAccess.RemoveItems = 1;
                }
                else if (sTempStr.Equals("LogRegister"))
                {

                    oUserAccess.LogRegister = 1;
                } 
                else
                {
                }
            }
            return oUserAccess;
        }


        //public CResult InsertHouseSeller(CHomeSeller oSeller)
        //{
        //    //CResult oResult = new CResult();
        //    //try
        //    //{
        //    //    this.OpenConnection();
        //    //    string sSql = string.Format(SqlQueries.GetQuery(Query.HomeSellerAdd),
        //    //        oSeller.HomeSellerID, oSeller.FirstName, oSeller.LastName, oSeller.Address1, oSeller.DayTimePhone, oSeller.Fax, oSeller.Email, oSeller.City, oSeller.State, oSeller.ZipCode, oSeller.NightPhone, oSeller.MobilePhone, oSeller.RegisterDate);
        //    //    this.ExecuteNonQuery(sSql);

        //    CResult oResult = new CResult();

        //    try
        //    {


        //        this.OpenConnection();

        //        string sSql = string.Format(SqlQueries.GetQuery(Query.UserLogin), oSeller.UserName, 4);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            bool bIsRead = oReader.Read();
        //            if (bIsRead)
        //            {
        //                if (oReader["user_password"] != DBNull.Value && oReader["client_id"] != DBNull.Value)
        //                {
        //                    string sTempStr = oReader["user_password"].ToString();

        //                    oSeller.HomeSellerID = Int64.Parse(oReader["client_id"].ToString());

        //                    oReader.Close();

        //                    oResult.IsSuccess = false;
        //                }

        //            }
        //            else
        //            {
        //                oReader.Close();
        //                sSql = string.Format(SqlQueries.GetQuery(Query.HomeSellerAdd), oSeller.FirstName, oSeller.LastName, oSeller.Address1, oSeller.DayTimePhone, oSeller.Fax, oSeller.Email, oSeller.City, oSeller.State, oSeller.ZipCode, oSeller.NightPhone, oSeller.MobilePhone, oSeller.RegisterDate);

        //                this.ExecuteNonQuery(sSql);

        //                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

        //                oReader = this.ExecuteReader(sSql);
        //                if (oReader != null)
        //                {
        //                    bIsRead = oReader.Read();
        //                    if (bIsRead)
        //                    {

        //                        oSeller.HomeSellerID = Int64.Parse(oReader[0].ToString());

        //                        oResult.Data = oSeller;
        //                    }
        //                    else
        //                    {


        //                    }
        //                }

        //                oReader.Close();

        //                sSql = string.Format(SqlQueries.GetQuery(Query.InsertUser), 4, oSeller.UserName, oSeller.Password, oSeller.HomeSellerID);
        //                this.ExecuteNonQuery(sSql);

        //                oResult.IsSuccess = true;
        //            }
        //        }
        //        else
        //        {
        //        }


        //        // return oResult;

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in CategoryCreate()", LogLevel.Error, "Database");
        //        //throw new Exception("Exception occure at CategoryCreate()", ex);

        //        oResult.IsException = true;

        //        oResult.Message = ex.Message;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return oResult;
        //}









        //public CResult UpdateAgent(CAgent oSeller)
        //{
        //    CResult oResult = new CResult();
        //    try
        //    {
        //        this.OpenConnection();

        //        // sRetval = "UPDATE agent SET fname='{0}',lname= '{1}', address= '{2}', daytime_phone = '{3}', fax = '{4}', city = '{5}', state = '{6}', zip_code = '{7}', night_phone = '{8}', mobile_phone = '{9}', company_name = '{10}', web_address= '{11}', description = '{12}'  WHERE agent_id = {13} ";
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.AgentUpdate),
        //           oSeller.FirstName, oSeller.LastName, oSeller.Address1, oSeller.DayTimePhone, oSeller.Fax, oSeller.City, oSeller.State, oSeller.ZipCode, oSeller.NightPhone, oSeller.MobilePhone, oSeller.CompanyName, oSeller.WebAddress, oSeller.AgentID);
        //        this.ExecuteNonQuery(sSql);

        //        if (oSeller.Password.Equals(String.Empty))
        //        {
        //        }
        //        else
        //        {

        //            sSql = string.Format(SqlQueries.GetQuery(Query.UpdateUser), oSeller.Password, oSeller.UserName, 6, oSeller.AgentID);
        //            this.ExecuteNonQuery(sSql);
        //        }



        //        oResult.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in CategoryUpdate()", LogLevel.Error, "Database");
        //        // throw new Exception("Exception occure at CategoryUpdate()", ex);

        //        oResult.IsException = true;

        //        oResult.Message = ex.Message;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return oResult;
        //}


        //public CResult DeleteHouseSeller(CHomeSeller oSeller)
        //{
        //    CResult oResult = new CResult();
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.HomeSellerDelete), oSeller.HomeSellerID);
        //        this.ExecuteNonQuery(sSql);

        //        oResult.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in CategoryDelete()", LogLevel.Error, "Database");
        //        //throw new Exception("Exception occure at CategoryDelete()", ex);

        //        oResult.IsException = true;

        //        oResult.Message = ex.Message;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return oResult;
        //}

        //public CResult GetServiceAgentByID(CServiceAgent oHomeSeller)
        //{
        //    CResult oResult = new CResult();
        //    CServiceAgent oNewHouseSeller = null;
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.GetServiceAgentByID), oHomeSeller.AgentID);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            bool bIsRead = oReader.Read();
        //            if (bIsRead)
        //            {
        //                oNewHouseSeller = ServiceAgentFromReader(oReader);

        //                oNewHouseSeller.AgentID = oHomeSeller.AgentID;

        //                oReader.Close();


        //                sSql = string.Format(SqlQueries.GetQuery(Query.GetUserByID), oHomeSeller.AgentID, 12);
        //                oReader = this.ExecuteReader(sSql);
        //                if (oReader != null)
        //                {
        //                    bIsRead = oReader.Read();
        //                    if (bIsRead)
        //                    {

        //                        if (oReader["user_password"] != DBNull.Value && oReader["user_name"] != DBNull.Value)
        //                        {
        //                            // oNewHouseSeller.Password = oReader["user_password"].ToString();

        //                            oNewHouseSeller.UserName = oReader["user_name"].ToString();

        //                            oResult.Data = oNewHouseSeller;

        //                            oResult.IsSuccess = true;
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in DistrictByShortName()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at DistrictByShortName()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oResult;
        //}

        //private CHomeSeller HouseSellerFromReader(IDataReader oReader)
        //{
        //    CHomeSeller oSeller = new CHomeSeller();
        //    if (oReader["seller_id"] != DBNull.Value)
        //        oSeller.HomeSellerID = Int64.Parse(oReader["seller_id"].ToString());
        //    if (oReader["fname"] != DBNull.Value)
        //        oSeller.FirstName = oReader["fname"].ToString();
        //    if (oReader["lname"] != DBNull.Value)
        //        oSeller.LastName = oReader["lname"].ToString();
        //    if (oReader["address"] != DBNull.Value)
        //        oSeller.Address1 = oReader["address"].ToString();
        //    if (oReader["daytime_phone"] != DBNull.Value)
        //        oSeller.DayTimePhone = oReader["daytime_phone"].ToString();
        //    if (oReader["fax"] != DBNull.Value)
        //        oSeller.Fax = oReader["fax"].ToString();
        //    if (oReader["email"] != DBNull.Value)
        //        oSeller.Email = oReader["email"].ToString();
        //    if (oReader["city"] != DBNull.Value)
        //        oSeller.City = Int32.Parse(oReader["city"].ToString());
        //    if (oReader["state"] != DBNull.Value)
        //        oSeller.State = Int32.Parse(oReader["state"].ToString());
        //    if (oReader["zip_code"] != DBNull.Value)
        //        oSeller.ZipCode = oReader["zip_code"].ToString();
        //    if (oReader["night_phone"] != DBNull.Value)
        //        oSeller.NightPhone = oReader["night_phone"].ToString();
        //    if (oReader["mobile_phone"] != DBNull.Value)
        //        oSeller.MobilePhone = oReader["mobile_phone"].ToString();


        //    if (oReader["register_date"] != DBNull.Value)
        //        oSeller.RegisterDate = (DateTime)oReader["register_date"];

        //    return oSeller;
        //}


    }
}
