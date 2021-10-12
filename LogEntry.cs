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


        public LogEntry(string severity, string dateTime, string from, string component, string device, string message, string fileName)
        {
            _severity = severity ?? throw new ArgumentNullException(nameof(severity));
            _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            _from = from;
            _component = component;
            _device = device;
            _message = message ?? throw new ArgumentNullException(nameof(message));
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));

            //TODO - Extract this FileType decision out of this Constructor, to be more flexible in the future?
            if (fileName.ToLower().StartsWith("tbtracer"))
            {
                _fileType = FileType.TBTracer;
            } 
            else if (fileName.ToLower().StartsWith("message")) 
            {
                _fileType = FileType.Message;
            }
            else
            {
                _fileType = FileType.Unidentified;
            }
        }

        public string Severity => _severity;

        public string DateTime => _dateTime;

        public string Message => _message;

        public string From => _from;

        public string Component => _component;

        public string Device => _device;

        public string FileName => _fileName;

        public FileType FileType => _fileType;
    }




}
