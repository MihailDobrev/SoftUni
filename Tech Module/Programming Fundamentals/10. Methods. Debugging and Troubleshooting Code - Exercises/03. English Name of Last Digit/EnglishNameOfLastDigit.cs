

namespace English_Name_of_Last_Digit
{
    using System;

    public class EnglishNameOfLastDigit
    {
        static void Main()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string n = Console.ReadLine();
            Console.WriteLine(digits[int.Parse(n[n.Length - 1].ToString())]);
        }
    }
}
