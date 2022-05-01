using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductManager
    {
        public List<Product> ProductList { get; set; }
       
        public Product FindProduct(int id);

    }
}
