using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Delivery
    {
        public Address Address { get; set; }

        [Required(ErrorMessage = "Enter your phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }

        public Delivery() { } // Empty ctor for XML serializing.
    }
}
