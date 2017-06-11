namespace _08.Upgraded_Matcher
{
    using System;
    using System.Linq;
    public class UpgradedMatcher
    {
        static void Main()
        {
            var products = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            string input;
            
            long initialQuanity = 0;

            while ((input = Console.ReadLine()) != "done")
            {
                var array = input.Split(' ');
                string product = array[0];
                long quantity = long.Parse(array[1]);

                int index = Array.IndexOf(products, product);
                var totalPrice = quantity * prices[index];

                try
                {
                    initialQuanity = quantities[index];
                }
                catch (IndexOutOfRangeException)
                {
                    initialQuanity = 0;
                }
                if (quantity<=initialQuanity)
                {
                    Console.WriteLine($"{products[index]} x {quantity} costs {totalPrice:F2}");
                    quantities[index] -= quantity;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {products[index]}");
                }
                
            }
        }
    }
}
