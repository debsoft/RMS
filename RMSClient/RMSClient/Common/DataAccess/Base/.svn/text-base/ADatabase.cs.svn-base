using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using RMS.Common.Config;
using RMS.DataAccess;

namespace RMS
{
    namespace Common
    {
        namespace DataAccess
        {
            public abstract class ADatabase
            {
                protected string m_sLastError;

                public string LastError
                {
                    get { return m_sLastError; }
                    set { m_sLastError = value; }
                }

              
                public abstract IItemDAO Item { get; }
                public abstract IUserInfoDAO User { get; }
                public abstract IOrderShowDAO OrderShow { get; }
                public abstract IOrderInfoDAO OrderInfo { get; }
                public abstract IButtonAccessDAO ButtonAccess { get; }
                public abstract IButtonColorDAO ButtonColor { get; }
                public abstract IParentCategoryDAO ParentCategory { get; }
                public abstract ICategory1DAO Category1 { get; }
                public abstract ICategory2DAO Category2 { get; }
                public abstract ICategory3DAO Category3 { get; }
                public abstract IOrderDetailsDAO OrderDetails { get; }
                public abstract ITableInfoDAO TableInfo { get; }
                public abstract IPaymentDAO Payment { get; }
                public abstract ICustomerInfoDAO Customer { get; }

                public abstract IPaymentSummaryDAO PaymentSummary { get; }
                public abstract IPaymentSummaryDAO PaymentSummaryForViewReport { get; }
                public abstract IOrderShowDAO OrderListForTransfer { get; }
                public abstract ITableInfoDAO AvailableTableForTransfer { get; }
                public abstract IOrderShowDAO AvailableTableForUnlock { get; }
                public abstract IOrderShowDAO AvailableTableForVoid { get; }
                public abstract IOrderShowDAO UpdateDBForTransfer { get; }
                public abstract ITableInfoDAO UpdateDBForUnlock { get; }
                public abstract IOrderShowDAO UpdateDBForVoid { get; }
                public abstract IOrderShowDAO UpdateDBForMerge { get; }
                public abstract IPcInfoDAO PcInfo { get; }
                public abstract IBookingDAO BookingInfo { get; }
                public abstract IDepositDAO Deposit { get; }
                public abstract IDeliveryDAO Delivery { get; }
                //public abstract IStateDAO State { get; }
    
            }//ADatabase

        }//ns
    }//ns
}//ns
