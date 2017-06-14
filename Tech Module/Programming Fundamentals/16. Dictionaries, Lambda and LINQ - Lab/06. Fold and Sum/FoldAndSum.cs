namespace _6.Fold_and_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FoldAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var foldedFirstPart = numbers
                    .Take(numbers.Length / 4)
                    .Reverse()
                    .ToList();

            var middle = numbers
                .Skip(numbers.Length / 4)
                .Take(2 * numbers.Length / 4)
                .ToList();

            var foldedSecondPart = numbers
                    .Skip(3 * numbers.Length / 4)
                    .Take(numbers.Length / 4)
                    .Reverse()
                    .ToList();

            var foldedSum = new List<int>();
            foldedSum.AddRange(foldedFirstPart);
            foldedSum.AddRange(foldedSecondPart);        

            var summed = new List<int>();

            for (int i = 0; i < middle.Count; i++)
            {
                summed.Add(foldedSum[i] + middle[i]);
            }

            Console.WriteLine(string.Join(" ",summed));
        }
    }
}
