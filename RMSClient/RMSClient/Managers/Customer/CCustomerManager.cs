using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Customer
{
    public class CCustomerManager
    {
        private CResult m_oResult;

        public CCustomerManager()
        {
            m_oResult = new CResult();
        }

        public CResult InsertCustomerInfo(CCustomerInfo inCustomerInfo)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                m_oResult.Data = Database.Instance.Customer.InsertCustomerInfo(inCustomerInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertCustomerInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertCustomerInfo()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        public CResult UpdateCustomerInfo(CCustomerInfo inCustomerInfo)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                Database.Instance.Customer.UpdateCustomerInfo(inCustomerInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateCustomerInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateCustomerInfo()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        public CResult DeleteCustomerInfo(CCustomerInfo inCustomerInfo)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                Database.Instance.Customer.DeleteCustomerInfo(inCustomerInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Deleted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteCustomerInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteCustomerInfo()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        public CResult CustomerInfoGetByCustomerID(Int64 inCustomerID)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                m_oResult.Data = Database.Instance.Customer.CustomerInfoGetByCustomerID(inCustomerID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at CustomerInfoGetByCustomerID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByCustomerID()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        public CResult CustomerInfoGetByPhone(String inCustomerPhone)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                m_oResult.Data = Database.Instance.Customer.CustomerInfoGetByPhone(inCustomerPhone);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at CustomerInfoGetByPhone() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByPhone()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }


        public CResult CustomerInfoGetByName(String inCustomerPhone)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                m_oResult.Data = Database.Instance.Customer.CustomerInfoGetByName(inCustomerPhone);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at CustomerInfoGetByPhone() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByPhone()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        #region "Log Area"

        //public CResult GetCustomerLog(Int64 startDateTime, Int64 endDateTime)
        //{
        //    try
        //    {
        //        CCustomerInfo tempCustomerInfo = new CCustomerInfo();

        //        m_oResult.Data = Database.Instance.Customer.GetCustomerLog(startDateTime, endDateTime);
        //        m_oResult.IsSuccess = true;
        //        m_oResult.Message = "Data Read Successfully";

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine("Exception occuer at CustomerInfoGetByPhone() : " + ex.Message);
        //        m_oResult.IsException = true;
        //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

        //        m_oResult.Message = ex.Message;
        //        Logger.Write("Exception : " + ex + " in CustomerInfoGetByPhone()", LogLevel.Error, "CCustomerManager");
        //    }
        //    return m_oResult;
        //}
        #endregion
       
    }
}
