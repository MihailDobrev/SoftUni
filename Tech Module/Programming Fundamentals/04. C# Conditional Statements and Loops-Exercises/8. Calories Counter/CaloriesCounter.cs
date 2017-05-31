

namespace _8.Calories_Counter
{
    using System;
    using System.Collections.Generic;
    public class CaloriesCounter
    {
        static void Main(string[] args)
        {
            var ingredients = new Dictionary<string, int>()
            {
                {"cheese",500 },
                {"tomato sauce",150 },
                {"salami",600 },
                {"pepper",50 },
            };
            int sumOfCalories = 0;

            byte numberOfIngredients = byte.Parse(Console.ReadLine());
            string ingredient;

            for (int i = 0; i < numberOfIngredients; i++)
            {
                ingredient = Console.ReadLine().ToLower();

                if (ingredients.ContainsKey(ingredient))
                {
                    sumOfCalories += ingredients[ingredient];
                }
            }
            Console.WriteLine($"Total calories: { sumOfCalories}");
        }
    }
}
