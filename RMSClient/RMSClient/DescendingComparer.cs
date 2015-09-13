using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RMS
{
    internal class DescendingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            try
            {
                return System.Convert.ToInt32(x).CompareTo
                    (System.Convert.ToInt32(y)) * 1;
            }
            catch (Exception ex)
            {
                return x.ToString().CompareTo(y.ToString());
            }
        }
    }
}
