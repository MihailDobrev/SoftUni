namespace Primes_in_Given_Range
{
    using System;
    using System.Collections.Generic;

    public class PrimesInGivenRange
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            List<int> primeNumbers = new List<int>();

            if (secondNumber>firstNumber)
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    bool prime = isPrime(i);

                    if (prime)
                    {
                        primeNumbers.Add(i);
                    }
                }
                Console.WriteLine(string.Join(", ", primeNumbers.ToArray()));
            }
            
           
        }

        public static bool isPrime(int number)
        {
            
            if (number == 1 || number==0) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
    }
}
