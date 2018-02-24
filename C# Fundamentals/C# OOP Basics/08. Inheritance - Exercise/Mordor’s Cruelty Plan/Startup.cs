namespace Mordor_s_Cruelty_Plan
{
    using Mordor_s_Cruelty_Plan.Food;
    using Mordor_s_Cruelty_Plan.Mood;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int totalHappiness = CalculateTotalHappiness();
            string mood = SetMood(totalHappiness);
            PrintResult(totalHappiness,mood);

        }

        private static void PrintResult(int totalHappiness, string mood)
        {
            Console.WriteLine(totalHappiness);
            Console.WriteLine(mood);
        }

        private static string SetMood(int totalHappiness)
        {
            string mood = string.Empty;

            if (totalHappiness < -5)
            {
                Angry angry = new Angry();
                mood = angry.SetMood(totalHappiness);
            }
            else if (totalHappiness >= -5 && totalHappiness <= 0)
            {
                Sad sad = new Sad();
                mood = sad.SetMood(totalHappiness);
            }
            else if (totalHappiness >= 1 && totalHappiness <= 15)
            {
                Happy happy = new Happy();
                mood = happy.SetMood(totalHappiness);
            }
            else if (totalHappiness > 15)
            {
                JavaScript js = new JavaScript();
                mood = js.SetMood(totalHappiness);
            }

            return mood;
        }

        private static int CalculateTotalHappiness()
        {
            string[] allFoodEaten = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<FoodFactory> foodFactory = new Queue<FoodFactory>();

            for (int index = 0; index < allFoodEaten.Length; index++)
            {
                string currentFood = allFoodEaten[index];

                switch (currentFood.ToLower())
                {
                    case "cram":
                        foodFactory.Enqueue(new Cram());
                        break;
                    case "lembas":
                        foodFactory.Enqueue(new Lembas());
                        break;
                    case "apple":
                        foodFactory.Enqueue(new Apple());
                        break;
                    case "melon":
                        foodFactory.Enqueue(new Melon());
                        break;
                    case "honeycake":
                        foodFactory.Enqueue(new HoneyCake());
                        break;
                    case "mushrooms":
                        foodFactory.Enqueue(new Mushroom());
                        break;
                    default:
                        foodFactory.Enqueue(new Other());
                        break;
                }
            }

            int totalHappiness = 0;

            while (foodFactory.Count > 0)
            {
                totalHappiness += foodFactory.Dequeue().Happiness;
            }

            return totalHappiness;
        }
    }
}
