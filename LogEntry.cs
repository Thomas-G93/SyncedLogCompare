using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedLogCompare
{
    internal enum FileType
    {
        TBTracer,
        Message,
        //TODO - Have an Option for "BASE" Type of Message?
        Unidentified
    }
    class LogEntry
    {
        //TODO - add NULL check in Constructor

        //TODO - split again in two different classes? TBTRACER and MESSAGE

        public LogEntry(string severity, string dateTime, string component, string device, string message, string fileName)
        {
            //TBTRACER
            Severity = severity;
            DateTime = dateTime;
            Component = component;
            Device = device;
            Message = message;
            FileName = fileName;

            //TODO - more elegant way needed, since FileType is "calculated" multiple times in the application
            SetFileType(fileName);
        }

        public LogEntry(string severity, string dateTime, string from, string message, string fileName)
        {
            //MESSAGE
            Severity = severity;
            DateTime = dateTime;
            From = from;
            Message = message;
            FileName = fileName;

            SetFileType(fileName);
        }

        public override string ToString()
        {
            return $"{nameof(Severity)}: {Severity}, {nameof(DateTime)}: {DateTime}, {nameof(Message)}: {Message}, {nameof(From)}: {From}, {nameof(Component)}: {Component}, {nameof(Device)}: {Device}";
        }

        public string Severity { get; }

        public string DateTime { get; }

        public string Message { get; }

        public string From { get; }

        public string Component { get; }

        public string Device { get; }

        public string FileName { get; }

        public FileType FileType { get; }

        private FileType SetFileType(string fileName)
        {
            if (fileName.ToLower().StartsWith("tbtracer"))
            {
                return FileType.TBTracer;
            }
            else if (fileName.ToLower().StartsWith("message"))
            {
                return FileType.Message;
            }
            else
            {
                return FileType.Unidentified;
            }

        }

    }




}
