namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string gender, int age, string name) 
            : base(gender, age, name)
        {
        }

        public override string ProduceSound() => "Ribbit";
    
    }
}
