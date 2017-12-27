namespace _06.Reverse_and_exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int numberToDevise = int.Parse(Console.ReadLine());
            List<int> devisibleNumbers = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                int currentNumber = numbers[index];
                bool isDevisible = CheckDevisible(currentNumber, num => num % numberToDevise == 0);

                if (!isDevisible)
                {
                    devisibleNumbers.Add(currentNumber);
                }
            }
            devisibleNumbers.Reverse();
            Console.WriteLine(string.Join(" ", devisibleNumbers));   
        }

        private static bool CheckDevisible(int number, Func<int, bool> condition)
        {
          return condition(number);           
        }
    }
}
