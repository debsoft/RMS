using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class EFTCard
    {
        int id = 0;

       
       string cardName = "";

       
       public EFTCard()
       {

       }

        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
