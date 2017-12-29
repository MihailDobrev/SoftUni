namespace _04.Average_of_Doubles
{
    using System;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            double averageNumber = Console.ReadLine().Split(' ')
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{ averageNumber:F2}");

        }
    }
}
