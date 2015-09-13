using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RMS.DataAccess
{
    public class CUserInfoDAO : BaseDAO, IUserInfoDAO
    {
        public CUserInfoDAO()
        {
        }

        # region IUserInfo members

        public void UserInsert(CUserInfo oUser)
        {
        }

        public void UserUpdate(CUserInfo oUser)
        {
        }

        public void UserDelete(CUserInfo oUser)
        {
        }

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

        public CUserInfo GetUserInfoByUsername(String inUsername)
        {
            CUserInfo oUserInfo = new CUserInfo();
            inUsername = inUsername.Replace("''", "'");
            inUsername = inUsername.Replace("'", "''");
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

        public CResult LoginUser(CUserInfo inCat)
        {
            Debug.WriteLine("process login 3a");
            CResult oResult = new CResult();

            CUserInfo oUser = new CUserInfo();
            try
            {
                this.OpenConnection();

                Debug.WriteLine("process login 3b");
                string sSql = string.Format(SqlQueries.GetQuery(Query.LoginUser), inCat.UserName);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {

                    Debug.WriteLine("process login 3c");
                    if (oReader.Read())
                    {

                        Debug.WriteLine("process login 3d");
                        oUser = ReaderToUserInfo(oReader);

                        if ((!oUser.Password.Equals(String.Empty)) && oUser.Password.Equals(inCat.Password) && oUser.Status != 0)
                        {

                            Debug.WriteLine("process login 3e");
                            oReader.Close();
                            sSql = string.Format(SqlQueries.GetQuery(Query.CheckCurrentUser), inCat.UserName);
                            oReader = this.ExecuteReader(sSql);

                            if (oReader != null)
                            {
                                Debug.WriteLine("process login 3f");
                                if (oReader.Read())
                                {
                                    Debug.WriteLine("process login 3g");
                                    if (oReader["user_id"] != null)
                                    {
                                        Debug.WriteLine("process login 3h");
                                        int iTempInt5 = Int32.Parse(oReader["user_id"].ToString());

                                        oResult.Message = "User already logged in.";
                                    }

                                }

                                else
                                {
                                    Debug.WriteLine("process login 3i");
                                    sSql = string.Format(SqlQueries.GetQuery(Query.DeleteCurrentUser), inCat.UserID);

                                    this.ExecuteNonQuery(sSql);

                                    sSql = string.Format(SqlQueries.GetQuery(Query.AddCurrentUser), inCat.UserID, inCat.PCID);

                                    this.ExecuteNonQuery(sSql);

                                    oResult.Data = oUser;

                                    oResult.IsSuccess = true;
                                }
                            }// if null


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

        public CResult AddUser(CUserInfo inUser)
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
                    string sSql = String.Format(SqlQueries.GetQuery(Query.AddUser), inUser.UserName, inUser.Password, inUser.Type, inUser.Status, inUser.Gender);

                    this.ExecuteNonQuery(sSql);

                    sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                    IDataReader oReader = this.ExecuteReader(sSql);
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

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);

                oResult.Message = "Could not add User. Please try again";

                oResult.IsException = true;
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


                    this.CommitTransection();

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        /*public CResult AddUser(CUserInfo inUser)
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
                    string sSql = String.Format(SqlQueries.GetQuery(Query.AddUser), inUser.UserName, inUser.Password, inUser.Type, inUser.Status, inUser.Gender);

                    this.ExecuteNonQuery(sSql);

                    sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                    IDataReader oReader = this.ExecuteReader(sSql);
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

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemInsert()", ex);

                oResult.Message = "Could not add User. Please try again";

                oResult.IsException = true;
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


                    this.CommitTransection();

                    oResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

                //throw new Exception("Exception occure at ItemDelete()", ex);

                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }*/

        public CResult DeleteUser(CUserInfo inUser)
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

        public CResult GetUser(CUserInfo inCat)
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

        #endregion

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

                //throw new Exception("Exception occure at ItemInsert()", ex);
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

                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
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

        private CUserInfo ReaderToUserInfo(IDataReader oReader)
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
                else
                {
                }
            }
            return oUserAccess;

        }

    }
}
