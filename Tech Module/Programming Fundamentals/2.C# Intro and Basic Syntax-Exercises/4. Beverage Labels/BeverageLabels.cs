
namespace _4.Beverage_Labels
{
    using System;
    public class BeverageLabels
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());

            Console.WriteLine($"{volume}ml {productName}:");
            Console.WriteLine($"{energyContent*(double)volume /100.00}kcal, {sugarContent* (double)volume /100.00}g sugars");
        }
    }
}
