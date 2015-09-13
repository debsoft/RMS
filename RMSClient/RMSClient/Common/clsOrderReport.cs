using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common
{
   public class clsOrderReport
    {
       private Int32 m_quantity;
       private string m_itemName;
       private double m_itemPrice;
       private bool m_drinkStatus;
       private int m_oderNumber = 0;
       private string m_foodTypeName = String.Empty;

       private double m_itemUnitPrice;
       public string PrintArea { set; get; }

       public string FoodTypeName
       {
           get { return m_foodTypeName; }
           set { m_foodTypeName = value; }
       }

       public Int32 OrderNumber
       {
           get { return m_oderNumber; }
           set { m_oderNumber = value; }
       }

       public bool DrinkStatus
       {
           get { return m_drinkStatus; }
           set { m_drinkStatus = value; }
       }

       public Int32 Quantity
       {
           get { return m_quantity; }
           set { m_quantity = value; }
       }
       public string ItemName
       {
           get { return m_itemName; }
           set { m_itemName = value; }
       }
       public double Price
       {
           get { return m_itemPrice; }
           set { m_itemPrice = value; }
       }

       public double ItemUnitPrice
       {
           get { return m_itemUnitPrice; }
           set {  m_itemUnitPrice = value; }
       }
    }
}