namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string gender, int age, string name)
            : base(gender, age, name)
        {
        }

        public override string ProduceSound() => "Woof!";
       
    }
}
