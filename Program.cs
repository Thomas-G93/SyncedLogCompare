using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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


            var path = "";
            foreach (var s in args)
            {
                path += s;
                path += " ";
            }

            path = path.Trim();
            
            Application.Run(args.Length > 0 ? 
                new MainWindow(path) :
                new MainWindow());
        }
    }
}
