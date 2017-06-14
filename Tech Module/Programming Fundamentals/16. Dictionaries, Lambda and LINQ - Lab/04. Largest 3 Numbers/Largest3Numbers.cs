namespace _4.Largest_3_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Largest3Numbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> threenNumbers = numbers
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ",threenNumbers));

        }
    }
}
