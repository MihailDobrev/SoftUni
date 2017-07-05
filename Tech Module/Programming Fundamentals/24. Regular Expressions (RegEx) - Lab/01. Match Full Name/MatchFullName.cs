namespace _1.Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        static void Main()
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string input = Console.ReadLine();
            MatchCollection matchedNames = Regex.Matches(input, pattern);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
