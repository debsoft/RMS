using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    /// <summary>
    /// Created at 13/08/2008
    /// </summary>
    public static class RMSGlobal
    {
        public const string MessageBoxTitle = "RMS Administration";

        public static string LogInUserName = String.Empty;


        public static Int64 GetCurrentDateTime()
        {
            Int64 loginDateTime = 0;
            DateTime dt = DateTime.Now;
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            loginDateTime = dt.Ticks;
            return loginDateTime;
        }
    }
}
