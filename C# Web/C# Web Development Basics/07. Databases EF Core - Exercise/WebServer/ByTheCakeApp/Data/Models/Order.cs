namespace WebServer.ByTheCakeApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
  
    }
}
