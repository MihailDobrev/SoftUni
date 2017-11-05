namespace _07.Fix_emails
{
    using System;
    using System.Collections.Generic;
    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            Dictionary<string, string> emailRecords = new Dictionary<string, string>();

            input = Console.ReadLine();

            while (input!="stop")
            {
                string name = input;
                string email = Console.ReadLine();

                string emailCaseInsensitive = email.ToLower();

                if (!emailCaseInsensitive.EndsWith("us")
                    || emailCaseInsensitive.EndsWith("uk"))
                {
                    emailRecords[name] = email;
                }

                input = Console.ReadLine();
            }

            foreach (var record in emailRecords)
            {
                Console.WriteLine($"{record.Key} -> {record.Value}");
            }
        }
    }
}
