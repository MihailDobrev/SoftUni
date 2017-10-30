namespace Fibonacci_Numbers
{
    using System;

    public class FibonacciNumbers
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            long fabunaciNumber = CalculateFibonacciNumbers(n);

            Console.WriteLine(fabunaciNumber);
        }

        private static long CalculateFibonacciNumbers(long n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
