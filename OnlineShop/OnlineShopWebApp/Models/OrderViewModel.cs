﻿using OnlineShop.DB;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public DeliveryInfoModelView DeliveryInfo { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public OrderViewModel(List<CartItemViewModel> items, DeliveryInfoModelView deliveryInfo)
        {
            
            CreatedDate = DateTime.Now;
            Items = items;
            DeliveryInfo = deliveryInfo;
            Status = OrderStatus.Processing;
        }

        public OrderViewModel() { }

    }
}
