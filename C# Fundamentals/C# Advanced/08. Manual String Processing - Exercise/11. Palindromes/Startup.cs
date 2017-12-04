namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' },StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> palindomes = new SortedSet<string>();

            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                char[] wordToCharArray = word.ToCharArray();
                Array.Reverse(wordToCharArray);
                string reversed = new string(wordToCharArray);

                if (word==reversed)
                {
                    palindomes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ",palindomes)}]");
        }
    }
}
