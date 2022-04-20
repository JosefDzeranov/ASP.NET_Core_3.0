using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryFavouritesRepository : IFavouritesRepository
    {
        private List<Product> favourites = new List<Product>();

        public List<Product> GetFavourites()
        {
            return favourites;
        }

        public void Add(Product product)
        {
            var existingProduct = favourites.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                favourites.Add(product);
            }

        }

        public void Clear()
        {
            favourites.Clear();
        }
        public void Delete(Product product)
        {
            favourites.Remove(product);
        }
    }
}
