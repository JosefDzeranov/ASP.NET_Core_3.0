using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product (
                "RTX 3080", 130000, "Видеокарта из серии RTX-3000", "/images/RT3080.png"
                ),
            new Product (
                "RTX 3090", 95000, "Видеокарта из серии RTX-3000", "/images/RT3090.png"
                ),
            new Product (
                "RTX 2080ti", 80000, "Видеокарта из серии RTX-2000", "/images/RT2080TI.png"
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
    }
}
