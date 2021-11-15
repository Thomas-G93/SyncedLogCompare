using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyncedLogCompare.log;

namespace SyncedLogCompare
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new MainWindow());

            if (args.Length > 0)
            {
                Application.Run(new MainWindow(args[0]));
            }
            else
            {
                //DEBUG purpose only
                Application.Run(new MainWindow("C:\\Users\\Thomas\\localgit\\SyncedLogCompare\\test.data\\reduced\\"));
            }



        }
    }
}
