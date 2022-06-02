using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public List<CartItem> CartItems { get; set; }


    }
}
