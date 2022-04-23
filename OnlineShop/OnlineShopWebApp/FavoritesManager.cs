using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class FavoritesManager : IFavorites
    {

        public List<Product> products = new List<Product>();
        public List<Product> Products
        {
            get
            {
                return products;
            }
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

    }
}