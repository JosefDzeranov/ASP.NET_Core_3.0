using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }
        public CartViewModel Cart { get; set; }

        public string UserId { get; set; }

        public OrderData OrderData { get; set; }
   

        public Order(CartViewModel cart, OrderData orderData, string userId)
        {
            Cart = cart;
            OrderData = orderData;
            UserId = userId;
            OrderDate = DateTime.Now;

            Id = Guid.NewGuid();
            Status = OrderStatus.Created;


        }
    }

}

