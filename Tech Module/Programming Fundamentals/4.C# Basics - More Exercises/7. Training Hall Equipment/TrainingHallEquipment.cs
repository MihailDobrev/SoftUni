

namespace _7.Training_Hall_Equipment
{
    using System;

    public class TrainingHallEquipment
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());
            string item;
            double price = 0;
            int count = 0;
            double subtotal = 0;
            double itemsCost = 0;
            string plural;
            

            for (int i = 1; i <= numberOfItems; i++)
            {
                item = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
                count = int.Parse(Console.ReadLine());
                itemsCost = price * count;

                plural = count > 1 ? "s" : "";
                Console.WriteLine($"Adding {count} {item}{plural} to cart.");
                subtotal += itemsCost;

            }

            if (subtotal <= budget)
            {
                double moneyLeft = budget - subtotal;
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Money left: ${moneyLeft:F2}");
            }
            else
            {
                double moneyNeeded = subtotal - budget;
                Console.WriteLine($"Subtotal: ${subtotal:f2}");
                Console.WriteLine($"Not enough. We need ${moneyNeeded:F2} more.");
            }

        }
    }
}
