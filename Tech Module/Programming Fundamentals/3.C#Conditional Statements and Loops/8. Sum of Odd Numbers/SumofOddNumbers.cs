
namespace _8.Sum_of_Odd_Numbers
{
    using System;
    public class SumofOddNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 1;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(number);
                sum += number;
                number += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
