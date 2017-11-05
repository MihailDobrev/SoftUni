using System.Collections.Generic;

namespace _11.Logs_Aggregator
{
    public class UserLog
    {
        public string UserName { get; set; }

        public int Duration { get; set; }

        public SortedSet<string> Ips { get; set; }
    }
}
