using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IFavorites
    {
        public List<Product> Products { get; }

        public void AddProduct(Product product);


        public List<Product> GetProducts();
        

    }
}