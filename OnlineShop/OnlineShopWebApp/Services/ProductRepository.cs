using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
           new Product(1, "Незнайка на луне", 345.6m , "Описание товара", "/images/book.png" ),
           new Product(2, "Что делать?", 556.5m,"Описание товара", "/images/book.png"),
           new Product(3, "Остров сокровищ", 999.0m,"Описание товара", "/images/book.png"),
           new Product(4, "Одисея капитана Блада", 1360.4m,"Описание товара", "/images/book.png"),
           new Product(5, "Война и мир", 790.6m,"Описание товара", "/images/book.png")

        };

        //пока не нужен
        public void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

    }
}
