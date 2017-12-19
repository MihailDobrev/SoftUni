namespace _05.Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;
    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"(?: )([a-z0-9]+[-._]*[a-z0-9]+@[a-z-]+\.*[a-z-]+\.[a-z]+)";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}
