namespace _06.Email_Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class EmailStatistics
    {
        static void Main()
        {
            int numberOfEmails = int.Parse(Console.ReadLine());
            string pattern = @"^([a-zA-Z]{5,})@(([a-z]{3,})\.(com|bg|org))$";
            Dictionary<string, HashSet<string>> emailData = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < numberOfEmails; i++)
            {
                string emailInput = Console.ReadLine();
                var emailMatch = Regex.Match(emailInput, pattern);

                if (emailMatch.Success)
                {
                    string userName = emailMatch.Groups[1].Value;
                    string domainName = emailMatch.Groups[2].Value;

                    if (!emailData.ContainsKey(domainName))
                    {
                        emailData[domainName] = new HashSet<string>();

                    }
                    emailData[domainName].Add(userName);
                }
            }

            foreach (var email in emailData.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{email.Key}:");

                foreach (var name in email.Value)
                {
                    Console.WriteLine($"### {name}");
                }
            }
        }
    }
}

