namespace Rotate_and_Sum
{
    using System;
    using System.Linq;

    public class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int k = int.Parse(Console.ReadLine());
            int indexIncrease = 1;

            int[] rotated = new int[numbers.Length];
            int[] newRotated = new int[numbers.Length];
            int[] sum = new int[numbers.Length];
            int[] initialRotated = new int[numbers.Length];

            rotated[0] = numbers[numbers.Length - 1];
            for (int j = 1; j < numbers.Length; j++)
            {
                rotated[indexIncrease] = numbers[indexIncrease - 1];
                indexIncrease++;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                initialRotated[i] = rotated[i];
            }

            if (k == 1)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    sum[i] = rotated[i];
                }
            }
            if (k > 1)
            {
                indexIncrease = 1;
                for (int i = 2; i <= k; i++)
                {
                    newRotated[0] = rotated[numbers.Length - 1];

                    for (int j = 1; j < numbers.Length; j++)
                    {
                        newRotated[indexIncrease] = rotated[indexIncrease - 1];
                        indexIncrease++;
                    }
                    indexIncrease = 1;
                    for (int m = 0; m < numbers.Length; m++)
                    {
                        sum[m] += newRotated[m];
                    }
                    for (int b = 0; b < numbers.Length; b++)
                    {
                        rotated[b] = newRotated[b];
                    }
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    sum[i] = sum[i] + initialRotated[i];
                }
            }


            foreach (var item in sum)
            {
                Console.Write(item + " ");
            }

        }
    }
}
