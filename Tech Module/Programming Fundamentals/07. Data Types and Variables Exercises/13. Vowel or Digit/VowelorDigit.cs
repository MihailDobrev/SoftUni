namespace _13.Vowel_or_Digit
{
    using System;
    using System.Linq;
    public class VowelorDigit
    {
        static void Main()
        {
            char symbol = char.Parse(Console.ReadLine());

            char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            char[] vowels = { 'a', 'o', 'u', 'e', 'i' };

            if (digits.Contains(symbol))
            {
                Console.WriteLine("digit");
            }
            else if (vowels.Contains(symbol))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
