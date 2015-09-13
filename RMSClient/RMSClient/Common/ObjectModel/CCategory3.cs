
/*
 * File name: CButtonAccess.cs 
 * Author: Md. Zahidur Rahman
 *   
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 *                     1/4/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CCategory3
    {
        private int m_iCategory3ID;
        private String m_sCategory3Name;
        private int m_iCategory2ID;
        private String m_sCategory3Description;
        private double m_dTablePrice;
        private double m_dTakeAwayPrice;
        private double m_dBarPrice;
        private int m_iOrderStatus;
        private int m_iCategory3Order;        
        private int m_iViewTable;
        private int m_iViewBar;
        private int m_iViewTakeAway;

        public CCategory3()
        {
            m_iCategory3ID = 0;
            m_sCategory3Name = String.Empty;
            m_iCategory2ID = 0;
            m_sCategory3Description = String.Empty;
            m_dTablePrice = 0;
            m_dTakeAwayPrice = 0;
            m_dBarPrice = 0;
            m_iOrderStatus = 0;
            m_iCategory3Order = 0;                     
            m_iViewTable = 0;
            m_iViewBar = 0;
            m_iViewTakeAway = 0;
        }

        public int Category3ID
        {
            get { return m_iCategory3ID; }
            set { m_iCategory3ID = value; }
        }

        public String Category3Name
        {
            get { return m_sCategory3Name; }
            set { m_sCategory3Name = value; }
        }

        public int Category2ID
        {
            get { return m_iCategory2ID; }
            set { m_iCategory2ID = value; }
        }

        public String Category3Description
        {
            get { return m_sCategory3Description; }
            set { m_sCategory3Description = value; }
        }

        public double Category3TablePrice
        {
            get { return m_dTablePrice; }
            set { m_dTablePrice = value; }
        }

        public double Category3TakeAwayPrice
        {
            get { return m_dTakeAwayPrice; }
            set { m_dTakeAwayPrice = value; }
        }

        public double Category3BarPrice
        {
            get { return m_dBarPrice; }
            set { m_dBarPrice = value; }
        }

        public int Category3OrderStatus
        {
            get { return m_iOrderStatus; }
            set { m_iOrderStatus = value; }
        }

        public int Category3Order
        {
            get { return m_iCategory3Order; }
            set { m_iCategory3Order = value; }
        }

        public int Category3ViewTable
        {
            get { return m_iViewTable; }
            set { m_iViewTable = value; }
        }

        public int Category3ViewBar
        {
            get { return m_iViewBar; }
            set { m_iViewBar = value; }
        }

        public int Category3ViewTakeAway
        {
            get { return m_iViewTakeAway; }
            set { m_iViewTakeAway = value; }
        }
    }
}
