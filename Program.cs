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

            // ----- TEST DEBUG -----
            LogHandler logHandler = new LogHandler("C:\\Users\\Thomas\\localgit\\work\\logcompare\\data.test\\logfiles_debug\\");

            List<LogEntry> list = new List<LogEntry>();

            list = logHandler.LoadLogFileEntries("messages.prn");

            foreach (var entry in list)
            {
                Console.WriteLine(entry.ToString());
            }

            List<LogEntry> list2 = new List<LogEntry>();
            list2 = logHandler.LoadLogFileEntries("TBTracer.log");
            foreach (var entry in list2)
            {
                Console.WriteLine(entry.ToString());
            }

            // ----------------------







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
