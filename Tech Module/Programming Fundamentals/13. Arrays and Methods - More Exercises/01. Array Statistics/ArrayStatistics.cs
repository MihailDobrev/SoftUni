namespace _01.Array_Statistics
{
    using System;
    using System.Linq;

    public class ArrayStatistics
    {
        static void Main()
        {
            var number = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();
            Console.WriteLine($"Min = {number.Min()}");
            Console.WriteLine($"Max = {number.Max()}");
            Console.WriteLine($"Sum = {number.Sum()}");
            Console.WriteLine($"Average = {number.Average()}");
        }
    }
}
