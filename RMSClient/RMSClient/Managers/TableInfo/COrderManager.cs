using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS;

namespace Managers.TableInfo
{

    public class COrderManager
    {
        private CResult m_oResult;

        public COrderManager()
        {
            m_oResult = new CResult();
        }

        public CResult GetBookingInfoAll(DateTime inCurrentDate)
        {
            try
            {
                m_oResult = Database.Instance.BookingInfo.GetBookingInfoAll(inCurrentDate);
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetBookingInfoAll() : " + ex.Message);
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetBookingInfoAll()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult GetBookingInfoByID(Int64 inBookingID)
        {
            try
            {
                m_oResult = Database.Instance.BookingInfo.GetBookingInfoByID(inBookingID);
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetBookingInfoAll() : " + ex.Message);
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetBookingInfoAll()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult InsertBookingInfo(CBooking inBookingInfo)
        {
            try
            {
                m_oResult = Database.Instance.BookingInfo.InsertBookingInfo(inBookingInfo);
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListShowByStatus() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListShowByStatus()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult deleteBookingInfo(Int64 inBookingID)
        {
            try
            {
                m_oResult = Database.Instance.BookingInfo.DeleteBookingInfo(inBookingID);
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListShowByStatus() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListShowByStatus()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult updateBookingInfo(CBooking inBookingInfo)
        {
            try
            {
                m_oResult = Database.Instance.BookingInfo.UpdateBookingInfo(inBookingInfo);
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at updateBookingInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in updateBookingInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult OrderListShowByStatus(String inStatus)
        {
            try
            {
                List<COrderShow> oOrderList = Database.Instance.OrderShow.OrderListShowByStatus(inStatus);
                m_oResult.Data = oOrderList;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListShowByStatus() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListShowByStatus()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult InsertOrderInfo(COrderInfo inOrderInfo)
        {
            try
            {
                COrderInfo tempOrderInfo = new COrderInfo();

                m_oResult.Data = Database.Instance.OrderInfo.OrderInfoInsert(inOrderInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult UpdateOrderInfo(COrderInfo inOrderInfo)
        {
            try
            {
                Database.Instance.OrderInfo.OrderInfoUpdate(inOrderInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateOrderInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateOrderInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult DeleteOrderInfo(Int64 inOrderID)
        {
            try
            {
                Database.Instance.OrderInfo.DeleteOrderInfo(inOrderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Deleted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteOrderInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteOrderInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult OrderInfoByOrderID(Int64 inOrderID)
        {
            try
            {
                m_oResult.Data = Database.Instance.OrderInfo.GetOrderInfoByOrderID(inOrderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderInfoByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderInfoByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult OrderInfoArchiveByOrderID(Int64 inOrderID) //new Added
        {
            try
            {
                //m_oResult.Data = Database.Instance.OrderInfo.GetOrderInfoArchiveByOrderID(inOrderID);
                m_oResult = Database.Instance.OrderInfo.GetOrderInfoArchiveByOrderID(inOrderID);
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderInfoByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderInfoByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        #region "Log Register"

        public CResult GetOrderdetails(Int64 startTime, Int64 endTime)
        {
            try
            {
                m_oResult = Database.Instance.OrderInfo.GetOrderdetails(startTime, endTime);
                m_oResult.Message = "Data Read Successful";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderInfoByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderInfoByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        #endregion


        public CResult InsertOrderDetails(COrderDetails inOrderDetails)
        {
            try
            {
                COrderDetails tempOrderDetails = new COrderDetails();

                tempOrderDetails = Database.Instance.OrderDetails.OrderDetailsInsert(inOrderDetails);
                m_oResult.IsSuccess = true;
                m_oResult.Data = tempOrderDetails;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderDetails() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderDetails()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult UpdateOrderDetails(COrderDetails inOrderDetails)
        {
            try
            {
                COrderDetails tempOrderDetails = new COrderDetails();

                tempOrderDetails = inOrderDetails;

                Database.Instance.OrderDetails.OrderDetailsUpdate(inOrderDetails);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateOrderDetails() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateOrderDetails()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult DeleteOrderDetails(Int64 inOrderDetailsID)
        {
            try
            {
                COrderDetails tempOrderDetails = new COrderDetails();



                Database.Instance.OrderDetails.OrderDetailsDelete(inOrderDetailsID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Deleted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteOrderDetails() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteOrderDetails()", LogLevel.Error, "COrderDetailsManager");
            }
            return m_oResult;
        }

        public CResult OrderDetailsByOrderID(Int64 inOrderID)
        {
            try
            {
                //List<COrderDetails> oOrderDetailsList = Database.Instance.OrderDetails.OrderDetailsGetByOrderID(inOrderID);
                m_oResult = Database.Instance.OrderDetails.OrderDetailsGetByOrderID(inOrderID);
                //m_oResult.Data = oOrderDetailsList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrdeDetailsByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrdeDetailsByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult OrderDetailsArchiveByOrderID(Int64 inOrderID) //new Added
        {
            try
            {
                //List<COrderDetails> oOrderDetailsList = Database.Instance.OrderDetails.OrderDetailsArchiveGetByOrderID(inOrderID);
                m_oResult = Database.Instance.OrderDetails.OrderDetailsArchiveGetByOrderID(inOrderID);
                //m_oResult.Data = oOrderDetailsList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrdeDetailsByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrdeDetailsByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult OrderDetailsByOrderDetailID(Int64 inOrderDetailID)
        {
            try
            {
                COrderDetails oOrderDetails = Database.Instance.OrderDetails.OrderDetailsGetByOrderDetailID(inOrderDetailID);
                m_oResult.Data = oOrderDetails;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderDetailsByOrderDetailID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderDetailsByOrderDetailID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult UpdateTableInfo(CTableInfo inTableInfo)
        {
            try
            {
                CTableInfo tempTableInfo = new CTableInfo();

                tempTableInfo = inTableInfo;

                Database.Instance.TableInfo.UpdateTableInfo(inTableInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateTableInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateTableInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult InsertTableInfo(CTableInfo inTableInfo)
        {
            try
            {
                CTableInfo tempTableInfo = new CTableInfo();

                tempTableInfo = inTableInfo;

                Database.Instance.TableInfo.InsertTableInfo(inTableInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertTableInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertTableInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult GetTableInfoByTableNumber(int inTableNumber, string inTableType)
        {
            try
            {
                m_oResult.Data = Database.Instance.TableInfo.TableInfoGetByTableNumber(inTableNumber, inTableType);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetTableInfoByTableNumber() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetTableInfoByTableNumber()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult InsertOrderSeatTime(COrderSeatTime inOrderSeatTime)
        {
            try
            {
                Database.Instance.OrderInfo.InsertOrderSeatTime(inOrderSeatTime);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderSeatTime() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderSeatTime()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult OrderSeatTimeByOrderID(Int64 inOrderID)
        {
            try
            {
                m_oResult.Data = Database.Instance.OrderInfo.OrderSeatTimeByOrderID(inOrderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderSeatTimeByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderSeatTimeByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult UpdateForTransferTable(String inOldTableOrderID, int inOldTableNumber, int inNewTableNumber, int inOldTableGuestCount)
        {
            try
            {
                Database.Instance.UpdateDBForTransfer.UpdateDBForTransfer(inOldTableOrderID, inOldTableNumber, inNewTableNumber, inOldTableGuestCount);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data update Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateForTransferTable() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateForTransferTable()", LogLevel.Error, "COrderInfoManager");
            }
            return m_oResult;
        }

        public CResult UpdateForUnlockTable(int inTableNumber, String inTableType)
        {
            try
            {
                Database.Instance.UpdateDBForUnlock.UpdateDBForUnlock(inTableNumber, inTableType);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data update Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateForUnlockTable() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateForUnlockTable()", LogLevel.Error, "COrderInfoManager");
            }
            return m_oResult;
        }

        public CResult UpdateForVoidTable(String inOrderID, int inTableNumber, String inTableType, bool inReportTableVoid)
        {
            try
            {
                Database.Instance.UpdateDBForVoid.UpdateDBForVoid(inOrderID, inTableNumber, inTableType, inReportTableVoid);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data update Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateForVoidTable() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateForVoidTable()", LogLevel.Error, "COrderInfoManager");
            }
            return m_oResult;
        }

        public CResult UpdateForMergeTable(String[] inOrderID, String inMasterOrderID, int[] inTableNumber, int inMasterTableNumber, int inTotalGuestCount)
        {
            try
            {
                Database.Instance.UpdateDBForMerge.UpdateDBForMerge(inOrderID, inMasterOrderID, inTableNumber, inMasterTableNumber, inTotalGuestCount);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data update Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateForMergeTable() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateForMergeTable()", LogLevel.Error, "COrderInfoManager");
            }
            return m_oResult;
        }

        public CResult OrderListForTransfer(bool inMergeTable)
        {
            try
            {
                //definition of OrderListForTransfer() in IOrdershowDAO is changed

                //List<CTransferOrderShow> oOrderList = Database.Instance.OrderListForTransfer.OrderListForTransfer(inMergeTable);
                m_oResult = Database.Instance.OrderListForTransfer.OrderListForTransfer(inMergeTable);
                //m_oResult.Data = oOrderList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListForTransfer() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListForTransfer()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult AvailableTableForTransfer()
        {
            try
            {
                //List<CTableInfo> oTableList = Database.Instance.AvailableTableForTransfer.AvailableTableForTransfer();
                m_oResult = Database.Instance.AvailableTableForTransfer.AvailableTableForTransfer();
                //m_oResult.Data = oTableList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListForTransfer() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListForTransfer()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult GetTableNumberList(string TableType)
        {
            try
            {
                m_oResult.Data = Database.Instance.TableInfo.GetTableNumberList(TableType);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successfully";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at GetMaxTableNumber() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetMaxTableNumber()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult AvailableTableForUnlock()
        {
            try
            {
                //List<CTransferOrderShow> oTableList = Database.Instance.AvailableTableForUnlock.AvailableTableForUnlock();
                m_oResult = Database.Instance.AvailableTableForUnlock.AvailableTableForUnlock();
                //m_oResult.Data = oTableList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListForUnlock() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListForUnlock()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult AvailableTableForVoid()
        {
            try
            {
                //List<CTransferOrderShow> oTableList = Database.Instance.AvailableTableForVoid.AvailableTableForVoid();
                m_oResult = Database.Instance.AvailableTableForVoid.AvailableTableForVoid();
                //m_oResult.Data = oTableList;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderListForVoid() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderListForVoid()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult InsertOrderArchive(COrderInfo inOrderInfo)
        {
            try
            {
                m_oResult = Database.Instance.OrderInfo.InsertOrderArchive(inOrderInfo);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderArchive() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderArchive()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult InsertOrderDetailsArchive(COrderInfo inOrderInfo)
        {
            try
            {
                m_oResult = Database.Instance.OrderInfo.InsertOrderDetailsArchive(inOrderInfo.OrderID);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderDetailsArchive() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderDetailsArchive()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult DeleteTableInfo(int inTableNumber, string inTableType)
        {
            try
            {
                Database.Instance.TableInfo.DeleteTableInfo(inTableNumber, inTableType);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data deleted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at DeleteTableInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in DeleteTableInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult InsertDeliveryInfo(CDelivery inDelivery)
        {
            try
            {

                Database.Instance.Delivery.InsertDelivery(inDelivery);
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertDeliveryInfo() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertDeliveryInfo()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;
        }

        public CResult InsertOrderDiscount(COrderDiscount inOrderDiscount)
        {
            try
            {

                m_oResult = Database.Instance.OrderInfo.InsertOrderDiscount(inOrderDiscount);
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderDiscount() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderDiscount()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult UpdateOrderDiscount(COrderDiscount inOrderDiscount)
        {
            try
            {

                m_oResult = Database.Instance.OrderInfo.UpdateOrderDiscount(inOrderDiscount);
                m_oResult.Message = "Data Updated Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at UpdateOrderDiscount() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in UpdateOrderDiscount()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult OrderDiscountGetByOrderID(Int64 inOrderID)
        {
            try
            {

                m_oResult = Database.Instance.OrderInfo.GetOrderDiscountByOrderID(inOrderID);
                m_oResult.Message = "Data Read Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at OrderDiscountGetByOrderID() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in OrderDiscountGetByOrderID()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

        public CResult InsertOrderVoucher(COrderVoucher inOrderVoucher)
        {
            try
            {

                m_oResult = Database.Instance.OrderInfo.InsertOrderVoucher(inOrderVoucher);
                m_oResult.Message = "Data Inserted Successfully";

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at InsertOrderVoucher() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                //m_oResult.SetParams(ex.Message);

                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in InsertOrderVoucher()", LogLevel.Error, "COrderManager");
            }
            return m_oResult;

        }

    }

}
