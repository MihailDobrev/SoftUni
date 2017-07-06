namespace _01.Censorship
{
    using System;
    using System.Text.RegularExpressions;
    public class Censorship
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string sentence = Console.ReadLine();
            string pattern = $@"{word}";
            int length = word.Length;
            string replacement = new string('*', length);

            Regex regex = new Regex(pattern);
            string cesored = regex.Replace(sentence, replacement);
            Console.WriteLine(cesored);
        }
    }
}
