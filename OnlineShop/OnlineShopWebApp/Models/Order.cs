using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
               
        public string UserId { get; set; }

        public OrderData OrderData { get; set; }
        //public string Name { get; set; }

        //public string Adress { get; set; }

        //public string Email { get; set; }

        public Order(Cart cart, OrderData orderData, string userId)
        {
            Cart = cart;
            OrderData = orderData;
            UserId = userId;
        }
    }

}

