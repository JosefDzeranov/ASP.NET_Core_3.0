using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IProductBase
    {
        Product TryGetById(int id);
        public List<Product> GetAll();
        
    }
}
