namespace Animals.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string gender, int age, string name) 
            : base(gender, age, name)
        {
            Gender = "Female";
        }

        public override string ProduceSound() => "Meow";
    }
}
