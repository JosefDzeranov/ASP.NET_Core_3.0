using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class FavoritesManager : IFavorites
    {

        public List<ProductViewModel> products = new List<ProductViewModel>();
        public List<ProductViewModel> Products
        {
            get
            {
                return products;
            }
        }
        public void AddProduct(ProductViewModel product)
        {
            Products.Add(product);
        }

        public List<ProductViewModel> GetProducts()
        {
            return Products;
        }

    }
}