using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Db.Models
{
    public class OrderDataViewModel
    {
        public Guid Id { get; set; }
        public CartViewModel Cart { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

    
    }

}
