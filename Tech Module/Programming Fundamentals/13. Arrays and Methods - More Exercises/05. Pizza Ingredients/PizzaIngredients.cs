namespace _05.Pizza_Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PizzaIngredients
    {
        static void Main(string[] args)
        {
            var ingredients = Console.ReadLine()
                .Split(' ')
                .Select(x => x)
                .ToArray();
            byte searchedLenght = byte.Parse(Console.ReadLine());
            byte counter = 0;
            List<string> ingredinetsUsed = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == searchedLenght)
                {
                    Console.WriteLine("Adding {0}.", ingredients[i]);
                    ingredinetsUsed.Add(ingredients[i]);
                    counter++;
                }
                if (counter == 10)
                {
                    break;
                }
            }
            Console.WriteLine($"Made pizza with total of {counter} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ",ingredinetsUsed)}.");

        }
    }
}
