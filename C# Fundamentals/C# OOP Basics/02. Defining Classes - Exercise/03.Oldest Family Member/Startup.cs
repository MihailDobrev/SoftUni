using System;
using System.Reflection;

namespace _03.Oldest_Family_Member
{
    public class Startup
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int line = 0; line < numberOfPeople; line++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person person = new Person();
                person.name = name;
                person.age = age;


                family.AddMember(person);
            }

            Person olderstPerson = family.GetOldestMember();
            Console.WriteLine($"{olderstPerson.name} {olderstPerson.age}");
        }
    }
}
