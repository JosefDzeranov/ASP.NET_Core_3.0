namespace OnlineShopWebApp.Models
{
    public class CartLine
    {
        int Id;
        public Product Product { get; set; }

        public int Amount { get; set; }


        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }
        }
        public CartLine(Product product)
        {
            Product = product;
        }



    }
}

