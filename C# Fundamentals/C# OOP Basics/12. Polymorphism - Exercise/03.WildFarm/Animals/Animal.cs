namespace _03.WildFarm
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }
     
        public abstract string ProduceSound();

        public abstract void EatFood(string food, double quantity);
       
    }
}
