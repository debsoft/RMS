using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;

namespace SoftwareLocker
{
  public  static class SystemInfo
    {
        #region -> Private Variables

        public static bool UseProcessorID;
        public static bool UseBaseBoardProduct;
        public static bool UseBaseBoardManufacturer;
        public static bool UseDiskDriveSignature;
        public static bool UseVideoControllerCaption;
        public static bool UsePhysicalMediaSerialNumber;
        public static bool UseBiosVersion;
        public static bool UseBiosManufacturer;
        public static bool UseWindowsSerialNumber;
        public static bool UseMacAddress;
        public static bool UseCurrentDateTime;
        public static bool UseSerialNumber;


        #endregion

      public static string GetSystemInfo(string SoftwareName)
        {
            //if(UseProcessorID == true)
            //    SoftwareName += RunQuery("Processor", "ProcessorId");

            //if (UseBaseBoardProduct == true)
            //    SoftwareName += RunQuery("BaseBoard", "Product");

            //if (UseBaseBoardManufacturer == true)
            //    SoftwareName += RunQuery("BaseBoard", "Manufacturer");

            //if (UseDiskDriveSignature == true)
            //    SoftwareName += RunQuery("DiskDrive", "Signature");

            //if (UseVideoControllerCaption == true)
            //    SoftwareName += RunQuery("VideoController", "Caption");

            //if (UsePhysicalMediaSerialNumber == true)
            //    SoftwareName += RunQuery("PhysicalMedia", "SerialNumber");

            //if (UseBiosVersion == true)
            //    SoftwareName += RunQuery("BIOS", "Version");

            //if (UseWindowsSerialNumber == true)
            //    SoftwareName += RunQuery("OperatingSystem", "SerialNumber");


            //New 
            //string SoftwareName = "";
            if (UseSerialNumber == true)
            {
              SoftwareName += "AGT3JU6YDHR65SGB39UFBHRNT"; //Client Take the serial number
               // SoftwareName += "HTT4UPOAGTJUR5398DHTSNH5S";//Admin
            }
            if (UseMacAddress == true)
                SoftwareName +=GetMacAddress();//Collect the mac address of the current pc

            if (UseCurrentDateTime == true)//Take current datetime.
            {
                DateTime currentDateTime=DateTime.Now;
                currentDateTime=new DateTime(currentDateTime.Year,currentDateTime.Month,currentDateTime.Day,currentDateTime.Hour,currentDateTime.Minute,0);
                Int64 dtValue=currentDateTime.Ticks;
                SoftwareName += dtValue.ToString();
            }

            SoftwareName = RemoveUseLess(SoftwareName);

            if (SoftwareName.Length < 25)
            {
                //when used for RMS Client then name(RMSClient) of the client is used.
                //in a word the name of the product 
                return GetSystemInfo("RMSCustomer");//Here rms client
            }

            return SoftwareName.Substring(0, 25).ToUpper();
        }

        private static  string GetMacAddress()
        {
            string macAddress = "";
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            macAddress = addr[0].ToString();
            return macAddress;
        }


        private static string RemoveUseLess(string st)
        {
            char ch;
            for (int i = st.Length - 1; i >= 0; i--)
            {
                ch = char.ToUpper(st[i]);
                
                if ((ch < 'A' || ch > 'Z') &&
                    (ch < '0' || ch > '9'))
                {
                    st = st.Remove(i, 1);
                }
            }
            return st;
        }

        private static string RunQuery(string TableName, string MethodName)
        {
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * from Win32_" + TableName);
            foreach (ManagementObject MO in MOS.Get())
            {
                try
                {
                    return MO[MethodName].ToString();
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
            return "";
        }
    }
}
