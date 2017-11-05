namespace _09.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            Dictionary<string, Dictionary<string, int>> userLogs = new Dictionary<string, Dictionary<string, int>>();
            input = Console.ReadLine();

            while (input != "end")
            {
                string[] messageDetails = input.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = messageDetails[1];
                string message = messageDetails[3];
                string user = messageDetails[5];

                if (!userLogs.ContainsKey(user))
                {
                    userLogs[user] = new Dictionary<string, int>();
                }

                if (!userLogs[user].ContainsKey(ip))
                {
                    userLogs[user][ip] = 1;
                }
                else
                {
                    userLogs[user][ip] += 1;
                }

                input = Console.ReadLine();
            }

            
            foreach (var log in userLogs.OrderBy(l => l.Key))
            {
                Console.WriteLine($"{log.Key}:");

                var ipRecords = log.Value;
                List<string> records = new List<string>();

                foreach (var record in ipRecords)
                {
                    records.Add($"{record.Key} => {record.Value}");
                }

                Console.WriteLine($"{string.Join(", ", records)}.");

            }
        }
    }
}
