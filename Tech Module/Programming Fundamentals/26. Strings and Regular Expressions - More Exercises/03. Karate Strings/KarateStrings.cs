namespace _03.Karate_Strings
{
    using System;
    using System.Linq;

    public class KarateStrings
    {
        static void Main()
        {
            var input = Console.ReadLine().ToList();
            var punch = '>';
            var punchStrength = 0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                var currentChar = input[i];

                if (currentChar != punch)
                {
                    continue;
                }

                punchStrength += input[i + 1] - 48;
                punchStrength = Math.Min(punchStrength, input.Count - 1 - i);

                while (punchStrength > 0)
                {
                    var count = 1;

                    if (input[i + count] != punch)
                    {
                        input.RemoveAt(i + count);
                    }
                    else
                    {
                        break;
                    }

                    punchStrength--;
                }
            }
            Console.WriteLine(string.Join("", input));
        }
    }
}
