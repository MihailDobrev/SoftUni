
namespace Multiply_Evens_by_Odds
{
    using System;

    public class MultiplyEvensByOdds
    {
        static void Main()

        {
            int number = int.Parse(Console.ReadLine());
            int returnedMultipliedSum = MultiplySumAndOddDigits(number);
            Console.WriteLine(returnedMultipliedSum);
        }

        private static int MultiplySumAndOddDigits(int number)
        {
            int sumOfEvenNumbers = 0;
            int sumOfOddNumbers = 0;

            while (Math.Abs(number) > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                {
                    sumOfEvenNumbers += lastDigit;
                }
                else
                {
                    sumOfOddNumbers += lastDigit;
                }
                number /= 10;
            }

            int multipliedEvenAndOddDigits = sumOfEvenNumbers * sumOfOddNumbers;

            return multipliedEvenAndOddDigits;
        }
    }
}
