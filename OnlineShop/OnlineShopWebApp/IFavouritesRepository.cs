using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IFavouritesRepository
    {
        List<ProductViewModel> GetFavourites();
        void Add(ProductViewModel product);
        void Clear();
        void Delete(ProductViewModel product);
    }
}
