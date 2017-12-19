using System;
using System.Text.RegularExpressions;

namespace _02.Match_Phone_Number
{
    public class Startup
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            Regex regex = new Regex(pattern);

            while (inputLine!="end")
            {
                if (regex.Match(inputLine).Success)
                {
                    Console.WriteLine(inputLine);
                }
                inputLine = Console.ReadLine();
            }
        }
    }
}
