namespace _04.Opinion_Poll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
       public static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int line = 0; line < numberOfPeople; line++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            var olderstPeople = people.Where(x => x.age > 30).OrderBy(x => x.name).ToList();

            foreach (var oldPerson in olderstPeople)
            {
                Console.WriteLine($"{oldPerson.name} - {oldPerson.age}");
            }
        }
    }
}
