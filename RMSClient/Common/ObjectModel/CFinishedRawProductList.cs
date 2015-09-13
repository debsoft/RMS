using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public class CFinishedRawProductList
    {
        private long id;
        private long finishedProductID;
        private long rawProductID;
        private string rawProductName;
        private double qnty;
        private string remarks;
        public Boolean InsType { set; get; }



       public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public long FinishedProductID
        {
            get { return finishedProductID; }
            set { finishedProductID = value; }
        }

        public long RawProductID
        {
            get { return rawProductID; }
            set { rawProductID = value; }
        }


        public string RawProductName
        {
            get { return rawProductName; }
            set { rawProductName = value; }
        }

        public double Qnty
        {
            get { return qnty; }
            set { qnty = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }


    }
}
