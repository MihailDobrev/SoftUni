using System;
using System.Collections.Generic;
using System.Linq;

    public class Startup
    {
        static void Main()
        {
            try
            {
                string[] namesAndMoney = Console.ReadLine().Split(new char[] { ';', '=', }, StringSplitOptions.RemoveEmptyEntries);
                List<Person> people = new List<Person>();

                for (int index = 0; index < namesAndMoney.Length - 1; index++)
                {
                    string name = namesAndMoney[index];
                    decimal money = decimal.Parse(namesAndMoney[index + 1]);
                    index++;
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                List<Product> products = new List<Product>();
                string[] productsAndCosts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                for (int index = 0; index < productsAndCosts.Length - 1; index++)
                {
                    string productName = productsAndCosts[index];
                    decimal cost = decimal.Parse(productsAndCosts[index + 1]);
                    index++;
                    Product product = new Product(productName, cost);
                    products.Add(product);
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] purchases = input.Split().Where(i => i != string.Empty).ToArray();

                    string client = purchases[0];
                    string productName = purchases[1];

                    Person searchedPerson = people.Where(p => p.Name == client).First();
                    Product searchedProduct = products.Where(p => p.Name == productName).First();
                    Console.WriteLine(searchedPerson.BuyProduct(searchedProduct));

                    input = Console.ReadLine();
                }

                foreach (Person person in people)
                {
                    if (person.Bag.Count==0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ",person.Bag.Select(pr=>pr.Name))}");
                    }
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        
        }
    }

