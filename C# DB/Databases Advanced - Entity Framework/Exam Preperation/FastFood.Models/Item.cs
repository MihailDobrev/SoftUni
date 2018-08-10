namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Item
    {
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}