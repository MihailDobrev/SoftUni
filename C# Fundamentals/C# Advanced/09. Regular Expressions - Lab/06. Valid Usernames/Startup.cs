namespace _06.Valid_Usernames
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input=Console.ReadLine();

            string pattern = @"[\w\d-]{3,16}";

            Regex regex = new Regex(pattern);

            while (input!="END")
            {
                Match match = regex.Match(input);

                if (match.Value==input)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
