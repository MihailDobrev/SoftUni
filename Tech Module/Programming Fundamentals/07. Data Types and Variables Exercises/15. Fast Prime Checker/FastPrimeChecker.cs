
namespace _15.Fast_Prime_Checker
{
    using System;

    public class FastPrimeChecker
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 2; i <= number; i++)
            {
                bool prime = true;

                for (int k = 2; k <= Math.Sqrt(i); k++)
                {
                    if (i % k == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                
                Console.WriteLine($"{i} -> {prime}");
            }

        }
    }
}
