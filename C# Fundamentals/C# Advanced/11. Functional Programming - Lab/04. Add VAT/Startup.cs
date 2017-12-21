namespace _04.Add_VAT
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Func<string, double> parser = n => double.Parse(n)*1.2;

            Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x:F2}"));

            
        }
    }
}
