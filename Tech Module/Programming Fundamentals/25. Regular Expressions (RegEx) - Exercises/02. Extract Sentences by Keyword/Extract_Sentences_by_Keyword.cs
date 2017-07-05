namespace _02.Extract_Sentences_by_Keyword
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractSentencesByKeyword
    {
        static void Main()
        {
            string keyword = Console.ReadLine().Trim();
            var sentences = Console.ReadLine()
                .Split(new char[] { '!', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"\b" + keyword + @"\b";

            foreach (var sentence in sentences)
            {
                var regex = new Regex(pattern);

                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }

            }
        }
    }
}
