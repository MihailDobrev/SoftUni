namespace _5.Match_Numbers
{
    using System;
    using System.Text.RegularExpressions;
  
    public class MatchNumbers
    {
        static void Main()
        {
            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            string numberStrings = Console.ReadLine();

            var numbers = Regex.Matches(numberStrings, regex);

            foreach (Match number in numbers)
            {
                Console.Write(number.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
