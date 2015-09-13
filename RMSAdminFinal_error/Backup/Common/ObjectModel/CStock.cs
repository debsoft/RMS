using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CStock
    {

        private int m_iStockID;
        private int m_iCategoryID;
        private int m_iCategoryLevel;
        private double m_dQuantity;
        private String m_sUnit;


        public CStock()
        {
            m_iStockID = 0;
            m_iCategoryID = 0;
            m_iCategoryLevel = 0;
            m_dQuantity = 0;
            m_sUnit = String.Empty;

        }


        public int StockID
        {
            get { return m_iStockID; }
            set { m_iStockID = value; }
        }


        public int CategoryID
        {
            get { return m_iCategoryID; }
            set { m_iCategoryID = value; }
        }


        public int CategoryLevel
        {
            get { return m_iCategoryLevel; }
            set { m_iCategoryLevel = value; }
        }

        public double Quantity
        {
            get { return m_dQuantity; }
            set { m_dQuantity = value; }
        }

        public String Unit
        {
            get { return m_sUnit; }
            set { m_sUnit = value; }
        }



    }
}
