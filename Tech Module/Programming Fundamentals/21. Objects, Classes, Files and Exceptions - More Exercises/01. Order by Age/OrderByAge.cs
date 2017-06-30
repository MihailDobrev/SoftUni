namespace _01.Order_by_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class OrderByAge
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();
            while (input!="End")
            {
                var personInfo = input.Split();
                Person person = new Person()
                {
                    Name = personInfo[0],
                    ID = personInfo[1],
                    Age = int.Parse(personInfo[2])
                };
                people.Add(person);
                input = Console.ReadLine();
            }

            foreach (var person in people.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

    }
}
