namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string gender, int age, string name) 
            : base(gender, age, name)
        {
            Gender = "Male";
        }

        public override string ProduceSound() => "MEOW";

    }
}
