using System;

namespace OnlineShop.Db.Models
{
    public class DeliveryInfo
    {
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
