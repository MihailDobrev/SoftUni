namespace _10.Group_by_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                List<string> inputArgs = input.Split().ToList();

                Person person = new Person()
                {
                    Name = inputArgs[0]+" "+inputArgs[1],
                    Group = int.Parse(inputArgs[2])
                };
                people.Add(person);
                input = Console.ReadLine();
            }

            var groupedPeople=people.GroupBy(
                p=>p.Group,p=>p.Name).OrderBy(x=>x.Key);

            foreach (var group in groupedPeople)
            {
                Console.Write(group.Key+" - ");

                Console.WriteLine(string.Join(", ",group));
            }
        }
    }
}
