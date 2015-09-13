using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CItemSelectableAttribute
    {
        private int id;

        private int topping_id;

        private string topping_Name;

        private int item_id;

        private int item_Selection_id;

        private bool is_default;

        private bool isPizaatopping;

        private decimal price;

        private decimal tk_price;

        private decimal bar_Price;

        private int selectQnty;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int ToppingID
        {
            get { return topping_id; }
            set { topping_id = value; }
        }

        public string ToppingName
        {
            get { return topping_Name; }
            set { topping_Name = value; }
        }

        public int ItemID
        {
            get { return item_id; }
            set { item_id = value; }
        }

        public int ItemSelectionID
        {
            get { return item_Selection_id; }
            set { item_Selection_id = value; }
        }


        public bool ISDefault
        {
            get { return is_default; }
            set { is_default = value; }
        }


        public bool ISPizzaTopping
        {
            get { return isPizaatopping; }
            set { isPizaatopping = value; }
        }


        public decimal TablePrice
        {
            get { return price; }
            set { price = value; }
        }


        public decimal TKPrice
        {
            get { return tk_price; }
            set { tk_price = value; }
        }


        public decimal BarPrice
        {
            get { return bar_Price; }
            set { bar_Price = value; }

        }
        
        public int SelectQnty
        {
            get { return selectQnty; }
            set { selectQnty  = value; }
        }

    }

}
