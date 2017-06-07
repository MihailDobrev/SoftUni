
namespace Master_Numbers
{
    using System;

    public class MasterNumbers
    {
        static void Main()
        {
            string numberAsText = Console.ReadLine();

            int number = Convert.ToInt32(numberAsText);
            CheckNumbers(number);

        }

        private static void CheckNumbers(int number)
        {

            for (int nextNum = 1; nextNum <= number; nextNum++)
            {
                bool isPalindrome = IsPalindrome(nextNum);
                bool isDivisible = IsDivisible(nextNum);
                bool hasAtLeastOneEvenDigit = HasAtLeastOneEvenDigit(nextNum);

                if (isPalindrome && isDivisible && hasAtLeastOneEvenDigit)
                {
                    Console.WriteLine(nextNum);
                }
            }
        }

        private static bool HasAtLeastOneEvenDigit(int nextNum)
        {
            int digit = 0;
            while (nextNum > 0)
            {
                digit = nextNum % 10;
                if (digit % 2 == 0)
                {
                    return true;
                }
                nextNum = nextNum / 10;
            }
            return false;
        }

        private static bool IsDivisible(int nextNum)
        {

            int sum = 0;
            while (nextNum > 0)
            {
                sum += nextNum % 10;
                nextNum = nextNum / 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPalindrome(int num)
        {
            string digits = "" + num;
            for (int i = 0; i < digits.Length / 2; i++)
            {
                if (digits[i] != digits[digits.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
