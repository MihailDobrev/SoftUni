namespace _05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            List<int> numbers = ReadNumbers();

            Dictionary<int, int> occurences = FindOccurences(numbers);

            foreach (var keyValuePair in occurences.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value} times");
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
