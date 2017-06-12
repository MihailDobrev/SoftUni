namespace _5.Sort_Numbers
{
    using System;
    using System.Linq;
    public class SortNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            numbers.Sort();

            Console.WriteLine(string.Join(" <= ",numbers));
        }
    }
}
