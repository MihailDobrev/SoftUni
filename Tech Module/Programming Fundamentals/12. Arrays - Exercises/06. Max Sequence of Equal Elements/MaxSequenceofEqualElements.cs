namespace Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class MaxSequenceofEqualElements
    {
        static void Main()
        {

            int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = 0;
            int count = 0;
            int max = 0;
            for (int i = 0; i < array1.Length - 1; i++)
            {
                if (array1[i] == array1[i + 1])
                {
                    count++;
                    if (count > max)
                    {
                        start = i - count;
                        max = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            for (int i = start + 1; i <= start + max + 1; i++)
            {
                Console.Write(array1[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
