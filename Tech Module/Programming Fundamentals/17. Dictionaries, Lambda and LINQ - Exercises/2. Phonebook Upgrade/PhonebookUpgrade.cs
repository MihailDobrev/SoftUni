
namespace _2.Phonebook_Upgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookUpgrade
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

            var phonebook = new SortedDictionary<string, string>();

            for (int index = 0; index < input.Count; index++)
            {
                if (input[index] == "A")
                {
                    if (!phonebook.ContainsKey(input[index + 1]))
                    {
                        phonebook.Add(input[index + 1], input[index + 2]);
                    }
                    else
                    {
                        phonebook[input[index + 1]] = input[index + 2];
                    }
                }
                else if (input[index] == "S")
                {
                    if (phonebook.ContainsKey(input[index + 1]))
                    {
                        Console.WriteLine($"{input[index + 1]} -> {phonebook[input[index + 1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[index + 1]} does not exist.");
                    }
                }
                else if (input[index] == "ListAll")
                {
                    foreach (var entry in phonebook)
                    {
                        Console.WriteLine($"{entry.Key} -> {entry.Value}");
                    }
                }
            }
        }
    }
}
