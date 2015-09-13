using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    /// <summary>
    /// This class describes the order details. 
    /// </summary>
    public class COrderDetails
    {
        private Int64 m_bOrderDetailsID;
        private Int64 m_bOrderID;
        private Int64 m_bProductID;
        private int m_iQuantity;
        private double m_dAmount;
        private String m_sRemarks;
        private String m_sFoodType;
        private int m_iCatLevel;
        private string m_itemName;
        private string product_Name;
        private Int64 m_rank;
        private Int64 m_categoryID;
        private Int64 m_onlineItemSequenceNumber;
        private string m_tableName = String.Empty;
        private string m_columnName = String.Empty;
        private Int64 m_CustomerId = 0;
        private Int32 m_printedQuantity = 0;
        private double m_unitPrice = 0;
        private Int64 m_item_order_time = 0;
        private int m_iUserID;
        private double m_vatTotal;
        private double m_amount_with_vat;
       private string m_Product_Type;
        private string m_UOM;
        private int m_guestPrintQuantity;
        private int m_kitchen_quantity;

        public COrderDetails()
        {
            m_bOrderDetailsID = 0;
            m_bOrderID = 0;
            m_bProductID = 0;
            m_iQuantity = 0;
            m_dAmount = 0;
            m_sRemarks = string.Empty;
            m_sFoodType = string.Empty;
            m_iCatLevel = 0;
            m_itemName = string.Empty;
            m_rank = 0;
            m_categoryID = 0;
            m_onlineItemSequenceNumber = 0;
            m_tableName = String.Empty;
            m_columnName = String.Empty;
            m_CustomerId = 0;
            m_printedQuantity = 0;
            m_unitPrice = 0;
            m_item_order_time = 0;
            m_iUserID = 0;
            m_vatTotal=0;
            m_amount_with_vat=0;
            m_Product_Type=String.Empty;
            m_UOM=String.Empty;
            GuestPrintQuantity = 0;
            KitchenQuantity = 0;

        }

        public Int64  ItemOrderTime
        {
            get { return m_item_order_time; }
            set { m_item_order_time = value; }
        }

        public double UnitPrice
        {
            get { return m_unitPrice; }
            set { m_unitPrice = value; }
        }

        public Int32 PrintedQuantity
        {
            get { return m_printedQuantity; }
            set { m_printedQuantity = value; }
        }


        public Int64 CustomerID
        {
            get { return m_CustomerId; }
            set { m_CustomerId = value; }
        }

        public string TableColumnName
        {
            get { return m_columnName; }
            set { m_columnName = value; }
        }

        public string TableName
        {
            get { return m_tableName; }
            set { m_tableName = value; }
        }

        public Int64 OnlineItemSequenceNumber
        {
            get { return m_onlineItemSequenceNumber; }
            set { m_onlineItemSequenceNumber = value; }
        }

        public Int64 CategoryID
        {
            get { return m_categoryID; }
            set { m_categoryID = value; }
        }

        public string ItemName
        {
            get { return m_itemName; }
            set { m_itemName = value; }
        }

        public Int64 Rank
        {
            get { return m_rank; }
            set { m_rank = value; }
        }


        public Int64 OrderDetailsID
        {
            get { return m_bOrderDetailsID; }
            set { m_bOrderDetailsID = value; }
        }

        public Int64 ProductID
        {
            get { return m_bProductID; }
            set { m_bProductID = value; }
        }

        public Int64 OrderID
        {
            get { return m_bOrderID; }
            set { m_bOrderID = value; }
        }

        public int OrderQuantity
        {
            get { return m_iQuantity; }
            set { m_iQuantity = value; }
        }

        public double OrderAmount
        {
            get { return m_dAmount; }
            set { m_dAmount = value; }
        }

        public String OrderRemarks
        {
            get { return m_sRemarks; }
            set { m_sRemarks = value; }
        }

        public String OrderFoodType
        {
            get { return m_sFoodType; }
            set { m_sFoodType = value; }
        }

        public int CategoryLevel
        {
            get { return m_iCatLevel; }
            set { m_iCatLevel = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }
        public double VatTotal
        {
            get { return m_vatTotal; }
            set { m_vatTotal = value; }
        }
        public double Amount_with_vat
        {
            get { return m_amount_with_vat; }
            set { m_amount_with_vat = value; }
        }

        public string Product_Name
        {
            get { return product_Name; }
            set { product_Name = value; }
        }

        public string UOM
        {

            get { return m_UOM; }
            set {m_UOM = value; }
        }

        public string Product_Type {


            get { return m_Product_Type; }
            set { m_Product_Type=value;}
        }

        public int GuestPrintQuantity
        {
            get { return m_guestPrintQuantity; }
            set { m_guestPrintQuantity = value; }
        }

        public double DiscountAmount { set; get; }

        public int KitchenQuantity
        {
            get { return m_kitchen_quantity; }
            set { m_kitchen_quantity = value; }
        }
    }
}
