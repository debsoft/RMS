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
    public class MembershipCardDao : BaseDAO, IMembershipCardDao
    {

        public RMS.Common.ObjectModel.MembershipCard AddMembershipCard(RMS.Common.ObjectModel.MembershipCard membershipCard)
        {
            MembershipCard tempmembershipCard = membershipCard;

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.AddMembershipCard),
                    membershipCard.code, membershipCard.title, membershipCard.description, membershipCard.name, membershipCard.points, membershipCard.discountPercent, membershipCard.type, membershipCard.startDate.ToString("MM/dd/yyyy"), membershipCard.endDate.ToString("MM/dd/yyyy"), membershipCard.isActive, membershipCard.creationDate.ToString("MM/dd/yyyy"));

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempmembershipCard.id = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }



                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in  AddMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at AddMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCard;
        }

        public RMS.Common.ObjectModel.MembershipCard UpdateMembershipCard(RMS.Common.ObjectModel.MembershipCard membershipCard)
        {
            MembershipCard tempmembershipCard = membershipCard;

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateMembershipCard),
                    membershipCard.code, membershipCard.title, membershipCard.description, membershipCard.name, membershipCard.points, membershipCard.discountPercent, membershipCard.type, membershipCard.startDate.ToString("MM/dd/yyyy"), membershipCard.endDate.ToString("MM/dd/yyyy"), membershipCard.isActive, membershipCard.creationDate.ToString("MM/dd/yyyy"), membershipCard.id);

                this.ExecuteNonQuery(sqlCommand);              
                
                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at UpdateMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCard;
        }

        public bool DeleteMembershipCard(long ID)
        {
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteMembershipCard),  ID);

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

        public List<RMS.Common.ObjectModel.MembershipCard> GetAllMembershipCard()
        {
           List<MembershipCard> tempmembershipCardList = new List<MembershipCard> ();
           MembershipCard tempmembershipCard = new MembershipCard();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetAllMembershipCard));

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {            
                    while (oReader.Read())
                    {
                        tempmembershipCard = ReaderToMembershipCard(oReader);                        
                        tempmembershipCardList.Add(tempmembershipCard);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCardList;
        }

        public RMS.Common.ObjectModel.MembershipCard GetMembershipCardByID(long ID)
        {        
            MembershipCard tempmembershipCard = new MembershipCard();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetMembershipCardByID), ID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembershipCard = ReaderToMembershipCard(oReader);                 
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetMembershipCardByID()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetMembershipCardByID()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCard;
        }


        public List<MembershipCard> GetAllMembershipCardByName(string name)
        {
            List<MembershipCard> tempmembershipCardList = new List<MembershipCard>();
            MembershipCard tempmembershipCard = new MembershipCard();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetAllMembershipCardByName), "%"+name +"%");

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembershipCard = ReaderToMembershipCard(oReader);
                        tempmembershipCardList.Add(tempmembershipCard);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCardList;
        }

        public List<MembershipCard> GetAllMembershipCardByCode(string code)
        {
            List<MembershipCard> tempmembershipCardList = new List<MembershipCard>();
            MembershipCard tempmembershipCard = new MembershipCard();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetAllMembershipCardByCode), code);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempmembershipCard = ReaderToMembershipCard(oReader);
                        tempmembershipCardList.Add(tempmembershipCard);
                    }

                    oReader.Close();
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllMembershipCard()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at GetAllMembershipCard()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return tempmembershipCardList;
        }

        private MembershipCard ReaderToMembershipCard(IDataReader inReader)//new Added
        {
            MembershipCard tempMembershipCard = new MembershipCard();

            if (inReader["code"] != null)
                tempMembershipCard.code = inReader["code"].ToString();

            if (inReader["creationDate"] != null && !inReader["creationDate"].ToString().Equals(""))
                tempMembershipCard.creationDate = DateTime.Parse(inReader["creationDate"].ToString());

            if (inReader["description"] != null)
                tempMembershipCard.description = inReader["description"].ToString();

            if (inReader["discountPercent"] != null)
                tempMembershipCard.discountPercent = Convert.ToDouble(inReader["discountPercent"].ToString());

            if (inReader["endDate"] != null)
                tempMembershipCard.endDate = DateTime.Parse(inReader["endDate"].ToString());

            if (inReader["startDate"] != null)
                tempMembershipCard.startDate = DateTime.Parse(inReader["startDate"].ToString());


            if (inReader["id"] != null)
                tempMembershipCard.id = Convert.ToInt64(inReader["id"].ToString());

            if (inReader["isActive"] != null)
                tempMembershipCard.isActive = Convert.ToBoolean(inReader["isActive"].ToString());

            if (inReader["name"] != null)
                tempMembershipCard.name = Convert.ToString(inReader["name"].ToString());

            if (inReader["points"] != null)
                tempMembershipCard.points = Convert.ToDouble(inReader["points"].ToString());
            
            if (inReader["title"] != null)
                tempMembershipCard.title = inReader["title"].ToString();


            if (inReader["type"] != null)
                tempMembershipCard.type = inReader["type"].ToString();


            return tempMembershipCard;
        }


      
    }
}
