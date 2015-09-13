//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RMS;
using RMS.Common.ObjectModel;
using RmsRemote;
using System.Threading;
using RMS.Common;
using RMSSvc;


namespace ConsoleApplication1
{

    class Program
    {

        
        //protected override void onStop
        //{

        //    try
        //    {
        //        if (m_oPrintThread != null)
        //        {
        //            m_oPrintThread.Abort();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        static void Main(string[] args)
        {
            Thread m_oPrintThread;

            ConfigManager.Init();

            ConfigManager.ReloadConfig();           
           

            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                      

            CPrintThread myThread = new CPrintThread();
            m_oPrintThread = new Thread(new ThreadStart(myThread.run));
            m_oPrintThread.Start();

            TcpChannel ch = new TcpChannel(8085);

            ChannelServices.RegisterChannel(ch);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof (RmsRemote.CLogin), "RMSSERVER", WellKnownObjectMode.Singleton);

            Console.Write("Sever is  Ready........");

            Console.Read();

        }

    }

}

