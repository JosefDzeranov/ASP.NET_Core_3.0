using System.ComponentModel.DataAnnotations;
using OnlineShopWebApp.Models.Attributes;

namespace OnlineShopWebApp.Models
{
    [NamePasswordEqual]
    public class SignUp
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

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
