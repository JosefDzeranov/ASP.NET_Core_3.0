using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {      
        public string Age { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }

    }
}
