namespace _03.WildFarm.Animals.Mammals
{
    using System;
    using System.Linq;
	
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            string[] foodAllowed = new string[] { "Vegetable", "Fruit" };

            if (foodAllowed.All(f => f != food))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }

            Weight += quantity * 0.1;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "Squeak";

        public override string ToString() => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
