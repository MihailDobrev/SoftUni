namespace _7.Count_Numbers
{
    using System;
    using System.Collections.Generic;
    public class CountNumbers
    {
        static void Main()
        {
            string[] nums = Console.ReadLine().Split(' ');

            var counts = new SortedDictionary<int, int>();

            foreach (var num in nums)
            {
                int parsedNumber = int.Parse(num);

                if (counts.ContainsKey(parsedNumber))
                {
                    counts[parsedNumber]++;
                }
                else
                {
                    counts[parsedNumber] = 1;
                }
            }
            foreach (var num in counts.Keys)
            {
                Console.WriteLine($"{num} -> {counts[num]}");
            }

        }
    }
}
