using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WH_SALEORDERLOADING
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
         //  args = new string[] { "41179", "WH01" };
            if (args.Length == 0)
            {
                MessageBox.Show("No parameter, cannot open application.");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain(args[0], args[1]));
            }
        }
    }
}
