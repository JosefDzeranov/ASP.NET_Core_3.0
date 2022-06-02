using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavoritesManager
    {
        //public List<Product> Products { get; }
        public List<Product> GetProducts(string userId);
        public void AddProduct(Product product, string userId);
        public Favorite TryGetByUserId(string userId);


        //public List<Product> GetProducts();


    }
}