namespace _03.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            Weight += quantity*0.35;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "Cluck";
    }
}
