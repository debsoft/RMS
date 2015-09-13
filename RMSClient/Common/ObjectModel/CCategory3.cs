
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
        private string m_sellingIn;

        private int m_Maximum_attributes;
        private int m_Selectable_attributes;
        private int m_IncludedPrice;
        private int m_defaultCount;



        private double m_retailPrice = 0;
        private double m_wholeSalePrice = 0;
        private double m_LastPurchasePrice = 0;

        private int m_unitsInStock = 0;
        private int m_reorderLevel = 0;
        private int m_QTYPerSaleUint = 0;
        private int m_QTYPerPurchaseUnit = 0;
        private string m_StandardUoM = "";
        private string m_SalesUoM = "";
        private string m_PurchaseUoM = "";
        private bool m_NonStockable = true;


        private bool m_NonTaxableGood = false;

        private string m_barCode = "";


        private int m_initialQuantity;
        private int m_unlimitStatus;
        private int m_itemSoldIn;

        private Int64 m_iRank;

        private string m_productType;

        private int m_supplierId = 0;
        private bool m_vatIncluded = true;
        public double TableCost { set; get; }
        public double TakeAwayCost { set; get; }
        public double BarCost { set; get; }


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
            m_sellingIn = String.Empty;
        }

        public string ItemSellingIn
        {
            get { return m_sellingIn; }
            set { m_sellingIn = value; }
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

        ///////////////////////new/////

        public int MItemSoldIn
        {
            get { return m_itemSoldIn; }
            set { m_itemSoldIn = value; }
        }

        public int MUnlimitStatus
        {
            get { return m_unlimitStatus; }
            set { m_unlimitStatus = value; }
        }

        public int MInitialQuantity
        {
            get { return m_initialQuantity; }
            set { m_initialQuantity = value; }
        }


        public long MIRank
        {
            get { return m_iRank; }
            set { m_iRank = value; }
        }


        public int MSupplierId
        {
            get { return m_supplierId; }
            set { m_supplierId = value; }
        }

        public bool MVatIncluded
        {
            get { return m_vatIncluded; }
            set { m_vatIncluded = value; }
        }

        public string MProductType
        {
            get { return m_productType; }
            set { m_productType = value; }
        }

        public string MBarCode
        {
            get { return m_barCode; }
            set { m_barCode = value; }
        }

        public bool MNonTaxableGood
        {
            get { return m_NonTaxableGood; }
            set { m_NonTaxableGood = value; }
        }

        public bool MNonStockable
        {
            get { return m_NonStockable; }
            set { m_NonStockable = value; }
        }

        public string MPurchaseUoM
        {
            get { return m_PurchaseUoM; }
            set { m_PurchaseUoM = value; }
        }

        public string MSalesUoM
        {
            get { return m_SalesUoM; }
            set { m_SalesUoM = value; }
        }

        public string MStandardUoM
        {
            get { return m_StandardUoM; }
            set { m_StandardUoM = value; }
        }

        public int MQtyPerPurchaseUnit
        {
            get { return m_QTYPerPurchaseUnit; }
            set { m_QTYPerPurchaseUnit = value; }
        }

        public int MQtyPerSaleUint
        {
            get { return m_QTYPerSaleUint; }
            set { m_QTYPerSaleUint = value; }
        }

        public int MReorderLevel
        {
            get { return m_reorderLevel; }
            set { m_reorderLevel = value; }
        }

        public int MUnitsInStock
        {
            get { return m_unitsInStock; }
            set { m_unitsInStock = value; }
        }
        public int Category3MaximumAttributes
        {
            get { return m_Maximum_attributes; }
            set { m_Maximum_attributes = value; }
        }
        public int Category3SelectableAttributes
        {
            get { return m_Selectable_attributes; }
            set { m_Selectable_attributes = value; }
        }

        public int IncludedPrice
        {
            get { return m_IncludedPrice; }
            set { m_IncludedPrice = value; }
        }

        public int DefaultCount
        {
            get { return m_defaultCount; }
            set { m_defaultCount = value; }
        }
        public double VatRate { set; get; }
    }
}
