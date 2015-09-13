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

            public override IUserInfoDAO UserInfo
            {
                get { return new CUserInfoDAO(); }
            }

            public override IParentCategoryDAO ParentCat
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

            public override ICategory4DAO Category4
            {
                get { return new CCategory4DAO(); }
            }

           
            public override IButtonColorDAO ButtonColor
            {
                get { return new CButtonColorDAO(); }
            }

            public override IPrintStyleDAO PrintStyle
            {
                get { return new CPrintStyleDAO(); }
            }

            public override IOrderInfoDAO OrderInfo
            {
                get { return new COrderInfoDAO(); }
            }  
            


            

        }//Database
    }//ns
}//ns
