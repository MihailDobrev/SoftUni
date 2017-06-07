namespace Equal_Sums
{
    using System;
    using System.Linq;
    public class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;
            bool found = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }

                for (int k = i; k >= 0; k--)
                {
                    leftSum += numbers[k];
                }
                if (leftSum==rightSum)
                {
                    found = true;
                    Console.WriteLine(i);
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }

            if (!found)
            {
                Console.WriteLine("no");
            }
         
        }
    }
}
