namespace _09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            long fabunaciNumber = CalculateFibonacciNumbers(n);

            Console.WriteLine(fabunaciNumber);
        }

        private static long CalculateFibonacciNumbers(long n)
        {
            Stack<long> stack = new Stack<long>();

            long a = 0;
            long b = 1;
            stack.Push(0);
          
            for (int i = 0; i < n; i++)
            {
                long temp = stack.Peek();
                a = b;
                b = temp + b;
                stack.Push(a);
            }
            return stack.Peek();
        }
    }
}
