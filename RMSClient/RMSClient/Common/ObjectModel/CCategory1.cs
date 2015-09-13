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
    public class CCategory1
    {
        private int m_iCategory1ID;
        private String m_sCategory1Name;
        private int m_iCategory1Order;
        private int m_sCategory1ParentID;

        public CCategory1()
		{
            m_iCategory1ID = 0;
            m_sCategory1Name = String.Empty;
            m_iCategory1Order = 0;
            m_sCategory1ParentID = 0;
		}

        public int Category1ID
		{
            get { return m_iCategory1ID; }
            set { m_iCategory1ID = value; }
		}

        public String Category1Name
		{
            get { return m_sCategory1Name; }
            set { m_sCategory1Name = value; }
		}

        public int Category1Order
        {
            get { return m_iCategory1Order; }
            set { m_iCategory1Order = value; }
        }

        public int Category1ParentID
		{
            get { return m_sCategory1ParentID; }
            set { m_sCategory1ParentID = value; }
		} 
    }
}
