using Microsoft.EntityFrameworkCore;
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

     
        public List<Product> GetProducts(string userId)
        {
            var favorite = TryGetFavoriteByUserId(userId);
       
            return favorite.Products;
        }

        public void AddProduct(Product product, string userId)
        {

            var favorite = TryGetFavoriteByUserId(userId);
            if (favorite == null)
            {
                favorite = new Favorite
                {
                    UserId = userId,

                };
                favorite.Products.Add(product);
                dataBaseContext.Favorites.Add(favorite);

            }
            else
            {

                if (favorite.Products.FirstOrDefault(x => x.Id == product.Id) == null)
                {
                    favorite.Products.Add(product);
                }
            }
          

            dataBaseContext.SaveChanges();
        }

        public Favorite TryGetFavoriteByUserId(string userId)
        {
            return dataBaseContext.Favorites.Include(x => x.Products).FirstOrDefault(f => f.UserId == userId);

            
        }

       
    }
}