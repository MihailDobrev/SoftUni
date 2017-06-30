namespace _04.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Palindromes
    {
        static void Main()
        {
            var text = Console.ReadLine()
                .Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> palindromes = new List<string>();
            foreach (var word in text)
            {
                string revesed = string.Concat(word.Reverse().ToArray());
                if (revesed==word)
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ",palindromes.OrderBy(x=>x).Distinct()));

        }
    }
}
