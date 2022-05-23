using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryFavouritesRepository : IFavouritesRepository
    {
        private List<ProductViewModel> favourites = new List<ProductViewModel>();

        public List<ProductViewModel> GetFavourites()
        {
            return favourites;
        }

        public void Add(ProductViewModel product)
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
        public void Delete(ProductViewModel product)
        {
            favourites.Remove(product);
        }
    }
}
