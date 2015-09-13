using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RMS.Common;
using RMSSvc;
using System.Runtime.Remoting.Channels.Tcp;
using RMS;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            RemotingConfiguration.RegisterWellKnownServiceType(typeof

                           (RmsRemote.CLogin), "RMSSERVER", WellKnownObjectMode.Singleton);

            Console.Write("Sever is  Ready........");

            Console.Read();

        
        }
    }
}