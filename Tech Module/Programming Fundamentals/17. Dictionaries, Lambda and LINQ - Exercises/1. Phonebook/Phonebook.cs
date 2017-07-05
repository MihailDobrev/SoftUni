namespace _1.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main()
        {
            var input = new List<string>();

            while (!input.Contains("END"))
            {
                input.AddRange(Console.ReadLine()
                    .Split(' ')
                    .Select(x => Convert.ToString(x))
                    .ToList());
            }

            var dictionary = new Dictionary<string, string>();

            for (int index = 0; index < input.Count; index++)
            {
                if (input[index] == "A")
                {
                    if (!dictionary.ContainsKey(input[index + 1]))
                    {
                        dictionary.Add(input[index + 1], input[index + 2]);
                    }
                    else
                    {
                        dictionary[input[index + 1]] = input[index + 2];
                    }
                }
                else if (input[index] == "S")
                {
                    if (dictionary.ContainsKey(input[index + 1]))
                    {
                        Console.WriteLine($"{input[index + 1]} -> {dictionary[input[index + 1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[index + 1]} does not exist.");
                    }
                }
            }
        }
    }
}
