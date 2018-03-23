namespace _03.WildFarm.Animals.Mammals.Felines
{
    using System;
    using System.Linq;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            string[] foodAllowed = new string[] { "Meat" };

            if (foodAllowed.All(f => f != food))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }

            Weight += quantity * 1;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "ROAR!!!";
    }
}
