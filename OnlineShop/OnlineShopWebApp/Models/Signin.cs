using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Email is not specified.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a password.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
