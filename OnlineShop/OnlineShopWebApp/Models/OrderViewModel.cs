using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public OrderStatusViewModel Status { get; set; }

        public DateTime OrderDate { get; set; }
        public CartViewModel Cart { get; set; }

        public string UserId { get; set; }

        public OrderDataViewModel OrderData { get; set; }
   

        //public OrderViewModel(CartViewModel cart, /*OrderData orderData,*/ string userId)
        //{
        //    Cart = cart;
        //    //OrderData = orderData;
        //    UserId = userId;
        //    OrderDate = DateTime.Now;

        //    Id = Guid.NewGuid();
        //    Status = OrderStatus.Created;


        //}
    }

}

