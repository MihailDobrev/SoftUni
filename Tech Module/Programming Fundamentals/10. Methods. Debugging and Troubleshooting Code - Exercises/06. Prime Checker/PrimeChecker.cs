
namespace Prime_Checker
{
    using System;

    public class PrimeChecker
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
        }

        static bool IsPrime(long n)
        {
            int sqrtN = (int)Math.Sqrt(n);
            if (n <= 1)
            {
                return false;
            }
            else if (n >= 2)
            {
                for (int cnt = 2; cnt <= sqrtN; cnt++)
                {
                    if (n % cnt == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
