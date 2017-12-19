namespace _01.Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^[A-Z][a-z]+ [A-Z][a-z]+$";

            Regex regex = new Regex(pattern);

            while (input!="end")
            {
                if (regex.Match(input).Success)
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
