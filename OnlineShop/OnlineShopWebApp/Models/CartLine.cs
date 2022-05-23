namespace OnlineShopWebApp.Models
{
    public class CartLine
    {
        int Id;
        public ProductViewModel Product { get; set; }

        public int Amount { get; set; }


        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }
        }
        public CartLine(ProductViewModel product)
        {
            Product = product;
        }

    }
}

