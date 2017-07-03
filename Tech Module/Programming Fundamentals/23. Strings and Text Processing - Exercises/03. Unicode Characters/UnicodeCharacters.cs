namespace _03.Unicode_Characters
{
    using System;
    using System.Collections.Generic;
    class UnicodeCharacters
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<string> unicodeSequence = new List<string>();
            foreach (var character in input)
            {
                string unicodeSymbols = "\\u" + ((int)character).ToString("X4");
                unicodeSequence.Add(unicodeSymbols.ToLower());
            }
            Console.WriteLine(string.Join("", unicodeSequence));
        }
    }
}
