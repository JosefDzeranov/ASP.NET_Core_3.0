using OnlineShop.Db;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OOnlineShop.Db
{
    public class FavoritesManager : IFavoritesManager
    {
        private readonly DataBaseContext dataBaseContext;
        public FavoritesManager(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        //public List<Product> products = new List<Product>();
        //public List<Product> Products
        //{
        //    get
        //    {
        //        return products;
        //    }
        //}
        public List<Product> GetProducts(string userId)
        {
            return TryGetByUserId(userId).Products;
        }

        public void AddProduct(Product product, string userId)
        {
           

            TryGetByUserId(userId).Products.ToList().Add(product);
            dataBaseContext.SaveChanges();
        }

        public Favorite TryGetByUserId(string userId)
        {
            return dataBaseContext.Favorites.FirstOrDefault(f => f.UserId == userId);
        }

        //public List<Product> GetProducts()
        //{
        //    return Products;
        //}

    }
}