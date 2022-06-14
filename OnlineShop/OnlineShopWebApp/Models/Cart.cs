using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public string BuyerLogin { get; set; }

        public List<CartItem> CartItems = new List<CartItem>();

        public UserDeleveryInfo UserDeleveryInfo = new UserDeleveryInfo();
        public decimal FullSumm { get; set; }
    }
}
