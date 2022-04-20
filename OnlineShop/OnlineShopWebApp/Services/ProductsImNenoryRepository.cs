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
                "RTX 3080", 130000, "Видеокарта из серии RTX-3000", "/images/geforce_rtx_3080_fe.png"
                ),
            new Product (
                "Iphone 13 PRO", 115000, "Новый Iphone 13 PRO", "/images/Iphone13Pro.png"
                ),
            new Product (
                "Sony PS 5", 900000, "Новинка Sony", "/images/PS5.png"
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
