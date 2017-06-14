namespace _2.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class OddOccurence
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .Select(x => Convert.ToString(x))
                .ToList();

            var dictionary = new Dictionary<string, int>();

            var oddKeys = new List<string>();

            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary[word] = 1;
                }
            }

            foreach (var word in dictionary)
            {
                if (word.Value % 2 == 1)
                {
                    oddKeys.Add(word.Key);
                }
            }
            Console.WriteLine(string.Join(", ",oddKeys));
        }
    }
}
