using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public partial class InMemoryProductsRepository: IProductsRepository
    {
        public List<Product> products = new List<Product>()
        {
            new Product("Teapot", 10, "Discription", "/images/item1.png"),
            new Product("Tea mug", 20, "Discription", "/images/item2.png"),
            new Product("Dish", 30, "Discription", "/images/item3.png"),
            new Product("Mug", 40, "Discription", "/images/item4.png"),
            new Product("Coffee mug", 50, "Discription", "/images/item5.png"),
            new Product("Bowl", 60, "Discription", "/images/item6.png"),
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id==id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
