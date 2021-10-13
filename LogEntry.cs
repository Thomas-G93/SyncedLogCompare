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
        private String _severity;
        private String _dateTime;
        private String _message;

        private String _from;        //only message log

        private String _component;   //only tracer
        private String _device;      //only tracer

        private String _fileName;
        private FileType _fileType;


        //TODO - add NULL check in Constructor

        public LogEntry(string severity, string dateTime, string component, string device, string message, string fileName)
        {
            //TBTRACER
            _severity = severity;
            _dateTime = dateTime;
            _component = component;
            _device = device;
            _message = message;
            _fileName = fileName;

            //TODO - more elegant way needed, since FileType is "calculated" multiple times in the application
            SetFileType(fileName);
        }

        public LogEntry(string severity, string dateTime, string from, string message, string fileName)
        {
            //MESSAGE
            _severity = severity;
            _dateTime = dateTime;
            _from = from;
            _message = message;
            _fileName = fileName;

            SetFileType(fileName);
        }


        public override string ToString()
        {
            return $"{nameof(Severity)}: {Severity}, {nameof(DateTime)}: {DateTime}, {nameof(Message)}: {Message}, {nameof(From)}: {From}, {nameof(Component)}: {Component}, {nameof(Device)}: {Device}";
        }


        public string Severity => _severity;

        public string DateTime => _dateTime;

        public string Message => _message;

        public string From => _from;

        public string Component => _component;

        public string Device => _device;

        public string FileName => _fileName;

        public FileType FileType => _fileType;


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
