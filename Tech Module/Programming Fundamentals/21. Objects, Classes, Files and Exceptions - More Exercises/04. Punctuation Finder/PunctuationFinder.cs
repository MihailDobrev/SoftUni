namespace _04.Punctuation_Finder
{
    using System.Collections.Generic;
    using System.IO;
    public class PunctuationFinder
    {
        static void Main()
        {
            var textInFile = File.ReadAllText("sample_text.txt");
            List<char> characters = new List<char>();

            foreach (var character in textInFile)
            {
                if (character == '.' ||
                    character == ',' ||
                    character == ':' ||
                    character == '?' ||
                    character == '!')
                {
                    characters.Add(character);
                }
            }

            string text = string.Join(", ", characters);
            File.WriteAllText("output.txt", text);
        }
    }
}
