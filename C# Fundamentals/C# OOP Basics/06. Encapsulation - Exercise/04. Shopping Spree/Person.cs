using System;
using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty || value==" ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }


        public string BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Bag.Add(product);
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }
    }

