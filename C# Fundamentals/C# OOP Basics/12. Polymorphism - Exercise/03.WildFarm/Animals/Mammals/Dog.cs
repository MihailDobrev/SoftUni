namespace _03.WildFarm.Animals.Mammals
{
    using System;
    using System.Linq;
	
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            string[] foodAllowed = new string[] { "Meat" };

            if (foodAllowed.All(f => f != food))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }
            Weight += quantity * 0.4;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "Woof!";

        public override string ToString() => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
