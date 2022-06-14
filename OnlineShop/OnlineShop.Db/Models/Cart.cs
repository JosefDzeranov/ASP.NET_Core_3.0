using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public string BuyerLogin { get; set; }

        public List<CartItem> CartItems = new List<CartItem>();

        public UserDeleveryInfo UserDeleveryInfo = new UserDeleveryInfo();
        public decimal FullSumm { get; set; }
    }
}
