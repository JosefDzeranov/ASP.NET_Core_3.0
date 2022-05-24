using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class DeliveryInfoViewModel
    {
        public AddressViewModel Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DeliveryInfoViewModel() { } // Empty ctor for XML serializing. 
    }
}
