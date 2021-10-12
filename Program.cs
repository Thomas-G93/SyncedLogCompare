using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncedLogCompare
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // ----- TEST -----
            LogHandler logHandler = new LogHandler("C:\\Users\\Thomas\\localgit\\work\\logcompare\\data.test\\logfiles_debug\\");

            logHandler.LoadLogFileEntries("messages.prn");

            // ----------------







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
