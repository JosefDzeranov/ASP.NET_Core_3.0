using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Models
{
    public class FavoriteProductViewModel
    {
        public int Id { get; set; } 
        public string UserId { get; set; }
        public List <ProductViewModel> FavoriteProducts { get; set; }
    }
}
