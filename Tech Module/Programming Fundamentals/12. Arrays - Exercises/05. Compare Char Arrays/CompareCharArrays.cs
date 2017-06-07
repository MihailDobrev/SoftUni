namespace Compare_Char_Arrays
{
    using System;
    using System.Linq;

    public class CompareCharArrays
    {
        static void Main()
        {
            char[] firstArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToChar(x))
                .ToArray();

            char[] secondArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToChar(x))
                .ToArray();

            char[] minArray = new char[Math.Min(firstArray.Length, secondArray.Length)];
            char[] maxArray = new char[Math.Max(firstArray.Length, secondArray.Length)];

            for (int i = 0; i < minArray.Length; i++)
            {
                if (firstArray[i] <= secondArray[i])
                {
                    minArray = firstArray;
                    maxArray = secondArray;
                }
                else
                {
                    minArray = secondArray;
                    maxArray = firstArray;
                }

            }

            PrintArray(minArray);
            Console.WriteLine();
            PrintArray(maxArray);
        }

        private static void PrintArray(char[] Array)
        {
            foreach (var charact in Array)
            {
                Console.Write(charact);
            }
        }
    }
}
