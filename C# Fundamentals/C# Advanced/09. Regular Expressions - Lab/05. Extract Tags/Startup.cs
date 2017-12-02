namespace _05.Extract_Tags
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"<.+?>";
            Regex regex = new Regex(pattern);

            while (input!="END")
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
