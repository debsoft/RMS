using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.DataAccess;

namespace Database
{
   public  class Supplier1DAO:BaseDAO
    {
       public string InsertSupplier(Supplier1 aSuppllier)
       {
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertSupplier1), aSuppllier.SupplierName,
                                              aSuppllier.SupplierInformation);
               this.ExecuteNonQuery(sqlComm);
               return "Supplier1 Insert Successfully";
           }
           catch (Exception)
           {
               return "Please Try Again";
           }
       }

       public List<Supplier1> GetAllSupplier()
       {
           List<Supplier1> aSuppliers=new List<Supplier1>();
           try
           {
               this.OpenConnection();
               string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllSupplier1));
               IDataReader aReader=this.ExecuteReader(sqlComm);
               if(aReader!=null)
               {
                   while(aReader.Read())
                   {
                       Supplier1 aSupplier1=new Supplier1();
                       aSupplier1 = ReadToSupplier(aReader);
                       aSuppliers.Add(aSupplier1);
                   }
               }
           }
           catch (Exception)
           {
               
              
           }
           return aSuppliers;
       }

       private Supplier1 ReadToSupplier(IDataReader aReaderr)
       {
           Supplier1 aSupplier1 = new Supplier1();
           try
           {
               aSupplier1.SupplierId = Convert.ToInt32(aReaderr["supplierId"]);
           }
           catch (Exception)
           {
           }
           try
           {
               aSupplier1.SupplierName = (aReaderr["supplier_name"]).ToString();
           }
           catch (Exception)
           {
           }
           try
           {
               aSupplier1.SupplierInformation = (aReaderr["supplier_information"]).ToString();
           }
           catch (Exception)
           {
           }

           return aSupplier1;
       }
    }
}
