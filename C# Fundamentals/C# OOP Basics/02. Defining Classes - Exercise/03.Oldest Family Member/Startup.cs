using System;

    public class Startup
    {
        public static void Main()
        {

            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int line = 0; line < numberOfPeople; line++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name,age);
                family.AddMember(person);
            }

            Person olderstPerson = family.GetOldestMember();
            Console.WriteLine($"{olderstPerson.name} {olderstPerson.age}");
        }
    }

