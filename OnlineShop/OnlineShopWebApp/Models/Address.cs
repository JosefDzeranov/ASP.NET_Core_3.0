using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Address
    {
        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string House { get; set; }

        [Required]
        public string Apartment { get; set; }

        public Address() { } // Empty ctor for XML serializing.
    }
}