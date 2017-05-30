


namespace _12.Number_checker
{
    using System;
    public class NumberChecker
    {
        static void Main()
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
