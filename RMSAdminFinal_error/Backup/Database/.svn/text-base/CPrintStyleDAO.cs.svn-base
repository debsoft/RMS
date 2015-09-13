using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;

namespace RMS.DataAccess
{
    public class CPrintStyleDAO : BaseDAO, IPrintStyleDAO
    {
        #region IPrintStyleDAO Members

        public RMS.Common.ObjectModel.CResult GetPrintStyle(RMS.Common.ObjectModel.CPrintStyle inCat)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetPrintStyle), inCat.StyleID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    if (oReader.Read())
                    {
                        inCat = ReaderToPrintStyle(oReader);

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

        private CPrintStyle ReaderToPrintStyle(IDataReader oReader)
        {
            CPrintStyle oItem = new CPrintStyle();

            if (oReader["style_id"] != null)
                oItem.StyleID = Int32.Parse(oReader["style_id"].ToString());

            if (oReader["header"] != null)
                oItem.Header = oReader["header"].ToString();

            if (oReader["body"] != null)
                oItem.Body = oReader["body"].ToString();

            if (oReader["footer"] != null)
                oItem.Footer = oReader["footer"].ToString();

            //if (oReader["style_name"] != null)
            //    oItem. = oReader["style_name"].ToString();

            return oItem;

        }

        public RMS.Common.ObjectModel.CResult UpdatePrintStyle(RMS.Common.ObjectModel.CPrintStyle inUser)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.UpdatePrintStyle), inUser.Header, inUser.Body, inUser.Footer, inUser.StyleID);

                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                oResult.IsException = true;


                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult AddPrintStyle(CPrintStyle inUser)
        {
            CResult oResult = new CResult();

            try
            {
                inUser.Header = inUser.Header.Replace("''", "'");
                inUser.Header = inUser.Header.Replace("'", "''");

                inUser.Body = inUser.Body.Replace("''", "'");
                inUser.Body = inUser.Body.Replace("'", "''");

                inUser.Footer = inUser.Footer.Replace("''", "'");
                inUser.Footer = inUser.Footer.Replace("'", "''");

                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.AddPrintStyle), inUser.Header, inUser.Body, inUser.Footer);

                this.ExecuteNonQuery(sSql);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");

                oResult.IsException = true;


                //throw new Exception("Exception occure at ItemInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }
        #endregion
    }
}
