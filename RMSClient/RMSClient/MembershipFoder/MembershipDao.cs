using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS;

namespace RMSClient.DataAccess
{
    public class MembershipDao : BaseDAO, IMembershipDao
    {
        public RMS.Common.ObjectModel.Membership AddMembership(RMS.Common.ObjectModel.Membership membership)
        {
            Membership tempmembership = membership;

            try
            {
                Membership tempMembership = GetMembershipByCustomerID(membership.customerID);

                if (tempMembership != null && tempMembership.mebershipCardID>0)
                {
                    throw new Exception("Membership " +  tempMembership.id.ToString() + " already exists");                  
                }

                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.AddMembership),
                    membership.customerID, membership.customerName, membership.customerPhone, membership.membershipCardType, membership.mebershipCardID, membership.membershipCardName, membership.membershipCardTitle, membership.point, membership.discountPercentRate, membership.startDate.ToString("MM/dd/yyyy"), membership.endDate.ToString("MM/dd/yyyy"), membership.issueDate.ToString("MM/dd/yyyy"), membership.isActive, membership.membershipCardCode);

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempmembership.id = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }



                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex.Message + " in AddMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception " + ex.Message + " occured at AddMembership()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }

        public RMS.Common.ObjectModel.Membership UpdateMembership(RMS.Common.ObjectModel.Membership membership)
        {
            Membership tempmembership = membership;

            Membership tempMembership = GetMembershipByCustomerID(membership.customerID);

            if (tempMembership != null && tempMembership.mebershipCardID > 0 && tempMembership.id != membership.id)
            {
                throw new Exception("Membership " + tempMembership.id.ToString() + " already exists");
            }

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateMembership),
                     membership.customerID, membership.customerName, membership.customerPhone, membership.membershipCardType, membership.mebershipCardID, membership.membershipCardName, membership.membershipCardTitle, membership.point, membership.discountPercentRate, membership.startDate.ToString("MM/dd/yyyy"), membership.endDate.ToString("MM/dd/yyyy"), membership.issueDate.ToString("MM/dd/yyyy"), membership.isActive, membership.id);

                this.ExecuteNonQuery(sqlCommand);

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in OrderInfoInsert()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at OrderInfoInsert()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }

        public bool DeleteMembership(long ID)
        {
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteMembership), ID);

                this.ExecuteNonQuery(sqlCommand);

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at DeleteMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return true;
        }

        public List<RMS.Common.ObjectModel.Membership> GetAllMembership()
        {
            List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetAllMembership));

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                        tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipList;
        }

        public RMS.Common.ObjectModel.Membership GetMembershipByID(long ID)
        {
          //  List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipByID), ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                      //  tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }

        #region GetMembershipByCustomerID
        public Membership GetMembershipByCustomerID(long customerID)
        {
            //  List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipByCustomerID), customerID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                        //  tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }
        #endregion


        #region GetMembershipByCustomerPhone
        public Membership GetMembershipByCustomerPhone(string  customerPhone)
        {
            //  List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipByCustomerPhone), customerPhone);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                        //  tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }
        #endregion

        #region GetMembershipByMembershipCardName
        public List<Membership> GetMembershipByMembershipCardName(string membershipCardName)
        {
              List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipBymembershipCardName), "%"+ membershipCardName +"%");

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                          tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipList;
        }
        #endregion

        #region GetMembershipByMembershipCardCode
        public Membership GetMembershipByMembershipCardCode(string membershipCode)
        {
            //  List<Membership> tempmembershipList = new List<Membership>();
            Membership tempmembership = new Membership();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipBymembershipCode), membershipCode);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembership = ReaderToMembership(oReader);
                        //  tempmembershipList.Add(tempmembership);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembership()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembership()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembership;
        }
        #endregion

        #region ReaderToMembership
        private Membership ReaderToMembership(IDataReader inReader)//new Added
        {
       
            Membership tempMembership = new Membership();

            if (inReader["id"] != null)
                tempMembership.id = long.Parse(inReader["id"].ToString());

            if (inReader["customerID"] != null)
                tempMembership.customerID = long.Parse(inReader["customerID"].ToString());

            if (inReader["customerName"] != null)
                tempMembership.customerName = inReader["customerName"].ToString();

            if (inReader["customerPhone"] != null)
                tempMembership.customerPhone = inReader["customerPhone"].ToString();

            if (inReader["membershipCardType"] != null)
                tempMembership.membershipCardType = inReader["membershipCardType"].ToString();

            if (inReader["mebershipCardID"] != null)
                tempMembership.mebershipCardID = long.Parse(inReader["mebershipCardID"].ToString());

            if (inReader["membershipCardName"] != null)
                tempMembership.membershipCardName = inReader["membershipCardName"].ToString();
            
            if (inReader["membershipCardTitle"] != null)
                tempMembership.membershipCardTitle = inReader["membershipCardTitle"].ToString();

            if (inReader["membershipCardCode"] != null)
                tempMembership.membershipCardCode = inReader["membershipCardCode"].ToString();

            if (inReader["point"] != null)
                tempMembership.point = float.Parse(inReader["point"].ToString());

            if (inReader["discountPercentRate"] != null)
                tempMembership.discountPercentRate = float.Parse(inReader["discountPercentRate"].ToString());

            if (inReader["startDate"] != null)
                tempMembership.startDate = DateTime.Parse(inReader["startDate"].ToString());

            if (inReader["endDate"] != null)
                tempMembership.endDate = DateTime.Parse(inReader["endDate"].ToString());

            if (inReader["issueDate"] != null)
                tempMembership.issueDate = DateTime.Parse(inReader["issueDate"].ToString());


            if (inReader["isActvie"] != null)
                tempMembership.isActive = Boolean.Parse(inReader["isActvie"].ToString());
                        
            return tempMembership;
        }
        #endregion

        public DataTable GetMembershipDiscountReport()
        {   
            
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetMembershipDiscountReport));
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);

                dt.Load(objDatareader);

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSalesItemReportWithOrderRange()", LogLevel.Error, "Database");
               
            }
            finally
            {
                this.CloseConnection();
            }
            return dt;
        }

        public DataTable LoadMemberDetailsReport(int memberid)
        {
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.LoadMemberDetailsReport),memberid);
                IDataReader objDatareader = this.ExecuteReader(sqlCommand);

                dt.Load(objDatareader);

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetSalesItemReportWithOrderRange()", LogLevel.Error, "Database");

            }
            finally
            {
                this.CloseConnection();
            }
            return dt;
        }
    }
}
