

namespace OnlineShop.db.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public Cart Cart { get; set; }

        public int Amount { get; set; }

        public decimal Cost => Amount * this.Product.Cost;
    }
}
