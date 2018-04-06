namespace P05.Comparing_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        private const int totalNumberOfStatistics = 3;
        public static void Main()
        {
            List<Person> people = GetPeople();
            try
            {
                int[] statistics = GetStatistics(people);
                Console.WriteLine(string.Join(" ", statistics));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<Person> GetPeople()
        {
            string input;
            var people = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                people.Add(new Person(args[0], int.Parse(args[1]), args[2]));
            }

            return people;
        }

        private static int[] GetStatistics(List<Person> people)
        {
            int id = int.Parse(Console.ReadLine());
            if (id >= people.Count || id < 0)
            {
                throw new Exception("No matches");
            }
            Person personToCheck = people[id];
            int[] statistics = new int[totalNumberOfStatistics];

            statistics[0] = people.Count(p => personToCheck.CompareTo(p) == 0);
            if (statistics[0] < 2)
            {
                throw new Exception("No matches");
            }
            statistics[1] = people.Count(p => personToCheck.CompareTo(p) != 0);
            statistics[2] = people.Count;

            return statistics;
        }
    }
}
