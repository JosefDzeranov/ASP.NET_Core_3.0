using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class DeliveryInfoViewModel
    {
        public Guid Id { get; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "Адрес должен содержать от 8-х до 128-ми символов")]
        public AddressViewModel Address { get; set; }

        public DeliveryInfoViewModel() 
        { 
        
        }
    }
}