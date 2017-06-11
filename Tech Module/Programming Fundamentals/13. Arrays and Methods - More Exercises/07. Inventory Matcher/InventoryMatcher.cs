namespace _07.Inventory_Matcher
{
    using System;
    public class InventoryMatcher
    {
        static void Main()
        {
            var products = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ');
            var prices = Console.ReadLine().Split(' ');
            string input;
            int index = 0;

            while ((input=Console.ReadLine())!="done")
            {
                index = Array.IndexOf(products, input);
                Console.WriteLine($"{products[index]} costs: {prices[index]}; Available quantity: {quantities[index]}");
            }
        }
    }
}
