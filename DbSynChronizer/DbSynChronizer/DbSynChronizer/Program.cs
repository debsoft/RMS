using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DbSynChronizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool firstInstance = false;
            string mutexName = "Local\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            Mutex mutex = null;
            try
            {
                // Create a new mutex object with a unique name
                mutex = new Mutex(false, mutexName, out firstInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace +
                     "\n\n" + "Application Exiting...", "Exception thrown");
                Application.Exit();
            }

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SynChronizerManagerForm());
            }

            else
            {
                MessageBox.Show("An instance has already been run!", "Database Synchronizer", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
