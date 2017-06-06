namespace Sign_of_Integer_Number
{
    using System;
    class SignofIntegerNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintSign(n);
        }

        private static void PrintSign(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
