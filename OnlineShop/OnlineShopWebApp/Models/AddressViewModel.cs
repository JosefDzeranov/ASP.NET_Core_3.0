using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AddressViewModel
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

        public AddressViewModel() { } // Empty ctor for XML serializing.
    }
}