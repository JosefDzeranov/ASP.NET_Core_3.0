using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class Cart
    {
        public static List<Product> addedProducts = new List<Product>();

        public static decimal CartCost
        {
            get
            {

                decimal cartCost = 0;

                foreach (var product in addedProducts)
                {
                    cartCost += product.TotalCost;
                }

                return cartCost;
            }
        }
             

    }
}
