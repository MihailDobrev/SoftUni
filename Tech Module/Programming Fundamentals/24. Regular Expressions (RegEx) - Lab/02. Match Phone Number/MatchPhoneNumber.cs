namespace _2.Match_Phone_Number
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class MatchPhoneNumber
    {
        static void Main()
        {
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            var phones = Console.ReadLine();
            var phoneMatches = Regex.Matches(phones, pattern);
            var matchedPhones = phoneMatches.Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
