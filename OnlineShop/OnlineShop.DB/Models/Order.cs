using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DB.Models
{
    public class Order
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public OrderStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

}
