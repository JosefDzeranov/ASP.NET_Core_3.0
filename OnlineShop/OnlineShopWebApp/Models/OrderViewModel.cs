using OnlineShop.DB;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<CartViewModel> Carts { get; set; } = new List<CartViewModel>();
        public DeliveryInfoModelView DeliveryInfo { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public OrderViewModel(CartViewModel cart, DeliveryInfoModelView deliveryInfo)
        {
            
            CreatedDate = DateTime.Now;
            Carts.Add(cart);
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }

        public OrderViewModel() { }

    }
}
