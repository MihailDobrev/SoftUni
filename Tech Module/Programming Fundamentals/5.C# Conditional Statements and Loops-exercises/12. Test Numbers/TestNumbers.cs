

namespace _12.Test_Numbers
{
    using System;

    public class TestNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSumBoundary = int.Parse(Console.ReadLine());
            int sum =0;
            int combinationsCounter = 0;

            for (int firstDigit = n; firstDigit >= 1; firstDigit--)
            {
                for (int secondDigit = 1; secondDigit <= m; secondDigit++)
                {
                    sum += firstDigit * secondDigit * 3;
                    combinationsCounter++;
                    if (sum>maxSumBoundary)
                    {
                        break;
                    }
                }
                if (sum > maxSumBoundary)
                {
                    break;
                }
            }
            if (sum>=maxSumBoundary)
            {
                Console.WriteLine($"{combinationsCounter} combinations");
                Console.WriteLine($"Sum: {sum} >= {maxSumBoundary}");
            }
            else
            {
                Console.WriteLine($"{combinationsCounter} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
            
        }
    }
}
