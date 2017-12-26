using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace IEEECUSB
{
    class var
    {
        public static Controller controllerObj;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // if (Environment.OSVersion.Version.Major == 6)
            // SetProcessDPIAware();
            //seeding s = new seeding();
            var.controllerObj = new Controller();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              
            Application.Run(new WorkshopsManagement());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
