namespace _4.Fix_Emails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            string input;

            var records = new Dictionary<string, string>();

            while ((input = Console.ReadLine()) != "stop")
            {

                records[input] = Console.ReadLine();

            }

            foreach (var pair in records)
            {
                if (!pair.Value.EndsWith("us") && !pair.Value.EndsWith("uk"))
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }

            }
        }
    }
}
