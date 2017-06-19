namespace _07.Andrey_and_Bill
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AndreyAndBilliard
    {
        static void Main()
        {

            int amountOfProducts = int.Parse(Console.ReadLine());
            Dictionary<string, double> products = new Dictionary<string, double>();

            for (int i = 0; i < amountOfProducts; i++)
            {
                var productsAndPrices = Console.ReadLine().Split('-');

                products[productsAndPrices[0]] = double.Parse(productsAndPrices[1]);
            }

            
            var customerList = new List<Customer>();

            string input=Console.ReadLine();

            while (input != "end of clients")
            {
                var properties = input.Split('-', ',').Select(x => x).ToArray();
                string name = properties[0];
                string product = properties[1];
                int quantity = int.Parse(properties[2]);
                var orderedQuantities = new Dictionary<string, int>() { { product, quantity } };

                if (products.ContainsKey(product))
                { 
                    bool hasAleadyPurchased = false;
                    double bill = products[product] *  quantity;

                    foreach (var cust in customerList)
                    {
                        if (cust.Name==name)
                        {
                            hasAleadyPurchased = true;
                            cust.Bill += bill;

                            if (cust.ShoppingList.ContainsKey(product))
                            {
                                cust.ShoppingList[product] += quantity;
                            }
                            else
                            {
                                cust.ShoppingList.Add(product, quantity);
                            }
                            break;
                        }
                    }
                    if (hasAleadyPurchased==false)
                    {
                        Customer customer = new Customer() { Name = name, ShoppingList = orderedQuantities, Bill = bill };
                        customerList.Add(customer);
                    }
                }

                input = Console.ReadLine();

            }
            
            
            foreach (var customerInList in customerList.OrderBy(x=>x.Name))
            {
                Console.WriteLine(customerInList.Name);
                foreach (var purchase in customerInList.ShoppingList)
                {
                    Console.WriteLine($"-- {purchase.Key} - {purchase.Value}");
                   
                }
           
                Console.WriteLine($"Bill: {customerInList.Bill:F2}");
            }
            double totalSum = customerList.Select(x => x.Bill).Sum();
            Console.WriteLine($"Total bill: {totalSum:F2}");
        }
    }
}
