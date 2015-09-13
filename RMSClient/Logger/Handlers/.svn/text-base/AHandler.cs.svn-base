using System;
using System.Collections.Generic;
using System.Text;

namespace CellBazaar.Handlers
{
    public abstract class AHandler : IDisposable
    {
        private string m_sAppName = "NoAppNameSpecified";

        public abstract void Open();
        public abstract void Close();
        public abstract void Log(LogEvent oEvent);
        public abstract void Dispose();

        public string AppName
        {
            get { return m_sAppName; }
            set { m_sAppName = value; }
        }

        public abstract string HandlerName {get;}

    }//AHandler
}//ns
