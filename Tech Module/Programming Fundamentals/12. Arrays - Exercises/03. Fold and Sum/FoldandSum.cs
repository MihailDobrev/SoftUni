namespace Fold_and_Sum
{
    using System;
    using System.Linq;

    public class FoldandSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var reversed = new int[numbers.Length];
            int counter = numbers.Length - 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                reversed[counter] = numbers[i];
                counter--;
            }

            int[] firstArray = new int[numbers.Length / 2];
            int[] secondArray = new int[numbers.Length / 2];

            counter = 0;
            for (int m = numbers.Length / 4 + numbers.Length / 2; m < numbers.Length; m++)
            {
                firstArray[counter] = reversed[m];
                counter++;
            }

            counter = 0;
            for (int k = numbers.Length / 4; k < numbers.Length / 4 + numbers.Length / 2; k++)
            {
                secondArray[counter] = numbers[k];
                counter++;
            }

            counter = 0;
            for (int j = numbers.Length / 4; j < numbers.Length / 2; j++)
            {
                firstArray[j] = reversed[counter];
                counter++;
            }

            int[] sum = new int[numbers.Length / 2];

            for (int n = 0; n < numbers.Length / 2; n++)
            {
                sum[n] = firstArray[n] + secondArray[n];
            }

            foreach (var number in sum)
            {
                Console.Write(number + " ");
            }


        }
    }
}
