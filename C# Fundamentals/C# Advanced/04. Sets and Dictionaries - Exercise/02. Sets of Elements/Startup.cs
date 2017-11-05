namespace _02.Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] lenghtOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> uniqueNumbersFirstSet = new HashSet<int>();
            HashSet<int> uniqueNumbersSecondSet = new HashSet<int>();

            uniqueNumbersFirstSet = FillData(lenghtOfSets[0],uniqueNumbersFirstSet);
            uniqueNumbersSecondSet = FillData(lenghtOfSets[1],uniqueNumbersSecondSet);


            List<int> equalNumbersBetweenSets = new List<int>();

            foreach (var number in uniqueNumbersSecondSet)
            {
                if (uniqueNumbersFirstSet.Contains(number))
                {
                    equalNumbersBetweenSets.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", equalNumbersBetweenSets));
        }

        private static HashSet<int> FillData(int lenghtOfSet, HashSet<int> uniqueNumbersFirstSet)
        {
            for (int i = 0; i < lenghtOfSet; i++)
            {
                int number = int.Parse(Console.ReadLine());

                uniqueNumbersFirstSet.Add(number);
            }

            return uniqueNumbersFirstSet;
        }
    }
}
