using System.Linq;
using System.Collections.Generic;
using System;
using OnlineShop.db.Models;
using OnlineShop.db;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int? Id { get; set; }
        //public string Name { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        
        public UserViewModel User { get; set; }

        public OrderStatusViewModel Status { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }

        public OrderViewModel()
        {
            Status = OrderStatusViewModel.Created;
            CreateDateTime = DateTime.Now;
            CartItems = new List<CartItemViewModel>();
        }

        public decimal Cost => CartItems.Sum(x => x.Cost);
    }
}
