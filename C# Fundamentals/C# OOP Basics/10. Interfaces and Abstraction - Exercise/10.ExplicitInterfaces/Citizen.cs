namespace _10.ExplicitInterfaces
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IPerson.GetName() => Name;

    }
}
