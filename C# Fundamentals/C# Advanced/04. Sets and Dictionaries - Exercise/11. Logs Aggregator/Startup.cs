namespace _11.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            int logs = int.Parse(Console.ReadLine());
            Dictionary<string, UserLog> logRecords = new Dictionary<string, UserLog>();

            for (int i = 0; i < logs; i++)
            {
                string[] logInfo = Console.ReadLine().Split();

                string ip = logInfo[0];
                string userName = logInfo[1];
                int duration = int.Parse(logInfo[2]);

                if (!logRecords.ContainsKey(userName))
                {
                    logRecords[userName] = new UserLog()
                    {
                        UserName = userName,
                        Duration = duration,
                        Ips = new SortedSet<string>()
                    };
                    logRecords[userName].Ips.Add(ip);
                }
                else
                {
                    logRecords[userName].Duration += duration;
                    logRecords[userName].Ips.Add(ip);
                }
                

            }

            foreach (var pair in logRecords.OrderBy(l=>l.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Duration} [{string.Join(", ",pair.Value.Ips)}]");
            }
        }
        
    }
}
