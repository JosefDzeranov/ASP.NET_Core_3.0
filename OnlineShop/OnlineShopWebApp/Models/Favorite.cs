using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
