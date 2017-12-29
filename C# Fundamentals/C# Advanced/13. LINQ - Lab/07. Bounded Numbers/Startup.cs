namespace _07.Bounded_Numbers
{
    using System;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            var bounds = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();

            Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= bounds[0] && n <= bounds[1])
                .ToList()
                .ForEach(n => Console.Write(n+" "));
        }
    }
}
