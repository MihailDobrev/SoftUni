namespace _04.Supermarket_Database
{
    using System;
    using System.Collections.Generic;
    public class SupermarketDatabase
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            while (input != "stocked")
            {
                var productInfo = input.Split(' ');

                if (!products.ContainsKey(productInfo[0]))
                {
                    Product product = new Product()
                    {
                        Name = productInfo[0],
                        Price = double.Parse(productInfo[1]),
                        Quantity = int.Parse(productInfo[2])

                    };
                    products.Add(product.Name, product);
                }
                else
                {
                    products[productInfo[0]].Price = double.Parse(productInfo[1]);
                    products[productInfo[0]].Quantity += int.Parse(productInfo[2]);
                }
                input = Console.ReadLine();
            }
            double grandTotal = 0;
            foreach (var product in products)
            {
                double total = product.Value.Price * product.Value.Quantity;
                Console.WriteLine($"{product.Key}: ${product.Value.Price:F2} * {product.Value.Quantity} = ${total:F2}");
                grandTotal += total;
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");

        }
    }
    
}

