
namespace WeatherForecast
{
    using System;

    public class WeatherForecast
    {
        public static void Main()
        {
            double inputNumber = double.Parse(Console.ReadLine());

            if (inputNumber % 1 != 0)
            {
                Console.WriteLine("Rainy");
            }
            else if (sbyte.MinValue <= inputNumber && inputNumber <= sbyte.MaxValue)
            {
                Console.WriteLine("Sunny");
            }
            else if (int.MinValue <= inputNumber && inputNumber <= int.MaxValue)
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.MinValue <= inputNumber && inputNumber <= long.MaxValue)
            {
                Console.WriteLine("Windy");
            }
        }
    }
}
