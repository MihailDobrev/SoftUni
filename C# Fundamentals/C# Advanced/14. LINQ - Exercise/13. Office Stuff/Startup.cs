namespace _13.Office_Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
       public static void Main()
        {
            int numberOfOrders = int.Parse(Console.ReadLine());
            List<Company> companies = new List<Company>();

            for (int i = 1; i <= numberOfOrders; i++)
            {
                string[] orderData = Console.ReadLine().Split(new char[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string companyName = orderData[0];
                string product = orderData[2];
                int amount = int.Parse(orderData[1]);

                var currentCompany = companies.Where(x => x.CompanyName == companyName).FirstOrDefault();

                if (currentCompany==null)
                {
                    currentCompany = new Company()
                    {
                        CompanyName = orderData[0],
                        Orders = new List<Order>()
                    };
                    companies.Add(currentCompany);
                }
                var currentOrder = currentCompany.Orders.Where(x => x.Product == product).FirstOrDefault();

                if (currentOrder==null)
                {
                    currentOrder = new Order()
                    {
                        Product = product,
                        Amount = 0
                    };

                    currentCompany.Orders.Add(currentOrder);
                }
                currentOrder.Amount += amount;
                
               
            }

            foreach (var company in companies.OrderBy(n=>n.CompanyName))
            {
                Console.Write($"{company.CompanyName}: ");

                Console.WriteLine(string.Join(", ",company.Orders.Select(x=>$"{x.Product}-{x.Amount}")));   
            }
        }     
    }
}
