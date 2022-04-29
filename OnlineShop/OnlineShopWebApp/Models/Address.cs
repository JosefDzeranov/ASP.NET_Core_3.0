using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Address
    {
        [Required(ErrorMessage = "Enter your zip code.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter your country name.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter your city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your street name.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Enter your house number.")]
        public string House { get; set; }

        [Required(ErrorMessage = "Enter your apartment number.")]
        public string Apartment { get; set; }

        public Address() { } // Empty ctor for XML serializing.
    }
}