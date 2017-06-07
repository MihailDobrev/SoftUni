namespace Rounding_Numbers_Away_from_Zero
{
    using System;
    using System.Linq;
    public class RoundingNumbers
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(m => Convert.ToDouble(m))
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number} => {Math.Round(number, 0, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
