namespace _06.Find_and_Sum_Integers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
              .Split()
              .Select(n =>
              {
                  long value;
                  bool success = long.TryParse(n, out value);
                  return new { value, success };
              })
              .Where(b => b.success)
              .Select(x => x.value)
              .ToList();

            var result = numbers.Count == 0 ? "No match" : numbers.Sum().ToString();

            Console.WriteLine(result);
        }
    }
}
