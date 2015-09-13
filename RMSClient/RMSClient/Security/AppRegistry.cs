using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RMSRegistry
{
    public class AppRegistry
    {

        public static void WriteRegistry(RegistryKey parentKey, String subKey, String valueName, Object value)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey, true);
                if (key == null) //If the key doesn't exist.
                    key = parentKey.CreateSubKey(subKey);

                //Set the value.
                key.SetValue(valueName, value);

               
            }
            catch (Exception e)
            {

                MessageBox.Show("Error occured during registering application on the computer");
             
            }
        }

        public static string ReadRegistry(RegistryKey parentKey, String subKey, String valueName)
        {
            RegistryKey key;  

            Object value = null;
            try
            {
                key = parentKey.OpenSubKey(subKey, true);
                if (key == null)
                {

                    return null;
                }

                //Get the value.
                value = key.GetValue(valueName);

               // Console.WriteLine("Value:{0} for {1} is successfully retrieved.", value, valueName);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured during getting register value of application from the computer");
            }

            return value.ToString();
        }
    }
}
