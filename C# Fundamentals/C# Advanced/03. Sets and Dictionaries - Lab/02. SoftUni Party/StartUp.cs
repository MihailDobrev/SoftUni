namespace _02.SoftUni_Party
{
	using System;
	using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;
            SortedSet<string> guests = new SortedSet<string>();
            input = Console.ReadLine();

            while (input != "PARTY")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                guests.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
