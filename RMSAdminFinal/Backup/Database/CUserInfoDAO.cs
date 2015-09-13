using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace RMS.DataAccess
{
    public class CUserInfoDAO : BaseDAO, IUserInfoDAO
    {
        public CUserInfoDAO()
        {
        }

        #region IUserInfoDAO Members

        public RMS.Common.ObjectModel.CResult AddUser(RMS.Common.ObjectModel.CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                int iTempInt = 0;

                bool bIsRead = false;

                bool bTempFlag = false;

                bTempFlag = CheckUser(inUser);

                if (bTempFlag)
                {
                    oResult.Message = " User exists with this user name. Please write another name.";
                }

                else
                {
                    inUser.UserName = inUser.UserName.Replace("''", "'");
                    inUser.UserName = inUser.UserName.Replace("'", "''");

                    this.OpenConnection();
                    string sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddUser), inUser.UserName, inUser.Password, inUser.Type, inUser.Status, inUser.Gender);

                    this.ExecuteNonQuery(sqlCommand);

                    sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                    IDataReader oReader = this.ExecuteReader(sqlCommand);
                    if (oReader != null)
                    {
                        bIsRead = oReader.Read();
                        if (bIsRead)
                        {

                            inUser.UserID = Int32.Parse(oReader[0].ToString());
                        }
                        oReader.Close();
                    }


                    if (inUser.UserAccess.OpenDrawer == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "OpenDrawer");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }
                            oReader.Close();
                        }
                    }
                    if (inUser.UserAccess.ReviewTransaction == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ReviewTransaction");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.VoidTable == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "VoidTable");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.ViewReport == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ViewReport");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }


                    if (inUser.UserAccess.TransferTable == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "TransferTable");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }


                    if (inUser.UserAccess.TillReporting == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "TillReporting");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.MergeTable == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "MergeTable");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);

                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.ExitRms == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ExitRMS");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.UnlockTable == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "UnlockTable");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Booking == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Booking");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Users == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Users");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Deposit == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Deposit");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Customers == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Customers");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.UpdateItems == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "UpdateItems");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }
                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.LogRegister == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "LogRegister");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }


                    if (inUser.UserAccess.SystemSettings == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "SystemSettings");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.RmsAdminAccess == 1)
                    {
                        sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "RmsAdminAccess");

                        oReader = this.ExecuteReader(sqlCommand);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sqlCommand);
                                }
                            }

                            oReader.Close();
                        }
                    }
                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                oResult.Message = "Could not add User. Please try again";

                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public RMS.Common.ObjectModel.CResult DeleteUser(RMS.Common.ObjectModel.CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                //this.OpenConnection();

                this.OpenConnectionWithTransection();

                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteUser), inUser.UserID);
                this.ExecuteNonQuery(sSql);

                sSql = string.Format(SqlQueries.GetQuery(Query.DeleteAllButtonAccess), inUser.UserID);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;

                this.CommitTransection();
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                oResult.IsException = true;

                this.RollBackTransection();

            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public RMS.Common.ObjectModel.CResult GetUser(RMS.Common.ObjectModel.CUserInfo inCat)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.getUserByID), inCat.UserID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        inCat = ReaderToUserInfo(oReader);

                        oResult.Data = inCat;

                        oResult.IsSuccess = true;
                    }
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
                else if (sTempStr.Equals("SystemSettings"))
                {

                    oUserAccess.SystemSettings = 1;
                }

                else if (sTempStr.Equals("RmsAdminAccess"))
                {

                    oUserAccess.RmsAdminAccess = 1;
                }
            }

            return oUserAccess;
        }

        private CUserInfo ReaderToUser(IDataReader oReader)
        {
            CUserInfo oUser = new CUserInfo();

            if (oReader["user_id"] != null)
                oUser.UserID = int.Parse(oReader["user_id"].ToString());

            if (oReader["user_name"] != null)
                oUser.UserName = oReader["user_name"].ToString();

            if (oReader["password"] != null)
                oUser.Password = oReader["password"].ToString();

            if (oReader["type"] != null)
                oUser.Type = int.Parse(oReader["type"].ToString());

            if (oReader["status"] != null)
                oUser.Status = int.Parse(oReader["status"].ToString());

            if (oReader["gender"] != null)
                oUser.Gender = oReader["gender"].ToString();


            return oUser;

        }

        public RMS.Common.ObjectModel.CResult GetUserAccess(RMS.Common.ObjectModel.CUserInfo inCat)
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

        public RMS.Common.ObjectModel.CUserInfo GetUserInfoByUsername(string inUsername)
        {
            CUserInfo oUserInfo = new CUserInfo();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.UserInfoByUsername), inUsername);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oUserInfo = ReaderToUser(oReader);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllUser()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllUser()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllUser()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oUserInfo;
        }

        private bool CheckUser(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupUser), inUser.UserName);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["user_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["user_id"].ToString());

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        private bool CheckUserForUpdate(CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CheckDupUserForUpdate), inUser.UserName, inUser.UserID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        if (oReader["user_id"] != null)
                        {
                            int iTemp = Int32.Parse(oReader["user_id"].ToString());

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }

        public RMS.Common.ObjectModel.CResult LoginAdminUser(RMS.Common.ObjectModel.CUserInfo inCat)
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

        public RMS.Common.ObjectModel.CResult LoginUser(RMS.Common.ObjectModel.CUserInfo inCat)
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

                            oResult.Data = oUser;

                            oResult.IsSuccess = true;
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

        public RMS.Common.ObjectModel.CResult LogoutUser(RMS.Common.ObjectModel.CUserInfo inUser)
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

        public RMS.Common.ObjectModel.CResult UnlockUser(RMS.Common.ObjectModel.CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();

                string sSql = string.Format(SqlQueries.GetQuery(Query.UnlockUser), inUser.UserID);
                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;


            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                oResult.IsException = true;

                this.RollBackTransection();

            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        public RMS.Common.ObjectModel.CResult UpdateUser(RMS.Common.ObjectModel.CUserInfo inUser)
        {
            CResult oResult = new CResult();

            try
            {
                bool bTempFlag = false;

                bool bIsRead = false;

                IDataReader oReader = null;

                int iTempInt = 0;

                bTempFlag = CheckUserForUpdate(inUser);

                if (bTempFlag)
                {
                    oResult.Message = " User exists with this user name. Please write another name.";
                }

                else
                {
                    //this.OpenConnection();

                    inUser.UserName = inUser.UserName.Replace("''", "'");
                    inUser.UserName = inUser.UserName.Replace("'", "''");

                    this.OpenConnectionWithTransection();

                    string sSql = string.Format(SqlQueries.GetQuery(Query.UpdateUser), inUser.UserName, inUser.Password, inUser.Type, inUser.Status, inUser.Gender, inUser.UserID);
                    this.ExecuteNonQuery(sSql);

                    sSql = String.Format(SqlQueries.GetQuery(Query.DeleteAllButtonAccess), inUser.UserID);

                    this.ExecuteNonQuery(sSql);

                    if (inUser.UserAccess.OpenDrawer == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "OpenDrawer");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }
                            oReader.Close();
                        }

                    }


                    if (inUser.UserAccess.ReviewTransaction == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ReviewTransaction");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.VoidTable == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "VoidTable");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.ViewReport == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ViewReport");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }


                    if (inUser.UserAccess.TransferTable == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "TransferTable");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }


                    if (inUser.UserAccess.TillReporting == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "TillReporting");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.MergeTable == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "MergeTable");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.ExitRms == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "ExitRMS");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }


                    if (inUser.UserAccess.UnlockTable == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "UnlockTable");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);



                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.Booking == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Booking");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }

                    }

                    if (inUser.UserAccess.Users == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Users");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {
                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Deposit == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Deposit");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {
                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.Customers == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "Customers");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {
                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);
                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.UpdateItems == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "UpdateItems");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }


                    //Added By Baruri at 07/08/2008

                    if (inUser.UserAccess.RemoveItems == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "RemoveItems");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.LogRegister == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "LogRegister");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.SystemSettings == 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "SystemSettings");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }

                    if (inUser.UserAccess.RmsAdminAccess== 1)
                    {
                        sSql = String.Format(SqlQueries.GetQuery(Query.GetButtonIDByName), "RmsAdminAccess");

                        oReader = this.ExecuteReader(sSql);
                        if (oReader != null)
                        {

                            bIsRead = oReader.Read();
                            if (bIsRead)
                            {

                                if (oReader["button_id"] != null)
                                {
                                    iTempInt = Int32.Parse(oReader["button_id"].ToString());
                                    oReader.Close();

                                    sSql = String.Format(SqlQueries.GetQuery(Query.AddButtonAccess), inUser.UserID, iTempInt);

                                    this.ExecuteNonQuery(sSql);
                                }
                            }

                            oReader.Close();
                        }
                    }





                    this.CommitTransection();

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");
                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        #endregion

        #region IUserInfoDAO Members


        public List<CUserInfo> GetAllUser()
        {
            List<CUserInfo> oUserList = new List<CUserInfo>();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.UserInfoGetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CUserInfo oUser = ReaderToUser(oReader);
                        oUserList.Add(oUser);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetAllUser()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllUser()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllUser()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oUserList;
        }

        #endregion
    }
}
