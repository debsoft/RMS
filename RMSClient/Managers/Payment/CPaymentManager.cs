using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Payment
{
    public class CPaymentManager
    {
        private CResult m_oResult;

        public CPaymentManager()
        {
            m_oResult = new CResult();
        }

        public CResult InsertPayment(CPayment inPayment)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                m_oResult.Data = Database.Instance.Payment.InsertPayment(inPayment);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertPayment() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertPayment()", LogLevel.Error, "CPaymentManager");
            }
            return m_oResult;
        }

        public CResult UpdatePayment(CPayment inPayment)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                Database.Instance.Payment.UpdatePayment(inPayment);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdatePayment() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdatePayment()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult UpdateVatStatInPayment(bool stat, Int64 orderID)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                Database.Instance.Payment.UpdatePaymentVatStat(stat,orderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdatePaymentvatstat() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdatePaymentvatstat()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

       
        
        public CResult InsertBillPrintTime(CPayment inPayment)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                Database.Instance.Payment.InsertBillPrintTime(inPayment);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertBillPrintTime() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertBillPrintTime()", LogLevel.Error, "CPaymentManager");
            }
            return m_oResult;
        }

        public CResult DeletePayment(CPayment inPayment)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                Database.Instance.Payment.DeletePayment(inPayment);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Deleted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeletePayment() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeletePayment()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult GetPaymentByOrderID(Int64 inPaymentID)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                m_oResult.Data = Database.Instance.Payment.GetPaymentByOrderID(inPaymentID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetPaymentByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetPaymentByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult GetSortedPayment(DateTime inTime)
        {
            try
            {
                m_oResult.Data = Database.Instance.Payment.GetSortedPayment(inTime);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetSortedPayment() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSortedPayment()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        #region "Log Region"
        public CResult GetPaymentLogDetails(Int64 startTime, Int64 endTime)
        {
            CResult tempPayment = new CResult();
            try
            {

                tempPayment= Database.Instance.Payment.GetPaymentLogDetails(startTime, endTime);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetPaymentByOrderID() : " + ex.Message);
                tempPayment.IsException = true;
                tempPayment.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                tempPayment.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetPaymentByOrderID()", LogLevel.Error, "COrderManager");
            }
            return tempPayment;

        }

        public CPayment SaveDrawerLogs(Int32 terminal_id,string user_id,Int64 dateTime)
        {
            CPayment tempPayment = new CPayment();
            try
            {
                tempPayment = Database.Instance.Payment.SaveDrawerLogs(terminal_id,user_id,dateTime);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetPaymentByOrderID() : " + ex.Message);
                Logger.Write("Exception : " + ex + " in GetPaymentByOrderID()", LogLevel.Error, "COrderManager");
            }
            return tempPayment;
        }

        public CResult GetDrawerLogDetails(Int64 startTime, Int64 endTime)
        {
            CResult tempPayment = new CResult();
            try
            {

                tempPayment = Database.Instance.Payment.GetDrawerLogDetails(startTime, endTime);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetPaymentByOrderID() : " + ex.Message);
                tempPayment.IsException = true;
                tempPayment.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                tempPayment.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetPaymentByOrderID()", LogLevel.Error, "COrderManager");
            }
            return tempPayment;

        }

        #endregion

    }
}
