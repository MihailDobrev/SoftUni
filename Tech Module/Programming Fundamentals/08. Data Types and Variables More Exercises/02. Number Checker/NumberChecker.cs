
namespace Number_Checker
{
    using System;

    public class NumberChecker
    {
        static void Main()
        {
            double input = double.Parse(Console.ReadLine());

            if (input % 1 == 0)
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
