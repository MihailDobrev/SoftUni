namespace _06.Heists
{
    using System;
    using System.Linq;
   
    public class Heists
    {
        public static void Main()
        {
            var prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int jewelsPrice = prices[0];
            int goldPrice = prices[1];
            string input;
            int jewelCounter = 0;
            int goldCounter = 0;
            long totalExpenses = 0;

            while ((input=Console.ReadLine())!="Jail Time")
            {
                var lootAndExpenses = input.Split(' ');
                string loot = lootAndExpenses[0];
                int expenses = int.Parse(lootAndExpenses[1]);
                totalExpenses += expenses;

                for (int i = 0; i < loot.Length; i++)
                {
                    if (loot[i]=='%')
                    {
                        jewelCounter++;
                    }
                    if (loot[i] == '$')
                    {
                        goldCounter++;
                    }
                }
            }
            long netEarnings = jewelCounter * jewelsPrice + goldCounter * goldPrice - totalExpenses;

            if (netEarnings>=0)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {netEarnings}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {Math.Abs(netEarnings)}.");
            }
        }
    }
}
