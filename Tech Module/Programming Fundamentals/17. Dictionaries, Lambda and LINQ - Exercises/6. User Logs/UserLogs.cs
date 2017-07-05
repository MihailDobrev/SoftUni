namespace _6.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            string input;

            char[] delimiters = { ' ', '=' };

            var ips = new Dictionary<string, int>();

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end")
            {
                var inputList = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => x)
                             .ToList();

                var userName = inputList[inputList.Count - 1];
                var ip = inputList[1];

                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();

                }

                if (!users[userName].ContainsKey(ip))
                {
                    users[userName][ip] = 1;
                }
                else
                {
                    users[userName][ip]++;
                }

            }

            foreach (var user in users)
            {
                var userName = user.Key;
                var counts = user.Value;

                Console.WriteLine($"{userName}:");

                var output = new List<string>();

                foreach (var number in counts)
                {

                    var ip = number.Key;
                    var numberCount = number.Value;
                    //Console.Write($"{ip} => {numberCount}");
                    output.Add(ip + " => " + numberCount);
                }
                Console.WriteLine(string.Join(", ", output) + ".");
            }
        }
    }
    
}
