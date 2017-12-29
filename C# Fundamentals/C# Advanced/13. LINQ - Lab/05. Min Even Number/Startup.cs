namespace _05.Min_Even_Number
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            var result = numbers.Count == 0 ? "No match" : numbers[0].ToString("0.00");
            Console.WriteLine(result);
        }
    }
}
