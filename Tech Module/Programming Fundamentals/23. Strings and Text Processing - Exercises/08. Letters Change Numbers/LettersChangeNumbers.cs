namespace _08.Letters_Change_Numbers
{
    using System;
    public class LettersChangeNumbers
    {
        static void Main()
        {
            var stringSequence = Console.ReadLine().Split(new char[] { ' ','\t' },StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (var sequence in stringSequence)
            {
                int firstLetter = sequence[0];
                int secondLetter = sequence[sequence.Length - 1];
                string numberAsString = "";
                
                for (int i = 1 ; i < sequence.Length-1; i++)
                {
                    numberAsString += sequence[i];
                }

                double number = double.Parse(numberAsString);
               

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    number /= firstLetter-64;
                }
                else if(firstLetter >= 97 && firstLetter <= 122)
                {
                    number *= firstLetter - 96;
                }
                

                if (secondLetter >= 65 && secondLetter <= 90)
                {
                    number -= secondLetter - 64;
                }
                else if (secondLetter >= 97 && secondLetter <= 122)
                {
                    number += secondLetter - 96;
                }
                sum += number;
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
