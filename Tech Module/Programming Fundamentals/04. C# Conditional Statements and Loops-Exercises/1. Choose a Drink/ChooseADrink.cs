namespace _1.Choose_a_Drink
{
    using System;
    using System.Collections.Generic;

    public class ChooseADrink
    {
        static void Main()
        {
            Dictionary<string, string> drinks = new Dictionary<string, string>()
            {
                { "Athlete", "Water"},
                { "Businessman","Coffee"},
                { "Businesswoman","Coffee"},
                { "SoftUni Student", "Beer"}
            };
                
            string input = Console.ReadLine();

            if (drinks.ContainsKey(input))
            {
                Console.WriteLine(drinks[input]);
            }
            else
            {
                Console.WriteLine("Tea");
            }
        }
    }
}
