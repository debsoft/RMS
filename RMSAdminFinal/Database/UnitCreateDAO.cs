using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
   public  class UnitCreateDAO:BaseDAO
    {
       public string InsertUnit(Unit sr)
       {
           string ret = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertUnit), sr.UnitName);
               this.ExecuteNonQuery(sqlCommand);
               ret = "Unit Insert Sucessfully";
           }
           catch 
           {
               ret = "Please Try Again";
           }
           finally
           {
              this.CloseConnection();
           }
           return ret;

       }

       public List<Unit> GetALLUnit()
       {
           List<Unit> aList=new List<Unit>();
           try
           {
               this.OpenConnection();
               string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetALLUnit));
               IDataReader oReader = this.ExecuteReader(sqlCommand);
               if (oReader != null)
               {
                   while(oReader.Read())
                   {
                       Unit aUnit = new Unit();
                       aUnit.UnitId = Convert.ToInt32(oReader["unit_id"]);
                       aUnit.UnitName = oReader["unit_name"].ToString();
                       aList.Add(aUnit);
                   }

               }
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex + " Try Again");

           }
           finally
           {
               this.CloseConnection();
           }
           return aList;
       }

       public Unit GetUnitByUnitId(int unitId)
       {
           Unit aUnit = new Unit();
           try
           {
               this.OpenConnection();
               string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetUnitByUnitId),unitId);
               IDataReader oReader = this.ExecuteReader(sqlCommand);
               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                      
                       aUnit.UnitId = Convert.ToInt32(oReader["unit_id"]);
                       aUnit.UnitName = oReader["unit_name"].ToString();
                      
                   }

               }
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex + " Try Again");

           }
           finally
           {
               this.CloseConnection();
           }
           return aUnit;
       }
    }
}
