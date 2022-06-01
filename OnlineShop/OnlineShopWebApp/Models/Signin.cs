using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class SignIn
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
