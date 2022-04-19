using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IFavouritesRepozitory
    {
        List<Product> GetFavourites();
        void Add(Product product);
        void ClearFavourites();
        void Delete(Product product);
    }
}
