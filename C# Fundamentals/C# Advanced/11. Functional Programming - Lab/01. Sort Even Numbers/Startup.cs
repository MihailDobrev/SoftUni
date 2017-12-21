namespace _01.Sort_Even_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> orderedNumbers = numbers
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();
            Console.WriteLine(string.Join(", ", orderedNumbers));
        }
    }
}
