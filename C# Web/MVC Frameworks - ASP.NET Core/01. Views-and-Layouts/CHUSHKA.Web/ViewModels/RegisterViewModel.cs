using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} and max {1} characters long", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
