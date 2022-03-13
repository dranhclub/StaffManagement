using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement
{
    static class Program
    {
        public static MyApplicationContext appCtx;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            appCtx = new MyApplicationContext();
            Application.Run(appCtx);
        }
    }
}
