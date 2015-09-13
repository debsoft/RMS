using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.Constants
{
 public  class CUserConstant
    {
        public static string GetUSerConstant(int user)
        {
            switch (user)
            {
                case 0:
                    return "ADMIN";
                case 1:
                    return "USER";
                case 2:
                    return "MANAGEMENT";
                case 3:
                    return "SUPERVISOR";
                case 4:
                    return "FOOD_PREP";
                case 5:
                    return "SALES";
                case 6:
                    return "DELIVERY_DRIVER";
                case 7:
                    return "WAITER";
                default:
                    return "";
            }
        }


        public static int GetUSerConstant(string user)
        {
            switch (user)
            {
                case "ADMIN":
                    return 0;
                case "USER":
                    return 1;
                case "MANAGEMENT":
                    return 2;
                case "SUPERVISOR":
                    return 3;
                case "FOOD_PREP":
                    return 4;
                case "SALES":
                    return 5;
                case "DELIVERY_DRIVER":
                    return 6;
                case "WAITER":
                    return 7;
                default:
                    return -1;
            }
        }
    
    }


}
