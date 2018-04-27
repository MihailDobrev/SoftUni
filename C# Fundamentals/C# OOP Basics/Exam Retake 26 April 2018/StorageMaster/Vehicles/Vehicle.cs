using StorageMaster.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> trunkWithProducts;
        protected Vehicle(int capacity)
        {
            trunkWithProducts = new List<Product>();
            Capacity = capacity;
        }

        public int Capacity { get; protected set; }

        public IReadOnlyCollection<Product> Trunk => trunkWithProducts.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public string Type => this.GetType().Name;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunkWithProducts.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            Product lastProduct = trunkWithProducts[trunkWithProducts.Count - 1];
            this.trunkWithProducts.RemoveAt(trunkWithProducts.Count - 1);
            return lastProduct;
        }
    }
}
