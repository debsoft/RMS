using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RMS.Common.DataAccess;
using RMSClient.DataAccess;


namespace RMS
{
    namespace DataAccess
    {
        public class Database : ADatabase
        {
            private Database()
            {
            }

            public static ADatabase Instance
            {
                get
                {
                    return new Database();
                }
            }


            public override IItemDAO Item
            {
                get { return new CItemDAO(); }
            }

            public override IUserInfoDAO User
            {
                get { return new CUserInfoDAO(); }
            }

            public override IOrderShowDAO OrderShow
            {
                get { return new COrderShowDAO(); }
            }

            public override IOrderInfoDAO OrderInfo
            {
                get { return new COrderInfoDAO(); }
            }

            public override IButtonAccessDAO ButtonAccess
            {
                get { return new CButtonAccessDAO(); }
            }

            public override IButtonColorDAO ButtonColor
            {
                get { return new CButtonColorDAO(); }
            }

            public override IParentCategoryDAO ParentCategory
            {
                get { return new CParentCategoryDAO(); }
            }

            public override ICategory1DAO Category1
            {
                get { return new CCategory1DAO(); }
            }

            public override ICategory2DAO Category2
            {
                get { return new CCategory2DAO(); }
            }

            public override ICategory3DAO Category3
            {
                get { return new CCategory3DAO(); }
            }

            public override IOrderDetailsDAO OrderDetails
            {
                get { return new COrderDetailsDAO(); }
            }

            public override ITableInfoDAO TableInfo
            {
                get { return new CTableInfoDAO(); }
            }

            public override IPaymentDAO Payment
            {
                get { return new CPaymentDAO(); }
            }

            public override ICustomerInfoDAO Customer
            {
                get { return new CCustomerInfoDAO(); }
            }

            public override IPaymentSummaryDAO PaymentSummary
            {
                get { return new CPaymentSummaryDAO(); }
            }

            public override IPaymentSummaryDAO PaymentSummaryForViewReport
            {
                get { return new CPaymentSummaryDAO(); }
            }

            public override IOrderShowDAO OrderListForTransfer
            {
                get { return new COrderShowDAO(); }
            }

            public override ITableInfoDAO AvailableTableForTransfer
            {
                get { return new CTableInfoDAO(); }
            }

            public override IOrderShowDAO AvailableTableForUnlock
            {
                get { return new COrderShowDAO(); }
            }

            public override IOrderShowDAO AvailableTableForVoid
            {
                get { return new COrderShowDAO(); }
            }

            public override IOrderShowDAO UpdateDBForTransfer
            {
                get { return new COrderShowDAO(); }
            }

            public override ITableInfoDAO UpdateDBForUnlock
            {
                get { return new CTableInfoDAO(); }
            }

            public override IOrderShowDAO UpdateDBForVoid
            {
                get { return new COrderShowDAO(); }
            }

            public override IOrderShowDAO UpdateDBForMerge
            {
                get { return new COrderShowDAO(); }
            }

            public override IPcInfoDAO PcInfo
            {
                get { return new CPcInfoDAO(); }
            }
            public override IBookingDAO BookingInfo
            {
                get { return new CBookingDAO(); }
            }
            public override IDepositDAO Deposit
            {
                get { return new CDepositDAO(); }
            }

            public override IDeliveryDAO Delivery
            {
                get { return new CDeliveryDAO(); }
            }


            public override ISystemManagementDAO SaveDefaultTime
            {
                get { return new SysytemManagementDAO(); }
            }

            public override ICustomerInfoDAO ConfiguredTime
            {
                get { return new CCustomerInfoDAO(); }
            }

            public override ICustomerInfoDAO GetCustomerInfoByName
            {
                get { return new CCustomerInfoDAO(); }
            }

            public override IGeneralSettingsDAO GeneralSettings
            {
                get { return new GeneralSettingsDAO(); }
            }

            public override IEFTCardDAO GetEfTcard
            {
                get { return new EftCardDAO(); }
            }
        }//Database
    }//ns
}//ns
