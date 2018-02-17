namespace _05.Pizza_Calories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private int numberOfToppings;

        public int NumberOFToppings
        {
            get { return numberOfToppings; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                numberOfToppings = value;
            }
        }

        public Pizza()
        {
            Toppings = new List<Topping>();
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value;}
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols");
                }
                name = value;
            }
        }

        public double CalculateCalories()
        {
            return this.Toppings.Sum(t => t.CalculateCalories()) + this.Dough.CalculateCalories();
        }

        public void AddTopping(Topping topping)
        { 
            this.Toppings.Add(topping);
        }
    }
}
