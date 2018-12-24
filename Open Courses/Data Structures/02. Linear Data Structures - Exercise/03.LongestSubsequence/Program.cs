namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = ReadNumbers();

            List<int> evenMatches = FindEvenMatches(numbers);

            PrintOccurencesToConsole(numbers, evenMatches);

        }

        private static void PrintOccurencesToConsole(List<int> numbers, List<int> evenMatches)
        {
            if (evenMatches.Count == 0)
            {
                Console.WriteLine(numbers.First());
            }
            else
            {
                Dictionary<int, int> occurences = new Dictionary<int, int>();

                foreach (var number in evenMatches)
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

                var ordered = occurences.OrderByDescending(x => x.Value).First();

                for (int i = 0; i <= ordered.Value; i++)
                {
                    Console.Write(ordered.Key + " ");
                }
            }
        }

        private static List<int> FindEvenMatches(List<int> numbers)
        {
            List<int> evenMatches = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    evenMatches.Add(numbers[i]);
                }
            }

            return evenMatches;
        }

        private static List<int> ReadNumbers()
        => Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
    }
}
