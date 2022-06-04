using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavoritesManager
    {
        //public List<Product> Products { get; }
        public List<Product> GetProducts(string userId);
        public void AddProduct(Product product, string userId);
        public Favorite TryGetFavoriteByUserId(string userId);
        void RemoveProduct(string userId, Guid id);


        //public List<Product> GetProducts();


    }
}