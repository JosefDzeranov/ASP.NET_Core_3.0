using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private List<Favourite> favourite = new List<Favourite>();

        public Favourite TryGetByUserId(string userId)
        {
            return favourite.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var exsitingFavourite = TryGetByUserId(userId);

            if (exsitingFavourite == null)
            {
                var newfavoritesList = new Favourite(userId);
                newfavoritesList.Products.Add(product);
                favourite.Add(newfavoritesList);
            }
            else
            {
                var productInList = exsitingFavourite.Products.FirstOrDefault(item => item.Id == product.Id);
                if (productInList == null)
                {
                    exsitingFavourite.Products.Add(product);
                }
            }
        }
        public void Clear(Product product, string userId)
        {
            var existingFavourite = TryGetByUserId(userId);
            favourite.Remove(existingFavourite);
        }
    }
}
