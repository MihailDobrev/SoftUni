
namespace String_Concatenation
{
    using System;
    using System.Collections.Generic;

    public class StringConcatenation
    {
        static void Main()
        {
            string delimiter = Console.ReadLine();
            string evenOrOdd = Console.ReadLine();
            byte numberOfLanes = byte.Parse(Console.ReadLine());
            List<string> strings = new List<string>();

            for (int index = 1; index <= numberOfLanes; index++)
            {
                string input = Console.ReadLine();

                if (index % 2 == 0 && evenOrOdd == "even")
                {
                    strings.Add(input);
                }
                else if (index % 2 == 1 && evenOrOdd == "odd")
                {
                    strings.Add(input);
                }
            }
            Console.WriteLine(string.Join(delimiter, strings.ToArray()));
        }
    }
}
