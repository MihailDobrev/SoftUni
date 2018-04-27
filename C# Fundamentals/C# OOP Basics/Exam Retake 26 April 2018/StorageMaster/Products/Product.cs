using System;

namespace StorageMaster.Products
{
    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get { return price; }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                price = value;
            }
        }
        public double Weight { get; protected set; }

        public string Name => this.GetType().Name;

    }
}
