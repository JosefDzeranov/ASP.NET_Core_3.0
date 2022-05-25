using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product (
                "RTX 3080", 130000, "Видеокарта из серии RTX-3000", "Графический процессор - GeForce RTX 3080",
                "Тип памяти GDDR6X", "Объем видеопамяти 10 ГБ", "Штатная частота работы видеочипа 1440 МГц", "Турбочастота 1740 МГц", "/images/RT3080.png"
                ),
            new Product (
                "RTX 3090", 230000, "Видеокарта из серии RTX-3000", "Графический процессор - GeForce RTX 3090",
                "Тип памяти GDDR6X", "Объем видеопамяти 24 ГБ", "Штатная частота работы видеочипа 1400 МГц", "Турбочастота 1755 МГц", "/images/RT3090.png"
                ),
            new Product (
                "RTX 2080ti", 80000, "Видеокарта из серии RTX-2000", "Графический процессор - GeForce RTX 2080 Ti",
                "Тип памяти GDDR6", "Объем видеопамяти 11 ГБ", "Штатная частота работы видеочипа 1600 МГц", "Турбочастота 1755 МГц", "/images/RT2080TI.png"
                ),
        };

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product TryGetByid(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Edit(Product newProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == newProduct.Id);
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Description = newProduct.Description;
            product.ImagesPath = newProduct.ImagesPath;
        }
        public void Clear(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
        }
    }
}
