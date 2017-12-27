namespace _09.List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int endRange = int.Parse(Console.ReadLine());

            int[] sequence = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> numbers = new List<int>();

            for (int consecutiveNumber = 1; consecutiveNumber <= endRange; consecutiveNumber++)
            {
                bool isDevisible = true;
                for (int sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
                {
                    int number = sequence[sequenceIndex];

                    if (CheckDevisible(number, n => consecutiveNumber % n == 0))
                    {
                        continue;
                    }
                    else
                    {
                        isDevisible = false;
                        break;
                    }
                }
                if (isDevisible)
                {
                    numbers.Add(consecutiveNumber);
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }

        public static bool CheckDevisible(int number, Func<int, bool> condition) => condition(number);
        
    }
}
