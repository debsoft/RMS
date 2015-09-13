using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RMS
{
    /// <summary>
    /// Abstract log handler class.
    /// Handler implementation classes should derive from this
    /// class.
    /// </summary>
    public abstract class AHandler : IDisposable
    {
        private string m_sAppName = "NoAppNameSpecified";

        /// <summary>
        /// Init the handler, for loading config file etc.
        /// </summary>
        /// <param name="oConfig">The main logger config object</param>
        public abstract void Init(HandlerConfig oConfig);

        /// <summary>
        /// Opens the required handler resources.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Closes the required handler resources.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Perform the actual logging of an event.
        /// </summary>
        /// <param name="oEvent"></param>
        public abstract void Log(LogEvent oEvent);

        /// <summary>
        /// Disposes the log handler object and frees the resources.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Gets or sets the application name used when logging.
        /// </summary>
        public string AppName
        {
            get { return m_sAppName; }
            set { m_sAppName = value; }
        }

        /// <summary>
        /// The name of this handler.
        /// </summary>
        public abstract string HandlerName { get; }


        protected string FixConfigPath(string sConfigFilePath)
        {
            if (Path.IsPathRooted(sConfigFilePath))
                return sConfigFilePath;
            else
                return AppDomain.CurrentDomain.BaseDirectory + "config/" + sConfigFilePath;
        }

    }//AHandler
}//ns
