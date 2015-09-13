using System;
using System.IO;

using System.Collections.Generic;
using System.Text;

using RMS.Common;

namespace RMS
{
    namespace Common
    {
        public class CExceptionHandler
        {


            public CExceptionHandler()
            {

            }


            public void WriteToFile(string in_str)
            {

                try
                {
                    //StreamWriter temp_tw;

                    //CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                    //string temp_file_path = oTempConstant.ERRORLOGPATH;

                    ////string temp_error_str = " error: " + e + " in check_syntax in CSyntaxEngine in syntax";


                    //if (!File.Exists(temp_file_path))
                    //{
                    //    temp_tw = File.CreateText(temp_file_path);
                    //}
                    //else
                    //{
                    //    temp_tw = File.AppendText(temp_file_path);
                    //}

                    //// write a line of text to the file
                    //temp_tw.WriteLine(in_str);

                    //temp_tw.Write(temp_tw.NewLine);

                    //// close the stream
                    //temp_tw.Close();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show("Write log error: " + e);
                    Console.WriteLine("exception in CExceptionHandler.WriteToFile(): " + e1.Message);
                }

            }


        }
    }
}
