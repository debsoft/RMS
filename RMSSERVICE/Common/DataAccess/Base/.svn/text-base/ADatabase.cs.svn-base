using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using RMS.Common.Config;

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
                public abstract IUserInfoDAO UserInfo { get; }
                public abstract IParentCategoryDAO ParentCat { get; }
                public abstract ICategory1DAO Category1 { get; }
                public abstract IButtonColorDAO ButtonColor { get; }
                public abstract IPrintStyleDAO PrintStyle { get; }

                public abstract ICategory2DAO Category2 { get; }

                public abstract ICategory3DAO Category3 { get; }

                public abstract ICategory4DAO Category4 { get; }

                public abstract IOrderInfoDAO OrderInfo { get; }

               

            }//ADatabase

        }//ns
    }//ns
}//ns
