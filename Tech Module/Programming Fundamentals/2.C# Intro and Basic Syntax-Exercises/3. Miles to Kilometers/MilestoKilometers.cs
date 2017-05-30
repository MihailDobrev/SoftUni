
namespace _3.Miles_to_Kilometers
{
    using System;
    public class MilestoKilometers
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine($"{number*1.60934:F2}");
        }
    }
}
