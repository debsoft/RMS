using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CParentCategory
    {

        private int m_iParentCatID;
        private String m_sParentCatName;
        private int m_synchronization_status;
        private bool m_online_status;
        //private int m_iOrder;


        public CParentCategory()
        {
            m_iParentCatID = 0;
            m_sParentCatName = String.Empty;
            m_synchronization_status = 0;
            m_online_status = false;
            //m_iOrder = 0;

        }


        public int ItemSynchronizationStatus
        {
            get { return m_synchronization_status; }
            set { m_synchronization_status = value; }
        }


        public bool ItemOnlineStatus
        {
            get { return m_online_status; }
            set { m_online_status = value; }
        }

        public int ParentCatID
        {
            get { return m_iParentCatID; }
            set { m_iParentCatID = value; }
        }


        public String ParentCatName
        {
            get { return m_sParentCatName; }
            set { m_sParentCatName = value; }
        }

    }
}
