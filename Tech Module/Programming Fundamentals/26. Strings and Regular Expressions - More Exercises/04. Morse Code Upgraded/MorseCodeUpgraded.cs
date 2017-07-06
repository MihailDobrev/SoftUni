namespace _04.Morse_Code_Upgraded
{
    using System;
    using System.Text.RegularExpressions;
    public class MorseCodeUpgraded
    {
        static void Main()
        {
            string[] codes = Console.ReadLine().Split('|');
            string pattern = @"(00+|11+)";
            int sum = 0;
            char letter;
            string word = "";

            foreach (var code in codes)
            {
                foreach (var character in code)
                {
                    if (character == '0')
                    {
                        sum += 3;
                    }
                    else if (character == '1')
                    {
                        sum += 5;
                    }
                }
                var matches = Regex.Matches(code, pattern);

                foreach (Match match in matches)
                {
                    string numberWithEqualDigits = match.Groups[1].Value;
                    sum += numberWithEqualDigits.Length;
                }
                letter = (char)sum;
                word += letter;
                sum = 0;
            }
            Console.WriteLine(word);
        }
    }
}
