namespace _01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = numbers[0];
            int finish = numbers[1];

            Thread thread = new Thread(() => PrintEvenNumvers(start, finish));

            thread.Start();
            thread.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumvers(int start, int finish)
        {
            for (int num = start; num <= finish; num++)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
