using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCI_PARTFORECAST
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //args = new string[] { "40777", "CX10" };
            if (args.Length == 0)
            {
                MessageBox.Show("No parameter, cannot open application.");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Home(args[0], args[1]));
            }
        }
    }
}
