namespace _07.FoodShortage
{
    using _07.FoodShortage.Interfaces;

    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; set; }

        public int Food { get; set; }

        public int BuyFood() => this.Food + 10;
    }
}
