

namespace BalancedBracke
{
    using System;
    using System.Collections.Generic;

    public class BalancedBrackets
    {
        static void Main()
        {
            byte numberOfLines = byte.Parse(Console.ReadLine());
            bool bracketsÜnmatch = false;
            var lines = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine().Trim();

                if (input == "(" || input == ")")
                {
                    lines.Add(input);
                }
            }
            if (lines.Count % 2 == 0)
            {
                for (int i = 0; i < lines.Count; i += 2)
                {
                    if (!(lines[i] == "(" && lines[i + 1] == ")"))
                    {
                        bracketsÜnmatch = true;
                    }
                }
            }
            else
            {
                bracketsÜnmatch = true;
            }
            
            if (bracketsÜnmatch)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}
