
namespace _11.Odd_Number
{
    using System;
    public class OddNumber
    {
        static void Main()
        {
            int n = 0;

            while (n % 2 == 0)
            {
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                }


            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");
        }
    }
}
