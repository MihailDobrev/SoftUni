namespace _04.RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = ReadNumbers();

            Dictionary<int, int> occurences = FindOccurences(numbers);

            PrintOddOccurences(numbers, occurences);

        }

        private static void PrintOddOccurences(List<int> numbers, Dictionary<int, int> occurences)
        {
            foreach (var number in numbers)
            {
                if (occurences[number] % 2 == 0)
                {
                    Console.Write(number + " ");
                }
            }
        }

        private static Dictionary<int, int> FindOccurences(List<int> numbers)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!occurences.ContainsKey(number))
                {
                    occurences[number] = 1;
                }
                else
                {
                    occurences[number]++;
                }
            }

            return occurences;
        }

        private static List<int> ReadNumbers()
       => Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
    }
}
