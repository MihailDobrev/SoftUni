namespace _2.Choose_a_Drink_2
{
    using System;
    using System.Collections.Generic;

    public class ChooseADrink2

    {
        static void Main()
        {
            var pricesPerProfession = new Dictionary<string, double>()
            {
                { "Athlete", 0.7},
                { "Businessman", 1},
                { "Businesswoman", 1},
                { "SoftUni Student", 1.7}
            };

            string profession = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            


            if (pricesPerProfession.ContainsKey(profession))
            {
                PrintOutput(profession,pricesPerProfession[profession],quantity);
                
            }
            else
            {
                PrintOutput(profession, 1.2, quantity);
            }           

        }

        private static void PrintOutput(string profession, double prices,double quantity )
        {
            var payAmount = quantity * prices;
            Console.WriteLine($"The {profession} has to pay {payAmount:F2}.");
        }
    }
}
