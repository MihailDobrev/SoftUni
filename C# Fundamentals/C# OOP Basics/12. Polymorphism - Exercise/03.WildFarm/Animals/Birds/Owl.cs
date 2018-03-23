namespace _03.WildFarm.Animals.Birds
{
    using System;
    using System.Linq;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            string[] foodAllowed = new string[] { "Meat" };

            if (foodAllowed.All(f=>f!=food))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }
            Weight += quantity * 0.25;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "Hoot Hoot";
    }
}
