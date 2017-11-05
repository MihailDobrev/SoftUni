namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            input = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (input!="search")
            {
                string[] records = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = records[0];
                string number = records[1];

                phonebook[name] = number;
               
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                input = Console.ReadLine();
            }
        }
    }
}
