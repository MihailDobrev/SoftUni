namespace _1.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
           
            var currentSequence = new List<int>();
            var maxSequence = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                currentSequence.Add(numbers[i]);
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentSequence.Add(numbers[j]);
                    }
                }
                if (maxSequence.Count < currentSequence.Count)
                {
                    maxSequence.Clear();
                    maxSequence.AddRange(currentSequence);
                }
                currentSequence.Clear();

            }
            foreach (var number in maxSequence)
            {
                Console.Write(number + " ");
            }
        }
    }
}
