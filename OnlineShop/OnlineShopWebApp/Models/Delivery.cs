using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Delivery
    {
        public Address Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Delivery() { } // Empty ctor for XML serializing.
    }
}
