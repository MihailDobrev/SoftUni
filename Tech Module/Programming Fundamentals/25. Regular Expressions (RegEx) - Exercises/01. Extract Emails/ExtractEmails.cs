namespace _01.Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;
    public class ExtractEmails
    {
        static void Main()
        {
            string pattern = @"(?<=\s)[a-z1-9]+(.|_|-)?(\w+)?@[a-z]+(-[a-z]+)?\.[a-z]+(\.[a-z]+)?\b";

            string text = Console.ReadLine();

            var emails = Regex.Matches(text, pattern);

            foreach (Match email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
