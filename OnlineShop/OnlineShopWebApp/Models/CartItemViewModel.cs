namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }

        public decimal Cost
        {
            get
            {
                return Product.Cost * Amount; 
            }
        }
    }
}
