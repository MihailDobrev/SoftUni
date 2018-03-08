namespace _07.FoodShortage
{
    using _07.FoodShortage.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            List<IBuyer> allPeople = ReadPeople();
            int totalFood = CalculateFood(allPeople);
            Console.WriteLine(totalFood);
        }

        private static int CalculateFood(List<IBuyer> allPeople)
        {
            int totalFood = 0;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string buyerOfFood = input;
                var searchedBuyer = allPeople.FirstOrDefault(p => p.Name == buyerOfFood);

                if (searchedBuyer != null)
                {
                    totalFood += searchedBuyer.BuyFood();
                }
            }

            return totalFood;
        }

        private static List<IBuyer> ReadPeople()
        {
            List<IBuyer> allPeople = new List<IBuyer>();

            int totalPeople = int.Parse(Console.ReadLine());

            for (int person = 0; person < totalPeople; person++)
            {
                string[] personInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 3)
                {
                    allPeople.Add(new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
                }
                else if (personInfo.Length == 4)
                {
                    allPeople.Add(new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]));
                }
            }

            return allPeople;
        }
    }
}
