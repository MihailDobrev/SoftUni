namespace _03.WildFarm.Animals.Mammals.Felines
{
    using System;
    using System.Linq;
	
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(string food, double quantity)
        {
            string[] foodAllowed = new string[] { "Meat", "Vegetable" };

            if (foodAllowed.All(f => f != food))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }
            Weight += quantity * 0.3;
            FoodEaten += (int)quantity;
        }

        public override string ProduceSound() => "Meow";
    }
}
