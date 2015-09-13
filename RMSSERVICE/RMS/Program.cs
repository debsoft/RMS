using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Runtime.Remoting;
//using System.Runtime.Remoting.Channels;
//using System.Runtime.Remoting.Channels.Tcp;

//namespace remoteserver
//{

//    class Program
//    {

//        static void Main(string[] args)
//        {

//            TcpChannel ch = new TcpChannel(8085);

//            ChannelServices.RegisterChannel(ch);

//            RemotingConfiguration.RegisterWellKnownServiceType(typeof

//                           (remoteclass.xx), "RMSSERVER", WellKnownObjectMode.Singleton);

//            Console.Write("Sever is  Ready........");

//            Console.Read();

//        }

//    }

//}

