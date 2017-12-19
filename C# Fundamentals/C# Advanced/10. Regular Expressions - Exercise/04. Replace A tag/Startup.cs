namespace _04.Replace_A_tag
{
    using System;
    using System.Text.RegularExpressions;
    public class Startup
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            var pattern = @"<a.*href=(""|')(.*)\1>(.*?)<\/a>";

            while (!inputLine.Equals("end"))
            {

                Regex reg = new Regex(pattern);
                var matches = reg.Matches(inputLine);

                inputLine = reg.Replace(inputLine, @"[URL href=""$2""]$3[/URL]");

                Console.WriteLine(inputLine);

                inputLine = Console.ReadLine();
            }

        }
    }
}
