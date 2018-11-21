using System;

namespace CHUSHKA.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime OrderedOn { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string ClientId { get; set; }
        public virtual User Client { get; set; }
    }
}
