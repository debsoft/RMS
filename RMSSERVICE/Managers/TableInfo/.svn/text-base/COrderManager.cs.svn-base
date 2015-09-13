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

            public CResult OrderInfoByOrderID(Int64 inOrderID)
            {
                try
                {
                    m_oResult.Data= Database.Instance.OrderInfo.GetOrderInfoByOrderID(inOrderID);
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

            
        }
    
}
