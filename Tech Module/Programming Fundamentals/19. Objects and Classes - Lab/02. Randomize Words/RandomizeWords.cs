

namespace _2.Randomize_Words
{
    using System;
    using System.Linq;

    public class RandomizeWords
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(x => x)
                .ToArray();

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int random = rnd.Next(0, input.Length);
                int secondRandom = rnd.Next(0, input.Length);
                string changer = input[random];
                input[random] = input[secondRandom];
                input[secondRandom] = changer;
               
                
            }
            Console.WriteLine(string.Join("\r\n",input));
        }
    }
}
