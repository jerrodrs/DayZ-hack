using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Reflection;

namespace dayz_toolkit
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gameOverlay overlay = new gameOverlay();
            IntPtr hProcess = memoryFunctions.findDayzProcess();
            if (hProcess == IntPtr.Zero)
            {
                overlay.setConsoleText("Dayz Client not found.");
            }
            else
            {
                overlay.setConsoleText("Dayz Client found, read success.");
            }
            overlay.TopMost = true;
            overlay.Show();

            Application.Run(overlay);
        }
    }
}
