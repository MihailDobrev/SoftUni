namespace _05.Key_Replacer
{
    using System;
    using System.Text.RegularExpressions;
    public class KeyReplacer
    {
        static void Main()
        {
            string keystring = Console.ReadLine();
            string keyPattern = @"([A-Za-z]+)(<|\||\\)(?:\w+)(<|\||\\)([A-Za-z]+)";

            var keyMatch = Regex.Match(keystring, keyPattern);
            string startKey = keyMatch.Groups[1].Value;
            string endKey = keyMatch.Groups[4].Value;

            string textString = Console.ReadLine();
            string searchPattern = $@"(?<={startKey})(\w*?)(?:{endKey})";

            var textMatches = Regex.Matches(textString, searchPattern);
            string output = string.Empty;

            foreach (Match text in textMatches)
            {
                output += text.Groups[1].Value;
            }

            if (output == string.Empty)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(output);
            }
        }
    }
}
