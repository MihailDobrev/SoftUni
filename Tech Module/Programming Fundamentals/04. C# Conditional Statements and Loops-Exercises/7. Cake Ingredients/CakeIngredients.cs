namespace _7.Cake_Ingredients
{
    using System;
    public class CakeIngredients
    {
        static void Main()
        {
            string ingredient;
            int ingredientCounter = 0;

            while ((ingredient=Console.ReadLine())!="Bake!")
            {
                Console.WriteLine($"Adding ingredient {ingredient}.");
                ingredientCounter++;
            }
            Console.WriteLine($"Preparing cake with {ingredientCounter} ingredients.");
        }
    }
}
