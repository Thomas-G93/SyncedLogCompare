using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedLogCompare
{
    class LogHandler
    {
        private String path;

        public LogHandler(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }


        //TODO - Change to "private" when tests are completed
        public List<LogEntry> LoadLogFileEntries(String fileName)
        {
            List<LogEntry> list = new List<LogEntry>();

            

            using (StreamReader sr = File.OpenText(path + "\\" + fileName))
            {
                // for split of array
                char[] separator = { ';' };

                //TODO - check how this can be more generic - since this is basically check for the FileType, no point of making this "calculation" twice...
                var parts = fileName.ToLower().StartsWith("tbtracer") ? 5 : 4;


                StringBuilder bufferLine = new StringBuilder();

                string line = String.Empty;

                sr.ReadLine(); // skip first line - useless information
                sr.ReadLine(); // skip second line - empty

                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(@"Line: " + line); //DEBUG

                    // Check if current line is a new log entry
                    if (BeginningOfEntry(line))
                    {
                        bufferLine = new StringBuilder(line);
                    }
                    else
                    {
                        bufferLine.Append(line);
                        continue; // continue with next ReadLine() before String is split
                    }


                    String[] splitLine = bufferLine.ToString().Split(separator, parts, StringSplitOptions.None);


                    /* 
                    foreach (var item in splitLine) // DEBUG
                    {
                        Console.Write(item.ToString() + " | ");   
                    }
                    Console.WriteLine();
                    */
                    
                    //TODO - move to private method

                    if (parts == 4) //MESSAGE
                    {
                        String severity = splitLine[0].Trim();
                        String dateTime = splitLine[1].Trim();
                        String from = splitLine[2].Trim();
                        String message = splitLine[3].Trim();

                        list.Add(new LogEntry(severity, dateTime, from, message, fileName));
                    }
                    else //TBTRACER //TODO - what if we have more types?
                    {
                        String severity = splitLine[0].Trim();
                        String dateTime = splitLine[1].Trim();
                        String component = splitLine[2].Trim();
                        String device = splitLine[3].Trim();
                        String message = splitLine[4].Trim();

                        list.Add(new LogEntry(severity, dateTime, component, device, message, fileName));

                    }

                }
            }



            return list;


        }

        private Boolean BeginningOfEntry(String line)
        {
            return line.StartsWith("(I)") || line.StartsWith("(W)") || line.StartsWith("(E)") || line.StartsWith("(A)");
        }



    }
}
