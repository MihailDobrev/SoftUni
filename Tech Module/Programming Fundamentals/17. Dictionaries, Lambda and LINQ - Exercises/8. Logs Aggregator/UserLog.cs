namespace _8.Logs_Aggregator
{
    using System.Collections.Generic;
    class UserLog
    {
        public string UserName { get; set; }

        public int Duration { get; set; }

        public HashSet<string> Ips { get; set; }
    }
}
