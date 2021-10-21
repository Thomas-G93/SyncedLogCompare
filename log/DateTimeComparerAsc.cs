using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedLogCompare.log
{
    internal class DateTimeComparerAsc : IComparer<LogEntry>
    {
        public int Compare(LogEntry x, LogEntry y)
        {
            return string.Compare(x.DateTime, y.DateTime, StringComparison.Ordinal);
        }
    }
}
