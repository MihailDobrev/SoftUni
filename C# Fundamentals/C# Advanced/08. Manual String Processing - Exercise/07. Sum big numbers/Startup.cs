namespace _07.Sum_big_numbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string firstNum = Console.ReadLine();
            string secondNum = Console.ReadLine();

            int maxLen = Math.Max(firstNum.Length, secondNum.Length);

            firstNum = firstNum.PadLeft(maxLen + 1, '0');
            secondNum = secondNum.PadLeft(maxLen + 1, '0');

            int[] firstDigits = firstNum.Select(x => int.Parse(x.ToString())).ToArray();
            int[] secondDigits = secondNum.Select(x => int.Parse(x.ToString())).ToArray();
            int[] sum = new int[firstNum.Length];

            int currentSum = 0;
            for (int i = sum.Length - 1; i >= 0; i--)
            {
                int total = firstDigits[i] + secondDigits[i] + currentSum;
                sum[i] = total % 10;

                if (total > 9)
                {
                    currentSum = 1;
                }
                else
                {
                    currentSum = 0;
                }
            }

            var result = string.Join(string.Empty, sum.SkipWhile(x => x == 0));

            Console.WriteLine(result);
        }
    }
}
