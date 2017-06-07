namespace Largest_Common_End
{
    using System;
    using System.Linq;
    public class LargestCommonEnd
    {
        static void Main()
        {
            string[] firstArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToString(x))
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToString(x))
                .ToArray();
            int matchCounter = 0;
            int result = 0;
            int k = 0;

            if (firstArray.Length <= secondArray.Length)
            {
                string[] minArray = new string[firstArray.Length];
                minArray = firstArray;
                string[] maxArray = new string[secondArray.Length];
                maxArray = secondArray;
                result = CheckMatch(minArray, maxArray, matchCounter, k);
            }
            else
            {
                string[] minArray = new string[secondArray.Length];
                minArray = secondArray;
                string[] maxArray = new string[firstArray.Length];
                maxArray = firstArray;
                result = CheckMatch(minArray, maxArray, matchCounter, k);

            }
            Console.WriteLine(result);

        }

        private static int CheckMatch(string[] minArray, string[] maxArray, int matchCounter, int k)
        {
            if (minArray[0] == maxArray[0])
            {
                for (int i = 0; i < minArray.Length; i++)
                {
                    if (minArray[i] == maxArray[i])
                    {
                        matchCounter++;
                    }
                }
                return matchCounter;
            }
            else if (minArray[minArray.Length - 1] == maxArray[maxArray.Length - 1])
            {
                for (int j = minArray.Length - 1; j >= 0; j--)
                {
                    if (minArray[minArray.Length - 1 - k] == maxArray[maxArray.Length - 1 - k])
                    {
                        matchCounter++;
                        k++;
                    }
                }
                return matchCounter;
            }
            else
            {
                return 0;
            }
        }
    }
}
