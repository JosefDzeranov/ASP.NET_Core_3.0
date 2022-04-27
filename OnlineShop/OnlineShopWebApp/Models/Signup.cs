using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Please, enter your Firstname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The name shouldn't be less than 2 and more than 25 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter your Lastname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The name shouldn't be less than 2 and more than 25 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is not specified.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm a password.")]
        [Compare("Password", ErrorMessage = "Рasswords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}
