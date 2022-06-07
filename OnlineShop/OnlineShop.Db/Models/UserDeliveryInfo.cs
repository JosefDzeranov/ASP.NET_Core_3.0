using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
