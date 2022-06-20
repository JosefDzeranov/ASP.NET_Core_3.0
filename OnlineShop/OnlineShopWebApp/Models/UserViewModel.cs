using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {    
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }   
        public List<Order> Orders { get; set; }
    }
}
