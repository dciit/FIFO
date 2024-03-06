using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WH_OBSOLETEREPORT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[] { "41219", "FIFO" };
            //args = new string[] { "41218", "OBSOLETE" };


            if (args.Length == 0)
            {
                MessageBox.Show("No parameter, cannot open application.");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (args[1] == "FIFO")
                {
                    Application.Run(new FrmFIFO(args[0], args[1]));

                } else if (args[1] == "OBSOLETE") {

                    Application.Run(new FrmMain(args[0], args[1]));
                }
                
            }
        }
    }
}
