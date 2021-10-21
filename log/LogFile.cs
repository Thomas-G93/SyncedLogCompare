using System;

namespace SyncedLogCompare.log
{
    class LogFile
    {
        public LogFile(string fileName)
        {
            FileName = fileName;

            FileType = SetFileType(fileName);

            Separator = SetSeparator(FileType);

            Parts = SetLogParts(FileType);
            
        }

        private char[] SetSeparator(FileType fileType)
        {
            char[] separator = { ';' };
            return separator;
        }

        private FileType SetFileType(string fileName)
        {

            Console.WriteLine(fileName.ToLower());

            if (fileName.ToLower().StartsWith("tbtracer"))
            {
                return FileType.TBTracer;
            }

            if (fileName.ToLower().StartsWith("messages_base"))
            {
                return FileType.MessagesBASE;
            }

            if (fileName.ToLower().StartsWith("messages"))
            {
                return FileType.Messages;
            }

            return FileType.Unidentified;
        }

        private int SetLogParts(FileType fileType)
        {
            if (fileType == FileType.TBTracer)
            {
                return 5;
            }

            if (fileType == FileType.Messages || fileType == FileType.MessagesBASE)
            {
                return 4;
            }

            //TODO - Write new FILE Exception // and throw here instead of returning 1
            return 1;

        }

        public string FileName { get; }

        public char[] Separator { get; }

        public int Parts { get; }

        public FileType FileType { get; }
    }
}
