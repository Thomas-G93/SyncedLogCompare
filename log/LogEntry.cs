namespace SyncedLogCompare.log
{
    public class LogEntry
    {
        //TODO - add NULL check in Constructor
        //TODO - split again in two different classes? TBTRACER and MESSAGE
        //TODO - LOGENTRY then a Interface or is then the FileType a Interface for new classes which hold the necesarry information?

        public LogEntry(string severity, string dateTime, string component, string device, string message, string fileName, string fileType)
        {
            //TBTRACER
            Severity = severity;
            DateTime = dateTime;
            Component = component;
            Device = device;
            Message = message;
            FileName = fileName;
            FileType = fileType;
        }

        public LogEntry(string severity, string dateTime, string from, string message, string fileName, string fileType)
        {
            //MESSAGE
            Severity = severity;
            DateTime = dateTime;
            From = from;
            Message = message;
            FileName = fileName;
            FileType = fileType;
        }

        public override string ToString()
        {
            return $"{nameof(Severity)}: {Severity}, {nameof(DateTime)}: {DateTime}, {nameof(Message)}: {Message}, {nameof(From)}: {From}, {nameof(Component)}: {Component}, {nameof(Device)}: {Device}";
        }

        public string FileType { get; }

        public string Severity { get; }

        public string DateTime { get; }

        public string Message { get; }

        public string From { get; }

        public string Component { get; }

        public string Device { get; }

        public string FileName { get; }


    }




}
