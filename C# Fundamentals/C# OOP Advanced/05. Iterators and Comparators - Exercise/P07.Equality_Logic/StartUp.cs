namespace P07.Equality_Logic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> sortedPeople = new SortedSet<Person>();

            int totalPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalPeople; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split();
                people.Add(new Person(peopleInfo[0], int.Parse(peopleInfo[1])));
                sortedPeople.Add(new Person(peopleInfo[0], int.Parse(peopleInfo[1])));
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
