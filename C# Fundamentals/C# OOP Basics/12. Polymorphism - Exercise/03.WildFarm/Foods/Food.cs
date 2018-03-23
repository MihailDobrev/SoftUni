namespace _03.WildFarm.Foods
{
    public abstract class Food
    {
        public Food(double quantity)
        {
            Name = $"{this.GetType().Name}";
            Quantity = quantity;
        }

        public string Name { get; set; }

        public double Quantity { get; set; }
    }
}
