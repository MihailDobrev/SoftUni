namespace P06.Strategy_Pattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> nameSortedSet = new SortedSet<Person>(new NameSorter());
            SortedSet<Person> ageSortedSet = new SortedSet<Person>(new AgeSorter());
            int totalPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalPeople; i++)
            {
                string[] personDetails = Console.ReadLine().Split();
                nameSortedSet.Add(new Person(personDetails[0],int.Parse(personDetails[1])));
                ageSortedSet.Add(new Person(personDetails[0], int.Parse(personDetails[1])));             
            }
            PrintCollection(nameSortedSet);
            PrintCollection(ageSortedSet);

        }

        private static void PrintCollection(SortedSet<Person> collection)
        {
            foreach (var person in collection)
            {
                Console.WriteLine(person);
            }
        }
    }
}
