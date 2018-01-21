namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    public class Startup
    {
        static void Main()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];

                if (!people.ContainsKey(name))
                {
                    people[name] = new Person();
                }
                switch (inputArgs[1])
                {
                    case "company":
                        string companyName = inputArgs[2];
                        string department = inputArgs[3];
                        decimal salary = decimal.Parse(inputArgs[4]);
                        people[name].Company.Name = companyName;
                        people[name].Company.Department = department;
                        people[name].Company.Salary = salary;
                        break;
                    case "pokemon":
                        string pokemonName = inputArgs[2];
                        string pokemonType = inputArgs[3];
                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        people[name].Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        string parentName = inputArgs[2];
                        string parentBirthday = inputArgs[3];
                        Parent parent = new Parent(parentName, parentBirthday);
                        people[name].Parents.Add(parent);
                        break;
                    case "children":
                        string childName = inputArgs[2];
                        string childBirthday = inputArgs[3];
                        Child child = new Child(childName, childBirthday);
                        people[name].Children.Add(child);
                        break;
                    case "car":
                        string carModel = inputArgs[2];
                        int carSpeeed = int.Parse(inputArgs[3]);
                        people[name].Car.Model = carModel;
                        people[name].Car.Speed = carSpeeed;
                        break;
                    default:
                        break;
                }
            }

            string personToDisplay = Console.ReadLine().Trim();
            Person person = people[personToDisplay];

            if (person != null)
            {
                Console.WriteLine(personToDisplay);
                Console.WriteLine(person.ToString());
            }
        }
    }
}
