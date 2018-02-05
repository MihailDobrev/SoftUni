namespace _03._Word_Count
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            using (StreamReader firstReader = new StreamReader("words.txt"))
            {
                using (StreamReader secondReader = new StreamReader("../Resources/text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("result.txt"))
                    {
                        Queue<string> wordsToFind = new Queue<string>();
                        Dictionary<string, int> wordsTimesFound = new Dictionary<string, int>();

                        string input = firstReader.ReadLine();

                        while (input != null)
                        {
                            wordsToFind.Enqueue(input);
                            input = firstReader.ReadLine();
                        }

                        input = secondReader.ReadLine();

                        while (input != null)
                        {
                            for (int i = 0; i < wordsToFind.Count; i++)
                            {
                                string wordToFind = wordsToFind.Dequeue().ToLower();
                                Regex regex = new Regex(@"\b"+wordToFind+ @"\b");
                                int matches = regex.Matches(input.ToLower()).Count;

                                if (!wordsTimesFound.ContainsKey(wordToFind))
                                {
                                    wordsTimesFound[wordToFind] = matches;
                                }
                                else
                                {
                                    wordsTimesFound[wordToFind] += matches;
                                }

                                wordsToFind.Enqueue(wordToFind);
                            }
                            input = secondReader.ReadLine();
                        }

                        foreach (var pair in wordsTimesFound.OrderByDescending(w=>w.Value))
                        {
                            writer.WriteLine($"{pair.Key} - {pair.Value}");
                        }
                    }

                   
                }
            }

        }
    }
}
