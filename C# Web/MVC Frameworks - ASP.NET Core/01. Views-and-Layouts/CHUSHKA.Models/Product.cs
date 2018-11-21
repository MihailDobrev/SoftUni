using CHUSHKA.Models.Enums;
using System;
using System.Collections.Generic;

namespace CHUSHKA.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
