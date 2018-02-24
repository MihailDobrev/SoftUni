namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string gender, int age, string name)
            : base(gender, age, name)
        {
        }
      
        public override string ProduceSound() => "Meow meow";

       
    }
}
