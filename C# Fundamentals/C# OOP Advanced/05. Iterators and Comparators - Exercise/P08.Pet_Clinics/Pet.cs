namespace P08.Pet_Clinics
{
    public class Pet
    {
        public Pet(string name, int age, string kind)
        {
            Name = name;
            Age = age;
            Kind = kind;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Kind { get; private set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Kind}";
        }
    }
}
