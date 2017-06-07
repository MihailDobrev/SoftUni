
namespace Fibonacci_Numbers
{
    using System;

    public class FibonacciNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int fabunaciNumber = CalculateFibonacciNumbers(n);

            Console.WriteLine(fabunaciNumber);
        }

        private static int CalculateFibonacciNumbers(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i <= n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
