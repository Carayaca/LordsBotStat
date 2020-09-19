using System;
using System.Windows.Forms;

using NLog;

namespace LordsBotStatView
{
    /// <summary>
    /// The Program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
