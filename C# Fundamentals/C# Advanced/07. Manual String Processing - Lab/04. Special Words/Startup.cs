namespace _04.Special_Words
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] text = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordTracker = new Dictionary<string, int>();            

            foreach (string specialWord in words)
            {
                wordTracker.Add(specialWord, 0);

                foreach (string word in text)
                {
                    if (specialWord==word)
                    {
                        wordTracker[specialWord] += 1;
                    }
                }
            }

            foreach (var pair in wordTracker)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
