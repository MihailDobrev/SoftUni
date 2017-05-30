
namespace _7.Divisible_by_3
{
    using System;
    public class Divisibleby3
    {
        static void Main()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
