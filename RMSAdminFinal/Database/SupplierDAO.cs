using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using RMS;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
    public class SupplierDAO : BaseDAO
    {
       public string InsertSupplier(Supplier aSupplier)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertSupplier), aSupplier.Name,
                                                 aSupplier.ContactInformation);
               this.ExecuteNonQuery(sqlCommand);
               sr = "Supplier Create Successfully";

           }
           catch
           {

               sr = "Please Check Your Input";
           }
           finally
           {
               this.CloseConnection();
           }

           return sr;
       }

        public List<Supplier> GetAllSupplier()
        {
            List<Supplier>aList=new List<Supplier>();
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetAllSupplier));
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if(aReader!=null)
                {
                    while(aReader.Read())
                    {
                        Supplier aSupplier=new Supplier();
                        aSupplier = ReaderToSupplier(aReader);
                        aList.Add(aSupplier);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + " Oooops........Please Check Your input:()");
            }
            finally
            {
                this.CloseConnection();
            }
            return aList;
        }

        private Supplier ReaderToSupplier(IDataReader aReader)
        {
            Supplier aSupplier=new Supplier();
            try
            {
                aSupplier.SupplierId = Convert.ToInt32(aReader["supplier_id"]);
            }
            catch 
            {              
                
            }
            try
            {
                aSupplier.Name = aReader["supplier_name"].ToString();
            }
            catch
            {

            }
            try
            {
                aSupplier.TotalAmount = Convert.ToDouble(aReader["suppler_amount"]);
            }
            catch
            {

            }
            try
            {
                aSupplier.PaidAmount = Convert.ToDouble(aReader["paid_amount"]);
            }
            catch
            {

            }
            try
            {
                aSupplier.ContactInformation = (aReader["contact_information"]).ToString();
            }
            catch
            {

            }

            if (aSupplier.PaidAmount > aSupplier.TotalAmount)
            {
                aSupplier.AdvanceAmount = aSupplier.PaidAmount - aSupplier.TotalAmount;
            }
            else aSupplier.AdvanceAmount = 0.0;
            if (aSupplier.PaidAmount < aSupplier.TotalAmount)
            {
                aSupplier.DueAmount = aSupplier.TotalAmount - aSupplier.PaidAmount;
            }
            else aSupplier.DueAmount = 0.0;
            return aSupplier;
        }

        public void UpdateSupplierForPurchase(Supplier aSupplier)
        {
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateSupplierForPurchase),aSupplier.TotalAmount
                    ,aSupplier.PaidAmount,aSupplier.SupplierId);
                this.ExecuteNonQuery(sqlComm);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ooops " + ex);
            }

            finally
            {
                this.CloseConnection();


            }
        }

        public Supplier GetSupplierByid(int toInt32)
        {
            Supplier aSupplier=new Supplier();
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetSupplierByid), toInt32);
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                       
                        aSupplier = ReaderToSupplier(aReader);
                      
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("GetSupplierByid()",ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return aSupplier;
        }

        public void InsertIntosupplier_payment_reportForSupplierPaymentTrack(Supplier aSupplier)
        {
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertIntosupplier_payment_reportForSupplierPaymentTrack),
                    aSupplier.SupplierId,aSupplier.TotalAmount,aSupplier.PaidAmount,aSupplier.PaymentType,DateTime.Now,RMSGlobal.LogInUserName);
                this.ExecuteNonQuery(sqlComm);

            }
            catch (Exception ex)
            {

                throw new Exception("InsertIntosupplier_payment_reportForSupplierPaymentTrack()",ex);
            }
            finally
            {
                this.CloseConnection();
            }

        }
    }
}
