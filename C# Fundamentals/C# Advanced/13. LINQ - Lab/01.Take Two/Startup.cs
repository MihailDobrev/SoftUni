namespace _01.Take_Two
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList()
                .Distinct()
                .Where(n => n >= 10 && n <= 20)
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}
