using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.Web.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MinLength(3)]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
    }
}
