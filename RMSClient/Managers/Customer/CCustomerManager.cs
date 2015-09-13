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

        /// <summary>
        /// This function collects the customer information taken from online
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns></returns>

        public CResult GetOnlineCustomerInfoByOrderID(Int64 p_orderID)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                m_oResult.Data = Database.Instance.Customer.GetCustomerTakeawayInfo(p_orderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetOnlineCustomerInfoByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetOnlineCustomerInfoByOrderID()", LogLevel.Error, "CCustomerManager");
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

        /// <summary>
        /// This function returns all the customer list according to filter criteria
        /// </summary>
        /// <param name="inCustomerPhone"></param>
        /// <returns></returns>

        public CResult GetCustomerInfoByName(String inCustomerPhone)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();

                m_oResult.Data = Database.Instance.Customer.GetCustomerInfoByName(inCustomerPhone);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at CustomerInfoGetByPhone() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByPhone()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }


        /// <summary>
        /// Added by Baruri .This function is used for collecting customer address details information from CSV
        /// </summary>
        /// <param name="p_houseNumber"></param>
        /// <param name="p_postCode"></param>
        /// <returns></returns>
        public CResult GetCustomerAddressDetailsInfo(string p_houseNumber,string p_postCode)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                m_oResult.Data = Database.Instance.Customer.GetCustomerAddressDetailsInfo( p_houseNumber, p_postCode);
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

        /// <summary>
        /// This function returns all the addresses of the selected criteria
        /// </summary>
        /// <param name="p_houseNumber"></param>
        /// <param name="p_postCode"></param>
        /// <returns></returns>
        public CResult GetCustomerAddressInfo(string p_houseNumber, string p_postCode)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                m_oResult.Data = Database.Instance.Customer.GetCustomerAddresses(p_houseNumber, p_postCode);
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

        /// <summary>
        /// This function returns the customer's takeaway information.
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns></returns>
        public CResult GetCustomerTakeawayInfo(Int64 p_orderID)
        {
            try
            {
                CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                m_oResult.Data = Database.Instance.Customer.GetCustomerTakeawayInfo(p_orderID);
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

        /// <summary>
        /// Collecting the log record of the order 
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns></returns>
        public CResult GetOrderLogInformation(Int64 p_orderID)
        {
            try
            {
                OrderLogInformation tempOrderLogInfo = new OrderLogInformation();
                m_oResult= Database.Instance.OrderInfo.GetOrderLogInformation(p_orderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetOrderLogInformation() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetOrderLogInformation()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Online order log information of the selected order.
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns></returns>
        public CResult GetOnlineOrderLogInformation(Int64 p_orderID)
        {
            try
            {
                OrderLogInformation tempOrderLogInfo = new OrderLogInformation();
                m_oResult= Database.Instance.OrderInfo.GetOnlineOrderLogInformation(p_orderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetOrderLogInformation() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetOrderLogInformation()", LogLevel.Error, "CCustomerManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Collecting the configuration time for take away and delivery orders
        /// </summary>
        /// <returns></returns>
        public CResult CollectConfiguredTime()
        {
            try
            {
                m_oResult.Data = Database.Instance.Customer.ConfiguredTime();
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Failed to collect configured time for take away and delivery orders: " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

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
