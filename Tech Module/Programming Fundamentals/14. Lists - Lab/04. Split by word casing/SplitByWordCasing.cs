namespace _4.Split_by_word_casing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SplitByWordCasing
    {
        static void Main()
        {
            char[] delimiters = new char[] {',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' '};
            var input = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x)
                .ToArray();
            var lowerCase = new List<string>();
            var upperCase = new List<string>();
            var mixesCase = new List<string>();
            int lowerCaseCounter = 0;
            int upperCaseCounter = 0;

            for (int j = 0; j < input.Length; j++)
            {
                string[] words = input[j]
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x)
                    .ToArray();
                for (int i = 0; i < words.Length; i++)
                {
                    char[] letters = words[i].ToCharArray();
                    for (int k = 0; k < letters.Length; k++)
                    {
                        if (char.IsLower(letters[k]))
                        {
                            lowerCaseCounter++;
                        }
                        else if (char.IsUpper(letters[k]))
                        {
                            upperCaseCounter++;
                        }

                    }
                    if (lowerCaseCounter == words[i].Length)
                    {
                        lowerCase.Add(words[i]);
                    }
                    else if (upperCaseCounter == words[i].Length)
                    {
                        upperCase.Add(words[i]);
                    }
                    else
                    {
                        mixesCase.Add(words[i]);
                    }
                    lowerCaseCounter = 0;
                    upperCaseCounter = 0;
                }
            }
            string cases = string.Empty;
            PrintCases("Lower-case: ", lowerCase);
            PrintCases("Mixed-case: ", mixesCase);
            PrintCases("Upper-case: ", upperCase);

        }
        private static void PrintCases(string cases, List<string> casesList)
        {
            Console.Write(cases);
            
            Console.Write(string.Join(", ",casesList));
            
            Console.WriteLine();
        }
    }
}
