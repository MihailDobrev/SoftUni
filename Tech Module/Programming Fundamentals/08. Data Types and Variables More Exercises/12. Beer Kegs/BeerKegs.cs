

namespace Beer_Kegs
{
    using System;

    public class BeerKegs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string biggestKeg = string.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double currentKegVolume = Math.PI * Math.Pow(radius, 2) * height;
                if (currentKegVolume > biggestKegVolume)
                {
                    biggestKegVolume = currentKegVolume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
