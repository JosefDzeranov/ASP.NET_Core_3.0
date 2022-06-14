namespace OnlineShop.Db.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public CartItem()
        {

        }
        public CartItem(Product product)
        {
            Product = product;
            Count = 1;
        }

    }
}
