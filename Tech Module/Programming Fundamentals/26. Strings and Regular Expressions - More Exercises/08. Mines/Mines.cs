namespace _08.Mines
{
    using System;
    using System.Text.RegularExpressions;
    public class Mines
    {
        static void Main()
        {
            string pattern = @"<.{2}>";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);

            MatchCollection minebMatches = regex.Matches(input);

            foreach (Match mine in minebMatches)
            {
                int index = mine.Index;
                char firstChar = input[index + 1];
                char secondChar = input[index + 2];
                int minePower = Math.Abs(firstChar - secondChar);
                int destroyIndex = Math.Max(0, index - minePower);
                int destroyBeforeMine = index - destroyIndex;
                int destroyAfterMine = Math.Min(minePower, input.Length - 4 - index);
                int destroyLength = destroyBeforeMine + 4 + destroyAfterMine;
                string replaceString = new string('_', destroyLength);

                input = input.Remove(destroyIndex, destroyLength);
                input = input.Insert(destroyIndex, replaceString);

            }
            Console.WriteLine(input);
        }
    }
}
