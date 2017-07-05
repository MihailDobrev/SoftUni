namespace _08.Use_Your_Chains__Buddy
{
    using System;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        static void Main()
        {
            string patternBetweenTags = @"(<p>)(.+?)(<\/p>)";
            string patternNotLettersAndNums = @"[^a-z0-9]";
            string input = Console.ReadLine();
            string textWithChangedLetters = "";

            var matchesBetweenTags = Regex.Matches(input, patternBetweenTags);

            foreach (Match match in matchesBetweenTags)
            {
                string textBetweenTags = match.Groups[2].Value;

                var regex = new Regex(patternNotLettersAndNums);
                string replacedInput = regex.Replace(textBetweenTags, " ");
                replacedInput = Regex.Replace(replacedInput, @"\s+", " ");
                

                foreach (char letter in replacedInput)
                {
                    if (letter <= 'm' && char.IsLetter(letter))
                    {
                        textWithChangedLetters += (char)(letter + 13);
                    }
                    else if (letter > 'm' && char.IsLetter(letter))
                    {
                        textWithChangedLetters += (char)(letter - 13);
                    }
                    if (char.IsDigit(letter) || letter==' ')
                    {
                        textWithChangedLetters += letter;
                    }
                }
            }
            Console.WriteLine(textWithChangedLetters);
        }
    }
}
