using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface ICartsStorage
    {
        public CartsStorage cartsStorage
        {
            get;
        }

        //private readonly Constants constants;

        public Product TryGetByUserId(string userId);

        public Product TryGetProduct(int productId);

        public Product GetByUserId(string userId);

        //public void Add(Product product, Constants.UserId);

        public List<Product> GetAll();
        void Add(Product product, string userId);
    }
}
