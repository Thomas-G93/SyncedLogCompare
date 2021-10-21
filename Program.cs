﻿using System;
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
            //TODO - added string[] args -> "handover" to MainCompareWindowForm -> Constructor???

            // ---- DEBUG ----- 

            Console.WriteLine("test start " + DateTime.Now);
            LogHandler logHandler = new LogHandler("C:\\Users\\Thomas\\localgit\\SyncedLogCompare\\test.data\\all\\");

          //  var list = logHandler.LoadLogFiles();

           // foreach (var logEntry in list) { Console.WriteLine(logEntry.ToString()); }

         //   Console.WriteLine(list.Count);

            Console.WriteLine("test end " + DateTime.Now);

            // ------ END DEBUG ------




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainCompareWindowForm());



        }
    }
}
