using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS;
using System.Data;
using RMS.Common;

using System.Data.SqlClient;
using RMS.Common.Config;


namespace RMS.DataAccess
{
    public class CItemSelectableAttributeDAO : BaseDAO, IItemSelectableAttributeDAO
    {

        public CResult DeleteItemSelectableAttributeByID(int ID)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
               // string sqlCommand = String.Format(SqlQueries.GetQuery(Query.DeleteItemSelectableAttribute), ID);

              //  this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in Delete in CItemSelectableAttribute class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }

            return objResult;
        }

        public CResult AddItemSelectableAttribute(CItemSelectableAttribute inUser)
        {
            CResult res = new CResult();

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();
            String tempConnStr = oTempDal.ConnectionString;
            SqlConnection conn = new SqlConnection(tempConnStr);
            try
            {
                SqlCommand command = new SqlCommand("ISP_item_selectable_attributes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@topping_id", SqlDbType.Int).Value = inUser.ToppingID;
                command.Parameters.Add("@item_selection_id", SqlDbType.Int).Value = inUser.ItemSelectionID;
                command.Parameters.Add("@price", SqlDbType.Decimal).Value = inUser.TablePrice;
                command.Parameters.Add("@item_id", SqlDbType.Int).Value = inUser.ItemID;
                command.Parameters.Add("@is_default", SqlDbType.Bit).Value = inUser.ISDefault;
                command.Parameters.Add("@topping_name", SqlDbType.VarChar).Value = inUser.ToppingName;
                command.Parameters.Add("@IsPizzaTopping", SqlDbType.Bit).Value = false;
                command.Parameters.Add("@tk_price", SqlDbType.Decimal).Value = inUser.TKPrice;
                command.Parameters.Add("@bar_price", SqlDbType.Decimal).Value = inUser.BarPrice;


                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int result = command.ExecuteNonQuery();

                res.IsSuccess = true;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;

                //   MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return res;
        }

        public CResult UpdateItemSelectableAttribute(CItemSelectableAttribute theData)
        {
            CResult objResult = new CResult();

            try
            {
                this.OpenConnection();
             //   string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateItemSelectableAttribute), theData.ToppingID, theData.ItemSelectionID, theData.TablePrice, theData.ItemID, theData.ISDefault, theData.ToppingName, theData.ISPizzaTopping, theData.TKPrice, theData.BarPrice, theData.ID);

              //  this.ExecuteNonQuery(sqlCommand);

                objResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        public CItemSelectableAttribute GetItemSelectableAttribute(CItemSelectableAttribute inCat)
        {
            throw new NotImplementedException();
        }

        public CItemSelectableAttribute GetItemSelectableAttributeByID(int itemSelectableAttributeID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// isCat4ID is false for search Category3ID or true for Category4ID
        /// </summary>
        /// <param name="cat4ID"></param>
        /// <param name="isCat4ID"></param>
        /// <returns></returns>
        public List<CItemSelectableAttribute> GetGlobalSelectableAttributeByCategory4ID(int cat4ID, bool isCat4ID)
        {
            string sqlCommand = "";
            if (isCat4ID)
            {
                sqlCommand = "SET DateFormat MDY;  select *from item_selectable_attributes where item_selection_id = " + cat4ID;//@Salim
            }
            else
            {
                sqlCommand = "SET DateFormat MDY;  select *from item_selectable_attributes where item_id = " + cat4ID;//@Salim

            }
            List<CItemSelectableAttribute> itemSelectableAttributeList = new List<CItemSelectableAttribute>();

            CItemSelectableAttribute itemSelectableAttribute = new CItemSelectableAttribute();

            try
            {
                this.OpenConnection();

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        itemSelectableAttribute = new CItemSelectableAttribute();

                        itemSelectableAttribute = ReaderToGlobalAttribute(oReader);

                        itemSelectableAttributeList.Add(itemSelectableAttribute);
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

            return itemSelectableAttributeList;
        }

        public List<CItemSelectableAttribute> GetAllItemSelectableAttribute()
        {
            string sqlCommand = "";

            sqlCommand = "SET DateFormat MDY;  select *from item_selectable_attributes ";
           

            List<CItemSelectableAttribute> itemSelectableAttributeList = new List<CItemSelectableAttribute>();

            CItemSelectableAttribute itemSelectableAttribute = new CItemSelectableAttribute();

            try
            {
                this.OpenConnection();

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        itemSelectableAttribute = new CItemSelectableAttribute();

                        itemSelectableAttribute = ReaderToGlobalAttribute(oReader);

                        itemSelectableAttributeList.Add(itemSelectableAttribute);
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

            return itemSelectableAttributeList;
        }

        public CItemSelectableAttribute GetGlobalSelectableAttributeByCategory4IDAndByToppingID(int cat4ID, int toppingID, bool isCat4ID)
        {
            //string sqlCommand = "";
            //if (isCat4ID)
            //{
            //    sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetItemSelectableAttributeIDByItemSelectionIDAndByToppingID), cat4ID, toppingID);

            //    //   sqlCommand = "SET DateFormat MDY;  select *from item_selectable_attributes where item_selection_id = " + cat4ID + " and topping_id = " + toppingID;//
            //}
            //else
            //{
            //    sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetItemSelectableAttributeIDByItemIDAndByToppingID), cat4ID, toppingID);

            //    //                sqlCommand = "SET DateFormat MDY;  select *from item_selectable_attributes where item_id = " + cat4ID + " and topping_id = " + toppingID; //

            //}

            //GetItemSelectableAttributeIDByItemSelectionIDAndByToppingID
            CItemSelectableAttribute itemSelectableAttribute = new CItemSelectableAttribute();

            try
            {
                this.OpenConnection();

                //IDataReader oReader = this.ExecuteReader(sqlCommand);
                //if (oReader != null)
                //{
                //    if (oReader.Read())
                //    {
                //        itemSelectableAttribute = ReaderToGlobalAttribute(oReader);

                //    }
                //}
                //else
                //{
                //    itemSelectableAttribute = null;
                //}

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ItemInsert() in CUserInfoDAO class", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }

            return itemSelectableAttribute;
        }


        private CItemSelectableAttribute ReaderToGlobalAttribute(IDataReader p_objReader)
        {
            CItemSelectableAttribute itemSelectAbleAttribute = new CItemSelectableAttribute();


            if (p_objReader["id"] != null)
                itemSelectAbleAttribute.ID = Int32.Parse(p_objReader["id"].ToString());

            if (p_objReader["topping_id"] != null)
                itemSelectAbleAttribute.ToppingID = Convert.ToInt16(p_objReader["topping_id"].ToString());

            if (p_objReader["topping_name"] != null)
                itemSelectAbleAttribute.ToppingName = p_objReader["topping_name"].ToString();

            if (p_objReader["item_id"] != null)
                itemSelectAbleAttribute.ItemID = Convert.ToInt16(p_objReader["item_id"].ToString());

            if (p_objReader["item_selection_id"] != null)
                itemSelectAbleAttribute.ItemSelectionID = Convert.ToInt16(p_objReader["item_selection_id"].ToString());

            if (p_objReader["is_default"] != null)
                itemSelectAbleAttribute.ISDefault = Convert.ToBoolean(p_objReader["is_default"].ToString());

            if (p_objReader["IsPizzaTopping"] != null)
                itemSelectAbleAttribute.ISPizzaTopping = Convert.ToBoolean(p_objReader["IsPizzaTopping"].ToString());

            if (p_objReader["price"] != null)
                itemSelectAbleAttribute.TablePrice = Convert.ToDecimal(p_objReader["price"].ToString());

            if (p_objReader["tk_price"] != null)
                itemSelectAbleAttribute.TKPrice = Convert.ToDecimal(p_objReader["tk_price"].ToString());

            if (p_objReader["bar_price"] != null)
                itemSelectAbleAttribute.BarPrice = Convert.ToDecimal(p_objReader["bar_price"].ToString());


            return itemSelectAbleAttribute;

        }



    }
}
