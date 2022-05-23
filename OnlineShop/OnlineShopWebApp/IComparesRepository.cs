using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IComparesRepository
    {
        List<ProductViewModel> GetCompare();
        void Add(ProductViewModel product);

        void Clear();
        void Delete(ProductViewModel product);

    }
}