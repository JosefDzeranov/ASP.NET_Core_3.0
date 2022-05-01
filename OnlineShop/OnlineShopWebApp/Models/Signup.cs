using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class SignUp
    {
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The name shouldn't be less than 2 and more than 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The name shouldn't be less than 2 and more than 25 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
