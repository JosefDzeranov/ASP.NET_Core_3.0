using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
           new Product("Незнайка на луне", 345.6m , "Описание товара", "/images/book.png" ),
           new Product("Что делать?", 556.5m,"Описание товара", "/images/book.png"),
           new Product("Остров сокровищ", 999.0m,"Описание товара", "/images/book.png"),
           new Product("Одисея капитана Блада", 1360.4m,"Описание товара", "/images/book.png"),
           new Product("Война и мир", 790.6m,"Описание товара", "/images/book.png")

        };

        
        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }
    }
}
