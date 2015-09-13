using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RMS.Common.ObjectModel
{
    public class CPrintQueue
    {
        public static Queue<CPrintingFormat> PrintQueue = null;

        private static object _monitor = new object();

        static CPrintQueue()
        {
            // Debug.WriteLine("Print2");
            lock (_monitor)
            {
                //Debug.WriteLine("Print3");
                if (PrintQueue == null)
                {
                    // Debug.WriteLine("Print4");
                    PrintQueue = new Queue<CPrintingFormat>();
                    // Debug.WriteLine("Print5");
                }
            }
        }

        public static void Init()
        {
            //Debug.WriteLine("Print6");
        }
    }
}
