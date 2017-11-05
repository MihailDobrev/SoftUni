namespace _13.Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Startup
    {
        public static void Main()
        {
            string input;
            Dictionary<string, Dictionary<string, int>> singerRevenues = new Dictionary<string, Dictionary<string, int>>();
            string pattern = @"(.*?)\s@(.*?)\s(\d+)\s(\d+)";
            input = Console.ReadLine();

            while (input!="End")
            {
                Match regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    string singerName = regex.Groups[1].Value;
                    string venue = regex.Groups[2].Value;
                    int ticketsPrice = int.Parse(regex.Groups[3].Value);
                    int ticketsCount = int.Parse(regex.Groups[4].Value);

                    int revenue = ticketsPrice * ticketsCount;

                    if (!singerRevenues.ContainsKey(venue))
                    {
                        singerRevenues[venue] = new Dictionary<string, int>();
                    }

                    if (!singerRevenues[venue].ContainsKey(singerName))
                    {
                        singerRevenues[venue][singerName] = revenue;
                    }
                    else
                    {
                        singerRevenues[venue][singerName] += revenue;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var revenue in singerRevenues)
            {
                Console.WriteLine(revenue.Key);

                foreach (var pair in revenue.Value.OrderByDescending(r=>r.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}
