using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Sales_Report
{
    public class SalesReport
    {
        static void Main()
        {
            var totalSalesPerTown = new SortedDictionary<string, double>();

            int numberOfSales = int.Parse(Console.ReadLine());

            for (int count = 0; count < numberOfSales; count++)
            {
                Sale sale = ReadSale(Console.ReadLine());

                if (!totalSalesPerTown.ContainsKey(sale.Town))
                {
                    totalSalesPerTown.Add(sale.Town, sale.Price * sale.Quantity);
                }
                else
                {
                    totalSalesPerTown[sale.Town] += sale.Price * sale.Quantity;
                }

            }

            foreach (var pair in totalSalesPerTown)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:F2}");
            }

        }

        public static Sale ReadSale(string input)
        {
            var properties = input.Split(' ').Select(x => x).ToArray();

            return new Sale() { Town = properties[0], Product = properties[1], Price = double.Parse(properties[2]), Quantity = double.Parse(properties[3]) };
        }
    }
}
