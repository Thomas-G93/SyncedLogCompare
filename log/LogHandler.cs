using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncedLogCompare.log;

namespace SyncedLogCompare
{
    class LogHandler
    {
        private readonly string _path;

        public LogHandler(string path)
        {
            this._path = path ?? throw new ArgumentNullException(nameof(path));
        }

        private List<LogEntry> LoadLogFileEntries(LogFile logFile)
        {
            List<LogEntry> list = new List<LogEntry>();


            using (StreamReader sr = File.OpenText(_path + "\\" + logFile.FileName))
            {
                var bufferLine = new StringBuilder();
                string line;

                //TODO - maybe loop and check until first entry has been found with the "Beginning..." method
                sr.ReadLine(); // skip first line -> header -> useless information
                sr.ReadLine(); // skip second line -> empty

                // Read in line by line
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(@"Line: " + line); //DEBUG

                    // Check if current line is a new log entry // Long lines could be split in two or more lines
                    if (BeginningOfEntry(line))
                    {
                        bufferLine = new StringBuilder(line);
                    }
                    else
                    {
                        bufferLine.Append(line);
                        continue; // continue with next ReadLine() before String is split
                    }

                    // Split String based on Separator and amount of Parts (based on FileType). 
                    var splitLine = bufferLine.ToString().Split(logFile.Separator, logFile.Parts, StringSplitOptions.None);

                    
                    list.AddRange(AddLogEntryToList(splitLine, logFile));

                }
            }

            return list;

        }

        //TODO - Completely rewrite.... maybe need new classes for LOG and TRACER?
        private List<LogEntry> AddLogEntryToList(string[] strings, LogFile logFile)
        {
            List<LogEntry> list = new List<LogEntry>();

            if (logFile.Parts == 4) //MESSAGE
            {
                String severity = strings[0].Trim();
                String dateTime = strings[1].Trim();
                String from = strings[2].Trim();
                String message = strings[3].Trim();

                list.Add(new LogEntry(severity, dateTime, from, message, logFile.FileName, logFile.FileType.ToString()));
            }
            else //TBTRACER //TODO - what if we have more types?
            {
                String severity = strings[0].Trim();
                String dateTime = strings[1].Trim();
                String component = strings[2].Trim();
                String device = strings[3].Trim();
                String message = strings[4].Trim();

                list.Add(new LogEntry(severity, dateTime, component, device, message, logFile.FileName, logFile.FileType.ToString()));
            }

            return list;
        }


        private bool BeginningOfEntry(string line)
        {
            return line.StartsWith("(I)") || line.StartsWith("(W)") || line.StartsWith("(E)") || line.StartsWith("(A)");
        }




        public List<LogEntry> LoadLogFiles()
        {
            List<LogEntry> list = new List<LogEntry>();

            var fileList = Directory
                .EnumerateFiles(_path, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);

            foreach (var file in fileList)
            {

                LogFile logFile = new LogFile(file);

                //TODO - with radio Button or Checkbox decide which Message Log File Type should be loaded
                // if (logFile.FileType == FileType.Messages || logFile.FileType == FileType.MessagesBASE || logFile.FileType == FileType.TBTracer)
                if (logFile.FileType == FileType.Messages || logFile.FileType == FileType.TBTracer)
                {
                    //Console.WriteLine(@"file: " + logFile.FileName + @" fileType: " + logFile.FileType);
                    list.AddRange(LoadLogFileEntries(logFile));
                }

            }

            list.Sort(new DateTimeComparerAsc());

            return list;
        }







    }
}
