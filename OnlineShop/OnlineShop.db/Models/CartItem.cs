namespace OnlineShop.db.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public virtual Cart? Cart { get; set; }

        public virtual Order? Order { get; set; }

        public int Amount { get; set; }

        public decimal Cost => Amount * this.Product.Cost;
    }
}
