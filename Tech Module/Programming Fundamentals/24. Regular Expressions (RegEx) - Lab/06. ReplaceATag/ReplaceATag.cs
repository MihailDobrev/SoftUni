namespace _6.ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;
    public class ReplaceATag
    {
      static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replacement = @"[URL href=$1]$2[/URL]";
                string replaced = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(replaced);
            }
        }
    }
}
