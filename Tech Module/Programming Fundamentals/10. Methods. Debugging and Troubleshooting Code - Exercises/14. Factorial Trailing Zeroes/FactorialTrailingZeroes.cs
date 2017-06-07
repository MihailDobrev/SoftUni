
namespace FactorialTrailingZeroes
{
    using System;
    using System.Numerics;
    public class FactorialTrailingZeroes
    {
        static void Main()
        {
            short num = short.Parse(Console.ReadLine());

            BigInteger factorial = CalculateFactorial(num);
            int zeroes = CountZeroes(factorial);
            Console.WriteLine(zeroes);
        }

        private static int CountZeroes(BigInteger factorial)
        {
            string factorialAsText = Convert.ToString(factorial);
            int zeroesCounter = 0;

            while (factorial % 10 == 0)
            {
                zeroesCounter++;
                factorial /= 10;
            }

            return zeroesCounter;
        }

        private static BigInteger CalculateFactorial(short num)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
