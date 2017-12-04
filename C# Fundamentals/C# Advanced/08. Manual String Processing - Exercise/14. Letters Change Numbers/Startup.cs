namespace _14.Letters_Change_Numbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] stringSequence = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0;

            for (int index = 0; index < stringSequence.Length; index++)
            {
                string text = stringSequence[index];
                char firstLetter = text[0];
                char secondLetter = text[text.Length - 1];
                long number = long.Parse(text.Substring(1, text.Length - 2));
                int firstLetterAlphabetPosition = 0;
                int secondLetterAlphabetPosition = 0;

                if (char.IsUpper(firstLetter))
                {
                    firstLetterAlphabetPosition = firstLetter - 64;
                    totalSum += (double)number / firstLetterAlphabetPosition;
                }
                else if(char.IsLower(firstLetter))
                {
                    firstLetterAlphabetPosition = firstLetter - 96;
                    totalSum += number * firstLetterAlphabetPosition;
                }

                if (char.IsUpper(secondLetter))
                {
                    secondLetterAlphabetPosition = secondLetter - 64;
                    totalSum -= secondLetterAlphabetPosition;
                }
                else if(char.IsLower(secondLetter))
                {
                    secondLetterAlphabetPosition = secondLetter - 96;
                    totalSum += secondLetterAlphabetPosition;
                }
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
