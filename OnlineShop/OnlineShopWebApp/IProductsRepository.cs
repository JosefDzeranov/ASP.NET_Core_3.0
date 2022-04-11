using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        private static List<Product> products;
        public List<Product> GetAll();
        public Product TryGetById() { return null; }
    }
}
