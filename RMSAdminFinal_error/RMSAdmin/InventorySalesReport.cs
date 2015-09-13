using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMSAdmin
{
  public  class InventorySalesReport
    {
      private string m_productName = "";
      private string m_foodTypeName = "";
      private string m_foodBeverageTypeName = "";
      private int m_quantity = 0;
      private double m_amount = 0.0;


      public string ProductName
      {
          get { return m_productName; }
          set { m_productName = value; }
      }

      public string FoodTypeName
      {
          get { return m_foodTypeName; }
          set { m_foodTypeName = value; }
      }

      public string FoodBeverageTypeName
      {
          get { return m_foodBeverageTypeName; }
          set { m_foodBeverageTypeName = value; }
      }


      public int Quantity
      {
          get { return m_quantity; }
          set { m_quantity = value; }
      }

      public double Amount
      {
          get { return m_amount; }
          set { m_amount = value; }
      }

    }
}
