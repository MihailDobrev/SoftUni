namespace _04.Extract_Integer_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"\d+");

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
