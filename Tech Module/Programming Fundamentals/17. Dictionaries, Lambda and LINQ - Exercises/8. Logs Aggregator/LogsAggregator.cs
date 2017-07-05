

namespace _8.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class LogsAggregator
    {
        static void Main()
        {
            short n = short.Parse(Console.ReadLine());
            var dataLog = new SortedDictionary<string, UserLog>();

            for (short i = 0; i < n; i++)
            {
                var userData = Console.ReadLine().Split(' ');
                string ip = userData[0];
                string userName = userData[1];
                int duration = int.Parse(userData[2]);

                if (!dataLog.ContainsKey(userName))
                {
                    UserLog userLog = new UserLog()
                    {
                        UserName = userName,
                        Duration = 0,
                        Ips = new HashSet<string>()
                    };
                    userLog.Duration += duration;
                    userLog.Ips.Add(ip);
                    dataLog.Add(userName, userLog);
                }
                else
                {
                    dataLog[userName].Duration += duration;
                    dataLog[userName].Ips.Add(ip);
                }

            }

            foreach (var data in dataLog)
            {

                Console.WriteLine($"{data.Key}: {data.Value.Duration} [{string.Join(", ", data.Value.Ips.OrderBy(x => x))}]");
            }
        }
    }
}
