namespace _3.Match_Hexadecimal_Numbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchHexadecimalNumbers
    {
        static void Main()
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";

            string text = Console.ReadLine();

            var matches = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
