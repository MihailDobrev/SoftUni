

namespace Factorial
{
    using System;
    using System.Numerics;

    public class Factorial
    {
        static void Main()
        {
            short num = short.Parse(Console.ReadLine());
            CalculateFactorial(num);

        }

        private static void CalculateFactorial(short num)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
