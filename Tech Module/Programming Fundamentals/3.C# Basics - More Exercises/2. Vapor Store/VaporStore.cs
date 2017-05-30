using System;
using System.Collections.Generic;

namespace _2.Vapor_Store
{
    public class VaporStore
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input;
            double startingMoney = balance;

            var gamePrices = new Dictionary<string, double>()
            {
                {"OutFall 4",39.99 },
                {"CS: OG",15.99 },
                {"Zplinter Zell",19.99 },
                {"Honored 2",59.99 },
                {"RoverWatch",29.99 },
                {"RoverWatch Origins Edition",39.99 }
            };

            while ((input=Console.ReadLine())!="Game Time")
            {
                if (gamePrices.ContainsKey(input))
                {
                    if (gamePrices[input]>balance)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        balance -= gamePrices[input];
                        Console.WriteLine($"Bought {input}");
                    }

                    if (balance==0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
            if (balance>0)
            {
                Console.WriteLine($"Total spent: ${startingMoney-balance:F2}. Remaining: ${balance:F2}");
            }
        }
    }
}
