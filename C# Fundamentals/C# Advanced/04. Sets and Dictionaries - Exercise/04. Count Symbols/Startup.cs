namespace _04.Count_Symbols
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<char, int> characterRecords = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (!characterRecords.ContainsKey(letter))
                {
                    characterRecords[letter]= 1;
                }
                else
                {
                    characterRecords[letter]++;
                }
            }

            foreach (var charRecord in characterRecords.OrderBy(rec=>rec.Key))
            {
                Console.WriteLine($"{charRecord.Key}: {charRecord.Value} time/s");
            }
        }
    }
}
