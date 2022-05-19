using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IComparesRepository
    {
        List<ComparingProduct> GetCompare();
        void Add(ComparingProduct product);

        void Clear();
        void Delete(ComparingProduct product);

    }
}